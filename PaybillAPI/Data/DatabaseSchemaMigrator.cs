using Microsoft.EntityFrameworkCore;
using System.Data;

namespace PaybillAPI.Data
{
    public static class DatabaseSchemaMigrator
    {
        public static async Task EnsureSchemaUpToDateAsync(AppDBContext dbContext)
        {
            try
            {
                var conn = dbContext.Database.GetDbConnection();
                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }

                // 1. Ensure new tables exist
                await ExecuteSafeSqlAsync(dbContext, @"
                    CREATE TABLE IF NOT EXISTS `custom_receipt_lines` (
                      `CustomLineId` int NOT NULL AUTO_INCREMENT,
                      `CustomLineTitle` varchar(50) NOT NULL DEFAULT '',
                      `CustomLineDescription` varchar(100) NOT NULL DEFAULT '',
                      `IsActive` tinyint NOT NULL DEFAULT '1',
                      `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                      PRIMARY KEY (`CustomLineId`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;");

                await ExecuteSafeSqlAsync(dbContext, @"
                    CREATE TABLE IF NOT EXISTS `service_request_status` (
                      `ServiceRequestStatusId` int NOT NULL,
                      `ServiceRequestStatusName` varchar(30) NOT NULL,
                      `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                      PRIMARY KEY (`ServiceRequestStatusId`),
                      UNIQUE KEY `ServiceRequestStatusName_UNIQUE` (`ServiceRequestStatusName`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;");

                await ExecuteSafeSqlAsync(dbContext, @"
                    INSERT IGNORE INTO `service_request_status` (`ServiceRequestStatusId`, `ServiceRequestStatusName`) VALUES
                    (1, 'Pending'),
                    (2, 'InProgress'),
                    (3, 'Completed'),
                    (4, 'Cancelled'),
                    (5, 'Delivered');");

                await ExecuteSafeSqlAsync(dbContext, @"
                    CREATE TABLE IF NOT EXISTS `job_cards` (
                      `ServiceRequestId` int NOT NULL AUTO_INCREMENT,
                      `SalesId` int DEFAULT NULL,
                      `PartyId` int NOT NULL,
                      `ServiceRequestDate` date NOT NULL,
                      `ServiceRequestDescription` varchar(500) DEFAULT NULL,
                      `ServiceRequestStatusId` int NOT NULL DEFAULT '1',
                      `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                      `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                      `CreatedBy` int NOT NULL,
                      `UpdatedBy` int NOT NULL,
                      PRIMARY KEY (`ServiceRequestId`),
                      KEY `fk_job_cards_party_id_idx` (`PartyId`),
                      KEY `fk_job_cards_status_id_idx` (`ServiceRequestStatusId`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;");

                await ExecuteSafeSqlAsync(dbContext, @"
                    CREATE TABLE IF NOT EXISTS `job_card_items` (
                      `ServiceRequestComplaintId` int NOT NULL AUTO_INCREMENT,
                      `ServiceRequestId` int NOT NULL,
                      `ServiceTypeId` int NOT NULL,
                      `ServiceCharge` double NOT NULL DEFAULT '0',
                      `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                      PRIMARY KEY (`ServiceRequestComplaintId`),
                      KEY `fk_job_card_items_req_id_idx` (`ServiceRequestId`),
                      KEY `fk_job_card_items_stype_id_idx` (`ServiceTypeId`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;");

                await ExecuteSafeSqlAsync(dbContext, @"
                    CREATE TABLE IF NOT EXISTS `job_card_spares` (
                      `JobCardSpareId` int NOT NULL AUTO_INCREMENT,
                      `ServiceRequestId` int NOT NULL,
                      `ItemId` int NOT NULL,
                      `Quantity` double NOT NULL DEFAULT '1',
                      `Mrp` double NOT NULL DEFAULT '0',
                      `Rate` double NOT NULL DEFAULT '0',
                      `Amount` double NOT NULL DEFAULT '0',
                      `DiscountInRs` double NOT NULL DEFAULT '0',
                      `TaxableAmount` double NOT NULL DEFAULT '0',
                      `CgstPer` float NOT NULL DEFAULT '0',
                      `SgstPer` float NOT NULL DEFAULT '0',
                      `IgstPer` float NOT NULL DEFAULT '0',
                      `GstPer` float NOT NULL DEFAULT '0',
                      `CgstRs` double NOT NULL DEFAULT '0',
                      `SgstRs` double NOT NULL DEFAULT '0',
                      `IgstRs` double NOT NULL DEFAULT '0',
                      `GstAmount` double NOT NULL DEFAULT '0',
                      `TotalAmount` double NOT NULL DEFAULT '0',
                      `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                      PRIMARY KEY (`JobCardSpareId`),
                      KEY `fk_job_card_spares_req_id_idx` (`ServiceRequestId`),
                      KEY `fk_job_card_spares_item_id_idx` (`ItemId`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;");

                await ExecuteSafeSqlAsync(dbContext, @"
                    CREATE TABLE IF NOT EXISTS `reward_transactions` (
                      `RewardTransId` int NOT NULL AUTO_INCREMENT,
                      `PartyId` int NOT NULL,
                      `SalesId` int DEFAULT '0',
                      `TransactionType` varchar(20) NOT NULL,
                      `PointsCredited` double NOT NULL DEFAULT '0',
                      `PointsDebited` double NOT NULL DEFAULT '0',
                      `MonetaryValue` double NOT NULL DEFAULT '0',
                      `TransactionDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                      `Description` varchar(250) DEFAULT '',
                      `RefTransId` int DEFAULT '0',
                      `CreatedBy` int DEFAULT '0',
                      PRIMARY KEY (`RewardTransId`),
                      KEY `idx_reward_trans_party_id` (`PartyId`),
                      KEY `idx_reward_trans_sales_id` (`SalesId`),
                      KEY `idx_reward_trans_date` (`TransactionDate`)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;");

                // 2. Ensure missing columns in `message_templates`
                await AddColumnIfNotExistsAsync(dbContext, "message_templates", "MessageType", "varchar(50) NOT NULL DEFAULT 'Sales Invoice Message'");
                await AddColumnIfNotExistsAsync(dbContext, "message_templates", "IsSelected", "tinyint NOT NULL DEFAULT '0'");

                // 3. Ensure missing columns in `sales`
                await AddColumnIfNotExistsAsync(dbContext, "sales", "ServiceRequestId", "int DEFAULT '0'");
                await AddColumnIfNotExistsAsync(dbContext, "sales", "RewardPointsEarned", "double NOT NULL DEFAULT '0'");
                await AddColumnIfNotExistsAsync(dbContext, "sales", "RewardPointsRedeemed", "double NOT NULL DEFAULT '0'");
                await AddColumnIfNotExistsAsync(dbContext, "sales", "RewardDiscountAmount", "double NOT NULL DEFAULT '0'");

                // 4. Ensure missing columns in `settings`
                var settingsColumns = new (string Name, string Definition)[]
                {
                    ("LocalLanguageCode", "varchar(2) NOT NULL DEFAULT 'te'"),
                    ("IsPrintLocalLanguage", "tinyint NOT NULL DEFAULT '0'"),
                    ("IsOnlineStoreEnabled", "tinyint NOT NULL DEFAULT '0'"),
                    ("BankDetails", "varchar(250) DEFAULT NULL"),
                    ("IsShareInvoice3C", "tinyint NOT NULL DEFAULT '0'"),
                    ("IsSalesInvoiceDateEnabled", "tinyint NOT NULL DEFAULT '1'"),
                    ("IsAutoBackupWhatsAppEnabled", "tinyint NOT NULL DEFAULT '1'"),
                    ("IsAutoBackupEmailEnabled", "tinyint NOT NULL DEFAULT '0'"),
                    ("PaymentGatewayName", "varchar(50) NOT NULL DEFAULT 'None'"),
                    ("PaymentGatewayMerchantId", "varchar(150) NOT NULL DEFAULT ''"),
                    ("PaymentGatewayApiKey", "varchar(250) NOT NULL DEFAULT ''"),
                    ("PaymentGatewayApiSecret", "varchar(250) NOT NULL DEFAULT ''"),
                    ("MaxItemImageDimension", "int NOT NULL DEFAULT '512'"),
                    ("IsRewardsEnabled", "tinyint NOT NULL DEFAULT '0'"),
                    ("RewardEarningMethod", "varchar(30) NOT NULL DEFAULT 'FIXED_POINTS'"),
                    ("RewardEarningPurchaseAmount", "double NOT NULL DEFAULT '100'"),
                    ("RewardEarningPoints", "double NOT NULL DEFAULT '1'"),
                    ("RewardEarningPercentage", "double NOT NULL DEFAULT '2'"),
                    ("RewardPointValue", "double NOT NULL DEFAULT '1'"),
                    ("RewardMinPurchaseForEarning", "double NOT NULL DEFAULT '100'"),
                    ("RewardMinPointsForRedemption", "double NOT NULL DEFAULT '0'"),
                    ("RewardMinInvoiceForRedemption", "double NOT NULL DEFAULT '0'"),
                    ("RewardMaxRedemptionPercentage", "double NOT NULL DEFAULT '20'"),
                    ("RewardAllowPartialRedemption", "tinyint NOT NULL DEFAULT '1'"),
                    ("RewardAllowSameInvoiceRedemption", "tinyint NOT NULL DEFAULT '0'"),
                    ("RewardIsExpiryEnabled", "tinyint NOT NULL DEFAULT '0'"),
                    ("RewardExpiryDays", "int NOT NULL DEFAULT '365'"),
                    ("RewardEligibleAmountType", "varchar(30) NOT NULL DEFAULT 'TOTAL_WITH_TAX'"),
                    ("RewardStartDate", "varchar(20) NOT NULL DEFAULT ''"),
                    ("RewardEndDate", "varchar(20) NOT NULL DEFAULT ''")
                };

                foreach (var col in settingsColumns)
                {
                    await AddColumnIfNotExistsAsync(dbContext, "settings", col.Name, col.Definition);
                }

                // 5. Ensure `sales_items_deleted` has `ServiceTypeId` and nullable `ItemId`
                await AddColumnIfNotExistsAsync(dbContext, "sales_items_deleted", "ServiceTypeId", "int DEFAULT NULL");
                await ExecuteSafeSqlAsync(dbContext, "ALTER TABLE `sales_items_deleted` MODIFY COLUMN `ItemId` int DEFAULT NULL;");
            }
            catch
            {
                // Ignore schema migration errors if database has not been initialized yet
            }
        }

        private static async Task AddColumnIfNotExistsAsync(AppDBContext dbContext, string tableName, string columnName, string columnDefinition)
        {
            try
            {
                var conn = dbContext.Database.GetDbConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_SCHEMA = DATABASE()
                      AND TABLE_NAME = @tableName
                      AND COLUMN_NAME = @columnName;";

                var pTable = cmd.CreateParameter();
                pTable.ParameterName = "@tableName";
                pTable.Value = tableName;
                cmd.Parameters.Add(pTable);

                var pCol = cmd.CreateParameter();
                pCol.ParameterName = "@columnName";
                pCol.Value = columnName;
                cmd.Parameters.Add(pCol);

                var existsObj = await cmd.ExecuteScalarAsync();
                long count = existsObj != null ? Convert.ToInt64(existsObj) : 0;
                if (count == 0)
                {
                    await ExecuteSafeSqlAsync(dbContext, $"ALTER TABLE `{tableName}` ADD COLUMN `{columnName}` {columnDefinition};");
                }
            }
            catch
            {
                // Ignore if table doesn't exist yet
            }
        }

        private static async Task ExecuteSafeSqlAsync(AppDBContext dbContext, string sql)
        {
            try
            {
                await dbContext.Database.ExecuteSqlRawAsync(sql);
            }
            catch
            {
                // Ignore individual DDL errors so remaining migrations proceed
            }
        }
    }
}

