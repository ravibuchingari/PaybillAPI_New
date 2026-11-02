-- =================================================================================
-- PayBill Database Schema Sync Script (Matches Updated DTO Models & AppDBContext)
-- Database: paybill_api
-- =================================================================================

SET FOREIGN_KEY_CHECKS = 0;

-- ---------------------------------------------------------------------------------
-- 1. Align `client` / `clients` table name with DTO/Client.cs ([Table("client")])
--    (If your table is currently named `clients`, rename it to `client` so EF Core
--     `[Table("client")]` maps to it, or keep `clients` if you change [Table("clients")])
-- ---------------------------------------------------------------------------------
-- RENAME TABLE `clients` TO `client`;

-- ---------------------------------------------------------------------------------
-- 2. Seed Required Lookup Statuses (`service_request_status` & `order_status`)
-- ---------------------------------------------------------------------------------
INSERT IGNORE INTO `service_request_status` (`ServiceRequestStatusId`, `ServiceRequestStatusName`) VALUES
(1, 'Pending'),
(2, 'InProgress'),
(3, 'Completed'),
(4, 'Cancelled'),
(5, 'Delivered');

INSERT IGNORE INTO `order_status` (`OrderStatusId`, `OrderStatusDesc`) VALUES
(1, 'New'),
(2, 'InProgress'),
(3, 'Ready'),
(4, 'Delivered'),
(5, 'Cancelled');

-- ---------------------------------------------------------------------------------
-- 3. `job_cards` — Add Foreign Keys matching DTO/JobCard.cs
-- ---------------------------------------------------------------------------------
ALTER TABLE `job_cards`
  ADD INDEX `fk_job_cards_sales_id_idx` (`SalesId`),
  ADD INDEX `fk_job_cards_created_by_idx` (`CreatedBy`),
  ADD INDEX `fk_job_cards_updated_by_idx` (`UpdatedBy`),
  ADD CONSTRAINT `fk_job_cards_party_id`
    FOREIGN KEY (`PartyId`) REFERENCES `parties` (`PartyId`),
  ADD CONSTRAINT `fk_job_cards_status_id`
    FOREIGN KEY (`ServiceRequestStatusId`) REFERENCES `service_request_status` (`ServiceRequestStatusId`),
  ADD CONSTRAINT `fk_job_cards_sales_id`
    FOREIGN KEY (`SalesId`) REFERENCES `sales` (`SalesId`) ON DELETE SET NULL,
  ADD CONSTRAINT `fk_job_cards_created_by`
    FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  ADD CONSTRAINT `fk_job_cards_updated_by`
    FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`);

-- ---------------------------------------------------------------------------------
-- 4. `job_card_items` — Add Foreign Keys matching DTO/JobCardItem.cs
-- ---------------------------------------------------------------------------------
ALTER TABLE `job_card_items`
  ADD CONSTRAINT `fk_job_card_items_req_id`
    FOREIGN KEY (`ServiceRequestId`) REFERENCES `job_cards` (`ServiceRequestId`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_job_card_items_stype_id`
    FOREIGN KEY (`ServiceTypeId`) REFERENCES `service_types` (`ServiceTypeId`);

