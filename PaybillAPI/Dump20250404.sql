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
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Food_2','2024-10-29 09:41:37','2025-01-29 07:31:01',2,2),(3,'Veg','2024-11-22 04:25:44','2024-11-22 04:25:44',5,5);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

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
  `MaxBackups` tinyint NOT NULL DEFAULT '0',
  `CountryId` int DEFAULT '28',
  `CountryLocaleCode` varchar(5) DEFAULT 'in',
  `CountryMobileLength` tinyint NOT NULL DEFAULT '10',
  `CountryName` varchar(50) NOT NULL DEFAULT 'India',
  `CountryCurrencyCode` varchar(10) NOT NULL DEFAULT 'Rs',
  `CountryCurrencySymbol` varchar(5) NOT NULL DEFAULT '₹',
  PRIMARY KEY (`ClientUniqueId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES ('REhPRmFpNlVJaFFoeW80N3Iyb3Vudz09','101059344665149510','Online Service','Online Service','9494855767','nellore','','Trail',1000,'2026-01-28',0,0,'dd792089c3c047fc873bd583b2875abe','0001-01-01 00:00:00',0,28,'in',10,'India','INR','₹'),('WERCM1I4WXpKNGFoSytkY0V6WE8rZz09','101059344665149454','Supermarket','Ramya General Stores','9494855767','Nellore','','Free',0,'2025-11-28',0,0,'cfedccd6c00f4b819c97a966354ee736','0001-01-01 00:00:00',0,NULL,NULL,10,'India','Rs','₹');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `gst`
--

LOCK TABLES `gst` WRITE;
/*!40000 ALTER TABLE `gst` DISABLE KEYS */;
INSERT INTO `gst` VALUES (1,5.5,5.5,11,1,'2024-10-29 13:30:29','2024-10-29 13:30:52',2,2),(2,6,6,12,1,'2024-10-29 13:30:33','2024-10-29 13:30:33',2,2),(4,10,10,20,1,'2024-10-29 13:30:40','2024-10-29 13:30:40',2,2);
/*!40000 ALTER TABLE `gst` ENABLE KEYS */;
UNLOCK TABLES;

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
  `ItemLocalName` varchar(100) NOT NULL,
  `AliasName` varchar(250) DEFAULT NULL,
  `Mrp` float NOT NULL,
  `SalesPrice` float NOT NULL,
  `PurchasePrice` float NOT NULL,
  `HSNCode` varchar(20) DEFAULT NULL,
  `Measure` varchar(20) NOT NULL,
  `OpeningStock` double NOT NULL,
  `ClosingStock` double NOT NULL,
  `MinimumStock` double NOT NULL,
  `Shelf` varchar(20) DEFAULT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items`
--

LOCK TABLES `items` WRITE;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` VALUES (9,1,2,'sadfdsa','sdfsd','','',25,25,25,'125452','Piece',100,1488,0,NULL,1,'2024-10-29 18:54:05','2024-11-01 06:27:43',2,2),(10,1,2,'3324','dsffsdf','','',44,44,20,'365241','Piece',255,128,0,NULL,1,'2024-10-30 14:08:22','2024-11-04 06:53:20',2,2),(11,1,1,'101','5 Star','','',30,25,15,'236852','Piece',101,1918,0,NULL,1,'2024-11-01 06:49:41','2024-11-01 06:49:41',2,2),(12,1,1,'101','5 Star','','',45,35,25,'','Piece',100,242,0,NULL,1,'2024-11-01 06:49:59','2024-12-03 11:50:44',2,5),(16,1,NULL,'101','5 Star','','',65,55,45,'','Piece',100,27,0,NULL,1,'2024-12-11 13:00:53','2024-12-11 13:00:53',2,2);
/*!40000 ALTER TABLE `items` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `message_templates`
--

LOCK TABLES `message_templates` WRITE;
/*!40000 ALTER TABLE `message_templates` DISABLE KEYS */;
INSERT INTO `message_templates` VALUES (3,'Dear <PARTY>, your vehicle <REMARKS> is ready for deliver. Spares and Serviec amount is <AMOUNT>. Regards <COMPANY>'),(4,'Dear <PARTY>, your invoice amount is <AMOUNT>. Regards <COMPANY>');
/*!40000 ALTER TABLE `message_templates` ENABLE KEYS */;
UNLOCK TABLES;

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
  `PartyShippingAddress` varchar(500) DEFAULT NULL,
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
-- Dumping data for table `parties`
--

LOCK TABLES `parties` WRITE;
/*!40000 ALTER TABLE `parties` DISABLE KEYS */;
INSERT INTO `parties` VALUES (1,'sdfgdsf','dfsgds',NULL,'345345354','','','',1,1,'2024-10-30 05:12:19','2024-10-30 05:12:19',2,2),(2,'SRS TRADERS','Nellore','Nellore','9494855767','','','',1,1,'2024-10-30 05:12:41','2024-12-10 19:58:08',2,2),(6,'xcvzzxvzxc','vzxvxz',NULL,'','','','',0,1,'2024-10-30 06:02:33','2024-10-30 06:02:33',2,2),(7,'xzcvzxvzxcvzx','xczvxzvxzcvxcz',NULL,'','','','',0,1,'2024-10-30 06:02:36','2024-11-08 14:31:23',2,2),(8,'Ravi','Nellore',NULL,'9959963575','','35DFGSFDSG','',0,1,'2024-11-04 19:14:16','2024-11-27 17:29:25',2,5);
/*!40000 ALTER TABLE `parties` ENABLE KEYS */;
UNLOCK TABLES;

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
  `PurchaseOrderId` int DEFAULT NULL,
  PRIMARY KEY (`PurchaseId`),
  KEY `fk_purchase_created_by_idx` (`CreatedBy`),
  KEY `fk_purchase_updated_by_idx` (`UpdatedBy`),
  KEY `fk_purchase_partry_id_idx` (`PartyId`),
  KEY `fk_purchase_order_id_idx` (`PurchaseOrderId`),
  CONSTRAINT `fk_purchase_created_by` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_purchase_order_id` FOREIGN KEY (`PurchaseOrderId`) REFERENCES `purchase_orders` (`PurchaseOrderId`),
  CONSTRAINT `fk_purchase_partry_id` FOREIGN KEY (`PartyId`) REFERENCES `parties` (`PartyId`),
  CONSTRAINT `fk_purchase_updated_by` FOREIGN KEY (`UpdatedBy`) REFERENCES `users` (`UserRowId`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase`
--

LOCK TABLES `purchase` WRITE;
/*!40000 ALTER TABLE `purchase` DISABLE KEYS */;
INSERT INTO `purchase` VALUES (3,1,'34324','2024-10-30','Cash','Cash','',NULL,1,'2024-10-30 18:16:20','2024-10-30 18:16:19',2,2,NULL),(4,1,'5454','2024-10-30','Cash','Cash','',NULL,1,'2024-10-30 18:20:23','2024-10-30 18:20:23',2,2,NULL),(7,2,'101','2024-10-31','Cash','Cash','',NULL,1,'2024-10-31 18:45:02','2024-10-31 18:45:02',2,2,NULL),(8,2,'123','2024-10-31','Cash','Cash','',NULL,1,'2024-10-31 19:04:38','2024-10-31 19:04:38',2,2,NULL),(9,1,'232','2024-11-01','Cash','Cash','',NULL,1,'2024-11-01 07:44:00','2024-11-01 07:44:00',2,2,NULL),(10,2,'343','2024-11-02','Credit','Cash','',NULL,1,'2024-11-02 12:28:13','2024-11-02 12:28:13',2,2,NULL),(11,1,'35241','2024-11-02','Cash','Cash','',NULL,1,'2024-11-02 13:38:47','2024-11-02 13:38:47',2,2,NULL),(12,2,'dxv','2024-11-21','Cash','Cash','','',1,'2024-11-21 19:38:03','2024-11-21 20:00:45',5,5,NULL),(13,2,'TGFF465','2024-11-22','Cash','Cash','','',0,'2024-11-22 04:02:13','2024-11-22 04:02:13',5,5,NULL),(14,2,'GFGHH','2024-11-22','Cash','Cash','','',1,'2024-11-22 04:03:30','2024-11-22 04:03:30',5,5,NULL),(15,2,'TXCC','2024-12-10','Cash','Cash','','',1,'2024-12-10 20:59:16','2024-12-10 20:59:16',2,2,NULL),(16,2,'HZNND','2024-12-10','Cash','Cash','','',1,'2024-12-10 21:02:19','2024-12-10 21:02:19',2,2,1),(17,2,'UZNNX','2024-12-10','Cash','Cash','','',1,'2024-12-10 21:02:56','2024-12-10 21:02:56',2,2,NULL),(18,2,'YBVVV','2025-01-29','Cash','Cash','','',0,'2025-01-29 09:45:50','2025-01-29 09:45:50',2,2,7),(19,2,'YVG','2025-01-29','Cash','Cash','','',1,'2025-01-29 09:48:58','2025-01-29 09:48:58',2,2,NULL),(20,2,'TVXG','2025-01-29','Cash','Cash','','',1,'2025-01-29 10:13:44','2025-01-29 10:13:44',2,2,8),(21,2,'FVC','2025-01-29','Cash','Cash','','',1,'2025-01-29 10:16:44','2025-01-29 10:16:44',2,2,NULL),(22,2,'VZGH','2025-01-29','Cash','Cash','','',1,'2025-01-29 10:22:08','2025-01-29 10:22:08',2,2,NULL);
/*!40000 ALTER TABLE `purchase` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_items`
--

LOCK TABLES `purchase_items` WRITE;
/*!40000 ALTER TABLE `purchase_items` DISABLE KEYS */;
INSERT INTO `purchase_items` VALUES (20,9,12,10,25,250,0,250,5.5,5.5,0,11,13.75,13.75,0,27.5,277.5,'2024-11-01 07:44:00',NULL,NULL),(21,10,10,100,44,4400,0,4400,0,0,12,12,0,0,528,528,4928,'2024-11-02 12:28:13',NULL,NULL),(22,10,9,250,25,6250,0,6250,6,6,0,12,375,375,0,750,7000,'2024-11-02 12:28:13',NULL,NULL),(23,11,10,25,44,1100,0,1100,6,6,0,12,66,66,0,132,1232,'2024-11-02 13:38:47',NULL,NULL),(24,12,11,500,15,7500,0,7500,5.5,5.5,0,11,412.5,412.5,0,825,8325,'2024-11-21 19:38:04',NULL,NULL),(25,12,9,400,25,10000,0,10000,6,6,0,12,600,600,0,1200,11200,'2024-11-21 19:38:04',NULL,NULL),(26,12,11,500,15,7500,0,7500,0,0,0,11,0,0,0,825,8325,'2024-11-21 20:00:45',NULL,NULL),(27,12,9,400,25,10000,0,10000,0,0,0,12,0,0,0,1200,11200,'2024-11-21 20:00:45',NULL,NULL),(28,12,11,500,15,7500,0,7500,0,0,0,11,0,0,0,825,8325,'2024-11-21 20:00:46',NULL,NULL),(29,12,9,400,25,10000,0,10000,0,0,0,12,0,0,0,1200,11200,'2024-11-21 20:00:46',NULL,NULL),(30,13,12,200,25,5000,0,5000,5.5,5.5,0,11,275,275,0,550,5550,'2024-11-22 04:02:13',NULL,NULL),(32,14,10,20,20,400,0,400,6,6,0,12,24,24,0,48,448,'2024-11-22 04:03:30',NULL,NULL),(33,15,11,100,15,1500,0,1500,5.5,5.5,0,0,8250,8250,0,16500,18000,'2024-12-10 20:59:17',NULL,NULL),(34,15,11,100,15,1500,0,1500,5.5,5.5,0,0,8250,8250,0,16500,18000,'2024-12-10 20:59:17',NULL,NULL),(35,16,11,100,15,1500,0,1500,5.5,5.5,0,0,8250,8250,0,16500,18000,'2024-12-10 21:02:19',NULL,NULL),(36,16,11,100,15,1500,0,1500,5.5,5.5,0,0,8250,8250,0,16500,18000,'2024-12-10 21:02:20',NULL,NULL),(37,17,12,25,25,625,0,625,5.5,5.5,0,11,34.375,34.375,0,68.75,693.75,'2024-12-10 21:02:56',NULL,NULL),(38,17,11,24,15,360,0,360,5.5,5.5,0,11,19.8,19.8,0,39.6,399.6,'2024-12-10 21:02:56',NULL,NULL),(39,18,11,10,15,150,0,150,5.5,5.5,0,0,825,825,0,1650,1800,'2025-01-29 09:45:50',NULL,NULL),(40,18,12,11,25,275,0,275,5.5,5.5,0,0,1512.5,1512.5,0,3025,3300,'2025-01-29 09:45:50',NULL,NULL),(41,19,12,10,25,250,0,250,5.5,5.5,0,11,13.75,13.75,0,27.5,277.5,'2025-01-29 09:48:58',NULL,NULL),(42,19,9,2,25,50,0,50,6,6,0,12,3,3,0,6,56,'2025-01-29 09:48:58',NULL,NULL),(43,20,16,10,45,450,0,450,0,0,0,0,0,0,0,0,450,'2025-01-29 10:13:44',NULL,NULL),(44,20,11,10,15,150,0,150,5.5,5.5,0,11,4.125,4.125,0,16.5,166.5,'2025-01-29 10:13:44',NULL,NULL),(45,21,12,25,25,625,0,625,5.5,5.5,0,11,34.375,34.375,0,68.75,693.75,'2025-01-29 10:16:44',NULL,NULL),(46,21,9,25,25,625,0,625,6,6,0,12,37.5,37.5,0,75,700,'2025-01-29 10:16:44',NULL,NULL),(47,22,16,17,45,765,0,765,0,0,0,0,0,0,0,0,765,'2025-01-29 10:22:08',NULL,NULL),(48,22,9,25,25,625,0,625,6,6,0,12,37.5,37.5,0,75,700,'2025-01-29 10:22:08',NULL,NULL);
/*!40000 ALTER TABLE `purchase_items` ENABLE KEYS */;
UNLOCK TABLES;
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
-- Dumping data for table `purchase_items_deleted`
--

LOCK TABLES `purchase_items_deleted` WRITE;
/*!40000 ALTER TABLE `purchase_items_deleted` DISABLE KEYS */;
INSERT INTO `purchase_items_deleted` VALUES (17,13,10,580,20,11600,0,11600,6,6,0,12,696,696,0,1392,12992,'2024-11-22 04:02:13','2024-11-22 04:56:33',5,'cccv gggg');
/*!40000 ALTER TABLE `purchase_items_deleted` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_order_items`
--

DROP TABLE IF EXISTS `purchase_order_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchase_order_items` (
  `PurchaseOrderItemId` int NOT NULL AUTO_INCREMENT,
  `PurchaseOrderId` int NOT NULL,
  `ItemId` int NOT NULL,
  `quantity` float NOT NULL,
  `rate` float NOT NULL,
  `amount` double NOT NULL,
  PRIMARY KEY (`PurchaseOrderItemId`),
  KEY `fk_purchase_order_items_order_id_idx` (`PurchaseOrderId`),
  KEY `fk_purchase_order_items_item_id_idx` (`ItemId`),
  CONSTRAINT `fk_purchase_order_items_item_id` FOREIGN KEY (`ItemId`) REFERENCES `items` (`ItemId`),
  CONSTRAINT `fk_purchase_order_items_order_id` FOREIGN KEY (`PurchaseOrderId`) REFERENCES `purchase_orders` (`PurchaseOrderId`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order_items`
--

LOCK TABLES `purchase_order_items` WRITE;
/*!40000 ALTER TABLE `purchase_order_items` DISABLE KEYS */;
INSERT INTO `purchase_order_items` VALUES (11,7,11,10,15,150),(12,7,12,11,25,275),(13,8,16,10,45,450),(14,8,11,5,15,75);
/*!40000 ALTER TABLE `purchase_order_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_orders`
--

DROP TABLE IF EXISTS `purchase_orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchase_orders` (
  `PurchaseOrderId` int NOT NULL AUTO_INCREMENT,
  `OrderDate` date NOT NULL,
  `PartyId` int NOT NULL,
  `Remarks` varchar(500) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL,
  `CreatedBy` int NOT NULL,
  PRIMARY KEY (`PurchaseOrderId`),
  KEY `fk_purchase_order_vendor_id_idx` (`PartyId`),
  KEY `fk_purchase_order_created_by_idx` (`CreatedBy`),
  CONSTRAINT `fk_purchase_order_created_by` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserRowId`),
  CONSTRAINT `fk_purchase_order_vendor_id` FOREIGN KEY (`PartyId`) REFERENCES `parties` (`PartyId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_orders`
--

LOCK TABLES `purchase_orders` WRITE;
/*!40000 ALTER TABLE `purchase_orders` DISABLE KEYS */;
INSERT INTO `purchase_orders` VALUES (1,'2024-12-10',2,'','2024-12-10 18:35:16',2),(5,'2025-01-29',2,'','2025-01-29 07:52:37',2),(6,'2025-01-29',1,'','2025-01-29 07:55:15',2),(7,'2025-01-29',2,'','2025-01-29 08:14:39',2),(8,'2025-01-29',2,'','2025-01-29 09:49:19',2);
/*!40000 ALTER TABLE `purchase_orders` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales`
--

LOCK TABLES `sales` WRITE;
/*!40000 ALTER TABLE `sales` DISABLE KEYS */;
INSERT INTO `sales` VALUES (5,2,'INVF24-5','2024-11-01','Cash','Cash','',0,7264.28,1,'',2,'2024-11-01 17:50:46',5,'2024-11-26 07:26:09',NULL),(7,NULL,'INVF24-000007','2024-11-01','Cash','Cash','',0,0,0,'',2,'2024-11-01 17:57:28',NULL,'2024-11-26 06:48:38',NULL),(8,NULL,'INVF24-00008','2024-11-02','Cash','Cash','',0,0,1,'',2,'2024-11-02 13:49:48',NULL,'2024-11-26 06:48:38',NULL),(9,NULL,'INVF24-00009','2024-11-04','Cash','Cash','',0,0,1,'',2,'2024-11-04 06:53:49',NULL,'2024-11-26 06:48:38',NULL),(10,NULL,'INVF24-00010','2024-11-04','Cash','Cash','',0,0,0,'',2,'2024-11-04 17:57:26',NULL,'2024-11-26 06:48:38',NULL),(11,2,'INVF24-00011','2024-11-04','Cash','Cash','',0,0,1,'',2,'2024-11-04 19:13:01',NULL,'2024-11-26 06:48:38',NULL),(12,8,'INVF24-00012','2024-11-04','Cash','Cash','',0,0,1,'',2,'2024-11-04 19:14:43',NULL,'2024-11-26 06:48:38',NULL),(13,8,'INVF24-00013','2024-11-05','Cash','Cash','',0,0,1,'',2,'2024-11-05 15:08:41',NULL,'2024-11-26 06:48:38',NULL),(14,8,'INVF24-00014','2024-11-08','Cash','Cash','',0,0,0,'',2,'2024-11-08 09:53:19',NULL,'2024-11-26 06:48:38',NULL),(15,8,'INVF24-00015','2024-11-08','Credit','','',0,0,1,'',2,'2024-11-08 09:53:50',NULL,'2024-11-26 06:48:38',NULL),(16,NULL,'INVF24-00016','2024-11-12','Cash','Cash','',0,0,1,'',2,'2024-11-12 13:36:00',NULL,'2024-11-26 06:48:38',NULL),(17,NULL,'INVF24-00017','2024-11-12','Cash','Cash','',0,0,1,'',2,'2024-11-12 13:42:55',NULL,'2024-11-26 06:48:38',NULL),(18,NULL,'INVF24-00018','2024-11-12','Cash','Cash','',0,0,1,'',2,'2024-11-12 13:45:10',NULL,'2024-11-26 06:48:38',NULL),(19,NULL,'INVF24-00019','2024-11-12','Cash','Cash','',0,0,1,'',2,'2024-11-12 13:50:06',NULL,'2024-11-26 06:48:38',NULL),(20,NULL,'INVF24-00020','2024-11-12','Cash','Cash','',0,0,1,'',2,'2024-11-12 14:19:11',NULL,'2024-11-26 06:48:38',NULL),(21,8,'INVF24-00021','2024-11-12','Cash','Cash','',0,0,1,'',2,'2024-11-12 19:05:12',NULL,'2024-11-26 06:48:38',NULL),(22,8,'INVF24-00022','2024-11-12','Cash','Cash','',0,0,1,'',2,'2024-11-12 19:06:37',NULL,'2024-11-26 06:48:38',NULL),(23,8,'INVF24-00023','2024-11-12','Cash','Cash','',0,0,1,'',2,'2024-11-12 19:07:57',NULL,'2024-11-26 06:48:38',NULL),(24,8,'INVF24-00024','2024-11-12','Cash','Cash','',0,0,1,'',2,'2024-11-12 19:08:27',NULL,'2024-11-26 06:48:38',NULL),(25,NULL,'INVF24-00025','2024-11-13','Cash','Cash','',0,0,1,'',2,'2024-11-13 05:35:58',NULL,'2024-11-26 06:48:38',NULL),(26,NULL,'INVF24-00026','2024-11-13','Cash','Cash','',0,0,1,'',2,'2024-11-13 05:41:09',NULL,'2024-11-26 06:48:38',NULL),(27,NULL,'INVF24-00027','2024-11-16','Cash','Cash','',500,-356.12,1,'',2,'2024-11-16 12:02:01',NULL,'2024-11-26 06:48:38',NULL),(30,NULL,'INVF24-00028','2024-11-21','Cash','Cash','',0,6754.6,0,'',5,'2024-11-21 18:53:52',NULL,'2024-11-26 06:48:38',NULL),(31,8,'INVF24-00031','2024-11-21','Cash','Cash','',0,1665,1,'',5,'2024-11-21 18:54:27',NULL,'2024-11-26 06:48:38',NULL),(32,8,'INVF24-00032','2024-11-21','Cash','Cash','',200,-83.87,1,'',5,'2024-11-21 18:54:51',NULL,'2024-11-26 06:48:38',NULL),(33,NULL,'INVF24-00033','2024-11-21','Cash','Cash','',0,7281.6,1,'',5,'2024-11-21 21:51:01',NULL,'2024-11-26 06:48:38',NULL),(34,NULL,'INVF24-00034','2024-11-22','Cash','Cash','',0,6688,1,'',5,'2024-11-22 04:04:37',5,'2024-12-03 11:51:04',''),(35,NULL,'INVF24-00035','2024-11-22','Cash','Cash','',0,66.85,1,'',5,'2024-11-22 06:50:37',NULL,'2024-11-26 06:48:38',NULL),(36,NULL,'INVF24-00036','2024-11-26','Cash','Cash','',2000,-268.4000000000001,0,'',5,'2024-11-26 07:30:01',5,'2024-11-26 07:30:01',NULL),(37,NULL,'INVF24-00037','2024-11-26','Cash','Cash','',0,38.85,1,'',5,'2024-11-26 10:49:39',5,'2024-11-26 10:49:39',NULL),(38,NULL,'INVF24-00038','2024-11-26','Cash','Cash','',0,38.85,1,'',5,'2024-11-26 10:50:02',5,'2024-11-26 10:50:02',NULL),(39,8,'INVF24-00039','2024-11-26','Cash','Cash','',0,1753.13,1,'',5,'2024-11-26 18:45:58',5,'2024-11-26 18:45:58',NULL),(40,NULL,'INVF24-00040','2024-11-26','Cash','Cash','',0,77.03,1,'',5,'2024-11-26 20:22:28',5,'2024-11-26 20:22:28','9959963575'),(41,NULL,'INVF24-00041','2024-11-26','Cash','Cash','',0,38.85,1,'',5,'2024-11-26 20:23:25',5,'2024-11-26 20:23:25','9959963575'),(42,NULL,'INVF24-00042','2024-11-26','Cash','Cash','',0,38.85,1,'',5,'2024-11-26 20:24:34',5,'2024-11-26 20:24:34','9959963575'),(43,NULL,'INVF24-00043','2024-11-26','Cash','Cash','',659,-620.15,1,'',5,'2024-11-26 20:49:45',5,'2024-11-26 20:49:45','9959963575'),(44,NULL,'INVF24-00044','2024-11-26','Cash','Cash','',0,38.85,1,'',5,'2024-11-26 20:50:14',5,'2024-11-26 20:50:14','9959963575'),(45,NULL,'INVF24-00045','2024-11-27','Cash','Cash','',0,66.85,1,'',5,'2024-11-27 07:47:23',5,'2024-11-27 07:47:23','9959963575'),(46,8,'INVF24-00046','2024-11-27','Cash','Cash','',0,27.75,1,'',5,'2024-11-27 07:54:17',5,'2024-11-27 07:54:17',''),(47,8,'INVF24-00047','2024-11-27','Cash','Cash','',0,7303.13,1,'',5,'2024-11-27 08:01:20',5,'2024-11-27 08:01:20',''),(48,8,'INVF24-00048','2024-11-27','Cash','Cash','',0,1148.85,1,'',5,'2024-11-27 08:02:39',5,'2024-11-27 08:02:39',''),(49,8,'INVF24-00049','2024-11-27','Cash','Cash','',0,5588.85,1,'',5,'2024-11-27 15:13:25',5,'2024-11-27 15:13:25',''),(50,NULL,'INVF24-00050','2024-11-28','Cash','Cash','',0,38.85,1,'',5,'2024-11-28 06:21:34',5,'2024-11-28 06:21:34',''),(51,NULL,'INVF24-00051','2024-11-28','Cash','Cash','',0,38.85,1,'',5,'2024-11-28 06:26:03',5,'2024-11-28 06:26:03',''),(52,NULL,'INVF24-00052','2024-11-28','Cash','Cash','',0,38.85,1,'',5,'2024-11-28 06:27:20',5,'2024-11-28 06:27:20',''),(53,NULL,'INVF24-00053','2024-11-28','Cash','Cash','',0,38.85,1,'',5,'2024-11-28 06:27:58',5,'2024-11-28 06:27:58',''),(54,NULL,'INVF24-00054','2024-11-28','Cash','Cash','',0,38.85,1,'',5,'2024-11-28 06:28:07',5,'2024-11-28 06:28:07',''),(55,NULL,'INVF24-00055','2024-11-28','Cash','Cash','',0,38.85,1,'',5,'2024-11-28 06:32:55',5,'2024-11-28 06:32:55',''),(56,NULL,'INVF24-00056','2024-12-03','Cash','Cash','',7000,-828.3999999999996,1,'',5,'2024-12-03 11:51:59',5,'2024-12-03 11:51:59',''),(57,NULL,'INVF24-00057','2024-12-11','Cash','Cash','',0,88.13,1,'',2,'2024-12-11 13:01:24',2,'2024-12-11 13:01:24',''),(58,NULL,'INVF24-00058','2025-01-29','Cash','Cash','',0,105.7,1,'',2,'2025-01-29 07:35:42',2,'2025-01-29 07:35:42',''),(59,NULL,'INVF24-00059','2025-01-29','Cash','Cash','',0,88.13,1,'',2,'2025-01-29 10:26:09',2,'2025-01-29 10:26:09','');
/*!40000 ALTER TABLE `sales` ENABLE KEYS */;
UNLOCK TABLES;
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
) ENGINE=InnoDB AUTO_INCREMENT=120 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_items`
--

LOCK TABLES `sales_items` WRITE;
/*!40000 ALTER TABLE `sales_items` DISABLE KEYS */;
INSERT INTO `sales_items` VALUES (5,5,10,NULL,1,44,0,44,0,44,0,0,0,12,0,0,0,5.28,49.28,0,'2024-11-01 17:50:46',2,'sdfdsafasf',5,'2024-11-26 07:26:42'),(8,7,9,NULL,1,25,0,25,0,25,0,0,0,12,0,0,0,3,28,0,'2024-11-01 17:57:28',NULL,NULL,NULL,'2024-11-26 06:52:34'),(9,8,10,NULL,1,44,0,44,0,44,0,0,0,12,0,0,0,5.28,49.28,0,'2024-11-02 13:49:48',NULL,NULL,NULL,'2024-11-26 06:52:34'),(10,8,9,NULL,1,25,0,25,0,25,0,0,0,12,0,0,0,3,28,0,'2024-11-02 13:49:48',NULL,NULL,NULL,'2024-11-26 06:52:34'),(11,9,11,NULL,1,25,100,25,0,25,0,0,0,11,0,0,0,2.75,27.75,15,'2024-11-04 06:53:49',NULL,NULL,NULL,'2024-11-26 06:52:34'),(12,9,10,NULL,1,44,100,44,0,44,0,0,0,12,0,0,0,5.28,49.28,20,'2024-11-04 06:53:49',NULL,NULL,NULL,'2024-11-26 06:52:34'),(13,10,11,NULL,10,25,100,250,0,250,5.5,5.5,0,11,13.75,13.75,0,27.5,277.5,15,'2024-11-04 17:57:26',NULL,NULL,NULL,'2024-11-26 06:52:34'),(14,11,11,NULL,1,25,100,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-04 19:13:02',NULL,NULL,NULL,'2024-11-26 06:52:34'),(15,12,12,NULL,1,35,100,35,0,35,0,0,11,11,0,0,3.85,3.85,38.85,25,'2024-11-04 19:14:43',NULL,NULL,NULL,'2024-11-26 06:52:34'),(16,12,11,NULL,1,25,100,25,0,25,0,0,11,11,0,0,2.75,2.75,27.75,15,'2024-11-04 19:14:43',NULL,NULL,NULL,'2024-11-26 06:52:34'),(17,13,11,NULL,1,25,100,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-05 15:08:41',NULL,NULL,NULL,'2024-11-26 06:52:34'),(18,13,12,NULL,1,35,100,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-05 15:08:41',NULL,NULL,NULL,'2024-11-26 06:52:34'),(19,13,10,NULL,1,44,100,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-05 15:08:41',NULL,NULL,NULL,'2024-11-26 06:52:34'),(21,14,10,NULL,1,44,100,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-08 09:53:19',NULL,NULL,NULL,'2024-11-26 06:52:34'),(22,14,9,NULL,1,25,100,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2024-11-08 09:53:19',NULL,NULL,NULL,'2024-11-26 06:52:34'),(23,15,12,NULL,1,35,100,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-08 09:53:50',NULL,NULL,NULL,'2024-11-26 06:52:34'),(24,15,10,NULL,1,44,100,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-08 09:53:50',NULL,NULL,NULL,'2024-11-26 06:52:34'),(25,16,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-12 13:36:00',NULL,NULL,NULL,'2024-11-26 06:52:34'),(26,16,9,NULL,1,25,25,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2024-11-12 13:36:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(27,17,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-12 13:42:55',NULL,NULL,NULL,'2024-11-26 06:52:34'),(28,17,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-12 13:42:55',NULL,NULL,NULL,'2024-11-26 06:52:34'),(29,17,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-12 13:42:55',NULL,NULL,NULL,'2024-11-26 06:52:34'),(30,18,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-12 13:45:10',NULL,NULL,NULL,'2024-11-26 06:52:34'),(31,19,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-12 13:50:06',NULL,NULL,NULL,'2024-11-26 06:52:34'),(32,19,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-12 13:50:06',NULL,NULL,NULL,'2024-11-26 06:52:34'),(33,20,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-12 14:19:11',NULL,NULL,NULL,'2024-11-26 06:52:34'),(34,21,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-12 19:05:13',NULL,NULL,NULL,'2024-11-26 06:52:34'),(35,21,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-12 19:05:13',NULL,NULL,NULL,'2024-11-26 06:52:34'),(36,21,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-12 19:05:13',NULL,NULL,NULL,'2024-11-26 06:52:34'),(37,21,9,NULL,1,25,25,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2024-11-12 19:05:13',NULL,NULL,NULL,'2024-11-26 06:52:34'),(38,22,12,NULL,1,35,45,35,0,35,0,0,11,11,0,0,3.85,3.85,38.85,25,'2024-11-12 19:06:37',NULL,NULL,NULL,'2024-11-26 06:52:34'),(39,23,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-12 19:07:57',NULL,NULL,NULL,'2024-11-26 06:52:34'),(40,24,11,NULL,1,25,30,25,0,25,0,0,11,11,0,0,2.75,2.75,27.75,15,'2024-11-12 19:08:27',NULL,NULL,NULL,'2024-11-26 06:52:34'),(41,24,12,NULL,1,35,45,35,0,35,0,0,11,11,0,0,3.85,3.85,38.85,25,'2024-11-12 19:08:27',NULL,NULL,NULL,'2024-11-26 06:52:34'),(42,24,10,NULL,1,44,44,44,0,44,0,0,12,12,0,0,5.28,5.28,49.28,20,'2024-11-12 19:08:27',NULL,NULL,NULL,'2024-11-26 06:52:34'),(43,24,9,NULL,1,25,25,25,0,25,0,0,12,12,0,0,3,3,28,25,'2024-11-12 19:08:27',NULL,NULL,NULL,'2024-11-26 06:52:34'),(44,25,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-13 05:35:58',NULL,NULL,NULL,'2024-11-26 06:52:34'),(45,25,9,NULL,1,25,25,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2024-11-13 05:35:58',NULL,NULL,NULL,'2024-11-26 06:52:34'),(46,26,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-13 05:41:09',NULL,NULL,NULL,'2024-11-26 06:52:34'),(47,27,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-16 12:02:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(48,27,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-16 12:02:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(49,27,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-16 12:02:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(50,27,9,NULL,1,25,25,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2024-11-16 12:02:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(52,30,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-21 18:53:53',NULL,NULL,NULL,'2024-11-26 06:52:34'),(53,30,9,NULL,1,25,25,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2024-11-21 18:53:53',NULL,NULL,NULL,'2024-11-26 06:52:34'),(54,30,NULL,2,1,5000,5000,5000,0,5000,5.5,5.5,0,11,275,275,0,550,5550,0,'2024-11-21 18:53:53',NULL,NULL,NULL,'2024-11-26 06:52:34'),(56,31,NULL,3,1,1000,1000,1000,0,1000,5.5,5.5,0,11,55,55,0,110,1110,0,'2024-11-21 18:54:27',NULL,NULL,NULL,'2024-11-26 06:52:34'),(57,31,NULL,1,1,500,500,500,0,500,5.5,5.5,0,11,27.5,27.5,0,55,555,0,'2024-11-21 18:54:27',NULL,NULL,NULL,'2024-11-26 06:52:34'),(58,32,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-21 18:54:51',NULL,NULL,NULL,'2024-11-26 06:52:34'),(59,32,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-21 18:54:51',NULL,NULL,NULL,'2024-11-26 06:52:34'),(60,32,9,NULL,1,25,25,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2024-11-21 18:54:51',NULL,NULL,NULL,'2024-11-26 06:52:34'),(61,33,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-21 21:51:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(62,33,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-21 21:51:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(63,33,NULL,2,1,5000,5000,5000,0,5000,5.5,5.5,0,11,275,275,0,550,5550,0,'2024-11-21 21:51:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(64,33,NULL,1,1,500,500,500,0,500,5.5,5.5,0,11,27.5,27.5,0,55,555,0,'2024-11-21 21:51:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(65,33,NULL,3,1,1000,1000,1000,0,1000,5.5,5.5,0,11,55,55,0,110,1110,0,'2024-11-21 21:51:01',NULL,NULL,NULL,'2024-11-26 06:52:34'),(67,34,9,NULL,1,25,0,25,0,25,0,0,0,12,0,0,0,3,28,0,'2024-11-22 04:04:37',NULL,NULL,5,'2024-12-03 11:51:05'),(68,34,NULL,3,1,1000,1000,1000,0,1000,0,0,0,11,0,0,0,110,1110,0,'2024-11-22 04:04:37',NULL,NULL,5,'2024-12-03 11:51:05'),(70,34,NULL,2,1,5000,5000,5000,0,5000,0,0,0,11,0,0,0,550,5550,0,'2024-11-22 04:04:37',NULL,NULL,5,'2024-12-03 11:51:05'),(71,35,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-22 06:50:38',NULL,NULL,NULL,'2024-11-26 06:52:34'),(72,35,9,NULL,1,25,25,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2024-11-22 06:50:38',NULL,NULL,NULL,'2024-11-26 06:52:34'),(73,5,NULL,2,1,5000,5000,5000,0,5000,5.5,5.5,0,11,275,275,0,550,5550,0,'2024-11-26 07:26:57',NULL,NULL,5,'2024-11-26 07:27:02'),(74,5,NULL,1,1,500,500,500,0,500,5.5,5.5,0,11,27.5,27.5,0,55,555,0,'2024-11-26 07:27:07',NULL,NULL,5,'2024-11-26 07:27:13'),(75,5,NULL,3,1,1000,1000,1000,0,1000,5.5,5.5,0,11,55,55,0,110,1110,0,'2024-11-26 07:27:13',NULL,NULL,5,'2024-11-26 07:27:13'),(76,36,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-26 07:30:08',NULL,NULL,5,'2024-11-26 07:30:08'),(77,36,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-26 07:30:08',NULL,NULL,5,'2024-11-26 07:30:08'),(78,36,NULL,1,1,500,500,500,0,500,5.5,5.5,0,11,27.5,27.5,0,55,555,0,'2024-11-26 07:30:08',NULL,NULL,5,'2024-11-26 07:30:08'),(79,36,NULL,3,1,1000,1000,1000,0,1000,5.5,5.5,0,11,55,55,0,110,1110,0,'2024-11-26 07:30:08',NULL,NULL,5,'2024-11-26 07:30:08'),(80,37,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-26 10:49:39',NULL,NULL,5,'2024-11-26 10:49:39'),(81,38,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-26 10:50:02',NULL,NULL,5,'2024-11-26 10:50:02'),(82,39,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-26 18:45:59',NULL,NULL,5,'2024-11-26 18:45:59'),(83,39,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-26 18:45:59',NULL,NULL,5,'2024-11-26 18:45:59'),(84,39,NULL,3,1,1000,1000,1000,0,1000,5.5,5.5,0,11,55,55,0,110,1110,0,'2024-11-26 18:45:59',NULL,NULL,5,'2024-11-26 18:45:59'),(85,39,NULL,1,1,500,500,500,0,500,5.5,5.5,0,11,27.5,27.5,0,55,555,0,'2024-11-26 18:45:59',NULL,NULL,5,'2024-11-26 18:45:59'),(86,40,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-26 20:22:28',NULL,NULL,5,'2024-11-26 20:22:28'),(87,40,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-26 20:22:28',NULL,NULL,5,'2024-11-26 20:22:28'),(88,41,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-26 20:23:25',NULL,NULL,5,'2024-11-26 20:23:25'),(89,42,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-26 20:24:34',NULL,NULL,5,'2024-11-26 20:24:34'),(90,43,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-26 20:49:45',NULL,NULL,5,'2024-11-26 20:49:45'),(91,44,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-26 20:50:14',NULL,NULL,5,'2024-11-26 20:50:14'),(92,45,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-27 07:47:23',NULL,NULL,5,'2024-11-27 07:47:23'),(93,45,9,NULL,1,25,25,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2024-11-27 07:47:23',NULL,NULL,5,'2024-11-27 07:47:23'),(94,46,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-11-27 07:54:17',NULL,NULL,5,'2024-11-27 07:54:17'),(95,47,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-27 08:01:20',NULL,NULL,5,'2024-11-27 08:01:20'),(96,47,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-11-27 08:01:20',NULL,NULL,5,'2024-11-27 08:01:20'),(97,47,NULL,1,1,500,500,500,0,500,5.5,5.5,0,11,27.5,27.5,0,55,555,0,'2024-11-27 08:01:20',NULL,NULL,5,'2024-11-27 08:01:20'),(98,47,NULL,2,1,5000,5000,5000,0,5000,5.5,5.5,0,11,275,275,0,550,5550,0,'2024-11-27 08:01:20',NULL,NULL,5,'2024-11-27 08:01:20'),(99,47,NULL,3,1,1000,1000,1000,0,1000,5.5,5.5,0,11,55,55,0,110,1110,0,'2024-11-27 08:01:20',NULL,NULL,5,'2024-11-27 08:01:20'),(100,48,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-27 08:02:39',NULL,NULL,5,'2024-11-27 08:02:39'),(101,48,NULL,3,1,1000,1000,1000,0,1000,5.5,5.5,0,11,55,55,0,110,1110,0,'2024-11-27 08:02:39',NULL,NULL,5,'2024-11-27 08:02:39'),(102,49,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-27 15:13:25',NULL,NULL,5,'2024-11-27 15:13:25'),(103,49,NULL,2,1,5000,5000,5000,0,5000,5.5,5.5,0,11,275,275,0,550,5550,0,'2024-11-27 15:13:25',NULL,NULL,5,'2024-11-27 15:13:25'),(104,50,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-28 06:21:35',NULL,NULL,5,'2024-11-28 06:21:35'),(105,51,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-28 06:26:03',NULL,NULL,5,'2024-11-28 06:26:03'),(106,52,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-28 06:27:20',NULL,NULL,5,'2024-11-28 06:27:20'),(107,53,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-28 06:27:58',NULL,NULL,5,'2024-11-28 06:27:58'),(108,54,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-28 06:28:07',NULL,NULL,5,'2024-11-28 06:28:07'),(109,55,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-11-28 06:32:55',NULL,NULL,5,'2024-11-28 06:32:55'),(110,56,11,NULL,1,25,30,25,0,25,5.5,5.5,0,11,1.375,1.375,0,2.75,27.75,15,'2024-12-03 11:51:59',NULL,NULL,5,'2024-12-03 11:51:59'),(111,56,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-12-03 11:51:59',NULL,NULL,5,'2024-12-03 11:51:59'),(112,56,NULL,1,1,500,500,500,0,500,5.5,5.5,0,11,27.5,27.5,0,55,555,0,'2024-12-03 11:51:59',NULL,NULL,5,'2024-12-03 11:51:59'),(113,56,NULL,2,1,5000,5000,5000,0,5000,5.5,5.5,0,11,275,275,0,550,5550,0,'2024-12-03 11:51:59',NULL,NULL,5,'2024-12-03 11:51:59'),(114,57,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2024-12-11 13:01:24',NULL,NULL,2,'2024-12-11 13:01:24'),(115,57,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2024-12-11 13:01:24',NULL,NULL,2,'2024-12-11 13:01:24'),(116,58,12,NULL,2,35,45,70,0,70,5.5,5.5,0,11,3.85,3.85,0,7.7,77.7,25,'2025-01-29 07:35:42',NULL,NULL,2,'2025-01-29 07:35:42'),(117,58,9,NULL,1,25,25,25,0,25,6,6,0,12,1.5,1.5,0,3,28,25,'2025-01-29 07:35:42',NULL,NULL,2,'2025-01-29 07:35:42'),(118,59,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,25,'2025-01-29 10:26:09',NULL,NULL,2,'2025-01-29 10:26:09'),(119,59,10,NULL,1,44,44,44,0,44,6,6,0,12,2.64,2.64,0,5.28,49.28,20,'2025-01-29 10:26:09',NULL,NULL,2,'2025-01-29 10:26:09');
/*!40000 ALTER TABLE `sales_items` ENABLE KEYS */;
UNLOCK TABLES;
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
-- Dumping data for table `sales_items_deleted`
--

LOCK TABLES `sales_items_deleted` WRITE;
/*!40000 ALTER TABLE `sales_items_deleted` DISABLE KEYS */;
INSERT INTO `sales_items_deleted` VALUES (5,1,30,NULL,3,1,1000,1000,1000,0,1000,5.5,5.5,0,11,55,55,0,110,1110,'2024-11-21 18:53:53','2024-11-21 19:31:57',5,'del'),(6,1,34,12,NULL,1,35,45,35,0,35,5.5,5.5,0,11,1.925,1.925,0,3.85,38.85,'2024-11-22 04:04:37','2024-11-22 04:38:14',5,'test'),(7,1,34,NULL,1,1,500,500,500,0,500,5.5,5.5,0,11,27.5,27.5,0,55,555,'2024-11-22 04:04:37','2024-11-22 04:38:23',5,'test');
/*!40000 ALTER TABLE `sales_items_deleted` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `service_types`
--

LOCK TABLES `service_types` WRITE;
/*!40000 ALTER TABLE `service_types` DISABLE KEYS */;
INSERT INTO `service_types` VALUES (1,'Engine Oil Change',500,'',NULL,1,1,5,5,'2024-11-21 18:25:36','2024-11-21 18:25:36'),(2,'Body Paint',5000,'usjdjfj',NULL,1,1,5,2,'2024-11-21 18:26:45','2025-01-29 10:31:13'),(3,'Filters Change',1000,'',NULL,1,1,5,5,'2024-11-21 18:27:12','2024-11-21 18:27:12');
/*!40000 ALTER TABLE `service_types` ENABLE KEYS */;
UNLOCK TABLES;

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
  `IsSendWhatsAppMessageOnInvoiceisSendWhatsAppMessageOnInvoice` tinyint NOT NULL DEFAULT '0',
  `IsShareInvoiceOnInvoice` tinyint NOT NULL DEFAULT '0',
  `SalesMessageId` int DEFAULT NULL,
  `ServiceMessageId` int DEFAULT NULL,
  `BalanceMessageId` int DEFAULT NULL,
  `FestivalMessageId` int DEFAULT NULL,
  `UPIId` varchar(60) DEFAULT NULL,
  `UPIName` varchar(100) DEFAULT NULL,
  `UPIMerchantCode` varchar(30) DEFAULT NULL,
  `IsServiceRequestEnabled` tinyint NOT NULL DEFAULT '0',
  `IsItemSearchImageVisible` tinyint NOT NULL DEFAULT '0',
  `IsBackupOnLogin` tinyint NOT NULL DEFAULT '0',
  `IsViewAllItemsOnSearch` tinyint NOT NULL DEFAULT '0',
  `EmailBodyForSalesInvoice` varchar(250) DEFAULT NULL,
  `IsSendWhatsAppMessageOnInvoice` tinyint NOT NULL DEFAULT '0',
  `IsSalesPriceEdited` tinyint NOT NULL DEFAULT '0',
  `IsCurrencyDecimalNotRequired` tinyint NOT NULL DEFAULT '0',
  `LocalLanguageCode` varchar(2) NOT NULL,
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
-- Dumping data for table `settings`
--

LOCK TABLES `settings` WRITE;
/*!40000 ALTER TABLE `settings` DISABLE KEYS */;
INSERT INTO `settings` VALUES (1,'GEVA TECHNOLOGIES','','','','','',1,1,1,'','Nellore','','','37ABCD2541411',1,1,0,'INVF24-',5,1,1,1,1,0,'2024-10-28 14:08:48','2025-01-29 07:32:14',2,2,1,1,1,1,1,0,0,0,4,3,4,4,'','','',0,1,1,1,'',0,0,0,'');
/*!40000 ALTER TABLE `settings` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (3,1,'2024-10-30','Cash','',49.28,49.28,NULL,NULL,3,'PURCHASE_CASH','2024-10-30 18:16:37','2024-10-30 18:16:32',2,2,NULL,NULL),(4,1,'2024-10-30','Cash','',5404,5404,NULL,NULL,4,'PURCHASE_CASH','2024-10-30 18:20:23','2024-10-30 18:20:23',2,2,NULL,NULL),(7,2,'2024-10-31','Cash','',-0.00000000000005684341886080802,-0.00000000000005684341886080802,NULL,NULL,7,'PURCHASE_CASH','2024-10-31 18:45:02','2024-10-31 18:45:02',2,2,NULL,NULL),(8,2,'2024-10-31','Cash','',0,0,NULL,NULL,8,'PURCHASE_CASH','2024-10-31 19:04:39','2024-10-31 19:04:39',2,2,NULL,NULL),(9,1,'2024-11-01','Cash','',277.5,277.5,NULL,NULL,9,'PURCHASE_CASH','2024-11-01 07:44:00','2024-11-01 07:44:00',2,2,NULL,NULL),(10,2,'2024-11-01','Cash','',7264.28,7264.28,'',5,NULL,'SALES_CASH','2024-11-01 17:50:46','2024-11-26 07:27:47',2,5,NULL,NULL),(14,1,'2024-11-02','Cash','',0,34324,'',NULL,NULL,'PAYMENT','2024-11-02 06:33:27','2024-11-02 06:33:27',2,2,NULL,NULL),(17,2,'2024-11-02','Credit','',11928,0,NULL,NULL,10,'PURCHASE_CREDIT','2024-11-02 12:28:13','2024-11-02 12:28:13',2,2,NULL,NULL),(18,1,'2024-11-02','Cash','',1232,1232,NULL,NULL,11,'PURCHASE_CASH','2024-11-02 13:38:47','2024-11-02 13:38:47',2,2,NULL,NULL),(19,2,'2024-11-04','Cash','',27.75,27.75,'',11,NULL,'SALES_CASH','2024-11-04 19:13:02','2024-11-04 19:13:02',2,2,NULL,NULL),(20,8,'2024-11-04','Cash','',66.6,66.6,'',12,NULL,'SALES_CASH','2024-11-04 19:14:43','2024-11-04 19:14:43',2,2,NULL,NULL),(21,8,'2024-11-05','Cash','',115.88,115.88,'',13,NULL,'SALES_CASH','2024-11-05 15:08:41','2024-11-05 15:08:41',2,2,NULL,NULL),(22,8,'2024-11-07','Cash','',250,0,'',NULL,NULL,'RECEIPT','2024-11-07 06:47:32','2024-11-07 06:47:32',2,2,NULL,NULL),(23,8,'2024-11-08','Cash','',77.28,77.28,'',14,NULL,'SALES_CASH','2024-11-08 09:53:19','2024-11-08 09:53:19',2,2,NULL,NULL),(24,8,'2024-11-08','Credit','',0,88.13,'',15,NULL,'SALES_CREDIT','2024-11-08 09:53:50','2024-11-08 09:53:50',2,2,NULL,NULL),(25,8,'2024-11-12','Cash','',143.88,143.88,'',21,NULL,'SALES_CASH','2024-11-12 19:05:13','2024-11-12 19:05:13',2,2,NULL,NULL),(26,8,'2024-11-12','Cash','',38.85,38.85,'',22,NULL,'SALES_CASH','2024-11-12 19:06:37','2024-11-12 19:06:37',2,2,NULL,NULL),(27,8,'2024-11-12','Cash','',27.75,27.75,'',23,NULL,'SALES_CASH','2024-11-12 19:07:57','2024-11-12 19:07:57',2,2,NULL,NULL),(28,8,'2024-11-12','Cash','',143.88,143.88,'',24,NULL,'SALES_CASH','2024-11-12 19:08:27','2024-11-12 19:08:27',2,2,NULL,NULL),(29,8,'2024-11-21','Cash','',1665,1665,'',31,NULL,'SALES_CASH','2024-11-21 18:54:27','2024-11-21 18:54:27',5,5,NULL,NULL),(30,8,'2024-11-21','Cash','',116.13,116.13,'',32,NULL,'SALES_CASH','2024-11-21 18:54:51','2024-11-21 18:54:51',5,5,NULL,NULL),(31,2,'2024-11-21','Cash','',19525,19525,'',NULL,12,'PURCHASE_CASH','2024-11-21 19:38:04','2024-11-21 20:00:46',5,5,NULL,NULL),(32,2,'2024-11-22','Cash','',5550,5550,'',NULL,13,'PURCHASE_CASH','2024-11-22 04:02:13','2024-11-22 04:02:13',5,5,NULL,NULL),(33,2,'2024-11-22','Cash','',448,448,'',NULL,14,'PURCHASE_CASH','2024-11-22 04:03:30','2024-11-22 04:03:30',5,5,NULL,NULL),(34,8,'2024-11-26','Cash','',1753.13,1753.13,'',39,NULL,'SALES_CASH','2024-11-26 18:45:59','2024-11-26 18:45:59',5,5,NULL,NULL),(35,8,'2024-11-27','Cash','',27.75,27.75,'',46,NULL,'SALES_CASH','2024-11-27 07:54:17','2024-11-27 07:54:17',5,5,NULL,NULL),(36,8,'2024-11-27','Cash','',7303.13,7303.13,'',47,NULL,'SALES_CASH','2024-11-27 08:01:20','2024-11-27 08:01:20',5,5,NULL,NULL),(37,8,'2024-11-27','Cash','',1148.85,1148.85,'',48,NULL,'SALES_CASH','2024-11-27 08:02:39','2024-11-27 08:02:39',5,5,NULL,NULL),(38,8,'2024-11-27','Cash','',5588.85,5588.85,'',49,NULL,'SALES_CASH','2024-11-27 15:13:25','2024-11-27 15:13:25',5,5,NULL,NULL),(39,2,'2024-12-10','Cash','',36000,36000,'',NULL,15,'PURCHASE_CASH','2024-12-10 20:59:17','2024-12-10 20:59:17',2,2,NULL,NULL),(40,2,'2024-12-10','Cash','',36000,36000,'',NULL,16,'PURCHASE_CASH','2024-12-10 21:02:20','2024-12-10 21:02:20',2,2,NULL,NULL),(41,2,'2024-12-10','Cash','',1093.35,1093.35,'',NULL,17,'PURCHASE_CASH','2024-12-10 21:02:56','2024-12-10 21:02:56',2,2,NULL,NULL),(42,2,'2025-01-29','Cash','',5100,5100,'',NULL,18,'PURCHASE_CASH','2025-01-29 09:45:50','2025-01-29 09:45:50',2,2,NULL,NULL),(43,2,'2025-01-29','Cash','',333.5,333.5,'',NULL,19,'PURCHASE_CASH','2025-01-29 09:48:58','2025-01-29 09:48:58',2,2,NULL,NULL),(44,2,'2025-01-29','Cash','',616.5,616.5,'',NULL,20,'PURCHASE_CASH','2025-01-29 10:13:44','2025-01-29 10:13:44',2,2,NULL,NULL),(45,2,'2025-01-29','Cash','',1393.75,1393.75,'',NULL,21,'PURCHASE_CASH','2025-01-29 10:16:44','2025-01-29 10:16:44',2,2,NULL,NULL),(46,2,'2025-01-29','Cash','',1465,1465,'',NULL,22,'PURCHASE_CASH','2025-01-29 10:22:08','2025-01-29 10:22:08',2,2,NULL,NULL);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `transactions_deleted`
--

LOCK TABLES `transactions_deleted` WRITE;
/*!40000 ALTER TABLE `transactions_deleted` DISABLE KEYS */;
/*!40000 ALTER TABLE `transactions_deleted` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unlock_requests`
--

LOCK TABLES `unlock_requests` WRITE;
/*!40000 ALTER TABLE `unlock_requests` DISABLE KEYS */;
INSERT INTO `unlock_requests` VALUES (1,5,NULL,'sdfsdafa dsdafsda dsaf dsfsdsad',2,'2024-11-09 05:38:25','2024-11-21 19:38:36',5,1,0),(2,7,NULL,'sdfds dsf sfsd',2,'2024-11-09 05:40:20','2024-11-21 19:38:40',5,1,0),(3,14,NULL,'sdafdsafsad df sdafdsa',2,'2024-11-09 05:40:27','2024-11-21 19:38:44',5,1,0),(4,10,NULL,'fsfdfsfds',2,'2024-11-09 10:44:54','2024-11-21 19:38:48',5,1,0),(5,10,NULL,'sdafasfasdf',2,'2024-11-09 10:45:00','2024-11-21 19:38:55',5,1,0),(6,30,NULL,'testing \n',5,'2024-11-21 19:14:47','2024-11-21 19:14:59',5,1,0),(7,NULL,12,'thcc\n',5,'2024-11-21 19:38:21','2024-11-21 19:39:35',5,1,0),(8,34,NULL,'test\n',5,'2024-11-22 04:37:53','2024-11-22 04:38:01',5,1,0),(9,NULL,13,'ggy\n',5,'2024-11-22 04:56:15','2024-11-22 04:56:22',5,1,0),(10,36,NULL,'hxhhdh bdhhd\n',5,'2024-11-26 11:57:42','2024-11-26 11:57:49',5,1,0),(11,NULL,18,'dnnxjc\n',2,'2025-01-29 09:47:18','2025-01-29 09:47:28',2,1,0);
/*!40000 ALTER TABLE `unlock_requests` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (2,'admin','Ravi','Buchingari','Nellore','9959963575','wgR7mCoQooeZhquIG6vJy7Kq/sqUyHYuZQJy6fdQ50QncTt7B3Bu2CpnnFNF9XMK','uag3qcuHc51inq+hVzNVcqO0WR9yiv8mzKP6Hp3ngWQ=',1,1,'d390c4b8f9dd4b1a9988fcd8cd788f91','0001-01-01 00:00:00','2025-01-29 10:54:38',NULL,5,'AlUguV5G8p+cx3Beep8VTl3wEWkX0azHc0hty4UCW4H8EwXB9ILkAz4aAZG5bkHKnS+fP8d23V9U9CMNAxDW6U4UDgn1jV2wwrIfGr/Vwb75DPELgK0BcneJVUJKBvz8w8OjcgtQCMWyHuSBtERdDhA+ia21rXseyRm6m0W2dMEBZin8kA+5l0m6uQpG3csjv708hHwBslZrH+lmZpogUxVUuGLYoaCt9d6qd3lyZDw9zh+Qr2fX5rhMd+4i8G8m7dJvN5q69+9c2iKNkSR8BiOmF1DfAh/KomUgg6jTvcMeBvSFICGOWH8PGIuTiAPo'),(4,'dsfsadf','Sdfsd','Dsafsa','sdfsfdsaf\n','2342423423','WtrmqLqmwg5iJqQrscFbClrSB8oUBWo72PDQSLSVFTTISx/pREsdPgWZQkuYMKPo','EGaCG+uvh/T6KkdRhxmrqgqitIvN41vLNcMyia2EW6o=',0,1,NULL,'2024-11-02 11:54:36','2024-11-02 12:06:52',2,2,NULL),(5,'a','Ravi','Buchingari','nellore','9494855767','lu5icgk1t7WRq4EXG0l9Cc/CfxdYaI7ODAADtv0utI8F0egRYsEbItmZlwbK5xdb','2Sb82wG3XuJay7a46k7KpEcjLjEHVSrFfnte0HcquhU=',1,1,'dff852557815490d8e408fc0bf203b0d','0001-01-01 00:00:00','2024-12-03 11:50:20',NULL,NULL,'AlUguV5G8p+cx3Beep8VTs4UI9S8G9JOP9JjBbIesdWbK8adfZx5cvO757mOwwmN4LcJgEGj4xfjq4aH7ETKKqpUuGUon4bQtkiaFWK8ZjQuBEpwvySMgaLtjkuQzc6LCr1ZrglbHgVhvV6HiV8cEK3lYjQ2+rLy1wdU0RjSJpagTfTfk40Roy6n4FXn5GwWT2q1tbzWEm1A2YEbiSpSFk6J/wS7f4hUX/6LsytNnet98dDTkCA9hBAPXQPUgPF6PDBbzS3QbMp/uheLhcj0EHq3vX4YIQN3W+QGjhEGsqNMiPcHK8fwyY++NCcRSrbT');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

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

-- Dump completed on 2025-04-04  9:59:53
