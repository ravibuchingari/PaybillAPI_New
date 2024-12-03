-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: paybill_api
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `categoryId` int NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(50) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `UpdatedDate` datetime NOT NULL,
  `CreatedBy` int NOT NULL,
  `UpdatedBy` int NOT NULL,
  PRIMARY KEY (`categoryId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `ClientUniqueId` varchar(150) NOT NULL,
  `ClientId` varchar(60) NOT NULL,
  `BusinessType` varchar(60) DEFAULT NULL,
  `ClientName` varchar(100) NOT NULL,
  `Mobile` varchar(10) NOT NULL,
  `Address` varchar(500) NOT NULL,
  `Email` varchar(150) DEFAULT NULL,
  `SubscriptionType` varchar(50) DEFAULT NULL,
  `SubscriptionAmount` double NOT NULL,
  `SubscriptionEndDate` date DEFAULT NULL,
  `IsPremiumUser` tinyint NOT NULL DEFAULT '0',
  `IsActivated` tinyint NOT NULL DEFAULT '0',
  `SecurityKey` varchar(60) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ClientUniqueId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `gst`
--

DROP TABLE IF EXISTS `gst`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gst` (
  `GstId` int NOT NULL AUTO_INCREMENT,
  `CgstPer` float NOT NULL,
  `SgstPer` float NOT NULL,
  `IgstPer` float NOT NULL,
  `IsActive` tinyint NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `UpdatedDate` datetime NOT NULL,
  `CreatedBy` int NOT NULL,
  `UpdatedBy` int NOT NULL,
  PRIMARY KEY (`GstId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `items`
--

DROP TABLE IF EXISTS `items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `items` (
  `ItemId` int NOT NULL AUTO_INCREMENT,
  `CategoryId` int NOT NULL,
  `GstId` int DEFAULT NULL,
  `ItemCode` varchar(50) NOT NULL,
  `ItemName` varchar(100) NOT NULL,
  `AliasName` varchar(250) DEFAULT NULL,
  `Mrp` float NOT NULL,
  `SalesPrice` float NOT NULL,
  `PurchasePrice` float NOT NULL,
  `HSNCode` varchar(20) DEFAULT NULL,
  `Measure` varchar(20) NOT NULL,
  `OpeningStock` double NOT NULL,
  `ClosingStock` double NOT NULL,
  `MinimumStock` double NOT NULL,
  `IsActive` tinyint NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `UpdatedDate` datetime NOT NULL,
  `CreatedBy` int NOT NULL,
  `UpdatedBy` int NOT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `fk_items_category_id_idx` (`CategoryId`),
  KEY `fk_items_gst_id_idx` (`GstId`),
  KEY `fk_items_created_by_idx` (`CreatedBy`),
  KEY `fk_items_updated_by_idx` (`UpdatedBy`),
  CONSTRAINT `fk_items_category_id` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`categoryId`),
  CONSTRAINT `fk_items_created_by` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_items_gst_id` FOREIGN KEY (`GstId`) REFERENCES `gst` (`GstId`),
  CONSTRAINT `fk_items_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `message_templates`
--

DROP TABLE IF EXISTS `message_templates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `message_templates` (
  `MessageId` int NOT NULL AUTO_INCREMENT,
  `MessageDescription` varchar(500) NOT NULL,
  PRIMARY KEY (`MessageId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `parties`
--

DROP TABLE IF EXISTS `parties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `parties` (
  `PartyId` int NOT NULL AUTO_INCREMENT,
  `PartyName` varchar(100) NOT NULL,
  `PartyAddress` varchar(500) NOT NULL,
  `PartyMobile` varchar(10) DEFAULT NULL,
  `PartyEmail` varchar(150) DEFAULT NULL,
  `PartyGstNo` varchar(15) DEFAULT NULL,
  `PartyRemarks` varchar(500) DEFAULT NULL,
  `IsVendor` tinyint NOT NULL,
  `IsActive` tinyint NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` int NOT NULL,
  `UpdatedBy` int NOT NULL,
  PRIMARY KEY (`PartyId`),
  KEY `fk_parties_created_by_idx` (`CreatedBy`),
  KEY `fk_parties_updated_by_idx` (`UpdatedBy`),
  CONSTRAINT `fk_parties_created_by` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_parties_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `purchase`
--

DROP TABLE IF EXISTS `purchase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchase` (
  `PurchaseId` int NOT NULL AUTO_INCREMENT,
  `PartyId` int NOT NULL,
  `InvoiceNo` varchar(20) NOT NULL,
  `InvoiceDate` date NOT NULL,
  `PurchaseType` varchar(20) NOT NULL,
  `PaymentMode` varchar(20) NOT NULL,
  `UpiType` varchar(12) DEFAULT NULL,
  `Remarks` varchar(500) DEFAULT NULL,
  `IsLocked` tinyint NOT NULL DEFAULT '1',
  `CreatedDate` datetime NOT NULL,
  `UpdatedDate` datetime NOT NULL,
  `CreatedBy` int NOT NULL,
  `UpdatedBy` int NOT NULL,
  PRIMARY KEY (`PurchaseId`),
  KEY `fk_purchase_created_by_idx` (`CreatedBy`),
  KEY `fk_purchase_updated_by_idx` (`UpdatedBy`),
  KEY `fk_purchase_partry_id_idx` (`PartyId`),
  CONSTRAINT `fk_purchase_created_by` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_purchase_partry_id` FOREIGN KEY (`PartyId`) REFERENCES `parties` (`PartyId`),
  CONSTRAINT `fk_purchase_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `purchase_items`
--

DROP TABLE IF EXISTS `purchase_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchase_items` (
  `PurchaseItemId` int NOT NULL AUTO_INCREMENT,
  `PurchaseId` int NOT NULL,
  `ItemId` int NOT NULL,
  `Quantity` float NOT NULL,
  `Rate` float NOT NULL,
  `Amount` double NOT NULL,
  `DiscountInRs` double NOT NULL,
  `TaxableAmount` double NOT NULL,
  `CgstPer` float NOT NULL,
  `SgstPer` float NOT NULL,
  `IgstPer` float NOT NULL,
  `GstPer` float NOT NULL,
  `CgstRs` double NOT NULL,
  `SgstRs` double NOT NULL,
  `IgstRs` double NOT NULL,
  `GstAmount` double NOT NULL,
  `TotalAmount` double NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `DeletedBy` int DEFAULT NULL,
  `DeletedRemarks` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`PurchaseItemId`),
  KEY `fk_purchase_item_purchase_id_idx` (`PurchaseId`),
  KEY `fk_purchase_item_item_id_idx` (`ItemId`),
  CONSTRAINT `fk_purchase_item_item_id` FOREIGN KEY (`ItemId`) REFERENCES `items` (`ItemId`),
  CONSTRAINT `fk_purchase_item_purchase_id` FOREIGN KEY (`PurchaseId`) REFERENCES `purchase` (`PurchaseId`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `purchase_items_AFTER_INSERT` AFTER INSERT ON `purchase_items` FOR EACH ROW BEGIN
	update items set ClosingStock = ClosingStock + new.Quantity where ItemId = new.ItemId;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `purchase_items_AFTER_UPDATE` AFTER UPDATE ON `purchase_items` FOR EACH ROW BEGIN
	update items set ClosingStock = ClosingStock - old.Quantity + new.Quantity where ItemId = new.ItemId;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `purchase_items_AFTER_DELETE` AFTER DELETE ON `purchase_items` FOR EACH ROW BEGIN
	declare v_PurchaseType varchar(20);
    
    select PurchaseType into v_PurchaseType from purchase where PurchaseId = old.PurchaseId;
    
    if lcase(v_PurchaseType) = 'cash' then
    
		update transactions set ReceiptAmount = ReceiptAmount - old.TotalAmount,
								PaymentAmount = PaymentAmount - old.TotalAmount
        where PurchaseId = old.PurchaseId;
        
	else
		update transactions set ReceiptAmount = ReceiptAmount - old.TotalAmount  where PurchaseId = old.PurchaseId;
    end if;
    
    update items set ClosingStock = ClosingStock - old.Quantity where ItemId = old.ItemId;
    
    INSERT INTO purchase_items_deleted (PurchaseId, ItemId, Quantity, Rate, Amount, DiscountInRs, TaxableAmount, CgstPer, SgstPer, IgstPer, GstPer, CgstRs, SgstRs, IgstRs, GstAmount, TotalAmount, CreatedDate, DeletedBy, DeletedRemarks) VALUES(old.PurchaseId, old.ItemId, old.Quantity, old.Rate, old.Amount, old.DiscountInRs, old.TaxableAmount, old.CgstPer, old.SgstPer, old.IgstPer, old.GstPer, old.CgstRs, old.SgstRs, old.IgstRs, old.GstAmount, old.TotalAmount, old.CreatedDate, old.DeletedBy, old.DeletedRemarks);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `purchase_items_deleted`
--

DROP TABLE IF EXISTS `purchase_items_deleted`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchase_items_deleted` (
  `purchaseDeletedItemId` int NOT NULL AUTO_INCREMENT,
  `PurchaseId` int NOT NULL,
  `ItemId` int NOT NULL,
  `Quantity` float NOT NULL,
  `Rate` float NOT NULL,
  `Amount` double NOT NULL,
  `DiscountInRs` double NOT NULL,
  `TaxableAmount` double NOT NULL,
  `CgstPer` float NOT NULL,
  `SgstPer` float NOT NULL,
  `IgstPer` float NOT NULL,
  `GstPer` float NOT NULL,
  `CgstRs` double NOT NULL,
  `SgstRs` double NOT NULL,
  `IgstRs` double NOT NULL,
  `GstAmount` double NOT NULL,
  `TotalAmount` double NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DeletedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DeletedBy` int NOT NULL,
  `DeletedRemarks` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`purchaseDeletedItemId`),
  KEY `fk_deleted_purchaseitem_item_id_idx` (`ItemId`),
  KEY `fk_deleted_purchase_item_deleted_ny_idx` (`DeletedBy`),
  CONSTRAINT `fk_deleted_purchaseitem_deleted_by` FOREIGN KEY (`DeletedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_deleted_purchaseitem_item_id` FOREIGN KEY (`ItemId`) REFERENCES `items` (`ItemId`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sales`
--

DROP TABLE IF EXISTS `sales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sales` (
  `SalesId` int NOT NULL AUTO_INCREMENT,
  `PartyId` int DEFAULT NULL,
  `InvoiceNo` varchar(20) NOT NULL,
  `InvoiceDate` date NOT NULL,
  `SalesType` varchar(20) NOT NULL,
  `PaymentMode` varchar(20) NOT NULL,
  `UpiType` varchar(12) DEFAULT NULL,
  `PaidAmount` double NOT NULL,
  `BalanceAmount` double NOT NULL,
  `IsLocked` tinyint NOT NULL DEFAULT '1',
  `Remarks` varchar(250) DEFAULT NULL,
  `CreatedBy` int NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `EndUserMobile` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`SalesId`),
  UNIQUE KEY `InvoiceNo_UNIQUE` (`InvoiceNo`),
  KEY `fk_sales_party_id_idx` (`PartyId`),
  KEY `fk_sales_created_by_idx` (`CreatedBy`),
  KEY `fk_sales_updated_by_idx` (`UpdatedBy`),
  CONSTRAINT `fk_sales_created_by` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_sales_party_id` FOREIGN KEY (`PartyId`) REFERENCES `parties` (`PartyId`),
  CONSTRAINT `fk_sales_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `sales_BEFORE_INSERT` BEFORE INSERT ON `sales` FOR EACH ROW BEGIN
	declare v_InvoicePrefix varchar(8);
    declare v_InvoiceLength tinyint;
    declare v_Next_SalesId int;
    
    select InvoicePrefix, InvoiceLength into v_InvoicePrefix, v_InvoiceLength from settings limit 1;
    
    select max(SalesId) into v_Next_SalesId from sales;
    
    set new.InvoiceNo = concat(v_InvoicePrefix,lpad(ifnull(v_Next_SalesId,0) + 1,v_InvoiceLength,0));
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `sales_items`
--

DROP TABLE IF EXISTS `sales_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sales_items` (
  `SalesItemId` int NOT NULL AUTO_INCREMENT,
  `SalesId` int NOT NULL,
  `ItemId` int DEFAULT NULL,
  `ServiceTypeId` int DEFAULT NULL,
  `Quantity` float NOT NULL,
  `Rate` float NOT NULL,
  `Mrp` float NOT NULL,
  `Amount` double NOT NULL,
  `DiscountInRs` double NOT NULL,
  `TaxableAmount` double NOT NULL,
  `CgstPer` float NOT NULL,
  `SgstPer` float NOT NULL,
  `IgstPer` float NOT NULL,
  `GstPer` float NOT NULL,
  `CgstRs` double NOT NULL,
  `SgstRs` double NOT NULL,
  `IgstRs` double NOT NULL,
  `GstAmount` double NOT NULL,
  `TotalAmount` double NOT NULL,
  `PurchasePrice` double NOT NULL DEFAULT '0',
  `CreatedDate` datetime NOT NULL,
  `DeletedBy` int DEFAULT NULL,
  `DeletedRemarks` varchar(250) DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`SalesItemId`),
  KEY `fk_sales_item_sales_id_idx` (`SalesId`),
  KEY `fk_sales_item_item_id_idx` (`ItemId`),
  KEY `fk_sales_item_service_type_id_idx` (`ServiceTypeId`),
  KEY `fk_sales_item_updated_by_idx` (`UpdatedBy`),
  CONSTRAINT `fk_sales_item_item_id` FOREIGN KEY (`ItemId`) REFERENCES `items` (`ItemId`),
  CONSTRAINT `fk_sales_item_sales_id` FOREIGN KEY (`SalesId`) REFERENCES `sales` (`SalesId`),
  CONSTRAINT `fk_sales_item_service_type_id` FOREIGN KEY (`ServiceTypeId`) REFERENCES `service_types` (`ServiceTypeId`),
  CONSTRAINT `fk_sales_item_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB AUTO_INCREMENT=114 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `sales_items_AFTER_INSERT` AFTER INSERT ON `sales_items` FOR EACH ROW BEGIN
	if new.ItemId is not null then
		update items set ClosingStock = ClosingStock - new.Quantity where ItemId = new.ItemId;
    end if;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `sales_items_AFTER_UPDATE` AFTER UPDATE ON `sales_items` FOR EACH ROW BEGIN
	if new.ItemId is not null then
		update items set ClosingStock = ClosingStock + old.Quantity - new.Quantity where ItemId = new.ItemId;
	end if;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `sales_items_AFTER_DELETE` AFTER DELETE ON `sales_items` FOR EACH ROW BEGIN
	declare v_SalesType varchar(20);
    declare v_PartyId int;
    
    select PartyId, SalesType into v_PartyId, v_SalesType from sales where SalesId = old.SalesId;
    
    if v_PartyId is not null then
    
        if lcase(v_SalesType) = 'cash' then
    
			update transactions set ReceiptAmount = ReceiptAmount - old.TotalAmount,
									PaymentAmount = PaymentAmount - old.TotalAmount
			where SalesId = old.SalesId;
			
		else
			update transactions set PaymentAmount = PaymentAmount - old.TotalAmount  where SalesId = old.SalesId;
		end if;
    
    end if;
    
    if old.ItemId is not null then
		update items set ClosingStock = ClosingStock + old.Quantity where ItemId = old.ItemId;
	end if;
    
    INSERT INTO sales_items_deleted (IsSalesItem, SalesId, ItemId, ServiceTypeId, Quantity, Rate, Mrp, Amount, DiscountInRs, CgstPer, SgstPer, IgstPer, GstPer, CgstRs, SgstRs, IgstRs, GstAmount, TaxableAmount, TotalAmount, CreatedDate, DeletedBy, DeletedRemarks) VALUES(1, old.SalesId, old.ItemId, old.ServiceTypeId, old.Quantity, old.Rate, old.Mrp, old.Amount, old.DiscountInRs, old.CgstPer, old.SgstPer, old.IgstPer, old.GstPer, old.CgstRs, old.SgstRs, old.IgstRs, old.GstAmount, old.TaxableAmount, old.TotalAmount, old.CreatedDate, old.DeletedBy, old.DeletedRemarks);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `sales_items_deleted`
--

DROP TABLE IF EXISTS `sales_items_deleted`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sales_items_deleted` (
  `salesDeletedItemId` int NOT NULL AUTO_INCREMENT,
  `IsSalesItem` tinyint NOT NULL,
  `SalesId` int NOT NULL,
  `ItemId` int DEFAULT NULL,
  `ServiceTypeId` int DEFAULT NULL,
  `Quantity` float NOT NULL,
  `Rate` float NOT NULL,
  `Mrp` float NOT NULL,
  `Amount` double NOT NULL,
  `DiscountInRs` double NOT NULL,
  `TaxableAmount` double NOT NULL,
  `CgstPer` float NOT NULL,
  `SgstPer` float NOT NULL,
  `IgstPer` float NOT NULL,
  `GstPer` float NOT NULL,
  `CgstRs` double NOT NULL,
  `SgstRs` double NOT NULL,
  `IgstRs` double NOT NULL,
  `GstAmount` double NOT NULL,
  `TotalAmount` double NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `DeletedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DeletedBy` int NOT NULL,
  `DeletedRemarks` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`salesDeletedItemId`),
  KEY `fk_deleted_salesitem_item_id_idx` (`ItemId`),
  KEY `fk_deleted_salesitem_service_type_id_idx` (`ServiceTypeId`),
  KEY `fk_deleted_sales_item_deleted_by_idx` (`DeletedBy`),
  CONSTRAINT `fk_deleted_sales_item_deleted_by` FOREIGN KEY (`DeletedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_deleted_salesitem_item_id` FOREIGN KEY (`ItemId`) REFERENCES `items` (`ItemId`),
  CONSTRAINT `fk_deleted_salesitem_service_type_id` FOREIGN KEY (`ServiceTypeId`) REFERENCES `service_types` (`ServiceTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `service_types`
--

DROP TABLE IF EXISTS `service_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `service_types` (
  `ServiceTypeId` int NOT NULL AUTO_INCREMENT,
  `ServiceTypeName` varchar(100) NOT NULL,
  `ServiceCharge` double NOT NULL,
  `ServiceDescription` varchar(500) DEFAULT NULL,
  `SacCode` varchar(20) DEFAULT NULL,
  `GstId` int DEFAULT NULL,
  `IsActive` tinyint NOT NULL,
  `CreatedBy` int NOT NULL,
  `UpdatedBy` int NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `UpdatedDate` datetime NOT NULL,
  PRIMARY KEY (`ServiceTypeId`),
  KEY `fk_service_types_gst_id_idx` (`GstId`),
  KEY `fk_service_type_createdby_idx` (`CreatedBy`),
  KEY `fk_service_type_updatedby_idx` (`UpdatedBy`),
  CONSTRAINT `fk_service_type_createdby` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_service_type_updatedby` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_service_types_gst_id` FOREIGN KEY (`GstId`) REFERENCES `gst` (`GstId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `settings`
--

DROP TABLE IF EXISTS `settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `settings` (
  `RowId` tinyint NOT NULL,
  `CompanyName` varchar(48) NOT NULL,
  `SmtpHost` varchar(100) DEFAULT NULL,
  `SmtpPort` varchar(10) DEFAULT NULL,
  `EmailFrom` varchar(150) DEFAULT NULL,
  `EmailTo` varchar(150) DEFAULT NULL,
  `EmailPassword` varchar(250) DEFAULT NULL,
  `IsAutoEmail` tinyint NOT NULL,
  `IsBackupOnExit` tinyint NOT NULL,
  `IsDiscountEnabled` tinyint NOT NULL,
  `InvoiceTitle` varchar(48) DEFAULT NULL,
  `Header1` varchar(48) DEFAULT NULL,
  `Header2` varchar(48) DEFAULT NULL,
  `Header3` varchar(48) DEFAULT NULL,
  `GSTIN` varchar(15) DEFAULT NULL,
  `GSTSlabRequired` tinyint NOT NULL,
  `ItemWiseGSTSlabRequired` tinyint NOT NULL DEFAULT '0',
  `AddItemOnSelected` tinyint NOT NULL,
  `InvoicePrefix` varchar(8) DEFAULT NULL,
  `InvoiceLength` tinyint NOT NULL DEFAULT '6',
  `IsCreateContactOnParty` tinyint NOT NULL,
  `IsCompressBackup` tinyint NOT NULL,
  `IsShadowMenuButton` tinyint NOT NULL,
  `IsBiometricAuthEnabled` tinyint NOT NULL,
  `IsAlertOnMinimumStock` tinyint NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` int NOT NULL,
  `UpdatedBy` int NOT NULL,
  `ItemCodeAllowNumberOnly` tinyint NOT NULL DEFAULT '1',
  `IsPaymentDetailsRequired` tinyint NOT NULL DEFAULT '1',
  `IsSavingDetailsRequired` tinyint NOT NULL DEFAULT '1',
  `IsGstSummaryRequired` tinyint NOT NULL DEFAULT '1',
  `IsSoundEnabled` tinyint NOT NULL DEFAULT '1',
  `IsSendSMSOnInvoice` tinyint NOT NULL DEFAULT '1',
  `SalesMessageId` int DEFAULT NULL,
  `ServiceMessageId` int DEFAULT NULL,
  `BalanceMessageId` int DEFAULT NULL,
  `FestivalMessageId` int DEFAULT NULL,
  `UPIId` varchar(60) DEFAULT NULL,
  `UPIName` varchar(100) DEFAULT NULL,
  `UPIMerchantCode` varchar(30) DEFAULT NULL,
  `isServiceRequestEnabled` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`RowId`),
  KEY `fk_settings_created_by_idx` (`CreatedBy`),
  KEY `fk_settings_updated_by_idx` (`UpdatedBy`),
  KEY `fk_settings_sales_message_id_idx` (`SalesMessageId`),
  KEY `fk_settings_service_message_id_idx` (`ServiceMessageId`),
  KEY `fk_settings_balance_message_id_idx` (`BalanceMessageId`),
  KEY `fk_settings_festival_message_id_idx` (`FestivalMessageId`),
  CONSTRAINT `fk_settings_balance_message_id` FOREIGN KEY (`BalanceMessageId`) REFERENCES `message_templates` (`MessageId`),
  CONSTRAINT `fk_settings_created_by` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_settings_festival_message_id` FOREIGN KEY (`FestivalMessageId`) REFERENCES `message_templates` (`MessageId`),
  CONSTRAINT `fk_settings_sales_message_id` FOREIGN KEY (`SalesMessageId`) REFERENCES `message_templates` (`MessageId`),
  CONSTRAINT `fk_settings_service_message_id` FOREIGN KEY (`ServiceMessageId`) REFERENCES `message_templates` (`MessageId`),
  CONSTRAINT `fk_settings_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `TransactionId` int NOT NULL AUTO_INCREMENT,
  `PartyId` int NOT NULL,
  `TransactionDate` date NOT NULL,
  `PaymentMode` varchar(20) NOT NULL,
  `UpiType` varchar(12) DEFAULT NULL,
  `ReceiptAmount` double NOT NULL DEFAULT '0',
  `PaymentAmount` double NOT NULL DEFAULT '0',
  `Remarks` varchar(500) DEFAULT NULL,
  `SalesId` int DEFAULT NULL,
  `PurchaseId` int DEFAULT NULL,
  `TransactionType` varchar(30) NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` int NOT NULL,
  `UpdatedBy` int NOT NULL,
  `DeletedBy` int DEFAULT NULL,
  `DeletedRemarks` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`TransactionId`),
  KEY `fk_transaction_party_id_idx` (`PartyId`),
  KEY `fk_transaction_sales_id_idx` (`SalesId`),
  KEY `fk_transaction_purchase_id_idx` (`PurchaseId`),
  KEY `fk_transaction_created_by_idx` (`CreatedBy`),
  KEY `fk_transaction_updated_by_idx` (`UpdatedBy`),
  CONSTRAINT `fk_transaction_created_by` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_transaction_party_id` FOREIGN KEY (`PartyId`) REFERENCES `parties` (`PartyId`),
  CONSTRAINT `fk_transaction_purchase_id` FOREIGN KEY (`PurchaseId`) REFERENCES `purchase` (`PurchaseId`),
  CONSTRAINT `fk_transaction_sales_id` FOREIGN KEY (`SalesId`) REFERENCES `sales` (`SalesId`),
  CONSTRAINT `fk_transaction_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `transactions_deleted`
--

DROP TABLE IF EXISTS `transactions_deleted`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions_deleted` (
  `DeletedTransactionId` int NOT NULL AUTO_INCREMENT,
  `PartyId` int DEFAULT NULL,
  `TransactionDate` date DEFAULT NULL,
  `PaymentMode` varchar(20) DEFAULT NULL,
  `UpiType` varchar(12) DEFAULT NULL,
  `ReceiptAmount` double DEFAULT NULL,
  `PaymentAmount` double DEFAULT NULL,
  `Remarks` varchar(500) DEFAULT NULL,
  `SalesId` int DEFAULT NULL,
  `PurchaseId` int DEFAULT NULL,
  `TransactionType` varchar(30) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `CreatedBy` int DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `DeletedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DeletedBy` int DEFAULT NULL,
  `DeletedRemarks` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`DeletedTransactionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `unlock_requests`
--

DROP TABLE IF EXISTS `unlock_requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unlock_requests` (
  `UnlockRequestId` int NOT NULL AUTO_INCREMENT,
  `SalesId` int DEFAULT NULL,
  `PurchaseId` int DEFAULT NULL,
  `Remarks` varchar(500) NOT NULL,
  `RequestedBy` int NOT NULL,
  `RequestedDate` datetime NOT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `IsApproved` tinyint NOT NULL DEFAULT '0',
  `IsRejected` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`UnlockRequestId`),
  KEY `fk_request_sales_id_idx` (`SalesId`),
  KEY `fk_request_purchase_id_idx` (`PurchaseId`),
  KEY `fk_request_requested_by_idx` (`RequestedBy`),
  KEY `fk_request_updated_by_idx` (`UpdatedBy`),
  CONSTRAINT `fk_request_purchase_id` FOREIGN KEY (`PurchaseId`) REFERENCES `purchase` (`PurchaseId`),
  CONSTRAINT `fk_request_requested_by` FOREIGN KEY (`RequestedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_request_sales_id` FOREIGN KEY (`SalesId`) REFERENCES `sales` (`SalesId`),
  CONSTRAINT `fk_request_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserRowId` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Address` varchar(500) DEFAULT NULL,
  `Mobile` varchar(10) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `UserSaltKey` varchar(100) DEFAULT NULL,
  `IsAdmin` int NOT NULL,
  `IsActive` int NOT NULL,
  `SecurityKey` varchar(45) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL,
  `UpdatedDate` datetime NOT NULL,
  `CreatedBy` int DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `BiometricAuthKey` varchar(600) DEFAULT NULL,
  PRIMARY KEY (`UserRowId`),
  UNIQUE KEY `UserId_UNIQUE` (`UserId`),
  UNIQUE KEY `Mobile_UNIQUE` (`Mobile`),
  UNIQUE KEY `SecurityKey_UNIQUE` (`SecurityKey`),
  KEY `fk_users_createdby_idx` (`CreatedBy`),
  KEY `fk_users_updated_by_idx` (`UpdatedBy`),
  CONSTRAINT `fk_users_created_by` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_users_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'paybill_api'
--

--
-- Dumping routines for database 'paybill_api'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-03 11:57:38