-- ---------------------------------------------------------------------------------
-- 5. `job_card_spares` — Add Foreign Keys matching DTO/JobCardSpare.cs
-- ---------------------------------------------------------------------------------
ALTER TABLE `job_card_spares`
  ADD CONSTRAINT `fk_job_card_spares_req_id`
    FOREIGN KEY (`ServiceRequestId`) REFERENCES `job_cards` (`ServiceRequestId`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_job_card_spares_item_id`
    FOREIGN KEY (`ItemId`) REFERENCES `items` (`ItemId`);

-- ---------------------------------------------------------------------------------
-- 6. `reward_transactions` — Clean up nullable FKs & Add Foreign Keys
--    matching DTO/RewardTransaction.cs
-- ---------------------------------------------------------------------------------
ALTER TABLE `reward_transactions`
  MODIFY COLUMN `SalesId` int DEFAULT NULL,
  MODIFY COLUMN `RefTransId` int DEFAULT NULL,
  MODIFY COLUMN `CreatedBy` int DEFAULT NULL;

UPDATE `reward_transactions` SET `SalesId` = NULL WHERE `SalesId` = 0;

-- Note: In POS Sales, customer rewards use `parties.PartyId`.
-- If `DTO/RewardTransaction.cs` uses `[ForeignKey("PartyId")] public virtual Party? Party`,
-- reference `parties(PartyId)`. If referencing `customers(CustomerRowId)`, change `parties`(`PartyId`) below.
ALTER TABLE `reward_transactions`
  ADD CONSTRAINT `fk_reward_trans_party_id`
    FOREIGN KEY (`PartyId`) REFERENCES `parties` (`PartyId`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_reward_trans_sales_id`
    FOREIGN KEY (`SalesId`) REFERENCES `sales` (`SalesId`) ON DELETE SET NULL;

-- ---------------------------------------------------------------------------------
-- 7. `order_items` — Ensure AUTO_INCREMENT on Primary Key & FK to `items`
-- ---------------------------------------------------------------------------------
ALTER TABLE `order_items`
  MODIFY COLUMN `OrderItemRowId` int NOT NULL AUTO_INCREMENT,
  ADD INDEX `fk_order_items_item_id_idx` (`ItemId`),
  ADD CONSTRAINT `fk_order_items_item_id`
    FOREIGN KEY (`ItemId`) REFERENCES `items` (`ItemId`);

-- ---------------------------------------------------------------------------------
-- 8. `settings` — Ensure default on `LocalLanguageCode` and drop duplicate typo column
-- ---------------------------------------------------------------------------------
ALTER TABLE `settings`
  MODIFY COLUMN `LocalLanguageCode` varchar(2) NOT NULL DEFAULT 'te';

-- ---------------------------------------------------------------------------------
-- 9. Recreate Required Database Triggers (Stock Updates, Invoice Numbering, Audit Log)
-- ---------------------------------------------------------------------------------
DROP TRIGGER IF EXISTS `purchase_items_AFTER_INSERT`;
DROP TRIGGER IF EXISTS `purchase_items_AFTER_UPDATE`;
DROP TRIGGER IF EXISTS `purchase_items_AFTER_DELETE`;
DROP TRIGGER IF EXISTS `sales_BEFORE_INSERT`;
DROP TRIGGER IF EXISTS `sales_items_AFTER_INSERT`;
DROP TRIGGER IF EXISTS `sales_items_AFTER_UPDATE`;
DROP TRIGGER IF EXISTS `sales_items_AFTER_DELETE`;

DELIMITER ;;

CREATE TRIGGER `purchase_items_AFTER_INSERT` AFTER INSERT ON `purchase_items` FOR EACH ROW BEGIN
    UPDATE items SET ClosingStock = ClosingStock + NEW.Quantity WHERE ItemId = NEW.ItemId;
END;;

CREATE TRIGGER `purchase_items_AFTER_UPDATE` AFTER UPDATE ON `purchase_items` FOR EACH ROW BEGIN
    UPDATE items SET ClosingStock = ClosingStock - OLD.Quantity + NEW.Quantity WHERE ItemId = NEW.ItemId;
END;;

CREATE TRIGGER `purchase_items_AFTER_DELETE` AFTER DELETE ON `purchase_items` FOR EACH ROW BEGIN
    DECLARE v_PurchaseType varchar(20);
    SELECT PurchaseType INTO v_PurchaseType FROM purchase WHERE PurchaseId = OLD.PurchaseId;

    IF LCASE(v_PurchaseType) = 'cash' THEN
        UPDATE transactions
           SET ReceiptAmount = ReceiptAmount - OLD.TotalAmount,
               PaymentAmount = PaymentAmount - OLD.TotalAmount
         WHERE PurchaseId = OLD.PurchaseId;
    ELSE
        UPDATE transactions
           SET ReceiptAmount = ReceiptAmount - OLD.TotalAmount
         WHERE PurchaseId = OLD.PurchaseId;
    END IF;

    UPDATE items SET ClosingStock = ClosingStock - OLD.Quantity WHERE ItemId = OLD.ItemId;

    INSERT INTO purchase_items_deleted (
        PurchaseId, ItemId, Quantity, Rate, Amount, DiscountInRs, TaxableAmount,
        CgstPer, SgstPer, IgstPer, GstPer, CgstRs, SgstRs, IgstRs, GstAmount,
        TotalAmount, CreatedDate, DeletedBy, DeletedRemarks
    ) VALUES (
        OLD.PurchaseId, OLD.ItemId, OLD.Quantity, OLD.Rate, OLD.Amount, OLD.DiscountInRs, OLD.TaxableAmount,
        OLD.CgstPer, OLD.SgstPer, OLD.IgstPer, OLD.GstPer, OLD.CgstRs, OLD.SgstRs, OLD.IgstRs, OLD.GstAmount,
        OLD.TotalAmount, OLD.CreatedDate, OLD.DeletedBy, OLD.DeletedRemarks
    );
END;;

CREATE TRIGGER `sales_BEFORE_INSERT` BEFORE INSERT ON `sales` FOR EACH ROW BEGIN
    DECLARE v_InvoicePrefix varchar(8);
    DECLARE v_InvoiceLength tinyint;
    DECLARE v_Next_SalesId int;

    SELECT IFNULL(InvoicePrefix, ''), IFNULL(InvoiceLength, 6)
      INTO v_InvoicePrefix, v_InvoiceLength
      FROM settings LIMIT 1;

    SELECT MAX(SalesId) INTO v_Next_SalesId FROM sales;

    SET NEW.InvoiceNo = CONCAT(
        IFNULL(v_InvoicePrefix, ''),
        LPAD(IFNULL(v_Next_SalesId, 0) + 1, IFNULL(v_InvoiceLength, 6), 0)
    );
END;;

CREATE TRIGGER `sales_items_AFTER_INSERT` AFTER INSERT ON `sales_items` FOR EACH ROW BEGIN
    IF NEW.ItemId IS NOT NULL THEN
        UPDATE items SET ClosingStock = ClosingStock - NEW.Quantity WHERE ItemId = NEW.ItemId;
    END IF;
END;;

CREATE TRIGGER `sales_items_AFTER_UPDATE` AFTER UPDATE ON `sales_items` FOR EACH ROW BEGIN
    IF NEW.ItemId IS NOT NULL THEN
        UPDATE items SET ClosingStock = ClosingStock + OLD.Quantity - NEW.Quantity WHERE ItemId = NEW.ItemId;
    END IF;
END;;

CREATE TRIGGER `sales_items_AFTER_DELETE` AFTER DELETE ON `sales_items` FOR EACH ROW BEGIN
    DECLARE v_SalesType varchar(20);
    DECLARE v_PartyId int;

    SELECT PartyId, SalesType INTO v_PartyId, v_SalesType FROM sales WHERE SalesId = OLD.SalesId;

    IF v_PartyId IS NOT NULL THEN
        IF LCASE(v_SalesType) = 'cash' THEN
            UPDATE transactions
               SET ReceiptAmount = ReceiptAmount - OLD.TotalAmount,
                   PaymentAmount = PaymentAmount - OLD.TotalAmount
             WHERE SalesId = OLD.SalesId;
        ELSE
            UPDATE transactions
               SET PaymentAmount = PaymentAmount - OLD.TotalAmount
             WHERE SalesId = OLD.SalesId;
        END IF;
    END IF;

    IF OLD.ItemId IS NOT NULL THEN
        UPDATE items SET ClosingStock = ClosingStock + OLD.Quantity WHERE ItemId = OLD.ItemId;
    END IF;

    INSERT INTO sales_items_deleted (
        IsSalesItem, SalesId, ItemId, ServiceTypeId, Quantity, Rate, Mrp, Amount,
        DiscountInRs, CgstPer, SgstPer, IgstPer, GstPer, CgstRs, SgstRs, IgstRs,
        GstAmount, TaxableAmount, TotalAmount, CreatedDate, DeletedBy, DeletedRemarks
    ) VALUES (
        1, OLD.SalesId, OLD.ItemId, OLD.ServiceTypeId, OLD.Quantity, OLD.Rate, OLD.Mrp, OLD.Amount,
        OLD.DiscountInRs, OLD.CgstPer, OLD.SgstPer, OLD.IgstPer, OLD.GstPer, OLD.CgstRs, OLD.SgstRs, OLD.IgstRs,
        OLD.GstAmount, OLD.TaxableAmount, OLD.TotalAmount, OLD.CreatedDate, OLD.DeletedBy, OLD.DeletedRemarks
    );
END;;

DELIMITER ;

SET FOREIGN_KEY_CHECKS = 1;

