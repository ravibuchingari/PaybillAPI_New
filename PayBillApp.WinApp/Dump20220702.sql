-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: smartbilling
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `tbl_admin`
--

DROP TABLE IF EXISTS `tbl_admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_admin` (
  `service_name` varchar(100) NOT NULL,
  `emp_default_password` varchar(250) NOT NULL,
  `fcm_server_api_key` varchar(500) DEFAULT NULL,
  `fcm_server_sender_id` varchar(100) DEFAULT NULL,
  `otp_sms_api` varchar(500) DEFAULT NULL,
  `enquiry_otp_template_id` varchar(50) DEFAULT NULL,
  `reset_otp_template_id` varchar(50) DEFAULT NULL,
  `apk_version_code` int NOT NULL DEFAULT '0',
  `is_apk_upgrade_mandatory` int NOT NULL DEFAULT '1',
  `client_alert_days` tinyint NOT NULL DEFAULT '7',
  `offline_apk_download_required` int NOT NULL DEFAULT '1',
  `payment_gateway_merchant_key` varchar(250) DEFAULT NULL,
  `payment_gateway_merchant_secret_key` varchar(250) DEFAULT NULL,
  `email_sales_user_id` varchar(500) DEFAULT NULL,
  `email_support_user_id` varchar(500) DEFAULT NULL,
  `email_password` varchar(500) DEFAULT NULL,
  `email_smtp_host` varchar(500) DEFAULT NULL,
  `email_port` int DEFAULT NULL,
  `email_ssl_enabled` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`service_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_admin`
--

LOCK TABLES `tbl_admin` WRITE;
/*!40000 ALTER TABLE `tbl_admin` DISABLE KEYS */;
INSERT INTO `tbl_admin` VALUES ('PayBillApp','Qv8hodZfT6QDpzMIXN/An7O8XaK05D4TNcs4jCWOx1R8lMv7hoD+pdxoGvW9+uoz','T+NotOcMt3a5nMAilL0BNf1X5215r2OeFxA/OaZeGvcjVhz7gKO3TfcK7OZAXIUOBDg/xQMVOaXrWHt6NfCSMRN1SBl+7CkaooNXBjetjoBSKBun+ZqKQMiAQEvQNk4gdbVtyBjA2EA6dCSXdCljUCkdYmQpbBktxZaZAhfXe8yyEYRTAxWxp8uLRhHJPCKjihNa8+IVcA0hL2xeakf3Yw==','RryacggArpMQmxn+uiC45A==','bvme/15o0oLEwvMKNh97qRJdBiqIhjouj8kz68zB6WZuS0HNUzlUE4kIpCtK9XE7XI7KyBbzgb0NIWirwkvzRluAJV/oEY2nlPDKKpvdbydFXttvbV20/fbNoHjkj/px','PAYBILL_OTP','PAYBILL_PASSWORD_RESET_OTP',10,1,7,0,'x/6soNj6b18mDf+qpgCc9Q==','h68EieOaZI4V2xzLWo4QS2/75iRuDgdUjfzZ/I2/51Q=','FsWMFUDRumzA0zaLUyfErGLojS7PaCRBtj0l1lU9iOM=','3Uzcnkc7VvfYXBZ0og48gGSnXIr+2JuATf9ypKlwE0E=','KechgwqEPuF5+Gl96qebmg==','aridU61D3+l0mDEN15a8dzL2JBrrZLxl7GowLOOQt2g=',996,1);
/*!40000 ALTER TABLE `tbl_admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_cities`
--

DROP TABLE IF EXISTS `tbl_cities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_cities` (
  `city_id` bigint NOT NULL AUTO_INCREMENT,
  `city_name` varchar(50) NOT NULL,
  `is_active` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`city_id`),
  UNIQUE KEY `city_name_UNIQUE` (`city_name`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_cities`
--

LOCK TABLES `tbl_cities` WRITE;
/*!40000 ALTER TABLE `tbl_cities` DISABLE KEYS */;
INSERT INTO `tbl_cities` VALUES (1,'Nellore',1),(2,'Kavali',1),(3,'Guduru',1),(4,'Ongole',1),(6,'Gudur',1),(7,'Vijayawada',1),(14,'Hyderabad',1),(15,'Bangalore',1),(16,'ANANTAPUR',1),(17,'CHITTOOR',1),(18,'EAST GODAVARI',1),(19,'GUNTUR',1),(20,'KRISHNA',1),(21,'KURNOOL',1),(22,'PRAKASAM',1),(23,'SPSR NELLORE',1),(24,'SRIKAKULAM',1),(25,'VISAKHAPATANAM',1),(26,'VIZIANAGARAM',1),(27,'WEST GODAVARI',1);
/*!40000 ALTER TABLE `tbl_cities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_client_payment_types`
--

DROP TABLE IF EXISTS `tbl_client_payment_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_client_payment_types` (
  `client_payment_id` bigint NOT NULL AUTO_INCREMENT,
  `client_id` bigint NOT NULL,
  `payment_type_id` int NOT NULL,
  PRIMARY KEY (`client_payment_id`),
  UNIQUE KEY `uq_clientid_paymentid` (`client_id`,`payment_type_id`),
  KEY `fk_client_pay_paymentid_idx` (`payment_type_id`),
  CONSTRAINT `fk_client_pay_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_client_pay_paymentid` FOREIGN KEY (`payment_type_id`) REFERENCES `tbl_payment_types` (`payment_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_client_payment_types`
--

LOCK TABLES `tbl_client_payment_types` WRITE;
/*!40000 ALTER TABLE `tbl_client_payment_types` DISABLE KEYS */;
INSERT INTO `tbl_client_payment_types` VALUES (7,1,1),(8,1,2),(9,1,3);
/*!40000 ALTER TABLE `tbl_client_payment_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_client_payments`
--

DROP TABLE IF EXISTS `tbl_client_payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_client_payments` (
  `payment_id` bigint NOT NULL AUTO_INCREMENT,
  `client_id` bigint NOT NULL,
  `payment_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `payment_trans_no` varchar(100) NOT NULL,
  `payment_amount` double NOT NULL,
  `payment_status` varchar(50) NOT NULL,
  `payment_remarks` varchar(500) DEFAULT NULL,
  `emp_user_id` varchar(150) NOT NULL,
  `package_id` int NOT NULL,
  `order_id` varchar(60) NOT NULL,
  `is_auto_insert` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`payment_id`),
  UNIQUE KEY `payment_trans_no_UNIQUE` (`payment_trans_no`),
  KEY `fk_subsc_pmt_clinetId_idx` (`client_id`),
  KEY `fk__idx` (`emp_user_id`),
  KEY `fk_subsc_pmt_pacakgeid_idx` (`package_id`),
  CONSTRAINT `fk_subsc_pmt_clinetId` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_subsc_pmt_emp_userid` FOREIGN KEY (`emp_user_id`) REFERENCES `tbl_users` (`emp_user_id`),
  CONSTRAINT `fk_subsc_pmt_pacakgeid` FOREIGN KEY (`package_id`) REFERENCES `tbl_packages` (`package_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_client_payments`
--

LOCK TABLES `tbl_client_payments` WRITE;
/*!40000 ALTER TABLE `tbl_client_payments` DISABLE KEYS */;
INSERT INTO `tbl_client_payments` VALUES (1,1,'2021-07-21 02:55:54','10001',15000,'Success','Razar','ravi2',4,'12541241',1),(2,1,'2021-12-10 06:54:59','pay_IVP0fPgRpI0U0z',1,'SUCCESS','Razorpay Checkout','ravi2',4,'470rrr506',0);
/*!40000 ALTER TABLE `tbl_client_payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_client_payments_failed`
--

DROP TABLE IF EXISTS `tbl_client_payments_failed`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_client_payments_failed` (
  `payment_id` bigint NOT NULL AUTO_INCREMENT,
  `client_id` bigint NOT NULL,
  `payment_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `payment_trans_no` varchar(100) NOT NULL,
  `payment_amount` double NOT NULL,
  `payment_status` varchar(50) NOT NULL,
  `payment_remarks` varchar(500) DEFAULT NULL,
  `emp_user_id` varchar(150) NOT NULL,
  `package_id` int NOT NULL,
  `order_id` varchar(60) NOT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_client_payments_failed`
--

LOCK TABLES `tbl_client_payments_failed` WRITE;
/*!40000 ALTER TABLE `tbl_client_payments_failed` DISABLE KEYS */;
INSERT INTO `tbl_client_payments_failed` VALUES (2,1,'2021-12-10 05:48:33','pay_IVP0fPgRpI0U0z',1,'SUCCESS','Razorpay Checkout','ravi2',4,'470506c1be5549df87bda098c6e854ff');
/*!40000 ALTER TABLE `tbl_client_payments_failed` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_client_requests`
--

DROP TABLE IF EXISTS `tbl_client_requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_client_requests` (
  `request_id` bigint NOT NULL AUTO_INCREMENT,
  `client_name` varchar(100) NOT NULL,
  `contact_name` varchar(100) NOT NULL,
  `client_address` varchar(500) NOT NULL,
  `contact_mobile` varchar(10) NOT NULL,
  `contact_email` varchar(100) DEFAULT NULL,
  `client_gst` varchar(20) DEFAULT NULL,
  `client_type_id` bigint NOT NULL,
  `locality_id` bigint NOT NULL,
  `is_mobile_validated` int NOT NULL DEFAULT '0',
  `is_email_validated` int NOT NULL DEFAULT '0',
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `request_otp` varchar(100) DEFAULT NULL,
  `request_otp_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `request_is_new` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`request_id`),
  KEY `fk_client_requests_typeid_idx` (`client_type_id`),
  KEY `fk_client_requests_localityid_idx` (`locality_id`),
  CONSTRAINT `fk_client_requests_localityid` FOREIGN KEY (`locality_id`) REFERENCES `tbl_locality` (`locality_id`),
  CONSTRAINT `fk_client_requests_typeid` FOREIGN KEY (`client_type_id`) REFERENCES `tbl_client_types` (`client_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_client_requests`
--

LOCK TABLES `tbl_client_requests` WRITE;
/*!40000 ALTER TABLE `tbl_client_requests` DISABLE KEYS */;
INSERT INTO `tbl_client_requests` VALUES (4,'test','test','tesa','7676575675','','',3,1,0,0,'2021-12-20 08:23:28','eCcxG3KIJ2zXYV9JZtKn7Q==','2021-12-20 08:23:28',1),(7,'sdfdsaf','asdfsafsa','sdfsafsdf','9640955888','','',3,5,0,0,'2021-12-20 08:53:09','ePiVv0S55ECpS7C8BJFkog==','2021-12-20 08:53:09',1),(8,'sdafasf','dsafsaf','sdafsadfsd','9540955888','','',3,5,0,0,'2021-12-20 08:54:59','9i0YPkign+u8K4jhvtetBg==','2021-12-20 08:54:59',1);
/*!40000 ALTER TABLE `tbl_client_requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_client_status`
--

DROP TABLE IF EXISTS `tbl_client_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_client_status` (
  `client_status_id` tinyint NOT NULL,
  `client_status_desc` varchar(45) NOT NULL,
  PRIMARY KEY (`client_status_id`),
  UNIQUE KEY `client_status_desc_UNIQUE` (`client_status_desc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_client_status`
--

LOCK TABLES `tbl_client_status` WRITE;
/*!40000 ALTER TABLE `tbl_client_status` DISABLE KEYS */;
INSERT INTO `tbl_client_status` VALUES (1,'Active'),(2,'Inactive'),(3,'Suspended');
/*!40000 ALTER TABLE `tbl_client_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_client_types`
--

DROP TABLE IF EXISTS `tbl_client_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_client_types` (
  `client_type_id` bigint NOT NULL AUTO_INCREMENT,
  `client_type_desc` varchar(50) NOT NULL,
  `is_active` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`client_type_id`),
  UNIQUE KEY `client_type_desc_UNIQUE` (`client_type_desc`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_client_types`
--

LOCK TABLES `tbl_client_types` WRITE;
/*!40000 ALTER TABLE `tbl_client_types` DISABLE KEYS */;
INSERT INTO `tbl_client_types` VALUES (1,'Supermaket',1),(2,'Electrical',1),(3,'Automobile',1),(8,'dsfdfsdfs',1);
/*!40000 ALTER TABLE `tbl_client_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_client_upi_types`
--

DROP TABLE IF EXISTS `tbl_client_upi_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_client_upi_types` (
  `client_upi_type_id` bigint NOT NULL AUTO_INCREMENT,
  `client_id` bigint NOT NULL,
  `upi_type_id` int NOT NULL,
  PRIMARY KEY (`client_upi_type_id`),
  UNIQUE KEY `uq_client_upi_clientid_upii` (`client_id`,`upi_type_id`),
  KEY `fk_upi_type_upiid_idx` (`upi_type_id`),
  CONSTRAINT `fk_upi_type_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_upi_type_upiid` FOREIGN KEY (`upi_type_id`) REFERENCES `tbl_upi_types` (`upi_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_client_upi_types`
--

LOCK TABLES `tbl_client_upi_types` WRITE;
/*!40000 ALTER TABLE `tbl_client_upi_types` DISABLE KEYS */;
INSERT INTO `tbl_client_upi_types` VALUES (6,1,1),(7,1,2),(8,1,3),(9,1,4);
/*!40000 ALTER TABLE `tbl_client_upi_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_clients`
--

DROP TABLE IF EXISTS `tbl_clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_clients` (
  `client_id` bigint NOT NULL AUTO_INCREMENT,
  `client_name` varchar(100) NOT NULL,
  `contact_name` varchar(100) NOT NULL,
  `client_address` varchar(500) NOT NULL,
  `contact_mobile1` varchar(10) NOT NULL,
  `contact_mobile2` varchar(10) DEFAULT NULL,
  `contact_email` varchar(100) DEFAULT NULL,
  `client_gst` varchar(20) DEFAULT NULL,
  `client_status_id` tinyint NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `subscription_start_date` date NOT NULL,
  `subscription_end_date` date NOT NULL,
  `client_type_id` bigint NOT NULL,
  `locality_id` bigint NOT NULL,
  `created_by` varchar(50) NOT NULL,
  `sales_invoice_title` varchar(50) DEFAULT NULL,
  `sales_invoice_address` varchar(500) DEFAULT NULL,
  `sales_invoice_terms1` varchar(500) DEFAULT NULL,
  `sales_invoice_terms2` varchar(500) DEFAULT NULL,
  `is_lock_sales_invoice` int NOT NULL DEFAULT '1',
  `is_lock_purchase_invoice` int NOT NULL DEFAULT '1',
  `barcode_is_show_company_name` int NOT NULL DEFAULT '1',
  `barcode_is_show_packed_date` int NOT NULL DEFAULT '1',
  `barcode_is_show_mrp` int NOT NULL DEFAULT '1',
  `barcode_is_show_price` int NOT NULL DEFAULT '1',
  `barcode_company_short_name` varchar(20) DEFAULT NULL,
  `report_format_id` int DEFAULT NULL,
  `emp_default_password` varchar(100) DEFAULT 'KCbyrso3FfYRiSBMarvaJ7a4fn0uK7O19PjYP84jjpQ=',
  `emp_default_salt` varchar(100) DEFAULT 'uNrZGmKgFi9S84+TB+9saOf0pb4=',
  `sales_invoice_lock_in_mins` int NOT NULL DEFAULT '1',
  `invoice_delivery_key` varchar(20) NOT NULL DEFAULT '@wsdedes',
  `invoice_delivery_key_date` date NOT NULL,
  `barcode_required_on_invoice` int NOT NULL DEFAULT '1',
  `payment_type_required` int NOT NULL DEFAULT '1',
  `add_item_on_scan_barcode` int NOT NULL DEFAULT '1',
  `cash_validation_required` int NOT NULL DEFAULT '1',
  `offline_item_validation` int NOT NULL DEFAULT '1',
  `package_discount` double NOT NULL DEFAULT '0',
  `package_id` int NOT NULL DEFAULT '1',
  `language_code` varchar(7) NOT NULL DEFAULT 'en',
  `gst_slab_required_on_invoice` int NOT NULL DEFAULT '1',
  `is_three_column_printer` int NOT NULL DEFAULT '1',
  `validate_stock_on_invoice` int NOT NULL DEFAULT '1',
  `is_optimization_processed` int NOT NULL DEFAULT '0',
  `items_download_automatically` int NOT NULL DEFAULT '1',
  `extra_discount_required` int NOT NULL DEFAULT '0',
  `gst_included_on_price` int NOT NULL DEFAULT '1',
  `is_allow_device_item_reg` int NOT NULL DEFAULT '1',
  `is_trail` int NOT NULL DEFAULT '0',
  `payment_id` bigint DEFAULT NULL,
  `discount_in_rs` double NOT NULL DEFAULT '0',
  `discount_end_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `last_access_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `logo_required_on_invoice` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`client_id`),
  KEY `fk_status_id_idx` (`client_status_id`),
  KEY `fk_client_typeid_idx` (`client_type_id`),
  KEY `fk_client_localityid_idx` (`locality_id`),
  KEY `fk_client_createdby_idx` (`created_by`),
  KEY `fk_client_report_idx` (`report_format_id`),
  KEY `fk_client_package_idx` (`package_id`),
  KEY `fk_client_paymnet_id_idx` (`payment_id`),
  CONSTRAINT `fk_client_createdby` FOREIGN KEY (`created_by`) REFERENCES `tbl_cp_users` (`user_id`),
  CONSTRAINT `fk_client_localityid` FOREIGN KEY (`locality_id`) REFERENCES `tbl_locality` (`locality_id`),
  CONSTRAINT `fk_client_package` FOREIGN KEY (`package_id`) REFERENCES `tbl_packages` (`package_id`),
  CONSTRAINT `fk_client_paymnet_id` FOREIGN KEY (`payment_id`) REFERENCES `tbl_client_payments` (`payment_id`),
  CONSTRAINT `fk_client_report` FOREIGN KEY (`report_format_id`) REFERENCES `tbl_report_format` (`report_format_id`),
  CONSTRAINT `fk_client_status_id` FOREIGN KEY (`client_status_id`) REFERENCES `tbl_client_status` (`client_status_id`),
  CONSTRAINT `fk_client_typeid` FOREIGN KEY (`client_type_id`) REFERENCES `tbl_client_types` (`client_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_clients`
--

LOCK TABLES `tbl_clients` WRITE;
/*!40000 ALTER TABLE `tbl_clients` DISABLE KEYS */;
INSERT INTO `tbl_clients` VALUES (1,'Geva Mart','Ravi Buchingari','Nellore','9959963575','','ravi.buchingari@gmail.com',NULL,1,'2021-07-21 02:55:54','2021-07-21','2023-07-20',1,1,'admin','Test Invoice','address','terms1','terms2',1,1,1,1,1,1,NULL,NULL,'KCbyrso3FfYRiSBMarvaJ7a4fn0uK7O19PjYP84jjpQ=','uNrZGmKgFi9S84+TB+9saOf0pb4=',100,'99445880943280128','2021-09-24',1,1,0,1,1,0,4,'te',1,1,1,0,1,0,1,1,0,2,1000,'2023-12-28 00:00:00','2021-12-14 05:52:34',1),(3,'test','test','test','2343242342','','','',1,'2021-10-29 16:10:14','2021-07-21','2022-07-21',2,1,'admin',NULL,NULL,NULL,NULL,1,1,1,1,1,1,NULL,NULL,'KCbyrso3FfYRiSBMarvaJ7a4fn0uK7O19PjYP84jjpQ=','uNrZGmKgFi9S84+TB+9saOf0pb4=',1,'@wsdedes','2021-10-29',1,1,0,1,1,0,1,'en',1,1,1,0,1,0,1,1,0,NULL,0,'2021-12-07 00:00:00','2021-12-14 05:52:34',0);
/*!40000 ALTER TABLE `tbl_clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_cp_users`
--

DROP TABLE IF EXISTS `tbl_cp_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_cp_users` (
  `user_id` varchar(50) NOT NULL,
  `user_first_name` varchar(50) NOT NULL,
  `user_last_name` varchar(50) NOT NULL,
  `user_mobile` varchar(10) NOT NULL DEFAULT '0',
  `user_email` varchar(150) DEFAULT NULL,
  `user_address` varchar(500) DEFAULT NULL,
  `user_security_key` varchar(100) DEFAULT NULL,
  `user_security_key_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `user_password` varchar(250) NOT NULL,
  `firebase_token` varchar(500) DEFAULT NULL,
  `device_app_id` varchar(250) DEFAULT NULL,
  `is_new_password` int NOT NULL DEFAULT '1',
  `is_control_panel_access` int NOT NULL DEFAULT '0',
  `user_is_active` int NOT NULL,
  `transaction_key` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_cp_users`
--

LOCK TABLES `tbl_cp_users` WRITE;
/*!40000 ALTER TABLE `tbl_cp_users` DISABLE KEYS */;
INSERT INTO `tbl_cp_users` VALUES ('admin','Ravi','Buchingari','9959963575',NULL,'nellore','b92f483e-b7bb-11ec-ba4a-645a049e7771','2022-04-09 09:45:43','deWRqtFlX8pPXeSd8rW0IwCerKbZk7zyPKb2ig+Cw7+HHaAlTxxW2rui0fhyYvP1','de7DkmLdRNSwz5uhFe739O:APA91bHXhvHDXylCiEYazRMPtFapJ5-jJl0tLGBQWQag6NijRWCJTufRF3G1oYtzVvsgOqk6TR0RT-2Z9LXxSVYxEGdvZBqCJWAq9tPs42CR0J5OK9YNoXg5VDVWcDFnrteq1gIGbpMr','UYnkRsgZk/6MGYsGwD/Y1w==',0,1,1,NULL),('dsfsd','433223','543534','5454353453',NULL,'dsfsdfsd',NULL,'2021-10-21 16:03:17','Qv8hodZfT6QDpzMIXN/An7O8XaK05D4TNcs4jCWOx1R8lMv7hoD+pdxoGvW9+uoz','de7DkmLdRNSwz5uhFe739O:APA91bHXhvHDXylCiEYazRMPtFapJ5-jJl0tLGBQWQag6NijRWCJTufRF3G1oYtzVvsgOqk6TR0RT-2Z9LXxSVYxEGdvZBqCJWAq9tPs42CR0J5OK9YNoXg5VDVWcDFnrteq1gIGbpMr','K68mWOPlV09YB6R1INuIaw==',1,0,1,NULL);
/*!40000 ALTER TABLE `tbl_cp_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_customers`
--

DROP TABLE IF EXISTS `tbl_customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_customers` (
  `customer_id` bigint NOT NULL AUTO_INCREMENT,
  `customer_name` varchar(100) NOT NULL,
  `customer_address` varchar(500) NOT NULL,
  `customer_mobile` varchar(10) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_by` varchar(150) NOT NULL,
  `updated_date` datetime DEFAULT CURRENT_TIMESTAMP,
  `updated_by` varchar(150) NOT NULL,
  `is_active` int NOT NULL DEFAULT '1',
  `client_id` bigint NOT NULL,
  PRIMARY KEY (`customer_id`),
  UNIQUE KEY `uq__tbl_cust__0161999d7c4f7684` (`customer_mobile`),
  KEY `idx_tbl_cust_is_active` (`is_active`),
  KEY `fk_customers_clientid_idx` (`client_id`),
  KEY `fk_customers_createdby_idx` (`created_by`),
  KEY `fk_customers_updatedby_idx` (`updated_by`),
  CONSTRAINT `fk_customers_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_customers_createdby` FOREIGN KEY (`created_by`) REFERENCES `tbl_users` (`emp_user_id`),
  CONSTRAINT `fk_customers_updatedby` FOREIGN KEY (`updated_by`) REFERENCES `tbl_users` (`emp_user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_customers`
--

LOCK TABLES `tbl_customers` WRITE;
/*!40000 ALTER TABLE `tbl_customers` DISABLE KEYS */;
INSERT INTO `tbl_customers` VALUES (1,'ravi','nellore','9959963575','2022-03-18 15:35:19','ravi','2022-03-18 15:35:19','ravi',1,1),(2,'ravi','nellore','9494855767','2022-06-25 10:42:12','ravi','2022-06-25 10:42:12','ravi',1,1),(3,'test','test','9999999999','2022-06-25 11:38:04','ravi','2022-06-25 11:38:04','ravi',1,1);
/*!40000 ALTER TABLE `tbl_customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_devices`
--

DROP TABLE IF EXISTS `tbl_devices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_devices` (
  `device_id` varchar(50) NOT NULL,
  `device_name` varchar(50) NOT NULL,
  `client_id` bigint NOT NULL,
  PRIMARY KEY (`device_id`),
  KEY `fk_devices_clientid_idx` (`client_id`),
  CONSTRAINT `fk_devices_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_devices`
--

LOCK TABLES `tbl_devices` WRITE;
/*!40000 ALTER TABLE `tbl_devices` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_devices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_gst`
--

DROP TABLE IF EXISTS `tbl_gst`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_gst` (
  `gst_id` bigint NOT NULL AUTO_INCREMENT,
  `client_id` bigint NOT NULL,
  `gst_name` varchar(30) NOT NULL,
  `cgst_in_per` decimal(4,2) NOT NULL,
  `sgst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `igst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `is_active` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`gst_id`),
  UNIQUE KEY `idx_clientid_gsname` (`client_id`,`gst_name`),
  UNIQUE KEY `uq_clientid_gst` (`client_id`,`cgst_in_per`,`sgst_in_per`,`igst_in_per`),
  KEY `fk_gst_clientid` (`client_id`),
  CONSTRAINT `fk_gst_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_gst`
--

LOCK TABLES `tbl_gst` WRITE;
/*!40000 ALTER TABLE `tbl_gst` DISABLE KEYS */;
INSERT INTO `tbl_gst` VALUES (1,1,'GST 20%',10.00,10.00,20.00,1),(2,1,'GST 10%',5.00,5.00,10.00,1),(8,1,'erterwt',2.00,2.00,4.00,0),(11,1,'dsfsa',3.00,3.00,4.00,0),(12,1,'GST 3.00%',1.00,2.00,3.00,1),(14,1,'GST 5%',2.50,2.50,5.00,1);
/*!40000 ALTER TABLE `tbl_gst` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_item_price_tracking`
--

DROP TABLE IF EXISTS `tbl_item_price_tracking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_item_price_tracking` (
  `client_id` bigint NOT NULL,
  `item_id` bigint NOT NULL,
  `old_price` double NOT NULL,
  `new_price` double NOT NULL,
  `updated_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_by` varchar(150) NOT NULL,
  KEY `fk_item_track_clientid_idx` (`client_id`),
  KEY `fk_item_track_itemid_idx` (`item_id`),
  KEY `fk_item_track_updaetdby_idx` (`updated_by`),
  CONSTRAINT `fk_item_track_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_item_track_itemid` FOREIGN KEY (`item_id`) REFERENCES `tbl_items` (`item_id`),
  CONSTRAINT `fk_item_track_updaetdby` FOREIGN KEY (`updated_by`) REFERENCES `tbl_users` (`emp_user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_item_price_tracking`
--

LOCK TABLES `tbl_item_price_tracking` WRITE;
/*!40000 ALTER TABLE `tbl_item_price_tracking` DISABLE KEYS */;
INSERT INTO `tbl_item_price_tracking` VALUES (1,108,10,8.74,'2021-12-15 07:34:26','ravi'),(1,112,10,14.56,'2021-12-15 07:34:34','ravi');
/*!40000 ALTER TABLE `tbl_item_price_tracking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_items`
--

DROP TABLE IF EXISTS `tbl_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_items` (
  `item_id` bigint NOT NULL AUTO_INCREMENT,
  `client_id` bigint NOT NULL,
  `item_name` varchar(50) NOT NULL,
  `item_alias_name` varchar(250) DEFAULT NULL,
  `item_barcode` varchar(30) NOT NULL,
  `item_mrp_price` decimal(19,2) NOT NULL,
  `item_sales_price` decimal(19,2) NOT NULL,
  `item_purchase_price` decimal(19,2) NOT NULL,
  `opening_balance` bigint NOT NULL DEFAULT '0',
  `current_balance` bigint NOT NULL DEFAULT '0',
  `item_discount_type` varchar(2) DEFAULT NULL,
  `item_discount_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `item_discount_expiry_date` date DEFAULT NULL,
  `is_active` int NOT NULL DEFAULT '1',
  `created_by` varchar(50) NOT NULL,
  `created_date` datetime(3) NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
  `updated_by` varchar(50) DEFAULT NULL,
  `updated_date` datetime(3) DEFAULT CURRENT_TIMESTAMP(3),
  `gst_id` bigint DEFAULT NULL,
  `hsn_code` varchar(30) DEFAULT NULL,
  `item_name_telugu` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `without_gst_quantity` bigint NOT NULL DEFAULT '0',
  `without_gst_quantity_balance` bigint NOT NULL DEFAULT '0',
  `change_pur_rate_after_qty` bigint NOT NULL DEFAULT '0',
  PRIMARY KEY (`item_id`),
  UNIQUE KEY `uq_item_itemname_price` (`client_id`,`item_name`,`item_barcode`,`item_sales_price`),
  KEY `idx_item_barcode_active` (`item_barcode`,`is_active`),
  KEY `idx_tbl_item_is_active` (`is_active`),
  KEY `fk_item_clientid_idx` (`client_id`),
  KEY `fk_items_createdby_idx` (`created_by`),
  KEY `fk_item_gst_idx` (`gst_id`),
  KEY `idx_tbl_item_is_active_gst_per` (`is_active`),
  KEY `idx_local_language_update` (`client_id`,`is_active`,`item_name_telugu`),
  KEY `idx_local_language_update_2` (`client_id`,`is_active`,`item_barcode`,`item_name`,`item_alias_name`),
  CONSTRAINT `fk_item_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_item_gst` FOREIGN KEY (`gst_id`) REFERENCES `tbl_gst` (`gst_id`),
  CONSTRAINT `fk_items_createdby` FOREIGN KEY (`created_by`) REFERENCES `tbl_users` (`emp_user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=708 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_items`
--

LOCK TABLES `tbl_items` WRITE;
/*!40000 ALTER TABLE `tbl_items` DISABLE KEYS */;
INSERT INTO `tbl_items` VALUES (2,1,'werwer','werwe','weerwr',333.00,333.00,333.00,200,200,'%',10.00,'2021-07-28',1,'ravi','2021-07-27 19:43:27.172',NULL,'2021-07-27 19:43:27.172',2,'3432423','dsfsfs',0,0,0),(3,1,'werewrw','sdfsfsd','rewrew',534.00,43534.00,435345.00,0,0,'',0.00,NULL,1,'ravi','2021-07-27 20:30:35.041',NULL,'2021-07-27 20:30:35.041',NULL,'','ఒక్కసారి కూడా',0,0,0),(6,1,'All Purpose Flour 250g','Maida Pindi','10001',12.00,10.00,8.00,100,93,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:16.798',NULL,'2021-07-29 19:50:16.798',12,'','మైదా పిండి 250g',0,0,0),(7,1,'All Purpose Flour 500g','Maida Pindi','10002',12.00,10.00,8.00,100,60,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:22.147',NULL,'2021-07-29 19:50:22.147',12,'','మైదా పిండి 500g',0,0,0),(8,1,'All Purpose Flour 1kg','Maida Pindi','377',12.00,10.00,8.00,100,453,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:22.314',NULL,'2021-07-29 19:50:22.314',12,'','',0,0,0),(9,1,'Wheat Flour 250g','Godhuma Pindi','377',12.00,10.00,8.00,100,70,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:22.536',NULL,'2021-07-29 19:50:22.536',12,'','గోధుమ పిండి 250g',0,0,0),(10,1,'Wheat Flour 500g','Godhuma Pindi','377',12.00,10.00,8.00,100,74,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:22.637',NULL,'2021-07-29 19:50:22.637',12,'','గోధుమ పిండి 500g',0,0,0),(11,1,'Wheat Flour 1kg','Godhuma Pindi','10006',12.00,10.00,8.00,100,92,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:23.425',NULL,'2021-07-29 19:50:23.425',12,'','గోధుమ పిండి 1kg',0,0,0),(12,1,'Besan Flour 250g','Sanaga Pindi,Gram Flour','10007',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:23.720',NULL,'2021-07-29 19:50:23.720',12,'','',0,0,0),(13,1,'Besan Flour 500g','Sanaga Pindi,Gram Flour','10008',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:23.942',NULL,'2021-07-29 19:50:23.942',12,'','శనగ పిండి 500g',0,0,0),(14,1,'Besan Flour 1kg','Sanaga Pindi,Gram Flour','10009',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:24.064',NULL,'2021-07-29 19:50:24.064',12,'','శనగ పిండి 1kg',0,0,0),(15,1,'Corn Flour  250g','Mokkajonna Pindi','10010',12.00,10.00,8.00,100,87,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:24.155',NULL,'2021-07-29 19:50:24.155',12,'','మొక్కజొన్న పిండి 250g',0,0,0),(16,1,'Corn Flour 500g','Mokkajonna Pindi','10011',12.00,10.00,8.00,100,83,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:24.320',NULL,'2021-07-29 19:50:24.320',12,'','మొక్కజొన్న పిండి 500g',0,0,0),(17,1,'Corn Flour  1kg','Mokkajonna Pindi','10012',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:24.409',NULL,'2021-07-29 19:50:24.409',12,'','మొక్కజొన్న పిండి 1kg',0,0,0),(18,1,'Finger Millet flour 250g','Ragi Flour ','10013',12.00,40.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:24.520',NULL,'2021-07-29 19:50:24.520',12,'','రాగి పిండి 250g',0,0,0),(19,1,'Finger Millet flour 500g','Ragi Flour ','10014',12.00,10.00,8.00,100,91,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:24.631',NULL,'2021-07-29 19:50:24.631',12,'','రాగి పిండి 500g',0,0,0),(20,1,'Finger Millet flour 1kg','Ragi Flour ','10015',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:24.874',NULL,'2021-07-29 19:50:24.874',12,'','రాగి పిండి 1kg',0,0,0),(21,1,'Rice Flour 250g','Biyappindi','10016',12.00,10.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:25.096',NULL,'2021-07-29 19:50:25.096',12,'','బియ్యం పిండి 250g',0,0,0),(22,1,'Rice Flour 500g','Biyappindi','10017',12.00,10.00,8.00,100,95,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:25.239',NULL,'2021-07-29 19:50:25.239',12,'','బియ్యం పిండి 500g',0,0,0),(23,1,'Rice Flour 1kg','Biyappindi','10018',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:25.295',NULL,'2021-07-29 19:50:25.295',12,'','బియ్యం పిండి 1kg',0,0,0),(24,1,'Jowar Flour 250g','Jonna Pindi','10019',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:25.395',NULL,'2021-07-29 19:50:25.395',12,'','జొన్నలు పిండి 250g',0,0,0),(25,1,'Jowar Flour 500g','Jonna Pindi','10020',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:25.552',NULL,'2021-07-29 19:50:25.552',12,'','జొన్నలు పిండి 500g',0,0,0),(26,1,'Jowar Flour 1kg','Jonna Pindi','10021',12.00,10.00,8.00,100,85,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:25.677',NULL,'2021-07-29 19:50:25.677',12,'','జొన్నలు పిండి 1kg',0,0,0),(27,1,'Coconut Flour','Kobbari Pindi','10022',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:25.819',NULL,'2021-07-29 19:50:25.819',12,'','కొబ్బరి పిండి',0,0,0),(28,1,'Bengal Gram 250g','Senaga Pappu','10023',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:25.972',NULL,'2021-07-29 19:50:25.972',12,'','శనగ పప్పు 250g',0,0,0),(29,1,'Bengal Gram 500g','Senaga Pappu','10024',12.00,10.00,8.00,100,95,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:26.094',NULL,'2021-07-29 19:50:26.094',12,'','శనగ పప్పు 500g',0,0,0),(30,1,'Bengal Gram 1kg','Senaga Pappu','10025',12.00,10.00,8.00,100,95,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:26.318',NULL,'2021-07-29 19:50:26.318',12,'','శనగ పప్పు 1kg',0,0,0),(31,1,'Green Gram 250g','Pesara pappu','10026',12.00,90.00,8.00,100,80,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:26.594',NULL,'2021-07-29 19:50:26.594',12,'','పెసర పప్పు 250g',0,0,0),(32,1,'Green Gram 500g','Pesara pappu','10027',12.00,10.00,8.00,100,57,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:26.794',NULL,'2021-07-29 19:50:26.794',12,'','పెసర పప్పు 500g',0,0,0),(33,1,'Green Gram 1kg','Pesara pappu','10028',12.00,10.00,8.00,100,66,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:27.105',NULL,'2021-07-29 19:50:27.105',12,'','పెసర పప్పు 1kg',0,0,0),(34,1,'Red Gram 250g','Kandhi pappu','10029',12.00,606.00,8.00,100,49,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:27.185',NULL,'2021-07-29 19:50:27.185',12,'','కంది పప్పు 250g',0,0,0),(35,1,'Red Gram 500g','Kandhi pappu','10030',12.00,10.00,8.00,100,45,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:27.352',NULL,'2021-07-29 19:50:27.352',12,'','కంది పప్పు 500g',0,0,0),(36,1,'Red Gram 1kg','Kandhi pappu','10031',12.00,236147.00,8.00,100,34,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:27.451',NULL,'2021-07-29 19:50:27.451',12,'','కంది పప్పు 1kg',0,0,0),(37,1,'Black Gram 250g','Minappappu','10032',12.00,10.00,8.00,100,88,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:27.549',NULL,'2021-07-29 19:50:27.549',12,'','మినపప్పు 250g',0,0,0),(38,1,'Black Gram 500g','Minappappu','10033',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:28.001',NULL,'2021-07-29 19:50:28.001',12,'','మినపప్పు 500g',0,0,0),(39,1,'Black Gram 1kg','Minappappu','10034',12.00,10.00,8.00,100,86,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:28.070',NULL,'2021-07-29 19:50:28.070',12,'','మినపప్పు 1kg',0,0,0),(40,1,'Poppy Seeds 50g','Gasalu,Gasagasaalu','10035',12.00,10.00,8.00,100,78,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:28.191',NULL,'2021-07-29 19:50:28.191',12,'','గసగసాలు 50g',0,0,0),(41,1,'Poppy Seeds 100g','Gasalu,Gasagasaalu','10036',12.00,10.00,8.00,100,88,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:28.313',NULL,'2021-07-29 19:50:28.313',12,'','గసగసాలు 100g',0,0,0),(42,1,'Poppy Seeds 250g','Gasalu,Gasagasaalu','10037',12.00,10.00,8.00,100,83,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:28.409',NULL,'2021-07-29 19:50:28.409',12,'','గసగసాలు 250g',0,0,0),(43,1,'Coriander Seeds 50g','Dhaniyalu','10038',12.00,10.00,8.00,100,91,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:28.499',NULL,'2021-07-29 19:50:28.499',12,'','ధనియాలు 50g',0,0,0),(44,1,'Coriander Seeds 100g','Dhaniyalu','10039',12.00,10.00,8.00,100,86,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:28.587',NULL,'2021-07-29 19:50:28.587',12,'','ధనియాలు 100g',0,0,0),(45,1,'Coriander Seeds 250g','Dhaniyalu','10040',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:28.961',NULL,'2021-07-29 19:50:28.961',12,'','ధనియాలు 250g',0,0,0),(46,1,'Coriander Seeds 500g','Dhaniyalu','10041',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:29.098',NULL,'2021-07-29 19:50:29.098',12,'','ధనియాలు 500g',0,0,0),(47,1,'Mustard Seeds 50g','Avalu','10042',12.00,3470.00,8.00,100,81,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:29.198',NULL,'2021-07-29 19:50:29.198',12,'','ఆవాలు 50g',0,0,0),(48,1,'Mustard Seeds 100g','Avalu','10043',12.00,10.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:29.352',NULL,'2021-07-29 19:50:29.352',12,'','ఆవాలు 100g',0,0,0),(49,1,'Mustard Seeds 250g','Avalu','10044',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:29.421',NULL,'2021-07-29 19:50:29.421',12,'','ఆవాలు 250g',0,0,0),(50,1,'Mustard Seeds 500g','Avalu','10045',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:29.518',NULL,'2021-07-29 19:50:29.518',12,'','ఆవాలు 500g',0,0,0),(51,1,'Cumin Seeds 50g','Jeelakarra,Jilakara','10046',12.00,10.00,8.00,100,95,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:29.607',NULL,'2021-07-29 19:50:29.607',12,'','జీలకర్ర 50g',0,0,0),(52,1,'Cumin Seeds 100g','Jeelakarra,Jilakara','10047',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:29.917',NULL,'2021-07-29 19:50:29.917',12,'','జీలకర్ర 100g',0,0,0),(53,1,'Cumin Seeds 250g','Jeelakarra,Jilakara','10048',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.017',NULL,'2021-07-29 19:50:30.017',12,'','జీలకర్ర 250g',0,0,0),(54,1,'Cumin Seeds 500g','Jeelakarra,Jilakara','10049',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.131',NULL,'2021-07-29 19:50:30.131',12,'','జీలకర్ర 500g',0,0,0),(55,1,'Urad dal 250g','Minapappu,Uddipappu','10050',12.00,10.00,8.00,100,89,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.208',NULL,'2021-07-29 19:50:30.208',12,'','మినప పప్పు 250g',0,0,0),(56,1,'Urad dal 500g','Minapappu,Uddipappu','10051',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.287',NULL,'2021-07-29 19:50:30.287',12,'','మినప పప్పు 500g',0,0,0),(57,1,'Urad dal 1kg','Minapappu,Uddipappu','10052',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.364',NULL,'2021-07-29 19:50:30.364',12,'','మినప పప్పు 1kg',0,0,0),(58,1,'Ground Nuts 250g','Verusanagapappu,Pallilu','10053',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.441',NULL,'2021-07-29 19:50:30.441',12,'','వేరుశనగపప్పు 250g',0,0,0),(59,1,'Ground Nuts 500g','Verusanagapappu,Pallilu','10054',12.00,10.00,8.00,100,91,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.550',NULL,'2021-07-29 19:50:30.550',12,'','వేరుశనగపప్పు 500g',0,0,0),(60,1,'Ground Nuts 1kg','Verusanagapappu,Pallilu','10055',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.631',NULL,'2021-07-29 19:50:30.631',12,'','వేరుశనగపప్పు 1kg',0,0,0),(61,1,'Turmeric','Pasupu','10056',12.00,10.00,8.00,100,83,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.749',NULL,'2021-07-29 19:50:30.749',12,'','పసుపు',0,0,0),(62,1,'Ajowan','Vamu','10057',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:30.805',NULL,'2021-07-29 19:50:30.805',12,'','వాము',0,0,0),(63,1,'Fenugreek Seeds','Menthulu','10058',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:31.022',NULL,'2021-07-29 19:50:31.022',12,'','మెంతులు',0,0,0),(64,1,'Sago','Saggubiyyam','10059',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:31.129',NULL,'2021-07-29 19:50:31.129',12,'','సగ్గుబియ్యం',0,0,0),(65,1,'Flattend Rice or Rice Flakes','Atukulu','10060',12.00,10.00,8.00,100,77,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:31.216',NULL,'2021-07-29 19:50:31.216',12,'','అటుకులు',0,0,0),(66,1,'Horse Gram','Ulavalu','10061',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:31.327',NULL,'2021-07-29 19:50:31.327',12,'','ఉలవలు',0,0,0),(67,1,'Millet','Jonnalu','10062',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:31.458',NULL,'2021-07-29 19:50:31.458',12,'','జొన్నలు',0,0,0),(68,1,'Maize','Mokka Jonna','10063',12.00,10.00,8.00,100,90,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:31.524',NULL,'2021-07-29 19:50:31.524',12,'','మొక్కజొన్న',0,0,0),(69,1,'Salt','Uppu','10064',12.00,10.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:31.613',NULL,'2021-07-29 19:50:31.613',12,'','ఉప్పు',0,0,0),(70,1,'Onion','Ullipayalu,Yerra gaddalu','10065',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:31.968',NULL,'2021-07-29 19:50:31.968',12,'','ఉల్లిపాయ',0,0,0),(71,1,'Garlic','Velluli payulu,Tellapaayalu','10066',12.00,10.00,8.00,100,93,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:32.151',NULL,'2021-07-29 19:50:32.151',12,'','వెల్లుల్లి',0,0,0),(72,1,'Red Chilli','Yendu mirapa kaaya,Endu Mirapakayalu','10067',12.00,89.00,8.00,100,15,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:32.279',NULL,'2021-07-29 19:50:32.279',12,'','మిరపకాయ',0,0,0),(73,1,'Aniseed','Sopu','10068',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:32.401',NULL,'2021-07-29 19:50:32.401',12,'','సొంపు',0,0,0),(74,1,'Asafoetida','Inguva','10069',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:32.472',NULL,'2021-07-29 19:50:32.472',12,'','ఇంగువ',0,0,0),(75,1,'Bay Leaf','Masala Aku,Biryani aaku','10070',12.00,10.00,8.00,100,95,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:32.712',NULL,'2021-07-29 19:50:32.712',12,'','బిర్యాని ఆకు',0,0,0),(76,1,'Black Pepper','Miriyalu','10071',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:32.945',NULL,'2021-07-29 19:50:32.945',12,'','మిరియాలు',0,0,0),(77,1,'Cardamom','Elakulu','10072',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:33.082',NULL,'2021-07-29 19:50:33.082',12,'','ఏలకుల',0,0,0),(78,1,'Cinnamon','Dalchina chekka,Dalchini,Dasina Chekka,Chekka','10073',12.00,10.00,8.00,100,80,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:33.162',NULL,'2021-07-29 19:50:33.162',12,'','దాల్చిన',0,0,0),(79,1,'Cloves','Lavangalu','10074',12.00,10.00,8.00,100,93,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:33.404',NULL,'2021-07-29 19:50:33.404',12,'','లవంగాలు',0,0,0),(80,1,'Saffron','Kumkum Puvvu','10075',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:33.482',NULL,'2021-07-29 19:50:33.482',12,'','కుంకుమ పుష్పం',0,0,0),(81,1,'Fennel','Peddajeelakarra,Sopu','10076',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:33.565',NULL,'2021-07-29 19:50:33.565',12,'','సోపు',0,0,0),(82,1,'Turmeric Powder','Pasupu','10077',12.00,10.00,8.00,100,93,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:33.739',NULL,'2021-07-29 19:50:33.739',12,'','పసుపు పొడి',0,0,0),(83,1,'Cashewnuts','Jeedi pappu','10078',12.00,10.00,8.00,100,70,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:34.084',NULL,'2021-07-29 19:50:34.084',12,'','జీడిపప్పు',0,0,0),(84,1,'Raisins','Yendu dhraksha','10079',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:34.499',NULL,'2021-07-29 19:50:34.499',12,'','ఎండుద్రాక్ష',0,0,0),(85,1,'Almond','Badham','10080',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:34.700',NULL,'2021-07-29 19:50:34.700',12,'','బాదం',0,0,0),(86,1,'Apricot','Seema Badham','10081',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:34.972',NULL,'2021-07-29 19:50:34.972',12,'','సీమ బాదం',0,0,0),(87,1,'Beetal Nut','Vakkalu','10082',12.00,10.00,8.00,100,91,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:35.104',NULL,'2021-07-29 19:50:35.104',12,'','వక్కలు',0,0,0),(88,1,'Dessicated Coconut','Kobbari','10083',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:35.353',NULL,'2021-07-29 19:50:35.353',12,'','కొబ్బరి',0,0,0),(89,1,'Dried Dates','Kharjooram','10084',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:35.813',NULL,'2021-07-29 19:50:35.813',12,'','ఖర్జూరం',0,0,0),(90,1,'Dried Fig','Athi Pallu','10085',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:36.018',NULL,'2021-07-29 19:50:36.018',12,'','అతి పళ్ళూ',0,0,0),(91,1,'Walnut','Aakrot','10086',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:36.095',NULL,'2021-07-29 19:50:36.095',12,'','అక్రోటుకాయ',0,0,0),(92,1,'Pistachio','Pista','10087',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:36.173',NULL,'2021-07-29 19:50:36.173',12,'','పిస్తా',0,0,0),(93,1,'Poppy Seed','Gasagasaalu','10088',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:36.251',NULL,'2021-07-29 19:50:36.251',12,'','గసగసాల',0,0,0),(94,1,'Peanut','Pallilu','10089',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:36.357',NULL,'2021-07-29 19:50:36.357',12,'','శనగ',0,0,0),(95,1,'Yogurt','Perugu','10090',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:36.456',NULL,'2021-07-29 19:50:36.456',12,'','పెరుగు',0,0,0),(96,1,'Rice (Raw)','Biyyamu','10091',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:36.803',NULL,'2021-07-29 19:50:36.803',12,'','బియ్యం',0,0,0),(97,1,'Rice (Boiled)','Uppudu Biyyamu','10092',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:36.967',NULL,'2021-07-29 19:50:36.967',12,'','ఉప్పుడుబియ్యం',0,0,0),(98,1,'Semolina','Bombai rawa','10093',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:37.105',NULL,'2021-07-29 19:50:37.105',12,'','బొంబాయి రవ్వ',0,0,0),(99,1,'Vermicelli','Semia','10094',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:37.182',NULL,'2021-07-29 19:50:37.182',12,'','సేమియా',0,0,0),(100,1,'Jaggery','Bellamu','10095',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:37.293',NULL,'2021-07-29 19:50:37.293',12,'','బెల్లం ',0,0,0),(101,1,'Honey','Tene','10096',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:37.372',NULL,'2021-07-29 19:50:37.372',12,'','తేనె',0,0,0),(102,1,'Coconut','Kobbari kaya','10097',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:37.477',NULL,'2021-07-29 19:50:37.477',12,'','కొబ్బరి కాయ',0,0,0),(103,1,'Sugar','Chakkera','10098',12.00,10.00,8.00,100,71,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:37.549',NULL,'2021-07-29 19:50:37.549',12,'','చక్కెర',0,0,0),(104,1,'Baking soda','Sodauppu','10099',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:37.766',NULL,'2021-07-29 19:50:37.766',12,'','baking soda',0,0,0),(105,1,'Tamarind','Chinthapandu ','10100',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:38.043',NULL,'2021-07-29 19:50:38.043',12,'','చింతపండు',0,0,0),(107,1,'3Roses 100g','3Roses','10102',18.00,14.56,8.00,100,199,'Rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:38.292','ravi','2021-12-15 06:53:34.000',12,'','3రొసెస్ 100g',0,0,0),(108,1,'3Roses 250g','3Roses','10103',12.00,8.74,8.00,100,99,'Rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:38.398','ravi','2021-12-15 07:34:26.000',12,'','3రొసెస్ 250g',0,0,0),(109,1,'3Roses H pack 500g','3Roses H pack','10104',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:38.473',NULL,'2021-07-29 19:50:38.473',12,'','3రొసెస్ H ప్యాక్ 500g',0,0,0),(110,1,'3Roses Natural','3Roses Natural','10105',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:38.582',NULL,'2021-07-29 19:50:38.582',12,'','3రొసెస్ Roses నాచురల్',0,0,0),(112,1,'50 50 Biscuit','50 50 Biscuit','10107',12.00,14.56,8.00,100,95,'Rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:39.205','ravi','2021-12-15 07:34:34.000',12,'','50 50 బిస్కెట్ ',0,0,0),(113,1,'Aachi Chicken Masala','Aachi Chicken Masala','10108',12.00,10.00,8.00,100,65,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:39.406',NULL,'2021-07-29 19:50:39.406',12,'','ఆచి చికెన్ మసాల',0,0,0),(114,1,'Aachi Gulabjam','Aachi Gulabjam','10109',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:39.477',NULL,'2021-07-29 19:50:39.477',12,'','ఆచి గులబ్జాం',0,0,0),(115,1,'Aashirvaad Multigrains 500g','Aashirvaad Multigrains','10110',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:39.577',NULL,'2021-07-29 19:50:39.577',12,'','ఆశిర్వాద్ ముల్తిగ్రైన్స్ 500g',0,0,0),(116,1,'Aashirvaad Multigrains 1kg','Aashirvaad Multigrains','10111',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:39.838',NULL,'2021-07-29 19:50:39.838',12,'','ఆశిర్వాద్ ముల్తిగ్రైన్స్ 1kg',0,0,0),(117,1,'Aashirvaad Multigrains 5kg','Aashirvaad Multigrains','10112',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:39.905',NULL,'2021-07-29 19:50:39.905',12,'','ఆశిర్వాద్ ముల్తిగ్రైన్స్ 5kg',0,0,0),(118,1,'Aashirvaad Multigrains 10kg','Aashirvaad Multigrains','10113',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:40.000',NULL,'2021-07-29 19:50:40.000',12,'','ఆశిర్వాద్ ముల్తిగ్రైన్స్ 10kg',0,0,0),(119,1,'Aashirvaad Coriander 50g','Aashirvaad Coriander','10114',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:40.076',NULL,'2021-07-29 19:50:40.076',12,'','ఆశిర్వాద్ కోరిందర్ 50g',0,0,0),(120,1,'Aashirvaad Coriander 100g','Aashirvaad Coriander','10115',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:40.360',NULL,'2021-07-29 19:50:40.360',12,'','ఆశిర్వాద్ కోరిందర్ 100g',0,0,0),(121,1,'Aashirvaad Coriander 500g','Aashirvaad Coriander','10116',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:40.417',NULL,'2021-07-29 19:50:40.417',12,'','ఆశిర్వాద్ కోరిందర్ 500g',0,0,0),(122,1,'Aashirvaad Coriander 1kg','Aashirvaad Coriander','10117',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:40.509',NULL,'2021-07-29 19:50:40.509',12,'','ఆశిర్వాద్ కోరిందర్ 1kg',0,0,0),(123,1,'Aashirvad Atta  500g','Aashirvad Atta','10118',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:40.587',NULL,'2021-07-29 19:50:40.587',12,'','ఆశిర్వాద్ అట 500g',0,0,0),(124,1,'Aashirvad Atta  1kg','Aashirvad Atta','10119',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:41.005',NULL,'2021-07-29 19:50:41.005',12,'','ఆశిర్వాద్ అట 1kg',0,0,0),(125,1,'Aashirvad Atta  5kg','Aashirvad Atta','10120',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:41.502',NULL,'2021-07-29 19:50:41.502',12,'','ఆశిర్వాద్ అట 5kg',0,0,0),(126,1,'Aashirvad Atta  10kg','Aashirvad Atta','10121',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:41.569',NULL,'2021-07-29 19:50:41.569',12,'','ఆశిర్వాద్ అట 10kg',0,0,0),(127,1,'Aashirvad Chilli 50g','Aashirvad Chilli','10122',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:41.625',NULL,'2021-07-29 19:50:41.625',12,'','ఆశిర్వాద్ చిల్లి 50g',0,0,0),(128,1,'Aashirvad Chilli 100g','Aashirvad Chilli','10123',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:41.858',NULL,'2021-07-29 19:50:41.858',12,'','ఆశిర్వాద్ చిల్లి 100g',0,0,0),(129,1,'Aashirvad Chilli 200g','Aashirvad Chilli','10124',12.00,10.00,8.00,100,149,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:42.018',NULL,'2021-07-29 19:50:42.018',12,'','ఆశిర్వాద్ చిల్లి 200g',0,0,0),(130,1,'Aashirvad Chilli 500g','Aashirvad Chilli','10125',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:42.118',NULL,'2021-07-29 19:50:42.118',12,'','ఆశిర్వాద్ చిల్లి 500g',0,0,0),(131,1,'Aashirvad Turmeric 50g','Aashirvad Turmeric','10126',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:42.219',NULL,'2021-07-29 19:50:42.219',12,'','ఆశిర్వాద్ టర్మేరిక్ 50g',0,0,0),(132,1,'Aashirvad Turmeric 100g','Aashirvad Turmeric','10127',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:42.357',NULL,'2021-07-29 19:50:42.357',12,'','ఆశిర్వాద్ టర్మేరిక్ 100g',0,0,0),(133,1,'Aashirvad Turmeric 200g','Aashirvad Turmeric','10128',12.00,10.00,8.00,100,149,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:42.654',NULL,'2021-07-29 19:50:42.654',12,'','ఆశిర్వాద్ టర్మేరిక్ 200g',0,0,0),(134,1,'Aashirvad Turmeric 500g','Aashirvad Turmeric','10129',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:42.856',NULL,'2021-07-29 19:50:42.856',12,'','ఆశిర్వాద్ టర్మేరిక్ 500g',0,0,0),(135,1,'Ajay Brush','Ajay Brush','10130',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:42.961',NULL,'2021-07-29 19:50:42.961',12,'','అజయ్ బ్రష్',0,0,0),(136,1,'Ajinomoto 50g','Ajinomoto','10131',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:43.067',NULL,'2021-07-29 19:50:43.067',12,'','అజినోమోటో 50g',0,0,0),(137,1,'Alasandalu Red 50g','Alasandalu Red','10132',12.00,10.00,8.00,100,87,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:43.172',NULL,'2021-07-29 19:50:43.172',12,'','అలసందులు రెడ్ 50g',0,0,0),(138,1,'Alasandalu Red 100g','Alasandalu Red','10133',12.00,10.00,8.00,100,85,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:43.311',NULL,'2021-07-29 19:50:43.311',12,'','అలసందులు రెడ్ 100g',0,0,0),(139,1,'Alasandalu White 50g','Alasandalu White','10134',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:43.368',NULL,'2021-07-29 19:50:43.368',12,'','అలసందులు వైట్ 50g',0,0,0),(140,1,'Alasandalu White 100g','Alasandalu White','10135',12.00,10.00,8.00,100,200,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:43.544',NULL,'2021-07-29 19:50:43.544',12,'','అలసందులు వైట్ 100g',0,0,0),(141,1,'Allout','Allout','10136',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:43.638',NULL,'2021-07-29 19:50:43.638',12,'','ఆల్ అవుట్',0,0,0),(142,1,'Ambika Athisayam','Ambika Athisayam','10137',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:43.921',NULL,'2021-07-29 19:50:43.921',12,'','అంబిక అతిశయం',0,0,0),(143,1,'Ambika Darbar','Ambika Darbar','10138',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:43.993',NULL,'2021-07-29 19:50:43.993',12,'','అంబిక దర్బార్',0,0,0),(144,1,'Ambika Sticks','Ambika Sticks','10139',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:44.102',NULL,'2021-07-29 19:50:44.102',12,'','అంబిక స్టిక్స్',0,0,0),(145,1,'Amrutanjan','Amrutanjan','10140',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:44.272',NULL,'2021-07-29 19:50:44.272',12,'','అమృతాంజన్',0,0,0),(146,1,'Anasapuvvu 30g','Anasapuvvu','10141',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:44.400',NULL,'2021-07-29 19:50:44.400',12,'','అనసపువ్వు 30g',0,0,0),(147,1,'Anchor Gel Paste','Anchor Gel Paste','10142',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:44.516',NULL,'2021-07-29 19:50:44.516',12,'','ఆంకర్ జెల్ పేస్ట్',0,0,0),(148,1,'Ariel 250g','Ariel','10143',12.00,10.00,8.00,100,93,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:44.790',NULL,'2021-07-29 19:50:44.790',12,'','ఎరిఎల్ 250g',0,0,0),(149,1,'Ariel 500g','Ariel','10144',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:45.107',NULL,'2021-07-29 19:50:45.107',12,'','ఎరిఎల్ 500g',0,0,0),(150,1,'Ariel 1kg','Ariel 1kg','10145',12.00,10.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:45.283',NULL,'2021-07-29 19:50:45.283',12,'','ఎరిఎల్ 1kg',0,0,0),(151,1,'AS Brand Oil 500ml','AS Brand Oil 500ml','10146',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:45.597',NULL,'2021-07-29 19:50:45.597',12,'','AS బ్రాండ్ ఆయిల్ 500ml',0,0,0),(152,1,'AS Brand Oil 1Ltr','AS Brand Oil 1Ltr','10147',12.00,10.00,8.00,100,92,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:45.907',NULL,'2021-07-29 19:50:45.907',12,'','AS బ్రాండ్ ఆయిల్ 1Ltr',0,0,0),(154,1,'AXE After Shave','AXE After Shave','10149',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:46.485',NULL,'2021-07-29 19:50:46.485',12,'','AXE ఆఫ్టర్ షేవింగ్',0,0,0),(155,1,'Ayush Soap','Ayush Soap','10150',12.00,10.00,8.00,100,93,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:47.077',NULL,'2021-07-29 19:50:47.077',12,'','ఆయుష్ సోప్',0,0,0),(156,1,'Babool Paste','Babool Paste','10151',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:47.348',NULL,'2021-07-29 19:50:47.348',12,'','బబూల్ పేస్ట్',0,0,0),(157,1,'Bambino Gulabjam','Bambino Gulabjam','10152',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:47.529',NULL,'2021-07-29 19:50:47.529',12,'','బాంబినో గులాబ్జాం',0,0,0),(158,1,'Bambino Rasam','Bambino Rasam','10153',12.00,10.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:47.789',NULL,'2021-07-29 19:50:47.789',12,'','బాంబినో రసం',0,0,0),(159,1,'Bambino Sambaar','Bambino Sambaar','10154',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:47.946',NULL,'2021-07-29 19:50:47.946',12,'','బాంబినో సాంబార్',0,0,0),(160,1,'Bambino Soap','Bambino Soap','10155',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:48.061',NULL,'2021-07-29 19:50:48.061',12,'','బాంబినో సోప్',0,0,0),(161,1,'Banjaras','Banjaras','10156',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:48.195',NULL,'2021-07-29 19:50:48.195',12,'','బంజరాస్',0,0,0),(162,1,'Banjaras Black Henna','Banjaras Black Henna','10157',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:48.300',NULL,'2021-07-29 19:50:48.300',12,'','బంజరాస్ బ్లాక్ హెన్న',0,0,0),(163,1,'Barle 250g','Barle','10158',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:48.433',NULL,'2021-07-29 19:50:48.433',12,'','బార్లె 250g',0,0,0),(164,1,'Jaggery 250g','Bellem','10159',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:48.516',NULL,'2021-07-29 19:50:48.516',12,'','బెల్లం 250g',0,0,0),(165,1,'Jaggery 500g','Bellem','10160',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:48.612',NULL,'2021-07-29 19:50:48.612',12,'','బెల్లం 500g',0,0,0),(166,1,'Jaggery 1kg','Bellem','10161',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:48.846',NULL,'2021-07-29 19:50:48.846',12,'','బెల్లం 1kg',0,0,0),(167,1,'Black Diamond Agarbathi','Black Diamond Agarbathi','10162',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:49.035',NULL,'2021-07-29 19:50:49.035',12,'','బ్లాక్ డైమండ్ అగర్బతి',0,0,0),(168,1,'Black Henna','Black Henna','10163',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:49.145',NULL,'2021-07-29 19:50:49.145',12,'','బ్లాక్ హెన్నా',0,0,0),(169,1,'Bleaching Powder 250g','Bleaching Powder','10164',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:49.251',NULL,'2021-07-29 19:50:49.251',12,'','బ్లీచింగ్ పౌడర్ 250g',0,0,0),(170,1,'Bleaching Powder 500g','Bleaching Powder','10165',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:49.334',NULL,'2021-07-29 19:50:49.334',12,'','బ్లీచింగ్ పౌడర్ 500g',0,0,0),(171,1,'Boost 200g','Boost','10166',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:49.458',NULL,'2021-07-29 19:50:49.458',12,'','బూస్ట్ 200g',0,0,0),(172,1,'Boost 500g','Boost','10167',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:49.533',NULL,'2021-07-29 19:50:49.533',12,'','బూస్ట్ 500g',0,0,0),(173,1,'Boost Jar 200g','Boost Jar','10168',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:49.661',NULL,'2021-07-29 19:50:49.661',12,'','బూస్ట్ జార్ 200g',0,0,0),(174,1,'Boost Jar 500g','Boost Jar','10169',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:49.960',NULL,'2021-07-29 19:50:49.960',12,'','బూస్ట్ జార్ 500g',0,0,0),(175,1,'Boost Bisket','Boost Bisket','10170',12.00,10.00,8.00,100,88,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:50.107',NULL,'2021-07-29 19:50:50.107',12,'','బూస్ట్ బిస్కెట్',0,0,0),(176,1,'Boroplus Powder','Boroplus Powder','10171',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:50.227',NULL,'2021-07-29 19:50:50.227',12,'','బోరోప్లుస్ పౌడర్',0,0,0),(177,1,'Borugulu 100g','Borugulu','10172',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:50.310',NULL,'2021-07-29 19:50:50.310',12,'','బొరుగులు 100g',0,0,0),(178,1,'Borugulu 250g','Borugulu','10173',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:50.609',NULL,'2021-07-29 19:50:50.609',12,'','బొరుగులు 250g',0,0,0),(179,1,'Borugulu 500g','Borugulu','10174',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:50.960',NULL,'2021-07-29 19:50:50.960',12,'','బొరుగులు 500g',0,0,0),(180,1,'Bournvita 500g','Bournvita','10175',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:51.053',NULL,'2021-07-29 19:50:51.053',12,'','బౌర్న్విట 500g',0,0,0),(181,1,'Bournvita Jar','Bournvita Jar','10176',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:51.142',NULL,'2021-07-29 19:50:51.142',12,'','బౌర్న్విట జార్',0,0,0),(182,1,'Bournvita Biskcut','Bournvita Biskcut','10177',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:51.269',NULL,'2021-07-29 19:50:51.269',12,'','బౌర్న్విట బిస్కెట్',0,0,0),(183,1,'Britania Tiger','Britania Tiger','10178',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:51.370',NULL,'2021-07-29 19:50:51.370',12,'','బ్రిటానియా టైగర్',0,0,0),(184,1,'Broom Sticks','Broom Sticks','10179',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:51.458',NULL,'2021-07-29 19:50:51.458',12,'','బ్రూమ్ స్టిక్స్',0,0,0),(185,1,'Bru Greenlable 100g','Bru Greenlable','10180',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:51.648',NULL,'2021-07-29 19:50:51.648',12,'','బ్రూ గ్రీన్ లేబుల్ 100g',0,0,0),(186,1,'Bru Greenlable 200g','Bru Greenlable','10181',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:51.903',NULL,'2021-07-29 19:50:51.903',12,'','బ్రూ గ్రీన్ లేబుల్ 200g',0,0,0),(187,1,'Bru Greenlable 300g','Bru Greenlable','10182',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:52.153',NULL,'2021-07-29 19:50:52.153',12,'','బ్రూ గ్రీన్ లేబుల్ 300g',0,0,0),(188,1,'Bru Instant','Bru Instant','10183',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:52.245',NULL,'2021-07-29 19:50:52.245',12,'','బ్రూ ఇన్స్టంట్',0,0,0),(189,1,'Bru Strong 200g','Bru Strong','10184',12.00,10.00,8.00,100,116,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:52.335',NULL,'2021-07-29 19:50:52.335',12,'','బ్రూ స్ట్రాంగ్ 200g',0,0,0),(190,1,'Brush Toilet Cleaner','Brush Toilet Cleaner','10185',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:52.435',NULL,'2021-07-29 19:50:52.435',12,'','బ్రష్ టాయిలెట్ క్లీనర్',0,0,0),(191,1,'Bryl Cream','Bryl Cream','10186',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:52.525',NULL,'2021-07-29 19:50:52.525',12,'','బ్రిల్ క్రీమ్',0,0,0),(192,1,'Buds','Buds','10187',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:52.702',NULL,'2021-07-29 19:50:52.702',12,'','బడ్స్',0,0,0),(193,1,'Candle Packet','Candle Packet','10188',12.00,10.00,8.00,100,90,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:52.920',NULL,'2021-07-29 19:50:52.920',12,'','క్యాండిల్ ప్యాకెట్',0,0,0),(194,1,'Candle','Candle','10189',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:53.112',NULL,'2021-07-29 19:50:53.112',12,'','క్యాండిల్',0,0,0),(195,1,'Carefree Regular','Carefree Regular','10190',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:53.412',NULL,'2021-07-29 19:50:53.412',12,'','కేరేఫ్రీ',0,0,0),(196,1,'Carry Bag','Carry Bag','10191',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:53.499',NULL,'2021-07-29 19:50:53.499',12,'','క్యారీ బ్యాగ్',0,0,0),(197,1,'Chakra Gold 100g','Chakra Gold','10192',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:53.611',NULL,'2021-07-29 19:50:53.611',12,'','చక్రా గోల్డ్ 100g',0,0,0),(198,1,'Chakra Gold 250g','Chakra Gold','10193',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:53.863',NULL,'2021-07-29 19:50:53.863',12,'','చక్రా గోల్డ్ 250g',0,0,0),(199,1,'Chanda Dalda 200g','Chanda Dalda','10194',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:54.042',NULL,'2021-07-29 19:50:54.042',12,'','చందా డాల్డ 200g',0,0,0),(200,1,'Chanda Dalda 500g','Chanda Dalda','10195',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:54.174',NULL,'2021-07-29 19:50:54.174',12,'','చందా డాల్డ 500g',0,0,0),(201,1,'Chanda Dalda 1kg','Chanda Dalda','10196',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:54.307',NULL,'2021-07-29 19:50:54.307',12,'','చందా డాల్డ 1kg',0,0,0),(202,1,'Charminar Biscuit','Charminar Biscuit','10197',12.00,10.00,8.00,100,85,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:54.407',NULL,'2021-07-29 19:50:54.407',12,'','చార్మినార్ బిస్కెట్',0,0,0),(203,1,'Odonil','Odonil','10198',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:54.572',NULL,'2021-07-29 19:50:54.572',12,'','ఒడోనిల్',0,0,0),(204,1,'Chennai Appalam','Chennai Appalam','10199',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:54.662',NULL,'2021-07-29 19:50:54.662',12,'','చెన్నై అప్పలం',0,0,0),(205,1,'Cherrys','Cherrys','10200',12.00,10.00,8.00,100,95,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:55.138',NULL,'2021-07-29 19:50:55.138',12,'','చేర్ర్య్స్',0,0,0),(206,1,'Cherrys Mixed','Cherrys Mixed','10201',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:55.451',NULL,'2021-07-29 19:50:55.451',12,'','చేర్ర్య్స్ మిక్స్ద్ద్',0,0,0),(207,1,'Chick Shampoo','Chick Shampoo','10202',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:55.650',NULL,'2021-07-29 19:50:55.650',12,'','చిక్ షాంపూ',0,0,0),(208,1,'Tamarind 250g','Chintapandu','10203',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:55.872',NULL,'2021-07-29 19:50:55.872',12,'','చింతపండు 250g',0,0,0),(209,1,'Tamarind 500g','Chintapandu','10204',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:56.204',NULL,'2021-07-29 19:50:56.204',12,'','చింతపండు 500g',0,0,0),(210,1,'Tamarind 1kg','Chintapandu','10205',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:56.549',NULL,'2021-07-29 19:50:56.549',12,'','చింతపండు 1kg',0,0,0),(211,1,'Chocos','Chocos','10206',12.00,10.00,8.00,100,319,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:56.839',NULL,'2021-07-29 19:50:56.839',12,'','చోకోస్',0,0,0),(212,1,'Cinthol Cool Set','Cinthol Cool Set','10207',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:56.937',NULL,'2021-07-29 19:50:56.937',12,'','సిన్తాల్ కూల్ సెట్',0,0,0),(213,1,'Cinthol Lime Set','Cinthol Lime Set','10208',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:57.040',NULL,'2021-07-29 19:50:57.040',12,'','సిన్తాల్ లైం సెట్',0,0,0),(214,1,'Cinthol Old','Cinthol Old','10209',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:57.182',NULL,'2021-07-29 19:50:57.182',12,'','సిన్తాల్ ఓల్డ్',0,0,0),(215,1,'Cinthol Powder','Cinthol Powder','10210',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:57.325',NULL,'2021-07-29 19:50:57.325',12,'','సిన్తాల్ పౌడర్',0,0,0),(216,1,'Cinthol Red Set','Cinthol Red Set','10211',12.00,10.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:57.438',NULL,'2021-07-29 19:50:57.438',12,'','సిన్తాల్ రెడ్ సెట్',0,0,0),(217,1,'Clean & Clear Facewash','Clean & Clear Facewash','10212',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:57.637',NULL,'2021-07-29 19:50:57.637',12,'','క్లీన్ & క్లియర్ పేస్ వాష్',0,0,0),(218,1,'Clear Shampoo','Clear Shampoo','10213',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:58.115',NULL,'2021-07-29 19:50:58.115',12,'','క్లియర్ షాంపూ',0,0,0),(219,1,'Clear Saram','Clear Saram','10214',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:58.270',NULL,'2021-07-29 19:50:58.270',12,'','క్లియర్ సరం',0,0,0),(220,1,'Clinic Plus Saram','Clinic Plus Saram','10215',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:58.391',NULL,'2021-07-29 19:50:58.391',12,'','క్లినిక్ ప్లస్ సరం',0,0,0),(221,1,'Clinic Plus Shampoo','Clinic Plus Shampoo','10216',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:58.503',NULL,'2021-07-29 19:50:58.503',12,'','క్లినిక్ ప్లస్ షాంపూ',0,0,0),(222,1,'Clips','Clips','10217',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:58.589',NULL,'2021-07-29 19:50:58.589',12,'','క్లిప్స్',0,0,0),(223,1,'Clips Sinco','Clips Sinco','10218',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:58.865',NULL,'2021-07-29 19:50:58.865',12,'','క్లిప్స్ సింకో',0,0,0),(224,1,'Close Up ','Close Up ','10219',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:59.167',NULL,'2021-07-29 19:50:59.167',12,'','క్లోజ్ అప్',0,0,0),(225,1,'Colgate Brush','Colgate Brush','10220',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:59.323',NULL,'2021-07-29 19:50:59.323',12,'','కోల్గేట్ బ్రష్',0,0,0),(226,1,'Colgate Cibaca','Colgate Cibaca','10221',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:59.411',NULL,'2021-07-29 19:50:59.411',12,'','కోల్గేట్ సిబాకా',0,0,0),(227,1,'Colgate Herbal','Colgate Herbal','10222',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:59.545',NULL,'2021-07-29 19:50:59.545',12,'','కోల్గేట్ హెర్బల్',0,0,0),(228,1,'Colgate Max','Colgate Max','10223',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:50:59.799',NULL,'2021-07-29 19:50:59.799',12,'','కోల్గేట్ మాక్స్',0,0,0),(229,1,'Colgate MF Blue','Colgate MF Blue','10224',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:00.045',NULL,'2021-07-29 19:51:00.045',12,'','కోల్గేట్ MF బ్లూ',0,0,0),(230,1,'Colgate MF Red','Colgate MF Red','10225',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:00.241',NULL,'2021-07-29 19:51:00.241',12,'','కోల్గేట్ MF రెడ్',0,0,0),(231,1,'Colgate Neem','Colgate Neem','10226',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:00.352',NULL,'2021-07-29 19:51:00.352',12,'','కోల్గేట్ నీమ్',0,0,0),(232,1,'Colgate Plax','Colgate Plax','10227',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:00.441',NULL,'2021-07-29 19:51:00.441',12,'','కోల్గేట్ ప్లక్ష్',0,0,0),(233,1,'Colgate Powder','Colgate Powder','10228',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:00.518',NULL,'2021-07-29 19:51:00.518',12,'','కోల్గేట్ పౌడర్',0,0,0),(234,1,'Colgate Salt','Colgate Salt','10229',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:00.618',NULL,'2021-07-29 19:51:00.618',12,'','కోల్గేట్ సాల్ట్',0,0,0),(235,1,'Colgate Salt Lemon','Colgate Salt Lemon','10230',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:00.840',NULL,'2021-07-29 19:51:00.840',12,'','కోల్గేట్ సాల్ట్ లెమన్',0,0,0),(236,1,'Colgate Sensitive','Colgate Sensitive','10231',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:01.006',NULL,'2021-07-29 19:51:01.006',12,'','కోల్గేట్ సెన్సిటివ్',0,0,0),(237,1,'Colgate Total','Colgate Total','10232',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:01.251',NULL,'2021-07-29 19:51:01.251',12,'','కోల్గేట్ టోటల్',0,0,0),(238,1,'Colgate Visible White','Colgate Visible White','10233',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:01.395',NULL,'2021-07-29 19:51:01.395',12,'','కోల్గేట్ విసిబుల్ వైట్',0,0,0),(239,1,'Colin','Colin','10234',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:01.517',NULL,'2021-07-29 19:51:01.517',12,'','కాలిన్',0,0,0),(240,1,'Comb','Comb','10235',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:01.674',NULL,'2021-07-29 19:51:01.674',12,'','కాంబ్',0,0,0),(241,1,'Comfort','Comfort','10236',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:01.816',NULL,'2021-07-29 19:51:01.816',12,'','కంఫోర్ట్',0,0,0),(242,1,'Complan','Complan','10237',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:01.893',NULL,'2021-07-29 19:51:01.893',12,'','కంప్లన్',0,0,0),(243,1,'Complan Jar','Complan Jar','10238',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:02.017',NULL,'2021-07-29 19:51:02.017',12,'','కంప్లన్ జార్',0,0,0),(244,1,'Complan Kesar','Complan Kesar','10239',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:02.105',NULL,'2021-07-29 19:51:02.105',12,'','కంప్లన్ కేసర్',0,0,0),(245,1,'Complan Nutri','Complan Nutri','10240',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:02.215',NULL,'2021-07-29 19:51:02.215',12,'','కంప్లన్ నుట్రి',0,0,0),(246,1,'Complan Pista','Complan Pista','10241',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:02.444',NULL,'2021-07-29 19:51:02.444',12,'','కంప్లన్ పిస్తా',0,0,0),(247,1,'Corn Flakes','Corn Flakes','10242',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:02.525',NULL,'2021-07-29 19:51:02.525',12,'','కార్న్ ఫ్లేకేస్',0,0,0),(248,1,'Corn Mixture','Corn Mixture','10243',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:02.883',NULL,'2021-07-29 19:51:02.883',12,'','కార్న్ మిక్స్అర్',0,0,0),(249,1,'Corn Powder','Corn Powder','10244',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:03.004',NULL,'2021-07-29 19:51:03.004',12,'','కార్న్ పౌడర్',0,0,0),(250,1,'Crane','Crane','10245',12.00,10.00,8.00,100,158,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:03.083',NULL,'2021-07-29 19:51:03.083',12,'','క్రేన్',0,0,0),(251,1,'Crystal','Crystal','10246',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:03.193',NULL,'2021-07-29 19:51:03.193',12,'','క్రిస్టల్',0,0,0),(252,1,'Crystal Tin','Crystal Tin','10247',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:03.314',NULL,'2021-07-29 19:51:03.314',12,'','క్రిస్టల్ టిన్',0,0,0),(253,1,'Custard Powder','Custard Powder','10248',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:03.389',NULL,'2021-07-29 19:51:03.389',12,'','కస్టర్డ్ పౌడర్',0,0,0),(254,1,'Dabur Almond Oil','Dabur Almond Oil','10249',12.00,10.00,8.00,100,90,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:03.494',NULL,'2021-07-29 19:51:03.494',12,'','డాబర్ ఆల్మాండ్ ఆయిల్',0,0,0),(255,1,'Dabur Almond Shampoo','Dabur Almond Shampoo','10250',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:03.647',NULL,'2021-07-29 19:51:03.647',12,'','డాబర్ ఆల్మాండ్ షాంపూ',0,0,0),(256,1,'Dabur Amla','Dabur Amla','10251',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:04.016',NULL,'2021-07-29 19:51:04.016',12,'','డాబర్ ఆమ్లా',0,0,0),(257,1,'Dabur Gulabari','Dabur Gulabari','10252',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:04.122',NULL,'2021-07-29 19:51:04.122',12,'','డాబర్ గులాబరి',0,0,0),(258,1,'Dabur Honey','Dabur Honey','10253',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:04.213',NULL,'2021-07-29 19:51:04.213',12,'','డాబర్ హనీ',0,0,0),(259,1,'Dabur Meswak','Dabur Meswak','10254',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:04.322',NULL,'2021-07-29 19:51:04.322',12,'','దాబర్ మెస్వాక్',0,0,0),(260,1,'Dabur Powder','Dabur Powder','10255',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:04.432',NULL,'2021-07-29 19:51:04.432',12,'','డాబర్ పౌడర్',0,0,0),(261,1,'Dabur Red','Dabur Red','10256',12.00,10.00,8.00,100,84,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:04.538',NULL,'2021-07-29 19:51:04.538',12,'','డాబర్ రెడ్',0,0,0),(262,1,'Dabur Red Gel','Dabur Red Gel','10257',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:04.675',NULL,'2021-07-29 19:51:04.675',12,'','డాబర్ రెడ్ జెల్',0,0,0),(263,1,'Dabur Vatika','Dabur Vatika','10258',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:05.116',NULL,'2021-07-29 19:51:05.116',12,'','డాబర్ వాటికా',0,0,0),(264,1,'Dairy Milk','Dairy Milk','10259',12.00,10.00,8.00,100,29,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:05.360',NULL,'2021-07-29 19:51:05.360',12,'','డైరీ మిల్క్',0,0,0),(265,1,'Dermi Cool','Dermi Cool','10260',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:05.448',NULL,'2021-07-29 19:51:05.448',12,'','డెర్మి కూల్',0,0,0),(266,1,'Dettol','Dettol','10261',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:05.595',NULL,'2021-07-29 19:51:05.595',12,'','డెట్టాల్',0,0,0),(267,1,'Dettol Cool','Dettol Cool','10262',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:05.748',NULL,'2021-07-29 19:51:05.748',12,'','డెట్టాల్ కూల్',0,0,0),(268,1,'Dettol HW','Dettol HW','10263',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:05.903',NULL,'2021-07-29 19:51:05.903',12,'','డెట్టాల్ HW',0,0,0),(269,1,'Dettol Liquid','Dettol Liquid','10264',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:05.994',NULL,'2021-07-29 19:51:05.994',12,'','డెట్టాల్ లిక్విడ్',0,0,0),(270,1,'Dettol Original','Dettol Original','10265',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:06.048',NULL,'2021-07-29 19:51:06.048',12,'','డెట్టాల్ ఒరిజినల్',0,0,0),(271,1,'Dettol Skin Care','Dettol Skin Care','10266',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:06.174',NULL,'2021-07-29 19:51:06.174',12,'','డెట్టాల్ స్కిన్ కేర్',0,0,0),(272,1,'Dalda Ghee','Dalda Ghee','10267',12.00,10.00,8.00,100,95,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:06.294',NULL,'2021-07-29 19:51:06.294',12,'','డాల్డా ఘీ',0,0,0),(273,1,'Domex','Domex','10268',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:06.347',NULL,'2021-07-29 19:51:06.347',12,'','డోమెక్ష్',0,0,0),(274,1,'Domex Powder','Domex Powder','10269',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:06.536',NULL,'2021-07-29 19:51:06.536',12,'','డోమెక్స్ పౌడర్',0,0,0),(275,1,'Dot Appalam','Dot Appalam','10270',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:06.646',NULL,'2021-07-29 19:51:06.646',12,'','డాట్ అప్పగలం',0,0,0),(276,1,'Dove Saram','Dove Saram','10271',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:06.958',NULL,'2021-07-29 19:51:06.958',12,'','డోవ్ సారం',0,0,0),(277,1,'Dove Shampoo','Dove Shampoo','10272',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:07.060',NULL,'2021-07-29 19:51:07.060',12,'','డోవ్ షాంపూ',0,0,0),(278,1,'Dove Soap','Dove Soap','10273',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:07.312',NULL,'2021-07-29 19:51:07.312',12,'','డోవ్ సోప్',0,0,0),(279,1,'Dove Soap Set','Dove Soap Set','10274',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:07.429',NULL,'2021-07-29 19:51:07.429',12,'','డోవ్ సోప్ సెట్',0,0,0),(280,1,'Dr.Copper Water Bottle','Dr.Copper Water Bottle','10275',12.00,10.00,8.00,100,58,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:07.523',NULL,'2021-07-29 19:51:07.523',12,'','Dr.కాపర్ వాటర్ బాటిల్',0,0,0),(281,1,'Dream Cream','Dream Cream','10276',12.00,10.00,8.00,100,88,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:07.703',NULL,'2021-07-29 19:51:07.703',12,'','డ్రీం క్రీమ్',0,0,0),(282,1,'Dream Cream Choco','Dream Cream Choco','10277',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:07.945',NULL,'2021-07-29 19:51:07.945',12,'','డ్రీం క్రీమ్ చాకో',0,0,0),(283,1,'Dry Dates','Dry Dates','10278',12.00,10.00,8.00,100,88,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:08.057',NULL,'2021-07-29 19:51:08.057',12,'','డ్రై డేట్స్',0,0,0),(284,1,'Dry Grapes','Dry Grapes','10279',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:08.160',NULL,'2021-07-29 19:51:08.160',12,'','డ్రై గ్రేప్స్',0,0,0),(285,1,'Dukes Waffy','Dukes Waffy','10280',12.00,10.00,8.00,100,91,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:08.278',NULL,'2021-07-29 19:51:08.278',12,'','డ్యూక్స్ వాఫీ',0,0,0),(286,1,'Durga Ghee','Durga Ghee','10281',12.00,486.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:08.356',NULL,'2021-07-29 19:51:08.356',12,'','దుర్గ ఘీ',0,0,0),(287,1,'Eastern Chicken','Eastern Chicken','10282',12.00,10.00,8.00,100,92,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:08.444',NULL,'2021-07-29 19:51:08.444',12,'','ఈస్ట్రన చికెన్',0,0,0),(288,1,'Eastern Chilli','Eastern Chilli','10283',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:08.557',NULL,'2021-07-29 19:51:08.557',12,'','ఈస్ట్రన్ చిల్లీ',0,0,0),(289,1,'Eastern Coriander','Eastern Dhaniyalu','10284',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:08.824',NULL,'2021-07-29 19:51:08.824',12,'','ఈస్ట్రన ధనియాలు',0,0,0),(290,1,'Eastern Garam Masala','Eastern Garam Masala','10285',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:09.024',NULL,'2021-07-29 19:51:09.024',12,'','ఈస్ట్రన గరం మసాలా',0,0,0),(291,1,'Eastern Meat','Eastern Meat','10286',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:09.131',NULL,'2021-07-29 19:51:09.131',12,'','ఈస్ట్రన మీట్',0,0,0),(292,1,'Eastern Rasam','Eastern Rasam','10287',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:09.265',NULL,'2021-07-29 19:51:09.265',12,'','ఈస్ట్రన రసమ్',0,0,0),(293,1,'Eastern Sambar','Eastern Sambar','10288',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:09.342',NULL,'2021-07-29 19:51:09.342',12,'','ఈస్ట్రన సాంబార్',0,0,0),(294,1,'Eastern Turmeric','Eastern Turmeric','10289',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:09.420',NULL,'2021-07-29 19:51:09.420',12,'','ఈస్ట్రన పసుపు',0,0,0),(295,1,'Eclairs','Eclairs','10290',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:09.533',NULL,'2021-07-29 19:51:09.533',12,'','ఎక్లైర్స్',0,0,0),(296,1,'Eclairs Choco Double','Eclairs Choco Double','10291',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:09.719',NULL,'2021-07-29 19:51:09.719',12,'','ఎక్లైర్స్ చోకో డబుల్',0,0,0),(297,1,'Eclairs Milkybar','Eclairs Milkybar','10292',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:09.828',NULL,'2021-07-29 19:51:09.828',12,'','ఎక్లైర్స్ మిల్కీబార్',0,0,0),(298,1,'Engage Spray','Engage Spray','10293',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:09.972',NULL,'2021-07-29 19:51:09.972',12,'','ఎంగేజ్ స్ప్రే',0,0,0),(299,1,'Eppa Nuny','Eppa Nuny','10294',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:10.104',NULL,'2021-07-29 19:51:10.104',12,'','ఎప్పా నునీ',0,0,0),(300,1,'Essence','Essence','10295',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:10.217',NULL,'2021-07-29 19:51:10.217',12,'','ఎసెన్స్',0,0,0),(301,1,'Everest Black Pepper','Everest Black Pepper','10296',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:10.327',NULL,'2021-07-29 19:51:10.327',12,'','ఎవరెస్ట్ బ్లాక్ పెప్పర్',0,0,0),(302,1,'Everest Chat Masala','Everest Chat Masala','10297',12.00,10.00,8.00,100,95,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:10.583',NULL,'2021-07-29 19:51:10.583',12,'','ఎవరెస్ట్ చాట్ మసాలా',0,0,0),(303,1,'Everest Chicken','Everest Chicken','10298',12.00,10.00,8.00,100,92,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:10.926',NULL,'2021-07-29 19:51:10.926',12,'','ఎవరెస్ట్ చికెన్',0,0,0),(304,1,'Everest Chole Masala','Everest Chole Masala','10299',12.00,6079.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:11.160',NULL,'2021-07-29 19:51:11.160',12,'','ఎవరెస్ట్ చోల్ మసాలా',0,0,0),(305,1,'Everest Cumin','Everest Cumin','10300',12.00,10.00,8.00,100,139,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:11.220',NULL,'2021-07-29 19:51:11.220',12,'','ఎవరెస్ట్ కుమిన్',0,0,0),(306,1,'Everest Fish Curry','Everest Fish Curry','10301',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:11.348',NULL,'2021-07-29 19:51:11.348',12,'','ఎవరెస్ట్ ఫిష్ కర్రీ',0,0,0),(307,1,'Everest Garam Masala','Everest Garam Masala','10302',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:11.426',NULL,'2021-07-29 19:51:11.426',12,'','ఎవరెస్ట్ గరం మసాలా',0,0,0),(308,1,'Everest Kasturi Methi','Everest Kasturi Methi','10303',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:11.696',NULL,'2021-07-29 19:51:11.696',12,'','ఎవరెస్ట్ కస్తూరి మెథి',0,0,0),(309,1,'Everest Meat Masala','Everest Meat Masala','10304',12.00,10.00,8.00,100,125,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:11.771',NULL,'2021-07-29 19:51:11.771',12,'','ఎవరెస్ట్ మీట్ మసాలా',0,0,0),(310,1,'Everest Panipuri','Everest Panipuri','10305',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:11.914',NULL,'2021-07-29 19:51:11.914',12,'','ఎవరెస్ట్ పానిపురి',0,0,0),(311,1,'Everest Rasam','Everest Rasam','10306',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:12.036',NULL,'2021-07-29 19:51:12.036',12,'','ఎవరెస్ట్ రసం',0,0,0),(312,1,'Everest Saffron','Everest Saffron','10307',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:12.129',NULL,'2021-07-29 19:51:12.129',12,'','ఎవరెస్ట్ కుంకుమ',0,0,0),(313,1,'Everest Sambar','Everest Sambar','10308',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:12.237',NULL,'2021-07-29 19:51:12.237',12,'','ఎవెరస్ట్ సాంబార్',0,0,0),(314,1,'Everest Sambar Super','Everest Sambar Super','10309',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:12.347',NULL,'2021-07-29 19:51:12.347',12,'','ఎవరెస్ట్ సామ్బర్ సూపర్',0,0,0),(315,1,'Everest Shahi Biryani','Everest Shahi Biryani','10310',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:12.436',NULL,'2021-07-29 19:51:12.436',12,'','ఎవరెస్టు షహీ బిర్యానీ',0,0,0),(316,1,'Everest Shahi Paneer','Everest Shahi Paneer','10311',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:12.558',NULL,'2021-07-29 19:51:12.558',12,'','ఎవరెస్ట్ షహీ పనీర్',0,0,0),(317,1,'Everest White Pepper','Everest White Pepper','10312',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:12.838',NULL,'2021-07-29 19:51:12.838',12,'','ఎవరెస్ట్ వైట్ పెప్పర్',0,0,0),(318,1,'Everyday Milk','Everyday Milk','10313',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:13.136',NULL,'2021-07-29 19:51:13.136',12,'','ఎవిరిడే మిల్క్',0,0,0),(319,1,'EXO','EXO','10314',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:13.256',NULL,'2021-07-29 19:51:13.256',12,'','ఎక్షొ',0,0,0),(320,1,'EXO Round','EXO Round','10315',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:14.045',NULL,'2021-07-29 19:51:14.045',12,'','ఎక్షొ రౌండ్',0,0,0),(321,1,'EXO Steel','EXO Steel','10317',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:14.804',NULL,'2021-07-29 19:51:14.804',12,'','ఎక్షొ స్టీల్',0,0,0),(322,1,'Fair & Handsome','Fair & Handsome','10318',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:14.932',NULL,'2021-07-29 19:51:14.932',12,'','ఫెయిర్ & హ్యాండ్సమ్',0,0,0),(323,1,'Fair & Lovely','Fair & Lovely','10319',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:15.063',NULL,'2021-07-29 19:51:15.063',12,'','ఫెయిర్ & లవ్లీ',0,0,0),(324,1,'Fair & Lovely Ayurvedic','Fair & Lovely Ayurvedic','10320',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:15.150',NULL,'2021-07-29 19:51:15.150',12,'','ఫెయిర్ & లవ్లీ ఆయుర్వేదిక్',0,0,0),(325,1,'Fairever','Fairever','10321',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:15.261',NULL,'2021-07-29 19:51:15.261',12,'','ఫైర్ఎవర్',0,0,0),(326,1,'Fiama Soap','Fiama Soap','10322',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:15.349',NULL,'2021-07-29 19:51:15.349',12,'','ఫియమా సోప్',0,0,0),(327,1,'Five Star','Five Star','10323',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:15.549',NULL,'2021-07-29 19:51:15.549',12,'','ఫైవ్ స్టార్',0,0,0),(328,1,'Food Colour','Food Colour','10324',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:15.741',NULL,'2021-07-29 19:51:15.741',12,'','ఫుడ్ కలర్',0,0,0),(329,1,'Fortune Basmati Rice','Fortune Basmati Rice','10325',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:15.971',NULL,'2021-07-29 19:51:15.971',12,'','ఫార్చూన్ బాస్మతి రైస్',0,0,0),(330,1,'Fortune Mustard Oil','Fortune Mustard Oil','10326',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:16.071',NULL,'2021-07-29 19:51:16.071',12,'','ఫార్చూన్ ఆవాలెడ్ ఆయిల్',0,0,0),(331,1,'Fortune SF Oil','Fortune SF Oil','10327',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:16.160',NULL,'2021-07-29 19:51:16.160',12,'','ఫార్చూన్ SF ఆయిల్',0,0,0),(332,1,'Freedom Oil','Freedom Oil','10328',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:16.259',NULL,'2021-07-29 19:51:16.259',12,'','ఫ్రీడం ఆయిల్',0,0,0),(333,1,'Freedom Rice Oil','Freedom Rice Oil','10329',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:16.404',NULL,'2021-07-29 19:51:16.404',12,'','ఫ్రీడం రైస్ ఆయిల్',0,0,0),(334,1,'Freedom Tin','Freedom Tin','10330',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:16.553',NULL,'2021-07-29 19:51:16.553',12,'','ఫ్రీడం టిన్',0,0,0),(335,1,'Gandham','Gandham','10331',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:16.705',NULL,'2021-07-29 19:51:16.705',12,'','గంధం',0,0,0),(336,1,'Gandham Tin','Gandham Tin','10332',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:17.069',NULL,'2021-07-29 19:51:17.069',12,'','గంధం టిన్',0,0,0),(337,1,'Gandham Tin Lotus','Gandham Tin Lotus','10333',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:17.269',NULL,'2021-07-29 19:51:17.269',12,'','గంధం టిన్ లోటస్',0,0,0),(338,1,'Garnier','Garnier','10334',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:17.491',NULL,'2021-07-29 19:51:17.491',12,'','గార్నియర్',0,0,0),(339,1,'Garnier Black Henna','Garnier Black Henna','10335',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:17.591',NULL,'2021-07-29 19:51:17.591',12,'','గార్నియర్ బ్లాక్ హెన్నా',0,0,0),(340,1,'Garnier Facewash','Garnier Facewash','10336',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:17.790',NULL,'2021-07-29 19:51:17.790',12,'','గార్నియర్ పేస్ వాష్',0,0,0),(341,1,'Gas Lighter','Gas Lighter','10337',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:18.080',NULL,'2021-07-29 19:51:18.080',12,'','గ్యాస్ లైటర్',0,0,0),(342,1,'Gayathri Dup Sticks','Gayathri Dup Sticks','10338',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:18.223',NULL,'2021-07-29 19:51:18.223',12,'','గాయత్రీ డూప్ స్టిక్స్',0,0,0),(343,1,'Gemini','Gemini','10339',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:18.323',NULL,'2021-07-29 19:51:18.323',12,'','జెమిని',0,0,0),(344,1,'Gillette Vector Blades','Gillette Vector Blades','10340',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:18.547',NULL,'2021-07-29 19:51:18.547',12,'','జిల్లెట్ వెక్టర్ బ్లేడ్స్',0,0,0),(345,1,'Gillette','Gillette','10341',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:18.789',NULL,'2021-07-29 19:51:18.789',12,'','జిల్లెట్',0,0,0),(346,1,'Gillette 7 Clock','Gillette 7 Clock','10342',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:19.166',NULL,'2021-07-29 19:51:19.166',12,'','జిల్లెట్ 7 క్లాక్',0,0,0),(347,1,'Gillette 7 Clock Blades','Gillette 7 Clock Blades','10343',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:19.255',NULL,'2021-07-29 19:51:19.255',12,'','జిల్లెట్ 7 క్లాక్ బ్లేడ్స్',0,0,0),(348,1,'Gillette Foam','Gillette Foam','10344',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:19.366',NULL,'2021-07-29 19:51:19.366',12,'','జిల్లెట్ ఫోమ్',0,0,0),(349,1,'Gillette Fusion','Gillette Fusion','10345',12.00,10.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:19.479',NULL,'2021-07-29 19:51:19.479',12,'','జిల్లెట్ ఫ్యూషన్',0,0,0),(350,1,'Gillette Fusion Razor','Gillette Fusion Razor','10346',12.00,10.00,8.00,100,89,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:19.854',NULL,'2021-07-29 19:51:19.854',12,'','జిల్లెట్ ఫ్యూజన్ రేజర్',0,0,0),(351,1,'Gillette Guard','Gillette Guard','10347',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:20.153',NULL,'2021-07-29 19:51:20.153',12,'','జిల్లెట్ గార్డ్',0,0,0),(352,1,'Gillette Guard Razor','Gillette Guard Razor','10348',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:20.483',NULL,'2021-07-29 19:51:20.483',12,'','జిల్లెట్ గార్డ్ రేజర్',0,0,0),(353,1,'Gillette Mach3','Gillette Mach3','10349',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:20.968',NULL,'2021-07-29 19:51:20.968',12,'','జిల్లెట్ మాక్ 3',0,0,0),(354,1,'Gillette Mach3 Set','Gillette Mach3 Set','10350',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:21.230',NULL,'2021-07-29 19:51:21.230',12,'','జిల్లెట్ మాక్ 3 సెట్',0,0,0),(355,1,'Gillette Mach3 Turbo','Gillette Mach3 Turbo','10351',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:21.482',NULL,'2021-07-29 19:51:21.482',12,'','జిల్లెట్ మచ్ 3 టర్బో',0,0,0),(356,1,'Gillette P2 Blades','Gillette P2 Blades','10352',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:21.727',NULL,'2021-07-29 19:51:21.727',12,'','జిల్లెట్ P2 బ్లేడ్స్',0,0,0),(357,1,'Gillette P2 Razor','Gillette P2 Razor','10353',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:21.914',NULL,'2021-07-29 19:51:21.914',12,'','జిల్లెట్ పి 2 రేజర్',0,0,0),(358,1,'Gillette Presto','Gillette Presto','10354',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:22.060',NULL,'2021-07-29 19:51:22.060',12,'','జిల్లెట్ ప్రేస్టో',0,0,0),(359,1,'Gillette Razor','Gillette Razor','10355',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:22.281',NULL,'2021-07-29 19:51:22.281',12,'','జిల్లెట్ రేజర్',0,0,0),(360,1,'Gillette Shave Gel','Gillette Shave Gel','10356',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:22.403',NULL,'2021-07-29 19:51:22.403',12,'','జిల్లెట్ షేవ్ జెల్',0,0,0),(361,1,'Gillette Shaving Brush','Gillette Shaving Brush','10357',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:22.541',NULL,'2021-07-29 19:51:22.541',12,'','జిల్లెట్ షేవింగ్ బ్రష్',0,0,0),(362,1,'Gillette Shaving Cream','Gillette Shaving Cream','10358',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:22.647',NULL,'2021-07-29 19:51:22.647',12,'','జిల్లెట్ షేవింగ్ క్రీమ్',0,0,0),(363,1,'Priya Ginger Garlic Paste','Priya Ginger Garlic Paste','10359',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:22.747',NULL,'2021-07-29 19:51:22.747',12,'','ప్రియా జింజర్ గార్లిక్ పేస్ట్',0,0,0),(364,1,'Girijan Honey','Girijan Honey','10360',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:22.921',NULL,'2021-07-29 19:51:22.921',12,'','గిరిజన హనీ',0,0,0),(365,1,'Glucon D','Glucon D','10361',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:23.102',NULL,'2021-07-29 19:51:23.102',12,'','గ్లూకాన్ D',0,0,0),(366,1,'Glucon D Jar','Glucon D Jar','10362',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:23.326',NULL,'2021-07-29 19:51:23.326',12,'','గ్లూకాన్ D జార్',0,0,0),(367,1,'Glucon D Orange','Glucon D Orange','10363',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:23.525',NULL,'2021-07-29 19:51:23.525',12,'','గ్లూకాన్ D ఆరెంజ్',0,0,0),(368,1,'Godrej Aer Pocket','Godrej Aer Pocket','10364',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:23.635',NULL,'2021-07-29 19:51:23.635',12,'','గోద్రేజ్ ఏరో పాకెట్',0,0,0),(369,1,'Godrej Aer Spray','Godrej Aer Spray','10365',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:23.734',NULL,'2021-07-29 19:51:23.734',12,'','గోద్రెజ్ ఏరో స్ప్రే',0,0,0),(370,1,'Godrej Shaving Cream','Godrej Shaving Cream','10366',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:23.970',NULL,'2021-07-29 19:51:23.970',12,'','గోద్రేజ్ షేవింగ్ క్రీమ్',0,0,0),(371,1,'Godrej Shikakai','Godrej Shikakai','10367',12.00,10.00,8.00,100,91,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:24.125',NULL,'2021-07-29 19:51:24.125',12,'','గోద్రేజ్ షికాకై',0,0,0),(372,1,'Godrej Expert Liqid','Godrej Expert Liqid','10368',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:24.234',NULL,'2021-07-29 19:51:24.234',12,'','గోద్రేజ్ ఎక్స్పర్ట్ లిక్విడ్',0,0,0),(373,1,'Gokul Dates','Gokul Dates','10369',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:24.391',NULL,'2021-07-29 19:51:24.391',12,'','గోకుల్ డేట్స్',0,0,0),(374,1,'Gokul Powder','Gokul Powder','10370',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:24.567',NULL,'2021-07-29 19:51:24.567',12,'','గోకుల్ పౌడర్',0,0,0),(375,1,'Good Day','Good Day','10371',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:24.657',NULL,'2021-07-29 19:51:24.657',12,'','గుడ్ డే',0,0,0),(376,1,'Good Day Packet','Good Day Packet','10372',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:24.757',NULL,'2021-07-29 19:51:24.757',12,'','గుడ్ డే ప్యాకెట్',0,0,0),(377,1,'Good Night','Good Night','10373',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:24.944',NULL,'2021-07-29 19:51:24.944',12,'','గుడ్ నైట్',0,0,0),(378,1,'Good Night Liquid','Good Night Liquid','10374',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:25.066',NULL,'2021-07-29 19:51:25.066',12,'','గుడ్ నైట్ లిక్విడ్',0,0,0),(379,1,'Gopuram','Gopuram','10375',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:25.255',NULL,'2021-07-29 19:51:25.255',12,'','గోపురం',0,0,0),(380,1,'Gopuram 100g','Gopuram 100g','10376',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:25.343',NULL,'2021-07-29 19:51:25.343',12,'','గోపురం 100 గ్రా',0,0,0),(381,1,'Gopuram 200g','Gopuram 200g','10377',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:25.432',NULL,'2021-07-29 19:51:25.432',12,'','గోపురం 200 గ్రా',0,0,0),(382,1,'Gopuram 500g','Gopuram 500g','10378',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:25.695',NULL,'2021-07-29 19:51:25.695',12,'','గోపురం 500 గ్రా',0,0,0),(383,1,'Gopuram Box','Gopuram Box','10379',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:25.751',NULL,'2021-07-29 19:51:25.751',12,'','గోపురం బాక్స్',0,0,0),(384,1,'Green Peas','Green Peas','10380',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:25.944',NULL,'2021-07-29 19:51:25.944',12,'','ఆకుపచ్చ బటానీలు',0,0,0),(385,1,'Haldiram','Haldiram','10381',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:26.039',NULL,'2021-07-29 19:51:26.039',12,'','హల్దిరాం',0,0,0),(386,1,'Haldiram Soap Papdi','Haldiram Soap Papdi','10382',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:26.128',NULL,'2021-07-29 19:51:26.128',12,'','హల్దిరాం సోప్ పాపది',0,0,0),(387,1,'Hamam Soap','Hamam Soap','10383',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:26.228',NULL,'2021-07-29 19:51:26.228',12,'','హమాం సోప్',0,0,0),(388,1,'Harpic','Harpic','10384',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:26.340',NULL,'2021-07-29 19:51:26.340',12,'','హార్పిక్',0,0,0),(389,1,'Hatsun Ghee','Hatsun Ghee','10385',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:26.450',NULL,'2021-07-29 19:51:26.450',12,'','హాట్సన్ ఘీ',0,0,0),(390,1,'Head & Shoulders Shampoo','Head & Shoulders Shampoo','10386',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:26.583',NULL,'2021-07-29 19:51:26.583',12,'','హెడ్ & షోల్డర్ షాంపూ',0,0,0),(391,1,'Head & Shoulders Saram','Head & Shoulders Saram','10387',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:26.694',NULL,'2021-07-29 19:51:26.694',12,'','హెడ్ & షోల్డర్ సరం',0,0,0),(392,1,'Henko Soap','Henko Soap','10388',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:26.909',NULL,'2021-07-29 19:51:26.909',12,'','హెన్కో సోప్',0,0,0),(393,1,'Hide & Seek','Hide & Seek','10389',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:27.233',NULL,'2021-07-29 19:51:27.233',12,'','హైడ్ & సీక్',0,0,0),(394,1,'Hide & Seek Black','Hide & Seek Black','10390',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:27.382',NULL,'2021-07-29 19:51:27.382',12,'','హైడ్ & సీక్ బ్లాక్',0,0,0),(395,1,'Hide & Seek Cafee','Hide & Seek Cafee','10391',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:27.538',NULL,'2021-07-29 19:51:27.538',12,'','హైడ్ & సీక్ కేఫీ',0,0,0),(396,1,'Hide & Seek Fab','Hide & Seek Fab','10392',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:27.648',NULL,'2021-07-29 19:51:27.648',12,'','హైడ్ & సీక్ ఫ్యాబ్',0,0,0),(397,1,'Himalaya Baby Shampoo','Himalaya Baby Shampoo','10393',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:27.748',NULL,'2021-07-29 19:51:27.748',12,'','హిమాలయ బేబీ షాంపూ',0,0,0),(398,1,'Himalaya Baby Lotion','Himalaya Baby Lotion','10394',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:27.926',NULL,'2021-07-29 19:51:27.926',12,'','హిమాలయ బేబీ లోషన్',0,0,0),(399,1,'Himalaya Baby Oil','Himalaya Baby Oil','10395',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:28.104',NULL,'2021-07-29 19:51:28.104',12,'','హిమాలయ బేబీ ఆయిల్',0,0,0),(400,1,'Himalaya Baby Powder','Himalaya Baby Powder','10396',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:28.159',NULL,'2021-07-29 19:51:28.159',12,'','హిమాలయ బేబీ పౌడర్',0,0,0),(401,1,'Himalaya Baby Soap','Himalaya Baby Soap','10397',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:28.280',NULL,'2021-07-29 19:51:28.280',12,'','హిమాలయ బేబీ సోప్',0,0,0),(402,1,'Himalaya Baby Wipes','Himalaya Baby Wipes','10398',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:28.404',NULL,'2021-07-29 19:51:28.404',12,'','హిమాలయ బేబీ వైప్స్',0,0,0),(403,1,'Himalaya Facewash','Himalaya Facewash','10399',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:28.499',NULL,'2021-07-29 19:51:28.499',12,'','హిమాలయ పేస్ వాష్',0,0,0),(404,1,'Himalaya Massage Oil','Himalaya Massage Oil','10400',12.00,10.00,8.00,100,600,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:28.613',NULL,'2021-07-29 19:51:28.613',12,'','హిమాలయ మసాజ్ ఆయిల్',0,0,0),(405,1,'Candy 250g','Kalakanda','10401',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:28.758',NULL,'2021-07-29 19:51:28.758',12,'','కలకండ',0,0,0),(406,1,'Candy 500g','Kalakanda','10402',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:29.112',NULL,'2021-07-29 19:51:29.112',12,'','కలకండ',0,0,0),(407,1,'Candy 1kg','Kalakanda','10403',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:29.212',NULL,'2021-07-29 19:51:29.212',12,'','కలకండ',0,0,0),(408,1,'Candy Diamond 250g','Kalakanda Diamond','10404',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:29.312',NULL,'2021-07-29 19:51:29.312',12,'','కలకండ డైమండ్',0,0,0),(409,1,'Candy Diamond 500g','Kalakanda Diamond','10405',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:29.457',NULL,'2021-07-29 19:51:29.457',12,'','కలకండ డైమండ్',0,0,0),(410,1,'Candy Diamond 100g','Kalakanda Diamond','10406',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:29.545',NULL,'2021-07-29 19:51:29.545',12,'','కలకండ డైమండ్',0,0,0),(411,1,'Camphor','Karpooram','10407',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:29.678',NULL,'2021-07-29 19:51:29.678',12,'','కర్పూరం',0,0,0),(412,1,'Himalaya Paste','Himalaya Paste','10408',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:29.737',NULL,'2021-07-29 19:51:29.737',12,'','హిమాలయ పేస్ట్',0,0,0),(413,1,'Himalaya Shampoo','Himalaya Shampoo','10409',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:29.869',NULL,'2021-07-29 19:51:29.869',12,'','హిమాలయ షాంపూ',0,0,0),(414,1,'Himalaya Soap','Himalaya Soap','10410',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:30.236',NULL,'2021-07-29 19:51:30.236',12,'','హిమాలయ సోప్',0,0,0),(415,1,'Hit','Hit','10411',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:30.334',NULL,'2021-07-29 19:51:30.334',12,'','హిట్',0,0,0),(416,1,'Hit Chalk','Hit Chalk','10412',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:30.422',NULL,'2021-07-29 19:51:30.422',12,'','హిట్ చాక్',0,0,0),(417,1,'Hit Rat Kill','Hit Rat Kill','10413',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:30.511',NULL,'2021-07-29 19:51:30.511',12,'','హిట్ రాట్ కిల్',0,0,0),(418,1,'Horlicks','Horlicks','10414',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:30.622',NULL,'2021-07-29 19:51:30.622',12,'','హార్లిక్స్',0,0,0),(419,1,'Horlicks Jar','Horlicks Jar','10415',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:30.877',NULL,'2021-07-29 19:51:30.877',12,'','హార్లిక్స్ జార్',0,0,0),(420,1,'Horlicks Biscuits','Horlicks Biscuits','10416',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:31.077',NULL,'2021-07-29 19:51:31.077',12,'','హార్లిక్ బిస్కెట్లు',0,0,0),(421,1,'Horlicks Chocolate','Horlicks Chocolate','10417',12.00,900.00,8.00,100,53,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:31.166',NULL,'2021-07-29 19:51:31.166',12,'','హొర్లిచ్క్ష్ చాక్లెట్',0,0,0),(422,1,'Horlicks Chocolate Jar','Horlicks Chocolate Jar','10418',12.00,1570.00,8.00,100,74,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:31.277',NULL,'2021-07-29 19:51:31.277',12,'','होर्लीच्क्ष चॉकलेट',0,0,0),(423,1,'Horlicks Growth','Horlicks Growth','10419',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:31.362',NULL,'2021-07-29 19:51:31.362',12,'','హార్లిక్స్ గ్రోత్',0,0,0),(424,1,'Horlicks Junior','Horlicks Junior','10420',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:31.473',NULL,'2021-07-29 19:51:31.473',12,'','హార్లిక్స్ జూనియర్',0,0,0),(425,1,'Horlicks Junior Bottle','Horlicks Junior Bottle','10421',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:31.616',NULL,'2021-07-29 19:51:31.616',12,'','హార్లిక్స్ జూనియర్ బాటిల్',0,0,0),(426,1,'Horlicks Kesar','Horlicks Kesar','10422',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:31.717',NULL,'2021-07-29 19:51:31.717',12,'','హార్లిక్స్ కేసర్',0,0,0),(427,1,'Horlicks Lite','Horlicks Lite','10423',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:31.872',NULL,'2021-07-29 19:51:31.872',12,'','హార్విక్స్ లైట్',0,0,0),(428,1,'Horlicks Mothers','Horlicks Mothers','10424',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:32.261',NULL,'2021-07-29 19:51:32.261',12,'','హార్విక్స్ మదర్స్',0,0,0),(429,1,'Horlicks Oats','Horlicks Oats','10425',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:32.394',NULL,'2021-07-29 19:51:32.394',12,'','హార్లిక్స్ వోట్స్',0,0,0),(430,1,'Ice Cream Powder','Ice Cream Powder','10426',12.00,10.00,8.00,100,90,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:32.605',NULL,'2021-07-29 19:51:32.605',12,'','ఐస్ క్రీమ్ పౌడర్',0,0,0),(431,1,'Idhayam Groundnut Oil','Idhayam Groundnut Oil','10427',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:32.738',NULL,'2021-07-29 19:51:32.738',12,'','ఇదాయం గ్రౌండ్ నట్ ఆయిల్',0,0,0),(432,1,'Idhayam Mustard Oil','Idhayam Mustard Oil','10428',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:32.938',NULL,'2021-07-29 19:51:32.938',12,'','ఇదాయం మస్టర్డ్ ఆయిల్',0,0,0),(433,1,'Lalitha Idly Ravva','Lalitha Idly Ravva','10429',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:33.460',NULL,'2021-07-29 19:51:33.460',12,'','లలిత ఇడ్లీ రవ్వ',0,0,0),(434,1,'Vamsi Idly Ravva','Vamsi Idly Ravva','10430',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:33.559',NULL,'2021-07-29 19:51:33.559',12,'','వంశీ ఇడ్లీ రవ్వ',0,0,0),(435,1,'Idly Ravva 250g','Idly Ravva 250g','10431',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:33.770',NULL,'2021-07-29 19:51:33.770',12,'','ఇడ్లీ రవ్వ 250g',0,0,0),(436,1,'Idly Ravva 500g','Idly Ravva 500g','10432',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:33.904',NULL,'2021-07-29 19:51:33.904',12,'','ఇడ్లీ రవ్వ 500g',0,0,0),(437,1,'Idly Ravva 1kg','Idly Ravva 1kg','10433',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:34.091',NULL,'2021-07-29 19:51:34.091',12,'','ఇడ్లీ రవ్వ 1kg',0,0,0),(438,1,'India Gate Super','India Gate Super','10434',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:34.236',NULL,'2021-07-29 19:51:34.236',12,'','ఇండియ గేట్ సూపర్',0,0,0),(439,1,'India Gate Classic','India Gate Classic','10435',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:34.358',NULL,'2021-07-29 19:51:34.358',12,'','ఇండియ గేట్ క్లాసిక్',0,0,0),(440,1,'Indica Easy','Indica Easy','10436',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:34.480',NULL,'2021-07-29 19:51:34.480',12,'','ఇండికా ఈజీ',0,0,0),(441,1,'Jet Coil','Jet Coil','10437',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:34.613',NULL,'2021-07-29 19:51:34.613',12,'','జెట్ కాయిల్',0,0,0),(442,1,'Jet Jumbo Coil','Jet Jumbo Coil','10438',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:34.777',NULL,'2021-07-29 19:51:34.777',12,'','జెట్ జంబో కాయిల్',0,0,0),(443,1,'Jim Jam','Jim Jam','10439',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:34.928',NULL,'2021-07-29 19:51:34.928',12,'','జిమ్ జామ్',0,0,0),(444,1,'Johnson Baby Shampoo','Johnson Baby Shampoo','10440',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:35.300',NULL,'2021-07-29 19:51:35.300',12,'','జాన్సన్ బేబీ షాంపూ',0,0,0),(445,1,'Johnson Baby Hair Oil','Johnson Baby Hair Oil','10441',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:35.432',NULL,'2021-07-29 19:51:35.432',12,'','జాన్సన్ బేబీ హెయిర్ ఆయిల్',0,0,0),(446,1,'Johnson Baby Body Oil','Johnson Baby Body Oil','10442',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:35.521',NULL,'2021-07-29 19:51:35.521',12,'','జాన్సన్ బేబీ బాడీ ఆయిల్',0,0,0),(447,1,'Johnson Baby Powder','Johnson Baby Powder','10443',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:35.664',NULL,'2021-07-29 19:51:35.664',12,'','జాన్సన్ బేబీ పౌడర్',0,0,0),(448,1,'Johnson Baby Soap','Johnson Baby Soap','10444',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:35.743',NULL,'2021-07-29 19:51:35.743',12,'','జాన్సన్ బేబీ సోప్',0,0,0),(449,1,'Johnson Baby Wipes','Johnson Baby Wipes','10445',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:36.086',NULL,'2021-07-29 19:51:36.086',12,'','జాన్సన్ బేబీ వైప్స్',0,0,0),(450,1,'JS Puja Oil','JS Puja Oil','10446',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:36.249',NULL,'2021-07-29 19:51:36.249',12,'','JS పూజ ఆయిల్',0,0,0),(451,1,'Karthika Saram','Karthika Saram','10447',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:36.404',NULL,'2021-07-29 19:51:36.404',12,'','కార్తీక సరం',0,0,0),(452,1,'Karthika Shampoo','Karthika Shampoo','10448',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:36.461',NULL,'2021-07-29 19:51:36.461',12,'','కార్తికా షాంపూ',0,0,0),(453,1,'Kellogg\'s Oats','Kellogg\'s Oats','10449',12.00,10.00,8.00,100,92,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:36.572',NULL,'2021-07-29 19:51:36.572',12,'','కెల్లోగ్స్ వోట్స్',0,0,0),(454,1,'KEO Karpin','KEO Karpin','10450',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:36.811',NULL,'2021-07-29 19:51:36.811',12,'','KEO కార్పిన్',0,0,0),(455,1,'Kimia Dates','Kimia Dates','10451',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:36.994',NULL,'2021-07-29 19:51:36.994',12,'','కిమీయా డేట్స్',0,0,0),(456,1,'Kinder Crispy','Kinder Crispy','10452',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:37.150',NULL,'2021-07-29 19:51:37.150',12,'','కిండర్ క్రిస్పీ',0,0,0),(457,1,'Kinder Joy','Kinder Joy','10453',12.00,10.00,8.00,100,35,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:37.304',NULL,'2021-07-29 19:51:37.304',12,'','కిండర్ జాయ్',0,0,0),(458,1,'Kissan','Kissan','10454',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:37.449',NULL,'2021-07-29 19:51:37.449',12,'','కిసాన్',0,0,0),(459,1,'Kissan Jam','Kissan Jam','10455',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:37.701',NULL,'2021-07-29 19:51:37.701',12,'','కిసాన్ జామ్',0,0,0),(460,1,'Kissan Sauce','Kissan Sauce','10456',12.00,10.00,8.00,100,89,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:37.948',NULL,'2021-07-29 19:51:37.948',12,'','కిసాన్ సాస్',0,0,0),(461,1,'Kissan Squash','Kissan Squash','10457',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:38.291',NULL,'2021-07-29 19:51:38.291',12,'','కిసాన్ స్క్వాష్',0,0,0),(462,1,'Kissan Tamato','Kissan Tamato','10458',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:38.435',NULL,'2021-07-29 19:51:38.435',12,'','కిసాన్ టమోటో',0,0,0),(463,1,'Coconut 250g','Coconut 250g','10459',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:38.547',NULL,'2021-07-29 19:51:38.547',12,'','కొబ్బరి 250g',0,0,0),(464,1,'Coconut 500g','Coconut 500g','10460',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:38.713',NULL,'2021-07-29 19:51:38.713',12,'','కొబ్బరి 500g',0,0,0),(465,1,'Coconut 1kg','Coconut 1kg','10461',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:38.950',NULL,'2021-07-29 19:51:38.950',12,'','కొబ్బరి 1kg',0,0,0),(466,1,'Krack Jack','Krack Jack','10462',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:39.093',NULL,'2021-07-29 19:51:39.093',12,'','క్రాక్ జాక్',0,0,0),(467,1,'Kunukulu','Kunukulu','10463',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:39.168',NULL,'2021-07-29 19:51:39.168',12,'','కునుకులు',0,0,0),(468,1,'Lakme Facewash','Lakme Facewash','10464',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:39.422',NULL,'2021-07-29 19:51:39.422',12,'','లాక్మీ పేస్ వాష్',0,0,0),(469,1,'Lakme Sunscreen Lotion','Lakme Sunscreen Lotion','10465',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:39.534',NULL,'2021-07-29 19:51:39.534',12,'','లాక్మీ సన్ స్క్రీన్ లోషన్',0,0,0),(470,1,'Laser Blades','Laser Blades','10466',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:39.657',NULL,'2021-07-29 19:51:39.657',12,'','లేజర్ బ్లేడ్స్',0,0,0),(471,1,'Lifebouy','Lifebouy','10467',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:39.757',NULL,'2021-07-29 19:51:39.757',12,'','లైఫ్ బోయ్',0,0,0),(472,1,'Lifebouy Pack','Lifebouy Pack','10468',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:39.923',NULL,'2021-07-29 19:51:39.923',12,'','లైఫ్ బోయ్ ప్యాక్',0,0,0),(473,1,'Lion Dates','Lion Dates','10469',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:40.333',NULL,'2021-07-29 19:51:40.333',12,'','లయన్ డేట్స్',0,0,0),(474,1,'Lion Dates Black','Lion Dates Black','10470',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:40.599',NULL,'2021-07-29 19:51:40.599',12,'','లయన్ డేట్స్ బ్లాక్',0,0,0),(475,1,'Lion Jam','Lion Jam','10471',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:40.753',NULL,'2021-07-29 19:51:40.753',12,'','లయన్ జామ్',0,0,0),(476,1,'Lion Syrup','Lion Syrup','10472',12.00,10.00,8.00,100,90,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:40.987',NULL,'2021-07-29 19:51:40.987',12,'','లయన్ ద్రాప్',0,0,0),(477,1,'Lipton','Lipton','10473',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:41.138',NULL,'2021-07-29 19:51:41.138',12,'','లిప్టన్',0,0,0),(478,1,'Liril Soap','Liril Soap','10474',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:41.282',NULL,'2021-07-29 19:51:41.282',12,'','లిరిల్ సోప్',0,0,0),(479,1,'Lysol','Lysol','10475',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:41.405',NULL,'2021-07-29 19:51:41.405',12,'','లైసాల్',0,0,0),(480,1,'Loreal Shampoo','Loreal Shampoo','10476',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:41.637',NULL,'2021-07-29 19:51:41.637',12,'','లోరియల్ షాంపూ',0,0,0),(481,1,'Lux International','Lux International','10477',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:41.739',NULL,'2021-07-29 19:51:41.739',12,'','లక్స్ ఇంటర్నేషనల్',0,0,0),(482,1,'Lux Soap Set','Lux Soap Set','10478',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:41.880',NULL,'2021-07-29 19:51:41.880',12,'','లక్స్ సోప్ సెట్',0,0,0),(483,1,'Lux','Lux','10479',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:42.049',NULL,'2021-07-29 19:51:42.049',12,'','లక్స్',0,0,0),(484,1,'Maggi','Maggi','10480',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:42.158',NULL,'2021-07-29 19:51:42.158',12,'','మాగి',0,0,0),(485,1,'Malas Juice Bottle','Malas Juice Bottle','10481',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:42.249',NULL,'2021-07-29 19:51:42.249',12,'','మలాస్ జ్యూస్ బాటిల్',0,0,0),(486,1,'Maltova','Maltova','10482',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:42.357',NULL,'2021-07-29 19:51:42.357',12,'','మాల్తో వ',0,0,0),(487,1,'Mango Bite','Mango Bite','10483',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:42.479',NULL,'2021-07-29 19:51:42.479',12,'','మ్యాంగో బైట్',0,0,0),(488,1,'Margo','Margo','10484',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:42.572',NULL,'2021-07-29 19:51:42.572',12,'','మార్గో',0,0,0),(489,1,'Marie Gold','Marie Gold','10485',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:42.904',NULL,'2021-07-29 19:51:42.904',12,'','మేరీ గోల్డ్',0,0,0),(490,1,'Marie Gold Vita','Marie Gold Vita','10486',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:43.403',NULL,'2021-07-29 19:51:43.403',12,'','మేరీ గోల్డ్ వీటా',0,0,0),(491,1,'Mealmaker','Mealmaker','10487',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:43.591',NULL,'2021-07-29 19:51:43.591',12,'','మీల్మేకర్',0,0,0),(492,1,'Mealmaker Fortune','Mealmaker Fortune','10488',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:43.737',NULL,'2021-07-29 19:51:43.737',12,'','మీల్మేకర్ ఫార్చ్యూన్',0,0,0),(493,1,'Mediker Soap','Mediker Soap','10489',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:44.066',NULL,'2021-07-29 19:51:44.066',12,'','మెడికేర్ సోప్',0,0,0),(494,1,'Medimix Sandal','Medimix Sandal','10490',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:44.170',NULL,'2021-07-29 19:51:44.170',12,'','మెడీమిక్స్ శాండల్',0,0,0),(495,1,'Medimix Soap','Medimix Soap','10491',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:44.288',NULL,'2021-07-29 19:51:44.288',12,'','మెడీమిక్స్ సోప్',0,0,0),(496,1,'Meera Saram','Meera Saram','10492',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:44.390',NULL,'2021-07-29 19:51:44.390',12,'','మీరా సరం',0,0,0),(497,1,'Meera Coconut Oil','Meera Coconut Oil','10493',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:44.523',NULL,'2021-07-29 19:51:44.523',12,'','మీరా కోకనట్ ఆయిల్',0,0,0),(498,1,'Meera Powder','Meera Powder','10494',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:44.637',NULL,'2021-07-29 19:51:44.637',12,'','మీరా పౌడర్',0,0,0),(499,1,'Meera Shampoo','Meera Shampoo','10495',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:44.754',NULL,'2021-07-29 19:51:44.754',12,'','మీరా షాంపూ',0,0,0),(500,1,'Mentho Plus','Mentho Plus','10496',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:44.920',NULL,'2021-07-29 19:51:44.920',12,'','మెంతోఫ్ ప్లస్',0,0,0),(501,1,'Milk Bikis','Milk Bikis','10497',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:45.442',NULL,'2021-07-29 19:51:45.442',12,'','మిల్క్ బికిస్',0,0,0),(502,1,'Milkmaid','Milkmaid','10498',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:45.588',NULL,'2021-07-29 19:51:45.588',12,'','మిల్క్మెయిడ్',0,0,0),(503,1,'Mop','Mop','10499',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:45.697',NULL,'2021-07-29 19:51:45.697',12,'','మాప్',0,0,0),(504,1,'Mop & Wooden Stick','Mop & Wooden Stick','10500',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:45.897',NULL,'2021-07-29 19:51:45.897',12,'','మాప్ & వుడెన్ స్టిక్',0,0,0),(505,1,'Mop & Steel Rod','Mop & Steel Rod','10501',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:46.226',NULL,'2021-07-29 19:51:46.226',12,'','మాప్ & స్టీల్ రాడ్',0,0,0),(506,1,'Mop Steel Rod','Mop Steel Rod','10502',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:46.285',NULL,'2021-07-29 19:51:46.285',12,'','మాప్ స్టీల్ రాడ్',0,0,0),(507,1,'Mouth Wash','Mouth Wash','10503',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:46.407',NULL,'2021-07-29 19:51:46.407',12,'','మౌత్ వాష్',0,0,0),(508,1,'MTR Badam Drink','MTR Badam Drink','10504',12.00,10.00,8.00,100,90,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:46.504',NULL,'2021-07-29 19:51:46.504',12,'','MTR బాదం డ్రింక్',0,0,0),(509,1,'MTR Badam Drink Jar','MTR Badam Drink Jar','10505',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:46.606',NULL,'2021-07-29 19:51:46.606',12,'','MTR బాదం డ్రింక్ జార్',0,0,0),(510,1,'MTR Garam Masala','MTR Garam Masala','10506',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:46.773',NULL,'2021-07-29 19:51:46.773',12,'','MTR గరం మసాలా',0,0,0),(511,1,'MTR Gulabjam','MTR Gulabjam','10507',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:46.982',NULL,'2021-07-29 19:51:46.982',12,'','MTR గులాబ్జమ్',0,0,0),(512,1,'MTR Lemon Rice','MTR Lemon Rice','10508',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:47.072',NULL,'2021-07-29 19:51:47.072',12,'','MTR నిమ్మకాయ రైస్',0,0,0),(513,1,'MTR Payasam','MTR Payasam','10509',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:47.184',NULL,'2021-07-29 19:51:47.184',12,'','MTR పాయాసం',0,0,0),(514,1,'MTR Pulao Masala','MTR Pulao Masala','10510',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:47.450',NULL,'2021-07-29 19:51:47.450',12,'','MTR పూలావో మసాలా',0,0,0),(515,1,'MTR Rasam','MTR Rasam','10511',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:47.505',NULL,'2021-07-29 19:51:47.505',12,'','MTR రసం',0,0,0),(516,1,'MTR Ravva Dosa','MTR Ravva Dosa','10512',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:47.618',NULL,'2021-07-29 19:51:47.618',12,'','MTR రవ్వ దోస',0,0,0),(517,1,'MTR ravva Idly','MTR ravva Idly','10513',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:47.782',NULL,'2021-07-29 19:51:47.782',12,'','MTR రావ్వ ఇడ్లి',0,0,0),(518,1,'MTR Roasted','MTR Roasted','10514',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:48.031',NULL,'2021-07-29 19:51:48.031',12,'','MTR రోస్ట్ద్',0,0,0),(519,1,'MTR Sambar','MTR Sambar','10515',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:48.215',NULL,'2021-07-29 19:51:48.215',12,'','MTR సాంబార్',0,0,0),(520,1,'MTR Tamrind Rice','MTR Tamrind Rice','10516',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:48.380',NULL,'2021-07-29 19:51:48.380',12,'','MTR తమరిండ్ రైస్',0,0,0),(521,1,'Munch','Munch','10517',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:48.624',NULL,'2021-07-29 19:51:48.624',12,'','మంచ్',0,0,0),(522,1,'Mysore Sandal','Mysore Sandal','10518',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:48.789',NULL,'2021-07-29 19:51:48.789',12,'','మైసూర్ శాండల్',0,0,0),(523,1,'Mysore Sandal Gold','Mysore Sandal Gold','10519',12.00,10.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:49.107',NULL,'2021-07-29 19:51:49.107',12,'','మైసూర్ శాంతల్ గోల్డ్',0,0,0),(524,1,'Nail Cutter','Nail Cutter','10520',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:49.334',NULL,'2021-07-29 19:51:49.334',12,'','నెయిల్ కట్టర్',0,0,0),(525,1,'Asafotedia','Inguva','10521',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:49.523',NULL,'2021-07-29 19:51:49.523',12,'','ఇంగువ',0,0,0),(526,1,'Basil Seeds','Sabja','10522',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:49.722',NULL,'2021-07-29 19:51:49.722',12,'','సాబ్జా',0,0,0),(527,1,'Black Cardamom','Nalla Elakkulu','10523',12.00,10.00,8.00,100,93,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:49.789',NULL,'2021-07-29 19:51:49.789',12,'','నల్ల ఎలాక్కులు',0,0,0),(528,1,'Black Cumin','Nalla Jeelakara','10524',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:50.086',NULL,'2021-07-29 19:51:50.086',12,'','నల్ల జీలకర',0,0,0),(529,1,'Caraway','Shahijeera','10525',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:50.222',NULL,'2021-07-29 19:51:50.222',12,'','శాహిజీర',0,0,0),(530,1,'Carom Seeds','Vamu','10526',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:50.302',NULL,'2021-07-29 19:51:50.302',12,'','వాము',0,0,0),(531,1,'Cumin','Jeelakara','10527',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:50.399',NULL,'2021-07-29 19:51:50.399',12,'','జీలకర',0,0,0),(532,1,'Dry Ginger','Sonti','10528',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:50.466',NULL,'2021-07-29 19:51:50.466',12,'','సొంటి',0,0,0),(533,1,'Fennel Seeds','Sompu, Sopu, Anieseeds','10529',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:50.533',NULL,'2021-07-29 19:51:50.533',12,'','సోమ్పు, సోపు, అన్సీడ్స్',0,0,0),(534,1,'Green Cardamom','Chinna Elakkulu','10530',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:50.614',NULL,'2021-07-29 19:51:50.614',12,'','చిన్న ఎలక్కులు',0,0,0),(535,1,'Large Mustard','Avalu','10531',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:50.710',NULL,'2021-07-29 19:51:50.710',12,'','ఆవాలు',0,0,0),(536,1,'Mace','Japathri,Jajikaya Pathri','10532',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:50.875',NULL,'2021-07-29 19:51:50.875',12,'','జపత్రి, జాజికాయ పత్రి',0,0,0),(537,1,'Nutmeg','Jajikaya','10533',12.00,10.00,8.00,100,90,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:51.190',NULL,'2021-07-29 19:51:51.190',12,'','జాజికాయ',0,0,0),(538,1,'Onion Seeds','Ulli Vithanalu','10534',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:51.309',NULL,'2021-07-29 19:51:51.309',12,'','ఉల్లి విత్తనాలు',0,0,0),(539,1,'Star Anise','Anasa Puvu','10535',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:51.400',NULL,'2021-07-29 19:51:51.400',12,'','అనస పువ్వు',0,0,0),(540,1,'Stone Flower','Dagad Phoot,Rock Flower','10536',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:51.512',NULL,'2021-07-29 19:51:51.512',12,'','డాగడ్ ఫుట్, రాక్ ఫ్లవర్',0,0,0),(541,1,'Navaratna Oil','Navaratna Oil','10537',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:51.645',NULL,'2021-07-29 19:51:51.645',12,'','నవారత్న ఆయిల్',0,0,0),(542,1,'Navaratna Powder','Navaratna Powder','10538',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:51.756',NULL,'2021-07-29 19:51:51.756',12,'','నవరత్న పౌడర్',0,0,0),(543,1,'Nestum','Nestum','10539',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:51.894',NULL,'2021-07-29 19:51:51.894',12,'','నెస్టమ',0,0,0),(544,1,'Nestum State1','Nestum State1','10540',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:52.337',NULL,'2021-07-29 19:51:52.337',12,'','నెస్టమ్ స్టేట్ 1',0,0,0),(545,1,'Nestum State2','Nestum State2','10541',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:52.581',NULL,'2021-07-29 19:51:52.581',12,'','నెస్టమ్ స్టేట్ 2',0,0,0),(546,1,'Nestum State3','Nestum State3','10542',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:52.739',NULL,'2021-07-29 19:51:52.739',12,'','రాష్ట్ర రాష్ట్రం 3',0,0,0),(547,1,'Britania Nice Biscuits','Britania Nice Biscuits','10543',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:52.981',NULL,'2021-07-29 19:51:52.981',12,'','బ్రిటానియా నైస్ బిస్కెట్స్',0,0,0),(548,1,'Lemon Salt','Lemon Salt','10544',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:53.304',NULL,'2021-07-29 19:51:53.304',12,'','నిమ్మకాయ ఉప్పు',0,0,0),(549,1,'Nippo','Nippo','10545',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:53.369',NULL,'2021-07-29 19:51:53.369',12,'','నిప్పో',0,0,0),(550,1,'Nippo High Power','Nippo High Power','10546',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:53.449',NULL,'2021-07-29 19:51:53.449',12,'','నిప్పో హై పవర్',0,0,0),(551,1,'Nupur Henna','Nupur Henna','10547',12.00,10.00,8.00,100,92,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:53.582',NULL,'2021-07-29 19:51:53.582',12,'','నూపర్ హన్నా',0,0,0),(552,1,'Nutri Choice','Nutri Choice','10548',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:53.810',NULL,'2021-07-29 19:51:53.810',12,'','న్యూట్ట్రో ఛాయిస్',0,0,0),(553,1,'Nutri Choice Oats','Nutri Choice Oats','10549',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:54.279',NULL,'2021-07-29 19:51:54.279',12,'','న్యూట్ట్ర ఛాయిస్ వోట్స్',0,0,0),(554,1,'Nycil Powder','Nycil Powder','10550',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:54.513',NULL,'2021-07-29 19:51:54.513',12,'','Nycil పౌడర్',0,0,0),(555,1,'Odonil Room Spray','Odonil Room Spray','10551',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:54.787',NULL,'2021-07-29 19:51:54.787',12,'','ఓడోనిల్ రూమ్ స్ప్రే',0,0,0),(556,1,'Old Spice','Old Spice','10552',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:55.244',NULL,'2021-07-29 19:51:55.244',12,'','ఓల్డ్ స్పైస్',0,0,0),(557,1,'Old Spice Lotioin','Old Spice Lotioin','10553',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:55.399',NULL,'2021-07-29 19:51:55.399',12,'','ఓల్డ్ స్పైస్ లోషన్',0,0,0),(558,1,'Olive Oil','Olive Oil','10554',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:55.492',NULL,'2021-07-29 19:51:55.492',12,'','ఆలివ్ ఆయిల్',0,0,0),(559,1,'Oral B Brush','Oral B Brush','10555',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:55.599',NULL,'2021-07-29 19:51:55.599',12,'','ఓరల్ B బ్రష్',0,0,0),(560,1,'Oral B Biscuits','Oral B Biscuits','10556',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:55.701',NULL,'2021-07-29 19:51:55.701',12,'','ఓరల్ బి బిస్కట్స్',0,0,0),(561,1,'Padmini','Padmini','10557',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:55.864',NULL,'2021-07-29 19:51:55.864',12,'','పద్మిని',0,0,0),(562,1,'Pampers','Pampers','10558',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:55.954',NULL,'2021-07-29 19:51:55.954',12,'','పెంపెర్స్',0,0,0),(563,1,'Panteen Saram','Panteen Saram','10559',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:56.301',NULL,'2021-07-29 19:51:56.301',12,'','పంటీన్ సరం',0,0,0),(564,1,'Panteen Shampoo','Panteen Shampoo','10560',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:56.565',NULL,'2021-07-29 19:51:56.565',12,'','పంటీన్ షాంపూ',0,0,0),(565,1,'Parachute','Parachute','10561',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:56.686',NULL,'2021-07-29 19:51:56.686',12,'','పారాచూట్',0,0,0),(566,1,'Parachute Aloevera','Parachute Aloevera','10562',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:56.797',NULL,'2021-07-29 19:51:56.797',12,'','పారాచూట్ అలోవెరా',0,0,0),(567,1,'Parachute Ayur','Parachute Ayur','10563',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:56.977',NULL,'2021-07-29 19:51:56.977',12,'','పారాచూట్ ఆయుర్',0,0,0),(568,1,'Parachute Jasmine','Parachute Jasmine','10564',12.00,10.00,8.00,100,92,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:57.204',NULL,'2021-07-29 19:51:57.204',12,'','పారాచూట్ జాస్మిన్',0,0,0),(569,1,'Parachute Pouch','Parachute Pouch','10565',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:57.552',NULL,'2021-07-29 19:51:57.552',12,'','పారాచూట్ పర్సు',0,0,0),(570,1,'Park Avenue','Park Avenue','10566',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:57.639',NULL,'2021-07-29 19:51:57.639',12,'','పార్క్ ఎవెన్యూ',0,0,0),(571,1,'Parle Bake Smith','Parle Bake Smith','10567',12.00,10.00,8.00,100,87,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:57.791',NULL,'2021-07-29 19:51:57.791',12,'','పార్లే బేక్ స్మిత్',0,0,0),(572,1,'Parle G','Parle G','10568',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:57.883',NULL,'2021-07-29 19:51:57.883',12,'','పార్లే జి',0,0,0),(573,1,'Pears','Pears','10569',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:57.979',NULL,'2021-07-29 19:51:57.979',12,'','పియర్స్ ',0,0,0),(574,1,'Pears Facewash','Pears Facewash','10570',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:58.284',NULL,'2021-07-29 19:51:58.284',12,'','పియర్స్ పేస్ వాష్',0,0,0),(575,1,'Pears Soap Set','Pears Soap Set','10571',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:58.455',NULL,'2021-07-29 19:51:58.455',12,'','పియర్స్ సోప్ సెట్',0,0,0),(576,1,'Pepsodent','Pepsodent','10572',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:58.545',NULL,'2021-07-29 19:51:58.545',12,'','పెప్సోదేంట్',0,0,0),(577,1,'Pepsodent Brush','Pepsonent Brush','10573',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:58.648',NULL,'2021-07-29 19:51:58.648',12,'','పెప్సోదేంట్ బ్రష్',0,0,0),(578,1,'Perk','Perk','10574',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:58.779',NULL,'2021-07-29 19:51:58.779',12,'','పెర్క్',0,0,0),(579,1,'Pillsbury Atta','Pillsbury Atta','10575',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:58.871',NULL,'2021-07-29 19:51:58.871',12,'','పిల్ల్స్బరీ అట్టా',0,0,0),(580,1,'Pillsbury Atta Multigrain','Pillsbury Atta Multigrain','10576',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:58.968',NULL,'2021-07-29 19:51:58.968',12,'','పిల్ల్స్బరీ అటా మల్టిగ్రెయిన్',0,0,0),(581,1,'Pista','Pista','10577',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:59.337',NULL,'2021-07-29 19:51:59.337',12,'','పిస్తా',0,0,0),(582,1,'Pitambari','Pitambari','10578',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:59.471',NULL,'2021-07-29 19:51:59.471',12,'','పీతంబరి',0,0,0),(583,1,'Ponds Dream','Ponds Dream','10579',12.00,10.00,8.00,100,92,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:59.566',NULL,'2021-07-29 19:51:59.566',12,'','పాండ్స్ డ్రీం',0,0,0),(584,1,'Ponds Facewash','Ponds Facewash','10580',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:59.658',NULL,'2021-07-29 19:51:59.658',12,'','పాండ్స్ పేస్ వాష్',0,0,0),(585,1,'Ponds Magic','Ponds Magic','10581',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:59.755',NULL,'2021-07-29 19:51:59.755',12,'','పాండ్స్ మేజిక్',0,0,0),(586,1,'Ponds Oil Control','Ponds Oil Control','10582',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:59.846',NULL,'2021-07-29 19:51:59.846',12,'','పాండ్స్ ఆయిల్ కంట్రోల్',0,0,0),(587,1,'Ponds Powder','Ponds Powder','10583',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:51:59.971',NULL,'2021-07-29 19:51:59.971',12,'','పాండ్స్ పౌడర్',0,0,0),(588,1,'Ponds W Beauty','Ponds W Beauty','10584',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:00.103',NULL,'2021-07-29 19:52:00.103',12,'','పాండ్స్ W బ్యూటీ',0,0,0),(589,1,'Pooja 500ml','Pooja 500ml','10585',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:00.287',NULL,'2021-07-29 19:52:00.287',12,'','పూజ 500ml',0,0,0),(590,1,'Pooja 1ltr','Pooja 1ltr','10586',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:00.557',NULL,'2021-07-29 19:52:00.557',12,'','పూజా 1ltr',0,0,0),(591,1,'Prill','Prill','10587',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:00.690',NULL,'2021-07-29 19:52:00.690',12,'','ప్రిల్',0,0,0),(592,1,'Priya Appalam','Priya Appalam','10588',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:00.836',NULL,'2021-07-29 19:52:00.836',12,'','ప్రియ అప్పలం',0,0,0),(593,1,'Priya Pickle','Priya Pickle','10589',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:00.930',NULL,'2021-07-29 19:52:00.930',12,'','ప్రియ పిక్లే',0,0,0),(594,1,'Priya Rice Oil','Priya Rice Oil','10590',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:01.083',NULL,'2021-07-29 19:52:01.083',12,'','ప్రియ రైస్ ఆయిల్',0,0,0),(595,1,'Protinex','Protinex','10591',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:01.268',NULL,'2021-07-29 19:52:01.268',12,'','ప్రోటీన్క్ష',0,0,0),(596,1,'Quaker Oats','Quaker Oats','10592',12.00,10.00,8.00,100,85,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:01.363',NULL,'2021-07-29 19:52:01.363',12,'','క్వేకర్ వోట్స్',0,0,0),(597,1,'Raagi Malt','Raagi Malt','10593',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:01.455',NULL,'2021-07-29 19:52:01.455',12,'','రాగి మాల్ట్',0,0,0),(598,1,'Rasna','Rasna','10594',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:01.588',NULL,'2021-07-29 19:52:01.588',12,'','రస్న',0,0,0),(599,1,'Rasna Orange','Rasna Orange','10595',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:01.796',NULL,'2021-07-29 19:52:01.796',12,'','రస్నఆరెంజ్',0,0,0),(600,1,'Red Lable','Red Lable','10596',12.00,10.00,8.00,100,83,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:01.996',NULL,'2021-07-29 19:52:01.996',12,'','రెడ్ లేబులే',0,0,0),(601,1,'Red Lable H Pack','Red Lable H Pack','10597',12.00,10.00,8.00,100,32,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:02.379',NULL,'2021-07-29 19:52:02.379',12,'','రెడ్ లేబుల్ H ప్యాక్',0,0,0),(602,1,'Red Lable Natural','Red Lable Natural','10598',12.00,10.00,8.00,100,85,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:02.540',NULL,'2021-07-29 19:52:02.540',12,'','రెడ్ లేబుల్ సహజ',0,0,0),(603,1,'Revive','Revive','10599',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:02.758',NULL,'2021-07-29 19:52:02.758',12,'','రివైవ్',0,0,0),(604,1,'Revive Liquid','Revive Liquid','10600',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:02.900',NULL,'2021-07-29 19:52:02.900',12,'','రివైవ్ లిక్విడ్',0,0,0),(605,1,'Revlon Charlie Spray','Revlon Charlie Spray','10601',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:03.104',NULL,'2021-07-29 19:52:03.104',12,'','రెవ్లాన్ చార్లీ స్ప్రే',0,0,0),(606,1,'Rexona Set','Rexona Set','10602',12.00,10.00,8.00,100,93,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:03.366',NULL,'2021-07-29 19:52:03.366',12,'','రెక్షొన సెట్',0,0,0),(607,1,'Rexona Soap','Rexona Soap','10603',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:03.466',NULL,'2021-07-29 19:52:03.466',12,'','రెక్షొన సోప్',0,0,0),(608,1,'Rin','Rin','10604',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:03.669',NULL,'2021-07-29 19:52:03.669',12,'','రిన్',0,0,0),(609,1,'Rin Ala','Rin Ala','10605',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:03.788',NULL,'2021-07-29 19:52:03.788',12,'','రిన్ అల',0,0,0),(610,1,'Rin Matic','Rin Matic','10606',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:03.921',NULL,'2021-07-29 19:52:03.921',12,'','రిన్ మాటిక్',0,0,0),(611,1,'Rin Powder','Rin Powder','10607',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:04.175',NULL,'2021-07-29 19:52:04.175',12,'','రిన్ పౌడర్',0,0,0),(612,1,'Robin','Robin','10608',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:04.315',NULL,'2021-07-29 19:52:04.315',12,'','రాబిన్',0,0,0),(613,1,'Robin Blue','Robin Blue','10609',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:04.565',NULL,'2021-07-29 19:52:04.565',12,'','రాబిన్ బ్లూ',0,0,0),(614,1,'Riya Room Spray','Riya Room Spray','10610',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:04.734',NULL,'2021-07-29 19:52:04.734',12,'','రియా రూమ్ స్ప్రే',0,0,0),(615,1,'Ruchi Gold','Ruchi Gold','10611',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:04.831',NULL,'2021-07-29 19:52:04.831',12,'','రుచి గోల్డ్',0,0,0),(616,1,'Britania Rusk','Britania Rusk','10612',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:04.914',NULL,'2021-07-29 19:52:04.914',12,'','బ్రిటానియా రస్క్',0,0,0),(617,1,'Saben Powder','Saben Powder','10613',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:05.008',NULL,'2021-07-29 19:52:05.008',12,'','సాబెన్ పౌడర్',0,0,0),(618,1,'Safe Wash','Safe Wash','10614',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:05.186',NULL,'2021-07-29 19:52:05.186',12,'','సేఫ్ వాష్',0,0,0),(619,1,'Saffola Gold','Saffola Gold','10615',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:05.281',NULL,'2021-07-29 19:52:05.281',12,'','సఫోల గోల్డ్',0,0,0),(620,1,'Saffola Tasty','Saffola Tasty','10616',12.00,10.00,8.00,100,76,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:05.374',NULL,'2021-07-29 19:52:05.374',12,'','సఫోల టేస్టీ',0,0,0),(621,1,'Samrani','Samrani','10617',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:05.481',NULL,'2021-07-29 19:52:05.481',12,'','సమ్రాని',0,0,0),(622,1,'Santoor Soap','Santoor Soap','10618',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:05.669',NULL,'2021-07-29 19:52:05.669',12,'','సంతూర్ సోప్',0,0,0),(623,1,'Santoor Baby Soap','Santoor Baby Soap','10619',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:05.741',NULL,'2021-07-29 19:52:05.741',12,'','సంతూర్ బేబీ సోప్',0,0,0),(624,1,'Santoor Glycerin','Santoor Glycerin','10620',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:05.874',NULL,'2021-07-29 19:52:05.874',12,'','సంతూర్ గ్లిసరిన్',0,0,0),(625,1,'Santoor Gold','Santoor Gold','10621',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:05.986',NULL,'2021-07-29 19:52:05.986',12,'','సంతూర్ గోల్డ్',0,0,0),(626,1,'Santoor Set','Santoor Set','10622',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:06.333',NULL,'2021-07-29 19:52:06.333',12,'','సంతూర్ సెట్',0,0,0),(627,1,'Sauce','Sauce','10623',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:06.441',NULL,'2021-07-29 19:52:06.441',12,'','సాస్',0,0,0),(628,1,'Savlon Hand Wash','Savlon Hand Wash','10624',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:06.533',NULL,'2021-07-29 19:52:06.533',12,'','సావ్లాన్ హ్యాండ్ వాష్',0,0,0),(629,1,'Sensodyne Brush','Sensodyne Brush','10625',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:06.640',NULL,'2021-07-29 19:52:06.640',12,'','సెన్సోడీ బ్రష్',0,0,0),(630,1,'Sensodyne Paste','Sensodyne Paste','10626',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:06.733',NULL,'2021-07-29 19:52:06.733',12,'','సెన్సిడన్ పేస్ట్',0,0,0),(631,1,'Sensora Paste','Sensora Paste','10627',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:06.869',NULL,'2021-07-29 19:52:06.869',12,'','సెన్సోరా పేస్ట్',0,0,0),(632,1,'Shower to Shower','Shower to Shower','10628',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:06.998',NULL,'2021-07-29 19:52:06.998',12,'','షవర్ టు షవర్',0,0,0),(633,1,'Snickers','Snickers','10629',12.00,10.00,8.00,100,97,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:07.450',NULL,'2021-07-29 19:52:07.450',12,'','స్నికెర్స్',0,0,0),(634,1,'Soap Box','Soap Box','10630',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:07.528',NULL,'2021-07-29 19:52:07.528',12,'','సబ్బు బాక్స్',0,0,0),(635,1,'Spinz Powder','Spinz Powder','10631',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:07.671',NULL,'2021-07-29 19:52:07.671',12,'','స్పిన్జ్ పౌడర్',0,0,0),(636,1,'Spinz Spray','Spinz Spray','10632',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:07.748',NULL,'2021-07-29 19:52:07.748',12,'','స్పిన్జ్ స్ప్రే',0,0,0),(637,1,'Sri Durga Pickle','Sri Durga Pickle','10633',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:07.922',NULL,'2021-07-29 19:52:07.922',12,'','శ్రీ దుర్గా పికెల్',0,0,0),(638,1,'Stayfree','Stayfree','10634',12.00,10.00,8.00,100,90,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:08.042',NULL,'2021-07-29 19:52:08.042',12,'','స్టే ఫ్రీ ఉండు',0,0,0),(639,1,'Subhalakshmi Turmeric','Subhalakshmi Turmeric','10635',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:08.265',NULL,'2021-07-29 19:52:08.265',12,'','సుభలక్ష్మి టర్మిరిక్',0,0,0),(640,1,'Subhra','Subhra','10636',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:08.464',NULL,'2021-07-29 19:52:08.464',12,'','సుభ్రా',0,0,0),(641,1,'Sundrop Blue','Sundrop Blue','10637',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:08.621',NULL,'2021-07-29 19:52:08.621',12,'','సన్ డ్రాప్ బ్లూ',0,0,0),(642,1,'Sundrop Heart','Sundrop Heart','10638',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:08.763',NULL,'2021-07-29 19:52:08.763',12,'','సన్ డ్రాప్ హార్ట్',0,0,0),(643,1,'Sundrop Peanut','Sundrop Peanut','10639',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:08.863',NULL,'2021-07-29 19:52:08.863',12,'','సన్ డ్రాప్ వేరుశెనగ',0,0,0),(644,1,'Sunfeast','Sunfeast','10640',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:08.964',NULL,'2021-07-29 19:52:08.964',12,'','సన్ ఫీస్ట్',0,0,0),(645,1,'Sunfeast Farmlite','Sunfeast Farmlite','10641',12.00,10.00,8.00,100,94,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:09.166',NULL,'2021-07-29 19:52:09.166',12,'','సన్ ఫీస్ట్ ఫార్మల్లైట్',0,0,0),(646,1,'Sunfeast Mom\'s Magic','Sunfeast Mom\'s Magic','10642',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:09.419',NULL,'2021-07-29 19:52:09.419',12,'','సన్ ఫీస్ట్ మామ్ మ్యాజిక్',0,0,0),(647,1,'Sunrise','Sunrise','10643',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:09.641',NULL,'2021-07-29 19:52:09.641',12,'','సన్రైజ్',0,0,0),(648,1,'Sunrise Saram','Sunrise Saram','10644',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:10.005',NULL,'2021-07-29 19:52:10.005',12,'','సన్రైజ్ సరం',0,0,0),(649,1,'Sunrise Jar','Sunrise Jar','10645',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:10.196',NULL,'2021-07-29 19:52:10.196',12,'','సన్రైజ్ జార్',0,0,0),(650,1,'Sunrise Strong','Sunrise Strong','10646',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:10.318',NULL,'2021-07-29 19:52:10.318',12,'','సన్రైజ్ స్ట్రాంగ్',0,0,0),(651,1,'Sunsilk Saram','Sunsilk Saram','10647',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:10.429',NULL,'2021-07-29 19:52:10.429',12,'','సన్సిల్క్ సరం',0,0,0),(652,1,'Sunsilk Shampoo','Sunsilk Shampoo','10648',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:10.507',NULL,'2021-07-29 19:52:10.507',12,'','సన్సిల్క్ షాంపూ',0,0,0),(653,1,'Supermax Blades','Supermax Blades','10649',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:10.617',NULL,'2021-07-29 19:52:10.617',12,'','సూపర్మాక్స్ బ్లేడ్స్',0,0,0),(654,1,'Surfexcel Bar','Surfexcel Bar','10650',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:10.728',NULL,'2021-07-29 19:52:10.728',12,'','సర్ఫ్ఎక్సెల్ బార్',0,0,0),(655,1,'Surfexcel Blue','Surfexcel Blue','10651',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:10.827',NULL,'2021-07-29 19:52:10.827',12,'','సర్ఫ్ఎక్సెల్ బ్లూ',0,0,0),(656,1,'Surfexcel Liquid','Surfexcel Liquid','10652',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:10.927',NULL,'2021-07-29 19:52:10.927',12,'','సర్ఫ్ఎక్సెల్ లిక్విడ్',0,0,0),(657,1,'Surfexcel MAT FL','Surfexcel MAT FL','10653',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:11.076',NULL,'2021-07-29 19:52:11.076',12,'','సర్ఫ్ఎక్సెల్ MAT FL',0,0,0),(658,1,'Surfexcel Quick Wash','Surfexcel Quick Wash','10654',12.00,10.00,8.00,100,86,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:11.293',NULL,'2021-07-29 19:52:11.293',12,'','సర్ఫ్ఎక్సెల్ ఆఫ్టర్ వాష్',0,0,0),(659,1,'Swasticks Pickle','Swasticks Pickle','10655',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:11.449',NULL,'2021-07-29 19:52:11.449',12,'','స్వస్తిక్స్ పికిల్',0,0,0),(660,1,'Taj Mahal','Taj Mahal','10656',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:11.606',NULL,'2021-07-29 19:52:11.606',12,'','తాజ్ మహల్',0,0,0),(661,1,'Tata Gold Tea','Tata Gold Tea','10657',12.00,10.00,8.00,100,96,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:11.748',NULL,'2021-07-29 19:52:11.748',12,'','టాటా గోల్డ్ టీ',0,0,0),(662,1,'Tata Grand Coffee','Tata Grand Coffee','10658',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:11.852',NULL,'2021-07-29 19:52:11.852',12,'','టాటా గ్రాండ్ కాఫీ',0,0,0),(663,1,'Tata Salt','Tata Salt','10659',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:11.938',NULL,'2021-07-29 19:52:11.938',12,'','టాటా ఉప్పు',0,0,0),(664,1,'Tetly','Tetly','10660',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:12.106',NULL,'2021-07-29 19:52:12.106',12,'','టేటిల్',0,0,0),(665,1,'Tetly Green Tea','Tetly Green Tea','10661',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:12.393',NULL,'2021-07-29 19:52:12.393',12,'','టేటిల్ గ్రీన్ టీ',0,0,0),(666,1,'Tetmosol Soap','Tetmosol Soap','10662',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:12.559',NULL,'2021-07-29 19:52:12.559',12,'','టెట్మోసోల్ సోప్',0,0,0),(667,1,'Tide','Tide','10663',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:12.745',NULL,'2021-07-29 19:52:12.745',12,'','టైడ్',0,0,0),(668,1,'Tissues','Tissues','10664',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:12.921',NULL,'2021-07-29 19:52:12.921',12,'','టిస్సుఎస్',0,0,0),(669,1,'Tounge Cleaner','Tounge Cleaner','10665',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:13.075',NULL,'2021-07-29 19:52:13.075',12,'','టంగ క్లీనర్',0,0,0),(670,1,'Tressemme Shampoo','Tressemme Shampoo','10666',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:13.388',NULL,'2021-07-29 19:52:13.388',12,'','టెస్సేమీ షాంపూ',0,0,0),(671,1,'Tressemme Saram','Tressemme Saram','10667',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:13.487',NULL,'2021-07-29 19:52:13.487',12,'','టెస్సేమ్మే సారం',0,0,0),(672,1,'Ujala','Ujala','10668',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:13.588',NULL,'2021-07-29 19:52:13.588',12,'','ఉజాలా',0,0,0),(673,1,'Ujala Stiff & Shine','Ujala Stiff & Shine','10669',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:13.809',NULL,'2021-07-29 19:52:13.809',12,'','ఉజాలా స్తిఫ్ఫ్ & షైన్',0,0,0),(674,1,'Universal Acid','Universal Acid','10670',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:13.977',NULL,'2021-07-29 19:52:13.977',12,'','యూనివర్సల్ యాసిడ్',0,0,0),(675,1,'Universal Phenoil','Universal Phenoil','10671',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:14.242',NULL,'2021-07-29 19:52:14.242',12,'','యూనివర్సల్ ఫినాయిల్',0,0,0),(676,1,'Universal Phenoil White','Universal Phenoil White','10672',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:14.450',NULL,'2021-07-29 19:52:14.450',12,'','యూనివర్సల్ ఫినాయిల్ వైట్',0,0,0),(677,1,'Vanish Liquid','Vanish Liquid','10673',12.00,10.00,8.00,100,93,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:14.586',NULL,'2021-07-29 19:52:14.586',12,'','వాణిశ్ లిక్విడ్',0,0,0),(678,1,'Vanish Powder','Vanish Powder','10674',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:14.706',NULL,'2021-07-29 19:52:14.706',12,'','వాణిశ్ పౌడర్',0,0,0),(679,1,'Vaselene','Vaselene','10675',12.00,10.00,8.00,100,98,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:14.787',NULL,'2021-07-29 19:52:14.787',12,'','వస్లేనే',0,0,0),(680,1,'Vasmol','Vasmol','10676',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:14.963',NULL,'2021-07-29 19:52:14.963',12,'','వాస్మోల్',0,0,0),(681,1,'Vathulu','Vathulu','10677',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:15.367',NULL,'2021-07-29 19:52:15.367',12,'','వాతులు',0,0,0),(682,1,'Vatika Shampoo','Vatika Shampoo','10678',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:15.712',NULL,'2021-07-29 19:52:15.712',12,'','వాటికా షాంపూ',0,0,0),(683,1,'Veneger','Veneger','10679',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:15.885',NULL,'2021-07-29 19:52:15.885',12,'','వేనేజర్',0,0,0),(684,1,'Vermicelli Bambino','Vermicelli Bambino','10680',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:15.986',NULL,'2021-07-29 19:52:15.986',12,'','వెర్మిసెల్లి బాంబినో',0,0,0),(685,1,'Vermicelli MTR','Vermicelli MTR','10681',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:16.395',NULL,'2021-07-29 19:52:16.395',12,'','వెర్మిసెల్లి MTR',0,0,0),(686,1,'Vicco Powder','Vicco Powder','10682',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:16.826',NULL,'2021-07-29 19:52:16.826',12,'','వికో పౌడర్',0,0,0),(687,1,'Vicco Paste','Vicco Paste','10683',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:17.195',NULL,'2021-07-29 19:52:17.195',12,'','వికో పేస్ట్',0,0,0),(688,1,'Vicco Turmeric','Vicco Turmeric','10684',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:17.294',NULL,'2021-07-29 19:52:17.294',12,'','వికో పసుపు',0,0,0),(689,1,'Vicks','Vicks','10685',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:17.394',NULL,'2021-07-29 19:52:17.394',12,'','విక్స్',0,0,0),(690,1,'Vijaya Groundnut Oil','Vijaya Groundnut Oil','10686',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:17.560',NULL,'2021-07-29 19:52:17.560',12,'','విజయ్ గ్రౌండ్ నట్ ఆయిల్',0,0,0),(691,1,'Vijaya SF Oil','Vijaya SF Oil','10687',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:17.680',NULL,'2021-07-29 19:52:17.680',12,'','విజయా SF ఆయిల్',0,0,0),(692,1,'Vim','Vim','10688',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:17.901',NULL,'2021-07-29 19:52:17.901',12,'','విమ',0,0,0),(693,1,'Vim Liquid','Vim Liquid','10689',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:18.013',NULL,'2021-07-29 19:52:18.013',12,'','విమ్ లిక్విడ్',0,0,0),(694,1,'Vivel Soap','Vivel Soap','10690',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:18.156',NULL,'2021-07-29 19:52:18.156',12,'','వివెల్ సోప్',0,0,0),(695,1,'Wheel','Wheel','10691',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:18.621',NULL,'2021-07-29 19:52:18.621',12,'','వీల్',0,0,0),(696,1,'XXX Soap','XXX Soap','10692',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:18.821',NULL,'2021-07-29 19:52:18.821',12,'','XXX సోప్',0,0,0),(697,1,'XXX Surf','XXX Surf','10693',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:19.000',NULL,'2021-07-29 19:52:19.000',12,'','XXX సర్ఫ్',0,0,0),(698,1,'Yardley','Yardley','10694',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:19.177',NULL,'2021-07-29 19:52:19.177',12,'','యర్డ్లేయ్',0,0,0),(699,1,'Yardley Powder','Yardley Powder','10695',12.00,10.00,8.00,100,99,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:19.421',NULL,'2021-07-29 19:52:19.421',12,'','యార్డ్లీ పౌడర్',0,0,0),(700,1,'Yardley Soap','Yardley Soap','10696',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:19.675',NULL,'2021-07-29 19:52:19.675',12,'','యార్డ్లీ సోప్',0,0,0),(701,1,'Yippee Noodle','Yippee Noodle','10697',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:19.776',NULL,'2021-07-29 19:52:19.776',12,'','యిప్పీ నూడుల్',0,0,0),(702,1,'Zandubalm','Zandubalm','10698',12.00,10.00,8.00,100,100,'rs',0.00,'2021-07-29',1,'ravi','2021-07-29 19:52:19.921',NULL,'2021-07-29 19:52:19.921',12,'','జండుబాం',0,0,0),(703,1,'Mobile','','377',5000.00,3333.33,3500.00,100,100,'',0.00,NULL,1,'ravi','2021-10-01 18:17:42.466','ravi','2021-10-01 18:33:33.000',1,'','',0,0,0),(704,1,'lemon','orange','5552',261.00,90.91,50.00,120,119,'',0.00,NULL,1,'ravi','2021-10-08 15:23:23.026',NULL,'2021-10-08 15:23:23.026',2,'','레몬',0,0,0),(705,1,'Tab','Tablet','5845',1300.00,363.64,300.00,30,30,'',0.00,NULL,1,'ravi','2021-10-08 15:26:01.788',NULL,'2021-10-08 15:26:01.788',2,'','탭',0,0,0),(706,1,'Handwash','','2010',100.00,80.00,70.00,4000,4000,'',0.00,NULL,1,'ravi','2021-10-08 15:39:43.128',NULL,'2021-10-08 15:39:43.128',NULL,'','',0,0,0),(707,1,'test','test','9009',50.00,40.00,30.00,965,965,NULL,0.00,NULL,1,'ravi2','2021-10-31 16:11:20.390',NULL,'2021-10-31 16:11:20.390',NULL,'58785','test',0,0,0);
/*!40000 ALTER TABLE `tbl_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_languages`
--

DROP TABLE IF EXISTS `tbl_languages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_languages` (
  `language_code` varchar(7) NOT NULL,
  `language_name` varchar(45) NOT NULL,
  PRIMARY KEY (`language_code`),
  UNIQUE KEY `language_name_UNIQUE` (`language_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_languages`
--

LOCK TABLES `tbl_languages` WRITE;
/*!40000 ALTER TABLE `tbl_languages` DISABLE KEYS */;
INSERT INTO `tbl_languages` VALUES ('bn','Bengali'),('en','Engilish'),('hi','Hindi'),('kn','Kannada'),('ta','Tamil'),('te','Telugu');
/*!40000 ALTER TABLE `tbl_languages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_lgrpt`
--

DROP TABLE IF EXISTS `tbl_lgrpt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_lgrpt` (
  `lg_id` bigint NOT NULL AUTO_INCREMENT,
  `userid` varchar(150) DEFAULT NULL,
  `lg_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `apk_version_code` int DEFAULT NULL,
  `is_biometric_auth` int NOT NULL,
  PRIMARY KEY (`lg_id`),
  KEY `idx_lgrpt_userid` (`userid`),
  KEY `idx_lgrpt_userid_is_active` (`userid`),
  CONSTRAINT `fk_lgrpt_userid` FOREIGN KEY (`userid`) REFERENCES `tbl_users` (`emp_user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_lgrpt`
--

LOCK TABLES `tbl_lgrpt` WRITE;
/*!40000 ALTER TABLE `tbl_lgrpt` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_lgrpt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_locality`
--

DROP TABLE IF EXISTS `tbl_locality`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_locality` (
  `locality_id` bigint NOT NULL AUTO_INCREMENT,
  `locality_name` varchar(100) NOT NULL,
  `is_active` int NOT NULL DEFAULT '1',
  `city_id` bigint NOT NULL,
  PRIMARY KEY (`locality_id`),
  UNIQUE KEY `locality_name_UNIQUE` (`locality_name`),
  KEY `fk_loc_cityid_idx` (`city_id`),
  CONSTRAINT `fk_loc_cityid` FOREIGN KEY (`city_id`) REFERENCES `tbl_cities` (`city_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1956 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_locality`
--

LOCK TABLES `tbl_locality` WRITE;
/*!40000 ALTER TABLE `tbl_locality` DISABLE KEYS */;
INSERT INTO `tbl_locality` VALUES (1,'Nellore',1,1),(2,'Kavali',1,1),(5,'Hyderabad',1,1),(6,'Ongole',1,1),(46,'S.R Nagar',1,14),(47,'koti',1,14),(48,'Kondapuram',1,14),(49,'Abbedoddi',1,16),(50,'Adadakulapalle',1,16),(51,'Adivigollapalle',1,16),(52,'Agali',1,16),(53,'Agraharam',1,16),(54,'Agraharampalle',1,16),(55,'Akkagaladevarahalli',1,16),(56,'Akkajampalle',1,16),(57,'Akuledu',1,16),(58,'Alampur',1,16),(59,'Alamuru',1,16),(60,'Allapalle',1,16),(61,'Allugundu',1,16),(62,'Alur',1,16),(63,'Amadagur',1,16),(64,'Amagondapalem',1,16),(65,'Amalladinne',1,16),(66,'Amarapuram',1,16),(67,'Ameenpalle',1,16),(68,'Amidala',1,16),(69,'Amidalagondi',1,16),(70,'Anandaraopeta',1,16),(71,'Anantapur',1,16),(72,'Anantapur Rural',1,16),(73,'Aniganidoddi',1,16),(74,'Ankampalle',1,16),(75,'Ankampeta',1,16),(76,'Anumpalle',1,16),(77,'Appajipeta',1,16),(78,'Apparacheruvu',1,16),(79,'Appecherla',1,16),(80,'Appilepalle',1,16),(81,'Arakativemula',1,16),(82,'Aravedu',1,16),(83,'Arkabhavipalle',1,16),(84,'Athiralladinne',1,16),(85,'Atmakur',1,16),(86,'Avuladatla',1,16),(87,'Avulampalle',1,16),(88,'Avulenna',1,16),(89,'Ayyagarlapalle',1,16),(90,'Ayyavaripalle',1,16),(91,'B.Pappuru',1,16),(92,'Bachchupalle',1,16),(93,'Baginayakana Halli',1,16),(94,'Balasamudram',1,16),(95,'Bandameedapalle',1,16),(96,'Bandarlapalle',1,16),(97,'Bandlapalle',1,16),(98,'Bandur',1,16),(99,'Basapuram',1,16),(100,'Basavanahalli',1,16),(101,'Basinepalle',1,16),(102,'Bathalapalle',1,16),(103,'Bayanakuntapalle',1,16),(104,'Bedrahalli',1,16),(105,'Beechiganipalle',1,16),(106,'Beedupalle',1,16),(107,'Belodu',1,16),(108,'Beluguppa',1,16),(109,'Bennikal',1,16),(110,'Bestharapalle',1,16),(111,'Bethapalle',1,16),(112,'Bevina Halli',1,16),(113,'Bhairasamudram',1,16),(114,'Bhogasamudram',1,16),(115,'Bhupasamudram',1,16),(116,'Bhyravanithippa',1,16),(117,'Bidurukontham',1,16),(118,'Bodaipalle',1,16),(119,'Bodiganidoddi',1,16),(120,'Bojjireddipalle',1,16),(121,'Bokkasampalle',1,16),(122,'Bollanaguddam',1,16),(123,'Bommagundanahalli',1,16),(124,'Bommanahal',1,16),(125,'Bommaparthy',1,16),(126,'Bondaladinne',1,16),(127,'Bondalawada',1,16),(128,'Bondankal',1,16),(129,'Bonthalapalle',1,16),(130,'Boppepalle',1,16),(131,'Boyalapalle',1,16),(132,'Brahmadevaramarri',1,16),(133,'Brahmana Yaleru',1,16),(134,'Brahmanapalle',1,16),(135,'Brahmasamudram',1,16),(136,'Bramhanapalle',1,16),(137,'Bucharla',1,16),(138,'Budagavi',1,16),(139,'Budanampalle',1,16),(140,'Buddareddipalle',1,16),(141,'Buddepalle',1,16),(142,'Budedu',1,16),(143,'Budigumma',1,16),(144,'Budili',1,16),(145,'Buganipalle',1,16),(146,'Bukkacherla',1,16),(147,'Bukkapatnam',1,16),(148,'Bukkapuram',1,16),(149,'Bukkarayasamudram',1,16),(150,'Bullasamudram',1,16),(151,'Bussaiahgaripalle',1,16),(152,'Byrapuram',1,16),(153,'C.Kodigepalle',1,16),(154,'Chabala',1,16),(155,'Chadam',1,16),(156,'Chagallu',1,16),(157,'Chagaluru',1,16),(158,'Chagapuram',1,16),(159,'Chakrayapeta',1,16),(160,'Chalakur',1,16),(161,'Chalamakuntapalle',1,16),(162,'Chalavemula',1,16),(163,'Chalivendala',1,16),(164,'Challapalle',1,16),(165,'Challavaripalle',1,16),(166,'Chamachenubylu',1,16),(167,'Chamalagondi',1,16),(168,'Chamaluru',1,16),(169,'Chandakacherela',1,16),(170,'Chandana',1,16),(171,'Chapiri',1,16),(172,'Charupalle',1,16),(173,'Chathram',1,16),(174,'Chedulla',1,16),(175,'Cheekalaguriki',1,16),(176,'Cheekatimanipalle',1,16),(177,'Cheekirevulapalle',1,16),(178,'Cheelapalle',1,16),(179,'Chelimenahalli',1,16),(180,'Chennampalle',1,16),(181,'Chennapuram',1,16),(182,'Chennarayapatnam',1,16),(183,'Chennarayunipalle',1,16),(184,'Chennavaram',1,16),(185,'Chennekothapalle',1,16),(186,'Cherlopalle',1,16),(187,'Cherlopalli',1,16),(188,'Cherukur',1,16),(189,'Chetnepalli',1,16),(190,'Chigathurpi',1,16),(191,'Chigicherla',1,16),(192,'Chilamakuru',1,16),(193,'Chilamathur',1,16),(194,'Chillavaripalle',1,16),(195,'Chinaganipalle',1,16),(196,'Chinna Hothur',1,16),(197,'Chinna Musturu',1,16),(198,'Chinnachigullarevu',1,16),(199,'Chinnakotla',1,16),(200,'Chinnamallepalle',1,16),(201,'Chinnamanthur',1,16),(202,'Chinnapolamada',1,16),(203,'Chinnaramannagaripalle',1,16),(204,'Chinnavadugur',1,16),(205,'Chinnayakkaluru',1,16),(206,'Chintacheruvu',1,16),(207,'Chintakunta',1,16),(208,'Chintalapalle',1,16),(209,'Chintarlapalle',1,16),(210,'Chippalamadugu',1,16),(211,'Chitrachedu',1,16),(212,'Chitturu',1,16),(213,'Chiyyedu',1,16),(214,'Cholasamudram',1,16),(215,'Cholemarri',1,16),(216,'Chowdireddipalle',1,16),(217,'Chowlur',1,16),(218,'Chowtakuntapalle',1,16),(219,'Chukkalur',1,16),(220,'D.Cherlopalle',1,16),(221,'D.Hirehal',1,16),(222,'D.Honnur',1,16),(223,'D.Kondapuram',1,16),(224,'Daburuvaripalle',1,16),(225,'Dadalur',1,16),(226,'Dademvaripalle',1,16),(227,'Dadithota',1,16),(228,'Dampetla',1,16),(229,'Dancherla',1,16),(230,'Danduvaripalle',1,16),(231,'Darsimala',1,16),(232,'Demakethepalle',1,16),(233,'Devanuppalapadu',1,16),(234,'Devaragudipalle',1,16),(235,'Devarapalle',1,16),(236,'Devulacheruvu',1,16),(237,'Dhaniyanicheruvu',1,16),(238,'Dharmapuram',1,16),(239,'Dharmavaram',1,16),(240,'Diguvamandalapalle',1,16),(241,'Diguvapalle',1,16),(242,'Dimmagudi',1,16),(243,'Dodagatta',1,16),(244,'Dodderi',1,16),(245,'Donekal',1,16),(246,'Donimukkala',1,16),(247,'Donnikota',1,16),(248,'Dorigallu',1,16),(249,'Dosaledu',1,16),(250,'Dosaludiki',1,16),(251,'Duddebanda',1,16),(252,'Duddekunta',1,16),(253,'Duggumarri',1,16),(254,'Duradakunta',1,16),(255,'Durgam',1,16),(256,'East Kodipalle',1,16),(257,'Eddulapalle',1,16),(258,'Edigavaripalle',1,16),(259,'Edula Mustur',1,16),(260,'Edulabalapuram',1,16),(261,'Edurudona',1,16),(262,'Edurur',1,16),(263,'Elakkuntla',1,16),(264,'Elanji',1,16),(265,'Ellareddipalle',1,16),(266,'Ellutla',1,16),(267,'Elukuntla',1,16),(268,'Engilibanda',1,16),(269,'Eradikera',1,16),(270,'Erragudi',1,16),(271,'Erramanchi',1,16),(272,'Eswarapalle',1,16),(273,'Ethodu',1,16),(274,'G. Venkatampalle',1,16),(275,'Gade Hothur',1,16),(276,'Gadekal',1,16),(277,'Gadidamvaripalle',1,16),(278,'Gajarampalle',1,16),(279,'Galagala',1,16),(280,'Ganapathipalle',1,16),(281,'Gandladinne',1,16),(282,'Gandlapadu',1,16),(283,'Gandlaparthi',1,16),(284,'Gandlapenta',1,16),(285,'Gandlavandlapalle',1,16),(286,'Gangadevipalle',1,16),(287,'Gangampalle',1,16),(288,'Gangavaram',1,16),(289,'Ganginepalle',1,16),(290,'Gangulakunta',1,16),(291,'Ganigera',1,16),(292,'Ganjikunta',1,16),(293,'Ganthimarri',1,16),(294,'Gariselapalle',1,16),(295,'Garladinne',1,16),(296,'Garudachedu',1,16),(297,'Garudapuram',1,16),(298,'Goddumarri',1,16),(299,'Godduvelagala',1,16),(300,'Golla',1,16),(301,'Gollapalle',1,16),(302,'Gollapuram',1,16),(303,'Gondipalle',1,16),(304,'Gondireddipalle',1,16),(305,'Gonipeta',1,16),(306,'Gootibylu',1,16),(307,'Gooty',1,16),(308,'Gooty (CT)',1,16),(309,'Gooty (Rural)',1,16),(310,'Gooty Ananta Puram',1,16),(311,'Gopepalle',1,16),(312,'Gorantla',1,16),(313,'Goridindla',1,16),(314,'Gotlur',1,16),(315,'Gotukur',1,16),(316,'Govindapalle',1,16),(317,'Govindapuram',1,16),(318,'Govindawada',1,16),(319,'Gowdanahalli',1,16),(320,'Gowkanapalle',1,16),(321,'Gowrivaripalle',1,16),(322,'Gramadatla',1,16),(323,'Gudibanda',1,16),(324,'Gudipadu',1,16),(325,'Gudipalle',1,16),(326,'Gugudu',1,16),(327,'Gulapalem',1,16),(328,'Gulimikondla @ G.Kottala',1,16),(329,'Gulyam',1,16),(330,'Gummagatta',1,16),(331,'Gundala',1,16),(332,'Gundiganihalli',1,16),(333,'Gunimorubagal',1,16),(334,'Gunipalle',1,16),(335,'Gunjepalle',1,16),(336,'Guntakal',1,16),(337,'Guntakal (R)',1,16),(338,'Gurrambailu',1,16),(339,'Gutturu',1,16),(340,'H.Hossahalli',1,16),(341,'H.Siddapuram',1,16),(342,'Halukuru',1,16),(343,'Hampapuram',1,16),(344,'Hanakanahal',1,16),(345,'Hanchanahal',1,16),(346,'Haresamudram',1,16),(347,'Havaligi',1,16),(348,'Haveli Sodanapalle',1,16),(349,'Hemavathi',1,16),(350,'HINDUPUR',1,16),(351,'Hirdehal',1,16),(352,'Hulikal',1,16),(353,'Hulikera',1,16),(354,'Hulikeradevarahalli',1,16),(355,'Husenapuram',1,16),(356,'Hussainpuram',1,16),(357,'Igudur',1,16),(358,'Illuru',1,16),(359,'Inagalore',1,16),(360,'Inagalur',1,16),(361,'Indravathi',1,16),(362,'Ipperu',1,16),(363,'Iragampalle',1,16),(364,'Itikalapalle',1,16),(365,'Jadrahalli',1,16),(366,'Jagarajupalle',1,16),(367,'Jajarakal',1,16),(368,'Jakkalacheruvu',1,16),(369,'Jakkasamudram',1,16),(370,'Jambugumpala',1,16),(371,'Jambuladinne',1,16),(372,'Jambulapadu',1,16),(373,'Jangalapalle',1,16),(374,'Janthulur',1,16),(375,'Jarutla Rampuram',1,16),(376,'Jayapuram',1,16),(377,'Jeenulakunta',1,16),(378,'Jodidharmapuram',1,16),(379,'Jogannapeta',1,16),(380,'Jonnalakothapalle',1,16),(381,'Joolakalva',1,16),(382,'Jowkalakothapalle',1,16),(383,'Jowkuledudinne',1,16),(384,'Julukunta',1,16),(385,'Junjurampalle',1,16),(386,'Jutur',1,16),(387,'K.Locharla',1,16),(388,'Kacharlakunta',1,16),(389,'Kadadarabenchi',1,16),(390,'Kadalur',1,16),(391,'Kadavakallu',1,16),(392,'Kadirepalle',1,16),(393,'Kadiri',1,16),(394,'Kadiri Brahmanapalle',1,16),(395,'Kadiridevarapalle',1,16),(396,'Kadirikuntlapalle',1,16),(397,'Kadiripulakunta',1,16),(398,'Kaki',1,16),(399,'Kakkalapalle (CT)',1,16),(400,'Kalagalla',1,16),(401,'Kalapuram',1,16),(402,'Kalasamudram',1,16),(403,'Kalekurthi',1,16),(404,'Kalipi',1,16),(405,'Kalludevanahalli',1,16),(406,'Kallumadi',1,16),(407,'Kallumarri',1,16),(408,'Kallur',1,16),(409,'Kalluru',1,16),(410,'Kalluru Agraharam',1,16),(411,'Kalugodu',1,16),(412,'Kalvapalle',1,16),(413,'Kalyandurg',1,16),(414,'Kamalapadu',1,16),(415,'Kamarupalle',1,16),(416,'Kamathampalle',1,16),(417,'Kambadur',1,16),(418,'Kambaladinne',1,16),(419,'Kammavaripalle',1,16),(420,'Kamthanahalli',1,16),(421,'Kamuru',1,16),(422,'Kanaganapalle',1,16),(423,'Kanampalle',1,16),(424,'Kanchisamudram',1,16),(425,'Kandakur',1,16),(426,'Kandikapula',1,16),(427,'Kandlaguduru',1,16),(428,'Kandlapalle',1,16),(429,'Kanekal',1,16),(430,'Kanisettipalle',1,16),(431,'Kannepalle',1,16),(432,'Kanugamakulapalle',1,16),(433,'Kanumukkala',1,16),(434,'Kappala Banda',1,16),(435,'Karadikonda',1,16),(436,'Karakamukkala',1,16),(437,'Karesankanahalli',1,16),(438,'Kariganipalle',1,16),(439,'Karikera',1,16),(440,'Karinireddipalle',1,16),(441,'Karnatakampalle',1,16),(442,'Karthanaparthi',1,16),(443,'Kasapuram',1,16),(444,'Kassamudram',1,16),(445,'Katepalle',1,16),(446,'Katiganikalva',1,16),(447,'Katrimala',1,16),(448,'Kaverisamudram',1,16),(449,'Kekathi',1,16),(450,'Kesapuram',1,16),(451,'Kesavapuram',1,16),(452,'Kethaganicheruvu',1,16),(453,'Khadarpeta',1,16),(454,'Khairevu',1,16),(455,'Kirikera',1,16),(456,'Kodapaganipalle',1,16),(457,'Kodavandlapalle',1,16),(458,'Kodigenahalli',1,16),(459,'Kodihalli',1,16),(460,'Kodikonda',1,16),(461,'Kodimi',1,16),(462,'Kodumurthy',1,16),(463,'Kodur',1,16),(464,'Kogira',1,16),(465,'Kojjepalle',1,16),(466,'Kokkanti',1,16),(467,'Kolaganahalli',1,16),(468,'Komali',1,16),(469,'Komatikuntla',1,16),(470,'Konakondla',1,16),(471,'Konampalle',1,16),(472,'Konapuram',1,16),(473,'Kondagattupalle',1,16),(474,'Kondakamarla',1,16),(475,'Kondakinda Agraharam',1,16),(476,'Kondamanayanipalem',1,16),(477,'Kondampalle',1,16),(479,'Kondur',1,16),(480,'Konduru',1,16),(481,'Konetinayanipalyam',1,16),(482,'Konganapalle',1,16),(483,'Konkallu',1,16),(484,'Kontanapalli',1,16),(485,'Konuppalapadu',1,16),(486,'Koppalakonda',1,16),(487,'Korivipalle',1,16),(488,'Korrakodu',1,16),(489,'Korrapadu',1,16),(490,'Korthikota',1,16),(491,'Kotanka',1,16),(492,'Kotapalle',1,16),(493,'Kothacheruvu',1,16),(494,'Kothakota',1,16),(495,'Kothalam',1,16),(496,'Kothapalle',1,16),(497,'Kothapeta',1,16),(498,'Kotipi',1,16),(499,'Kotlapalle',1,16),(500,'KOTNUR',1,16),(501,'Kowlepalle',1,16),(502,'Krishnapuram',1,16),(503,'Kristipadu',1,16),(504,'Kudair',1,16),(505,'Kudulur',1,16),(506,'Kumbaranagehalli',1,16),(507,'Kummanamala',1,16),(508,'Kummetha',1,16),(509,'Kundanakota',1,16),(510,'Kundurpi',1,16),(511,'Kuntimaddi',1,16),(512,'Kunukuntla',1,16),(513,'Kunuthuru (R)',1,16),(514,'Kurakulapalle',1,16),(515,'Kurli',1,16),(516,'Kurubarahalli',1,16),(517,'Kurugunta',1,16),(518,'Kurumala',1,16),(519,'Kurumamidi',1,16),(520,'Kuruvalli',1,16),(521,'KUTAGULLA',1,16),(522,'Lakkasamudram',1,16),(523,'Lakshmanpalle',1,16),(524,'Lakshmipuram',1,16),(525,'Lathavaram',1,16),(526,'Lepakshi',1,16),(527,'Lingamanahalli',1,16),(528,'Lingareddipalle',1,16),(529,'Lokojipalle',1,16),(530,'Lolur',1,16),(531,'M.Rayapuram',1,16),(532,'Madakasira',1,16),(533,'Maddalacheruvu',1,16),(534,'Maddimadugu',1,16),(535,'Maddinayanipalem',1,16),(536,'Maddivarigondi',1,16),(537,'Madenahalli',1,16),(538,'Madhudi',1,16),(539,'Madigubba',1,16),(540,'Madugupalle',1,16),(541,'Maduguvanigondi',1,16),(542,'Magecheruvu',1,16),(543,'Makkinavaripalle',1,16),(544,'Malakavemula',1,16),(545,'Malameedapalle',1,16),(546,'Malapanagudi',1,16),(547,'Malapuram',1,16),(548,'Malayanur',1,16),(549,'Mallagundla',1,16),(550,'Mallakalva',1,16),(551,'Mallapalle',1,16),(552,'Mallapuram',1,16),(553,'Mallenipalle',1,16),(554,'Mallepalle',1,16),(555,'Mallinayakanahalli',1,16),(556,'Malreddipalle',1,16),(557,'Maluguru',1,16),(558,'Malyam',1,16),(559,'Malyavantham',1,16),(560,'Mamadur',1,16),(561,'Mandalahalli',1,16),(562,'Mandalapalle',1,16),(563,'Mandli',1,16),(564,'Manepalle',1,16),(565,'Manesamudram',1,16),(566,'Mangalamadaka',1,16),(567,'Manirevu',1,16),(568,'Mannila',1,16),(569,'Manur',1,16),(570,'Marakuntapalle',1,16),(571,'Marala',1,16),(572,'Maravapalle Agraharam',1,16),(573,'Maredipalle',1,16),(574,'Marnepalle',1,16),(575,'Maroor',1,16),(576,'Marrikommadinne',1,16),(577,'Marrimakulapalle',1,16),(578,'Marthadu',1,16),(579,'Marutla',1,16),(580,'Matlagondi',1,16),(581,'Mavaturu',1,16),(582,'Mavinamardhanahalli',1,16),(583,'Mechiri',1,16),(584,'Medapuram',1,16),(585,'Medimakulapalle',1,16),(586,'Medukurthy',1,16),(587,'Meenahalli',1,16),(588,'Mekalacheruvu',1,16),(589,'Melavoi',1,16),(590,'Miduthuru',1,16),(591,'Moda',1,16),(592,'Mohammadabad',1,16),(593,'Molakathalla',1,16),(594,'Mopidi',1,16),(595,'Morasalapalle',1,16),(596,'Morubagal',1,16),(597,'Motarchintalapalle',1,16),(598,'Motukapalle',1,16),(599,'Muchukota',1,16),(600,'Muddinayanapalle',1,16),(601,'Muddireddipalle',1,16),(602,'Mudigal',1,16),(603,'Mudigubba',1,16),(604,'Mudupalajuvi',1,16),(605,'Mukkandlavarikothapalle',1,16),(606,'Mukthapuram',1,16),(607,'Mulakalacheruvu',1,16),(608,'Mulakaledu',1,16),(609,'Mulakanur',1,16),(610,'Mundlavaripalle',1,16),(611,'Munimadugu',1,16),(612,'Muntimadugu',1,16),(613,'Muppalagutti',1,16),(614,'Muradi',1,16),(615,'Mustikovila',1,16),(616,'Muthavakuntla',1,16),(617,'Muthukur',1,16),(618,'Muthyalacheruvu',1,16),(619,'Mydugolam',1,16),(620,'Mylarampalle',1,16),(621,'Mylasamudram',1,16),(622,'N.Hanumapuram',1,16),(623,'N.Thimmapuram',1,16),(624,'Nadimidoddi',1,16),(625,'Nadimpalle',1,16),(626,'Nagalapuram',1,16),(627,'Nagalur',1,16),(628,'Nagareddipalle',1,16),(629,'Nagarur',1,16),(630,'Nagasamudram',1,16),(631,'Naginayanicheruvu',1,16),(632,'Nagireddipalle',1,16),(633,'Nakkalagutta Palle',1,16),(634,'Nakkalapalle',1,16),(635,'Nakkanadoddi',1,16),(636,'Nallacheruvu',1,16),(637,'Nallamada',1,16),(638,'Nallur',1,16),(639,'Nambulipulikunta',1,16),(640,'Nandalapadu (R)',1,16),(641,'Naranagepalle',1,16),(642,'Narasambhotlapalle',1,16),(643,'Narasambudi',1,16),(644,'Narasampalle',1,16),(645,'Narasapuram',1,16),(646,'Narayanapuram (CT)',1,16),(647,'Naremuddapalle',1,16),(648,'Narepalle',1,16),(649,'Narinjagundlapalle',1,16),(650,'Narpala',1,16),(651,'Narsapuram',1,16),(652,'Nasanakota',1,16),(653,'Neelur',1,16),(654,'Nelagonda',1,16),(655,'Nelakota',1,16),(656,'Nemakallu',1,16),(657,'Nemallapalle',1,16),(658,'Nerimetla',1,16),(659,'Nidhanawada',1,16),(660,'Nidigallu',1,16),(661,'Nidimamidi',1,16),(662,'Nidragatta',1,16),(663,'Nijavalli',1,16),(664,'Nimbagal',1,16),(665,'Nittoor',1,16),(666,'Nitturu',1,16),(667,'Nuthanakalva',1,16),(668,'Nuthimadugu',1,16),(669,'Nyamaddala',1,16),(670,'Obuladevaracheruvu',1,16),(671,'Obulapuram',1,16),(672,'Obulareddipalle',1,16),(673,'Odulapalle',1,16),(674,'Oravoy',1,16),(675,'P. Byadigera',1,16),(676,'Padamatiyaleru',1,16),(677,'Pakeerupalle',1,16),(678,'Palacherla',1,16),(679,'Palasamudram',1,16),(680,'Palavoy',1,16),(681,'Pallur',1,16),(682,'Palthur',1,16),(683,'Palyam',1,16),(684,'Pamidi',1,16),(685,'Pamudurthi',1,16),(686,'Pandikunta',1,16),(687,'Pandiparthi',1,16),(688,'Pandulakunta',1,16),(689,'Panthulacheruvu',1,16),(690,'Papampeta',1,16),(691,'Parigi',1,16),(692,'Pasalur',1,16),(693,'Patha Kadamalakunta',1,16),(694,'Patha Kothachervu',1,16),(695,'Pathapalle',1,16),(696,'Patnam',1,16),(697,'Pedaballi',1,16),(698,'Pedaballikothapalle',1,16),(699,'Pedapalle',1,16),(700,'Pedda Chinnapyapili',1,16),(701,'Pedda Musturu',1,16),(702,'Peddachigullarevu',1,16),(703,'Peddajalalpuram',1,16),(704,'Peddakotla',1,16),(705,'Peddakowkuntla',1,16),(706,'Peddamallepalle',1,16),(707,'Peddamanthur',1,16),(708,'Peddannavaripalle',1,16),(709,'Peddapappur',1,16),(710,'Peddapolamada',1,16),(711,'Peddavadugur',1,16),(712,'Peddayakkaluru',1,16),(713,'Peddipalle',1,16),(714,'Peddoddi',1,16),(715,'Penakacherla',1,16),(716,'Penakalapadu',1,16),(717,'Pendekallu',1,16),(718,'Pennahobilam',1,16),(719,'Penukonda',1,16),(720,'Peravali',1,16),(721,'Perur',1,16),(722,'Pillalapalle',1,16),(723,'Pillenahalli',1,16),(724,'Pinnadari',1,16),(725,'Podaralla',1,16),(726,'Pogarur',1,16),(727,'Polepalle',1,16),(728,'Poletipalle',1,16),(729,'Poliki',1,16),(730,'Pothulakunta',1,16),(731,'Pothulanagepalle',1,16),(732,'Pottipadu',1,16),(733,'Pulagampalle',1,16),(734,'Pulakunta',1,16),(735,'Pulakurthi',1,16),(736,'Pulamathi',1,16),(737,'Puleru',1,16),(738,'Puligundlapalle',1,16),(739,'Pulikuntlapalle',1,16),(740,'Puliproddatur',1,16),(741,'Puppala',1,16),(742,'Putlur',1,16),(743,'Puttaparthi',1,16),(744,'Pyadindi',1,16),(745,'Pydeti',1,16),(746,'R. Anantapuram',1,16),(747,'R.Locharla',1,16),(748,'Rachanapalle',1,16),(749,'Racharla',1,16),(750,'Rachepalle',1,16),(751,'Raghavampalle',1,16),(752,'Ragimakulapalle',1,16),(753,'Ragulapadu',1,16),(754,'Rajapuram',1,16),(755,'Raketla',1,16),(756,'Ralla Anantapuram',1,16),(757,'Rallahalli',1,16),(758,'Rallapalle',1,16),(759,'Ramagiri',1,16),(760,'Ramanathapuram',1,16),(761,'Ramapuram',1,16),(762,'Ramarajupalle',1,16),(763,'Rampuram',1,16),(764,'Rangasamudram',1,16),(765,'Raptadu',1,16),(766,'Ratchumarri',1,16),(767,'Ratnagiri',1,16),(768,'Ravudi',1,16),(769,'Ravulacheruvu',1,16),(770,'Ravuludiki',1,16),(771,'Rayadurgam',1,16),(772,'Rayalacheruvu',1,16),(773,'Rayampalle',1,16),(774,'Reddipalle',1,16),(775,'Regatipalle',1,16),(776,'Renimakulapalle',1,16),(777,'Roddakampalle',1,16),(778,'Roddam',1,16),(779,'Rolla',1,16),(780,'S.Bandlapalle',1,16),(781,'S.Hosahalli',1,16),(782,'S.Kuruvapalle',1,16),(783,'S.Mallapuram',1,16),(784,'S.Mulakalapalle',1,16),(785,'S.Rayapuram',1,16),(786,'SAIDAPURAM',1,16),(787,'Sajjaladinne',1,16),(788,'Sajjalakalva',1,16),(789,'Salakamcheruvu',1,16),(790,'Sanagalaguduru',1,16),(791,'Sanapa',1,16),(792,'Sanevaripalle',1,16),(793,'Sangala',1,16),(794,'Sangameswarapalle',1,16),(795,'Sanipalle',1,16),(796,'Sankarabanda',1,16),(797,'Sankepalle',1,16),(798,'Sankepalle Brahmanapalle',1,16),(799,'Santhebidanur',1,16),(800,'Santhekondapuram',1,16),(801,'Sasanakota',1,16),(802,'Satarlapalle',1,16),(803,'Seegipalle',1,16),(804,'Seerpi',1,16),(805,'Seetharampuram',1,16),(806,'Seshadribhatra Halli',1,16),(807,'Settipalle',1,16),(808,'Settur',1,16),(809,'Shaiksanipalle',1,16),(810,'Shobeerepalle',1,16),(811,'Siddampeta',1,16),(812,'Siddaracherla',1,16),(813,'Siddarampuram',1,16),(814,'Singanahalli',1,16),(815,'Singanamala',1,16),(816,'Singavaram',1,16),(817,'Sirekolam',1,16),(818,'Sirivaram',1,16),(819,'Sivaram',1,16),(820,'Sodanapalle',1,16),(821,'Sollapuram',1,16),(822,'Somaghatta',1,16),(823,'Somalapuram',1,16),(824,'Somanadoddi',1,16),(825,'Somandepalle',1,16),(826,'Somayajulapalle',1,16),(827,'Sorakayalapeta',1,16),(828,'Sreedharaghattu',1,16),(829,'Sreekanthapuram (R)',1,16),(830,'Sreerangapuram',1,16),(831,'Subbaraopet',1,16),(832,'Subbaraopeta',1,16),(833,'Sunnampalle',1,16),(834,'Surepalli',1,16),(835,'T.Sadum',1,16),(836,'Tabjula',1,16),(837,'Tadimarri',1,16),(838,'Tadpatri',1,16),(839,'Talamarla',1,16),(840,'Talamarlavandla Palle',1,16),(841,'Talaricheruvu',1,16),(842,'Tallakera',1,16),(843,'Talupula',1,16),(844,'Talupuru',1,16),(845,'Tanakal',1,16),(846,'Tangedukunta',1,16),(847,'Tarimela',1,16),(848,'Tavalam',1,16),(849,'Tavalamarri',1,16),(850,'Tekulodu',1,16),(851,'Teliki',1,16),(852,'Thagguparthy',1,16),(853,'Thamballapalle',1,16),(854,'Thammadehalli',1,16),(855,'Thappetavaripalle',1,16),(856,'Thaticherla',1,16),(857,'Thatrakal',1,16),(858,'Theetakal',1,16),(859,'THIMMANACHERLA',1,16),(860,'Thimmanayanipalem',1,16),(861,'Thimmapuram',1,16),(862,'Thimmasamudram',1,16),(863,'Thippa Batlapalle',1,16),(864,'Thippepalle',1,16),(865,'Thirumalapuram',1,16),(866,'Thogarakunta',1,16),(867,'Thondapadu',1,16),(868,'Thopudurthi',1,16),(869,'Thumbiganur',1,16),(870,'Thummala',1,16),(871,'Thummalabylu',1,16),(872,'Thummalakuntla Palle',1,16),(873,'Thumucherla',1,16),(874,'Thumukunta',1,16),(875,'Thungepalle',1,16),(876,'Thurakalapatnam',1,16),(877,'Tirumaladevarahalli',1,16),(878,'Tirumaladevarapalle',1,16),(879,'Tubinakunta',1,16),(880,'Tungodu',1,16),(881,'Turakapalle',1,16),(882,'Tutrallapalle',1,16),(883,'Ubicherla',1,16),(884,'Uddehal',1,16),(885,'Udegolam',1,16),(886,'Udiripikonda',1,16),(887,'Udumulakurthy',1,16),(888,'Ulavalavandlapalle',1,16),(889,'Ullikallu',1,16),(890,'Undabanda',1,16),(891,'Untakal',1,16),(892,'Uppalapadu',1,16),(893,'Upparapalle',1,16),(894,'Upparlahalli',1,16),(895,'Uravakonda',1,16),(896,'Uruchinthala',1,16),(897,'Utakallu',1,16),(898,'Utakur',1,16),(899,'Vadigepalle',1,16),(900,'Vadrahonnur',1,16),(901,'Vajrakarur',1,16),(902,'Valasa',1,16),(903,'Vanavolu',1,16),(904,'Vangampalle',1,16),(905,'Vanganur',1,16),(906,'Vankamaddi',1,16),(907,'Vankarajukalva',1,16),(908,'Vankarakunta',1,16),(909,'Varli',1,16),(910,'Vasudevapuram',1,16),(911,'Veerabommana Halli',1,16),(912,'Veeraobanapalle',1,16),(913,'Veerapuram',1,16),(914,'Velagamakulapalle',1,16),(915,'Velamakur',1,16),(916,'Veldurthi',1,16),(917,'Velichelimala',1,16),(918,'Velidadakala',1,16),(919,'Veligonda',1,16),(920,'Vellamaddi',1,16),(921,'Velpumadugu',1,16),(922,'Vemulapadu',1,16),(923,'Vemulapalle',1,16),(924,'Vemuletipalle',1,16),(925,'Vengalammacheruvu',1,16),(926,'Venkatampalle',1,16),(927,'Venkatapuram',1,16),(928,'Venkatrayanipalle',1,16),(929,'Vennapurapalle',1,16),(930,'Vepalaparthy',1,16),(931,'Vepamampeta',1,16),(932,'Veparala',1,16),(933,'Veparalla',1,16),(934,'Vidapanakal',1,16),(935,'Virupapuram',1,16),(936,'Vittapalle',1,16),(937,'Vyasapuram',1,16),(938,'West Kodipalle',1,16),(939,'Y.Chintakayamanda',1,16),(940,'Y.Rampuram',1,16),(941,'Yadiki',1,16),(942,'Yagnisettipalle',1,16),(943,'Yatakal',1,16),(944,'Yeguvapalle',1,16),(945,'Yellanur',1,16),(946,'Yenumaladoddi',1,16),(947,'Yenumalapalle (CT)',1,16),(948,'Yerrabommanahalli',1,16),(949,'Yerradoddi',1,16),(950,'Yerragudi',1,16),(951,'Yerragunta',1,16),(952,'Yerraguntla',1,16),(953,'Yerrakondapuram',1,16),(954,'Yerrasingepalle',1,16),(955,'Yerrathimmarayachervu',1,16),(956,'A.Chinta Makulapalle',1,17),(957,'A.Kothakota',1,17),(958,'Achamma Agraharam',1,17),(959,'Adaram',1,17),(960,'Adavaram',1,17),(961,'Adavi Budugur',1,17),(962,'Adavikothuru',1,17),(963,'Adavimulakapalle',1,17),(964,'Adenapalle',1,17),(965,'Adilakshmamba Puram',1,17),(966,'Adusupalem',1,17),(967,'Agarala',1,17),(968,'Agaram',1,17),(969,'Agaramangalam',1,17),(970,'Aggichenupalle',1,17),(972,'Akanambattu',1,17),(973,'Akkarampalle',1,17),(974,'Akkurthy',1,17),(975,'Alapakam',1,17),(976,'Alapalle',1,17),(977,'Alathur',1,17),(978,'Alimelu Manga Puram',1,17),(979,'Allamadugu',1,17),(980,'ALLAMADUGU HW',1,17),(981,'Allipoolagunta',1,17),(982,'Alugumanipalle',1,17),(983,'Alukurupalle',1,17),(984,'Amallabandakota',1,17),(985,'Ambakam',1,17),(986,'Ambodharapalle',1,17),(987,'Ambur',1,17),(988,'Amilepalle',1,17),(989,'Ammacheruvu',1,17),(990,'Ammagaripalle',1,17),(991,'Ammapalem',1,17),(992,'Ammavaripatteda',1,17),(993,'Ammavaripeta',1,17),(994,'Amudala',1,17),(995,'Amudalaputhur',1,17),(996,'Anagallu',1,17),(997,'Anagarlapalle',1,17),(998,'Anagunta',1,17),(999,'Ananthapadmanabha Puram',1,17),(1000,'Ananthapuram',1,17),(1001,'Anchinayanikuppam',1,17),(1002,'Angallu',1,17),(1003,'Anganamalakothuru',1,17),(1004,'Angeri Cheruvu',1,17),(1005,'Anikera',1,17),(1006,'Anjuru',1,17),(1007,'Ankamvaripalle',1,17),(1008,'Ankireddipalle',1,17),(1009,'Ankisettipalle (OG)',1,17),(1010,'Annasamipalle',1,17),(1011,'Annur',1,17),(1012,'Annurkasabagayat',1,17),(1013,'Anupalle',1,17),(1014,'Anupalle (Part)',1,17),(1015,'Ayyvaripalli',1,2),(1016,'Balayapalli',1,2),(1017,'Basinenipalli',1,2),(1018,'Chinanagampalli',1,2),(1019,'Devammacheruvu',1,2),(1020,'Devarajusurayapalli',1,2),(1021,'Devisettipalli',1,2),(1022,'Gundupalli',1,2),(1023,'Pokalingayapalli(Jayapuram)',1,2),(1024,'Maramreddipalli',1,2),(1025,'Nemalladinne',1,2),(1026,'Pabbultipalli',1,2),(1027,'Seetharamapuram',1,2),(1028,'Singareddipalli',1,2),(1029,'Dakkanuru',1,2),(1030,'Ganeswarapuram',1,2),(1031,'Guvvadi',1,2),(1032,'Iskapalli',1,2),(1033,'Jadadevi',1,2),(1034,'Kancheruvu',1,2),(1035,'G.Kondareddipalli',1,2),(1036,'T.Kondareddipalli',1,2),(1037,'Mahammadapuram',1,2),(1038,'Nallabothulavaripalli',1,2),(1039,'North kondayapalem',1,2),(1040,'North krishnamrajupalli',1,2),(1041,'Pamurpalli',1,2),(1042,'Peddireddipalli',1,2),(1044,'Thimmareddipalli',1,2),(1045,'Thotalacheruvupalli',1,2),(1046,'Thurupuboyamadugula',1,2),(1047,'T.Chennampalli',1,2),(1048,'T.Rompidodla',1,2),(1049,'Varikuntapadu',1,2),(1050,'Vempadu',1,2),(1051,'Viruvuru',1,2),(1052,'Yerramreddipalli',1,2),(1053,'Bheemavarappadu',1,2),(1054,'Chinthaladevi',1,2),(1055,'Ganugapenta',1,2),(1056,'Garimenapanta',1,2),(1057,'Gottigundala',1,2),(1058,'Gottigundalapalem',1,2),(1059,'Gudavalluru',1,2),(1060,'Iskadamerla',1,2),(1061,'Kommi',1,2),(1062,'Marrigunta',1,2),(1063,'Nelkunampeta',1,2),(1064,'Parlapalli',1,2),(1065,'Renamal',1,2),(1066,'Saipet',1,2),(1067,'Sathyavolu',1,2),(1068,'Settypalem',1,2),(1069,'Turpuyerraballi',1,2),(1070,'Uppalapadu(Uppuluru)',1,2),(1071,'Veligondla',1,2),(1072,'ANNAVARAM',1,2),(1073,'BRAHMANAKRALKA',1,2),(1074,'CHAMADALA',1,2),(1075,'CHINAKRAKA',1,2),(1076,'CHOWDAVARAM',1,2),(1077,'GATTUPALLI',1,2),(1078,'GOPANNAPALEM',1,2),(1079,'JALADANKI',1,2),(1080,'JAMMALAPALEM',1,2),(1081,'KAMMAVARIPALEM',1,2),(1082,'KESAVARAM',1,2),(1083,'KOTHAPALEM',1,2),(1084,'KRISHNAPADU',1,2),(1085,'L.R.Agraharam',1,2),(1086,'Ramavarappadu',1,2),(1087,'Somavarappadu',1,2),(1089,'AMUDALADINNE',1,2),(1090,'ANEDADUGU',1,2),(1091,'ANNAGARIPALEM',1,2),(1092,'CHALAMCHERLA',1,2),(1093,'CHENCHUGANIPALEM',1,2),(1094,'CHENNAYAPALEM',1,2),(1095,'CHOWDARIPALEM',1,2),(1096,'GOWRAVARAM',1,2),(1097,'KOTHAPALLI',1,2),(1099,'MANNANGIDINNE',1,2),(1100,'PEDAPATTAPUPALEM',1,2),(1101,'R.C PALEM',1,2),(1102,'RUDRAKOTA',1,2),(1103,'SARVAYAPALEM',1,2),(1104,'SIRIPURAM',1,2),(1105,'THALLAPALEM',1,2),(1106,'THUMMALAPENTA',1,2),(1107,'AB Kandrika',1,2),(1108,'Allimadugu',1,2),(1109,'Bitragunta',1,2),(1110,'Bogole',1,2),(1111,'CR Palem',1,2),(1112,'JP Guduru',1,2),(1113,'J. Dinne',1,2),(1114,'Kovurupalli',1,2),(1115,'Mungamuru',1,2),(1116,'Nagulavaram',1,2),(1117,'SGV Ksandrika',1,2),(1118,'SV Palem',1,2),(1119,'Thalluru',1,2),(1120,'UM Puram',1,2),(1121,'VNR Peta',1,2),(1122,'Yeugulabavi',1,2),(1124,'Chinna Annaluru',1,2),(1125,'Gangireddy palem',1,2),(1126,'Kaligiri',1,2),(1127,'Kavali musthapuram',1,2),(1128,'Krakuturu',1,2),(1129,'Krishnareddypalem',1,2),(1130,'Kummara Konduru',1,2),(1133,'Parikota',1,2),(1134,'Peda Konduru',1,2),(1135,'Polampadu',1,2),(1136,'Ravulakollu',1,2),(1137,'Siddanakonduru',1,2),(1138,'Tellapadu',1,2),(1139,'Turpudubagunta',1,2),(1140,'Gudladona East',1,2),(1141,'Veernakollu',1,2),(1142,'Velagapadu',1,2),(1143,'Gudladonawest',1,2),(1144,'Yepinapi',1,2),(1145,'Yerukalareddypalem',1,2),(1146,'A. Kistipuram',1,2),(1148,'Chakalakonda',1,2),(1149,'Gundemakala',1,2),(1150,'Janardhanapuram',1,2),(1151,'Katepalli',1,2),(1152,'Nandigunta',1,2),(1153,'Nallagondla',1,2),(1154,'Ravipadu',1,2),(1155,'Sankavaram',1,2),(1156,'Utukuru',1,2),(1157,'Vinjamur',1,2),(1158,'Bandakindapalli',1,2),(1159,'Bodavaripalli',1,2),(1160,'Brahmeswram',1,2),(1161,'Bhyaravaram',1,2),(1162,'Duttalur',1,2),(1164,'Nandipadu',1,2),(1165,'Narrawada',1,2),(1166,'Papampalli',1,2),(1167,'Rachavaripalli',1,2),(1168,'Reddladinne',1,2),(1169,'Somala regada',1,2),(1170,'Theddupadu',1,2),(1172,'Vengana palem',1,2),(1173,'Venkatam peta',1,2),(1174,'Yerukollu',1,2),(1175,'Appasamudram',1,2),(1176,'Arlapadia',1,2),(1177,'Bandaganipally',1,2),(1178,'Dasaripally',1,2),(1179,'Gandipalem',1,2),(1180,'G. Ayyavaripally',1,2),(1181,'G. Cherlopally',1,2),(1182,'G. Cheruvupally',1,2),(1183,'Gannepally',1,2),(1184,'Kondayapalem',1,2),(1185,'Krishnampally',1,2),(1186,'Nelatur',1,2),(1187,'Pullayapally',1,2),(1188,'Sakunalapally',1,2),(1190,'Udayagiri',1,2),(1191,'Vengalrao Nagar',1,2),(1192,'Allampadu',1,2),(1193,'Bheemavaram',1,2),(1194,'Bramhanapalli',1,2),(1195,'Budhawada',1,2),(1196,'Chabolu',1,2),(1197,'Chilakapadu',1,2),(1198,'Chinnamachanuru',1,2),(1199,'Chunchuluru',1,2),(1200,'D.C.Palli',1,2),(1201,'Irlapadu',1,2),(1202,'Kampasamudram',1,2),(1203,'Kethigunta',1,2),(1204,'Khadarpur',1,2),(1205,'Marripadu',1,2),(1206,'Naginenigunta',1,2),(1207,'Nandavaram',1,2),(1208,'P.N.Palli',1,2),(1209,'Pallavolu',1,2),(1210,'Pegallapadu',1,2),(1211,'Ponguru',1,2),(1212,'Ponguru Kandrika',1,2),(1213,'Ramanaidupalli',1,2),(1214,'Singanapalli',1,2),(1215,'Yepilagunta',1,2),(1216,'Apparaopalem',1,1),(1217,'Araveedu',1,1),(1218,'Bandarupalli',1,1),(1219,'Battepadu',1,1),(1220,'Boila Chirivella',1,1),(1221,'Cherlo Yadavalli',1,1),(1222,'Depur',1,1),(1223,'Kanupurupalli',1,1),(1224,'Karatampadu',1,1),(1225,'Mahimalur',1,1),(1226,'Muragalla',1,1),(1227,'Nagulapadu',1,1),(1228,'Nallapareddypalli',1,1),(1229,'Narampeta',1,1),(1230,'Nuvvurupadu',1,1),(1231,'Padakandla',1,1),(1232,'Pamidipadu',1,1),(1233,'Ramaswamypalli',1,1),(1235,'Vasili',1,1),(1236,'Vennawada',1,1),(1237,'Akbarabad',1,1),(1238,'Anumasamudram',1,1),(1239,'Anumasamudrampeta',1,1),(1240,'Chiramana',1,1),(1241,'Chowtabheemavaram',1,1),(1242,'Dubagunta',1,1),(1244,'Gumparlapadu',1,1),(1245,'Hasanapuram',1,1),(1246,'Kavali Yadavalli',1,1),(1247,'Kondameedakonduru',1,1),(1248,'Kuppurupadu',1,1),(1249,'Pandipadu',1,1),(1250,'Peddabbipuram',1,1),(1251,'Ponugodu',1,1),(1252,'Rajavolu',1,1),(1253,'Sreekolanu',1,1),(1254,'Velpulagunta',1,1),(1255,'Jammavaram',1,1),(1256,'ANANTHAVARAM',1,2),(1257,'BODAGUDIPADU',1,2),(1258,'CHAVATAPUTHEDU',1,2),(1259,'CHENNERU',1,2),(1260,'DAGADARTHI',1,2),(1261,'DAMAVARAM',1,2),(1262,'DHARAMAVARAM',1,2),(1263,'DUNDIGAM',1,2),(1264,'KATRAYAPADU',1,2),(1265,'KOTHAPALLI KOWRU GUNTA',1,2),(1266,'MANUBOLUPADU',1,2),(1267,'PEDDAPUTEHDU',1,2),(1269,'TADAKALURU',1,2),(1270,'THRIVEEDI PADU',1,2),(1271,'THURIMERLA',1,2),(1272,'ULAVA PALLA',1,2),(1273,'VELUPODU',1,2),(1274,'UCHAGUNTA PALEM',1,2),(1275,'YELAMANCHIPADU',1,2),(1276,'ALLUR',1,2),(1277,'BHATRAKAGOLLU',1,2),(1278,'BEERAMGUNTA',1,2),(1279,'EASTGOGULAPALLY',1,2),(1280,'GRADDAGUNTA',1,2),(1281,'INDUPUR',1,2),(1282,'ISKAPALLY',1,2),(1283,'NORTHAMULUR',1,2),(1284,'NORTHMOPUR',1,2),(1285,'PURINI',1,2),(1286,'SINGAPET',1,2),(1287,'VELICHERLA',1,2),(1288,'WEST GOGULAPALLY',1,2),(1289,'Alaganipadu',1,2),(1290,'Annareddypalem',1,2),(1291,'Chowkacherla',1,2),(1292,'Dampuru',1,2),(1293,'Dandigunta',1,2),(1294,'Gadela Dinne',1,2),(1295,'Mudivarthi',1,2),(1297,'Ramatheertham',1,2),(1298,'Ramachandrapuram',1,2),(1299,'Utukur',1,2),(1300,'Vavilla',1,2),(1301,'Varini',1,2),(1302,'Vidavalur',1,2),(1303,'Alurupadu',1,2),(1304,'Basavayapalem',1,2),(1305,'Boduvaripalem',1,2),(1306,'Dakshina Harjanawada',1,2),(1307,'Damegunta',1,2),(1308,'Gandavaram',1,2),(1309,'Gandavaram South',1,2),(1310,'Gundalammapalem',1,2),(1311,'Kammapalem',1,2),(1312,'Kodavalur',1,2),(1313,'Kothavangallu',1,2),(1314,'Maneguntapadu',1,2),(1315,'Mikkilimpeta',1,2),(1316,'Naidupalem',1,2),(1317,'North Rajupalem',1,2),(1318,'Peyyalapalem',1,2),(1319,'Ramannapalem',1,2),(1320,'Regadichelika',1,2),(1321,'Talamanchi',1,2),(1322,'Venkanapuram',1,2),(1323,'Yellayapalem',1,2),(1324,'Buchireddypalem',1,2),(1325,'Chellayapalem',1,2),(1326,'Damaramadugu',1,2),(1327,'Iskapalem',1,2),(1328,'Jonnawada',1,2),(1329,'Kalayakagollu',1,2),(1330,'Kattubadipalem',1,2),(1331,'Minagallu',1,2),(1332,'Munulapaudi',1,2),(1333,'Nagamambapuram',1,2),(1334,'Nagayagunta',1,2),(1335,'Panchedu',1,2),(1336,'Penuballi',1,2),(1337,'Rebala',1,2),(1338,'Vavveru',1,2),(1340,'Chennavarappadu',1,2),(1341,'Duvvuru',1,2),(1342,'GandhijanaSangam',1,2),(1343,'Jandadibba',1,2),(1344,'Jangalakandriga',1,2),(1345,'Kolagatla',1,2),(1346,'Korimmerla',1,2),(1347,'Makthapuram',1,2),(1349,'Neelayapalem',1,2),(1350,'Padamatipalem',1,2),(1351,'Peramana',1,2),(1352,'Sangam',1,2),(1353,'Siddipuram',1,2),(1354,'Thalupurupadu',1,2),(1355,'Tarunavoya',1,2),(1356,'Vangallu',1,2),(1357,'Veeralagudipadu',1,2),(1358,'Vengareddypalem',1,2),(1359,'ADURUPALLI',1,1),(1360,'BOODIPADU',1,1),(1361,'CHEJARLA',1,1),(1362,'CHITTALURU',1,1),(1363,'GOLLAPALLI',1,1),(1364,'KAKIVOYA',1,1),(1365,'KOTITEERTHAM',1,1),(1366,'MADAPALLI',1,1),(1367,'MAMUDURU',1,1),(1368,'NGULAVELLATURU',1,1),(1369,'NERNOOR',1,1),(1370,'NUTAKIVARI KANDRIGA',1,1),(1371,'OBULAYAPALLI',1,1),(1372,'PADERU',1,1),(1373,'PATHAPADU',1,1),(1374,'PELLERU',1,1),(1375,'PERUMALLAPADU',1,1),(1376,'T.K.PADU',1,1),(1377,'THIMMAYAPALEM',1,1),(1378,'VAVILERU',1,1),(1379,'YANAMADALA',1,1),(1380,'YETURU',1,1),(1381,'AMANICHIRIVELLA',1,1),(1382,'ANANTHASAGARAM',1,1),(1383,'BEDUSUPALLI',1,1),(1384,'BOMMAVARAM',1,1),(1385,'CHILAKALAMARRI',1,1),(1386,'DEVARAYAPALLI     BIT-1',1,1),(1387,'DEVARAYAPALLI    BIT-2',1,1),(1389,'GUDIGUNTA',1,1),(1390,'INAGALURU',1,1),(1392,'KAMIREDDYPADU',1,1),(1393,'LINGAMGUNTA',1,1),(1394,'MANCHALAPALLI',1,1),(1395,'MANGUPALLI',1,1),(1397,'MUSTHAURAM',1,1),(1398,'PADAMATI KAMBHAM PADU',1,1),(1399,'PATHALAPALLI',1,1),(1400,'REVURU',1,1),(1401,'SOMASILA',1,1),(1403,'VARIKUNTAPAUDU',1,1),(1404,'VENGAMPALLI',1,1),(1405,'Baddevolu',1,1),(1406,'Balajiraopet',1,1),(1408,'Cheepinapi',1,1),(1409,'Chinagopavaram',1,1),(1410,'Chinthalapalem',1,1),(1411,'Chinthalatmakuru',1,1),(1412,'Chowtapalli',1,1),(1413,'Dachuru',1,1),(1414,'Kaluvoya',1,1),(1416,'Kesamanenipalli',1,1),(1417,'Kulluru',1,1),(1418,'Madannagaripalli',1,1),(1419,'Nukanapalli',1,1),(1420,'Pallakonda',1,1),(1421,'Peramakonda',1,1),(1422,'Telugurayapuram',1,1),(1423,'Thopugunta',1,1),(1424,'Uyyalapalli',1,1),(1425,'ADURPALLI',1,1),(1426,'AKILIVALASA',1,1),(1427,'BOJJANAPALLI',1,1),(1428,'CHEROPALLI',1,1),(1429,'GILAKAPADU',1,1),(1430,'GONUPALLI',1,1),(1431,'GUNDAVOLU',1,1),(1432,'JOREPALLI',1,1),(1433,'KAMBHALAPALLI',1,1),(1434,'MV.PURAM',1,1),(1435,'NELLEPALLI',1,1),(1436,'PANGILI',1,1),(1437,'PENUBARTHI',1,1),(1438,'RAPUR',1,1),(1439,'SANAYAPALEM',1,1),(1440,'SANKRANTHIPALLI',1,1),(1441,'SIDDAVARAM',1,1),(1442,'TEGACHERLA',1,1),(1443,'THUMAYA',1,1),(1444,'VEPINAPI',1,1),(1445,'YEPURU',1,1),(1446,'Althurthi',1,1),(1447,'Ammavaripalem',1,1),(1448,'Ayyagaripalem',1,1),(1449,'Bathulapalli',1,1),(1450,'Biradavolu',1,1),(1451,'Chatagotla',1,1),(1452,'Chennareddy Palli',1,1),(1453,'Degapudi',1,1),(1454,'Duggunta',1,1),(1455,'Inkurthi',1,1),(1456,'Kanuparthi',1,1),(1457,'Mahamadapuram',1,1),(1458,'Marripalli',1,1),(1459,'Marupuru',1,1),(1460,'Moggalluru',1,1),(1461,'Nandivayi',1,1),(1462,'Navuru',1,1),(1463,'Navuru Palli',1,1),(1464,'Nedurupalli',1,1),(1466,'Podalakur',1,1),(1467,'Prabhagiri Patnam',1,1),(1468,'Pulikallu',1,1),(1469,'RY Palem',1,1),(1470,'Surayapalem',1,1),(1471,'Tatiparthi',1,1),(1472,'Toderu',1,1),(1473,'Vavinta Parthi',1,1),(1474,'Velikanit Palem',1,1),(1475,'Virivuru',1,1),(1476,'Kakupalli-II(M.R.Gudur)',1,1),(1477,'Amancherla',1,1),(1478,'Deverapalem',1,1),(1479,'Dontali',1,1),(1480,'Gollakandukuru',1,1),(1481,'Kakupalli-I',1,1),(1482,'Kalivelapalem',1,1),(1483,'Kandamuru',1,1),(1484,'Kommarapudi',1,1),(1485,'Kondlapudi',1,1),(1486,'Kothavellanti',1,1),(1487,'Mulumudi',1,1),(1488,'Pathavellanti',1,1),(1490,'Sajjapuram',1,1),(1491,'Southmopur',1,1),(1492,'Upputur',1,1),(1493,'Cherlopalem',1,2),(1495,'Inamadugu',1,2),(1496,'Kovur',1,2),(1497,'Leguntapadu',1,2),(1498,'Modegunta',1,2),(1499,'Padugupadu',1,2),(1500,'Patur',1,2),(1501,'Pothireddypalem',1,2),(1502,'Vegur',1,2),(1503,'Devispet',1,1),(1504,'Gangapatnam',1,1),(1505,'Indukurpet Bit-II',1,1),(1506,'Indukurpet Bit-I',1,1),(1507,'Jangamvanidoruvu',1,1),(1508,'Komarika',1,1),(1509,'Koruturu',1,1),(1510,'Kothuruchinthopu',1,1),(1511,'Kudithipalem',1,1),(1512,'Leburu Bit-I',1,1),(1513,'Leburu Bit-II',1,1),(1514,'Mudivarthipalem',1,1),(1515,'Mypadu',1,1),(1517,'Nidimusali',1,1),(1518,'Pallipadu',1,1),(1519,'Punnur',1,1),(1520,'Ramudupalem',1,1),(1521,'Ravur',1,1),(1522,'Somarajupalli',1,1),(1523,'South Amuluru',1,1),(1524,'Chinna Cherukuru',1,1),(1525,'Chinthopu',1,1),(1526,'Eduru',1,1),(1527,'Isakapalem',1,1),(1528,'Koduru',1,1),(1530,'Koverapalem',1,1),(1531,'Macharlavaripalem',1,1),(1532,'Mallikharjunapuram',1,1),(1533,'Mandapam',1,1),(1534,'Mungaladoruvu',1,1),(1535,'Narukuru',1,1),(1536,'Papireddypalem',1,1),(1537,'Peduru',1,1),(1538,'Potlapudi',1,1),(1539,'Thotapalli Gudur',1,1),(1540,'Thotapalli',1,1),(1541,'Varakavipudi',1,1),(1542,'Varigonda',1,1),(1543,'Venkannapalem',1,1),(1544,'Villukanipalli',1,1),(1545,'BRAHMADEVAM',1,1),(1546,'DAMMAYAPALEM',1,1),(1547,'DORUVULAPALEM',1,1),(1548,'DUVVURUVARIPALEM',1,1),(1549,'EPURU – 1 A',1,1),(1550,'KRISHNAPATNAM',1,1),(1551,'MOLLURU',1,1),(1552,'MAMIDIPUDI',1,1),(1553,'MUSUNURUVARIPALEM',1,1),(1555,'NARIKELLAPALLI',1,1),(1556,'NELATURU',1,1),(1557,'EPURU – 1 B (PANTAPALEM)',1,1),(1558,'PATURUVARIKANDRIGA',1,1),(1559,'PIDATHAPOLUR',1,1),(1560,'POLAMRAJUGUNTA',1,1),(1561,'PYNAPURAM',1,1),(1562,'SARVEPALLI BIT – 5 (POTTEMPADU)',1,1),(1563,'THALLAPUDI',1,1),(1564,'VALLUR',1,1),(1565,'ATV Kandriga',1,1),(1566,'Anikepalli',1,1),(1567,'Chemudugunta',1,1),(1568,'Edagali',1,1),(1569,'Eguvamitta',1,1),(1570,'Epuru-II(GVR Palem)',1,1),(1571,'Idemepalli',1,1),(1572,'Kakutur',1,1),(1573,'Kandalapadu',1,1),(1574,'Kantepalli',1,1),(1575,'Kanupuru BIT-I',1,1),(1576,'Chavatapalem (KANUPURU BIT-II)',1,1),(1577,'Kasumuru',1,1),(1578,'Kuricherlapadu',1,1),(1579,'Palicherlapadu',1,1),(1580,'Pudiparthy',1,1),(1581,'Punjulurupadu',1,1),(1582,'Ramdasskandriga',1,1),(1583,'Survepalli I (Tikkavarappadu)',1,1),(1584,'Survepalli II',1,1),(1585,'Survepalli III (Iskapalem)',1,1),(1586,'Survepalli IV (Nidiguntapalem)',1,1),(1587,'Tatiparthipalem',1,1),(1588,'Tirumapalammapalem',1,1),(1589,'Venkatachalam',1,1),(1590,'Akkampeta',1,3),(1592,'Bandepalli',1,3),(1594,'Cherkumudi',1,3),(1595,'Guruvindapudi',1,3),(1596,'Jatlakonduru',1,3),(1597,'Kagithalapuru',1,3),(1598,'Kattuvapalli',1,3),(1599,'Kolanakuduru',1,3),(1600,'Kommalapudi',1,3),(1601,'Lakshminarasimha puram',1,3),(1602,'Madamanuru',1,3),(1603,'Manubolu',1,3),(1604,'Piduru',1,3),(1605,'Pidurupalem',1,3),(1606,'Vadlapudi',1,3),(1607,'Veerampalli',1,3),(1609,'Ayyavaripalem',1,3),(1610,'Chennur',1,3),(1611,'Divipalem',1,3),(1612,'Kandali',1,3),(1613,'Kandra',1,3),(1614,'Kommanetur',1,3),(1615,'Kondagunta',1,3),(1616,'Kundakur',1,3),(1617,'Mangalapur',1,3),(1618,'Mekanur',1,3),(1619,'Mittatmakur',1,3),(1620,'Nellatur',1,3),(1621,'Nernur',1,3),(1622,'Pagadalapalli',1,3),(1623,'Palicherla',1,3),(1624,'Potupalem',1,3),(1625,'Ramalingapuram',1,3),(1626,'Santhadasupalli',1,3),(1628,'Thippavarappadu',1,3),(1629,'Vedicherla',1,3),(1630,'Vendodu',1,3),(1631,'Vindur',1,3),(1632,'Ananthamadugu',1,3),(1633,'Chaganam Rajupalem',1,3),(1634,'Chaganam',1,3),(1635,'Cheekavolu',1,3),(1636,'Devaravemuru',1,3),(1637,'GB vanam',1,3),(1638,'Griddaluru',1,3),(1639,'Gulimcherla',1,3),(1640,'Jogipalli',1,3),(1641,'Kalichedu',1,3),(1642,'KGR Palem',1,3),(1643,'Kommipadu',1,3),(1644,'Krishnareddy palli',1,3),(1645,'Linganapalem',1,3),(1646,'Lingasamudram',1,3),(1647,'Malichedu',1,3),(1648,'Marlapudi',1,3),(1649,'Paluru',1,3),(1651,'Pokkandala',1,3),(1652,'Pothegunta',1,3),(1653,'Ragana Ramapuram',1,3),(1654,'Ramasagaram',1,3),(1655,'RYG Palem',1,3),(1656,'Sydapuram',1,3),(1657,'Thippireddy palli',1,3),(1658,'Thocham',1,3),(1659,'Thummala Thalupuru',1,3),(1660,'Turimerla',1,3),(1662,'Vemulachedu',1,3),(1663,'Althurupadu',1,3),(1664,'Amuduru',1,3),(1665,'Chapalapalli',1,3),(1666,'D.Upparapalli',1,3),(1667,'D.Vaddipalli',1,3),(1668,'Daggavolu',1,3),(1669,'Dakkili',1,3),(1670,'Dandavolu',1,3),(1671,'Devulapalli',1,3),(1672,'K.B.Palli',1,3),(1674,'Madhavayapalem',1,3),(1675,'Marlagunta',1,3),(1676,'Matumadugu',1,3),(1677,'Mopur',1,3),(1678,'Mopur Vellampalli',1,3),(1679,'Nadimpalli',1,3),(1680,'Nagavolu',1,3),(1681,'Palugodu',1,3),(1682,'Pathanalapadu',1,3),(1683,'Sanganapalli',1,3),(1684,'Sreepuram',1,3),(1685,'Theerthampadu',1,3),(1686,'VKY.Samudram',1,3),(1687,'Devudu Vellampalli',1,3),(1688,'Velikallu',1,3),(1689,'Vembuluru',1,3),(1691,'Chinnannapeta',1,3),(1692,'Kalavalapudi',1,3),(1693,'Palemkota',1,3),(1694,'Panjam',1,3),(1695,'Papamambapuram',1,3),(1696,'Paravolu',1,3),(1698,'Somasanigunta',1,3),(1699,'Upparapalli K',1,3),(1700,'Yathaluru',1,3),(1701,'Chilakampadu',1,3),(1702,'Chintagunta',1,3),(1703,'Jangalapalli',1,3),(1704,'Kalapadu',1,3),(1705,'Kurjagunta',1,3),(1706,'Lalapet',1,3),(1707,'Mogalagunta',1,3),(1708,'Petluru',1,3),(1709,'Valivedu',1,3),(1710,'Alimili',1,3),(1712,'Bhyravaram',1,3),(1713,'Chilamanuru',1,3),(1714,'Gottikadu',1,3),(1715,'Hastakavaeri',1,3),(1716,'Jayampu',1,3),(1717,'Kadagunta',1,3),(1718,'Kalaganda',1,3),(1719,'Kamakuru',1,3),(1720,'Katragunta',1,3),(1721,'Kayyuru',1,3),(1722,'Kotambedu',1,3),(1723,'Mannuru',1,3),(1724,'Nidigalllu',1,3),(1725,'Nindali',1,3),(1726,'Pakapudi',1,3),(1728,'Perimidi',1,3),(1729,'Pigialm',1,3),(1730,'Sangavaram',1,3),(1731,'Siddagunta',1,3),(1732,'Utlapalli',1,3),(1733,'Vengamambapuram',1,3),(1734,'Arimenipadu',1,3),(1735,'Athivaram',1,3),(1736,'Bhatlakanupuru',1,3),(1737,'Bhuvanagiri Palem',1,3),(1738,'Chillamanuchenu',1,3),(1740,'Gurramkonda',1,3),(1741,'Inugunta',1,3),(1742,'Karaballavolu',1,3),(1743,'Kondavallipadu',1,3),(1744,'Kotta Cheruvu',1,3),(1745,'Kundam',1,3),(1746,'Kurugonda',1,3),(1747,'Machavaram',1,3),(1748,'Manamala',1,3),(1749,'Manavali',1,3),(1750,'Mummaya palem',1,3),(1751,'Nemallapudi',1,3),(1752,'Ozili',1,3),(1753,'Pedapariya',1,3),(1754,'Punnepalli',1,3),(1755,'Rachapalem',1,3),(1757,'Saguturu',1,3),(1758,'Thirumalapudi',1,3),(1759,'Venkatareddy palem',1,3),(1760,'Annambaka',1,3),(1761,'Ballavolu',1,3),(1762,'Budanam',1,3),(1763,'Chedimala',1,3),(1764,'Chillakur',1,3),(1765,'Chinthavaram',1,3),(1766,'East Kanupuru',1,3),(1767,'Eguvarajupalem',1,3),(1768,'Kadivedu',1,3),(1769,'Kalavakonda',1,3),(1771,'Lingavaram',1,3),(1772,'Mannegunta',1,3),(1773,'Momidi',1,3),(1774,'Muthyalapadu',1,3),(1775,'NR Palli',1,3),(1776,'Oduru',1,3),(1777,'Palicherlavaripalem',1,3),(1778,'Pallamala',1,3),(1779,'Ponnavolu',1,3),(1780,'Thamminapatnam',1,3),(1781,'Theepanuru',1,3),(1782,'Thikkavaram',1,3),(1783,'Thimmanagaripalem',1,3),(1784,'Thippaguntapalem',1,3),(1785,'Thonukumala',1,3),(1786,'Udathavaripalem',1,3),(1787,'Vallipedu',1,3),(1788,'Varagali',1,3),(1789,'Vellapalem',1,3),(1790,'Yeruru',1,3),(1792,'CHENDODU',1,3),(1793,'CHITTEDU',1,3),(1794,'GUDALI',1,3),(1795,'JARUGUMALLI',1,3),(1796,'KARLAPUDI',1,3),(1797,'KESAVRAM',1,3),(1798,'KOKKUPADU',1,3),(1799,'KOTA',1,3),(1800,'KOTHAPATNAM',1,3),(1801,'MADDALI',1,3),(1802,'NP KOTHAPALEM',1,3),(1803,'PUCHALAPALLI',1,3),(1804,'RUDRAVARAM',1,3),(1805,'SIDDAVRAM',1,3),(1806,'THIMMANAIDUPALEM',1,3),(1807,'THINNELAPUDI',1,3),(1808,'UNUGUNTAPALEM',1,3),(1809,'UTHAMANELLORE',1,3),(1810,'VANJIWAKA',1,3),(1812,'Balireddypalem',1,3),(1813,'Duggarajapatnam',1,3),(1814,'Jameenkothapalem',1,3),(1815,'Juvvinattu',1,3),(1819,'Molaganur',1,3),(1820,'Muttembaka',1,3),(1821,'Nellipudi',1,3),(1822,'Nidigurthi',1,3),(1823,'Pudirayadoruvu',1,3),(1824,'Raviguntapalem',1,3),(1825,'Reddypalem Bit II',1,3),(1826,'Kasipuram',1,3),(1827,'Thirumuru',1,3),(1828,'Vakadu',1,3),(1829,'Valamedu',1,3),(1830,'Yeragatipalli',1,3),(1831,'Alletipadu',1,3),(1832,'Aravapalem',1,3),(1833,'Aruru',1,3),(1834,'B.G.K. Palem',1,3),(1835,'Chillamur',1,3),(1836,'Chittamur',1,3),(1837,'Eswarawaka',1,3),(1838,'Gunapadu',1,3),(1839,'Gunapatipalem',1,3),(1840,'J.K.Palli',1,3),(1841,'Kogili',1,3),(1842,'Mallam',1,3),(1843,'Mettu',1,3),(1844,'Mollakalapudi',1,3),(1845,'North Varthuru',1,3),(1846,'Pallamparthi',1,3),(1847,'Pellakuru',1,3),(1848,'Ranganadhapuram',1,3),(1849,'Tadimedu',1,3),(1850,'Uppalamarthy',1,3),(1851,'Yakasiri',1,3),(1852,'Yellasiri',1,3),(1853,'Yellore',1,3),(1854,'ANNAMEDU',1,3),(1855,'ARAVAPERIMIDI',1,3),(1857,'CHIGURUPADU',1,3),(1858,'CHILAMATHURU',1,3),(1859,'DWARAKAPURAM',1,3),(1860,'GOTTIPROLU',1,3),(1861,'JUVVALAPALEM',1,3),(1862,'KALLIPEDU',1,3),(1863,'KAPULURU',1,3),(1864,'KUCHIWADA',1,3),(1865,'MARLAPALLI',1,3),(1866,'MENAKURU',1,3),(1867,'PANDLURU',1,3),(1868,'PUDERU',1,3),(1869,'PUDURU',1,3),(1870,'THIMMAJIKANDRIGA',1,3),(1871,'VINNAMALA',1,3),(1872,'ANKAVOLU',1,3),(1873,'ARDHAMALA',1,3),(1874,'BANGARAMMAPET',1,3),(1875,'CHENNAPANAIDUPETA',1,3),(1876,'CHAVALI',1,3),(1877,'CHEMBEDU',1,3),(1878,'CHILLAKURU',1,3),(1879,'CHINTHAPUDI',1,3),(1880,'JEELAPATUR',1,3),(1881,'KALAVAKUR',1,3),(1882,'KANUR',1,3),(1883,'KOTHURU',1,3),(1884,'MUMMAREDDIGUNTA',1,3),(1885,'NANDIMALA',1,3),(1886,'NELLUBALLI',1,3),(1887,'PALACHURU',1,3),(1889,'PENNEPALLI',1,3),(1890,'PULLURU',1,3),(1891,'PUNABAKA',1,3),(1892,'RAVULAPADU',1,3),(1893,'ROSANUR',1,3),(1894,'SIRASANAMBEDU',1,3),(1895,'TALVAIPADU',1,3),(1896,'Akkarapaka',1,3),(1897,'Anepudi',1,3),(1898,'Buduru',1,3),(1901,'Meejuru',1,3),(1902,'Minamanamudi',1,3),(1903,'Modugulapalem',1,3),(1904,'Nelaballi',1,3),(1905,'Nelapattu',1,3),(1906,'Nellorepalli',1,3),(1907,'Polireddypalem',1,3),(1908,'Poolathota',1,3),(1909,'Singanalathuru',1,3),(1910,'Sreedhanamalli',1,3),(1911,'Thallampadu',1,3),(1912,'Thanayali',1,3),(1913,'Thogaramudi',1,3),(1914,'Utchuru',1,3),(1915,'Vedurupattu',1,3),(1916,'Venumbaka',1,3),(1917,'Yekollu',1,3),(1918,'ABAKA',1,3),(1919,'DAMANELLORE',1,3),(1920,'DAMARAI',1,3),(1921,'GOPALREDDY PALEM',1,3),(1922,'ILLUPURU',1,3),(1923,'KCN GUNTA',1,3),(1924,'KADAPATRA',1,3),(1925,'KORIDI',1,3),(1926,'KOTAPOLURU',1,3),(1927,'KUDIRI',1,3),(1928,'MANGANELLORE',1,3),(1929,'MANGALAMPADU',1,3),(1930,'MANNEMUTHERI',1,3),(1931,'MATHAKAMUDI',1,3),(1932,'N.V.KANDRIGA',1,3),(1933,'SAMANTHAMALLAM',1,3),(1934,'SUGGUPALLI',1,3),(1935,'UGGUMUDI',1,3),(1936,'VELAGALAPONNURU',1,3),(1937,'Andagundala',1,3),(1938,'B.V.Palem',1,3),(1939,'Chenigunta',1,3),(1941,'Irakam',1,3),(1942,'Kadaluru',1,3),(1943,'Karijatha',1,3),(1944,'Karuru',1,3),(1945,'Tadakandriga',1,3),(1947,'Mambattu',1,3),(1948,'Periyavattu',1,3),(1949,'Pudi',1,3),(1951,'Tada',1,3),(1952,'Vatambedu',1,3),(1953,'Venadu',1,3),(1954,'Vendlurupadu',1,3);
/*!40000 ALTER TABLE `tbl_locality` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_o_bal_track`
--

DROP TABLE IF EXISTS `tbl_o_bal_track`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_o_bal_track` (
  `item_id` bigint DEFAULT NULL,
  `prv_opening_balance` bigint DEFAULT NULL,
  `new_opening_balance` bigint DEFAULT NULL,
  `updated_by` bigint DEFAULT NULL,
  `updated_date` datetime(3) NOT NULL DEFAULT CURRENT_TIMESTAMP(3)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_o_bal_track`
--

LOCK TABLES `tbl_o_bal_track` WRITE;
/*!40000 ALTER TABLE `tbl_o_bal_track` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_o_bal_track` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_packages`
--

DROP TABLE IF EXISTS `tbl_packages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_packages` (
  `package_id` int NOT NULL,
  `package_name` varchar(50) NOT NULL,
  `package_no_users` tinyint NOT NULL,
  `package_is_active` int NOT NULL DEFAULT '1',
  `package_amount` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`package_id`),
  UNIQUE KEY `package_name_UNIQUE` (`package_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_packages`
--

LOCK TABLES `tbl_packages` WRITE;
/*!40000 ALTER TABLE `tbl_packages` DISABLE KEYS */;
INSERT INTO `tbl_packages` VALUES (1,'Silver',1,1,4000),(2,'Gold',3,1,6000),(3,'Platinum',5,1,8000),(4,'Trail',1,1,0);
/*!40000 ALTER TABLE `tbl_packages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_payment_gateway_error`
--

DROP TABLE IF EXISTS `tbl_payment_gateway_error`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_payment_gateway_error` (
  `payment_gateway_error_id` bigint NOT NULL AUTO_INCREMENT,
  `error_code` varchar(50) DEFAULT NULL,
  `error_description` varchar(500) NOT NULL,
  `error_source` varchar(50) DEFAULT NULL,
  `error_step` varchar(50) DEFAULT NULL,
  `error_reason` varchar(250) DEFAULT NULL,
  `error_created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `client_id` bigint NOT NULL,
  `emp_user_id` varchar(150) NOT NULL,
  PRIMARY KEY (`payment_gateway_error_id`),
  KEY `fk_pmt_gway_clientid_idx` (`client_id`),
  KEY `fk_pmt_gway_userid_idx` (`emp_user_id`),
  CONSTRAINT `fk_pmt_gway_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_pmt_gway_userid` FOREIGN KEY (`emp_user_id`) REFERENCES `tbl_users` (`emp_user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_payment_gateway_error`
--

LOCK TABLES `tbl_payment_gateway_error` WRITE;
/*!40000 ALTER TABLE `tbl_payment_gateway_error` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_payment_gateway_error` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_payment_types`
--

DROP TABLE IF EXISTS `tbl_payment_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_payment_types` (
  `payment_type_id` int NOT NULL,
  `payment_type_desc` varchar(45) NOT NULL,
  PRIMARY KEY (`payment_type_id`),
  UNIQUE KEY `payment_type_desc_UNIQUE` (`payment_type_desc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_payment_types`
--

LOCK TABLES `tbl_payment_types` WRITE;
/*!40000 ALTER TABLE `tbl_payment_types` DISABLE KEYS */;
INSERT INTO `tbl_payment_types` VALUES (2,'Card'),(1,'Cash'),(3,'UPI');
/*!40000 ALTER TABLE `tbl_payment_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_purchase`
--

DROP TABLE IF EXISTS `tbl_purchase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_purchase` (
  `purchase_id` bigint NOT NULL AUTO_INCREMENT,
  `client_id` bigint NOT NULL,
  `supplier_id` bigint NOT NULL,
  `purchase_inv_date` date NOT NULL,
  `purchase_inv_no` varchar(30) NOT NULL,
  `transport_charge` decimal(19,2) NOT NULL,
  `packing_charge` decimal(19,2) NOT NULL,
  `other_charge` decimal(19,2) NOT NULL,
  `trade_discount` decimal(19,2) NOT NULL DEFAULT '0.00',
  `is_locked` int NOT NULL DEFAULT '1',
  `created_by` varchar(150) NOT NULL,
  `created_date` datetime(3) NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
  `updated_by` varchar(150) DEFAULT NULL,
  `updated_date` datetime(3) DEFAULT CURRENT_TIMESTAMP(3),
  PRIMARY KEY (`purchase_id`),
  UNIQUE KEY `uq_pur_supid_invno` (`client_id`,`supplier_id`,`purchase_inv_no`),
  KEY `idx_tbl_pur_date` (`purchase_inv_date`),
  KEY `idx_tbl_pur_date_sup` (`supplier_id`,`purchase_inv_date`),
  KEY `idx_tbl_pur_sup` (`supplier_id`),
  KEY `fk__tbl_purch__creat__24927208` (`created_by`),
  KEY `fk_purchase_clientid_idx` (`client_id`),
  CONSTRAINT `fk__tbl_purch__suppl__22aa2996` FOREIGN KEY (`supplier_id`) REFERENCES `tbl_suppliers` (`supplier_id`),
  CONSTRAINT `fk_pur_createdby` FOREIGN KEY (`created_by`) REFERENCES `tbl_users` (`emp_user_id`),
  CONSTRAINT `fk_purchase_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_purchase`
--

LOCK TABLES `tbl_purchase` WRITE;
/*!40000 ALTER TABLE `tbl_purchase` DISABLE KEYS */;
INSERT INTO `tbl_purchase` VALUES (11,1,7,'2021-08-02','1001',0.00,0.00,0.00,0.00,1,'ravi','2021-08-02 19:10:34.680',NULL,'2021-08-02 19:10:34.680'),(12,1,7,'2021-08-02','1002',500.00,200.00,100.00,100.00,1,'ravi','2021-08-02 19:20:02.254','ravi','2021-08-04 16:27:15.000'),(13,1,7,'2021-08-01','25241',100.00,200.00,100.00,500.00,1,'ravi','2021-08-03 20:08:09.383',NULL,'2021-08-03 20:08:09.383'),(14,1,7,'2021-08-02','1111',0.00,0.00,0.00,0.00,1,'ravi','2021-08-04 16:29:14.454',NULL,'2021-08-04 16:29:14.454'),(17,1,3,'2021-10-06','102',0.00,0.00,0.00,0.00,1,'ravi','2021-10-08 15:14:30.295',NULL,'2021-10-08 15:14:30.295');
/*!40000 ALTER TABLE `tbl_purchase` ENABLE KEYS */;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_purchase_AFTER_UPDATE` AFTER UPDATE ON `tbl_purchase` FOR EACH ROW BEGIN
	insert into PayBillApp.tbl_purchase_log(purchase_id,
											client_id,
                                            supplier_id,
                                            purchase_inv_date,
                                            purchase_inv_no,
                                            transport_charge,
                                            packing_charge,
                                            other_charge,
                                            trade_discount,
                                            is_locked,
                                            created_by,
                                            created_date,
                                            updated_by,
                                            updated_date,
                                            log_remarks)
									values(old.purchase_id,
											old.client_id,
                                            old.supplier_id,
                                            old.purchase_inv_date,
                                            old.purchase_inv_no,
                                            old.transport_charge,
                                            old.packing_charge,
                                            old.other_charge,
                                            old.trade_discount,
                                            old.is_locked,
                                            old.created_by,
                                            old.created_date,
                                            old.updated_by,updated_date,
                                            'Purchase invoice updated');
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_purchase_AFTER_DELETE` AFTER DELETE ON `tbl_purchase` FOR EACH ROW BEGIN
	insert into PayBillApp.tbl_purchase_log(purchase_id,
											client_id,
                                            supplier_id,
                                            purchase_inv_date,
                                            purchase_inv_no,
                                            transport_charge,
                                            packing_charge,
                                            other_charge,
                                            trade_discount,
                                            is_locked,
                                            created_by,
                                            created_date,
                                            updated_by,
                                            updated_date,
                                            log_remarks)
									values(old.purchase_id,
											old.client_id,
                                            old.supplier_id,
                                            old.purchase_inv_date,
                                            old.purchase_inv_no,
                                            old.transport_charge,
                                            old.packing_charge,
                                            old.other_charge,
                                            old.trade_discount,
                                            old.is_locked,
                                            old.created_by,
                                            old.created_date,
                                            old.updated_by,updated_date,
                                            'Purchase invoice deleted');
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `tbl_purchase_details`
--

DROP TABLE IF EXISTS `tbl_purchase_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_purchase_details` (
  `purchase_details_id` bigint NOT NULL AUTO_INCREMENT,
  `purchase_id` bigint NOT NULL,
  `item_id` bigint NOT NULL,
  `item_quantity` bigint NOT NULL,
  `item_price` decimal(19,2) NOT NULL,
  `item_amount` decimal(19,2) NOT NULL,
  `item_discount_in_per` decimal(4,2) NOT NULL,
  `item_discount_in_rs` decimal(19,2) NOT NULL,
  `cgst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `sgst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `igst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `cgst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `sgst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `igst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_total_value` decimal(19,2) NOT NULL,
  PRIMARY KEY (`purchase_details_id`),
  KEY `idx_tbl_pur_dtl_item` (`item_id`),
  KEY `idx_tbl_pur_dtl_purid` (`purchase_id`),
  KEY `idx_tbl_pur_dtl_purid_itemid` (`purchase_id`,`item_id`),
  CONSTRAINT `fk__tbl_purch__item___2a4b4b5e` FOREIGN KEY (`item_id`) REFERENCES `tbl_items` (`item_id`),
  CONSTRAINT `tbl_purchase_details_ibfk_1` FOREIGN KEY (`purchase_id`) REFERENCES `tbl_purchase` (`purchase_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_purchase_details`
--

LOCK TABLES `tbl_purchase_details` WRITE;
/*!40000 ALTER TABLE `tbl_purchase_details` DISABLE KEYS */;
INSERT INTO `tbl_purchase_details` VALUES (4,11,133,50,8.00,400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,400.00),(5,12,129,50,8.00,400.00,10.00,40.00,0.00,0.00,0.00,0.00,0.00,0.00,360.00),(6,12,305,40,8.00,320.00,5.00,16.00,0.00,0.00,0.00,0.00,0.00,0.00,304.00),(7,12,404,500,8.00,4000.00,12.00,80.00,0.00,0.00,0.00,0.00,0.00,0.00,3920.00),(8,12,8,400,8.00,3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00),(9,13,140,100,8.00,800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,800.00),(10,13,189,20,8.00,160.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,160.00),(12,12,309,25,8.00,200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,200.00),(13,14,107,100,8.00,800.00,5.00,40.00,0.00,0.00,0.00,0.00,0.00,0.00,760.00),(15,17,250,60,90.00,5400.00,2.00,108.00,0.00,0.00,3.00,0.00,0.00,158.76,5450.76),(18,17,211,222,545.00,120990.00,8.00,9679.20,0.00,0.00,3.00,0.00,0.00,3339.32,114650.12);
/*!40000 ALTER TABLE `tbl_purchase_details` ENABLE KEYS */;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_purchase_details_AFTER_INSERT` AFTER INSERT ON `tbl_purchase_details` FOR EACH ROW BEGIN
	update PayBillApp.tbl_items set current_balance = current_balance + new.item_quantity where item_id = new.item_id;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_purchase_details_AFTER_UPDATE` AFTER UPDATE ON `tbl_purchase_details` FOR EACH ROW BEGIN
	update PayBillApp.tbl_items set current_balance = current_balance - old.item_quantity + new.item_quantity where item_id = new.item_id;
    
    insert into PayBillApp.tbl_purchase_details_log(purchase_details_id,
													purchase_id,
                                                    item_id,
                                                    item_quantity,
                                                    item_price,
                                                    item_amount,
                                                    item_discount_in_per,
                                                    item_discount_in_rs,
                                                    cgst_in_per,
                                                    sgst_in_per,
                                                    igst_in_per,
                                                    cgst_in_rs,
                                                    sgst_in_rs,
                                                    igst_in_rs,
                                                    item_total_value,
                                                    log_remarks)
											values(old.purchase_details_id,
													old.purchase_id,
                                                    old.item_id,
                                                    old.item_quantity,
                                                    old.item_price,
                                                    old.item_amount,
                                                    old.item_discount_in_per,
                                                    old.item_discount_in_rs,
                                                    old.cgst_in_per,
                                                    old.sgst_in_per,
                                                    old.igst_in_per,
                                                    old.cgst_in_rs,
                                                    old.sgst_in_rs,
                                                    old.igst_in_rs,
                                                    old.item_total_value,
                                                    'Purchase invoice item updated');
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_purchase_details_AFTER_DELETE` AFTER DELETE ON `tbl_purchase_details` FOR EACH ROW BEGIN
	update PayBillApp.tbl_items set current_balance = current_balance - old.item_quantity where item_id = old.item_id;
    
    insert into PayBillApp.tbl_purchase_details_log(purchase_details_id,
													purchase_id,
                                                    item_id,
                                                    item_quantity,
                                                    item_price,
                                                    item_amount,
                                                    item_discount_in_per,
                                                    item_discount_in_rs,
                                                    cgst_in_per,
                                                    sgst_in_per,
                                                    igst_in_per,
                                                    cgst_in_rs,
                                                    sgst_in_rs,
                                                    igst_in_rs,
                                                    item_total_value,
                                                    log_remarks)
											values(old.purchase_details_id,
													old.purchase_id,
                                                    old.item_id,
                                                    old.item_quantity,
                                                    old.item_price,
                                                    old.item_amount,
                                                    old.item_discount_in_per,
                                                    old.item_discount_in_rs,
                                                    old.cgst_in_per,
                                                    old.sgst_in_per,
                                                    old.igst_in_per,
                                                    old.cgst_in_rs,
                                                    old.sgst_in_rs,
                                                    old.igst_in_rs,
                                                    old.item_total_value,
                                                    'Purchase invoice item deleted');
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `tbl_purchase_details_log`
--

DROP TABLE IF EXISTS `tbl_purchase_details_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_purchase_details_log` (
  `purchase_details_id` bigint NOT NULL,
  `purchase_id` bigint NOT NULL,
  `item_id` bigint NOT NULL,
  `item_quantity` bigint NOT NULL,
  `item_price` decimal(19,2) NOT NULL,
  `item_amount` decimal(19,2) NOT NULL,
  `item_discount_in_per` decimal(4,2) NOT NULL,
  `item_discount_in_rs` decimal(19,2) NOT NULL,
  `cgst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `sgst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `igst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `cgst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `sgst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `igst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_total_value` decimal(19,2) NOT NULL,
  `log_remarks` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_purchase_details_log`
--

LOCK TABLES `tbl_purchase_details_log` WRITE;
/*!40000 ALTER TABLE `tbl_purchase_details_log` DISABLE KEYS */;
INSERT INTO `tbl_purchase_details_log` VALUES (11,13,141,40,8.00,320.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,320.00,'Purchase invoice item deleted'),(16,17,65,43,962.00,41366.00,6.00,2481.96,0.00,0.00,3.00,0.00,0.00,1166.52,40050.56,'Purchase invoice item deleted'),(17,17,29,100,163.00,16300.00,7.00,1141.00,0.00,0.00,3.00,0.00,0.00,454.77,15613.77,'Purchase invoice item deleted'),(7,12,404,500,8.00,4000.00,2.00,80.00,0.00,0.00,0.00,0.00,0.00,0.00,3920.00,'Purchase invoice item updated');
/*!40000 ALTER TABLE `tbl_purchase_details_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_purchase_log`
--

DROP TABLE IF EXISTS `tbl_purchase_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_purchase_log` (
  `purchase_id` bigint NOT NULL,
  `client_id` bigint NOT NULL,
  `supplier_id` bigint NOT NULL,
  `purchase_inv_date` date NOT NULL,
  `purchase_inv_no` varchar(30) NOT NULL,
  `transport_charge` decimal(19,2) NOT NULL,
  `packing_charge` decimal(19,2) NOT NULL,
  `other_charge` decimal(19,2) NOT NULL,
  `trade_discount` decimal(19,2) NOT NULL DEFAULT '0.00',
  `is_locked` int NOT NULL DEFAULT '1',
  `created_by` varchar(150) NOT NULL,
  `created_date` datetime(3) NOT NULL,
  `updated_by` varchar(150) DEFAULT NULL,
  `updated_date` datetime(3) DEFAULT NULL,
  `log_remarks` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_purchase_log`
--

LOCK TABLES `tbl_purchase_log` WRITE;
/*!40000 ALTER TABLE `tbl_purchase_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_purchase_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_report_format`
--

DROP TABLE IF EXISTS `tbl_report_format`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_report_format` (
  `report_format_id` int NOT NULL AUTO_INCREMENT,
  `report_format_desc` varchar(100) NOT NULL,
  PRIMARY KEY (`report_format_id`),
  UNIQUE KEY `report_format_desc_UNIQUE` (`report_format_desc`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_report_format`
--

LOCK TABLES `tbl_report_format` WRITE;
/*!40000 ALTER TABLE `tbl_report_format` DISABLE KEYS */;
INSERT INTO `tbl_report_format` VALUES (1,'rdlcSalesInvoice'),(2,'rdlcSalesInvoiceGST');
/*!40000 ALTER TABLE `tbl_report_format` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_sales`
--

DROP TABLE IF EXISTS `tbl_sales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_sales` (
  `sales_id` bigint NOT NULL AUTO_INCREMENT,
  `client_id` bigint NOT NULL,
  `customer_id` bigint DEFAULT NULL,
  `sales_date` date NOT NULL,
  `transport_charge` decimal(19,2) NOT NULL,
  `packing_charge` decimal(19,2) NOT NULL,
  `other_charge` decimal(19,2) NOT NULL,
  `paid_cash` decimal(19,2) NOT NULL DEFAULT '0.00',
  `payment_type_id` int NOT NULL,
  `upi_type_id` int DEFAULT NULL,
  `trans_no` varchar(40) DEFAULT NULL,
  `created_by` varchar(150) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_by` varchar(150) DEFAULT NULL,
  `updated_date` datetime DEFAULT CURRENT_TIMESTAMP,
  `is_deleted` int NOT NULL DEFAULT '0',
  `remarks` varchar(500) DEFAULT NULL,
  `is_invoice_delivered` int NOT NULL DEFAULT '0',
  `is_locked` int NOT NULL DEFAULT '1',
  `is_mobile_billing` int DEFAULT '1',
  PRIMARY KEY (`sales_id`),
  KEY `idx_tbl_sal_cust` (`customer_id`),
  KEY `idx_tbl_sal_pmt_type` (`payment_type_id`),
  KEY `idx_upi_type_id` (`upi_type_id`),
  KEY `fk_sales_clientid_idx` (`client_id`),
  KEY `fk_sales_created_by_idx` (`created_by`),
  KEY `fk_sales_updated_by_idx` (`updated_by`),
  KEY `idx_tbl_sal_cust_date` (`customer_id`,`sales_date`,`is_deleted`),
  KEY `idx_tbl_sal_date` (`sales_date`,`is_deleted`),
  KEY `idx_tbl_sal_date_created_by` (`sales_date`,`created_by`,`is_deleted`),
  KEY `idx_tbl_sal_emp_date` (`sales_date`,`created_by`,`is_deleted`),
  KEY `idx_tbl_sal_emp_date_pmt` (`sales_date`,`created_by`,`payment_type_id`,`is_deleted`),
  KEY `idx_tbl_sal_pmt_type_date` (`sales_date`,`payment_type_id`,`is_deleted`),
  CONSTRAINT `fk_sales_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_sales_created_by` FOREIGN KEY (`created_by`) REFERENCES `tbl_users` (`emp_user_id`),
  CONSTRAINT `fk_sales_customerid` FOREIGN KEY (`customer_id`) REFERENCES `tbl_customers` (`customer_id`),
  CONSTRAINT `fk_sales_pymt_typeid` FOREIGN KEY (`payment_type_id`) REFERENCES `tbl_payment_types` (`payment_type_id`),
  CONSTRAINT `fk_sales_updated_by` FOREIGN KEY (`updated_by`) REFERENCES `tbl_users` (`emp_user_id`),
  CONSTRAINT `fk_sales_upi_typeid` FOREIGN KEY (`upi_type_id`) REFERENCES `tbl_upi_types` (`upi_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=232 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_sales`
--

LOCK TABLES `tbl_sales` WRITE;
/*!40000 ALTER TABLE `tbl_sales` DISABLE KEYS */;
INSERT INTO `tbl_sales` VALUES (41,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-01 11:24:32',NULL,'2021-09-01 11:24:32',0,NULL,0,1,1),(42,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,1,'65878555','ravi2','2021-09-01 13:22:40',NULL,'2021-09-01 13:22:40',0,NULL,0,1,1),(43,1,NULL,'2021-11-04',0.00,0.00,0.00,11.00,1,NULL,'','ravi2','2021-09-02 17:29:57',NULL,'2021-09-02 17:29:57',0,NULL,0,1,1),(44,1,NULL,'2021-11-04',0.00,0.00,0.00,114.00,1,NULL,'','ravi2','2021-09-02 17:30:20',NULL,'2021-09-02 17:30:20',0,NULL,0,1,1),(45,1,NULL,'2021-11-04',10.00,20.00,30.00,11.00,1,NULL,'','ravi2','2021-09-03 08:23:09',NULL,'2021-09-03 08:23:09',0,NULL,0,1,1),(47,1,NULL,'2021-11-04',0.00,0.00,44.00,103.00,1,NULL,'','ravi2','2021-09-03 10:50:52',NULL,'2021-09-03 10:50:52',0,NULL,0,1,1),(48,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,2,'85796596','ravi2','2021-09-03 10:51:36',NULL,'2021-09-03 10:51:36',0,NULL,0,1,1),(49,1,NULL,'2021-11-04',0.00,0.00,0.00,124.00,1,NULL,'','ravi2','2021-09-03 13:30:30',NULL,'2021-09-03 13:30:30',0,NULL,0,1,1),(50,1,NULL,'2021-11-04',0.00,0.00,0.00,42.00,1,NULL,'','ravi2','2021-09-03 15:11:09',NULL,'2021-09-03 15:11:09',0,NULL,0,1,1),(51,1,NULL,'2021-11-04',0.00,0.00,0.00,31.00,1,NULL,'','ravi2','2021-09-03 16:50:29',NULL,'2021-09-03 16:50:29',0,NULL,0,1,1),(52,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-03 16:56:54',NULL,'2021-09-03 16:56:54',0,NULL,0,1,1),(53,1,NULL,'2021-11-04',0.00,0.00,0.00,1165.00,1,NULL,'','ravi2','2021-09-03 17:01:43',NULL,'2021-09-03 17:01:43',0,NULL,0,1,1),(54,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-03 18:46:13',NULL,'2021-09-03 18:46:13',0,NULL,0,1,1),(55,1,NULL,'2021-11-04',0.00,0.00,0.00,42.00,1,NULL,'','ravi2','2021-09-03 19:04:14',NULL,'2021-09-03 19:04:14',0,NULL,0,1,1),(56,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,2,'2549696','ravi','2021-09-03 19:32:19',NULL,'2021-09-03 19:32:19',0,NULL,0,1,1),(57,1,NULL,'2021-11-04',0.00,0.00,0.00,9999999999.00,1,NULL,'','ravi','2021-09-03 19:35:42',NULL,'2021-09-03 19:35:42',0,NULL,0,1,1),(58,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'8690','ravi','2021-09-03 19:36:36',NULL,'2021-09-03 19:36:36',0,NULL,0,1,1),(59,1,NULL,'2021-11-04',0.00,0.00,0.00,675.00,1,NULL,'','ravi','2021-09-03 19:39:39',NULL,'2021-09-03 19:39:39',0,NULL,0,1,1),(60,1,NULL,'2021-11-04',0.00,0.00,0.00,500.00,1,NULL,'','ravi','2021-09-03 19:50:51',NULL,'2021-09-03 19:50:51',0,NULL,0,1,1),(61,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,3,'58809','ravi','2021-09-03 20:04:11',NULL,'2021-09-03 20:04:11',0,NULL,0,1,1),(62,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-04 14:17:53',NULL,'2021-09-04 14:17:53',0,NULL,0,1,1),(63,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-04 14:18:07',NULL,'2021-09-04 14:18:07',0,NULL,0,1,1),(64,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-04 14:19:43',NULL,'2021-09-04 14:19:43',0,NULL,0,1,1),(65,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-04 14:20:00',NULL,'2021-09-04 14:20:00',0,NULL,0,1,1),(66,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-04 14:22:31',NULL,'2021-09-04 14:22:31',0,NULL,0,1,1),(67,1,NULL,'2021-11-04',0.00,0.00,0.00,31.00,1,NULL,'','ravi2','2021-09-05 15:43:54',NULL,'2021-09-05 15:44:14',1,'fcvdgh',0,1,1),(68,1,NULL,'2021-11-04',0.00,0.00,0.00,11.00,1,NULL,'','ravi2','2021-09-06 06:52:39',NULL,'2021-09-06 07:45:10',1,'ejhenrn',0,1,1),(69,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-06 07:56:20',NULL,'2021-09-06 07:56:51',1,'ejdjndjf',0,1,1),(70,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-06 08:16:51',NULL,'2021-09-06 08:16:51',0,NULL,0,1,1),(71,1,NULL,'2021-11-04',0.00,0.00,0.00,21.00,1,NULL,'','ravi2','2021-09-07 05:08:12',NULL,'2021-09-07 05:08:12',0,NULL,0,1,1),(72,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi','2021-09-15 07:47:49',NULL,'2021-09-15 07:47:49',0,NULL,0,1,1),(73,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi','2021-09-15 07:50:34',NULL,'2021-09-15 07:50:34',0,NULL,0,1,1),(74,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi','2021-09-15 07:59:41',NULL,'2021-09-15 07:59:41',0,NULL,0,1,1),(75,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi','2021-09-15 08:00:13',NULL,'2021-09-15 08:00:13',0,NULL,0,1,1),(76,1,NULL,'2021-11-04',0.00,0.00,0.00,120.00,1,NULL,'','ravi2','2021-09-15 20:27:13',NULL,'2021-09-15 20:27:13',0,NULL,0,1,1),(77,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi2','2021-09-15 20:36:18',NULL,'2021-09-15 20:36:18',0,NULL,0,1,1),(78,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi2','2021-09-15 20:40:32',NULL,'2021-09-15 20:40:32',0,NULL,0,1,1),(79,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi2','2021-09-15 20:46:57',NULL,'2021-09-15 20:46:57',0,NULL,0,1,1),(80,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi2','2021-09-15 20:58:41',NULL,'2021-09-15 20:58:41',0,NULL,0,1,1),(81,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi2','2021-09-15 21:00:51',NULL,'2021-09-15 21:00:51',0,NULL,0,1,1),(82,1,NULL,'2021-11-04',0.00,0.00,0.00,20.00,1,NULL,'','ravi2','2021-09-16 06:00:50',NULL,'2021-09-16 06:00:50',0,NULL,0,1,1),(83,1,NULL,'2021-11-04',0.00,0.00,0.00,1000.00,1,NULL,'','ravi2','2021-09-16 06:28:34',NULL,'2021-09-16 06:28:34',0,NULL,0,1,1),(84,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,2,'5254525','ravi2','2021-09-16 06:50:15',NULL,'2021-09-16 06:50:15',0,NULL,0,1,1),(85,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi2','2021-09-16 06:50:46',NULL,'2021-09-16 06:50:46',0,NULL,0,1,1),(86,1,NULL,'2021-11-04',0.00,0.00,0.00,20.00,1,NULL,'','ravi2','2021-09-16 06:54:42',NULL,'2021-09-16 06:54:42',0,NULL,0,1,1),(87,1,NULL,'2021-11-04',0.00,0.00,0.00,20.00,1,NULL,'','ravi2','2021-09-16 06:57:32',NULL,'2021-09-16 06:57:32',0,NULL,0,1,1),(88,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,2,'1576','ravi2','2021-09-23 15:19:32',NULL,'2021-09-23 15:19:32',0,NULL,0,1,1),(89,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi2','2021-09-23 15:20:12',NULL,'2021-09-23 15:20:12',0,NULL,0,1,1),(90,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'8652','ravi2','2021-09-23 15:21:56',NULL,'2021-09-23 15:21:56',0,NULL,0,1,1),(91,1,NULL,'2021-11-04',0.00,0.00,0.00,560.00,1,NULL,'','ravi2','2021-09-23 15:27:14',NULL,'2021-09-23 15:27:14',0,NULL,0,1,1),(92,1,NULL,'2021-11-04',0.00,0.00,0.00,7880.00,1,NULL,'','ravi2','2021-09-23 15:30:27',NULL,'2021-09-23 15:30:27',0,NULL,0,1,1),(93,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,3,'6823','ravi2','2021-09-23 15:32:59',NULL,'2021-09-23 15:32:59',0,NULL,0,1,1),(94,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'0856','ravi2','2021-09-23 15:33:57',NULL,'2021-09-23 15:33:57',0,NULL,0,1,1),(95,1,NULL,'2021-11-04',0.00,0.00,0.00,390.00,1,NULL,'','ravi2','2021-09-23 15:35:28',NULL,'2021-09-23 15:35:28',0,NULL,0,1,1),(96,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'9000','ravi2','2021-09-23 15:36:26',NULL,'2021-09-23 15:36:26',0,NULL,0,1,1),(97,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,3,'5689','ravi2','2021-09-23 15:38:17',NULL,'2021-09-23 15:38:17',0,NULL,0,1,1),(98,1,NULL,'2021-11-04',0.00,0.00,0.00,390.00,1,NULL,'','ravi2','2021-09-23 15:40:55',NULL,'2021-09-23 15:40:55',0,NULL,0,1,1),(99,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'9087','ravi2','2021-09-23 15:43:53',NULL,'2021-09-23 15:43:53',0,NULL,0,1,1),(100,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'8383','ravi2','2021-09-23 15:44:54',NULL,'2021-09-23 15:44:54',0,NULL,0,1,1),(101,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,3,'8000','ravi2','2021-09-23 15:45:49',NULL,'2021-09-23 15:45:49',0,NULL,0,1,1),(102,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'8907','ravi2','2021-09-23 15:48:05',NULL,'2021-09-23 15:48:05',0,NULL,0,1,1),(103,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'3690','ravi2','2021-09-23 15:49:28',NULL,'2021-09-23 15:49:28',0,NULL,0,1,1),(104,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,1,'2560','ravi2','2021-09-23 15:50:43',NULL,'2021-09-23 15:50:43',0,NULL,0,1,1),(105,1,NULL,'2021-11-04',0.00,0.00,0.00,468.00,1,NULL,'','ravi2','2021-09-23 15:52:07',NULL,'2021-09-23 15:52:07',0,NULL,0,1,1),(106,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,2,'9738','ravi2','2021-09-23 15:53:31',NULL,'2021-09-23 15:53:31',0,NULL,0,1,1),(107,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'8907','ravi2','2021-09-23 15:54:15',NULL,'2021-09-23 15:54:15',0,NULL,0,1,1),(108,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'7688','ravi2','2021-09-23 15:55:07',NULL,'2021-09-23 15:55:07',0,NULL,0,1,1),(109,1,NULL,'2021-11-04',0.00,0.00,0.00,360.00,1,NULL,'','ravi2','2021-09-23 15:56:48',NULL,'2021-09-23 15:56:48',0,NULL,0,1,1),(110,1,NULL,'2021-11-04',0.00,0.00,0.00,10.00,1,NULL,'','ravi2','2021-09-23 15:57:18',NULL,'2021-09-23 15:57:18',0,NULL,0,1,1),(111,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'546','ravi2','2021-09-23 15:58:04',NULL,'2021-09-23 15:58:04',0,NULL,0,1,1),(112,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,4,'3614','ravi2','2021-09-23 15:59:25',NULL,'2021-09-23 15:59:25',0,NULL,0,1,1),(113,1,NULL,'2021-11-04',0.00,0.00,0.00,3105.00,1,NULL,'','ravi2','2021-09-23 16:00:42',NULL,'2021-09-23 16:00:42',0,NULL,0,1,1),(114,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'4605','ravi2','2021-09-23 16:04:20',NULL,'2021-09-23 16:04:20',0,NULL,0,1,1),(115,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'8907','ravi2','2021-09-23 16:05:12',NULL,'2021-09-23 16:05:12',0,NULL,0,1,1),(116,1,NULL,'2021-11-04',0.00,0.00,0.00,890.00,1,NULL,'','ravi2','2021-09-23 16:06:17',NULL,'2021-09-23 16:06:17',0,NULL,0,1,1),(118,1,NULL,'2021-11-04',0.00,0.00,0.00,260.00,1,NULL,'','ravi2','2021-09-23 16:08:34',NULL,'2021-09-23 16:08:34',0,NULL,0,1,1),(119,1,NULL,'2021-11-04',0.00,0.00,0.00,210.00,1,NULL,'','ravi2','2021-09-23 16:09:34',NULL,'2021-09-23 16:09:34',0,NULL,0,1,1),(120,1,NULL,'2021-11-04',0.00,0.00,0.00,866.00,1,NULL,'','ravi2','2021-09-23 16:10:54',NULL,'2021-09-23 16:10:54',0,NULL,0,1,1),(121,1,NULL,'2021-11-04',0.00,0.00,0.00,40.00,1,NULL,'','ravi2','2021-09-23 16:11:57',NULL,'2021-09-23 16:11:57',0,NULL,0,1,1),(122,1,NULL,'2021-11-04',0.00,0.00,0.00,240.00,1,NULL,'','ravi2','2021-09-23 16:12:21',NULL,'2021-09-23 16:12:21',0,NULL,0,1,1),(123,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'1092','ravi2','2021-09-23 16:36:40',NULL,'2021-09-23 16:36:40',0,NULL,0,1,1),(124,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,2,'3678','ravi2','2021-09-23 16:37:34',NULL,'2021-09-23 16:37:34',0,NULL,0,1,1),(125,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'1070','ravi2','2021-09-23 16:44:39',NULL,'2021-09-23 16:44:39',0,NULL,0,1,1),(126,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'1104','ravi2','2021-09-23 17:52:54',NULL,'2021-09-23 17:52:54',0,NULL,0,1,1),(127,1,NULL,'2021-11-04',0.00,0.00,0.00,9658.00,1,NULL,'','ravi2','2021-09-23 17:53:40',NULL,'2021-09-23 17:53:40',0,NULL,0,1,1),(128,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'0862','ravi2','2021-09-23 17:55:55',NULL,'2021-09-23 17:55:55',0,NULL,0,1,1),(129,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,3,2,'1680','ravi2','2021-09-23 17:57:43',NULL,'2021-09-23 17:57:43',0,NULL,0,1,1),(130,1,NULL,'2021-11-04',0.00,0.00,0.00,0.00,2,NULL,'1890','ravi2','2021-09-23 18:18:15',NULL,'2021-09-23 18:18:15',0,NULL,0,1,1),(131,1,NULL,'2021-11-04',0.00,0.00,0.00,1234567890.00,1,NULL,'','ravi2','2021-09-23 18:38:08',NULL,'2021-09-23 18:38:08',0,NULL,0,1,1),(132,1,NULL,'2021-11-04',0.00,0.00,0.00,1030.00,1,NULL,'','ravi2','2021-09-23 18:40:29',NULL,'2021-09-23 18:40:29',0,NULL,0,1,1),(133,1,NULL,'2021-11-04',0.00,0.00,0.00,5099.00,1,NULL,'','ravi2','2021-09-23 18:44:29',NULL,'2021-09-23 18:44:29',0,NULL,0,1,1),(134,1,NULL,'2021-11-04',0.00,0.00,0.00,236147.00,1,NULL,'','ravi2','2021-09-24 14:14:02',NULL,'2021-09-24 14:14:02',0,NULL,0,1,1),(135,1,NULL,'2022-06-29',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-29 13:33:38',NULL,'2022-06-29 13:33:38',0,NULL,0,1,0),(136,1,NULL,'2022-06-29',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-29 13:34:03',NULL,'2022-06-29 13:34:03',0,NULL,0,1,0),(137,1,NULL,'2022-06-29',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-29 13:36:55',NULL,'2022-06-29 13:36:55',0,NULL,0,1,0),(138,1,NULL,'2022-06-29',0.00,0.00,0.00,100.00,1,NULL,'','ravi','2022-06-29 13:40:04',NULL,'2022-06-29 13:40:04',0,NULL,0,1,0),(139,1,NULL,'2022-06-29',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-29 13:48:03',NULL,'2022-06-29 13:48:03',0,NULL,0,1,0),(140,1,NULL,'2022-06-29',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-29 17:17:42',NULL,'2022-06-29 17:17:42',0,NULL,0,1,0),(141,1,NULL,'2022-06-29',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-29 17:30:42',NULL,'2022-06-29 17:30:42',0,NULL,0,1,0),(142,1,NULL,'2022-06-29',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-29 17:30:55',NULL,'2022-06-29 17:30:55',0,NULL,0,1,0),(153,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,2,NULL,'','ravi','2022-06-30 06:17:25',NULL,'2022-06-30 06:17:25',0,NULL,0,1,0),(154,1,NULL,'2022-06-30',0.00,0.00,0.00,3521.00,2,NULL,'','ravi','2022-06-30 06:25:04',NULL,'2022-06-30 06:25:04',0,NULL,0,1,0),(155,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 11:17:06',NULL,'2022-06-30 11:17:06',0,NULL,0,1,0),(156,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 11:44:00',NULL,'2022-06-30 11:44:00',0,NULL,0,1,0),(157,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 11:44:31',NULL,'2022-06-30 11:44:31',0,NULL,0,1,0),(158,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:00:45',NULL,'2022-06-30 12:00:45',0,NULL,0,1,0),(160,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:06:09',NULL,'2022-06-30 12:06:09',0,NULL,0,1,0),(161,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:11:27',NULL,'2022-06-30 12:11:27',0,NULL,0,1,0),(162,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:13:01',NULL,'2022-06-30 12:13:01',0,NULL,0,1,0),(163,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:20:02',NULL,'2022-06-30 12:20:02',0,NULL,0,1,0),(164,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:21:55',NULL,'2022-06-30 12:21:55',0,NULL,0,1,0),(165,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:26:10',NULL,'2022-06-30 12:26:10',0,NULL,0,1,0),(166,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:27:51',NULL,'2022-06-30 12:27:51',0,NULL,0,1,0),(167,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:30:43',NULL,'2022-06-30 12:30:43',0,NULL,0,1,0),(168,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:34:44',NULL,'2022-06-30 12:34:44',0,NULL,0,1,0),(169,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:40:23',NULL,'2022-06-30 12:40:23',0,NULL,0,1,0),(170,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:41:10',NULL,'2022-06-30 12:41:10',0,NULL,0,1,0),(171,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:45:01',NULL,'2022-06-30 12:45:01',0,NULL,0,1,0),(172,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:46:54',NULL,'2022-06-30 12:46:54',0,NULL,0,1,0),(173,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:50:13',NULL,'2022-06-30 12:50:13',0,NULL,0,1,0),(174,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:51:34',NULL,'2022-06-30 12:51:34',0,NULL,0,1,0),(175,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:52:23',NULL,'2022-06-30 12:52:23',0,NULL,0,1,0),(176,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:54:16',NULL,'2022-06-30 12:54:16',0,NULL,0,1,0),(177,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:55:36',NULL,'2022-06-30 12:55:36',0,NULL,0,1,0),(178,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 12:56:23',NULL,'2022-06-30 12:56:23',0,NULL,0,1,0),(179,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:07:34',NULL,'2022-06-30 13:07:34',0,NULL,0,1,0),(180,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:12:01',NULL,'2022-06-30 13:12:01',0,NULL,0,1,0),(181,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:17:05',NULL,'2022-06-30 13:17:05',0,NULL,0,1,0),(182,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:21:32',NULL,'2022-06-30 13:21:32',0,NULL,0,1,0),(183,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:21:40',NULL,'2022-06-30 13:21:40',0,NULL,0,1,0),(184,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:22:10',NULL,'2022-06-30 13:22:10',0,NULL,0,1,0),(185,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:22:47',NULL,'2022-06-30 13:22:47',0,NULL,0,1,0),(186,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:25:58',NULL,'2022-06-30 13:25:58',0,NULL,0,1,0),(187,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:28:25',NULL,'2022-06-30 13:28:25',0,NULL,0,1,0),(188,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:31:03',NULL,'2022-06-30 13:31:03',0,NULL,0,1,0),(189,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:36:31',NULL,'2022-06-30 13:36:31',0,NULL,0,1,0),(190,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:37:17',NULL,'2022-06-30 13:37:17',0,NULL,0,1,0),(191,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:37:41',NULL,'2022-06-30 13:37:41',0,NULL,0,1,0),(192,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:38:02',NULL,'2022-06-30 13:38:02',0,NULL,0,1,0),(193,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:43:23',NULL,'2022-06-30 13:43:23',0,NULL,0,1,0),(194,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:45:07',NULL,'2022-06-30 13:45:07',0,NULL,0,1,0),(195,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:47:23',NULL,'2022-06-30 13:47:23',0,NULL,0,1,0),(196,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:53:32',NULL,'2022-06-30 13:53:32',0,NULL,0,1,0),(197,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:56:24',NULL,'2022-06-30 13:56:24',0,NULL,0,1,0),(198,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 13:57:02',NULL,'2022-06-30 13:57:02',0,NULL,0,1,0),(199,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 14:11:32',NULL,'2022-06-30 14:11:32',0,NULL,0,1,0),(200,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 14:28:25',NULL,'2022-06-30 14:28:25',0,NULL,0,1,0),(201,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 14:50:48',NULL,'2022-06-30 14:50:48',0,NULL,0,1,0),(202,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 14:53:57',NULL,'2022-06-30 14:53:57',0,NULL,0,1,0),(203,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 14:55:09',NULL,'2022-06-30 14:55:09',0,NULL,0,1,0),(204,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 14:56:56',NULL,'2022-06-30 14:56:56',0,NULL,0,1,0),(205,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 14:59:00',NULL,'2022-06-30 14:59:00',0,NULL,0,1,0),(206,1,NULL,'2022-06-30',0.00,0.00,0.00,500.00,1,NULL,'','ravi','2022-06-30 17:41:48',NULL,'2022-06-30 17:41:48',0,NULL,0,1,0),(207,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 17:46:22',NULL,'2022-06-30 17:46:22',0,NULL,0,1,0),(208,1,NULL,'2022-06-30',0.00,0.00,0.00,2000.00,1,NULL,'','ravi','2022-06-30 17:59:33',NULL,'2022-06-30 17:59:33',0,NULL,0,1,0),(209,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 18:01:34',NULL,'2022-06-30 18:01:34',0,NULL,0,1,0),(210,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 18:04:26',NULL,'2022-06-30 18:04:26',0,NULL,0,1,0),(211,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 18:07:03',NULL,'2022-06-30 18:07:03',0,NULL,0,1,0),(212,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 18:13:40',NULL,'2022-06-30 18:13:40',0,NULL,0,1,0),(213,1,NULL,'2022-06-30',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-06-30 18:17:49',NULL,'2022-06-30 18:17:49',0,NULL,0,1,0),(214,1,NULL,'2022-07-01',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-07-01 11:20:36',NULL,'2022-07-01 11:20:36',0,NULL,0,1,0),(215,1,NULL,'2022-07-01',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-07-01 11:23:15',NULL,'2022-07-01 11:23:15',0,NULL,0,1,0),(216,1,NULL,'2022-07-01',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-07-01 11:26:47',NULL,'2022-07-01 11:26:47',0,NULL,0,1,0),(218,1,NULL,'2022-07-01',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-07-01 11:27:45',NULL,'2022-07-01 11:27:45',0,NULL,0,1,0),(219,1,NULL,'2022-07-01',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-07-01 11:36:40',NULL,'2022-07-01 11:36:40',0,NULL,0,1,0),(220,1,NULL,'2022-07-01',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-07-01 11:39:06',NULL,'2022-07-01 11:39:06',0,NULL,0,1,0),(221,1,NULL,'2022-07-01',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-07-01 12:14:12',NULL,'2022-07-01 12:14:12',0,NULL,0,1,0),(222,1,NULL,'2022-07-01',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-07-01 17:43:56',NULL,'2022-07-01 17:43:56',0,NULL,0,1,0),(223,1,NULL,'2022-07-01',0.00,0.00,0.00,0.00,1,NULL,'','ravi','2022-07-01 17:49:01',NULL,'2022-07-01 17:49:01',0,NULL,0,1,0),(224,1,NULL,'2022-07-02',0.00,0.00,0.00,0.00,3,1,'2541241','ravi','2022-07-02 13:53:35',NULL,'2022-07-02 13:53:35',0,NULL,0,1,0),(225,1,NULL,'2022-07-02',0.00,0.00,0.00,0.00,2,NULL,'2541','ravi','2022-07-02 14:02:45',NULL,'2022-07-02 14:02:45',0,NULL,0,1,0),(226,1,NULL,'2022-07-02',0.00,0.00,0.00,0.00,2,NULL,'2541','ravi','2022-07-02 14:06:42',NULL,'2022-07-02 14:06:42',0,NULL,0,1,0),(227,1,NULL,'2022-07-02',0.00,0.00,0.00,0.00,3,3,'254125412541241','ravi','2022-07-02 14:08:59',NULL,'2022-07-02 14:08:59',0,NULL,0,1,0),(228,1,NULL,'2022-07-02',0.00,0.00,0.00,254000.00,1,NULL,'','ravi','2022-07-02 14:12:50',NULL,'2022-07-02 14:12:50',0,NULL,0,1,0),(229,1,NULL,'2022-07-02',0.00,0.00,0.00,0.00,2,NULL,'2541','ravi','2022-07-02 14:13:04',NULL,'2022-07-02 14:13:04',0,NULL,0,1,0),(230,1,1,'2022-07-02',0.00,0.00,0.00,0.00,3,2,'254212541241','ravi','2022-07-02 14:14:54',NULL,'2022-07-02 14:14:54',0,NULL,0,1,0),(231,1,NULL,'2022-07-02',0.00,0.00,0.00,0.00,3,2,'236521411','ravi','2022-07-02 14:27:03',NULL,'2022-07-02 14:27:03',0,NULL,0,1,0);
/*!40000 ALTER TABLE `tbl_sales` ENABLE KEYS */;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_sales_AFTER_UPDATE` AFTER UPDATE ON `tbl_sales` FOR EACH ROW BEGIN
	insert into PayBillApp.tbl_sales_log(sales_id,
											client_id,
											customer_id,
											sales_date,
											transport_charge,
											packing_charge,
											other_charge,
											paid_cash,
											payment_type_id,
											upi_type_id,
											trans_no,
											created_by,
											created_date,
											updated_by,
											updated_date,
											is_deleted,
											remarks,
											is_invoice_delivered,
											is_locked,
											log_remarks)
									values(old.sales_id,
											old.client_id,
											old.customer_id,
											old.sales_date,
											old.transport_charge,
											old.packing_charge,
											old.other_charge,
											old.paid_cash,
											old.payment_type_id,
											old.upi_type_id,
											old.trans_no,
											old.created_by,
											old.created_date,
											old.updated_by,
											old.updated_date,
											old.is_deleted,
											old.remarks,
											old.is_invoice_delivered,
											old.is_locked,
											'Sales invoice updated');
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_sales_AFTER_DELETE` AFTER DELETE ON `tbl_sales` FOR EACH ROW BEGIN
	insert into PayBillApp.tbl_sales_log(sales_id,
											client_id,
											customer_id,
											sales_date,
											transport_charge,
											packing_charge,
											other_charge,
											paid_cash,
											payment_type_id,
											upi_type_id,
											trans_no,
											created_by,
											created_date,
											updated_by,
											updated_date,
											is_deleted,
											remarks,
											is_invoice_delivered,
											is_locked,
											log_remarks)
									values(old.sales_id,
											old.client_id,
											old.customer_id,
											old.sales_date,
											old.transport_charge,
											old.packing_charge,
											old.other_charge,
											old.paid_cash,
											old.payment_type_id,
											old.upi_type_id,
											old.trans_no,
											old.created_by,
											old.created_date,
											old.updated_by,
											old.updated_date,
											old.is_deleted,
											old.remarks,
											old.is_invoice_delivered,
											old.is_locked,
											'Sales invoice deleted');
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `tbl_sales_details`
--

DROP TABLE IF EXISTS `tbl_sales_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_sales_details` (
  `sales_details_id` bigint NOT NULL AUTO_INCREMENT,
  `sales_id` bigint DEFAULT NULL,
  `item_id` bigint NOT NULL,
  `item_quantity` bigint NOT NULL,
  `item_price` decimal(19,2) NOT NULL,
  `item_total` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_discount_in_per` decimal(4,2) NOT NULL,
  `item_discount_in_rs` decimal(19,2) NOT NULL,
  `special_discount_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_taxable_value` decimal(19,2) NOT NULL DEFAULT '0.00',
  `cgst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `sgst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `igst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `cgst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `sgst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `igst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_total_value_incl_gst` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_saving_amount` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_mrp_price` decimal(19,2) NOT NULL DEFAULT '0.00',
  `purchase_rate_incl_gst` decimal(19,2) NOT NULL DEFAULT '0.00',
  `is_deleted` int NOT NULL DEFAULT '0',
  `updated_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `remarks` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`sales_details_id`),
  KEY `fk__tbl_sales__item___17036cc0` (`item_id`),
  KEY `idx_tbl_sal_saleid_item` (`sales_id`,`item_id`,`is_deleted`),
  KEY `idx_tbl_sal_dtls_saledi_del` (`sales_id`,`is_deleted`) /*!80000 INVISIBLE */,
  KEY `idx_tbl_sls_dtls_del` (`is_deleted`),
  KEY `idx_tbl_sls_dtls_saleid` (`sales_id`),
  CONSTRAINT `fk__tbl_sales__item___17036cc0` FOREIGN KEY (`item_id`) REFERENCES `tbl_items` (`item_id`),
  CONSTRAINT `fk__tbl_sales__sales__160f4887` FOREIGN KEY (`sales_id`) REFERENCES `tbl_sales` (`sales_id`)
) ENGINE=InnoDB AUTO_INCREMENT=803 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_sales_details`
--

LOCK TABLES `tbl_sales_details` WRITE;
/*!40000 ALTER TABLE `tbl_sales_details` DISABLE KEYS */;
INSERT INTO `tbl_sales_details` VALUES (34,41,36,10,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-01 17:34:57',NULL),(35,41,10,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-01 17:34:57',NULL),(36,42,9,12,9.71,116.52,0.00,0.00,0.00,116.52,1.00,2.00,0.00,1.17,2.33,0.00,120.02,23.98,12.00,8.00,0,'2021-09-01 17:34:57',NULL),(37,42,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-01 17:34:57',NULL),(38,42,26,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-01 17:34:57',NULL),(39,43,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-02 17:29:58',NULL),(40,44,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-02 17:30:20',NULL),(41,44,138,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-02 17:30:20',NULL),(42,45,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 08:23:10',NULL),(44,47,508,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-03 10:50:53',NULL),(45,48,34,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 10:51:36',NULL),(46,48,11,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 10:51:36',NULL),(47,48,75,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 10:51:36',NULL),(48,48,18,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 10:51:36',NULL),(49,49,137,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 13:30:31',NULL),(50,49,384,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 13:30:31',NULL),(51,49,602,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-03 13:30:31',NULL),(52,50,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 15:11:11',NULL),(53,50,40,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 15:11:11',NULL),(54,50,46,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 15:11:11',NULL),(55,50,10,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 15:11:11',NULL),(56,51,35,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 16:50:30',NULL),(57,51,138,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 16:50:30',NULL),(58,51,41,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 16:50:30',NULL),(59,52,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 16:56:55',NULL),(60,52,137,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 16:56:55',NULL),(61,53,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 17:01:43',NULL),(62,54,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 18:46:14',NULL),(63,54,520,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 18:46:14',NULL),(64,55,34,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:04:14',NULL),(65,55,33,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:04:14',NULL),(66,55,230,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:04:14',NULL),(67,55,602,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:04:14',NULL),(68,56,137,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:32:20',NULL),(69,56,44,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:32:20',NULL),(70,56,69,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:32:20',NULL),(71,56,60,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:32:20',NULL),(72,57,14,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-03 19:35:42',NULL),(73,58,421,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:36:36',NULL),(74,58,79,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:36:36',NULL),(75,59,421,37,9.71,359.27,0.00,0.00,0.00,359.27,1.00,2.00,0.00,3.59,7.19,0.00,370.05,73.95,12.00,8.00,0,'2021-09-03 19:39:40',NULL),(76,59,280,27,9.71,262.17,0.00,0.00,0.00,262.17,1.00,2.00,0.00,2.62,5.24,0.00,270.03,53.97,12.00,8.00,0,'2021-09-03 19:39:40',NULL),(77,59,42,13,9.71,126.23,0.00,0.00,0.00,126.23,1.00,2.00,0.00,1.26,2.52,0.00,130.01,25.99,12.00,8.00,0,'2021-09-03 19:39:40',NULL),(78,59,264,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:39:40',NULL),(79,60,422,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:50:51',NULL),(80,60,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:50:51',NULL),(81,60,261,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 19:50:51',NULL),(82,61,35,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(83,61,36,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(84,61,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(85,61,137,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(86,61,138,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(87,61,216,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(88,61,230,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(89,61,261,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(90,61,262,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(91,61,600,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-03 20:04:12',NULL),(92,62,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:17:54',NULL),(93,62,83,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:17:54',NULL),(94,63,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:18:07',NULL),(95,63,83,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:18:07',NULL),(96,64,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:19:43',NULL),(97,64,34,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:19:43',NULL),(98,65,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:20:00',NULL),(99,65,34,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:20:00',NULL),(100,66,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:22:32',NULL),(101,66,34,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-04 14:22:32',NULL),(102,67,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,1,'2021-09-05 15:44:14','fcvdgh'),(103,67,138,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,1,'2021-09-05 15:44:14','fcvdgh'),(104,67,19,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,1,'2021-09-05 15:44:14','fcvdgh'),(105,68,36,1,9.71,9.71,0.00,0.00,0.00,9.71,6.00,6.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,1,'2021-09-06 07:44:27','tekdmdm'),(106,69,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,1,'2021-09-06 07:56:51','ejdjndjf'),(107,69,11,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,1,'2021-09-06 07:56:38','eudjfk'),(108,70,36,1,9.71,9.71,0.00,0.00,0.00,9.71,8.00,8.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-06 08:16:51',NULL),(109,70,11,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-06 08:16:52',NULL),(110,71,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-07 05:08:13',NULL),(111,71,509,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-07 05:08:13',NULL),(112,72,35,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 07:47:50',NULL),(113,73,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 07:50:35',NULL),(114,74,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 07:59:42',NULL),(115,75,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 08:00:13',NULL),(116,76,35,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-15 20:27:14',NULL),(117,76,138,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 20:27:15',NULL),(118,76,69,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 20:27:15',NULL),(119,77,35,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 20:36:19',NULL),(120,78,138,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 20:40:32',NULL),(121,79,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 20:46:57',NULL),(122,80,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 20:58:41',NULL),(123,81,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-15 21:00:51',NULL),(124,82,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:00:53',NULL),(125,82,147,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:00:54',NULL),(126,83,35,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-16 06:28:35',NULL),(127,83,89,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:28:35',NULL),(128,83,34,1,588.35,588.35,0.00,0.00,0.00,588.35,1.00,2.00,0.00,5.88,11.77,0.00,606.00,0.00,12.00,8.00,0,'2021-09-16 06:28:35',NULL),(129,83,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:28:35',NULL),(130,83,72,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:28:35',NULL),(131,84,34,8,588.35,4706.80,0.00,0.00,0.00,4706.80,1.00,2.00,0.00,47.07,94.14,0.00,4848.01,0.00,12.00,8.00,0,'2021-09-16 06:50:15',NULL),(132,84,601,48,9.71,466.08,0.00,0.00,0.00,466.08,1.00,2.00,0.00,4.66,9.32,0.00,480.06,95.94,12.00,8.00,0,'2021-09-16 06:50:16',NULL),(133,84,216,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:50:16',NULL),(134,85,137,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:50:46',NULL),(135,86,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:54:42',NULL),(136,86,262,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:54:42',NULL),(137,87,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:57:32',NULL),(138,87,271,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-16 06:57:33',NULL),(139,88,39,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 15:19:33',NULL),(140,88,148,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:19:33',NULL),(141,88,142,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 15:19:33',NULL),(142,88,280,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:19:33',NULL),(143,88,71,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:19:33',NULL),(144,89,29,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:20:12',NULL),(145,90,281,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 15:21:56',NULL),(146,90,430,9,9.71,87.39,0.00,0.00,0.00,87.39,1.00,2.00,0.00,0.87,1.75,0.00,90.01,17.99,12.00,8.00,0,'2021-09-23 15:21:56',NULL),(147,90,645,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:21:56',NULL),(148,90,128,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:21:56',NULL),(149,91,527,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:27:14',NULL),(150,91,677,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:27:14',NULL),(151,91,596,9,9.71,87.39,0.00,0.00,0.00,87.39,1.00,2.00,0.00,0.87,1.75,0.00,90.01,17.99,12.00,8.00,0,'2021-09-23 15:27:14',NULL),(152,91,68,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:27:14',NULL),(153,91,7,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 15:27:14',NULL),(154,91,40,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:27:14',NULL),(155,91,10,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 15:27:14',NULL),(156,91,61,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:27:14',NULL),(157,92,422,5,1524.27,7621.35,0.00,0.00,0.00,7621.35,1.00,2.00,0.00,76.21,152.43,0.00,7849.99,0.00,12.00,8.00,0,'2021-09-23 15:30:27',NULL),(158,92,196,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:30:27',NULL),(159,92,596,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:30:28',NULL),(160,93,620,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 15:32:59',NULL),(161,93,460,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 15:32:59',NULL),(162,93,234,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:32:59',NULL),(163,93,8,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:32:59',NULL),(164,94,72,10,86.41,864.10,0.00,0.00,0.00,864.10,1.00,2.00,0.00,8.64,17.28,0.00,890.02,0.00,12.00,8.00,0,'2021-09-23 15:33:57',NULL),(165,94,33,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:33:57',NULL),(166,94,7,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 15:33:57',NULL),(167,95,10,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:35:28',NULL),(168,95,34,3,588.35,1765.05,0.00,0.00,0.00,1765.05,1.00,2.00,0.00,17.65,35.30,0.00,1818.00,0.00,12.00,8.00,0,'2021-09-23 15:35:28',NULL),(169,95,9,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:35:28',NULL),(170,95,44,9,9.71,87.39,0.00,0.00,0.00,87.39,1.00,2.00,0.00,0.87,1.75,0.00,90.01,17.99,12.00,8.00,0,'2021-09-23 15:35:28',NULL),(171,96,261,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 15:36:27',NULL),(172,96,150,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 15:36:27',NULL),(173,96,64,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:36:27',NULL),(174,97,16,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:38:17',NULL),(175,97,280,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:38:17',NULL),(176,97,571,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:38:18',NULL),(177,97,341,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:38:18',NULL),(178,97,568,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:38:18',NULL),(179,98,78,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:40:56',NULL),(180,98,34,2,588.35,1176.70,0.00,0.00,0.00,1176.70,1.00,2.00,0.00,11.77,23.53,0.00,1212.00,0.00,12.00,8.00,0,'2021-09-23 15:40:56',NULL),(181,98,571,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:40:56',NULL),(182,98,620,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 15:40:56',NULL),(183,98,79,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:40:56',NULL),(184,98,460,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:40:56',NULL),(185,99,33,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 15:43:53',NULL),(186,99,189,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:43:53',NULL),(187,99,61,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:43:53',NULL),(188,99,350,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:43:53',NULL),(189,99,155,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:43:53',NULL),(190,99,272,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:43:53',NULL),(191,100,568,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:44:54',NULL),(192,100,658,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:44:54',NULL),(193,100,620,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 15:44:54',NULL),(194,100,217,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:44:54',NULL),(195,100,59,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 15:44:54',NULL),(196,101,349,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:45:49',NULL),(197,101,7,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:45:49',NULL),(198,101,72,7,86.41,604.87,0.00,0.00,0.00,604.87,1.00,2.00,0.00,6.05,12.10,0.00,623.02,0.00,12.00,8.00,0,'2021-09-23 15:45:49',NULL),(199,101,9,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 15:45:49',NULL),(200,102,568,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:48:06',NULL),(201,102,55,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:48:06',NULL),(202,102,83,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:48:06',NULL),(203,102,35,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 15:48:06',NULL),(204,102,31,10,87.38,873.80,0.00,0.00,0.00,873.80,1.00,2.00,0.00,8.74,17.48,0.00,900.02,0.00,12.00,8.00,0,'2021-09-23 15:48:06',NULL),(205,102,283,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:48:06',NULL),(206,102,75,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:48:06',NULL),(207,102,19,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 15:48:06',NULL),(208,103,422,10,1524.27,15242.70,0.00,0.00,0.00,15242.70,1.00,2.00,0.00,152.43,304.85,0.00,15699.98,0.00,12.00,8.00,0,'2021-09-23 15:49:28',NULL),(209,103,47,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:49:28',NULL),(210,103,137,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:49:28',NULL),(211,103,202,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:49:28',NULL),(212,103,453,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:49:28',NULL),(213,103,32,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:49:28',NULL),(214,104,26,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:50:43',NULL),(215,104,254,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:50:43',NULL),(216,104,350,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:50:43',NULL),(217,104,35,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:50:43',NULL),(218,105,261,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:52:07',NULL),(219,105,42,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 15:52:08',NULL),(220,105,34,9,588.35,5295.15,0.00,0.00,0.00,5295.15,1.00,2.00,0.00,52.95,105.90,0.00,5454.00,0.00,12.00,8.00,0,'2021-09-23 15:52:08',NULL),(221,105,16,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:52:08',NULL),(222,105,158,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 15:52:08',NULL),(223,105,87,9,9.71,87.39,0.00,0.00,0.00,87.39,1.00,2.00,0.00,0.87,1.75,0.00,90.01,17.99,12.00,8.00,0,'2021-09-23 15:52:08',NULL),(224,106,31,5,87.38,436.90,0.00,0.00,0.00,436.90,1.00,2.00,0.00,4.37,8.74,0.00,450.01,0.00,12.00,8.00,0,'2021-09-23 15:53:31',NULL),(225,106,8,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:53:31',NULL),(226,106,11,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:53:31',NULL),(227,106,65,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 15:53:31',NULL),(228,106,460,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:53:31',NULL),(229,107,7,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 15:54:15',NULL),(230,107,620,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:54:15',NULL),(231,107,103,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:54:15',NULL),(232,107,544,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:54:15',NULL),(233,108,302,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:55:07',NULL),(234,108,21,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:55:07',NULL),(235,108,78,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:55:07',NULL),(236,108,7,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:55:07',NULL),(237,109,281,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:56:48',NULL),(238,109,47,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 15:56:48',NULL),(239,109,105,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 15:56:48',NULL),(240,109,476,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:56:48',NULL),(241,109,661,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:56:48',NULL),(242,109,32,9,9.71,87.39,0.00,0.00,0.00,87.39,1.00,2.00,0.00,0.87,1.75,0.00,90.01,17.99,12.00,8.00,0,'2021-09-23 15:56:48',NULL),(243,109,33,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:56:48',NULL),(244,110,195,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 15:57:18',NULL),(245,111,303,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:58:04',NULL),(246,111,41,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 15:58:04',NULL),(247,111,280,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 15:58:04',NULL),(248,111,112,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:58:04',NULL),(249,112,422,10,1524.27,15242.70,0.00,0.00,0.00,15242.70,1.00,2.00,0.00,152.43,304.85,0.00,15699.98,0.00,12.00,8.00,0,'2021-09-23 15:59:25',NULL),(250,112,280,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 15:59:25',NULL),(251,112,202,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 15:59:25',NULL),(252,112,48,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 15:59:25',NULL),(253,112,72,5,86.41,432.05,0.00,0.00,0.00,432.05,1.00,2.00,0.00,4.32,8.64,0.00,445.01,0.00,12.00,8.00,0,'2021-09-23 15:59:25',NULL),(254,113,349,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:00:42',NULL),(255,113,83,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 16:00:42',NULL),(256,113,71,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 16:00:42',NULL),(257,113,40,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 16:00:42',NULL),(258,114,457,40,9.71,388.40,0.00,0.00,0.00,388.40,1.00,2.00,0.00,3.88,7.77,0.00,400.05,79.95,12.00,8.00,0,'2021-09-23 16:04:20',NULL),(259,114,280,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 16:04:20',NULL),(260,115,78,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 16:05:12',NULL),(261,115,8,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 16:05:12',NULL),(262,115,22,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:05:12',NULL),(263,115,551,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 16:05:12',NULL),(264,116,78,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 16:06:17',NULL),(265,116,523,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 16:06:17',NULL),(266,116,583,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 16:06:17',NULL),(267,116,645,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 16:06:17',NULL),(268,116,43,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 16:06:17',NULL),(269,118,372,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 16:08:34',NULL),(270,118,638,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 16:08:34',NULL),(271,118,264,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 16:08:34',NULL),(272,118,151,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:08:34',NULL),(273,118,8,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:08:35',NULL),(274,119,39,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:09:34',NULL),(275,119,371,9,9.71,87.39,0.00,0.00,0.00,87.39,1.00,2.00,0.00,0.87,1.75,0.00,90.01,17.99,12.00,8.00,0,'2021-09-23 16:09:34',NULL),(276,119,18,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 16:09:34',NULL),(277,119,51,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 16:09:34',NULL),(278,120,460,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(279,120,283,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(280,120,72,4,86.41,345.64,0.00,0.00,0.00,345.64,1.00,2.00,0.00,3.46,6.91,0.00,356.01,0.00,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(281,120,81,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(282,120,33,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(283,120,620,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(284,120,6,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(285,120,8,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(286,120,61,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(287,120,11,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(288,120,82,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 16:10:54',NULL),(289,121,7,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:11:58',NULL),(290,122,658,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:12:21',NULL),(291,122,152,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 16:12:21',NULL),(292,122,8,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 16:12:21',NULL),(293,122,457,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 16:12:21',NULL),(294,123,216,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 16:36:41',NULL),(295,123,33,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:36:41',NULL),(296,123,15,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 16:36:41',NULL),(297,123,367,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:36:41',NULL),(298,123,659,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:36:41',NULL),(299,123,8,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 16:36:41',NULL),(300,123,9,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 16:36:41',NULL),(301,123,10,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 16:36:41',NULL),(302,124,602,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 16:37:34',NULL),(303,124,44,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 16:37:34',NULL),(304,125,72,4,86.41,345.64,0.00,0.00,0.00,345.64,1.00,2.00,0.00,3.46,6.91,0.00,356.01,0.00,12.00,8.00,0,'2021-09-23 16:44:39',NULL),(305,125,32,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 16:44:39',NULL),(306,125,285,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 16:44:39',NULL),(307,125,69,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 16:44:39',NULL),(308,125,287,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 16:44:39',NULL),(309,126,47,10,3368.93,33689.30,0.00,0.00,0.00,33689.30,1.00,2.00,0.00,336.89,673.79,0.00,34699.98,0.00,12.00,8.00,0,'2021-09-23 17:52:54',NULL),(310,126,137,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 17:52:54',NULL),(311,126,205,4,9.71,38.84,0.00,0.00,0.00,38.84,1.00,2.00,0.00,0.39,0.78,0.00,40.01,7.99,12.00,8.00,0,'2021-09-23 17:52:54',NULL),(312,126,548,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 17:52:55',NULL),(313,126,33,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 17:52:55',NULL),(314,127,68,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 17:53:40',NULL),(315,127,32,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 17:53:40',NULL),(316,127,217,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 17:53:40',NULL),(317,127,8,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 17:53:40',NULL),(318,128,69,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 17:55:55',NULL),(319,128,677,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 17:55:55',NULL),(320,128,72,10,86.41,864.10,0.00,0.00,0.00,864.10,1.00,2.00,0.00,8.64,17.28,0.00,890.02,0.00,12.00,8.00,0,'2021-09-23 17:55:55',NULL),(321,128,32,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 17:55:55',NULL),(322,128,83,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 17:55:55',NULL),(323,128,457,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 17:55:55',NULL),(324,128,264,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 17:55:55',NULL),(325,128,304,2,5901.94,11803.88,0.00,0.00,0.00,11803.88,1.00,2.00,0.00,118.04,236.08,0.00,12158.00,0.00,12.00,8.00,0,'2021-09-23 17:55:55',NULL),(326,129,95,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 17:57:43',NULL),(327,129,537,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 17:57:43',NULL),(328,129,8,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 17:57:43',NULL),(329,129,286,6,471.84,2831.04,0.00,0.00,0.00,2831.04,1.00,2.00,0.00,28.31,56.62,0.00,2915.97,0.00,12.00,8.00,0,'2021-09-23 17:57:43',NULL),(330,130,28,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(331,130,29,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(332,130,30,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(333,130,31,4,87.38,349.52,0.00,0.00,0.00,349.52,1.00,2.00,0.00,3.50,6.99,0.00,360.01,0.00,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(334,130,32,5,9.71,48.55,0.00,0.00,0.00,48.55,1.00,2.00,0.00,0.49,0.97,0.00,50.01,9.99,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(335,130,33,6,9.71,58.26,0.00,0.00,0.00,58.26,1.00,2.00,0.00,0.58,1.17,0.00,60.01,11.99,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(336,130,34,7,588.35,4118.45,0.00,0.00,0.00,4118.45,1.00,2.00,0.00,41.18,82.37,0.00,4242.00,0.00,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(337,130,35,8,9.71,77.68,0.00,0.00,0.00,77.68,1.00,2.00,0.00,0.78,1.55,0.00,80.01,15.99,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(338,130,36,9,229268.93,2063420.37,0.00,0.00,0.00,2063420.37,1.00,2.00,0.00,20634.20,41268.41,0.00,2125322.98,0.00,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(339,130,37,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(340,130,38,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(341,130,57,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(342,130,264,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 18:18:16',NULL),(343,131,264,39,9.71,378.69,0.00,0.00,0.00,378.69,1.00,2.00,0.00,3.79,7.57,0.00,390.05,77.95,12.00,8.00,0,'2021-09-23 18:38:08',NULL),(344,131,457,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(345,131,421,9,873.79,7864.11,0.00,0.00,0.00,7864.11,1.00,2.00,0.00,78.64,157.28,0.00,8100.03,0.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(346,131,35,11,9.71,106.81,0.00,0.00,0.00,106.81,1.00,2.00,0.00,1.07,2.14,0.00,110.02,21.98,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(347,131,36,10,229268.93,2292689.30,0.00,0.00,0.00,2292689.30,1.00,2.00,0.00,22926.89,45853.79,0.00,2361469.98,0.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(348,131,72,14,86.41,1209.74,0.00,0.00,0.00,1209.74,1.00,2.00,0.00,12.10,24.19,0.00,1246.03,0.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(349,131,28,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(350,131,29,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(351,131,30,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(352,131,31,1,87.38,87.38,0.00,0.00,0.00,87.38,1.00,2.00,0.00,0.87,1.75,0.00,90.00,0.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(353,131,32,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(354,131,33,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(355,131,34,2,588.35,1176.70,0.00,0.00,0.00,1176.70,1.00,2.00,0.00,11.77,23.53,0.00,1212.00,0.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(356,131,37,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(357,131,38,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(358,131,39,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(359,131,55,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(360,131,56,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(361,131,57,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(362,131,58,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(363,131,59,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(364,131,60,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(365,131,83,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(366,131,137,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(367,131,138,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(368,131,216,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(369,131,230,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(370,131,261,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(371,131,262,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(372,131,600,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(373,131,601,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(374,131,602,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(375,131,15,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(376,131,16,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(377,131,17,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(378,131,65,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(379,131,103,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(380,131,113,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(381,131,175,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(382,131,193,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(383,131,244,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(384,131,247,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(385,131,285,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(386,131,287,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(387,131,303,3,9.71,29.13,0.00,0.00,0.00,29.13,1.00,2.00,0.00,0.29,0.58,0.00,30.00,6.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(388,131,368,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(389,131,376,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(390,131,426,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(391,131,453,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(392,131,454,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(393,131,491,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(394,131,492,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(395,131,493,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(396,131,571,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(397,131,596,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(398,131,633,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(399,131,21,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(400,131,22,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(401,131,23,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:09',NULL),(402,131,27,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(403,131,43,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(404,131,44,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(405,131,45,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(406,131,46,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(407,131,51,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(408,131,52,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(409,131,53,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(410,131,54,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(411,131,61,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(412,131,71,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(413,131,76,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(414,131,77,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(415,131,78,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(416,131,79,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(417,131,82,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(418,131,86,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(419,131,88,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(420,131,92,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(421,131,96,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(422,131,97,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(423,131,99,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(424,131,102,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(425,131,105,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(426,131,109,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(427,131,112,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(428,131,114,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(429,131,119,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(430,131,120,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(431,131,121,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(432,131,122,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(433,131,127,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(434,131,128,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(435,131,129,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(436,131,130,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(437,131,131,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(438,131,132,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(439,131,133,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(440,131,134,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(441,131,144,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(442,131,147,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(443,131,162,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(444,131,167,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(445,131,168,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(446,131,169,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(447,131,170,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(448,131,182,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(449,131,184,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(450,131,190,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(451,131,191,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(452,131,194,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(453,131,195,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(454,131,196,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(455,131,197,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(456,131,198,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(457,131,199,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(458,131,200,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(459,131,201,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(460,131,202,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(461,131,204,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(462,131,205,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(463,131,206,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(464,131,207,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(465,131,208,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(466,131,209,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(467,131,210,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(468,131,211,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(469,131,212,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(470,131,213,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(471,131,214,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:10',NULL),(472,131,215,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(473,131,217,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(474,131,218,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(475,131,219,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(476,131,220,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(477,131,221,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(478,131,222,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(479,131,223,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(480,131,224,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(481,131,225,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(482,131,226,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(483,131,227,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(484,131,228,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(485,131,229,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(486,131,231,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(487,131,232,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(488,131,233,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(489,131,234,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(490,131,235,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(491,131,236,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(492,131,237,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(493,131,238,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(494,131,239,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(495,131,240,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(496,131,241,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(497,131,242,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(498,131,243,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(499,131,245,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(500,131,246,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(501,131,248,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(502,131,249,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(503,131,250,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(504,131,251,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(505,131,252,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(506,131,253,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(507,131,265,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(508,131,267,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(509,131,271,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(510,131,280,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(511,131,281,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(512,131,282,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(513,131,288,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(514,131,289,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(515,131,294,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(516,131,295,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(517,131,296,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(518,131,297,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(519,131,300,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(520,131,301,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(521,131,302,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(522,131,304,1,5901.94,5901.94,0.00,0.00,0.00,5901.94,1.00,2.00,0.00,59.02,118.04,0.00,6079.00,0.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(523,131,305,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(524,131,306,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(525,131,324,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(526,131,328,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:38:11',NULL),(527,132,65,13,9.71,126.23,0.00,0.00,0.00,126.23,1.00,2.00,0.00,1.26,2.52,0.00,130.01,25.99,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(528,132,103,18,9.71,174.78,0.00,0.00,0.00,174.78,1.00,2.00,0.00,1.75,3.50,0.00,180.03,35.97,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(529,132,113,32,9.71,310.72,0.00,0.00,0.00,310.72,1.00,2.00,0.00,3.11,6.21,0.00,320.04,63.96,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(530,132,175,10,9.71,97.10,0.00,0.00,0.00,97.10,1.00,2.00,0.00,0.97,1.94,0.00,100.01,19.99,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(531,132,193,7,9.71,67.97,0.00,0.00,0.00,67.97,1.00,2.00,0.00,0.68,1.36,0.00,70.01,13.99,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(532,132,244,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(533,132,247,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(534,132,285,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(535,132,287,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(536,132,303,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(537,132,368,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(538,132,376,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(539,132,426,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(540,132,453,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(541,132,454,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(542,132,491,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(543,132,492,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(544,132,493,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(545,132,571,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(546,132,596,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(547,132,633,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(548,132,27,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(549,132,88,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(550,132,102,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(551,132,392,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:40:30',NULL),(552,133,81,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(553,133,101,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(554,133,190,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(555,133,231,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(556,133,250,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(557,133,258,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(558,133,316,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(559,133,329,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(560,133,330,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(561,133,331,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(562,133,364,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(563,133,492,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(564,133,533,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(565,133,540,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(566,133,543,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(567,133,544,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(568,133,545,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(569,133,546,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(570,133,568,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(571,133,577,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(572,133,595,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(573,133,629,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(574,133,630,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(575,133,669,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(576,133,673,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(577,133,679,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(578,133,683,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(579,133,6,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(580,133,7,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(581,133,8,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(582,133,28,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(583,133,29,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(584,133,30,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(585,133,40,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(586,133,41,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(587,133,42,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(588,133,43,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(589,133,44,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(590,133,45,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(591,133,46,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(592,133,47,1,3368.93,3368.93,0.00,0.00,0.00,3368.93,1.00,2.00,0.00,33.69,67.38,0.00,3470.00,0.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(593,133,48,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(594,133,49,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(595,133,50,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(596,133,51,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(597,133,52,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(598,133,53,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(599,133,54,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(600,133,63,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(601,133,66,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(602,133,73,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(603,133,86,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(604,133,93,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(605,133,98,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(606,133,99,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(607,133,107,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(608,133,108,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(609,133,109,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(610,133,110,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(611,133,212,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(612,133,213,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(613,133,216,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(614,133,224,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(615,133,236,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(616,133,279,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(617,133,300,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(618,133,354,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(619,133,393,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(620,133,394,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(621,133,395,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(622,133,396,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(623,133,470,2,9.71,19.42,0.00,0.00,0.00,19.42,1.00,2.00,0.00,0.19,0.39,0.00,20.00,4.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(624,133,482,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(625,133,526,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(626,133,530,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(627,133,538,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(628,133,539,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(629,133,575,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(630,133,606,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(631,133,626,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(632,133,631,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(633,133,647,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(634,133,648,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(635,133,649,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(636,133,650,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(637,133,670,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(638,133,671,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(639,133,82,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(640,133,88,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(641,133,119,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(642,133,120,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(643,133,121,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(644,133,122,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(645,133,169,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(646,133,170,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(647,133,176,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(648,133,215,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(649,133,233,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(650,133,249,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(651,133,253,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(652,133,260,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(653,133,265,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(654,133,266,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(655,133,267,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(656,133,268,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(657,133,269,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(658,133,270,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(659,133,271,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(660,133,274,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(661,133,289,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(662,133,344,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(663,133,347,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:29',NULL),(664,133,356,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(665,133,374,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(666,133,390,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(667,133,391,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(668,133,400,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(669,133,430,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(670,133,447,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(671,133,456,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(672,133,457,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(673,133,498,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(674,133,504,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(675,133,542,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(676,133,554,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(677,133,576,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(678,133,587,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(679,133,611,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(680,133,617,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(681,133,635,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(682,133,653,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(683,133,667,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(684,133,678,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(685,133,686,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(686,133,699,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-23 18:44:30',NULL),(687,134,36,1,229268.93,229268.93,0.00,0.00,0.00,229268.93,1.00,2.00,0.00,2292.69,4585.38,0.00,236147.00,0.00,12.00,8.00,0,'2021-09-24 14:14:03',NULL),(688,135,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-29 13:33:39',NULL),(689,136,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-29 13:34:03',NULL),(690,137,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-29 13:36:57',NULL),(691,137,597,4,10.00,40.00,0.00,0.00,0.00,40.00,1.00,2.00,0.00,0.40,0.80,0.00,41.20,6.80,12.00,8.00,0,'2022-06-29 13:36:57',NULL),(692,138,19,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-29 13:40:04',NULL),(693,138,28,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-29 13:40:05',NULL),(694,138,209,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-29 13:40:05',NULL),(695,139,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-29 13:48:03',NULL),(696,139,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-29 13:48:04',NULL),(697,140,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-29 17:17:42',NULL),(698,141,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-29 17:30:42',NULL),(699,142,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-29 17:30:55',NULL),(702,153,288,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 06:17:25',NULL),(703,154,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-30 06:25:04',NULL),(704,155,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-30 11:17:07',NULL),(705,156,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-30 11:44:00',NULL),(706,157,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-30 11:44:31',NULL),(707,158,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-30 12:00:45',NULL),(708,160,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:06:09',NULL),(709,161,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-30 12:11:28',NULL),(710,162,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 12:13:01',NULL),(711,163,606,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:20:02',NULL),(712,164,211,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:21:56',NULL),(713,165,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:26:11',NULL),(714,166,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:27:51',NULL),(715,167,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:30:43',NULL),(716,168,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:34:44',NULL),(717,169,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:40:23',NULL),(718,170,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:41:10',NULL),(719,171,604,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:45:01',NULL),(720,172,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 12:46:54',NULL),(721,173,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:50:13',NULL),(722,174,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-30 12:51:34',NULL),(723,175,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 12:52:23',NULL),(724,176,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 12:54:16',NULL),(725,177,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-30 12:55:36',NULL),(726,178,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 12:56:23',NULL),(727,179,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 13:07:34',NULL),(728,180,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-30 13:12:01',NULL),(729,181,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:17:05',NULL),(730,182,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:21:32',NULL),(731,183,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:21:40',NULL),(732,184,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:22:10',NULL),(733,185,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:22:48',NULL),(734,186,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 13:25:59',NULL),(735,187,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-30 13:28:25',NULL),(736,187,605,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:28:25',NULL),(737,188,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 13:31:03',NULL),(738,189,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:36:31',NULL),(739,190,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:37:17',NULL),(740,191,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:37:41',NULL),(741,192,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:38:02',NULL),(742,193,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-30 13:43:23',NULL),(743,194,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-30 13:45:07',NULL),(744,195,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:47:23',NULL),(745,195,289,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:47:23',NULL),(746,196,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 13:53:32',NULL),(747,197,35,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:56:24',NULL),(748,198,35,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 13:57:02',NULL),(749,198,601,2,10.00,20.00,0.00,0.00,0.00,20.00,1.00,2.00,0.00,0.20,0.40,0.00,20.60,3.40,12.00,8.00,0,'2022-06-30 13:57:02',NULL),(750,199,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-06-30 14:11:32',NULL),(751,199,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-30 14:11:32',NULL),(752,200,103,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 14:28:26',NULL),(753,200,43,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 14:28:26',NULL),(754,200,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 14:28:26',NULL),(755,200,264,10,10.00,100.00,0.00,0.00,0.00,100.00,1.00,2.00,0.00,1.00,2.00,0.00,103.00,17.00,12.00,8.00,0,'2022-06-30 14:28:26',NULL),(756,201,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 14:50:48',NULL),(757,202,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-30 14:53:57',NULL),(758,203,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 14:55:09',NULL),(759,204,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 14:56:56',NULL),(760,205,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 14:59:00',NULL),(761,206,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 17:41:49',NULL),(762,206,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 17:41:49',NULL),(763,207,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 17:46:22',NULL),(764,207,602,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 17:46:22',NULL),(765,208,72,3,89.00,267.00,0.00,0.00,0.00,267.00,1.00,2.00,0.00,2.67,5.34,0.00,275.01,0.00,12.00,8.00,0,'2022-06-30 17:59:33',NULL),(766,208,602,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 17:59:33',NULL),(767,208,607,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 17:59:33',NULL),(768,209,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-06-30 18:01:34',NULL),(769,210,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:04:28',NULL),(770,211,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-06-30 18:07:03',NULL),(771,212,35,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:13:40',NULL),(772,212,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:13:40',NULL),(773,213,66,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:17:49',NULL),(774,213,17,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:17:50',NULL),(775,213,7,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:17:50',NULL),(776,213,12,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:17:50',NULL),(777,213,15,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:17:50',NULL),(778,213,266,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:17:50',NULL),(779,213,65,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:17:50',NULL),(780,213,596,2,10.00,20.00,0.00,0.00,0.00,20.00,1.00,2.00,0.00,0.20,0.40,0.00,20.60,3.40,12.00,8.00,0,'2022-06-30 18:17:50',NULL),(781,213,81,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-06-30 18:17:50',NULL),(782,214,34,1,606.00,606.00,0.00,0.00,0.00,606.00,1.00,2.00,0.00,6.06,12.12,0.00,624.18,0.00,12.00,8.00,0,'2022-07-01 11:20:37',NULL),(783,215,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-07-01 11:23:15',NULL),(784,215,606,4,10.00,40.00,0.00,0.00,0.00,40.00,1.00,2.00,0.00,0.40,0.80,0.00,41.20,6.80,12.00,8.00,0,'2022-07-01 11:23:15',NULL),(785,216,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-07-01 11:26:47',NULL),(786,216,605,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-01 11:26:47',NULL),(787,218,606,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-01 11:27:45',NULL),(788,219,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-01 11:36:40',NULL),(789,220,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-01 11:39:06',NULL),(790,221,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-01 12:14:12',NULL),(791,221,607,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-01 12:14:12',NULL),(792,222,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-07-01 17:43:56',NULL),(793,223,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-07-01 17:49:01',NULL),(794,224,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-07-02 13:53:35',NULL),(795,225,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-02 14:02:45',NULL),(796,226,601,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-02 14:06:42',NULL),(797,227,72,1,89.00,89.00,0.00,0.00,0.00,89.00,1.00,2.00,0.00,0.89,1.78,0.00,91.67,0.00,12.00,8.00,0,'2022-07-02 14:08:59',NULL),(798,228,36,1,236147.00,236147.00,0.00,0.00,0.00,236147.00,1.00,2.00,0.00,2361.47,4722.94,0.00,243231.41,0.00,12.00,8.00,0,'2022-07-02 14:12:51',NULL),(799,228,607,2,10.00,20.00,0.00,0.00,0.00,20.00,1.00,2.00,0.00,0.20,0.40,0.00,20.60,3.40,12.00,8.00,0,'2022-07-02 14:12:51',NULL),(800,229,211,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-02 14:13:04',NULL),(801,230,704,1,90.91,90.91,0.00,0.00,0.00,90.91,5.00,5.00,0.00,4.55,4.55,0.00,100.01,160.99,261.00,50.00,0,'2022-07-02 14:14:55',NULL),(802,231,600,1,10.00,10.00,0.00,0.00,0.00,10.00,1.00,2.00,0.00,0.10,0.20,0.00,10.30,1.70,12.00,8.00,0,'2022-07-02 14:27:04',NULL);
/*!40000 ALTER TABLE `tbl_sales_details` ENABLE KEYS */;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_sales_details_AFTER_INSERT` AFTER INSERT ON `tbl_sales_details` FOR EACH ROW BEGIN
	update PayBillApp.tbl_items set current_balance = current_balance - new.item_quantity where item_id = new.item_id;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_sales_details_AFTER_UPDATE` AFTER UPDATE ON `tbl_sales_details` FOR EACH ROW BEGIN
	update PayBillApp.tbl_items set current_balance = current_balance + old.item_quantity - new.item_quantity where item_id = new.item_id;
    
    insert into PayBillApp.tbl_sales_details_log(sales_details_id,
													sales_id,
													item_id,
													item_quantity,
													item_price,
													item_total,
													item_discount_in_per,
													item_discount_in_rs,
													special_discount_in_rs,
													item_taxable_value,
													cgst_in_per,
													sgst_in_per,
													igst_in_per,
													cgst_in_rs,
													sgst_in_rs,
													igst_in_rs,
													item_total_value_incl_gst,
													item_saving_amount,
													item_mrp_price,
													purchase_rate_incl_gst,
													is_deleted,
													updated_date,
													remarks,
													log_remarks)
											values(old.sales_details_id,
													old.sales_id,
													old.item_id,
													old.item_quantity,
													old.item_price,
													old.item_total,
													old.item_discount_in_per,
													old.item_discount_in_rs,
													old.special_discount_in_rs,
													old.item_taxable_value,
													old.cgst_in_per,
													old.sgst_in_per,
													old.igst_in_per,
													old.cgst_in_rs,
													old.sgst_in_rs,
													old.igst_in_rs,
													old.item_total_value_incl_gst,
													old.item_saving_amount,
													old.item_mrp_price,
													old.purchase_rate_incl_gst,
													old.is_deleted,
													old.updated_date,
													old.remarks,
													'Sales invoice item updated.');
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tbl_sales_details_AFTER_DELETE` AFTER DELETE ON `tbl_sales_details` FOR EACH ROW BEGIN
	update PayBillApp.tbl_items set current_balance = current_balance + old.item_quantity where item_id = old.item_id;
    
    insert into PayBillApp.tbl_sales_details_log(sales_details_id,
													sales_id,
													item_id,
													item_quantity,
													item_price,
													item_total,
													item_discount_in_per,
													item_discount_in_rs,
													special_discount_in_rs,
													item_taxable_value,
													cgst_in_per,
													sgst_in_per,
													igst_in_per,
													cgst_in_rs,
													sgst_in_rs,
													igst_in_rs,
													item_total_value_incl_gst,
													item_saving_amount,
													item_mrp_price,
													purchase_rate_incl_gst,
													is_deleted,
													updated_date,
													remarks,
													log_remarks)
											values(old.sales_details_id,
													old.sales_id,
													old.item_id,
													old.item_quantity,
													old.item_price,
													old.item_total,
													old.item_discount_in_per,
													old.item_discount_in_rs,
													old.special_discount_in_rs,
													old.item_taxable_value,
													old.cgst_in_per,
													old.sgst_in_per,
													old.igst_in_per,
													old.cgst_in_rs,
													old.sgst_in_rs,
													old.igst_in_rs,
													old.item_total_value_incl_gst,
													old.item_saving_amount,
													old.item_mrp_price,
													old.purchase_rate_incl_gst,
													old.is_deleted,
													old.updated_date,
													old.remarks,
													'Sales invoice item deleted.');
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `tbl_sales_details_log`
--

DROP TABLE IF EXISTS `tbl_sales_details_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_sales_details_log` (
  `sales_details_id` bigint NOT NULL,
  `sales_id` bigint DEFAULT NULL,
  `item_id` bigint NOT NULL,
  `item_quantity` bigint NOT NULL,
  `item_price` decimal(19,2) NOT NULL,
  `item_total` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_discount_in_per` decimal(4,2) NOT NULL,
  `item_discount_in_rs` decimal(19,2) NOT NULL,
  `special_discount_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_taxable_value` decimal(19,2) NOT NULL DEFAULT '0.00',
  `cgst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `sgst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `igst_in_per` decimal(4,2) NOT NULL DEFAULT '0.00',
  `cgst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `sgst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `igst_in_rs` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_total_value_incl_gst` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_saving_amount` decimal(19,2) NOT NULL DEFAULT '0.00',
  `item_mrp_price` decimal(19,2) NOT NULL DEFAULT '0.00',
  `purchase_rate_incl_gst` decimal(19,2) NOT NULL DEFAULT '0.00',
  `is_deleted` int NOT NULL DEFAULT '0',
  `updated_date` datetime NOT NULL,
  `remarks` varchar(500) DEFAULT NULL,
  `log_remarks` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_sales_details_log`
--

LOCK TABLES `tbl_sales_details_log` WRITE;
/*!40000 ALTER TABLE `tbl_sales_details_log` DISABLE KEYS */;
INSERT INTO `tbl_sales_details_log` VALUES (34,41,36,1,9.71,9.71,0.00,0.00,0.00,9.71,1.00,2.00,0.00,0.10,0.19,0.00,10.00,2.00,12.00,8.00,0,'2021-09-01 17:34:57',NULL,'Sales invoice item updated.');
/*!40000 ALTER TABLE `tbl_sales_details_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_sales_enquiries`
--

DROP TABLE IF EXISTS `tbl_sales_enquiries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_sales_enquiries` (
  `enquiry_id` bigint NOT NULL AUTO_INCREMENT,
  `enquiry_date` datetime NOT NULL,
  `enquiry_name` varchar(100) NOT NULL,
  `enquiry_address` varchar(100) DEFAULT NULL,
  `enquiry_mobile` varchar(10) NOT NULL,
  `enquiry_remarks` varchar(255) NOT NULL,
  `enquiry_is_new` int NOT NULL DEFAULT '1',
  `enquiry_is_validated` int NOT NULL DEFAULT '0',
  `enquiry_otp` varchar(6) DEFAULT NULL,
  `enquiry_otp_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`enquiry_id`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_sales_enquiries`
--

LOCK TABLES `tbl_sales_enquiries` WRITE;
/*!40000 ALTER TABLE `tbl_sales_enquiries` DISABLE KEYS */;
INSERT INTO `tbl_sales_enquiries` VALUES (65,'2021-12-09 16:39:17','dsfasaf','sdafs','9959963575','sdfsfa',0,1,'559296','2021-12-09 16:39:17'),(66,'2021-12-20 08:28:45','dsfaasf','sdfsd','3242423432','sdfdsf',1,0,'380826','2021-12-20 08:28:45');
/*!40000 ALTER TABLE `tbl_sales_enquiries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_sales_log`
--

DROP TABLE IF EXISTS `tbl_sales_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_sales_log` (
  `sales_id` bigint NOT NULL,
  `client_id` bigint NOT NULL,
  `customer_id` bigint DEFAULT NULL,
  `sales_date` date NOT NULL,
  `transport_charge` decimal(19,2) NOT NULL,
  `packing_charge` decimal(19,2) NOT NULL,
  `other_charge` decimal(19,2) NOT NULL,
  `paid_cash` decimal(19,2) NOT NULL DEFAULT '0.00',
  `payment_type_id` int NOT NULL,
  `upi_type_id` int DEFAULT NULL,
  `trans_no` varchar(40) DEFAULT NULL,
  `created_by` varchar(150) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_by` varchar(150) DEFAULT NULL,
  `updated_date` datetime DEFAULT CURRENT_TIMESTAMP,
  `is_deleted` int NOT NULL DEFAULT '0',
  `remarks` varchar(500) DEFAULT NULL,
  `is_invoice_delivered` int NOT NULL,
  `is_locked` int NOT NULL,
  `log_remarks` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_sales_log`
--

LOCK TABLES `tbl_sales_log` WRITE;
/*!40000 ALTER TABLE `tbl_sales_log` DISABLE KEYS */;
INSERT INTO `tbl_sales_log` VALUES (45,1,NULL,'2021-11-04',0.00,0.00,0.00,11.00,1,NULL,'','ravi2','2021-09-03 08:23:09',NULL,'2021-09-03 08:23:09',0,NULL,0,1,'Sales invoice updated'),(47,1,NULL,'2021-11-04',0.00,0.00,0.00,103.00,1,NULL,'','ravi2','2021-09-03 10:50:52',NULL,'2021-09-03 10:50:52',0,NULL,0,1,'Sales invoice updated');
/*!40000 ALTER TABLE `tbl_sales_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_suppliers`
--

DROP TABLE IF EXISTS `tbl_suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_suppliers` (
  `supplier_id` bigint NOT NULL AUTO_INCREMENT,
  `client_id` bigint NOT NULL,
  `supplier_name` varchar(100) NOT NULL,
  `supplier_address` varchar(500) NOT NULL,
  `supplier_mobile` varchar(10) DEFAULT NULL,
  `supplier_phone` varchar(50) DEFAULT NULL,
  `supplier_email` varchar(150) DEFAULT NULL,
  `gstin` varchar(20) DEFAULT NULL,
  `is_non_gst_vendor` int NOT NULL DEFAULT '0',
  `is_active` int NOT NULL DEFAULT '1',
  `created_by` varchar(150) NOT NULL,
  `created_date` datetime(3) NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
  `updated_by` varchar(150) DEFAULT NULL,
  `updated_date` datetime(3) DEFAULT CURRENT_TIMESTAMP(3),
  PRIMARY KEY (`supplier_id`),
  UNIQUE KEY `idx_clientid_supplier_name` (`supplier_name`,`client_id`),
  KEY `idx_tbl_sup_isactive` (`is_active`),
  KEY `fk__tbl_suppl__creat__1de57479` (`created_by`),
  KEY `fk_suppliers_clinetid_idx` (`client_id`),
  KEY `fk_tbl_suppl_updated_by_idx` (`updated_by`),
  CONSTRAINT `fk_suppliers_clinetid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_suppliers_createdby` FOREIGN KEY (`created_by`) REFERENCES `tbl_users` (`emp_user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_suppliers`
--

LOCK TABLES `tbl_suppliers` WRITE;
/*!40000 ALTER TABLE `tbl_suppliers` DISABLE KEYS */;
INSERT INTO `tbl_suppliers` VALUES (3,1,'Supplier1','Nellore','9959963575',NULL,NULL,'125471254114',0,1,'ravi','2021-07-27 11:29:13.554','ravi','2021-07-27 11:30:02.000'),(4,1,'Supplier2','Hyderabad','8555555555',NULL,NULL,NULL,0,1,'ravi','2021-07-27 11:29:30.611',NULL,'2021-07-27 11:29:30.611'),(5,1,'Supplier3','Kavali','8888888888',NULL,NULL,NULL,0,1,'ravi','2021-07-27 11:29:47.707',NULL,'2021-07-27 11:29:47.707'),(7,1,'Supplier10','Nellore','1234556789',NULL,NULL,'14252525252',0,1,'ravi','2021-07-27 18:31:17.054','ravi','2021-07-27 18:50:21.000');
/*!40000 ALTER TABLE `tbl_suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_support_requests`
--

DROP TABLE IF EXISTS `tbl_support_requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_support_requests` (
  `support_request_id` bigint NOT NULL AUTO_INCREMENT,
  `emp_user_id` varchar(150) NOT NULL,
  `support_request_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `support_request_remarks` varchar(500) NOT NULL,
  `support_status_id` int NOT NULL,
  `support_response_remarks` varchar(500) DEFAULT NULL,
  `client_id` bigint NOT NULL,
  `support_response_date` datetime DEFAULT NULL,
  PRIMARY KEY (`support_request_id`),
  KEY `fk_support_statusid_idx` (`support_status_id`),
  KEY `fk_support_emp_userid_idx` (`emp_user_id`),
  KEY `fk_support_clientid_idx` (`client_id`),
  CONSTRAINT `fk_support_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_support_emp_userid` FOREIGN KEY (`emp_user_id`) REFERENCES `tbl_users` (`emp_user_id`),
  CONSTRAINT `fk_support_statusid` FOREIGN KEY (`support_status_id`) REFERENCES `tbl_support_status` (`support_status_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_support_requests`
--

LOCK TABLES `tbl_support_requests` WRITE;
/*!40000 ALTER TABLE `tbl_support_requests` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_support_requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_support_status`
--

DROP TABLE IF EXISTS `tbl_support_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_support_status` (
  `support_status_id` int NOT NULL,
  `support_status_desc` varchar(45) NOT NULL,
  PRIMARY KEY (`support_status_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_support_status`
--

LOCK TABLES `tbl_support_status` WRITE;
/*!40000 ALTER TABLE `tbl_support_status` DISABLE KEYS */;
INSERT INTO `tbl_support_status` VALUES (1,'Open'),(2,'Closed'),(3,'Rejected');
/*!40000 ALTER TABLE `tbl_support_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_transaction_types`
--

DROP TABLE IF EXISTS `tbl_transaction_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_transaction_types` (
  `trans_type_id` int NOT NULL,
  `trans_type_desc` varchar(30) NOT NULL,
  PRIMARY KEY (`trans_type_id`),
  UNIQUE KEY `trans_type_desc` (`trans_type_desc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_transaction_types`
--

LOCK TABLES `tbl_transaction_types` WRITE;
/*!40000 ALTER TABLE `tbl_transaction_types` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_transaction_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_unknown_device`
--

DROP TABLE IF EXISTS `tbl_unknown_device`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_unknown_device` (
  `row_id` bigint NOT NULL AUTO_INCREMENT,
  `device_id` varchar(50) NOT NULL,
  `user_id` varchar(150) DEFAULT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`row_id`)
) ENGINE=InnoDB AUTO_INCREMENT=108 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_unknown_device`
--

LOCK TABLES `tbl_unknown_device` WRITE;
/*!40000 ALTER TABLE `tbl_unknown_device` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_unknown_device` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_upi_types`
--

DROP TABLE IF EXISTS `tbl_upi_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_upi_types` (
  `upi_type_id` int NOT NULL,
  `upi_type_desc` varchar(30) NOT NULL,
  `upi_image_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`upi_type_id`),
  UNIQUE KEY `wallet_desc` (`upi_type_desc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_upi_types`
--

LOCK TABLES `tbl_upi_types` WRITE;
/*!40000 ALTER TABLE `tbl_upi_types` DISABLE KEYS */;
INSERT INTO `tbl_upi_types` VALUES (1,'PhonePe','phonepe'),(2,'GPay','gpay'),(3,'PayTM','paytm'),(4,'Others','others');
/*!40000 ALTER TABLE `tbl_upi_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_user_types`
--

DROP TABLE IF EXISTS `tbl_user_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_user_types` (
  `user_type_id` int NOT NULL,
  `user_type_desc` varchar(30) NOT NULL,
  PRIMARY KEY (`user_type_id`),
  UNIQUE KEY `user_type_desc` (`user_type_desc`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_user_types`
--

LOCK TABLES `tbl_user_types` WRITE;
/*!40000 ALTER TABLE `tbl_user_types` DISABLE KEYS */;
INSERT INTO `tbl_user_types` VALUES (1,'Administrator'),(2,'Manager'),(3,'Operator');
/*!40000 ALTER TABLE `tbl_user_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_users`
--

DROP TABLE IF EXISTS `tbl_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_users` (
  `emp_user_id` varchar(150) NOT NULL,
  `client_id` bigint NOT NULL,
  `emp_first_name` varchar(50) NOT NULL,
  `emp_last_name` varchar(50) DEFAULT NULL,
  `emp_address` varchar(500) DEFAULT NULL,
  `emp_mobile` varchar(15) DEFAULT NULL,
  `emp_email_address` varchar(150) DEFAULT NULL,
  `emp_device_id` varchar(100) NOT NULL,
  `emp_salt` varchar(100) NOT NULL,
  `emp_pwd` varchar(100) NOT NULL,
  `is_active` tinyint NOT NULL DEFAULT '0',
  `is_last_invoice_access` tinyint NOT NULL DEFAULT '0',
  `is_enable_sales_price` tinyint NOT NULL DEFAULT '0',
  `is_enable_sales_date` tinyint NOT NULL DEFAULT '0',
  `is_view_item_alias_name` tinyint NOT NULL DEFAULT '0',
  `is_access_purchase` tinyint NOT NULL DEFAULT '0',
  `is_access_sales` tinyint NOT NULL DEFAULT '0',
  `transaction_key` varchar(100) DEFAULT NULL,
  `user_security_key` varchar(100) DEFAULT NULL,
  `user_security_key_date` datetime DEFAULT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_date` datetime DEFAULT CURRENT_TIMESTAMP,
  `updated_by` varchar(150) DEFAULT NULL,
  `is_password_changed` int NOT NULL DEFAULT '0',
  `is_admin` int NOT NULL DEFAULT '0',
  `created_by` varchar(50) NOT NULL DEFAULT 'admin',
  `device_public_key` varchar(100) DEFAULT NULL,
  `local_language_print` int NOT NULL DEFAULT '0',
  `is_price_updated` int NOT NULL DEFAULT '1',
  `login_key_unique_id` varchar(255) DEFAULT NULL,
  `login_last_key` varchar(750) NOT NULL DEFAULT 'test',
  `password_reset_key` varchar(100) DEFAULT NULL,
  `otp` varchar(100) DEFAULT NULL,
  `otp_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `apk_version_code` int DEFAULT NULL,
  `biometric_key` varchar(250) DEFAULT NULL,
  `is_biometric_enabled` int NOT NULL DEFAULT '1',
  `win_qrcode_id` int DEFAULT NULL,
  `win_qrcode_date` datetime DEFAULT NULL,
  PRIMARY KEY (`emp_user_id`),
  UNIQUE KEY `emp_device_id_UNIQUE` (`emp_device_id`),
  UNIQUE KEY `uq_users_winqrcodeid` (`win_qrcode_id`),
  KEY `idx_emp_user_pwd_is_active` (`emp_user_id`,`emp_pwd`,`is_active`),
  KEY `idx_tbl_emp_isactive` (`is_active`),
  KEY `idx_tbl_emp_user_id_and_pwd` (`emp_user_id`,`emp_pwd`),
  KEY `idx_tbl_emp_user_type_is_active` (`is_active`),
  KEY `fk_employee_clientid_idx` (`client_id`),
  KEY `fk_users_created_by_idx` (`created_by`),
  KEY `fk_users_winqrcode_idx` (`win_qrcode_id`),
  CONSTRAINT `fk_users_clientid` FOREIGN KEY (`client_id`) REFERENCES `tbl_clients` (`client_id`),
  CONSTRAINT `fk_users_created_by` FOREIGN KEY (`created_by`) REFERENCES `tbl_cp_users` (`user_id`),
  CONSTRAINT `fk_users_winqrcode` FOREIGN KEY (`win_qrcode_id`) REFERENCES `tbl_win_qrcodes` (`win_qrcode_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_users`
--

LOCK TABLES `tbl_users` WRITE;
/*!40000 ALTER TABLE `tbl_users` DISABLE KEYS */;
INSERT INTO `tbl_users` VALUES ('4444',1,'4444','4444','sdfsafsdfds','2343242342','','5ugxgdseepTPEg2DZSVGunfXok6/OpIK6xbyuy5LkwQcoCUCJJEaJcCly1dyRFJz','uNrZGmKgFi9S84+TB+9saOf0pb4=','KCbyrso3FfYRiSBMarvaJ7a4fn0uK7O19PjYP84jjpQ=',1,0,0,0,0,0,0,NULL,NULL,NULL,'2021-10-29 16:42:15','2021-12-17 16:49:34','ravi',0,0,'admin',NULL,0,1,NULL,'test',NULL,NULL,'2021-10-29 16:42:15',NULL,NULL,-455166986,NULL,NULL),('555',3,'5555','5555',NULL,'5555',NULL,'f1d917a0-38a9-11ec-8b98-b82a72cd1567','uNrZGmKgFi9S84+TB+9saOf0pb4=','KCbyrso3FfYRiSBMarvaJ7a4fn0uK7O19PjYP84jjpQ=',1,0,0,0,0,0,0,NULL,NULL,NULL,'2021-10-29 16:48:29','2021-10-29 16:48:29',NULL,0,1,'admin',NULL,0,1,NULL,'test',NULL,NULL,'2021-10-29 16:48:29',NULL,NULL,1,NULL,NULL),('demo',1,'demo','demo','ffffff','9494855767','','cwNKgTwl51d6zSYDGKuqo6kWLR0Bb23Jrnb0r4mZr3UFa2Tl1kr4ENqqUXgPCrf1','uNrZGmKgFi9S84+TB+9saOf0pb4=','KCbyrso3FfYRiSBMarvaJ7a4fn0uK7O19PjYP84jjpQ=',1,0,0,0,0,0,0,NULL,NULL,NULL,'2021-10-28 17:06:19','2022-03-18 09:12:07','ravi',0,0,'admin',NULL,0,1,NULL,'test',NULL,NULL,'2021-10-28 17:06:19',NULL,NULL,702876473,NULL,NULL),('ravi',1,'ravi','buchingari','nellore','9959963575','','VBpTlk4Zf76iEl2OJG0BhIHkBmRkRMk18sqz+KF0IXc=','5ZhtNDVCf/pgZMo9IJRA/zjn4QM=','wk0tfOswKDXMjCilGS2ocy1yq0gBgg+gz6G/L6b/2JQ=',1,1,1,1,1,1,1,'8f0f0664-1a0f-11ec-9708-b82a72cd1567','7547081d-f93d-11ec-bc2d-645a049e7771','2022-07-01 18:28:09','2021-07-27 10:07:34','2022-03-19 05:50:09','ravi',1,1,'admin','qIpd6/5xcnZUCGbH2bwaOAnk7pEaC5CCVisNTy3kHqs=',1,1,NULL,'test','','','2021-10-26 01:22:32',NULL,NULL,1,3,'2022-07-02 15:11:19'),('ravi2',1,'ravi','buchingari','nellore','55555555','buchinari@yahoo.com','D3hc5eGMjFznhx/4jdlIpE2GFo3/87wiS5ECUSCC1kQ=','wqYoWuPa84hCPkOm8Nbof/HrHbA=','Ja/Hymq2ASLrcEgpx3L6ryYDVhq0lXUHYk8xoq0f7do=',1,1,1,1,1,1,1,'25ce0ce8-1d13-11ec-8795-b82a72cd1567','b1668ead-03ad-11ec-bebd-b82a72cd1567','2021-08-23 06:31:48','2021-07-28 11:26:04','2021-09-15 19:35:42','ravi',1,0,'admin','eegUadoMAlfcS/YX8IPU+LWc3/cRgIGYvKDwsajs1lg=',0,1,NULL,'test',NULL,NULL,'2021-10-25 08:23:46',NULL,NULL,1,NULL,NULL);
/*!40000 ALTER TABLE `tbl_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_win_qrcodes`
--

DROP TABLE IF EXISTS `tbl_win_qrcodes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_win_qrcodes` (
  `win_qrcode_id` int NOT NULL AUTO_INCREMENT,
  `win_system_unique_id` varchar(250) NOT NULL,
  `win_qrcode_value` varchar(500) NOT NULL,
  `win_qrcode_security_key` varchar(500) NOT NULL,
  `win_system_ip_address` varchar(20) NOT NULL,
  `win_qrcode_created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `client_id` bigint DEFAULT NULL,
  PRIMARY KEY (`win_qrcode_id`),
  UNIQUE KEY `win_qrcode_key_UNIQUE` (`win_qrcode_security_key`),
  UNIQUE KEY `win_qrcode_value_UNIQUE` (`win_qrcode_value`),
  UNIQUE KEY `win_system_unique_id_UNIQUE` (`win_system_unique_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_win_qrcodes`
--

LOCK TABLES `tbl_win_qrcodes` WRITE;
/*!40000 ALTER TABLE `tbl_win_qrcodes` DISABLE KEYS */;
INSERT INTO `tbl_win_qrcodes` VALUES (3,'CivrCkO/ZLL/s1VNcBJ+OHY8U3T+L+7eSVgbDTKFGgyW+TDg3KEjEwPeOOLdmJ7e','LhOzSbLM6X5ufKp78GRPXNH1deKYZJKl4L18GyFbrdbNPJqtOsk5GNjdfZQeQWFJy3X9tXwy4wJi58ncn8cFfcjdnkKYNAN0ER7HvCTNrMkip3abXvBimayzq6S4RVdPVnHA3DjZKHBWWRWTRQdxKOVXKmw1F8Di0m4VjglueyiR9kgGiSaa6k1hRU7SwRtC17woERTp5uStup6IwDTL76yRwBw8H8rb/3qhBMQ16pKfMhSTfZp3evyc55dKYQ6Tp+ieTo9LMwEn02fPYVXRLbUCl0BqEeFkzzf1sjiYOmSZvG6ptkUOds5zly47buhoUwuUN07gKOF5fNEEZI1YB3uswvVdvlqHlVEeViW+U5xf8TPnKXqzUoZOvwbFyQM1QV0bGG09+7p62mq8S/jywg==','3f4PNRk9bAye7nh2urO8hjdOSfSQDS5dJuAUuRFtQ9tDRkZgDYMALlw0HJDmw37NeH3HkO1/R4KBqZKA/XJ4xLQgnsFxMKKDKSehYNuWWBAD+sg6WnV1CH+a2j23fdQt','192.168.0.4','2022-07-02 15:11:19',NULL);
/*!40000 ALTER TABLE `tbl_win_qrcodes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vw_client_users`
--

DROP TABLE IF EXISTS `vw_client_users`;
/*!50001 DROP VIEW IF EXISTS `vw_client_users`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_client_users` AS SELECT 
 1 AS `client_id`,
 1 AS `no_of_users`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vw_purchase_details`
--

DROP TABLE IF EXISTS `vw_purchase_details`;
/*!50001 DROP VIEW IF EXISTS `vw_purchase_details`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_purchase_details` AS SELECT 
 1 AS `purchase_id`,
 1 AS `quantity`,
 1 AS `total_incl_gst`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vw_sales_details`
--

DROP TABLE IF EXISTS `vw_sales_details`;
/*!50001 DROP VIEW IF EXISTS `vw_sales_details`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_sales_details` AS SELECT 
 1 AS `sales_id`,
 1 AS `quantity`,
 1 AS `total_incl_gst`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'smartbilling'
--

--
-- Dumping routines for database 'smartbilling'
--
/*!50003 DROP PROCEDURE IF EXISTS `item_troubleshooting` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `item_troubleshooting`(v_item_id bigint)
BEGIN
	
	declare v_purchase_qty bigint;
    declare v_sales_qty bigint;
    
    select sum(item_quantity) into v_purchase_qty
    from PayBillApp.tbl_purchase_details
    where item_id = v_item_id;
    
    select sum(item_quantity) into v_sales_qty
    from PayBillApp.tbl_sales_details
    where item_id = v_item_id and is_deleted = 0;
    
    update PayBillApp.tbl_items set current_balance = opening_balance + ifnull(v_purchase_qty,0) - ifnull(v_sales_qty,0)  where item_id = v_item_id;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_activate_client` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_activate_client`(p_client_id bigint,
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	update PayBillApp.tbl_clients set client_status_id = 1 where client_status_id = 2 and client_id = p_client_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_authentication` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_authentication`(p_emp_user_id varchar(50),
									p_emp_pwd1 varchar(50),
									p_emp_pwd2 varchar(50))
begin

	declare v_user_type_id int;
	
	select `user_type_id` into v_user_type_id from tbl_employee where `emp_user_id` = p_emp_user_id;
	
	if v_user_type_id = 1
	then
		
		select	`emp_id`,
				`emp_user_id`,
				`emp_first_name`,
				`emp_mobile`,
				`user_type_id`,
				`is_active`,
				(select `header_1` from  tbl_company_info limit 1) as company_name,
				(now()) as server_date,
				`is_last_invoice_access`,
				`is_enable_sales_price`,
				`is_enable_sales_date`,
				`is_view_item_alias_name`,
				`is_touch_screen_only`,
				`is_access_sales`,
				`is_access_purchase`
		from  tbl_employee where `emp_user_id` = p_emp_user_id and `emp_pwd` = p_emp_pwd2;  
	else

		
		select	`emp_id`,
				`emp_user_id`,
				`emp_first_name`,
				`emp_mobile`,
				`user_type_id`,
				`is_active`,
				(select `header_1` from  tbl_company_info limit 1) as company_name,
				(now()) as server_date,
				`is_last_invoice_access`,
				`is_enable_sales_price`,
				`is_enable_sales_date`,
				`is_view_item_alias_name`,
				`is_touch_screen_only`,
				`is_access_sales`,
				`is_access_purchase`
		from  tbl_employee 
		where	`emp_user_id` = p_emp_user_id and 
				`emp_pwd` = p_emp_pwd1;
	end if;
	
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_change_cp_user_password` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_change_cp_user_password`(p_old_user_password varchar(100),
																			p_new_user_password varchar(100),
																			p_user_id varchar(50),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    datediff(date(user_security_key_date), date(now())) = 0) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	if exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_password = p_old_user_password) then
                                    
		update PayBillApp.tbl_cp_users set user_password = p_new_user_password, is_new_password = 0 where user_id = p_user_id;
	else
		signal sqlstate '45000' set message_text = 'The old password do not match.';
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_check_cp_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_check_cp_device`(p_device_app_id varchar(250),
																	p_firebase_token varchar(500),
																	out o_user_id varchar(50),
																	out o_user_name varchar(101),
                                                                    out o_transaction_key varchar(100))
BEGIN
	if exists(select user_id from PayBillApp.tbl_cp_users where device_app_id = p_device_app_id and user_is_active = 1) then
		select user_id, concat(user_first_name, ' ', user_last_name) into o_user_id, o_user_name from PayBillApp.tbl_cp_users where device_app_id = p_device_app_id;
        set o_transaction_key = (select uuid());
        update PayBillApp.tbl_cp_users set firebase_token = p_firebase_token, transaction_key = o_transaction_key where device_app_id = p_device_app_id;
	else
		signal sqlstate '45000' set message_text = 'Access Denied';
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_check_customer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_check_customer`(p_client_id bigint,
																p_emp_user_id varchar(150),
																p_emp_device_id varchar(100),
																p_transaction_key varchar(100),
																p_customer_mobile varchar(10),
                                                                out o_is_active int(1),
                                                                out o_customer_name varchar(100),
                                                                out o_customer_id bigint)
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
   
   select customer_id,is_active,customer_name into o_customer_id,o_is_active,o_customer_name from PayBillApp.tbl_customers where customer_mobile = p_customer_mobile;
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_check_customer_win` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_check_customer_win`(p_client_id bigint,
																	p_win_qrcode_id int,
																	p_emp_user_id varchar(150),
																	p_win_system_unique_id varchar(250),
																	p_win_qrcode_security_key varchar(500),
																	p_customer_mobile varchar(10),
																	out o_is_active int(1),
																	out o_customer_name varchar(100),
																	out o_customer_id bigint)
leave_lable: BEGIN

	if not exists(select win.win_qrcode_id 
					from PayBillApp.tbl_win_qrcodes win
                    inner join PayBillApp.tbl_users usr
                    on win.win_qrcode_id = usr.win_qrcode_id
					where usr.client_id = p_client_id and 
							emp_user_id = p_emp_user_id and 
                            win.win_qrcode_id = p_win_qrcode_id and
							win_system_unique_id = p_win_system_unique_id and
							win_qrcode_security_key = p_win_qrcode_security_key and 
							is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if; 
   
   select customer_id,is_active,customer_name into o_customer_id,o_is_active,o_customer_name from PayBillApp.tbl_customers where customer_mobile = p_customer_mobile;
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_check_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_check_device`(p_emp_device_id varchar(100),
																p_device_public_key varchar(100),
                                                                p_biometric_key varchar(250),
                                                                out o_apk_version_code int,
                                                                out o_is_apk_upgrade_mandatory int(1),
                                                                out o_return_value varchar(100))
BEGIN
	if exists(select emp_user_id from PayBillApp.tbl_users where emp_device_id = p_emp_device_id) then
		update PayBillApp.tbl_users set device_public_key = p_device_public_key, biometric_key = p_biometric_key where emp_device_id = p_emp_device_id;
        select apk_version_code,is_apk_upgrade_mandatory into o_apk_version_code,o_is_apk_upgrade_mandatory from PayBillApp.tbl_admin limit 1;
        set o_return_value = 'SUCCESS';
    else
		#insert into PayBillApp.tbl_unknown_device(device_id,user_id) values(p_emp_device_id,p_device_public_key);
		set o_apk_version_code = 0;
        set o_return_value = 'The device is not activated. Please contact the administrator!';
    end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_check_manage_authentication` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_check_manage_authentication`(p_sales_manage_password varchar(50),
												p_purchase_manage_password varchar(50),
												p_others_manage_password varchar(50),
												p_reset_manage_password varchar(50))
begin
	if length(p_sales_manage_password) > 0 then
		
		select count(*) from tbl_company_info where `sales_manage_password` = p_sales_manage_password;
	end if;
		
	if length(p_purchase_manage_password) > 0 then
		
		select count(*) from tbl_company_info where `purchase_manage_password` = p_purchase_manage_password;
	end if;
		
	if length(p_others_manage_password) > 0 then
		
		select count(*) from tbl_company_info where `others_manage_password` = p_others_manage_password;
	end if;
		
	if length(p_reset_manage_password) > 0 then
		
		select count(*) from tbl_company_info where `reset_manage_password` = p_reset_manage_password;
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_client_authentication` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_client_authentication`(p_emp_user_id varchar(50),
																		p_emp_pwd varchar(100),
                                                                        p_emp_salt varchar(60),
                                                                        out o_client_id bigint,
                                                                        out o_client_name varchar(100),
                                                                        out o_is_password_changed int(1),
                                                                        out o_user_name varchar(101),
																		out o_user_security_key varchar(100),
                                                                        out o_expire_in_days int)
BEGIN
	declare v_emp_first_name varchar(50);
    declare v_emp_last_name varchar(50);
    declare v_client_status_id tinyint;
    
    select usr.client_id, emp_first_name, emp_last_name,is_password_changed, datediff(subscription_end_date,date(now())) into o_client_id,v_emp_first_name, v_emp_last_name,o_is_password_changed,o_expire_in_days
    from PayBillApp.tbl_users usr
    inner join tbl_clients clt
    on usr.client_id = clt.client_id
    where emp_user_id = p_emp_user_id and 
			emp_pwd = p_emp_pwd and 
            emp_salt = p_emp_salt and
            is_admin = 1 and
            is_active = 1 and 
            client_status_id = 1;
            
    if o_client_id is not null and o_client_id > 0 then
    
		set o_user_security_key = UUID();
		set o_user_name = concat(v_emp_first_name, ' ', v_emp_last_name) ;
        
        select client_name into o_client_name from PayBillApp.tbl_clients where client_id = o_client_id;
        
        update PayBillApp.tbl_users set user_security_key = o_user_security_key, user_security_key_date = now()
        where emp_user_id = p_emp_user_id and emp_pwd = p_emp_pwd;
        
	else 
		select client_status_id into v_client_status_id
		from PayBillApp.tbl_users usr
		inner join tbl_clients clt
		on usr.client_id = clt.client_id
		where emp_user_id = p_emp_user_id and 
				emp_pwd = p_emp_pwd and 
				emp_salt = p_emp_salt and
				is_admin = 1 and
				is_active = 1;
		if v_client_status_id is not null and (v_client_status_id = 2 || v_client_status_id = 3) then
			signal sqlstate '45000' set message_text = 'Your account is not activated. Please contact the service provider!';
		else 
			signal sqlstate '45000' set message_text = 'Security information failed!';
		end if;
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_client_authentication_with_key` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_client_authentication_with_key`(p_client_id bigint,
																				p_emp_user_id varchar(50),
																				p_emp_device_id varchar(100),
																				p_transaction_key varchar(100),
                                                                                p_login_key_unique_id varchar(255),
                                                                                p_key_created_date datetime,
                                                                                p_login_last_key varchar(750),
																				out o_client_id bigint,
																				out o_client_name varchar(100),
																				out o_is_password_changed int(1),
																				out o_user_name varchar(101),
																				out o_user_security_key varchar(100),
                                                                                out o_expire_in_days int)
BEGIN
	declare v_emp_first_name varchar(50);
    declare v_emp_last_name varchar(50);
    
    set p_key_created_date = ADDTIME(p_key_created_date, "0:2:0");
    
    select usr.client_id, emp_first_name, emp_last_name,is_password_changed, datediff(subscription_end_date,date(now())) into o_client_id,v_emp_first_name, v_emp_last_name,o_is_password_changed,o_expire_in_days
    from PayBillApp.tbl_users usr
    inner join tbl_clients clt
    on usr.client_id = clt.client_id
    where usr.client_id = p_client_id and
			emp_user_id = p_emp_user_id and 
			emp_device_id = p_emp_device_id and 
            transaction_key = p_transaction_key and
            login_key_unique_id = p_login_key_unique_id and
            is_admin = 1 and
            is_active = 1 and 
            client_status_id = 1 and 
            p_key_created_date >= now() and
            login_last_key <> p_login_last_key;
            
    if o_client_id is not null and o_client_id > 0 then
    
		set o_user_security_key = UUID();
		set o_user_name = concat(v_emp_first_name, ' ', v_emp_last_name) ;
        
        select client_name into o_client_name from PayBillApp.tbl_clients where client_id = o_client_id;
        
        update PayBillApp.tbl_users set user_security_key = o_user_security_key, user_security_key_date = now(), login_last_key = p_login_last_key
        where emp_user_id = p_emp_user_id and emp_device_id = p_emp_device_id;
        
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_client_subscription_end_date` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_client_subscription_end_date`(p_client_id bigint)
BEGIN
	select date_format(subscription_end_date,'%d-%b-%Y') from PayBillApp.tbl_clients where client_id = p_client_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_client_user_password_reset` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_client_user_password_reset`(p_client_id bigint,
																			p_emp_user_id varchar(150),
																			p_emp_user_id_updated_by varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN
	declare v_emp_default_password varchar(100);
    declare v_emp_default_salt varchar(100);
    declare v_is_admin int(1);
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id_updated_by and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	select is_admin into v_is_admin from tbl_users where client_id = p_client_id and emp_user_id = p_emp_user_id;

	if v_is_admin = 1 then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	select emp_default_password,emp_default_salt into v_emp_default_password,v_emp_default_salt from tbl_clients where client_id = p_client_id;
    
    update tbl_users set is_password_changed = 0, emp_pwd = v_emp_default_password, emp_salt = v_emp_default_salt where client_id = p_client_id and emp_user_id = p_emp_user_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_cp_authentication` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_cp_authentication`(p_user_id varchar(50),
																	p_user_password varchar(100),
                                                                    out o_is_new_password int(1),
																	out o_user_name varchar(101),
                                                                    out o_user_security_key varchar(100))
BEGIN
	declare v_user_first_name varchar(50);
    declare v_user_last_name varchar(50);
    declare v_is_new_password int(1);
    
    select user_first_name, user_last_name, is_new_password into v_user_first_name, v_user_last_name, v_is_new_password
    from PayBillApp.tbl_cp_users
    where user_id = p_user_id and 
			user_password = p_user_password and 
            user_is_active = 1 and 
            is_control_panel_access = 1;
            
    if v_user_first_name is not null and length(v_user_first_name) > 0 then
    
		set o_user_security_key = UUID();
		set o_user_name = concat(v_user_first_name, ' ', v_user_last_name);
        set o_is_new_password = v_is_new_password;
        
        update PayBillApp.tbl_cp_users set user_security_key = o_user_security_key, user_security_key_date = now()
        where user_id = p_user_id and user_password = p_user_password;
	else 
		signal sqlstate '45000' set message_text = 'Security information failed!';
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_create_client` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_create_client`(p_request_id bigint,
																p_user_id varchar(50),
																p_device_app_id varchar(250),
																p_transaction_key varchar(100))
leave_lable: BEGIN

	declare v_client_name varchar(100);
	declare v_contact_name varchar(100);
	declare v_client_address varchar(500);
	declare v_contact_mobile1 varchar(10);
	declare v_contact_email varchar(150);
	declare v_client_gst varchar(20);
	declare v_client_type_id bigint;
	declare v_locality_id bigint;
	
              
              
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									device_app_id = p_device_app_id and 
                                    user_is_active = 1 and 
                                    transaction_key = p_transaction_key) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
        
    if exists (select client_id from PayBillApp.tbl_clients where contact_mobile1 = v_contact_mobile1 or contact_mobile2 = v_contact_mobile1) then
		signal sqlstate '45000' set message_text = 'Oops! Mobile is already in use.';
		leave leave_lable;
	end if;
	
	select client_name,
			contact_name,
            client_address,
            contact_mobile,
            contact_email,
            client_type_id,
            locality_id into v_client_name,v_contact_name,v_client_address,v_contact_mobile1,v_contact_email,v_client_type_id,v_locality_id
    from PayBillApp.tbl_client_requests where request_id = p_request_id and is_mobile_validated= 1;

	insert into PayBillApp.tbl_clients(client_name,
									contact_name,
									client_address,
									contact_mobile1,
									contact_email,
									client_status_id,
									client_type_id,
									locality_id,
									invoice_delivery_key_date,
									package_id,
									created_by,
									subscription_start_date,
                                    subscription_end_date,
									discount_in_rs,
									discount_end_date)
							values(v_client_name,
									v_contact_name,
									v_client_address,
									v_contact_mobile1,
									v_contact_email,
									2,
									v_client_type_id,
									v_locality_id,
									date(now()),
									1,
									'admin',
									date(now()),
                                    date_add(now(),interval 1 year),
									0,
									date(now()));

    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_deactivate_client` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_deactivate_client`(p_client_id bigint,
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	update PayBillApp.tbl_clients set client_status_id = 2 where client_id = p_client_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_city` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_city`(p_city_id bigint,
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	delete from PayBillApp.tbl_cities where city_id = p_city_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_client` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_client`(p_client_id bigint,
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	delete from PayBillApp.tbl_clients where client_id = p_client_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_client_payment_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_client_payment_types`(p_client_id bigint,
																			p_emp_user_id varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    delete from PayBillApp.tbl_client_payment_types where client_id = p_client_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_client_type` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_client_type`(p_client_type_id bigint,
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	delete from PayBillApp.tbl_client_types where client_type_id = p_client_type_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_client_upi_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_client_upi_types`(p_client_id bigint,
																		p_emp_user_id varchar(150),
																		p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    delete from PayBillApp.tbl_client_upi_types where client_id = p_client_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_client_user` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_client_user`(p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_user_id varchar(50),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    delete from PayBillApp.tbl_users where client_id = p_client_id and emp_user_id = p_emp_user_id;
                            
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_customer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_customer`(p_customer_id bigint)
begin
	delete from `dbo`.`tbl_customers` where `customer_id` = p_customer_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_device`(p_device_id varchar(50))
begin
	delete from `dbo`.`tbl_devices` where `device_id` = p_device_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_emp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_emp`(p_emp_id bigint)
begin
	delete from `dbo`.`tbl_employee` where `emp_id` = p_emp_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_employee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_employee`(p_del_user_id varchar(50),
																p_user_id varchar(50),
																p_user_security_key varchar(100))
leave_lable: BEGIN
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    delete from PayBillApp.tbl_cp_users where user_id = p_del_user_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_gst` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_gst`(p_gst_id bigint,
															p_client_id bigint,
															p_emp_user_id varchar(150),
															p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	delete from tbl_gst where gst_id = p_gst_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_item` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_item`(p_item_id bigint,
															p_client_id bigint,
															p_emp_user_id varchar(150),
															p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	delete from tbl_items where item_id = p_item_id and client_id = p_client_id;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_locality` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_locality`(p_locality_id bigint,
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	delete from PayBillApp.tbl_locality where locality_id = p_locality_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_purchase` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_purchase`(p_purchase_id bigint,
                                                                    p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		ROLLBACK;
        signal sqlstate '45000' set message_text = 'Purchase invoice could not be deleted. Please try again!';
    END;

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    START TRANSACTION;
    
    delete from tbl_purchase_details where purchase_id = p_purchase_id;
    delete from tbl_purchase where client_id = p_client_id and purchase_id = p_purchase_id;
    
    COMMIT;
	
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_purchase_item` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_purchase_item`(p_purchase_details_id bigint,
                                                                    p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    delete dtl
    from PayBillApp.tbl_purchase_details dtl
    inner join PayBillApp.tbl_purchase pur
    on dtl.purchase_id = pur.purchase_id and client_id = p_client_id
    where purchase_details_id = p_purchase_details_id;
	
    #delete from PayBillApp.tbl_purchase_details
    #where purchase_details_id = p_purchase_details_id and 
			#purchase_id in (select purchase_id from PayBillApp.tbl_purchase where client_id = p_client_id);
	
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_registration` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_registration`(p_request_id bigint,
																		p_user_id varchar(50),
																		p_device_app_id varchar(250),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									device_app_id = p_device_app_id and 
                                    user_is_active = 1 and 
                                    transaction_key = p_transaction_key) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	delete from PayBillApp.tbl_client_requests where request_id = p_request_id;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_sales_enquiry` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_sales_enquiry`(p_enquiry_id bigint,
																		p_user_id varchar(50),
																		p_device_app_id varchar(250),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									device_app_id = p_device_app_id and 
                                    user_is_active = 1 and 
                                    transaction_key = p_transaction_key) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	delete from PayBillApp.tbl_sales_enquiries where enquiry_id = p_enquiry_id;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_sales_enquiry2` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_sales_enquiry2`(p_enquiry_id bigint,
																	p_user_id varchar(50),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	delete from PayBillApp.tbl_sales_enquiries where enquiry_id = p_enquiry_id;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_sales_enquiry_portal` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_sales_enquiry_portal`(p_enquiry_id bigint,
																	p_user_id varchar(50),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	delete from PayBillApp.tbl_sales_enquiries where enquiry_id = p_enquiry_id;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_sales_invoice` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_sales_invoice`(p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_emp_device_id varchar(100),
																	p_transaction_key varchar(100),
																	p_sales_id bigint,
																	p_remarks varchar(500),
                                                                    out o_return_value varchar(20))
leave_lable: BEGIN
	
	declare exit handler for sqlexception
    begin
		rollback;
        signal sqlstate '45000' set message_text = 'Sales invoice could not be deleted. Please try again!';
    end;

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    START TRANSACTION;
    if exists(select sales_id 
				from PayBillApp.tbl_sales
                where 	sales_id = p_sales_id and
						is_deleted = 0 and 
						client_id = p_client_id) then
         
		update PayBillApp.tbl_sales_details set is_deleted = 1, updated_date = now(), remarks = p_remarks
		where sales_id = p_sales_id and is_deleted = 0;
		
		update PayBillApp.tbl_sales set is_deleted = 1, updated_date = now(), remarks = p_remarks
		where sales_id = p_sales_id;
        
        delete from PayBillApp.tbl_sales_details where sales_id = p_sales_id;
        delete from PayBillApp.tbl_sales where sales_id = p_sales_id;
        
        set o_return_value = 'SUCCESS';
	else 
		signal sqlstate '45000' set message_text = 'Sales invoice was already deleted!';
    end if;
    
    commit;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_sales_item` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_sales_item`(p_client_id bigint,
																p_emp_user_id varchar(150),
																p_emp_device_id varchar(100),
																p_transaction_key varchar(100),
																p_sales_id bigint,
																p_sales_details_id bigint,
                                                                p_remarks varchar(500),
                                                                out o_return_value varchar(20))
leave_lable: BEGIN
	declare v_sales_invoice_lock_in_mins int(1);
	declare exit handler for sqlexception
    begin
		#rollback;
        #signal sqlstate '45000' set message_text = 'Sales invoice could not be deleted. Please try again!';
        
        get diagnostics condition 1
        @p1 = returned_sqlstate, @p2 = message_text;
		signal sqlstate '45000' set message_text = @p2;
		rollback;
    end;
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    START TRANSACTION;
    
    select sales_invoice_lock_in_mins into v_sales_invoice_lock_in_mins from PayBillApp.tbl_clients where client_id = p_client_id;
    
    if exists(select sales_details_id 
				from PayBillApp.tbl_sales_details dtls
                inner join PayBillApp.tbl_sales sls
                on dtls.sales_id = sls.sales_id and 
					sls.created_by = p_emp_user_id and 
                    sls.client_id = p_client_id and 
                    (is_locked = 0 or date_add(sls.created_date, interval v_sales_invoice_lock_in_mins minute) > now())
                where sales_details_id = p_sales_details_id and sls.sales_id = p_sales_id) then
    
		update PayBillApp.tbl_sales_details set is_deleted = 1, updated_date = now(), remarks = p_remarks	where sales_details_id = p_sales_details_id;
        
        delete from PayBillApp.tbl_sales_details where sales_details_id = p_sales_details_id;
        
        if not exists(select sales_details_id from PayBillApp.tbl_sales_details where sales_id = p_sales_id) then
			update PayBillApp.tbl_sales set is_deleted = 1, updated_date = now(), remarks = p_remarks where sales_id = p_sales_id;
            delete from PayBillApp.tbl_sales where sales_id = p_sales_id;
        end if;
        
		set o_return_value = 'SUCCESS';
    else 
		signal sqlstate '45000' set message_text = 'Sales invoice item was already deleted!';
	end if;
	commit;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_supplier` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_supplier`(p_supplier_id bigint,
                                                                p_client_id bigint,
																p_emp_user_id varchar(150),
																p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	delete from tbl_suppliers where p_client_id = client_id and supplier_id = p_supplier_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_del_support_request` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_del_support_request`(p_client_id bigint,
																		p_emp_user_id varchar(150),
																		p_emp_device_id varchar(100),
																		p_transaction_key varchar(100),
                                                                        p_support_request_id bigint)
leave_lable: BEGIN
	declare v_support_request_id bigint;
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    delete from PayBillApp.tbl_support_requests where support_status_id = 1 and client_id = p_client_id and support_request_id = p_support_request_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_device_authentication` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_device_authentication`(p_emp_user_id varchar(150),
																		p_emp_pwd varchar(100),
                                                                        p_emp_device_id varchar(100),
                                                                        p_apk_version_code int)
BEGIN
	declare v_client_id bigint;
    declare v_transaction_key varchar(100);
    declare v_invoice_delivery_key_date date;
    declare v_client_alert_days tinyint;
    
    select usr.client_id, invoice_delivery_key_date into v_client_id, v_invoice_delivery_key_date
    from PayBillApp.tbl_users usr
    inner join PayBillApp.tbl_clients clt
    on usr.client_id = clt.client_id
    where emp_user_id = p_emp_user_id and 
			emp_pwd = p_emp_pwd and 
            emp_device_id = p_emp_device_id and
            is_active = 1 and 
            client_status_id = 1;
            
    if v_client_id is not null and v_client_id > 0 then
    
		set v_transaction_key = UUID();
		
        update PayBillApp.tbl_users set transaction_key = v_transaction_key, apk_version_code = p_apk_version_code
        where emp_user_id = p_emp_user_id and 
				emp_pwd = p_emp_pwd and 
				emp_device_id = p_emp_device_id;
        
        if datediff(v_invoice_delivery_key_date, date(now())) <> 0 then
			update PayBillApp.tbl_clients set invoice_delivery_key = (select uuid_short()), invoice_delivery_key_date = date(now())
            where client_id = v_client_id;
        end if;
        
        select client_alert_days into v_client_alert_days from PayBillApp.tbl_admin limit 1;
        
        update PayBillApp.tbl_clients set last_access_date = now() where client_id = v_client_id;
        
        insert into PayBillApp.tbl_lgrpt(userid,apk_version_code,is_biometric_auth)
        values(p_emp_user_id,p_apk_version_code,0);
        
        select usr.client_id, 
				client_name,
                client_address,
                contact_mobile1,
                client_gst,
                sales_invoice_title,
                sales_invoice_address,
                sales_invoice_terms1,
                sales_invoice_terms2,
                local_language_print,
                concat(emp_first_name, ' ', emp_last_name) as emp_name,
				is_password_changed,
                is_admin,
                offline_item_validation,
                add_item_on_scan_barcode,
                payment_type_required,
                barcode_required_on_invoice,
                cash_validation_required,
                language_code,
                gst_slab_required_on_invoice,
                is_three_column_printer,
                validate_stock_on_invoice,
                items_download_automatically,
                is_price_updated,
                extra_discount_required,
                datediff(subscription_end_date,date(now())) as expire_in_days,
                is_trail,
                subscription_end_date,
                v_transaction_key as transaction_key,
                v_client_alert_days as client_alert_days
        from PayBillApp.tbl_users usr
		inner join PayBillApp.tbl_clients clt
		on usr.client_id = clt.client_id
		where emp_user_id = p_emp_user_id;
    
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_device_biometric_authentication` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_device_biometric_authentication`(p_client_id bigint,
																					p_emp_user_id varchar(150),
																					p_emp_device_id varchar(100),
																					p_device_public_key varchar(100),
																					p_biometric_key varchar(250),
                                                                                    p_apk_version_code int)
BEGIN
	declare v_transaction_key varchar(100);
    declare v_invoice_delivery_key_date date;
    declare v_client_alert_days tinyint;
    
	if exists(select emp_user_id from PayBillApp.tbl_users 
					where client_id = p_client_id and 
							emp_user_id = p_emp_user_id and 
							emp_device_id = p_emp_device_id and 
							device_public_key = p_device_public_key and 
							biometric_key = p_biometric_key and 
                            is_biometric_enabled = 1 and 
                            is_active = 1) then
                            
		select invoice_delivery_key_date into v_invoice_delivery_key_date
		from PayBillApp.tbl_clients
        where client_id = p_client_id;
                            
		set v_transaction_key = UUID();
		
        update PayBillApp.tbl_users set transaction_key = v_transaction_key, apk_version_code = p_apk_version_code
        where emp_user_id = p_emp_user_id and 
				emp_device_id = p_emp_device_id;
        
        if datediff(v_invoice_delivery_key_date, date(now())) <> 0 then
			update PayBillApp.tbl_clients set invoice_delivery_key = (select uuid_short()), invoice_delivery_key_date = date(now())
            where client_id = p_client_id;
        end if;
        
        select client_alert_days into v_client_alert_days from PayBillApp.tbl_admin limit 1;
        
        update PayBillApp.tbl_clients set last_access_date = now() where client_id = p_client_id;
        
        insert into PayBillApp.tbl_lgrpt(userid,apk_version_code,is_biometric_auth)
        values(p_emp_user_id,p_apk_version_code,1);
        
        select usr.client_id, 
				client_name,
                client_address,
                contact_mobile1,
                client_gst,
                sales_invoice_title,
                sales_invoice_address,
                sales_invoice_terms1,
                sales_invoice_terms2,
                local_language_print,
                concat(emp_first_name, ' ', emp_last_name) as emp_name,
				is_password_changed,
                is_admin,
                offline_item_validation,
                add_item_on_scan_barcode,
                payment_type_required,
                barcode_required_on_invoice,
                cash_validation_required,
                language_code,
                gst_slab_required_on_invoice,
                is_three_column_printer,
                validate_stock_on_invoice,
                items_download_automatically,
                is_price_updated,
                extra_discount_required,
                datediff(subscription_end_date,date(now())) as expire_in_days,
                is_trail,
                subscription_end_date,
                v_transaction_key as transaction_key,
                v_client_alert_days as client_alert_days
        from PayBillApp.tbl_users usr
		inner join PayBillApp.tbl_clients clt
		on usr.client_id = clt.client_id
		where emp_user_id = p_emp_user_id and 
				usr.client_id = p_client_id and 
                client_status_id = 1;
        
    end if;
						
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_active_cities` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_active_cities`()
BEGIN
	select city_id,city_name
    from PayBillApp.tbl_cities
    where is_active = 1 order by city_name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_admin_preferences` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_admin_preferences`(p_user_id varchar(50),
																		p_user_security_key varchar(100))
leave_lable: BEGIN
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	select service_name,
			fcm_server_api_key,
            fcm_server_sender_id,
            otp_sms_api,
            enquiry_otp_template_id,
            reset_otp_template_id,
            apk_version_code,
            is_apk_upgrade_mandatory,
            offline_apk_download_required,
            payment_gateway_merchant_key,
            payment_gateway_merchant_secret_key,
            email_sales_user_id,
            email_support_user_id,
            email_password,
            email_smtp_host,
            email_port,
            email_ssl_enabled
    from PayBillApp.tbl_admin;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_cities` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_cities`(p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    select city_id,city_name,is_active from PayBillApp.tbl_cities order by is_active desc, city_name asc;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_clients_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_clients_details`(p_client_id bigint,
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	select client_id,
			client_name,
			contact_name,
			client_address,
			contact_mobile1,
            contact_mobile2,
            contact_email,
			client_type_id,
			locality_id,
			client_gst,
            package_id,
            date_format(subscription_end_date,'%d-%b-%Y') as service_end_date,
            discount_in_rs,
            date_format(discount_end_date,'%d-%b-%Y') as discount_end_date
    from PayBillApp.tbl_clients
    where client_id = p_client_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_clients_to_manage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_clients_to_manage`(p_user_id varchar(50),
																		p_user_security_key varchar(100))
leave_lable: BEGIN
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	select clt.client_id,
			client_name,
			contact_name,
			client_address,
			contact_mobile1,
            contact_email,
			client_type_desc,
			client_status_desc,
			date_format(created_date,'%d-%b-%Y') as created_date,
			created_by,
            clt.client_status_id,
            package_name,
            package_no_users,
            ifnull(no_of_users,0) as no_of_users,
            date_format(subscription_end_date,'%d-%b-%Y') as service_end_date
	from PayBillApp.tbl_clients clt
    inner join PayBillApp.tbl_client_status sts
    on clt.client_status_id = sts.client_status_id
    inner join PayBillApp.tbl_client_types ctp
    on clt.client_type_id = ctp.client_type_id
    inner join PayBillApp.tbl_packages pkg
    on clt.package_id = pkg.package_id
    left outer join PayBillApp.vw_client_users usr
    on clt.client_id = usr.client_id
    order by clt.client_status_id,client_name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_and_package_name` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_and_package_name`(p_client_id bigint,
																			p_package_id bigint,
																			p_user_id varchar(50),
																			p_user_security_key varchar(100),
																			out o_client_name varchar(100),
																			out o_client_address varchar(500),
																			out o_package_name varchar(50))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	select client_name,client_address into o_client_name,o_client_address from PayBillApp.tbl_clients 
	where client_id = p_client_id;
    
    select package_name into o_package_name	from PayBillApp.tbl_packages
	where package_id = p_package_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_dashboard_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_dashboard_items`(p_client_id bigint,
																				p_emp_user_id varchar(150),
																				p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
            
	 select sales_date,
            concat(sls.created_by,',', emp_first_name, ' ', emp_last_name) as emp_name,
			sum((total_incl_gst+transport_charge+packing_charge+other_charge)) as total_value
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtls
    on sls.sales_id = dtls.sales_id
    inner join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    inner join PayBillApp.tbl_users usr
    on sls.created_by = usr.emp_user_id
    where sls.client_id = p_client_id and 
			datediff(sales_date,date(now())) = 0
	group by sales_date,sls.created_by
    order by sales_date,sls.created_by;
    
    select concat(item_barcode,' ',item_name) as item_name,
			old_price,
			new_price,
			date_format(trk.updated_date,'%d-%b-%Y') as updated_date,
			trk.updated_by
    from PayBillApp.tbl_item_price_tracking trk
    inner join PayBillApp.tbl_clients clt
    on trk.client_id = clt.client_id
    inner join PayBillApp.tbl_items itm
    on trk.item_id = itm.item_id
    where trk.client_id = p_client_id and 
			date_add(trk.updated_date, interval 7 day) > date(now());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_gst_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_gst_for_device`(p_client_id bigint,
																		p_emp_user_id varchar(150),
                                                                        p_emp_device_id varchar(100),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select gst_id as KeyId,
			gst_name as KeyDesc
	from PayBillApp.tbl_gst 
    where client_id = p_client_id and is_active = 1
	order by cgst_in_per + sgst_in_per;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_item_ids` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_item_ids`(p_client_id bigint)
BEGIN
	select item_id from PayBillApp.tbl_items where client_id = p_client_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_payment_gateway` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_payment_gateway`(p_client_id bigint,
																			p_emp_user_id varchar(150),
																			p_emp_device_id varchar(100),
																			p_transaction_key varchar(100),
                                                                            out o_discount_in_rs double,
                                                                            out o_contact_mobile varchar(10),
                                                                            out o_contact_email varchar(100),
																			out o_payment_gateway_merchant_key varchar(250),
																			out o_payment_gateway_merchant_secret_key varchar(250),
                                                                            out o_order_id varchar(25))
leave_lable: BEGIN
	declare v_package_no_users tinyint;
    declare v_discount_end_date date;
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select package_no_users,contact_mobile1,contact_email,discount_in_rs,date(discount_end_date) into v_package_no_users,o_contact_mobile,o_contact_email,o_discount_in_rs,v_discount_end_date
    from PayBillApp.tbl_clients clt
    inner join PayBillApp.tbl_packages pkg
    on clt.package_id = pkg.package_id
    where client_id = p_client_id;
    
    if v_discount_end_date < date(now()) then
		set o_discount_in_rs = 0;
    end if;
    
    select payment_gateway_merchant_key,payment_gateway_merchant_secret_key into o_payment_gateway_merchant_key,o_payment_gateway_merchant_secret_key
    from PayBillApp.tbl_admin limit 1;
    
    select package_id,package_name,package_no_users,package_amount
    from PayBillApp.tbl_packages 
    where package_is_active = 1 and 
			package_no_users >= ifnull(v_package_no_users,0) and 
            package_amount > 0
    order by package_no_users;

	set o_order_id = (select uuid_short());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_prefs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_prefs`(p_client_id bigint)
BEGIN
	declare v_offline_apk_download_required int(1);
    
    select offline_apk_download_required into v_offline_apk_download_required
    from PayBillApp.tbl_admin limit 1;

	select client_id,
			client_name,
            contact_name,
            client_address,
            contact_mobile1,
            contact_mobile2,
            contact_email,
            client_gst,
            client_type_desc,
            locality_id,
            sales_invoice_title,
            sales_invoice_address,
            sales_invoice_terms1,
            sales_invoice_terms2,
            cash_validation_required,
            report_format_id,
            emp_default_password,
            sales_invoice_lock_in_mins,
            barcode_required_on_invoice,
            payment_type_required,
            add_item_on_scan_barcode,
            cash_validation_required,
            offline_item_validation,
            language_code,
            gst_slab_required_on_invoice,
            is_three_column_printer,
            validate_stock_on_invoice,
            items_download_automatically,
            extra_discount_required,
            gst_included_on_price,
            is_allow_device_item_reg,
            logo_required_on_invoice,
            v_offline_apk_download_required as offline_apk_download_required
    from PayBillApp.tbl_clients clt
    inner join PayBillApp.tbl_client_types ctp
    on clt.client_type_id = ctp.client_type_id
    where client_id = p_client_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_support_requests` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_support_requests`(p_client_id bigint,
																		p_emp_user_id varchar(150),
																		p_emp_device_id varchar(100),
																		p_transaction_key varchar(100))
leave_lable: BEGIN
	declare v_support_request_id bigint;
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	 select support_request_id as RequestID,
			date_format(support_request_date,'%d-%m-%Y') as RequestDate,
			support_request_remarks as RequestRemarks,
            req.emp_user_id as UserID,
            concat(emp_first_name, ' ', emp_last_name) as UserName,
            support_status_desc as RequestStatus,
            req.support_status_id as RequestStatusID,
            support_response_remarks AS ResponseRemarks
	from PayBillApp.tbl_support_requests req 
    inner join PayBillApp.tbl_users usr
    on req.emp_user_id = usr.emp_user_id
    inner join PayBillApp.tbl_support_status sts
    on req.support_status_id = sts.support_status_id
    where req.client_id = p_client_id order by support_request_id desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_types`(	p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    select client_type_id,client_type_desc,is_active from PayBillApp.tbl_client_types order by is_active desc, client_type_desc asc;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_types_and_localities` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_types_and_localities`()
BEGIN
	select client_type_id as KeyId,client_type_desc as KeyDesc 
    from PayBillApp.tbl_client_types 
    where is_active order by client_type_desc;
    
    select locality_id as KeyId, concat(locality_name,',',city_name) as KeyDesc
    from PayBillApp.tbl_locality loc
    inner join PayBillApp.tbl_cities cty
    on loc.city_id = cty.city_id
    where loc.is_active and cty.is_active 
    order by concat(locality_name,',',city_name);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_users` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_users`(p_client_id bigint)
BEGIN
	select emp_user_id,
			concat(emp_first_name,' ',emp_last_name) as emp_user_name,
			emp_address,
            emp_mobile,
            (case when is_admin = 1 then 'Admin' else 'User' end) as user_type,
            (case when is_active = 1 then 'Active' else 'Inactive' end) as user_status
    from tbl_users
    where client_id = p_client_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_user_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_user_details`(p_client_id bigint,
																			p_emp_user_id varchar(150))
BEGIN
	select emp_user_id,
			emp_first_name,
			emp_last_name,
			emp_address,
            emp_mobile,
            emp_email_address,
            emp_device_id,
            local_language_print,
            is_biometric_enabled,
            is_active
    from PayBillApp.tbl_users
    where client_id = p_client_id and emp_user_id = p_emp_user_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_client_user_names` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_client_user_names`(p_client_id bigint)
BEGIN
	select ROW_NUMBER() OVER (ORDER BY emp_user_id) AS s_no,
			emp_user_id,
			emp_first_name,
			emp_last_name,
            is_active
    from PayBillApp.tbl_users
    where client_id = p_client_id
    order by emp_user_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_company_info` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_company_info`()
begin
	
	select * from tbl_company_info;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_customers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_customers`()
begin
	
	select	`customer_id`,
			`customer_name`,
			`customer_address`,
			`customer_mobile`,
			(select case `is_active`
			when 1 then 'active'
			else 'inactive' end) as cust_status,
			'edit' as edit,
			'remove' as remove
	from PayBillApp.tbl_customers
	order by `customer_name`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_customer_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_customer_details`(p_customer_id bigint)
begin
	
	select * from tbl_customers where `customer_id` = p_customer_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_customer_names` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_customer_names`()
begin
	
	select	`customer_id`,
			`customer_name`,
			`customer_mobile`
	from tbl_customers
	where `is_active` = 1
	order by `customer_name`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_dashboard_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_dashboard_items`(p_user_id varchar(50),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	select enquiry_id,
			date_format(enquiry_date,'%d-%m-%Y %H:%i') as enquiry_date,
            enquiry_name,
            enquiry_mobile,
            enquiry_address,
            enquiry_remarks,
            enquiry_is_new
    from PayBillApp.tbl_sales_enquiries 
    where enquiry_is_validated = 1
    order by enquiry_is_new desc, enquiry_id desc;
    
    select client_id,
			client_name,
            client_address,
            contact_mobile1,
            date_format(subscription_end_date,'%d-%b-%Y') as subscription_end_date,
            datediff(subscription_end_date,date(now())) as remain_days
    from PayBillApp.tbl_clients
    where date_add(subscription_end_date, interval 10 day) < date(now());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_devices` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_devices`()
begin

	
	select `device_id`,`device_name`, 'delete' as remove
	from tbl_devices order by `device_name`;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_employees_to_manage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_employees_to_manage`(p_user_id varchar(50),
																		p_user_security_key varchar(100))
leave_lable: BEGIN
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	select user_id,
			user_first_name,
			user_last_name,
			user_mobile,
			device_app_id,
            is_control_panel_access,
			user_is_active
    from PayBillApp.tbl_cp_users
    order by user_is_active desc,user_first_name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_employee_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_employee_details`(p_dtl_user_id varchar(50),
																		p_user_id varchar(50),
																		p_user_security_key varchar(100))
leave_lable: BEGIN
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    select user_id,
			user_first_name,
            user_last_name,
            user_mobile,
            user_email,
            user_address,
            device_app_id,
            is_control_panel_access,
            user_is_active
    from PayBillApp.tbl_cp_users 
    where user_id = p_dtl_user_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_failed_payments` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_failed_payments`(p_user_id varchar(50),
																		p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	select fld.client_id,
			client_name,
			client_address,
			date_format(error_created_date,'%d-%b-%Y %H:%i') as error_created_date,
			error_code,
			error_description,
            error_source,
            error_step,
            error_reason
	from PayBillApp.tbl_payment_gateway_error fld
	inner join PayBillApp.tbl_clients clt
	on fld.client_id = clt.client_id
	order by payment_gateway_error_id desc;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_gst` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_gst`(p_client_id bigint)
begin
	
	select gst_id,gst_name,cgst_in_per,sgst_in_per,igst_in_per,is_active
	from PayBillApp.tbl_gst where client_id = p_client_id order by is_active desc, cgst_in_per;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_gst_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_gst_items`(p_gst_name varchar(100) /* = null */)
begin
	if p_gst_name is not null
	then
		
		select `item_id`,
				`item_name`,
				`item_mrp_price`,
				`item_sales_price`,
				`item_purchase_price`,
				`cgst_in_per`,
				`sgst_in_per`,
				`igst_in_per`,
				(`cgst_in_per`+`sgst_in_per`+`igst_in_per`) as total_gst_per
		from tbl_items
		where (concat('cgst:' , cast(`cgst_in_per` as char) , ',sgst:' , cast(`sgst_in_per` as char) , ',igst:' , cast(`igst_in_per` as char))) = p_gst_name
		order by `item_name`;
	else 
			
			select `item_id`,
				`item_name`,
				`item_mrp_price`,
				`item_sales_price`,
				`item_purchase_price`,
				`cgst_in_per`,
				`sgst_in_per`,
				`igst_in_per`,
				(`cgst_in_per`+`sgst_in_per`+`igst_in_per`) as total_gst_per
		from tbl_items
		order by `item_name`;
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_gst_per` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_gst_per`(p_client_id bigint)
begin
	
	select gst_id,
			gst_name
	from PayBillApp.tbl_gst 
    where client_id = p_client_id and is_active = 1
	order by cgst_in_per + sgst_in_per;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_gst_purchase_datewise` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_gst_purchase_datewise`(p_cgst_in_per decimal(4,2), 
												p_sgst_in_per decimal(4,2), 
												p_igst_in_per decimal(4,2), 
												p_from_date date, 
												p_to_date date, 
												p_gst_type_id int(1))
begin
	
	if p_gst_type_id = 1 
	then

		if (p_cgst_in_per + p_sgst_in_per) > 0
		then
			
			select `purchase_inv_date`,
					'cgst,sgst' as gst_type,
					(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char))) as gst_per,
					(`cgst_in_per` + `sgst_in_per`) as gst_per_value,
					sum(`cgst_in_rs`) as total_cgst,
					sum(`sgst_in_rs`) as total_sgst,
					0.00 as total_igst,
					sum(`cgst_in_rs` + `sgst_in_rs`) as total_gst
			from tbl_purchase sls
			inner join tbl_purchase_details dtls
			on sls.purchase_id = dtls.purchase_id
			where `cgst_in_per` = p_cgst_in_per and 
					`sgst_in_per` = p_sgst_in_per and
					(`purchase_inv_date` between p_from_date and p_to_date) and 
					(`cgst_in_rs` + `sgst_in_rs`) > 0
			group by `purchase_inv_date`,(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char))),(`cgst_in_per` + `sgst_in_per`)
			order by `purchase_inv_date`;
		else 

			
			select `purchase_inv_date`,
					'cgst,sgst' as gst_type,
					(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char))) as gst_per,
					(`cgst_in_per` + `sgst_in_per`) as gst_per_value,
					sum(`cgst_in_rs`) as total_cgst,
					sum(`sgst_in_rs`) as total_sgst,
					0.00 as total_igst,
					sum(`cgst_in_rs` + `sgst_in_rs`) as total_gst
			from tbl_purchase sls
			inner join tbl_purchase_details dtls
			on sls.purchase_id = dtls.purchase_id
			where (`purchase_inv_date` between p_from_date and p_to_date) and 
					(`cgst_in_rs` + `sgst_in_rs`) > 0
			group by `purchase_inv_date`,(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char))),(`cgst_in_per` + `sgst_in_per`)
			order by `purchase_inv_date`;

		end if;

	elseif p_gst_type_id = 2
	then

		if p_igst_in_per > 0
		then
			
			select `purchase_inv_date`,
					'igst' as gst_type,
					(concat('igst:' , cast(`igst_in_per` as char))) as gst_per,
					`igst_in_per` as gst_per_value,
					0.00 as total_cgst,
					0.00 as total_sgst,
					sum(`igst_in_rs`) as total_igst,
					sum(`igst_in_rs`) as total_gst
			from tbl_purchase sls
			inner join tbl_purchase_details dtls
			on sls.purchase_id = dtls.purchase_id
			where `igst_in_per` = p_igst_in_per and 
					(`purchase_inv_date` between p_from_date and p_to_date) and 
					`igst_in_rs` > 0
			group by `purchase_inv_date`,(concat('igst:' , cast(`igst_in_per` as char))),`igst_in_per`
			order by `purchase_inv_date`;
		else 

			
			select `purchase_inv_date`,
					'igst' as gst_type,
					(concat('igst:' , cast(`igst_in_per` as char))) as gst_per,
					`igst_in_per` as gst_per_value,
					0.00 as total_cgst,
					0.00 as total_sgst,
					sum(`igst_in_rs`) as total_igst,
					sum(`igst_in_rs`) as total_gst
			from tbl_purchase sls
			inner join tbl_purchase_details dtls
			on sls.purchase_id = dtls.purchase_id
			where (`purchase_inv_date` between p_from_date and p_to_date) and 
					`igst_in_rs` > 0
			group by `purchase_inv_date`,(concat('igst:' , cast(`igst_in_per` as char))),`igst_in_per`
			order by `purchase_inv_date`;

		end if;

	else 

		if (p_cgst_in_per + p_sgst_in_per + p_igst_in_per) > 0
		then
			
			select `purchase_inv_date`,
					'cgst,sgs,igstt' as gst_type,
					(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char) , ', igst:' , cast(`igst_in_per` as char))) as gst_per,
					(`cgst_in_per` + `sgst_in_per` + `igst_in_per`) as gst_per_value,
					sum(`cgst_in_rs`) as total_cgst,
					sum(`sgst_in_rs`) as total_sgst,
					sum(`igst_in_rs`) as total_igst,
					sum(`cgst_in_rs` + `sgst_in_rs` + `igst_in_rs`) as total_gst
			from tbl_purchase sls
			inner join tbl_purchase_details dtls
			on sls.purchase_id = dtls.purchase_id
			where `cgst_in_per` = p_cgst_in_per and 
					`sgst_in_per` = p_sgst_in_per and
					`igst_in_per` = p_igst_in_per and
					(`purchase_inv_date` between p_from_date and p_to_date) and 
					(`cgst_in_rs` + `sgst_in_rs` + `igst_in_rs`) > 0
			group by `purchase_inv_date`,(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char) , ', igst:' , cast(`igst_in_per` as char))),(`cgst_in_per` + `sgst_in_per` + `igst_in_per`)
			order by `purchase_inv_date`;
		else 

			
			select `purchase_inv_date`,
					'cgst,sgs,igstt' as gst_type,
					(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char) , ', igst:' , cast(`igst_in_per` as char))) as gst_per,
					(`cgst_in_per` + `sgst_in_per` + `igst_in_per`) as gst_per_value,
					sum(`cgst_in_rs`) as total_cgst,
					sum(`sgst_in_rs`) as total_sgst,
					sum(`igst_in_rs`) as total_igst,
					sum(`cgst_in_rs` + `sgst_in_rs` + `igst_in_rs`) as total_gst
			from tbl_purchase sls
			inner join tbl_purchase_details dtls
			on sls.purchase_id = dtls.purchase_id
			where (`purchase_inv_date` between p_from_date and p_to_date) and 
					(`cgst_in_rs` + `sgst_in_rs` + `igst_in_rs`) > 0
			group by `purchase_inv_date`,(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char) , ', igst:' , cast(`igst_in_per` as char))),(`cgst_in_per` + `sgst_in_per` + `igst_in_per`)
			order by `purchase_inv_date`;

		end if;
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_gst_sales_datewise` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_gst_sales_datewise`(p_cgst_in_per decimal(4,2), 
											p_sgst_in_per decimal(4,2), 
											p_igst_in_per decimal(4,2), 
											p_from_date date, 
											p_to_date date, 
											p_gst_type_id int(1))
begin
	
	if p_gst_type_id = 1 
	then

		if (p_cgst_in_per + p_sgst_in_per) > 0
		then
			
			select `sales_date`,
					'cgst,sgst' as gst_type,
					(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char))) as gst_per,
					(`cgst_in_per` + `sgst_in_per`) as gst_per_value,
					sum(`cgst_in_rs`) as total_cgst,
					sum(`sgst_in_rs`) as total_sgst,
					0.00 as total_igst,
					sum(`cgst_in_rs` + `sgst_in_rs`) as total_gst
			from tbl_sales sls
			inner join tbl_sales_details dtls
			on sls.sales_id = dtls.sales_id
			where `cgst_in_per` = p_cgst_in_per and 
					`sgst_in_per` = p_sgst_in_per and
					(`sales_date` between p_from_date and p_to_date) and 
					(`cgst_in_rs` + `sgst_in_rs`) > 0
			group by `sales_date`,(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char))),(`cgst_in_per` + `sgst_in_per`)
			order by `sales_date`;
		else 

			
			select `sales_date`,
					'cgst,sgst' as gst_type,
					(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char))) as gst_per,
					(`cgst_in_per` + `sgst_in_per`) as gst_per_value,
					sum(`cgst_in_rs`) as total_cgst,
					sum(`sgst_in_rs`) as total_sgst,
					0.00 as total_igst,
					sum(`cgst_in_rs` + `sgst_in_rs`) as total_gst
			from tbl_sales sls
			inner join tbl_sales_details dtls
			on sls.sales_id = dtls.sales_id
			where (`sales_date` between p_from_date and p_to_date) and 
					(`cgst_in_rs` + `sgst_in_rs`) > 0
			group by `sales_date`,(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char))),(`cgst_in_per` + `sgst_in_per`)
			order by `sales_date`;

		end if;

	elseif p_gst_type_id = 2
	then

		if p_igst_in_per > 0
		then
			
			select `sales_date`,
					'igst' as gst_type,
					(concat('igst:' , cast(`igst_in_per` as char))) as gst_per,
					`igst_in_per` as gst_per_value,
					0.00 as total_cgst,
					0.00 as total_sgst,
					sum(`igst_in_rs`) as total_igst,
					sum(`igst_in_rs`) as total_gst
			from tbl_sales sls
			inner join tbl_sales_details dtls
			on sls.sales_id = dtls.sales_id
			where `igst_in_per` = p_igst_in_per and 
					(`sales_date` between p_from_date and p_to_date) and 
					`igst_in_rs` > 0
			group by `sales_date`,(concat('igst:' , cast(`igst_in_per` as char))),`igst_in_per`
			order by `sales_date`;
		else 

			
			select `sales_date`,
					'igst' as gst_type,
					(concat('igst:' , cast(`igst_in_per` as char))) as gst_per,
					`igst_in_per` as gst_per_value,
					0.00 as total_cgst,
					0.00 as total_sgst,
					sum(`igst_in_rs`) as total_igst,
					sum(`igst_in_rs`) as total_gst
			from tbl_sales sls
			inner join tbl_sales_details dtls
			on sls.sales_id = dtls.sales_id
			where (`sales_date` between p_from_date and p_to_date) and 
					`igst_in_rs` > 0
			group by `sales_date`,(concat('igst:' , cast(`igst_in_per` as char))),`igst_in_per`
			order by `sales_date`;

		end if;

	else 

		if (p_cgst_in_per + p_sgst_in_per + p_igst_in_per) > 0
		then
			
			select `sales_date`,
					'cgst,sgs,igstt' as gst_type,
					(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char) , ', igst:' , cast(`igst_in_per` as char))) as gst_per,
					(`cgst_in_per` + `sgst_in_per` + `igst_in_per`) as gst_per_value,
					sum(`cgst_in_rs`) as total_cgst,
					sum(`sgst_in_rs`) as total_sgst,
					sum(`igst_in_rs`) as total_igst,
					sum(`cgst_in_rs` + `sgst_in_rs` + `igst_in_rs`) as total_gst
			from tbl_sales sls
			inner join tbl_sales_details dtls
			on sls.sales_id = dtls.sales_id
			where `cgst_in_per` = p_cgst_in_per and 
					`sgst_in_per` = p_sgst_in_per and
					`igst_in_per` = p_igst_in_per and
					(`sales_date` between p_from_date and p_to_date) and 
					(`cgst_in_rs` + `sgst_in_rs` + `igst_in_rs`) > 0
			group by `sales_date`,(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char) , ', igst:' , cast(`igst_in_per` as char))),(`cgst_in_per` + `sgst_in_per` + `igst_in_per`)
			order by `sales_date`;
		else 

			
			select `sales_date`,
					'cgst,sgs,igstt' as gst_type,
					(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char) , ', igst:' , cast(`igst_in_per` as char))) as gst_per,
					(`cgst_in_per` + `sgst_in_per` + `igst_in_per`) as gst_per_value,
					sum(`cgst_in_rs`) as total_cgst,
					sum(`sgst_in_rs`) as total_sgst,
					sum(`igst_in_rs`) as total_igst,
					sum(`cgst_in_rs` + `sgst_in_rs` + `igst_in_rs`) as total_gst
			from tbl_sales sls
			inner join tbl_sales_details dtls
			on sls.sales_id = dtls.sales_id
			where (`sales_date` between p_from_date and p_to_date) and 
					(`cgst_in_rs` + `sgst_in_rs` + `igst_in_rs`) > 0
			group by `sales_date`,(concat('cgst:' , cast(`cgst_in_per` as char) , ', sgst:' , cast(`sgst_in_per` as char) , ', igst:' , cast(`igst_in_per` as char))),(`cgst_in_per` + `sgst_in_per` + `igst_in_per`)
			order by `sales_date`;

		end if;
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_itemdetails_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_itemdetails_for_device`(p_client_id bigint,
																		p_emp_user_id varchar(150),
                                                                        p_item_id bigint,
                                                                        p_emp_device_id varchar(100),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select item_id,
			item_name,
            item_alias_name,
            item_barcode,
            item_mrp_price,
            item_sales_price,
            (case when item_discount_in_per > 0 and item_discount_expiry_date is not null and datediff(item_discount_expiry_date,date(now())) >= 0 then item_discount_in_per
            else 0 end) as item_discount_in_per,
            (ifnull(cgst_in_per,0) + ifnull(sgst_in_per,0)) as gst_per,
            current_balance,
            item_name_telugu
    from tbl_items itm
    left outer join tbl_gst gst
    on itm.gst_id = gst.gst_id
    where itm.client_id = p_client_id and 
			item_id = p_item_id and
			itm.is_active = 1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_items`(p_client_id bigint,
															p_search_param varchar(50))
begin
	if p_search_param is null then 
		set p_search_param = '';
    end if;
	select item_id,
			item_name,
			item_name_telugu,
            item_alias_name,
			item_barcode,
			hsn_code,
			item_mrp_price,
			item_sales_price,
			item_purchase_price,
			item_discount_in_per,
			item_discount_expiry_date,
			cgst_in_per,
            sgst_in_per,
            igst_in_per,
			opening_balance,
			current_balance,
            itm.is_active,
            itm.gst_id
		from tbl_items itm
        left outer join tbl_gst gst
        on itm.gst_id = gst.gst_id
		where itm.client_id = p_client_id and 
				(item_name like concat('%' , p_search_param , '%') or 
				item_barcode like concat('%' , p_search_param , '%') or
				item_alias_name like concat('%' , p_search_param , '%'))
		order by item_name;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_items_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_items_for_device`(p_client_id bigint,
																		p_emp_user_id varchar(150),
                                                                        p_emp_device_id varchar(100),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    update PayBillApp.tbl_users set is_price_updated = 0
    where client_id = p_client_id and 
			emp_user_id = p_emp_user_id;
    
    select item_id,
			item_name,
            item_alias_name,
            item_barcode,
            item_mrp_price,
            item_sales_price,
            item_discount_in_per,
            item_discount_expiry_date,
            (ifnull(cgst_in_per,0) + ifnull(sgst_in_per,0)) as gst_per,
            item_name_telugu
    from PayBillApp.tbl_items itm
    left outer join PayBillApp.tbl_gst gst
    on itm.gst_id = gst.gst_id
    where itm.client_id = p_client_id and itm.is_active = 1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_items_to_update_local_language` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_items_to_update_local_language`(p_client_id bigint,
																					p_emp_user_id varchar(150),
																					p_emp_device_id varchar(100),
																					p_transaction_key varchar(100),
                                                                                    p_search_param varchar(50))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    if length(p_search_param) = 0 then
		select item_id,item_name,item_name_telugu
		from PayBillApp.tbl_items
		where client_id = p_client_id and 
				is_active = 1 and 
				length(item_name_telugu) = 0;
	else 
		select item_id,item_name,item_name_telugu
		from PayBillApp.tbl_items
		where client_id = p_client_id and 
				is_active = 1 and 
				(item_barcode like concat('%',p_search_param,'%') || 
                item_name like concat('%',p_search_param,'%') ||
                item_alias_name like concat('%',p_search_param,'%'));
	end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_item_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_item_details`(p_client_id bigint,
																	p_item_id bigint)
begin
	declare v_gst_included_on_price int(1);
    select gst_included_on_price into v_gst_included_on_price
    from PayBillApp.tbl_clients where client_id = p_client_id;
    
	select item_id,
			item_name,
			item_name_telugu,
			item_alias_name,
			item_barcode,
			item_mrp_price,
            (case when (v_gst_included_on_price = 1 and itm.gst_id is not null) then round(item_sales_price + (item_sales_price * (cgst_in_per + sgst_in_per))/100,2)
            else item_sales_price end) as item_sales_price,
			item_purchase_price,
			itm.gst_id,
			opening_balance,
			current_balance,
			item_discount_type,
			item_discount_in_per,
			item_discount_expiry_date,
			itm.is_active,
			hsn_code
	from PayBillApp.tbl_items itm
    left outer join PayBillApp.tbl_gst gst
    on itm.gst_id = gst.gst_id
	where p_client_id = itm.client_id and item_id = p_item_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_item_for_device_sqllite` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_item_for_device_sqllite`(p_client_id bigint, p_item_id bigint)
BEGIN
    select item_id,
			item_name,
            item_alias_name,
            item_barcode,
            item_mrp_price,
            item_sales_price,
            item_discount_in_per,
            item_discount_expiry_date,
            (ifnull(cgst_in_per,0) + ifnull(sgst_in_per,0)) as gst_per,
            item_name_telugu
    from PayBillApp.tbl_items itm
    left outer join PayBillApp.tbl_gst gst
    on itm.gst_id = gst.gst_id
    where itm.client_id = p_client_id and item_id = p_item_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_item_names` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_item_names`()
begin
	
	select `item_id`,
			`item_name`
	from tbl_items
	order by `item_name`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_item_on_barcode_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_item_on_barcode_for_device`(p_client_id bigint,
																					p_emp_user_id varchar(150),
																					p_emp_device_id varchar(100),
																					p_transaction_key varchar(100),
																					p_item_barcode varchar(30))
leave_lable: BEGIN
	declare v_client_type_id bigint;
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select client_type_id into v_client_type_id from PayBillApp.tbl_clients where client_id = p_client_id;
    
    select item_name,
            item_alias_name,
            item_barcode,
            item_mrp_price,
            item_name_telugu
    from PayBillApp.tbl_items itm
    inner join PayBillApp.tbl_clients clt
    on itm.client_id = clt.client_id
    where item_barcode = p_item_barcode and client_type_id = v_client_type_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_languages` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_languages`(p_client_id bigint)
BEGIN
	select language_code,language_name
    from PayBillApp.tbl_languages;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_localities` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_localities`(p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    select locality_id,city_name,locality_name,loc.is_active 
    from PayBillApp.tbl_locality loc
    inner join PayBillApp.tbl_cities cty
    on loc.city_id = cty.city_id
    order by city_name asc,locality_name asc,loc.is_active desc;
	
    call PayBillApp.usp_get_active_cities();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_localities_and_client_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_localities_and_client_types`()
BEGIN
	select locality_id, concat(locality_name,',',city_name) as locality_name
    from PayBillApp.tbl_locality loc
    inner join PayBillApp.tbl_cities cty
    on loc.city_id = cty.city_id
    where loc.is_active = 1 order by locality_name;
    
    select client_type_id,client_type_desc
    from PayBillApp.tbl_client_types
    where is_active = 1 order by client_type_desc;
    
    select package_id,
			concat(package_name,' - ',package_no_users, ' Users') as package_name
    from PayBillApp.tbl_packages
    where package_is_active = 1 order by package_no_users;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_locs_clttps` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_locs_clttps`()
BEGIN
	select locality_id as LocalityId, concat(locality_name,', ',city_name) as LocalityName
    from PayBillApp.tbl_locality loc
    inner join PayBillApp.tbl_cities cty
    on loc.city_id = cty.city_id
    where loc.is_active = 1 order by locality_name;
        
    select client_type_id as ClientTypeId,
			client_type_desc as ClientTypeName
    from PayBillApp.tbl_client_types
    where is_active = 1 order by client_type_desc;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_locs_clttps_pkgs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_locs_clttps_pkgs`()
BEGIN
	select locality_id, concat(locality_name,',',city_name) as locality_name
    from PayBillApp.tbl_locality loc
    inner join PayBillApp.tbl_cities cty
    on loc.city_id = cty.city_id
    where loc.is_active = 1 order by locality_name;
    
    select client_type_id,client_type_desc
    from PayBillApp.tbl_client_types
    where is_active = 1 order by client_type_desc;
    
    select package_id,
			concat(package_name,' - ',package_no_users, ' Users') as package_name
    from PayBillApp.tbl_packages
    where package_is_active = 1 order by package_no_users;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_payment_and_upi_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_payment_and_upi_types`(p_client_id bigint)
BEGIN
	select cpmt.payment_type_id as ValueID,
			payment_type_desc as ValueName
	from PayBillApp.tbl_client_payment_types cpmt
    inner join PayBillApp.tbl_payment_types pmt
    on cpmt.payment_type_id = pmt.payment_type_id
    where client_id = p_client_id
    order by cpmt.payment_type_id;
	
	select cupi.upi_type_id as ValueID,
			upi_type_desc as ValueName,
            upi_image_name as ImageName
	from PayBillApp.tbl_client_upi_types cupi
	inner join PayBillApp.tbl_upi_types upi
    on cupi.upi_type_id = upi.upi_type_id
    where client_id = p_client_id
    order by cupi.upi_type_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_payment_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_payment_types`(p_client_id bigint)
BEGIN
	select pmt.payment_type_id,
			payment_type_desc,
			ifnull(client_payment_id,0) as is_selected
    from PayBillApp.tbl_payment_types pmt
    left outer join PayBillApp.tbl_client_payment_types cpmt 
    on pmt.payment_type_id = cpmt.payment_type_id and client_id = p_client_id
    order by pmt.payment_type_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_purchase_invoice` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_purchase_invoice`(p_client_id bigint,
																		p_supplier_id bigint,
																		p_from_date date, 
																		p_to_date date)
begin
	 if p_from_date is not null and p_to_date is not null then
		with purchase_details as 
		(
			select dtl.purchase_id,
					sum(item_quantity) as total_quantity,
					sum(item_total_value) as total_item_value
			from tbl_purchase_details dtl
			inner join tbl_purchase pur
			on dtl.purchase_id = pur.purchase_id
			where client_id = p_client_id and 
					supplier_id = ifnull(supplier_id,p_supplier_id)
			group by purchase_id
		)
		select	pur.purchase_id,
				supplier_name,
				purchase_inv_date,
				purchase_inv_no,
				total_quantity,
				total_item_value,
				transport_charge,
				packing_charge,
                other_charge,
				trade_discount,
				(total_item_value + 
				transport_charge + 
				packing_charge + 
				other_charge - 
				trade_discount) as total_inv_value
		from tbl_purchase pur
		inner join purchase_details purd
		on pur.purchase_id = purd.purchase_id
		inner join tbl_suppliers sup
		on pur.supplier_id = sup.supplier_id
		where pur.client_id = p_client_id and 
				purchase_inv_date between p_from_date and p_to_date
		order by pur.purchase_id desc;
	else 
		with purchase_details as 
		(
			select dtl.purchase_id,
					sum(item_quantity) as total_quantity,
					sum(item_total_value) as total_item_value
			from tbl_purchase_details dtl
			inner join tbl_purchase pur
			on dtl.purchase_id = pur.purchase_id
			where client_id = p_client_id and 
					supplier_id = ifnull(supplier_id,p_supplier_id)
			group by purchase_id
		)
		select	pur.purchase_id,
				supplier_name,
                supplier_address,
                supplier_mobile,
				purchase_inv_date,
				purchase_inv_no,
				total_quantity,
				total_item_value,
				transport_charge,
				packing_charge,
				trade_discount,
                other_charge,
				(total_item_value + 
				transport_charge + 
				packing_charge + 
				other_charge - 
				trade_discount) as total_inv_value
		from tbl_purchase pur
		inner join purchase_details purd
		on pur.purchase_id = purd.purchase_id
		inner join tbl_suppliers sup
		on pur.supplier_id = sup.supplier_id
		where pur.client_id = p_client_id
        order by pur.purchase_id desc;
        
    end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_purchase_invoice_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_purchase_invoice_details`(p_client_id bigint,
																				p_purchase_id bigint,
																				p_emp_user_id varchar(150),
																				p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
	select	purchase_id,
			pur.supplier_id,
			purchase_inv_date,
			purchase_inv_no,
			transport_charge,
			packing_charge,
			other_charge,
			trade_discount,
            supplier_name
	from PayBillApp.tbl_purchase pur
    inner join PayBillApp.tbl_suppliers sup
    on pur.supplier_id = sup.supplier_id
	where pur.client_id = p_client_id and 
			purchase_id = p_purchase_id;
	
	
	select	purchase_details_id,
			dtls.item_id,
			item_name,
			item_barcode,
			item_quantity,
			item_price,
            item_amount,
			dtls.item_discount_in_per,
			dtls.item_discount_in_rs,
			cgst_in_per,
			sgst_in_per,
            igst_in_per,
            cgst_in_rs,
            sgst_in_rs,
            igst_in_rs,
            gst_id,
			item_total_value
	from PayBillApp.tbl_purchase_details dtls
	inner join PayBillApp.tbl_items itm
	on dtls.item_id = itm.item_id
	where client_id = p_client_id and purchase_id = p_purchase_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_purchase_invoice_for_print` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_purchase_invoice_for_print`(p_purchase_id bigint)
begin

	
	select `supplier_name`,
			`supplier_address`,
			`supplier_mobile`,
			`purchase_inv_date`,
			`purchase_inv_no`,
			`transport_charge`,
			`packing_charge`,
			`other_charge`,
			`trade_discount`
	from tbl_purchase pur
	inner join tbl_suppliers supp
	on pur.supplier_id = supp.supplier_id
	where `purchase_id` = p_purchase_id;
	
	
	
	select `item_name`,
			`item_barcode`,
			`hsn_code`,
			`item_quantity`,
			`item_price`,
			`item_amount`,
			puri.item_discount_in_per,
			`item_discount_in_rs`,
			(`item_amount` - `item_discount_in_rs`) as taxable_value,
			`item_tax_in_per`,
			`item_tax_in_rs`,
			`item_total_value`
	from tbl_purchase_details puri
	inner join tbl_items itm
	on puri.item_id = itm.item_id
	where `purchase_id` = p_purchase_id;
	
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_purchase_sales_analysis` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_purchase_sales_analysis`(p_from_date date, p_to_date date)
begin

	
	select	`sales_date`,
			sls.sales_id,
			`item_name`,
			`item_barcode`,
			`item_quantity`,
			`purchase_rate_incl_gst` as purchase_price,
			`original_rate` as sales_price,
			((`original_rate` - `purchase_rate_incl_gst`) * `item_quantity`) as profit_or_loss
	from tbl_sales sls
	inner join tbl_sales_details slsd
	on sls.sales_id = slsd.sales_id 
	inner join tbl_items itm
	on slsd.item_id = itm.item_id 
	where `sales_date` between p_from_date and p_to_date
	order by `sales_date`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_registration_requests` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_registration_requests`(p_user_id varchar(50),
																		p_device_app_id varchar(250),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									device_app_id = p_device_app_id and 
                                    user_is_active = 1 and 
                                    transaction_key = p_transaction_key) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	select request_id as EnquiryId,
			date_format(created_date,'%d-%m-%Y') as EnquiryDate,
            client_name as EnquiryName,
            contact_mobile as EnquiryMobile,
            client_address as EnquiryAddress,
            contact_name as EnquiryRemarks,
            request_is_new as EnquiryIsNew
    from PayBillApp.tbl_client_requests 
    where is_mobile_validated = 1
    order by request_is_new desc, request_id desc;
    
     update PayBillApp.tbl_client_requests set request_is_new = 0 where request_is_new = 1;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_report_formats` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_report_formats`(p_client_id bigint)
BEGIN
	select report_format_id,report_format_desc
    from tbl_report_format
    order by report_format_desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_sales_enquiries` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_sales_enquiries`(p_user_id varchar(50),
																		p_device_app_id varchar(250),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									device_app_id = p_device_app_id and 
                                    user_is_active = 1 and 
                                    transaction_key = p_transaction_key) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	select enquiry_id as EnquiryId,
			date_format(enquiry_date,'%d-%m-%Y') as EnquiryDate,
            enquiry_name as EnquiryName,
            enquiry_mobile as EnquiryMobile,
            enquiry_address as EnquiryAddress,
            enquiry_remarks as EnquiryRemarks,
            enquiry_is_new as EnquiryIsNew
    from PayBillApp.tbl_sales_enquiries where enquiry_is_validated = 1
    order by enquiry_is_new desc, enquiry_id desc;
    
     update PayBillApp.tbl_sales_enquiries set enquiry_is_new = 0 where enquiry_is_new = 1;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_sales_enquiries_to_manage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_sales_enquiries_to_manage`(p_user_id varchar(50),
																				p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	select enquiry_id,
			date_format(enquiry_date,'%d-%m-%Y %H:%i') as enquiry_date,
            enquiry_name,
            enquiry_mobile,
            enquiry_address,
            enquiry_remarks,
            enquiry_is_new
    from PayBillApp.tbl_sales_enquiries 
    where enquiry_is_validated = 1
    order by enquiry_is_new desc, enquiry_id desc;
    
    update PayBillApp.tbl_sales_enquiries set enquiry_is_new = 0 where enquiry_is_new = 1;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_sales_invoice_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_sales_invoice_details`(p_client_id bigint,
																			p_sales_id bigint,
																			p_emp_user_id varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select sls.sales_id,
			sales_date,
			(transport_charge + packing_charge + other_charge) as others_charge,
            (transport_charge + packing_charge + other_charge + total_incl_gst) as total_amount,
			sls.created_by,
            concat(emp_first_name,' ', emp_last_name) as emp_name
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtls
    on sls.sales_id = dtls.sales_id
    inner join PayBillApp.tbl_users usr
    on sls.created_by = usr.emp_user_id
	where sls.sales_id = p_sales_id;
	
	
	select item_name,
			item_quantity,
			item_price,
			item_total,
			item_discount_in_rs,
			item_taxable_value,
			(slsi.cgst_in_per + slsi.sgst_in_per) as gst_in_per,
			(cgst_in_rs + sgst_in_rs + igst_in_rs) as gst_in_rs,
			item_total_value_incl_gst
	from PayBillApp.tbl_sales_details slsi
	inner join PayBillApp.tbl_items itm
	on slsi.item_id = itm.item_id
	where sales_id = p_sales_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_sales_invoice_to_deliver` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_sales_invoice_to_deliver`(p_client_id bigint,
																				p_sales_id bigint)
begin
	select sales_id as SalesID,
			date_format(created_date,'%d-%m-%Y') as SalesDate,
			item_name as ItemName,
			item_quantity as Quantity,
			item_total_value_incl_gst as TotalAmount,
            created_by as CreatedBy
	from PayBillApp.tbl_sales_details slsi
	inner join PayBillApp.tbl_items itm
	on slsi.item_id = itm.item_id
    inner join PayBillApp.tbl_sales sls
    on sls.sales_id = slsi.sales_id
	where sales_id = p_sales_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_sales_invoice_to_print` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_sales_invoice_to_print`(p_client_id bigint,
																			p_sales_id bigint)
begin
	    
	select sales_id as SalesID,
			date_format(sales_date,'%d-%b-%Y') as SalesDate,
			transport_charge as TransportCharge,
			packing_charge as PackingCharge,
			other_charge as OtherCharge,
			paid_cash as CashReceived,
			sls.created_by as CreatedBy,
            invoice_delivery_key as InvoiceDeliveryKey,
            barcode_required_on_invoice as BarcodeReqOnInvoice,
            invoice_delivery_key as BarcodeValue,
            payment_type_desc as PaymentType,
            upi_type_desc as UPIType,
            date_format(sls.created_date,'%d-%b-%Y %H:%i') as CreatedDate
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.tbl_clients clt
    on sls.client_id = clt.client_id
    inner join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    left outer join PayBillApp.tbl_upi_types upi
    on sls.upi_type_id = upi.upi_type_id
	where sales_id = p_sales_id;
	
	
	select item_name as ItemName,
			item_barcode as ItemCode,
			item_quantity as Quantity,
			item_price as ItemPrice,
			item_total as ItemTotal,
			(item_discount_in_rs + special_discount_in_rs) as DiscountInRs,
			item_taxable_value as TaxableValue,
			slsi.cgst_in_per as CGSTInPer,
			slsi.sgst_in_per as SGSTInPer,
            slsi.igst_in_per as IGSTInPer,
			cgst_in_rs as CGSTInRs,
			sgst_in_rs as SGSTInRs,
			igst_in_rs as IGSTInRs,
			item_total_value_incl_gst as TotalValueIncludeGST,
			item_saving_amount as SavingAmount,
			slsi.item_mrp_price as ItemMRP,
            item_name_telugu as LocalLanguage
	from PayBillApp.tbl_sales_details slsi
	inner join PayBillApp.tbl_items itm
	on slsi.item_id = itm.item_id
	where sales_id = p_sales_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_sales_inv_to_manage_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_sales_inv_to_manage_for_device`(p_client_id bigint,
																					p_sales_id bigint,
																					p_emp_user_id varchar(150),
																					p_emp_device_id varchar(100),
																					p_transaction_key varchar(100))
leave_lable: BEGIN
	declare v_sales_invoice_lock_in_mins int(1);
    #declare v_sales_id bigint;
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	select sales_invoice_lock_in_mins into v_sales_invoice_lock_in_mins
    from PayBillApp.tbl_clients where client_id = p_client_id;
    
    select	sales_id as SalesID,
				date_format(sales_date,'%d-%m-%Y') as SalesDate,
                payment_type_desc as PaymentType,
                upi_type_desc as UpiType,
                (transport_charge + packing_charge + other_charge) as OtherCharge
        from PayBillApp.tbl_sales sls
        inner join tbl_payment_types pmt
        on sls.payment_type_id = pmt.payment_type_id
        left outer join tbl_upi_types upi
        on sls.upi_type_id = upi.upi_type_id
        where sales_id = p_sales_id and 
				client_id = p_client_id and 
				created_by = p_emp_user_id and
				(is_locked = 0 or 
				date_add(created_date, interval v_sales_invoice_lock_in_mins minute) > now());
        
        select sales_details_id as SalesDetailsID,
				dtls.item_id as ItemID,
                item_barcode as ItemCode,
				item_name as ItemName,
                item_quantity as Quantity,
                item_price as ItemPrice,
                item_discount_in_rs as DiscountInRs,
                item_taxable_value as TaxableValue,
                item_total_value_incl_gst as TotalValue
        from PayBillApp.tbl_sales_details dtls
        inner join PayBillApp.tbl_items itm
        on dtls.item_id = itm.item_id
        where sales_id = p_sales_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_sales_items_to_check_stock` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_sales_items_to_check_stock`(p_client_id bigint,
																				p_item_ids varchar(3000))
BEGIN
	declare v_dynamic_query varchar(6000);
    set v_dynamic_query = concat('select item_id,current_balance from tbl_items where client_id = ',p_client_id,' and item_id in (',p_item_ids,')');
    
    SET @statement = v_dynamic_query;
	PREPARE dynquery FROM @statement;
	EXECUTE dynquery;
	DEALLOCATE PREPARE dynquery; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_search_items_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_search_items_for_device`(p_client_id bigint,
																			p_emp_user_id varchar(150),
																			p_search_param varchar(50),
																			p_emp_device_id varchar(100),
																			p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select item_id,
			item_name,
            item_barcode,
            item_mrp_price,
            item_sales_price,
            (case when item_discount_expiry_date is not null and datediff(item_discount_expiry_date,date(now())) >= 0 then item_discount_in_per
            else 0 end) as item_discount_in_per,
            (cgst_in_per + sgst_in_per) as gst_per,
            current_balance
    from PayBillApp.tbl_items itm
    inner join PayBillApp.tbl_gst gst
    on itm.gst_id = gst.gst_id
    where itm.client_id = p_client_id and 
			itm.is_active = 1 and 
            (item_name like concat('%',p_search_param,'%') or 
            item_alias_name like concat('%',p_search_param,'%') or 
            item_barcode like concat('%',p_search_param,'%'));

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_selected_gst_per` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_selected_gst_per`(p_gst_id bigint)
BEGIN
	select  cgst_in_per + sgst_in_per
    from tbl_gst where gst_id = p_gst_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_selected_item_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_selected_item_details`(p_client_id bigint, p_item_id bigint)
BEGIN
	select item_id,
			item_barcode,
			item_name,
            item_sales_price,
            item_purchase_price,
            ifnull(itm.gst_id,0) as gst_id,
            cgst_in_per,
            sgst_in_per,
            igst_in_per,
            (ifnull(cgst_in_per,0) + ifnull(sgst_in_per,0)) as gst_per
    from tbl_items itm
    left outer join tbl_gst gst
    on itm.gst_id = gst.gst_id
    where item_id = p_item_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_stock_search` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_stock_search`()
begin

	update tbl_items set `item_discount_in_per` = 0 
	where	`item_discount_in_per` > 0 and 
			`item_discount_expiry_date` < convert(now(), date);

	
	select `item_id`,
			`item_name`,
			`item_alias_name`,
			`item_barcode`,
			`item_mrp_price`,
			`item_sales_price`,
			`item_discount_in_per`,
			(`cgst_in_per` + `sgst_in_per` + `igst_in_per`) as gst_percentage,
			`current_balance`,
			`gst_is_included`,
			`item_discount_expiry_date`,
			`item_purchase_price`
	from tbl_items
	where `is_active` = 1
	order by `item_name`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_successful_payments` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_successful_payments`(p_search varchar(50),
																		p_user_id varchar(50),
																		p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	if p_search is null then
		select pmt.client_id,
				client_name,
                client_address,
                package_name,
				package_no_users,
				order_id,
				date_format(payment_date,'%d-%b-%Y') as payment_date,
				payment_trans_no,
				payment_amount
		from PayBillApp.tbl_client_payments pmt
		inner join PayBillApp.tbl_clients clt
		on pmt.client_id = clt.client_id
		inner join PayBillApp.tbl_packages pkg
		on pmt.package_id = pkg.package_id
		order by pmt.payment_id desc;
    else 
		select pmt.client_id,
				client_name,
                client_address,
                package_name,
				package_no_users,
				order_id,
				date_format(payment_date,'%d-%b-%Y') as payment_date,
				payment_trans_no,
				payment_amount
		from PayBillApp.tbl_client_payments pmt
		inner join PayBillApp.tbl_clients clt
		on pmt.client_id = clt.client_id
		inner join PayBillApp.tbl_packages pkg
		on pmt.package_id = pkg.package_id
        where (client_name like concat(p_search,'%') || 
				contact_mobile1 like concat(p_search,'%') || 
                order_id like concat(p_search,'%') || 
                payment_trans_no like concat(p_search,'%'))
		order by pmt.payment_id desc;
    end if;
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_suppliers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_suppliers`(p_client_id bigint)
begin
	
	select	supplier_id,
			supplier_name,
			supplier_address,
			supplier_mobile,
			supplier_email,
			gstin,
			is_active
	from tbl_suppliers 
    where client_id = p_client_id 
    order by is_active desc,supplier_name;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_suppliers_for_report` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_suppliers_for_report`()
begin
	
	select	`supplier_id`,
			`supplier_name`,
			`supplier_address`,
			`supplier_mobile`,
			`supplier_phone`,
			`supplier_email`,
			`gstin`,
			(select case `is_active`
			when 1 then 'active'
			else 'inactive' end) as supp_status
	from tbl_suppliers
	order by `supplier_name`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_supplier_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_supplier_details`(p_client_id bigint,
																		p_supplier_id bigint)
BEGIN
	select	supplier_id,
			supplier_name,
			supplier_address,
			supplier_mobile,
			supplier_email,
			gstin,
			is_active,
            supplier_phone,
            is_local_vendor
	from tbl_suppliers 
    where client_id = p_client_id and supplier_id = p_supplier_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_supplier_names` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_supplier_names`(p_client_id bigint)
begin
	
	select	supplier_id,
			supplier_name
	from tbl_suppliers
	where client_id = p_client_id and is_active = 1
	order by supplier_name;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_support_requests` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_support_requests`(p_user_id varchar(50),
																		p_device_app_id varchar(250),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									device_app_id = p_device_app_id and 
                                    user_is_active = 1 and 
                                    transaction_key = p_transaction_key) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
     select support_request_id as RequestId,
			req.emp_user_id as RequestUserId,
			date_format(support_request_date,'%d-%m-%Y') as RequestDate,
			client_name as ClientName,
            client_address as ClientAddress,
            contact_mobile1 as ClientMobile,
			support_request_remarks as ClientRemarks
	from PayBillApp.tbl_support_requests req 
    inner join PayBillApp.tbl_clients clt
    on req.client_id = clt.client_id
    where support_status_id = 1 order by support_request_id desc; 
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_today_sales_summary_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_today_sales_summary_for_device`(p_client_id bigint,
																					p_emp_user_id varchar(150),
																					p_emp_device_id varchar(100),
																					p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
                
	select payment_type_desc as PaymentType,
			upi_type_desc as UpiType,
            count(*) as TotalInvoice,
			sum(transport_charge + packing_charge + other_charge + total_incl_gst) as TotalAmount,
            sls.payment_type_id, sls.upi_type_id
    from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtls
    on sls.sales_id = dtls.sales_id
    inner join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    left outer join PayBillApp.tbl_upi_types upi
    on sls.upi_type_id = upi.upi_type_id
    where client_id = p_client_id and 
			is_deleted = 0 and
			created_by = p_emp_user_id and 
            sales_date = date(now())
	group by payment_type_desc,upi_type_desc,sls.payment_type_id, sls.upi_type_id
    order by sls.payment_type_id, sls.upi_type_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_upi_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_upi_types`(p_client_id bigint)
BEGIN
	select upi.upi_type_id,
			upi_type_desc,
            upi_image_name,
			ifnull(client_upi_type_id,0) as is_selected
    from PayBillApp.tbl_upi_types upi
    left outer join PayBillApp.tbl_client_upi_types cupi 
    on upi.upi_type_id = cupi.upi_type_id and client_id = p_client_id
    order by upi.upi_type_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_users` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_users`(p_client_id bigint)
BEGIN
	select emp_user_id, 
			concat(emp_first_name, ' ', emp_last_name, ' (', emp_user_id,')') as emp_name
    from PayBillApp.tbl_users
    where client_id = p_client_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_users_and_payment_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_users_and_payment_types`(p_client_id bigint)
BEGIN
	select emp_user_id, 
			concat(emp_first_name, ' ', emp_last_name, ' (', emp_user_id,')') as emp_name
    from PayBillApp.tbl_users
    where client_id = p_client_id;
    
	select payment_type_id,payment_type_desc
    from PayBillApp.tbl_payment_types
    order by payment_type_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_user_names` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_user_names`()
begin
	
	select	`emp_id`,
			(concat(`emp_first_name` , ' ' , `emp_user_id` , '')) as emp_name,
			`emp_user_id`
	from tbl_employee
	order by `emp_first_name`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_user_sales_invoices_daterange_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_user_sales_invoices_daterange_for_device`(p_client_id bigint,
																					p_emp_user_id varchar(150),
																					p_emp_device_id varchar(100),
																					p_transaction_key varchar(100),
																					p_user_id varchar(150),
																					p_from_date date,
                                                                                    p_to_date date)
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	select	sls.sales_id as SalesID,
			date_format(sales_date,'%d-%m-%Y') as SalesDate,
            (case when payment_type_desc = 'UPI' then upi_type_desc
            else payment_type_desc end) as PaymentType,
			quantity as Quantity,
			(transport_charge + packing_charge + other_charge + total_incl_gst) as InvoiceAmount
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtls
    on sls.sales_id = dtls.sales_id
    left outer join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    left outer join PayBillApp.tbl_upi_types upi
    on sls.upi_type_id = upi.upi_type_id
	where created_by = p_user_id and 
			is_deleted = 0 and
            sales_date between p_from_date and p_to_date
	order by sls.sales_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_user_sales_invoices_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_user_sales_invoices_for_device`(p_client_id bigint,
																					p_emp_user_id varchar(150),
																					p_emp_device_id varchar(100),
																					p_transaction_key varchar(100),
                                                                                    p_sales_date date)
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	select	sls.sales_id as SalesID,
			date_format(sales_date,'%d-%m-%Y') as SalesDate,
            (case when payment_type_desc = 'UPI' then upi_type_desc
            else payment_type_desc end) as PaymentType,
			quantity as Quantity,
			(transport_charge + packing_charge + other_charge + total_incl_gst) as InvoiceAmount
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtls
    on sls.sales_id = dtls.sales_id
    left outer join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    left outer join PayBillApp.tbl_upi_types upi
    on sls.upi_type_id = upi.upi_type_id
	where created_by = p_emp_user_id and 
			is_deleted = 0 and
			sales_date = p_sales_date
	order by sls.sales_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_user_salt` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_user_salt`(p_emp_user_id varchar(150))
BEGIN
	select emp_salt from tbl_users where emp_user_id = p_emp_user_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_user_salt_and_key` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_user_salt_and_key`(p_emp_user_id varchar(150),
																		p_emp_device_id varchar(100),
																		out o_emp_salt varchar(100),
																		out o_device_public_key varchar(100))
BEGIN
	select emp_salt,device_public_key into o_emp_salt,o_device_public_key
    from tbl_users where emp_user_id = p_emp_user_id and emp_device_id = p_emp_device_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_user_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_user_types`()
begin
	
	select `user_type_id`,`user_type_desc`
	from tbl_user_types;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_utilities_for_win` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_utilities_for_win`(p_client_id bigint,
																		p_emp_user_id varchar(150),
                                                                        p_win_system_unique_id varchar(250),
																		p_win_qrcode_security_key varchar(500),
                                                                        out o_server_date datetime)
leave_lable: BEGIN

	if not exists(select win.win_qrcode_id 
					from PayBillApp.tbl_win_qrcodes win
                    inner join PayBillApp.tbl_users usr
                    on win.win_qrcode_id = usr.win_qrcode_id
					where usr.client_id = p_client_id and 
							emp_user_id = p_emp_user_id and 
							win_system_unique_id = p_win_system_unique_id and
							win_qrcode_security_key = p_win_qrcode_security_key and 
							is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if; 
    
    set o_server_date = now();
        
    select item_id,
			item_name,
            item_alias_name,
            item_barcode,
            item_mrp_price,
            item_sales_price,
             (case when item_discount_in_per > 0 and item_discount_expiry_date is not null and datediff(item_discount_expiry_date,date(now())) >= 0 then item_discount_in_per
            else 0 end) as item_discount_in_per,
            (ifnull(cgst_in_per,0) + ifnull(sgst_in_per,0)) as gst_per,
            item_name_telugu
    from PayBillApp.tbl_items itm
    left outer join PayBillApp.tbl_gst gst
    on itm.gst_id = gst.gst_id
    where itm.client_id = p_client_id and itm.is_active = 1;
    
    call PayBillApp.usp_get_payment_and_upi_types(p_client_id);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_view_sales_for_win` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_view_sales_for_win`(p_client_id bigint,
																		p_from_date date,
                                                                        p_to_date date,
																		p_emp_user_id varchar(150),
																		p_win_qrcode_id int,
																		p_win_system_unique_id varchar(250),
																		p_win_qrcode_security_key varchar(500))
leave_lable: BEGIN

	if not exists(select win.win_qrcode_id 
					from PayBillApp.tbl_win_qrcodes win
                    inner join PayBillApp.tbl_users usr
                    on win.win_qrcode_id = usr.win_qrcode_id
					where usr.client_id = p_client_id and 
							emp_user_id = p_emp_user_id and 
                            win.win_qrcode_id = p_win_qrcode_id and
							win_system_unique_id = p_win_system_unique_id and
							win_qrcode_security_key = p_win_qrcode_security_key and 
							is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if; 
    
    select sls.sales_id,
			date_format(sales_date,'%d-%b-%Y') as invoice_date,
            payment_type_desc,
             ifnull(upi_type_desc,'Cash') as upi_type_desc,
			quantity,
			total_incl_gst,
            (case when is_locked = 0 then 'Modify' else 'Locked' end) as edit_item
    from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtl
    on sls.sales_id = dtl.sales_id
    left outer join PayBillApp.tbl_payment_types ptp
    on sls.payment_type_id = ptp.payment_type_id
    left outer join PayBillApp.tbl_upi_types upi
    on sls.upi_type_id = upi.upi_type_id
    where sls.client_id = p_client_id and 
			is_mobile_billing = 0 and 
            is_deleted = 0 and
			sales_date between p_from_date and p_to_date and 
			sls.created_by = p_emp_user_id
	order by sls.sales_id;
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_get_wallet_types` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_get_wallet_types`()
begin
	
	select `wallet_type_id`,`wallet_desc`
	from tbl_wallet_types
	order by `wallet_type_id`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_city` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_city`(p_city_id bigint,
															p_city_name varchar(50),
															p_is_active int(1),
															p_user_id varchar(50),
															p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	if p_city_id = 0 then
		insert into PayBillApp.tbl_cities(city_name,is_active) values(p_city_name,p_is_active);
    else
		update PayBillApp.tbl_cities set city_name = p_city_name, is_active = p_is_active where city_id = p_city_id;
    end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_client` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_client`(p_client_id bigint,
																p_client_name varchar(100),
																p_contact_name varchar(100),
																p_client_address varchar(500),
																p_contact_mobile1 varchar(10),
																p_contact_mobile2 varchar(10),
																p_contact_email varchar(150),
																p_client_gst varchar(20),
																p_client_type_id bigint,
																p_locality_id bigint,
                                                                p_package_id int,
                                                                p_discount_in_rs double,
                                                                p_discount_end_date date,
                                                                p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;


	if p_client_id = 0 then
    
		if exists (select client_id from PayBillApp.tbl_clients where contact_mobile1 = p_contact_mobile1) then
			signal sqlstate '45000' set message_text = 'Oops! Mobile1 is already in use.';
            leave leave_lable;
        end if;
        
        if length(p_contact_mobile2) > 0 and exists (select client_id from PayBillApp.tbl_clients where contact_mobile2 = p_contact_mobile2) then
			signal sqlstate '45000' set message_text = 'Oops! Mobile2 is already in use.';
            leave leave_lable;
        end if;
    
		#if length(p_contact_email) > 0 and exists (select client_id from PayBillApp.tbl_clients where contact_email = p_contact_email) then
			#signal sqlstate '45000' set message_text = 'Oops! Email address is already in use.';
            #leave leave_lable;
        #end if;
        
        #if length(p_client_gst) > 0 and exists (select client_id from PayBillApp.tbl_clients where client_gst = p_client_gst) then
			#signal sqlstate '45000' set message_text = 'Oops! GSTIN is already in use.';
            #leave leave_lable;
        #end if;
    
		insert into PayBillApp.tbl_clients(client_name,
										contact_name,
                                        client_address,
                                        contact_mobile1,
                                        contact_mobile2,
                                        contact_email,
                                        client_gst,
                                        client_status_id,
                                        client_type_id,
                                        locality_id,
                                        invoice_delivery_key_date,
                                        package_id,
                                        created_by,
                                        subscription_start_date,
                                        discount_in_rs,
                                        discount_end_date)
								values(p_client_name,
										p_contact_name,
                                        p_client_address,
                                        p_contact_mobile1,
                                        p_contact_mobile2,
                                        p_contact_email,
                                        p_client_gst,
                                        2,
                                        p_client_type_id,
                                        p_locality_id,
                                        date(now()),
                                        p_package_id,
                                        p_user_id,
                                        date(now()),
                                        p_discount_in_rs,
                                        p_discount_end_date);
	else 
		if exists (select client_id from PayBillApp.tbl_clients where contact_mobile1 = p_contact_mobile1 and client_id <> p_client_id) then
			signal sqlstate '45000' set message_text = 'Oops! Mobile1 is already in use.';
            leave leave_lable;
        end if;
        
        if length(p_contact_mobile2) > 0 and exists (select client_id from PayBillApp.tbl_clients where contact_mobile2 = p_contact_mobile2 and client_id <> p_client_id) then
			signal sqlstate '45000' set message_text = 'Oops! Mobile2 is already in use.';
            leave leave_lable;
        end if;
    
		#if length(p_contact_email) > 0 and exists (select client_id from PayBillApp.tbl_clients where contact_email = p_contact_email and client_id <> p_client_id) then
			#signal sqlstate '45000' set message_text = 'Oops! Email address is already in use.';
            #leave leave_lable;
        #end if;
        
        #if length(p_client_gst) > 0 and exists (select client_id from PayBillApp.tbl_clients where client_gst = p_client_gst and client_id <> p_client_id) then
			#signal sqlstate '45000' set message_text = 'Oops! GSTIN has been already updated by another client.';
            #leave leave_lable;
        #end if;
		update PayBillApp.tbl_clients set 
										client_name = p_client_name,
										contact_name = p_contact_name,
                                        client_address = p_client_address,
                                        contact_mobile1 = p_contact_mobile1,
                                        contact_mobile2 = p_contact_mobile2,
                                        contact_email = p_contact_email,
                                        client_gst = p_client_gst,
                                        client_type_id = p_client_type_id,
                                        locality_id = p_locality_id,
                                        package_id = p_package_id,
                                        discount_in_rs = p_discount_in_rs,
                                        discount_end_date = p_discount_end_date
								where	client_id = p_client_id;
    end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_client_payment_type` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_client_payment_type`(p_client_id bigint,
																			p_payment_type_id int,
																			p_emp_user_id varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    insert into PayBillApp.tbl_client_payment_types(client_id,payment_type_id) values(p_client_id,p_payment_type_id);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_client_request` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_client_request`(p_client_name varchar(100),
																	p_contact_name varchar(100),
																	p_client_address varchar(500),
																	p_contact_mobile varchar(10),
																	p_contact_email varchar(150),
																	p_client_gst varchar(20),
																	p_client_type_id bigint,
																	p_locality_id bigint,
                                                                    p_request_otp varchar(100),
                                                                    out o_register_is_validated int(1),
                                                                    out o_request_id bigint,
                                                                    out o_otp_sms_api varchar(500),
                                                                    out o_enquiry_otp_template_id varchar(50))
leave_lable: BEGIN

	if exists (select client_id from PayBillApp.tbl_clients where (contact_mobile1 = p_contact_mobile || contact_mobile2 = p_contact_mobile)) then
		signal sqlstate '45000' set message_text = 'Oops! Mobile is already in use.';
		leave leave_lable;
	end if;
	
	if length(p_client_gst) > 0 and exists (select client_id from PayBillApp.tbl_clients where client_gst = p_client_gst) then
		signal sqlstate '45000' set message_text = 'Oops! GSTIN is already in use.';
		leave leave_lable;
	end if;
     
    /*
    if exists (select request_id from PayBillApp.tbl_client_requests where contact_mobile = p_contact_mobile) then
		signal sqlstate '45000' set message_text = 'Oops! Mobile is already in use.';
		leave leave_lable;
	end if;
	
	if length(p_client_gst) > 0 and exists (select request_id from PayBillApp.tbl_client_requests where client_gst = p_client_gst) then
		signal sqlstate '45000' set message_text = 'Oops! GSTIN is already in use.';
		leave leave_lable;
	end if; */

	if not exists(select request_id from PayBillApp.tbl_client_requests where contact_mobile = p_contact_mobile and is_mobile_validated = 1 limit 1) then
		delete from PayBillApp.tbl_client_requests where contact_mobile = p_contact_mobile;
		insert into PayBillApp.tbl_client_requests(client_name,
													contact_name,
													client_address,
													contact_mobile,
													contact_email,
													client_gst,
													client_type_id,
													locality_id,
													request_otp)
											values(p_client_name,
													p_contact_name,
													p_client_address,
													p_contact_mobile,
													p_contact_email,
													p_client_gst,
													p_client_type_id,
													p_locality_id,
													p_request_otp);
													
		set o_request_id = (select last_insert_id());
        set o_register_is_validated = 0;
        select otp_sms_api, enquiry_otp_template_id into o_otp_sms_api, o_enquiry_otp_template_id from PayBillApp.tbl_admin limit 1;
	else
		select request_id into o_request_id
        from PayBillApp.tbl_client_requests where contact_mobile = p_contact_mobile and is_mobile_validated = 1 limit 1;
        update PayBillApp.tbl_client_requests set request_is_new = 1 where request_id = o_request_id;
        set o_register_is_validated = 1;
	end if;
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_client_type` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_client_type`(p_client_type_id bigint,
																p_client_type_desc varchar(50),
																p_is_active int(1),
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	if p_client_type_id = 0 then
		insert into PayBillApp.tbl_client_types(client_type_desc,is_active) values(p_client_type_desc,p_is_active);
    else
		update PayBillApp.tbl_client_types set client_type_desc = p_client_type_desc, is_active = p_is_active where client_type_id = p_client_type_id;
    end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_client_upi_type` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_client_upi_type`(p_client_id bigint,
																	p_upi_type_id int,
																	p_emp_user_id varchar(150),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    insert into PayBillApp.tbl_client_upi_types(client_id,upi_type_id) values(p_client_id,p_upi_type_id);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_client_user` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_client_user`(p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_emp_first_name varchar(50),
																	p_emp_last_name varchar(50),
																	p_emp_mobile varchar(10),
																	p_user_id varchar(50),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	declare v_emp_default_password varchar(100);
    declare v_emp_default_salt varchar(100);
    declare v_package_no_users tinyint;
    declare v_no_users tinyint;
    declare v_is_admin int(1);

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select emp_default_password,emp_default_salt,package_no_users into v_emp_default_password,v_emp_default_salt,v_package_no_users
	from PayBillApp.tbl_clients clt
    inner join PayBillApp.tbl_packages pkg
    on clt.package_id = pkg.package_id
    where client_id = p_client_id;
    
    select count(*) into v_no_users
    from PayBillApp.tbl_users
    where client_id = p_client_id;
        
    if v_package_no_users is null or v_no_users > v_package_no_users then
		signal sqlstate '45000' set message_text = 'User(s) limit has been exceeded. Please conatct the service provider!';
        leave leave_lable;
    end if;
    
    if exists(select emp_user_id from PayBillApp.tbl_users where emp_user_id = p_emp_user_id) then
		signal sqlstate '45000' set message_text = 'User ID not available.';
        leave leave_lable;
    end if;
	
    if v_no_users = 0 then
		set v_is_admin = 1;
	else 
		set v_is_admin = 0;
    end if;
    
	insert into PayBillApp.tbl_users(client_id,
						emp_user_id,
						emp_first_name,
						emp_last_name,
						emp_mobile,
						emp_salt,
						emp_pwd,
                        emp_device_id,
						is_active,
                        created_by,
                        is_admin)
				values(p_client_id,
						p_emp_user_id,
						p_emp_first_name,
						p_emp_last_name,
						p_emp_mobile,
						v_emp_default_salt,
						v_emp_default_password,
                        uuid(),
						1,
                        p_user_id,
                        v_is_admin);
                           
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_customer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_customer`(p_client_id bigint,
																p_customer_name varchar(100),
                                                                p_customer_address varchar(500),
                                                                p_customer_mobile varchar(10),
																p_emp_user_id varchar(150),
																p_emp_device_id varchar(100),
																p_transaction_key varchar(100),
																out o_customer_mobile varchar(10),
                                                                out o_customer_name varchar(100),
                                                                out o_customer_id bigint)
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if; 
   
   select customer_id,customer_mobile,customer_name into o_customer_id,o_customer_mobile,o_customer_name from PayBillApp.tbl_customers where customer_mobile = p_customer_mobile;
   
   if o_customer_id is null then
		insert into PayBillApp.tbl_customers(customer_name,customer_address,customer_mobile,created_by,updated_by,client_id)
        values(p_customer_name,p_customer_address,p_customer_mobile,p_emp_user_id,p_emp_user_id,p_client_id);
        set o_customer_id = (select last_insert_id());
        set o_customer_mobile = p_customer_mobile;
        set o_customer_name = p_customer_name;
   end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_customer_win` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_customer_win`(p_client_id bigint,
																p_customer_name varchar(100),
                                                                p_customer_address varchar(500),
                                                                p_customer_mobile varchar(10),
																p_win_qrcode_id int,
																p_emp_user_id varchar(150),
																p_win_system_unique_id varchar(250),
																p_win_qrcode_security_key varchar(500),
																out o_customer_mobile varchar(10),
                                                                out o_customer_name varchar(100),
                                                                out o_customer_id bigint)
leave_lable: BEGIN

	if not exists(select win.win_qrcode_id 
					from PayBillApp.tbl_win_qrcodes win
                    inner join PayBillApp.tbl_users usr
                    on win.win_qrcode_id = usr.win_qrcode_id
					where usr.client_id = p_client_id and 
							emp_user_id = p_emp_user_id and 
                            win.win_qrcode_id = p_win_qrcode_id and
							win_system_unique_id = p_win_system_unique_id and
							win_qrcode_security_key = p_win_qrcode_security_key and 
							is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if; 
   
   select customer_id,customer_mobile,customer_name into o_customer_id,o_customer_mobile,o_customer_name from PayBillApp.tbl_customers where customer_mobile = p_customer_mobile;
   
   if o_customer_id is null then
		insert into PayBillApp.tbl_customers(customer_name,customer_address,customer_mobile,created_by,updated_by,client_id)
        values(p_customer_name,p_customer_address,p_customer_mobile,p_emp_user_id,p_emp_user_id,p_client_id);
        set o_customer_id = (select last_insert_id());
        set o_customer_mobile = p_customer_mobile;
        set o_customer_name = p_customer_name;
   end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_default_values` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_default_values`(
												p_admin_user_id varchar(30),
												p_admin_pwd varchar(50),
												p_company_name varchar(50),
												p_fyear_from_date date,
												p_fyear_to_date date,
												p_is_year_end_process int(1))
begin
	insert into tbl_user_types(`user_type_id`,`user_type_desc`) values(3,'operator');
	insert into tbl_user_types(`user_type_id`,`user_type_desc`) values(2,'manager');
	insert into tbl_user_types(`user_type_id`,`user_type_desc`) values(1,'administrator');
	
	insert into tbl_company_info(`sales_invoice_title`,
											`header_1`,
											`fyear_from_date`,
											`fyear_to_date`)
									values(	'tax invoice',
											p_company_name,
											p_fyear_from_date,
											p_fyear_to_date);	
											
	insert into tbl_employee(`emp_first_name`,
									`emp_last_name`,
									`emp_user_id`,
									`emp_pwd`,
									`user_type_id`,
									`is_active`)
							values(
									p_admin_user_id,
									p_admin_user_id,
									p_admin_user_id,
									p_admin_pwd,
									1,1);

	insert into tbl_wallet_types values(1,'phonepe');
	insert into tbl_wallet_types values(2,'gpay');
	insert into tbl_wallet_types values(3,'paytm');
	insert into tbl_wallet_types values(4,'others');
									
			
	insert into tbl_barcode_page_settings(`smt_barcode_page_columns`) values(4);						
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_device`(p_device_id varchar(50), p_device_name varchar(50))
begin
	insert tbl_devices(`device_id`,`device_name`) values(p_device_id,p_device_name);
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_gst` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_gst`(p_gst_id bigint,
															p_client_id bigint,
															p_gst_name varchar(30),
															p_cgst_in_per decimal(4,2),
															p_sgst_in_per decimal(4,2),
															p_igst_in_per decimal(4,2),
                                                            p_is_active int(1),
                                                            p_emp_user_id varchar(150),
															p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    if p_gst_id = 0 then
		if exists(select gst_name from tbl_gst where client_id = p_client_id and gst_name = p_gst_name) then
			signal sqlstate '02000' set message_text = 'Duplicate GST name.';
            leave leave_lable;
		end if;
		insert into tbl_gst(client_id, gst_name,cgst_in_per,sgst_in_per,igst_in_per,is_active)
		values(p_client_id, p_gst_name, p_cgst_in_per,p_sgst_in_per,p_igst_in_per,p_is_active);
	else 
		if exists(select gst_name from tbl_gst where client_id = p_client_id and gst_name = p_gst_name and gst_id <> p_gst_id) then
			signal sqlstate '02000' set message_text = 'Duplicate GST name.';
            leave leave_lable;
		end if;
		update tbl_gst set gst_name = p_gst_name,
							cgst_in_per = p_cgst_in_per,
							sgst_in_per = p_sgst_in_per,
							igst_in_per = p_igst_in_per,
							is_active = p_is_active
					where gst_id = p_gst_id;
							
	end if;

	
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_item` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_item`(p_client_id bigint,
															p_item_id bigint,
															p_item_name varchar(50),
                                                            p_item_name_telugu nvarchar(100),
															p_item_alias_name varchar(250),
															p_item_barcode varchar(30),
															p_item_mrp_price decimal(19,2),
															p_item_sales_price decimal(19,2),
															p_item_purchase_price decimal(19,2),
															p_item_discount_type varchar(2),
															p_item_discount_in_per decimal(19,2),
															p_item_discount_expiry_date date,
															p_opening_balance bigint,
															p_hsn_code varchar(10),
                                                            p_gst_id bigint,
															p_is_active int(1),
                                                            p_emp_user_id varchar(150),
															p_user_security_key varchar(100))
leave_lable: BEGIN

	declare v_cgst_in_per decimal(4,2);
	declare v_sgst_in_per decimal(4,2);
	declare v_igst_in_per decimal(4,2);
    declare v_gst_included_on_price int(1);
    declare v_gst_per decimal(4,2);
    #declare v_gst_rs decimal(19,2);
    
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    #set v_gst_rs = 0;
    
    select gst_included_on_price into v_gst_included_on_price
    from PayBillApp.tbl_clients where client_id = p_client_id;

	if v_gst_included_on_price = 1 and p_gst_id is not null then
		
        select cgst_in_per + sgst_in_per into v_gst_per
        from PayBillApp.tbl_gst where gst_id = p_gst_id;
        
        if v_gst_per > 0 then
			set p_item_sales_price = (p_item_sales_price * 100)/(100 + v_gst_per);
        end if;
        
    end if;

	if p_item_id = 0 then
		insert into tbl_items(client_id,
						  item_name,
						  item_alias_name,
						  item_barcode,
						  item_mrp_price,
						  item_sales_price,
						  item_purchase_price,
						  created_by,
						  opening_balance,
						  current_balance,
						  item_discount_type,
						  item_discount_in_per,
						  item_discount_expiry_date,
						  is_active,
						  gst_id,
						  item_name_telugu,
						  hsn_code)
			values(p_client_id,
					p_item_name,
					p_item_alias_name,
					p_item_barcode,
					p_item_mrp_price,
					p_item_sales_price,
					p_item_purchase_price,
					p_emp_user_id,
					p_opening_balance,
					p_opening_balance,
					p_item_discount_type,
					p_item_discount_in_per,
					p_item_discount_expiry_date,
					p_is_active,
					p_gst_id,
					p_item_name_telugu,
					p_hsn_code);
	else
	
		update tbl_items set 
							item_name = p_item_name,
							item_alias_name = p_item_alias_name,
							item_barcode = p_item_barcode,
							item_mrp_price = p_item_mrp_price,
							item_sales_price = p_item_sales_price,
							item_purchase_price = p_item_purchase_price,
							updated_date = now(),
							updated_by = p_emp_user_id,
							item_discount_type = p_item_discount_type,
							item_discount_in_per = p_item_discount_in_per,
							item_discount_expiry_date = p_item_discount_expiry_date,
							is_active = p_is_active,
							gst_id = p_gst_id,
							item_name_telugu = p_item_name_telugu,
							hsn_code = p_hsn_code 
				where	item_id = p_item_id;	
                
	end if;
    
    update PayBillApp.tbl_users set is_price_updated = 1 where client_id = p_client_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_item_from_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_item_from_device`(p_client_id bigint,
																		p_item_name varchar(50),
																		p_item_name_telugu nvarchar(100),
																		p_item_alias_name varchar(250),
																		p_item_barcode varchar(30),
																		p_item_mrp_price decimal(19,2),
																		p_item_sales_price decimal(19,2),
																		p_item_purchase_price decimal(19,2),
																		p_opening_balance bigint,
																		p_hsn_code varchar(10),
																		p_gst_id bigint,
																		p_emp_user_id varchar(150),
                                                                        p_emp_device_id varchar(100),
																		p_transaction_key varchar(100),
                                                                        out o_item_id bigint)
leave_lable: BEGIN
	declare v_is_allow_device_item_reg int(1);
    declare v_cgst_in_per decimal(4,2);
	declare v_sgst_in_per decimal(4,2);
	declare v_igst_in_per decimal(4,2);
    declare v_gst_included_on_price int(1);
    declare v_gst_per decimal(4,2);
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select gst_included_on_price,is_allow_device_item_reg into v_gst_included_on_price,v_is_allow_device_item_reg
    from PayBillApp.tbl_clients 
    where client_id = p_client_id;
    
    
    if v_is_allow_device_item_reg = 0 then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	if v_gst_included_on_price = 1 and p_gst_id is not null then
		
        select cgst_in_per + sgst_in_per into v_gst_per
        from PayBillApp.tbl_gst 
        where gst_id = p_gst_id;
        
        if v_gst_per > 0 then
			set p_item_sales_price = (p_item_sales_price * 100)/(100 + v_gst_per);
        end if;
        
    end if;

	update PayBillApp.tbl_users set is_price_updated = 1
    where client_id = p_client_id and emp_user_id <> p_emp_user_id;
    
    insert into tbl_items(client_id,
						  item_name,
						  item_alias_name,
						  item_barcode,
						  item_mrp_price,
						  item_sales_price,
						  item_purchase_price,
						  created_by,
						  opening_balance,
						  current_balance,
						  is_active,
						  gst_id,
						  item_name_telugu,
						  hsn_code)
			values(p_client_id,
					p_item_name,
					p_item_alias_name,
					p_item_barcode,
					p_item_mrp_price,
					p_item_sales_price,
					p_item_purchase_price,
					p_emp_user_id,
					p_opening_balance,
					p_opening_balance,
					1,
					p_gst_id,
					p_item_name_telugu,
					p_hsn_code);
                    
			select last_insert_id() into o_item_id;
			
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_locality` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_locality`(p_locality_id bigint,
																p_city_id bigint,
																p_locality_name varchar(100),
																p_is_active int(1),
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	if p_locality_id = 0 then
		insert into PayBillApp.tbl_locality(city_id,locality_name,is_active) values(p_city_id,p_locality_name,p_is_active);
    else
		update PayBillApp.tbl_locality set locality_name = p_locality_name, is_active = p_is_active where locality_id = p_locality_id;
    end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_payment_gateway_error` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_payment_gateway_error`(p_client_id bigint,
																			p_emp_user_id varchar(150),
																			p_emp_device_id varchar(100),
																			p_transaction_key varchar(100),
																			p_error_code varchar(50),
																			p_error_description varchar(500),
																			p_error_source varchar(50),
																			p_error_step varchar(50),
																			p_error_reason varchar(250))
leave_lable: BEGIN
	declare v_client_type_id bigint;
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	insert into PayBillApp.tbl_payment_gateway_error(error_code,
														error_description,
                                                        error_source,
                                                        error_step,
                                                        error_reason,
                                                        client_id,
                                                        emp_user_id)
												values(p_error_code,
														p_error_description,
                                                        p_error_source,
                                                        p_error_step,
                                                        p_error_reason,
                                                        p_client_id,
                                                        p_emp_user_id);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_purchase` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_purchase`(p_client_id bigint,
																p_purchase_id bigint,
																p_supplier_id bigint,
																p_purchase_inv_date date,
																p_purchase_inv_no varchar(30),
																p_transport_charge decimal(19,2),
																p_packing_charge decimal(19,2),
																p_other_charge decimal(19,2),
																p_trade_discount decimal(19,2),
                                                                p_emp_user_id varchar(150),
																p_user_security_key varchar(100),
																out o_purchase_id bigint,
                                                                out o_is_non_gst_vendor int(1),
																out o_is_igst int(1))
leave_lable: BEGIN

	declare v_supplier_gst varchar(30);
	declare v_client_gst varchar(30);
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    set o_is_igst = 0;
	
	select gstin,is_non_gst_vendor into v_supplier_gst,o_is_non_gst_vendor
	from tbl_suppliers where supplier_id = p_supplier_id;
	
	if v_supplier_gst is not null and length(v_supplier_gst) > 1 then
    
		select client_gst into v_client_gst
		from tbl_clients where client_id = p_client_id;
		
		if v_client_gst is not null and length(v_client_gst) > 1 then
			if (substring(v_client_gst,1,2) != substring(v_supplier_gst,1,2)) then
				set o_is_igst = 1;
			end if;
		end if;
	
	end if;
	
	if p_purchase_id = 0 then
		insert into tbl_purchase(client_id,
									supplier_id,
									purchase_inv_date,
									purchase_inv_no,
									transport_charge,
									packing_charge,
									other_charge,
									created_by,
									trade_discount)
							values(p_client_id,
									p_supplier_id,
									p_purchase_inv_date,
									p_purchase_inv_no,
									p_transport_charge,
									p_packing_charge,
									p_other_charge,
									p_emp_user_id,
									p_trade_discount);
									
						set o_purchase_id = (select last_insert_id());
										
	else 
		update tbl_purchase set 
								supplier_id = p_supplier_id,
								purchase_inv_date = p_purchase_inv_date,
								purchase_inv_no = p_purchase_inv_no,
								transport_charge = p_transport_charge,
								packing_charge = p_packing_charge,
								other_charge = p_other_charge,
								updated_date = now(),
								updated_by = p_emp_user_id,
								trade_discount = p_trade_discount
						where	purchase_id = p_purchase_id;
							
						set o_purchase_id = p_purchase_id;
	end if;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_purchase_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_purchase_details`(p_purchase_details_id bigint,
																		p_purchase_id bigint,
																		p_item_id bigint,
																		p_item_quantity bigint,
																		p_item_price decimal(19,2),
																		p_item_discount_in_per decimal(4,2),
																		p_is_igst int(1),
																		p_is_local_vendor int(1))
begin
	declare v_current_balance bigint;
	declare v_cgst_in_per decimal(4,2);
	declare v_sgst_in_per decimal(4,2);
	declare v_igst_in_per decimal(4,2);
    declare v_item_tax_in_per decimal(4,2);
	
	declare v_cgst_in_rs decimal(19,2);
	declare v_sgst_in_rs decimal(19,2);
	declare v_igst_in_rs decimal(19,2);
	
    declare v_item_value decimal(19,2);
    declare v_discount_value decimal(19,2);
    declare v_taxable_value decimal(19,2);
	declare v_total_value decimal(19,2);
	
    declare v_gst_id bigint;
    
    set v_item_value = p_item_quantity * p_item_price;
    set v_discount_value = v_item_value * p_item_discount_in_per / 100;
    set v_taxable_value = v_item_value - v_discount_value;
    
    select gst_id into v_gst_id
    from tbl_items where item_id = p_item_id;
    
	if p_is_local_vendor = 0 and v_gst_id is not null and v_gst_id > 0 then
    
		select cgst_in_per, sgst_in_per, igst_in_per into 
				v_cgst_in_per, v_sgst_in_per, v_igst_in_per
		from tbl_gst
        where gst_id = v_gst_id;
        
        if p_is_igst = 0 then
			set v_cgst_in_rs = v_taxable_value * v_cgst_in_per/100;
			set v_sgst_in_rs = v_taxable_value * v_sgst_in_per/100;
			set v_igst_in_rs = 0;
			set v_igst_in_per = 0;
            set v_item_tax_in_per = v_cgst_in_per + v_sgst_in_per;
		else 
			set v_igst_in_rs = v_taxable_value * v_igst_in_per/100;
			set v_cgst_in_rs = 0;
			set v_sgst_in_rs = 0;
			
			set v_cgst_in_per = 0;
			set v_sgst_in_per = 0;
            set v_item_tax_in_per = v_igst_in_per;
		end if;
		
	else 
		set v_cgst_in_per = 0;
		set v_sgst_in_per = 0;
		set v_igst_in_per = 0;
        
        set v_cgst_in_rs = 0;
		set v_sgst_in_rs = 0;
        set v_igst_in_rs = 0;
	end if;
	
    set v_total_value  = v_taxable_value + v_cgst_in_rs + v_sgst_in_rs + v_igst_in_rs;

	if p_purchase_details_id = 0 then

		select current_balance into v_current_balance
		from tbl_items where item_id = p_item_id;

		insert into tbl_purchase_details(
										purchase_id,
										item_id,
										item_quantity,
										item_price,
										item_amount,
										item_discount_in_per,
										item_discount_in_rs,
										cgst_in_per,
										sgst_in_per,
										igst_in_per,
										cgst_in_rs,
										sgst_in_rs,
										igst_in_rs,
										item_total_value)
								values(
										p_purchase_id,
										p_item_id,
										p_item_quantity,
										p_item_price,
										v_item_value,
										p_item_discount_in_per,
										v_discount_value,
										v_cgst_in_per,
										v_sgst_in_per,
										v_igst_in_per,
										v_cgst_in_rs,
										v_sgst_in_rs,
										v_igst_in_rs,
										v_total_value);

		#update tbl_items set item_purchase_price = p_item_price + ((p_item_price * v_item_tax_in_per) / 100) where item_id = p_item_id;
	else 
	
		update tbl_purchase_details set 
									item_quantity = p_item_quantity,
									item_price = p_item_price,
									item_amount = v_item_value,
									item_discount_in_per = p_item_discount_in_per,
									item_discount_in_rs = v_discount_value,
									cgst_in_per = v_cgst_in_per,
									sgst_in_per = v_sgst_in_per,
									igst_in_per = v_igst_in_per,
									cgst_in_rs = v_cgst_in_rs,
									sgst_in_rs = v_sgst_in_rs,
									igst_in_rs = v_igst_in_rs,
									item_total_value = v_total_value
							where purchase_details_id = p_purchase_details_id;
		
	end if;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_sales` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_sales`(p_sales_id bigint,
															p_client_id bigint,
															p_transport_charge decimal(19,2),
															p_packing_charge decimal(19,2),
															p_other_charge decimal(19,2),
															p_paid_cash decimal(19,2),
															p_payment_type_id int,
															p_upi_type_id int,
                                                            p_trans_no varchar(40),
                                                            p_customer_id bigint,
                                                            p_emp_user_id varchar(150),
															p_emp_device_id varchar(100),
															p_transaction_key varchar(100),
                                                            out o_sales_id bigint,
                                                            out o_validate_stock_on_invoice int(1),
                                                            out o_extra_discount_required int(1))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
	if p_sales_id = 0 then
		insert into PayBillApp.tbl_sales(client_id,
							sales_date,
							transport_charge,
							packing_charge,
							other_charge,
							paid_cash,
							payment_type_id,
							upi_type_id,
							trans_no,
							created_by,
                            customer_id)
					values(p_client_id,
							date(now()),
							p_transport_charge,
							p_packing_charge,
							p_other_charge,
							p_paid_cash,
							p_payment_type_id,
							p_upi_type_id,
							p_trans_no,
							p_emp_user_id,
                            p_customer_id);
										
				set o_sales_id = (select last_insert_id()); 
											
	else 
		update PayBillApp.tbl_sales set 
						transport_charge = p_transport_charge,
						packing_charge = p_packing_charge,
						other_charge = p_other_charge,
						paid_cash = p_paid_cash,
						payment_type_id = p_payment_type_id,
						upi_type_id = p_upi_type_id,
						trans_no = p_trans_no,
                        updated_date = now(),
						updated_by = p_emp_user_id
				where	sales_id = p_sales_id;
				
				set o_sales_id = p_sales_id;
	end if;
	select validate_stock_on_invoice,extra_discount_required into o_validate_stock_on_invoice,o_extra_discount_required
    from PayBillApp.tbl_clients where client_id = p_client_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_sales_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_sales_details`(p_sales_details_id bigint,
																	p_sales_id bigint,
																	p_item_id bigint,
																	p_item_quantity bigint,
																	p_is_sgst int(1),
                                                                    p_validate_stock_on_invoice int(1),
                                                                    p_special_discount_in_rs decimal(19,2),
                                                                    out o_return_value varchar(100))
leave_lable: begin

	declare v_item_price decimal(19,2);
	declare v_item_total decimal(19,2);
	declare v_item_discount_in_per decimal(4,2);
	declare v_item_discount_in_rs decimal(19,2);
	declare v_item_taxable_value decimal(19,2);
	declare v_cgst_in_per decimal(4,2);
	declare v_sgst_in_per decimal(4,2);
	declare v_igst_in_per decimal(4,2);
	declare v_cgst_in_rs decimal(19,2);
	declare v_sgst_in_rs decimal(19,2);
	declare v_igst_in_rs decimal(19,2);
	declare v_item_total_value_incl_gst decimal(19,2);
	declare v_item_discount_expiry_date date;
	declare v_item_saving_amount decimal(19,2);
	declare v_item_mrp_price decimal(19,2);
	declare v_item_purchase_price decimal(19,2);
    declare v_current_balance bigint;
	declare v_old_item_quantity bigint;
    
	set v_item_discount_in_per = 0;
	set v_item_discount_in_rs = 0;
	
	
	select item_discount_in_per,
		 item_discount_expiry_date,
		 ifnull(cgst_in_per,0),
		 ifnull(sgst_in_per,0),
		 ifnull(igst_in_per,0),
		 item_sales_price,
		 item_mrp_price,
		 item_purchase_price,
         current_balance into 
         v_item_discount_in_per, 
         v_item_discount_expiry_date, 
         v_cgst_in_per, 
         v_sgst_in_per, 
         v_igst_in_per, 
         v_item_price, 
         v_item_mrp_price, 
         v_item_purchase_price, 
         v_current_balance
	from PayBillApp.tbl_items itm
    left outer join PayBillApp.tbl_gst gst
    on itm.gst_id = gst.gst_id
	where itm.item_id = p_item_id;
	
	if datediff(v_item_discount_expiry_date, date(now())) < 0 then
		set v_item_discount_in_per = 0;
		set v_item_discount_in_rs = 0;
	end if;
	
	
	if p_is_sgst = 1 then
		set v_igst_in_per = 0;
	else
		set v_cgst_in_per = 0;
		set v_sgst_in_per = 0;
	end if;
	
	set v_item_total = p_item_quantity * v_item_price;
	
	if v_item_discount_in_per > 0 then
		set v_item_discount_in_rs = v_item_total * v_item_discount_in_per/100;
	end if;
	
	set v_item_taxable_value = v_item_total - v_item_discount_in_rs - p_special_discount_in_rs;
	
	set v_cgst_in_rs = v_item_taxable_value * v_cgst_in_per/100;
	set v_sgst_in_rs = v_item_taxable_value * v_sgst_in_per/100;
	set v_igst_in_rs = v_item_taxable_value * v_igst_in_per/100;
	
	if p_is_sgst = 1 then
		set v_igst_in_rs = 0;
	else
		set v_cgst_in_rs = 0;
		set v_sgst_in_rs = 0;
	end if;
	
	set v_item_total_value_incl_gst = v_item_taxable_value + v_cgst_in_rs + v_sgst_in_rs + v_igst_in_rs;
	
	set v_item_saving_amount = (v_item_mrp_price * p_item_quantity) - v_item_total_value_incl_gst;
	
	if v_item_saving_amount < 0 then
		set v_item_saving_amount = 0;
	end if;
	
	if p_sales_details_id = 0 then
    
		if p_validate_stock_on_invoice = 1 and v_current_balance < p_item_quantity then
			set o_return_value = 'Please check the highlighted item(s) stock and try again!';
			leave leave_lable;
        end if;
    
		insert into PayBillApp.tbl_sales_details(
								sales_id,
								item_id,
								item_quantity,
								item_price,
								item_total,
								item_discount_in_per,
								item_discount_in_rs,
                                special_discount_in_rs,
								item_taxable_value,
								cgst_in_per,
								sgst_in_per,
								igst_in_per,
								cgst_in_rs,
								sgst_in_rs,
								igst_in_rs,
								item_total_value_incl_gst,
								item_saving_amount,
								item_mrp_price,
								purchase_rate_incl_gst)
						values(
								p_sales_id,
								p_item_id,
								p_item_quantity,
								v_item_price,
								v_item_total,
								v_item_discount_in_per,
								v_item_discount_in_rs,
                                p_special_discount_in_rs,
								v_item_taxable_value,
								v_cgst_in_per,
								v_sgst_in_per,
								v_igst_in_per,
								v_cgst_in_rs,
								v_sgst_in_rs,
								v_igst_in_rs,
								v_item_total_value_incl_gst,
								v_item_saving_amount,
								v_item_mrp_price,
								v_item_purchase_price);
				set o_return_value = 'SUCCESS';
	else 
		select item_quantity into v_old_item_quantity
        from tbl_sales_details where sales_details_id = p_sales_details_id;
		
		if p_validate_stock_on_invoice = 1 and (v_current_balance + v_old_item_quantity) < p_item_quantity then
			set o_return_value = 'Please check the highlighted item(s) stock and try again!';
			leave leave_lable;
        end if;
        
		update PayBillApp.tbl_sales_details set 
							item_id = p_item_id,
							item_quantity = p_item_quantity,
							item_price = v_item_price,
							item_total = v_item_total,
							item_discount_in_per = v_item_discount_in_per,
							item_discount_in_rs = v_item_discount_in_rs,
                            special_discount_in_rs = p_special_discount_in_rs,
							item_taxable_value = v_item_taxable_value,
							cgst_in_per = v_cgst_in_per,
							sgst_in_per = v_sgst_in_per,
							igst_in_per = v_igst_in_per,
							cgst_in_rs = v_cgst_in_rs,
							sgst_in_rs = v_sgst_in_rs,
							igst_in_rs = v_igst_in_rs,
							item_total_value_incl_gst = v_item_total_value_incl_gst,
							item_saving_amount = v_item_saving_amount,
							purchase_rate_incl_gst = v_item_purchase_price
					where sales_details_id = p_sales_details_id;
			set o_return_value = 'SUCCESS';
	end if;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_sales_enquiry` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_sales_enquiry`(p_enquiry_name varchar(100),
																	p_enquiry_mobile varchar(10),
                                                                    p_enquiry_address varchar(100),
																	p_enquiry_remarks varchar(255),
                                                                    p_enquiry_otp varchar(6),
                                                                    out o_enquiry_is_validated int(1),
                                                                    out o_enquiry_id bigint,
                                                                    out o_otp_sms_api varchar(500),
                                                                    out o_enquiry_otp_template_id varchar(50))
BEGIN

	delete from PayBillApp.tbl_sales_enquiries where enquiry_mobile = p_enquiry_mobile and enquiry_is_validated = 0;

	if not exists(select enquiry_id from PayBillApp.tbl_sales_enquiries where enquiry_mobile = p_enquiry_mobile and enquiry_is_validated = 1 limit 1) then
		insert into PayBillApp.tbl_sales_enquiries(enquiry_date,enquiry_name,enquiry_mobile,enquiry_address,enquiry_remarks,enquiry_otp)
		values(now(),p_enquiry_name,p_enquiry_mobile,p_enquiry_address,p_enquiry_remarks,p_enquiry_otp);
		set o_enquiry_id = (select last_insert_id());
        #select last_insert_id() into o_enquiry_id;
        set o_enquiry_is_validated = 0;
        select otp_sms_api, enquiry_otp_template_id into o_otp_sms_api, o_enquiry_otp_template_id from PayBillApp.tbl_admin limit 1;
	else 
		select enquiry_id into o_enquiry_id
        from PayBillApp.tbl_sales_enquiries where enquiry_mobile = p_enquiry_mobile and enquiry_is_validated = 1 limit 1;
        update PayBillApp.tbl_sales_enquiries set enquiry_is_new = 1 where enquiry_id = o_enquiry_id;
        set o_enquiry_is_validated = 1;
    end if;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_sales_win` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_sales_win`(p_sales_id bigint,
															p_client_id bigint,
															p_transport_charge decimal(19,2),
															p_packing_charge decimal(19,2),
															p_other_charge decimal(19,2),
															p_paid_cash decimal(19,2),
															p_payment_type_id int,
															p_upi_type_id int,
                                                            p_trans_no varchar(40),
                                                            p_customer_id bigint,
                                                            p_emp_user_id varchar(150),
															p_win_qrcode_id int,
															p_win_system_unique_id varchar(250),
															p_win_qrcode_security_key varchar(500),
                                                            out o_sales_id bigint,
                                                            out o_validate_stock_on_invoice int(1),
                                                            out o_extra_discount_required int(1))
leave_lable: BEGIN

	if not exists(select win.win_qrcode_id 
					from PayBillApp.tbl_win_qrcodes win
                    inner join PayBillApp.tbl_users usr
                    on win.win_qrcode_id = usr.win_qrcode_id
					where usr.client_id = p_client_id and 
							emp_user_id = p_emp_user_id and 
                            win.win_qrcode_id = p_win_qrcode_id and
							win_system_unique_id = p_win_system_unique_id and
							win_qrcode_security_key = p_win_qrcode_security_key and 
							is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if; 
	
	if p_sales_id = 0 then
		insert into PayBillApp.tbl_sales(client_id,
							sales_date,
							transport_charge,
							packing_charge,
							other_charge,
							paid_cash,
							payment_type_id,
							upi_type_id,
							trans_no,
							created_by,
                            customer_id,
                            is_mobile_billing)
					values(p_client_id,
							date(now()),
							p_transport_charge,
							p_packing_charge,
							p_other_charge,
							p_paid_cash,
							p_payment_type_id,
							p_upi_type_id,
							p_trans_no,
							p_emp_user_id,
                            p_customer_id,0);
										
				set o_sales_id = (select last_insert_id()); 
											
	else 
		update PayBillApp.tbl_sales set 
						transport_charge = p_transport_charge,
						packing_charge = p_packing_charge,
						other_charge = p_other_charge,
						paid_cash = p_paid_cash,
						payment_type_id = p_payment_type_id,
						upi_type_id = p_upi_type_id,
						trans_no = p_trans_no,
                        updated_date = now(),
						updated_by = p_emp_user_id
				where	sales_id = p_sales_id;
				
				set o_sales_id = p_sales_id;
	end if;
	select validate_stock_on_invoice,extra_discount_required into o_validate_stock_on_invoice,o_extra_discount_required
    from PayBillApp.tbl_clients where client_id = p_client_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_successful_payment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_successful_payment`(p_client_id bigint,
																		p_emp_user_id varchar(150),
																		p_emp_device_id varchar(100),
																		p_transaction_key varchar(100),
                                                                        p_package_id int,
																		p_payment_trans_no varchar(100),
																		p_payment_status varchar(50),
																		p_payment_remarks varchar(500),
                                                                        p_payment_amount double,
                                                                        p_order_id varchar(25))
leave_lable: BEGIN
	declare v_package_no_users tinyint;
    declare v_payment_id bigint;
    declare v_subscription_end_date date;
    declare v_package_amount double;
    declare v_discount_end_date date;
    declare v_discount_in_rs double;
    
    declare exit handler for sqlexception
    begin
		get diagnostics condition 1
        @p1 = returned_sqlstate, @p2 = message_text;
		signal sqlstate '45000' set message_text = @p2;
		rollback;
        
        insert into PayBillApp.tbl_client_payments_failed(client_id,
															payment_trans_no,
															payment_amount,
															payment_status,
															payment_remarks,
															emp_user_id,
															package_id,
															order_id)
													values(p_client_id,
															p_payment_trans_no,
															p_payment_amount,
															p_payment_status,
															p_payment_remarks,
															p_emp_user_id,
															p_package_id,
															p_order_id);
        
       
    end;
    
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select package_amount into v_package_amount
    from PayBillApp.tbl_packages
    where package_id = p_package_id;
    
    select subscription_end_date,discount_in_rs,date(discount_end_date) into v_subscription_end_date,v_discount_in_rs,v_discount_end_date
    from PayBillApp.tbl_clients
    where client_id = p_client_id;
    
    if v_discount_end_date >= date(now()) then
		set v_package_amount = v_package_amount - v_discount_in_rs;
    end if;
    
    if p_payment_amount < v_package_amount then
		signal sqlstate '45000' set message_text = 'Not a valid package amount.';
        leave leave_lable;
    end if;

	start transaction;
    
    if v_subscription_end_date < date(now()) then
		set v_subscription_end_date = date_add(date(now()), interval 1 year) - 1;
	else
		set v_subscription_end_date = date_add(v_subscription_end_date, interval 1 year) - 1;
    end if;
    
	insert into PayBillApp.tbl_client_payments(client_id,
												payment_trans_no,
												payment_amount,
												payment_status,
												payment_remarks,
												emp_user_id,
												package_id,
												order_id)
										values(p_client_id,
												p_payment_trans_no,
												p_payment_amount,
												p_payment_status,
												p_payment_remarks,
												p_emp_user_id,
												p_package_id,
												p_order_id);
	select last_insert_id() into v_payment_id;
                                                            
	update PayBillApp.tbl_clients set package_id = p_package_id, 
										payment_id = v_payment_id,
                                        subscription_end_date = v_subscription_end_date,
                                        client_status_id = 1
	where client_id = p_client_id;
                                                            
                                                            
    commit;                                                      
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_successful_payment_manual` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_successful_payment_manual`(p_client_id bigint,
																				p_package_id int,
																				p_payment_trans_no varchar(100),
																				p_payment_status varchar(50),
																				p_payment_remarks varchar(500),
																				p_payment_amount double,
																				p_order_id varchar(25),
                                                                                p_emp_user_id varchar(150),
																				p_user_id varchar(50),
																				p_user_security_key varchar(100),
                                                                                out o_return_value varchar(20))
leave_lable: BEGIN
	declare v_package_no_users tinyint;
    declare v_payment_id bigint;
    declare v_subscription_end_date date;
    declare v_package_amount double;
    declare v_discount_end_date date;
    declare v_discount_in_rs double;
    
    declare exit handler for sqlexception
    begin
		get diagnostics condition 1
        @p1 = returned_sqlstate, @p2 = message_text;
		signal sqlstate '45000' set message_text = @p2;
		rollback;
	end;
    
    set o_return_value = 'FAILED';
    
    if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    if exists(select payment_id from PayBillApp.tbl_client_payments where payment_trans_no = p_payment_trans_no) then
		signal sqlstate '45000' set message_text = 'Warning: Payment transaction was already processed.';
        leave leave_lable;
    end if;
    
    select package_amount into v_package_amount
    from PayBillApp.tbl_packages
    where package_id = p_package_id;
    
    select subscription_end_date,discount_in_rs,date(discount_end_date) into v_subscription_end_date,v_discount_in_rs,v_discount_end_date
    from PayBillApp.tbl_clients
    where client_id = p_client_id;
    
    if v_discount_end_date >= date(now()) then
		set v_package_amount = v_package_amount - v_discount_in_rs;
    end if;
    
    if p_payment_amount < v_package_amount then
		signal sqlstate '45000' set message_text = 'Not a valid package amount.';
        leave leave_lable;
    end if;

	start transaction;
    
    if v_subscription_end_date < date(now()) then
		set v_subscription_end_date = date_add(date(now()), interval 1 year) - 1;
	else
		set v_subscription_end_date = date_add(v_subscription_end_date, interval 1 year) - 1;
    end if;
    
	insert into PayBillApp.tbl_client_payments(client_id,
												payment_trans_no,
												payment_amount,
												payment_status,
												payment_remarks,
												emp_user_id,
												package_id,
												order_id,
                                                is_auto_insert)
										values(p_client_id,
												p_payment_trans_no,
												p_payment_amount,
												p_payment_status,
												p_payment_remarks,
												p_emp_user_id,
												p_package_id,
												p_order_id,0);
	select last_insert_id() into v_payment_id;
                                                            
	update PayBillApp.tbl_clients set package_id = p_package_id, 
										payment_id = v_payment_id,
                                        subscription_end_date = v_subscription_end_date,
                                        client_status_id = 1
	where client_id = p_client_id;
                                                            
    set o_return_value = 'SUCCESS';                                                          
    commit;                                                      
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_successful_payment_service` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_successful_payment_service`(p_client_id bigint,
																				p_package_id int,
																				p_payment_trans_no varchar(100),
																				p_payment_status varchar(50),
																				p_payment_remarks varchar(500),
																				p_payment_amount double,
																				p_order_id varchar(25),
                                                                                p_emp_user_id varchar(150),
																				p_user_id varchar(50),
																				p_user_security_key varchar(100),
                                                                                out o_return_value varchar(20))
leave_lable: BEGIN
	declare v_package_no_users tinyint;
    declare v_payment_id bigint;
    declare v_subscription_end_date date;
    declare v_package_amount double;
    declare v_discount_end_date date;
    declare v_discount_in_rs double;
    
    declare exit handler for sqlexception
    begin
		get diagnostics condition 1
        @p1 = returned_sqlstate, @p2 = message_text;
		signal sqlstate '45000' set message_text = @p2;
		rollback;
	end;
    
    set o_return_value = 'FAILED';
    
    if p_user_id != 'service' || p_user_security_key != 'auto_payment_recovery_service' then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    if exists(select payment_id from PayBillApp.tbl_client_payments where payment_trans_no = p_payment_trans_no) then
		signal sqlstate '45000' set message_text = 'Warning: Payment transaction was already processed.';
        leave leave_lable;
    end if;
    
    select package_amount into v_package_amount
    from PayBillApp.tbl_packages
    where package_id = p_package_id;
    
    select subscription_end_date,discount_in_rs,date(discount_end_date) into v_subscription_end_date,v_discount_in_rs,v_discount_end_date
    from PayBillApp.tbl_clients
    where client_id = p_client_id;
    
    if v_discount_end_date >= date(now()) then
		set v_package_amount = v_package_amount - v_discount_in_rs;
    end if;
    
    if p_payment_amount < v_package_amount then
		signal sqlstate '45000' set message_text = 'Not a valid package amount.';
        leave leave_lable;
    end if;

	start transaction;
    
    if v_subscription_end_date < date(now()) then
		set v_subscription_end_date = date_add(date(now()), interval 1 year) - 1;
	else
		set v_subscription_end_date = date_add(v_subscription_end_date, interval 1 year) - 1;
    end if;
    
	insert into PayBillApp.tbl_client_payments(client_id,
												payment_trans_no,
												payment_amount,
												payment_status,
												payment_remarks,
												emp_user_id,
												package_id,
												order_id,
                                                is_auto_insert)
										values(p_client_id,
												p_payment_trans_no,
												p_payment_amount,
												p_payment_status,
												p_payment_remarks,
												p_emp_user_id,
												p_package_id,
												p_order_id,0);
	select last_insert_id() into v_payment_id;
                                                            
	update PayBillApp.tbl_clients set package_id = p_package_id, 
										payment_id = v_payment_id,
                                        subscription_end_date = v_subscription_end_date,
                                        client_status_id = 1
	where client_id = p_client_id;
                                                            
    set o_return_value = 'SUCCESS';                                                        
    commit;                                                      
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_supplier` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_supplier`(p_client_id bigint,
																p_supplier_id bigint,
																p_supplier_name varchar(100),
																p_supplier_address varchar(500),
																p_supplier_mobile varchar(10),
																p_supplier_phone varchar(50),
																p_supplier_email varchar(150),
                                                                p_gstin varchar(20),
                                                                p_is_non_gst_vendor int(1),
																p_is_active int(1),
																p_emp_user_id varchar(150),
																p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	if p_supplier_id = 0 then
		insert into tbl_suppliers(client_id,
								supplier_name,
								supplier_address,
								supplier_mobile,
								supplier_phone,
								supplier_email,
								is_active,
								gstin,
								is_non_gst_vendor,
                                created_by)
						values(p_client_id,
								p_supplier_name,
								p_supplier_address,
								p_supplier_mobile,
								p_supplier_phone,
								p_supplier_email,
								p_is_active,
								p_gstin,
								p_is_non_gst_vendor,
                                p_emp_user_id);
	else
		update tbl_suppliers set 
							supplier_name = p_supplier_name,
							supplier_address = p_supplier_address,
							supplier_mobile = p_supplier_mobile,
							supplier_phone = p_supplier_phone,
							supplier_email = p_supplier_email,
							gstin = p_gstin,
							is_non_gst_vendor = p_is_non_gst_vendor,
                            is_active = p_is_active,
							updated_date = now(),
							updated_by = p_emp_user_id
		where p_client_id = client_id and supplier_id = p_supplier_id;
					
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_support_request` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_support_request`(p_client_id bigint,
																		p_emp_user_id varchar(150),
																		p_emp_device_id varchar(100),
																		p_transaction_key varchar(100),
                                                                        p_support_request_remarks varchar(500),
                                                                        out o_fcm_server_api_key varchar(500),
																		out o_fcm_server_sender_id varchar(100))
leave_lable: BEGIN
	declare v_support_request_id bigint;
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	select fcm_server_api_key,fcm_server_sender_id into o_fcm_server_api_key,o_fcm_server_sender_id from PayBillApp.tbl_admin limit 1; 
    
	insert into PayBillApp.tbl_support_requests(emp_user_id,support_request_remarks,support_status_id,client_id)
    values(p_emp_user_id,p_support_request_remarks,1,p_client_id);
    
    set v_support_request_id = (select last_insert_id());
    
    select support_request_id,
			client_name,
            client_address,
            contact_mobile1,
			support_request_remarks
	from PayBillApp.tbl_support_requests req 
    inner join PayBillApp.tbl_clients clt
    on req.client_id = clt.client_id
    where support_request_id = v_support_request_id;
	
	select firebase_token from PayBillApp.tbl_cp_users where length(firebase_token) > 5 and user_is_active = 1;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_upd_cp_user` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_upd_cp_user`(p_is_new int(1),
																p_new_user_id varchar(50),
																p_user_first_name varchar(50),
																p_user_last_name varchar(50),
                                                                P_user_address varchar(500),
                                                                p_user_mobile varchar(10),
                                                                p_user_email varchar(150),
																p_device_app_id varchar(250),
                                                                p_is_control_panel_access int(1),
                                                                p_user_is_active int(1),
                                        						p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	declare v_user_password varchar(250);
    
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	if p_is_new = 1 then
		if exists(select user_id from PayBillApp.tbl_cp_users where user_id = p_new_user_id) then
			signal sqlstate '45000' set message_text = 'User ID is already assigned to another user.';
			leave leave_lable;
		end if;
        
        select emp_default_password into v_user_password
        from PayBillApp.tbl_admin limit 1;
        
        insert into PayBillApp.tbl_cp_users(user_id,
												user_first_name,
                                                user_last_name,
                                                user_address,
                                                user_mobile,
                                                user_email,
                                                user_password,
                                                device_app_id,
                                                is_new_password,
                                                is_control_panel_access,
                                                user_is_active)
										values(p_new_user_id,
												p_user_first_name,
                                                p_user_last_name,
                                                p_user_address,
                                                p_user_mobile,
                                                p_user_email,
                                                v_user_password,
                                                p_device_app_id,1,
                                                p_is_control_panel_access,
                                                p_user_is_active);
                                                
    else 
		update PayBillApp.tbl_cp_users set user_first_name = p_user_first_name,
											user_last_name = p_user_last_name,
                                            user_address = p_user_address,
                                            user_email = p_user_email,
                                            user_is_active = p_user_is_active,
                                            user_mobile = p_user_mobile,
                                            device_app_id = p_device_app_id,
                                            is_control_panel_access = p_is_control_panel_access
        where user_id = p_new_user_id;
    end if;
    
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_ins_win_qrcode` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ins_win_qrcode`(p_win_system_unique_id varchar(250),
																	p_win_qrcode_value varchar(500),
																	p_win_qrcode_security_key varchar(500),
																	p_win_system_ip_address varchar(20),
																	out o_win_qrcode_id bigint)
BEGIN
	declare v_win_qrcode_id int;
    select win_qrcode_id into v_win_qrcode_id from PayBillApp.tbl_win_qrcodes where win_system_unique_id = p_win_system_unique_id;
    if v_win_qrcode_id is null then
		insert into PayBillApp.tbl_win_qrcodes(win_qrcode_value,
												win_qrcode_security_key,
                                                win_system_ip_address,
                                                win_system_unique_id)
										values(p_win_qrcode_value,
												p_win_qrcode_security_key,
                                                p_win_system_ip_address,
                                                p_win_system_unique_id);
						set o_win_qrcode_id = last_insert_id();
	else 
		update PayBillApp.tbl_users set win_qrcode_id = null where win_qrcode_id = v_win_qrcode_id;
		update PayBillApp.tbl_win_qrcodes set win_qrcode_value = p_win_qrcode_value,
												win_qrcode_security_key = p_win_qrcode_security_key,
                                                win_system_ip_address = p_win_system_ip_address,
                                                win_qrcode_created_date = now()
										where win_qrcode_id = v_win_qrcode_id;
                                        set o_win_qrcode_id = v_win_qrcode_id;
    end if;
    
    #remove below code
    update PayBillApp.tbl_users set win_qrcode_id = o_win_qrcode_id, win_qrcode_date = now() 
	where emp_user_id = 'ravi';
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_lock_sales_invoice` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_lock_sales_invoice`(p_sales_id bigint)
BEGIN
	update PayBillApp.tbl_sales set is_locked = 1 where sales_id = p_sales_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_reset_barcode_page_settings` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_reset_barcode_page_settings`(p_parameter_value int)
begin
	if p_parameter_value = 0
	then
		update tbl_barcode_page_settings set 	
							`smt_barcode_page_columns` = default,
							`smt_barcode_body_width` = default,
							`smt_barcode_body_height` = default,
							`smt_barcode_item_top` = default,
							`smt_barcode_item_left` = default,
							`smt_barcode_item_height` = default,
							`smt_barcode_item_width` = default,
							`smt_barcode_image1_top` = default,
							`smt_barcode_image1_left` = default,
							`smt_barcode_image1_height` = default,
							`smt_barcode_image1_width` = default,
							`smt_barcode_itemcode_top` = default,
							`smt_barcode_itemcode_left` = default,
							`smt_barcode_itemcode_height` = default,
							`smt_barcode_itemcode_width` = default,
							`smt_barcode_mrp_top` = default,
							`smt_barcode_mrp_left` = default,
							`smt_barcode_mrp_height` = default,
							`smt_barcode_mrp_width` = default,
							`smt_barcode_price_top` = default,
							`smt_barcode_price_left` = default,
							`smt_barcode_price_height` = default,
							`smt_barcode_price_width` = default,
							`smt_barcode_companyname_top` = default,
							`smt_barcode_companyname_left` = default,
							`smt_barcode_companyname_height` = default,
							`smt_barcode_companyname_width` = default,
							`smt_barcode_packeddate_top` = default,
							`smt_barcode_packeddate_left` = default,
							`smt_barcode_packeddate_height` = default,
							`smt_barcode_packeddate_width` = default;
		else
			update tbl_barcode_page_settings set 
					`smt_qrcode_page_columns` = default,
					`smt_qrcode_body_width` = default,
					`smt_qrcode_body_height` = default,
					`smt_qrcode_item_top` = default,
					`smt_qrcode_item_left` = default,
					`smt_qrcode_item_height` = default,
					`smt_qrcode_item_width` = default,
					`smt_qrcode_image1_top` = default,
					`smt_qrcode_image1_left` = default,
					`smt_qrcode_image1_height` = default,
					`smt_qrcode_image1_width` = default,
					`smt_qrcode_itemcode_top` = default,
					`smt_qrcode_itemcode_left` = default,
					`smt_qrcode_itemcode_height` = default,
					`smt_qrcode_itemcode_width` = default,
					`smt_qrcode_mrp_top` = default,
					`smt_qrcode_mrp_left` = default,
					`smt_qrcode_mrp_height` = default,
					`smt_qrcode_mrp_width` = default,
					`smt_qrcode_price_top` = default,
					`smt_qrcode_price_left` = default,
					`smt_qrcode_price_height` = default,
					`smt_qrcode_price_width` = default,
					`smt_qrcode_companyname_top` = default,
					`smt_qrcode_companyname_left` = default,
					`smt_qrcode_companyname_height` = default,
					`smt_qrcode_companyname_width` = default,
					`smt_qrcode_packeddate_top` = default,
					`smt_qrcode_packeddate_left` = default,
					`smt_qrcode_packeddate_height` = default,
					`smt_qrcode_packeddate_width` = default;
		end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_sales_last_invoice` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_sales_last_invoice`(p_created_by bigint,
										out p_o_return_value int(1) unsigned)
begin
	declare v_sales_id bigint;
    
	if exists(select `emp_id` from tbl_employee where `emp_id` = p_created_by and `is_last_invoice_access` = 1)
	then
	
		
	
		
		select max(`sales_id`) into v_sales_id 
		from tbl_sales
		where `created_by` = p_created_by;
		set p_o_return_value = 1;
		
		if v_sales_id is not null
		then
		
			
			select `sales_id`,
					`customer_id`,
					`sales_date`,
					`transport_charge`,
					`packing_charge`,
					`other_charge`,
					`paid_amount`,
					`payment_type`,
					`card_no`
			from tbl_sales
			where `sales_id` = v_sales_id;
			
			
			select `sales_details_id`,
					slsi.item_id,
					`item_name`,
					`item_barcode`,
					`item_quantity` as quantity,
					`item_price` as rate,
					`item_total`,
					slsi.item_discount_in_per as discount_in_per,
					slsi.item_discount_in_rs as discount_in_rs,
					`item_taxable_value`,
					(slsi.cgst_in_per + slsi.sgst_in_per + slsi.igst_in_per) as gst_in_per,
					(`cgst_in_rs` + `sgst_in_rs` + `igst_in_rs`) as gst_in_rs,
					`item_total_value_incl_gst`,
					'edit' as edit,
					'remove' as remove
			from tbl_sales_details slsi
			inner join tbl_items itm
			on slsi.item_id = itm.item_id
			where `sales_id` = v_sales_id;
			
			set p_o_return_value = 1;
		
		else 
			set p_o_return_value = 2;
			
			select 0;
		end if;
	else 
		set p_o_return_value = 0;
		
		select 0;
	end if;
	
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_sales_optimization` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_sales_optimization`(p_client_id bigint,
                                                                    p_to_date date,
																	p_emp_user_id varchar(150),
																	p_user_security_key varchar(100))
leave_lable: BEGIN
	declare v_validate_stock_on_invoice int(1);
    
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		ROLLBACK;
        signal sqlstate '45000' set message_text = 'Optimization could not be processed. Please try again!';
    END;
    
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select validate_stock_on_invoice into v_validate_stock_on_invoice
    from PayBillApp.tbl_clients where client_id = p_client_id;

	if v_validate_stock_on_invoice = 1 then
		signal sqlstate '45000' set message_text = 'You cannot perform optimization when stock verification on sales is activated.';
        leave leave_lable;
    end if;

	start transaction;
	delete from PayBillApp.tbl_sales_details
	where client_id = p_client_id and sales_id in (select sales_id from tbl_sales where sales_date < p_to_date);

	delete from PayBillApp.tbl_sales where client_id = p_client_id and sales_date < p_to_date;
    
    update PayBillApp.tbl_clients set is_optimization_processed = 1 where client_id = p_client_id;
    
	commit ;
	
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_search` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_search`(p_client_id bigint,
																p_param varchar(50))
BEGIN
	select item_id,
			item_name,
            item_barcode,
            item_mrp_price,
            (case when itm.gst_id is null then item_sales_price 
            else round(item_sales_price + (item_sales_price * (cgst_in_per + sgst_in_per)/100),0) end) as item_sales_price,
            current_balance
    from PayBillApp.tbl_items itm
    left outer join PayBillApp.tbl_gst gst
    on itm.gst_id = gst.gst_id
    where itm.client_id = p_client_id and 
			itm.is_active = 1 and
			(item_barcode like concat('%',p_param,'%') or 
            item_name like concat('%',p_param,'%') or 
            item_alias_name like concat('%',p_param,'%'))
	order by item_name,item_mrp_price;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_search_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_search_items`(p_client_id bigint,
																p_param varchar(50))
BEGIN
	select item_id,
			item_name,
			concat(item_barcode,', ',item_name,', MRP.', cast(item_mrp_price as char)) as item_desc
    from tbl_items
    where client_id = p_client_id and 
			is_active = 1 and
			(item_barcode like concat('%',p_param,'%') or 
            item_name like concat('%',p_param,'%') or 
            item_alias_name like concat('%',p_param,'%'))
	order by item_name,item_mrp_price;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_set_manage_password` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_set_manage_password`(
									p_sales_manage_password varchar(50),
									p_purchase_manage_password varchar(50),
									p_others_manage_password varchar(50),
									p_reset_manage_password varchar(50))
begin
	if length(p_sales_manage_password) > 0 then
		update tbl_company_info set `sales_manage_password` = p_sales_manage_password;
	end if;
		
	if length(p_purchase_manage_password) > 0 then
		update tbl_company_info set `purchase_manage_password` = p_purchase_manage_password;
	end if;
		
	if length(p_others_manage_password) > 0 then
		update tbl_company_info set `others_manage_password` = p_others_manage_password;
	end if;
		
	if length(p_reset_manage_password) > 0 then
		update tbl_company_info set `reset_manage_password` = p_reset_manage_password;
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_suspend_client` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_suspend_client`(p_client_id bigint,
																p_user_id varchar(50),
                                                                p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	update PayBillApp.tbl_clients set client_status_id = 3 where client_id = p_client_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_unlock_sales_invoice` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_unlock_sales_invoice`(p_client_id bigint,
																		p_emp_user_id varchar(150),
																		p_emp_device_id varchar(100),
																		p_transaction_key varchar(100),
																		p_sales_id bigint)
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    update PayBillApp.tbl_sales set is_locked = 0 where sales_id = p_sales_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_update_app_password` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_update_app_password`(p_client_id bigint,
																		p_emp_user_id varchar(150),
																		p_emp_device_id varchar(100),
																		p_emp_pwd varchar(100),
																		p_old_emp_pwd varchar(100),
																		p_old_emp_salt varchar(60),
                                                                        p_new_emp_salt varchar(60),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    emp_pwd = p_old_emp_pwd and
                                    emp_salt = p_old_emp_salt and
                                    is_active = 1) then
		update  PayBillApp.tbl_users  set emp_pwd = p_emp_pwd, emp_salt = p_new_emp_salt, is_password_changed = 1
		where client_id = p_client_id and emp_user_id = p_emp_user_id;
	else 
		signal sqlstate '45000' set message_text = 'Password could not be changed. Please check the old password and try again!';
        leave leave_lable;
    end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_update_balance` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_update_balance`(p_item_id bigint, p_quantity bigint)
begin
	update tbl_items set `current_balance` = `current_balance` + 0 where `item_id` = p_item_id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_update_barcode_page_settings` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_update_barcode_page_settings`( p_smt_barcode_page_columns int,
												  p_smt_barcode_body_width decimal(19,5),
												  p_smt_barcode_body_height decimal(19,5),
												  p_smt_barcode_item_top decimal(19,5),
												  p_smt_barcode_item_left decimal(19,5),
												  p_smt_barcode_item_height decimal(19,5),
												  p_smt_barcode_item_width decimal(19,5),
												  p_smt_barcode_image1_top decimal(19,5),
												  p_smt_barcode_image1_left decimal(19,5),
												  p_smt_barcode_image1_height decimal(19,5),
												  p_smt_barcode_image1_width decimal(19,5),
												  p_smt_barcode_itemcode_top decimal(19,5),
												  p_smt_barcode_itemcode_left decimal(19,5),
												  p_smt_barcode_itemcode_height decimal(19,5),
												  p_smt_barcode_itemcode_width decimal(19,5),
												  p_smt_barcode_mrp_top decimal(19,5),
												  p_smt_barcode_mrp_left decimal(19,5),
												  p_smt_barcode_mrp_height decimal(19,5),
												  p_smt_barcode_mrp_width decimal(19,5),
												  p_smt_barcode_price_top decimal(19,5),
												  p_smt_barcode_price_left decimal(19,5),
												  p_smt_barcode_price_height decimal(19,5),
												  p_smt_barcode_price_width decimal(19,5),
												  p_smt_barcode_companyname_top decimal(19,5),
												  p_smt_barcode_companyname_left decimal(19,5),
												  p_smt_barcode_companyname_height decimal(19,5),
												  p_smt_barcode_companyname_width decimal(19,5),
												  p_smt_barcode_packeddate_top decimal(19,5),
												  p_smt_barcode_packeddate_left decimal(19,5),
												  p_smt_barcode_packeddate_height decimal(19,5),
												  p_smt_barcode_packeddate_width decimal(19,5))
begin
	update tbl_barcode_page_settings set 	
				  `smt_barcode_page_columns` = p_smt_barcode_page_columns,
				  `smt_barcode_body_width` = p_smt_barcode_body_width,
				  `smt_barcode_body_height` = p_smt_barcode_body_height,
				  `smt_barcode_item_top` = p_smt_barcode_item_top,
				  `smt_barcode_item_left` = p_smt_barcode_item_left,
				  `smt_barcode_item_height` = p_smt_barcode_item_height,
				  `smt_barcode_item_width` = p_smt_barcode_item_width,
				  `smt_barcode_image1_top` = p_smt_barcode_image1_top,
				  `smt_barcode_image1_left` = p_smt_barcode_image1_left,
				  `smt_barcode_image1_height` = p_smt_barcode_image1_height,
				  `smt_barcode_image1_width` = p_smt_barcode_image1_width,
				  `smt_barcode_itemcode_top` = p_smt_barcode_itemcode_top,
				  `smt_barcode_itemcode_left` = p_smt_barcode_itemcode_left,
				  `smt_barcode_itemcode_height` = p_smt_barcode_itemcode_height,
				  `smt_barcode_itemcode_width` = p_smt_barcode_itemcode_width,
				  `smt_barcode_mrp_top` = p_smt_barcode_mrp_top,
				  `smt_barcode_mrp_left` = p_smt_barcode_mrp_left,
				  `smt_barcode_mrp_height` = p_smt_barcode_mrp_height,
				  `smt_barcode_mrp_width` = p_smt_barcode_mrp_width,
				  `smt_barcode_price_top` = p_smt_barcode_price_top,
				  `smt_barcode_price_left` = p_smt_barcode_price_left,
				  `smt_barcode_price_height` = p_smt_barcode_price_height,
				  `smt_barcode_price_width` = p_smt_barcode_price_width,
				  `smt_barcode_companyname_top` = p_smt_barcode_companyname_top,
				  `smt_barcode_companyname_left` = p_smt_barcode_companyname_left,
				  `smt_barcode_companyname_height` = p_smt_barcode_companyname_height,
				  `smt_barcode_companyname_width` = p_smt_barcode_companyname_width,
				  `smt_barcode_packeddate_top` = p_smt_barcode_packeddate_top,
				  `smt_barcode_packeddate_left` = p_smt_barcode_packeddate_left,
				  `smt_barcode_packeddate_height` = p_smt_barcode_packeddate_height,
				  `smt_barcode_packeddate_width` = p_smt_barcode_packeddate_width;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_update_login_key` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_update_login_key`(p_client_id bigint,
																	p_login_key_unique_id varchar(255),
																	p_emp_user_id varchar(150),
																	p_emp_device_id varchar(100),
																	p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	update PayBillApp.tbl_users set login_key_unique_id = p_login_key_unique_id where client_id = p_client_id and emp_user_id = p_emp_user_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_update_password` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_update_password`(p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_emp_pwd varchar(100),
																	p_old_emp_pwd varchar(100),
                                                                    p_emp_old_salt varchar(100),
                                                                    p_emp_new_salt varchar(100),
																	p_user_security_key varchar(100))
BEGIN

	if exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    emp_pwd = p_old_emp_pwd and
                                    emp_salt = p_emp_old_salt and
                                    is_active = 1) then
		update  PayBillApp.tbl_users  set emp_pwd = p_emp_pwd, emp_salt = p_emp_new_salt, is_password_changed = 1
		where client_id = p_client_id and emp_user_id = p_emp_user_id;
	else 
		signal sqlstate '45000' set message_text = 'Password could not be changed. Please check the old password and try again!';
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_update_qrcode_page_settings` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_update_qrcode_page_settings`( p_smt_barcode_page_columns int,
												  p_smt_barcode_body_width decimal(19,5),
												  p_smt_barcode_body_height decimal(19,5),
												  p_smt_barcode_item_top decimal(19,5),
												  p_smt_barcode_item_left decimal(19,5),
												  p_smt_barcode_item_height decimal(19,5),
												  p_smt_barcode_item_width decimal(19,5),
												  p_smt_barcode_image1_top decimal(19,5),
												  p_smt_barcode_image1_left decimal(19,5),
												  p_smt_barcode_image1_height decimal(19,5),
												  p_smt_barcode_image1_width decimal(19,5),
												  p_smt_barcode_itemcode_top decimal(19,5),
												  p_smt_barcode_itemcode_left decimal(19,5),
												  p_smt_barcode_itemcode_height decimal(19,5),
												  p_smt_barcode_itemcode_width decimal(19,5),
												  p_smt_barcode_mrp_top decimal(19,5),
												  p_smt_barcode_mrp_left decimal(19,5),
												  p_smt_barcode_mrp_height decimal(19,5),
												  p_smt_barcode_mrp_width decimal(19,5),
												  p_smt_barcode_price_top decimal(19,5),
												  p_smt_barcode_price_left decimal(19,5),
												  p_smt_barcode_price_height decimal(19,5),
												  p_smt_barcode_price_width decimal(19,5),
												  p_smt_barcode_companyname_top decimal(19,5),
												  p_smt_barcode_companyname_left decimal(19,5),
												  p_smt_barcode_companyname_height decimal(19,5),
												  p_smt_barcode_companyname_width decimal(19,5),
												  p_smt_barcode_packeddate_top decimal(19,5),
												  p_smt_barcode_packeddate_left decimal(19,5),
												  p_smt_barcode_packeddate_height decimal(19,5),
												  p_smt_barcode_packeddate_width decimal(19,5))
begin
	update tbl_barcode_page_settings set 	
				  `smt_qrcode_page_columns` = p_smt_barcode_page_columns,
				  `smt_qrcode_body_width` = p_smt_barcode_body_width,
				  `smt_qrcode_body_height` = p_smt_barcode_body_height,
				  `smt_qrcode_item_top` = p_smt_barcode_item_top,
				  `smt_qrcode_item_left` = p_smt_barcode_item_left,
				  `smt_qrcode_item_height` = p_smt_barcode_item_height,
				  `smt_qrcode_item_width` = p_smt_barcode_item_width,
				  `smt_qrcode_image1_top` = p_smt_barcode_image1_top,
				  `smt_qrcode_image1_left` = p_smt_barcode_image1_left,
				  `smt_qrcode_image1_height` = p_smt_barcode_image1_height,
				  `smt_qrcode_image1_width` = p_smt_barcode_image1_width,
				  `smt_qrcode_itemcode_top` = p_smt_barcode_itemcode_top,
				  `smt_qrcode_itemcode_left` = p_smt_barcode_itemcode_left,
				  `smt_qrcode_itemcode_height` = p_smt_barcode_itemcode_height,
				  `smt_qrcode_itemcode_width` = p_smt_barcode_itemcode_width,
				  `smt_qrcode_mrp_top` = p_smt_barcode_mrp_top,
				  `smt_qrcode_mrp_left` = p_smt_barcode_mrp_left,
				  `smt_qrcode_mrp_height` = p_smt_barcode_mrp_height,
				  `smt_qrcode_mrp_width` = p_smt_barcode_mrp_width,
				  `smt_qrcode_price_top` = p_smt_barcode_price_top,
				  `smt_qrcode_price_left` = p_smt_barcode_price_left,
				  `smt_qrcode_price_height` = p_smt_barcode_price_height,
				  `smt_qrcode_price_width` = p_smt_barcode_price_width,
				  `smt_qrcode_companyname_top` = p_smt_barcode_companyname_top,
				  `smt_qrcode_companyname_left` = p_smt_barcode_companyname_left,
				  `smt_qrcode_companyname_height` = p_smt_barcode_companyname_height,
				  `smt_qrcode_companyname_width` = p_smt_barcode_companyname_width,
				  `smt_qrcode_packeddate_top` = p_smt_barcode_packeddate_top,
				  `smt_qrcode_packeddate_left` = p_smt_barcode_packeddate_left,
				  `smt_qrcode_packeddate_height` = p_smt_barcode_packeddate_height,
				  `smt_qrcode_packeddate_width` = p_smt_barcode_packeddate_width;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_update_rdlc` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_update_rdlc`(p_sales_invoice_rdlc_name varchar(100),p_sales_invoice_extra_rdlc_name varchar(100))
begin
	update tbl_company_info set `sales_invoice_rdlc_name` = p_sales_invoice_rdlc_name, `sales_invoice_extra_rdlc_name` = p_sales_invoice_extra_rdlc_name;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_update_support_request` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_update_support_request`(p_support_request_id bigint,
																		p_support_status_id int(1),
																		p_support_response_remarks varchar(500),
																		p_user_id varchar(50),
																		p_device_app_id varchar(250),
																		p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									device_app_id = p_device_app_id and 
                                    user_is_active = 1 and 
                                    transaction_key = p_transaction_key) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
	update PayBillApp.tbl_support_requests set 
												support_status_id = p_support_status_id,
                                                support_response_remarks = p_support_response_remarks,
                                                support_response_date = now()
										where support_request_id = p_support_request_id;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_admin_preferences` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_admin_preferences`(p_service_name varchar(100),
																		p_emp_default_password varchar(250),
                                                                        p_fcm_server_api_key varchar(500),
                                                                        p_fcm_server_sender_id varchar(100),
                                                                        p_otp_sms_api varchar(500),
                                                                        p_enquiry_otp_template_id varchar(50),
                                                                        p_reset_otp_template_id varchar(50),
																		p_apk_version_code int,
                                                                        p_is_apk_upgrade_mandatory int(1),
                                                                        p_offline_apk_download_required int(1),
                                                                        p_payment_gateway_merchant_key varchar(250),
                                                                        p_payment_gateway_merchant_secret_key varchar(250),
                                                                        p_email_sales_user_id varchar(500),
                                                                        p_email_support_user_id varchar(500),
                                                                        p_email_password varchar(500),
                                                                        p_email_smtp_host varchar(50),
                                                                        p_email_port int,
                                                                        p_email_ssl_enabled int(1),
                                                                        p_user_id varchar(50),
																		p_user_security_key varchar(100))
leave_lable: BEGIN
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	if exists(select service_name from PayBillApp.tbl_admin) then
		update PayBillApp.tbl_admin set 
										service_name = p_service_name, 
                                        fcm_server_api_key = p_fcm_server_api_key,
                                        fcm_server_sender_id = p_fcm_server_sender_id,
                                        otp_sms_api = p_otp_sms_api,
                                        enquiry_otp_template_id = p_enquiry_otp_template_id,
                                        reset_otp_template_id = p_reset_otp_template_id,
                                        apk_version_code = p_apk_version_code,
                                        is_apk_upgrade_mandatory = p_is_apk_upgrade_mandatory,
                                        offline_apk_download_required = p_offline_apk_download_required,
                                        payment_gateway_merchant_key = p_payment_gateway_merchant_key,
                                        payment_gateway_merchant_secret_key = p_payment_gateway_merchant_secret_key,
                                        email_sales_user_id = p_email_sales_user_id,
										email_support_user_id = p_email_support_user_id,
										email_password = p_email_password,
										email_smtp_host = p_email_smtp_host,
										email_port = p_email_port,
										email_ssl_enabled = p_email_ssl_enabled;
                                        
		if length(p_emp_default_password) > 0 then
			update PayBillApp.tbl_admin set emp_default_password = p_emp_default_password;
		end if;
    else 
		insert into PayBillApp.tbl_admin(service_name,emp_default_password,fcm_server_api_key,fcm_server_sender_id,otp_sms_api,enquiry_otp_template_id,reset_otp_template_id)
        values(p_service_name,p_emp_default_password,p_fcm_server_api_key,p_fcm_server_sender_id,p_otp_sms_api,p_enquiry_otp_template_id,p_reset_otp_template_id);
    end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_barcode_settings` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_barcode_settings`(p_barcode_is_show_company_name int(1),
											p_barcode_is_show_packed_date int(1),
											p_barcode_is_show_serial_no int(1),
											p_barcode_is_show_mrp int(1),
											p_barcode_is_show_price int(1),
											p_barcode_company_short_name varchar(20),
											p_barcode_height int,
											p_barcode_lable_height int,
											p_barcode_lable_width int,
											p_barcode_no_of_columns int,
											p_barcode_no_of_copies int)
begin
	update tbl_company_info set 
									`barcode_is_show_company_name` = p_barcode_is_show_company_name,
									`barcode_is_show_packed_date` = p_barcode_is_show_packed_date,
									`barcode_is_show_serial_no` = p_barcode_is_show_serial_no,
									`barcode_is_show_mrp` = p_barcode_is_show_mrp,
									`barcode_is_show_price` = p_barcode_is_show_price,
									`barcode_company_short_name` = p_barcode_company_short_name,
									`barcode_height` = p_barcode_height,
									`barcode_lable_height` = p_barcode_lable_height,
									`barcode_lable_width` = p_barcode_lable_width,
									`barcode_no_of_columns` = p_barcode_no_of_columns,
									`barcode_no_of_copies` = p_barcode_no_of_copies;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_client_pref` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_client_pref`(p_client_id bigint,
																	p_contact_name varchar(100),
                                                                    p_client_gst varchar(20),
                                                                    p_sales_invoice_title varchar(45),
                                                                    p_sales_invoice_address varchar(500),
                                                                    p_sales_invoice_terms1 varchar(500),
                                                                    p_sales_invoice_terms2 varchar(500),
                                                                    p_is_lock_sales_invoice int(1),
                                                                    p_sales_invoice_lock_in_mins int(1),
                                                                    p_barcode_required_on_invoice int(1),
                                                                    p_payment_type_required int(1),
                                                                    p_add_item_on_scan_barcode int(1),
                                                                    p_cash_validation_required int(1),
                                                                    p_offline_item_validation int(1),
                                                                    p_emp_default_password varchar(100),
                                                                    p_emp_default_salt varchar(100),
                                                                    p_language_code varchar(7),
                                                                    p_gst_slab_required_on_invoice int(1),
																	p_is_three_column_printer int(1),
                                                                    p_validate_stock_on_invoice int(1),
                                                                    p_items_download_automatically int(1),
                                                                    p_extra_discount_required int(1),
                                                                    p_gst_included_on_price int(1),
                                                                    p_is_allow_device_item_reg int(1),
                                                                    p_logo_required_on_invoice int(1),
                                                                    p_emp_user_id varchar(150),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	update PayBillApp.tbl_clients set 
									contact_name = p_contact_name,
                                    client_gst = p_client_gst,
                                    sales_invoice_title = p_sales_invoice_title,
                                    sales_invoice_address = p_sales_invoice_address,
                                    sales_invoice_terms1 = p_sales_invoice_terms1,
                                    sales_invoice_terms2 = p_sales_invoice_terms2,
                                    is_lock_sales_invoice = p_is_lock_sales_invoice,
                                    sales_invoice_lock_in_mins = p_sales_invoice_lock_in_mins,
                                    barcode_required_on_invoice = p_barcode_required_on_invoice,
                                    payment_type_required = p_payment_type_required,
                                    add_item_on_scan_barcode = p_add_item_on_scan_barcode,
                                    cash_validation_required = p_cash_validation_required,
                                    offline_item_validation = p_offline_item_validation,
                                    language_code = p_language_code,
                                    gst_slab_required_on_invoice = p_gst_slab_required_on_invoice,
                                    is_three_column_printer = p_is_three_column_printer,
                                    validate_stock_on_invoice = p_validate_stock_on_invoice,
                                    items_download_automatically = p_items_download_automatically,
                                    extra_discount_required = p_extra_discount_required,
                                    gst_included_on_price = p_gst_included_on_price,
                                    is_allow_device_item_reg = p_is_allow_device_item_reg,
                                    logo_required_on_invoice = p_logo_required_on_invoice
    where client_id = p_client_id and client_status_id = 1;
    
    if length(p_emp_default_password) > 0 then
		update PayBillApp.tbl_clients set emp_default_password = p_emp_default_password, emp_default_salt = p_emp_default_salt
        where client_id = p_client_id and client_status_id = 1;
    end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_client_user` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_client_user`(p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_emp_first_name varchar(50),
																	p_emp_last_name varchar(50),
																	p_emp_address varchar(500),
																	p_emp_mobile varchar(10),
																	p_emp_email_address varchar(150),
                                                                    p_emp_device_id varchar(100),
                                                                    p_local_language_print int(1),
                                                                    p_is_biometric_enabled int(1),
                                                                    p_is_active int(1),
																	p_emp_user_id_updated_by varchar(150),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	declare v_emp_default_password varchar(100);
    declare v_emp_default_salt varchar(100);

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id_updated_by and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;

	update tbl_users set emp_first_name = p_emp_first_name,
                            emp_last_name = p_emp_last_name,
                            emp_address = p_emp_address,
                            emp_mobile = p_emp_mobile,
                            emp_email_address = p_emp_email_address,
                            emp_device_id = p_emp_device_id,
                            local_language_print = p_local_language_print,
                            is_active = p_is_active,
                            updated_by = p_emp_user_id_updated_by,
                            updated_date = now(),
                            is_biometric_enabled = p_is_biometric_enabled
					where client_id = p_client_id and emp_user_id = p_emp_user_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_company_info` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_company_info`(p_sales_invoice_title varchar(50),
									  p_terms1 varchar(500),
									  p_terms2 varchar(500),
									  p_is_authentication_on_manage int(1),
									  p_is_auto_backup int(1),
									  p_backup_file_expiry_days int,
									  p_is_lock_sales_invoice int(1),
									  p_is_lock_purchase_invoice int(1),
									  p_is_cash_validation_required int(1),
									  p_is_transaction_blocked int(1),
									  p_msmapp_id bigint,
									  p_is_dos_barcode int(1),
									  p_is_telugu_print int(1),
									  p_is_gst_required_on_dos_print int(1),
									  p_is_show_aliasname_on_search int(1),
									  p_is_enabled_card int(1),
									  p_is_enabled_wallet int(1),
									  p_is_enabled_app int(1),
									  p_is_enable_android_app_sales int(1),
									  p_app_sales_recollect_time_in_msce bigint,
									  p_barcode_shared_printer varchar(150))
begin
	update tbl_company_info set 
									  `sales_invoice_title` = p_sales_invoice_title,
									  `terms1` = p_terms1,
									  `terms2` = p_terms2,
									  `is_authentication_on_manage` = p_is_authentication_on_manage,
									  `is_auto_backup` = p_is_auto_backup,
									  `backup_file_expiry_days` = p_backup_file_expiry_days,
									  `is_lock_sales_invoice` = p_is_lock_sales_invoice,
									  `is_lock_purchase_invoice` = p_is_lock_purchase_invoice,
									  `is_cash_validation_required` = p_is_cash_validation_required,
									  `is_transaction_blocked` = p_is_transaction_blocked,
									  `msmapp_id` = p_msmapp_id,
									  `is_dos_barcode` = p_is_dos_barcode,
									  `is_telugu_print` = p_is_telugu_print,
									  `is_gst_required_on_dos_print` = p_is_gst_required_on_dos_print,
									  `is_show_aliasname_on_search` = p_is_show_aliasname_on_search,
									  `is_enabled_wallet` = p_is_enabled_wallet,
									  `is_enabled_card` = p_is_enabled_card,
									  `is_enabled_app` = p_is_enabled_app,
									  `is_enable_android_app_sales` = p_is_enable_android_app_sales,
									  `app_sales_recollect_time_in_msce` = p_app_sales_recollect_time_in_msce,
									  `barcode_shared_printer` = p_barcode_shared_printer;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_financial_year` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_financial_year`(p_fyear_to date)
begin
	update tbl_company_info set `fyear_to_date` = p_fyear_to;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_firebase_token` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_firebase_token`(p_user_id varchar(50),
																		p_device_app_id varchar(250),
																		p_firebase_token varchar(500))
leave_lable: BEGIN
	if not exists(select user_id from PayBillApp.tbl_cp_users where user_id = p_user_id and device_app_id = p_device_app_id) then
		signal sqlstate '45000' set message_text = 'Access Denied!';
        leave leave_lable;
    end if;
    
    update PayBillApp.tbl_cp_users set firebase_token = p_firebase_token where user_id = p_user_id and device_app_id = p_device_app_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_invoice_deliver_status` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_invoice_deliver_status`(p_client_id bigint,
																			p_emp_user_id varchar(150),
																			p_emp_device_id varchar(100),
																			p_transaction_key varchar(100),
																			p_sales_id bigint,
																			p_invoice_delivery_key varchar(20),
																			out o_return_value varchar(20))
leave_lable: BEGIN
	declare v_is_invoice_delivered int;
	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select is_invoice_delivered into v_is_invoice_delivered
    from PayBillApp.tbl_sales
    where sales_id = p_sales_id;
    
    if v_is_invoice_delivered is null then
		set o_return_value = 'NO_DATA_FOUND';
	elseif v_is_invoice_delivered = 0 then
		update PayBillApp.tbl_sales set is_invoice_delivered = 1 where sales_id = p_sales_id;
		set o_return_value = 'SUCCESS';
	else 
		set o_return_value = 'ALREADY_DELIVERD';
	end if;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_item_price` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_item_price`(p_client_id bigint,
																p_emp_user_id varchar(150),
																p_emp_device_id varchar(100),
																p_transaction_key varchar(100),
																p_item_id bigint,
                                                                p_item_name varchar(50),
                                                                p_item_alias_name varchar(250),
                                                                p_item_sales_price decimal(19,2))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    update PayBillApp.tbl_items set item_name = p_item_name, item_alias_name = p_item_alias_name, item_sales_price = p_item_sales_price where item_id = p_item_id;
    update PayBillApp.tbl_users set is_price_updated = 1 where client_id = p_client_id and emp_user_id <> p_emp_user_id; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_local_language` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_local_language`(p_client_id bigint, p_item_id bigint, p_item_name_telugu varchar(100))
BEGIN
	update PayBillApp.tbl_items set item_name_telugu = p_item_name_telugu 
    where client_id = p_client_id and item_id = p_item_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_logout` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_logout`(p_userid varchar(50))
begin
	declare v_lg_id bigint;
	
	select max(`lg_id`) into v_lg_id
	from tbl_lgrpt  
	where `userid` = p_userid;

	update tbl_lgrpt set `lg_out_date` = now() where `lg_id` = v_lg_id;

	update tbl_lgrpt set `is_active` = 0 where `userid` = p_userid and `is_active` = 1; 
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_report_header` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_report_header`(p_header_1 varchar(100),
										p_header_2 varchar(100),
										p_header_phone varchar(30),
										p_header_gstin varchar(20))
begin
	update tbl_company_info set 
										`header_1` = p_header_1,
										`header_2` = p_header_2,
										`header_phone` = p_header_phone,
										`header_gstin` = p_header_gstin;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_system` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_system`(p_sys_name varchar(100), 
								p_sys_invoice_printer varchar(150) /* = null */, 
								p_sys_barcode_printer varchar(150) /* = null */,
								p_sys_others_printer varchar(150) /* = null */,
								p_sys_is_dos_invoice_print int(1) /* = null */,
								p_sys_is_telugu_invoice_print int(1) /* = null */,
								p_sys_is_android_app_sales_print int(1) /* = null */)
begin
	if exists(select `sys_name` from tbl_system where `sys_name` = p_sys_name)
	then
		update tbl_system set 
									`sys_invoice_printer` = ifnull(p_sys_invoice_printer,`sys_invoice_printer`), 
									`sys_barcode_printer` = ifnull(p_sys_barcode_printer, `sys_barcode_printer`),
									`sys_others_printer` = ifnull(p_sys_others_printer, `sys_others_printer`),
									`sys_is_dos_invoice_print` = ifnull(p_sys_is_dos_invoice_print,`sys_is_dos_invoice_print`),
									`sys_is_telugu_invoice_print` = ifnull(p_sys_is_telugu_invoice_print, `sys_is_telugu_invoice_print`),
									`sys_is_android_app_sales_print` = ifnull(p_sys_is_android_app_sales_print, `sys_is_android_app_sales_print`)
							where	`sys_name` = p_sys_name;
									
	else
		insert into tbl_system (`sys_invoice_printer`,`sys_barcode_printer`,`sys_others_printer`, `sys_is_dos_invoice_print`, `sys_is_telugu_invoice_print`, `sys_is_android_app_sales_print`)
		values(p_sys_invoice_printer,p_sys_barcode_printer,p_sys_others_printer,p_sys_is_dos_invoice_print,p_sys_is_telugu_invoice_print, p_sys_is_android_app_sales_print);
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upd_system_login` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upd_system_login`(p_sys_name varchar(100))
begin
	if exists(select `sys_name` from tbl_system where `sys_name` = p_sys_name)
	then
		update tbl_system 
							set `last_login_date` = now()
							where	`sys_name` = p_sys_name;
									
	else
		insert into tbl_system (`sys_name`,`last_login_date`) values(p_sys_name,now());
	end if;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_upload_item` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_upload_item`(p_client_id bigint,
																	p_item_name varchar(50),
                                                                    p_item_name_telugu nvarchar(100),
																	p_item_alias_name varchar(250),
																	p_item_barcode varchar(30),
																	p_item_mrp_price decimal(19,2),
																	p_item_sales_price decimal(19,2),
																	p_item_purchase_price decimal(19,2),
																	p_opening_balance bigint,
																	p_cgst_in_per decimal(4,2),
																	p_sgst_in_per decimal(4,2),
																	p_igst_in_per decimal(4,2),
                                                                    p_hsn_code varchar(30),
																	p_emp_user_id varchar(150),
																	p_user_security_key varchar(100))
sp_lbl: begin

	declare v_gst_id bigint;
    declare v_gst_name varchar(30);
    declare v_gst_included_on_price int(1);
    
	if exists(select item_id from tbl_items where client_id = p_client_id and item_name = p_item_name and item_barcode = p_item_barcode and item_mrp_price = p_item_mrp_price) then
		signal sqlstate '45000' set message_text = 'Duplicate item found.';
		leave sp_lbl;
	end if;
    
	
	if (p_cgst_in_per + p_sgst_in_per + p_igst_in_per) > 0 then
		
		select gst_id into v_gst_id
		from tbl_gst
		where cgst_in_per = p_cgst_in_per and 
				sgst_in_per = p_sgst_in_per and 
				igst_in_per = p_igst_in_per;
				
		if v_gst_id is null then
			
			set v_gst_name = concat('GST ' , cast((p_cgst_in_per + p_sgst_in_per) as char), '%');
			
            insert into tbl_gst(client_id,gst_name,cgst_in_per,sgst_in_per,igst_in_per)
			values(p_client_id,v_gst_name,p_cgst_in_per,p_sgst_in_per,p_igst_in_per);
            
            set v_gst_id = last_insert_id();
		end if;
        
        select gst_included_on_price into v_gst_included_on_price
		from PayBillApp.tbl_clients where client_id = p_client_id;

		if v_gst_included_on_price = 1 then
			set p_item_sales_price = (p_item_sales_price * 100)/(100 + p_cgst_in_per + p_sgst_in_per);
		end if;
    
	end if;
    
	insert into tbl_items(client_id,
						  item_name,
						  item_alias_name,
						  item_barcode,
						  item_mrp_price,
						  item_sales_price,
						  item_purchase_price,
						  created_by,
						  opening_balance,
						  current_balance,
						  is_active,
						  gst_id,
						  hsn_code,
						  item_discount_expiry_date,
						  item_discount_type,
						  item_discount_in_per,
						  item_name_telugu)
					values(p_client_id,
							p_item_name,
							p_item_alias_name,
							p_item_barcode,
							p_item_mrp_price,
							p_item_sales_price,
							p_item_purchase_price,
							p_emp_user_id,
							p_opening_balance,
							p_opening_balance,
							1,
							v_gst_id,
							p_hsn_code,
							now(),
							'rs',0,
							p_item_name_telugu);
				
									
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_verify_account_to_reset_password` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_verify_account_to_reset_password`(p_emp_user_id varchar(150),
																					p_emp_mobile varchar(10),
                                                                                    p_otp varchar(100),
																					out o_password_reset_key varchar(100),
                                                                                    out o_otp_sms_api varchar(500),
																					out o_reset_otp_template_id varchar(50))
BEGIN
	if exists(select emp_user_id from PayBillApp.tbl_users where emp_user_id = p_emp_user_id and emp_mobile = p_emp_mobile and is_admin = 1 and is_active = 1) then
		set o_password_reset_key = (select uuid());
        
        select otp_sms_api, reset_otp_template_id into o_otp_sms_api, o_reset_otp_template_id from PayBillApp.tbl_admin limit 1;
        
        update PayBillApp.tbl_users set otp = p_otp, otp_date = now(), password_reset_key = o_password_reset_key
        where emp_user_id = p_emp_user_id and emp_mobile = p_emp_mobile and is_admin = 1 and is_active = 1;
    else 
		signal sqlstate '45000' set message_text = 'No account found on these criteria. Please check and try again!';
    end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_verify_and_update_client_subscription` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_verify_and_update_client_subscription`()
BEGIN
	update PayBillApp.tbl_clients set client_status_id = 2 where client_status_id = 1 and subscription_end_date < date(now());
    
    update PayBillApp.tbl_clients set client_status_id = 3 where client_status_id = 2 and date_add(subscription_end_date, interval 1 month) < date(now());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_verify_client_subscription` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_verify_client_subscription`()
BEGIN
	update PayBillApp.tbl_clients set client_status_id = 2 where client_status_id = 1 and subscription_end_date < date(now());
    
    update PayBillApp.tbl_clients set client_status_id = 3 where client_status_id = 2 and date_add(subscription_end_date, interval 1 month) < date(now());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_verify_otp_to_reset_password` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_verify_otp_to_reset_password`(p_emp_user_id varchar(150),
																					p_emp_mobile varchar(10),
                                                                                    p_otp varchar(100),
																					p_password_reset_key varchar(100),
                                                                                    p_emp_pwd varchar(100),
                                                                                    p_emp_salt varchar(100))
BEGIN
	if exists(select emp_user_id from PayBillApp.tbl_users 
				where emp_user_id = p_emp_user_id and 
						emp_mobile = p_emp_mobile and 
                        is_active = 1 and
						is_admin = 1 and
                        otp = p_otp and
                        addtime(otp_date,'0:10:0') >= now() and
						password_reset_key = p_password_reset_key) then
		
        update PayBillApp.tbl_users set emp_pwd = p_emp_pwd,
											emp_salt = p_emp_salt,
                                            otp = '',
                                            otp_date = addtime(otp_date, '-10:0:0'),
                                            password_reset_key = ''
										where emp_user_id = p_emp_user_id;
    else 
		signal sqlstate '45000' set message_text = 'OTP is not matched/expired!';
    end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_verify_win_qrcode` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_verify_win_qrcode`(p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_emp_device_id varchar(100),
																	p_transaction_key varchar(100),
																	p_win_qrcode_id int,
																	p_win_system_unique_id varchar(250),
																	p_win_qrcode_value varchar(500),
																	p_win_qrcode_security_key varchar(500))
leave_lable: BEGIN
	declare error_msg text;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		GET DIAGNOSTICS CONDITION 1
        error_msg = MESSAGE_TEXT;
		ROLLBACK;
		signal sqlstate '45000' set message_text = error_msg;
    END;

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    if exists(select win_qrcode_id from PayBillApp.tbl_win_qrcodes 
									where win_qrcode_id = p_win_qrcode_id and 
											win_system_unique_id = p_win_system_unique_id and 
                                            win_qrcode_value = p_win_qrcode_value and 
                                            win_qrcode_security_key = p_win_qrcode_security_key) then
          
		START TRANSACTION; 
			
		update PayBillApp.tbl_users set win_qrcode_id = null where win_qrcode_id = p_win_qrcode_id;
        
		update PayBillApp.tbl_users set win_qrcode_id = p_win_qrcode_id, win_qrcode_date = now() 
        where client_id = p_client_id and emp_user_id = p_emp_user_id;
        
        update PayBillApp.tbl_win_qrcodes set client_id = p_client_id where win_qrcode_id = p_win_qrcode_id;
        COMMIT;
	else 
		signal sqlstate '45000' set message_text = 'QR Code authentication parameters have been expired. Please restart the paybill application.';
	end if;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_veriry_enquiry_mobile` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_veriry_enquiry_mobile`(p_enquiry_id bigint,
																		p_enquiry_otp varchar(6),
																		out o_fcm_server_api_key varchar(500),
																		out o_fcm_server_sender_id varchar(100))
BEGIN

	if exists(select enquiry_id from PayBillApp.tbl_sales_enquiries 
								where enquiry_id = p_enquiry_id  and 
										enquiry_otp = p_enquiry_otp and 
                                        addtime(enquiry_otp_date, '0:10:0') >= now()) then
            
			update PayBillApp.tbl_sales_enquiries set enquiry_is_validated = 1, enquiry_otp='' where enquiry_id = p_enquiry_id;
			select fcm_server_api_key,fcm_server_sender_id into o_fcm_server_api_key,o_fcm_server_sender_id from PayBillApp.tbl_admin limit 1; 
			
            select enquiry_id,
					enquiry_date,
					enquiry_name,
                    enquiry_address,
                    enquiry_mobile,
                    enquiry_remarks,
                    enquiry_is_new
            from PayBillApp.tbl_sales_enquiries where enquiry_id = p_enquiry_id;
            
            select firebase_token from PayBillApp.tbl_cp_users where length(firebase_token) > 5 and user_is_active = 1;
	else 
		signal sqlstate '45000' set message_text = 'OTP not matched!';
    end if;
            
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_veriry_register_mobile` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_veriry_register_mobile`(p_request_id bigint,
																		p_request_otp varchar(100),
																		out o_fcm_server_api_key varchar(500),
																		out o_fcm_server_sender_id varchar(100))
BEGIN

	if exists(select request_id from PayBillApp.tbl_client_requests 
								where request_id = p_request_id and 
										request_otp = p_request_otp and 
                                        addtime(request_otp_date, '0:10:0') >= now()) then
            
			update PayBillApp.tbl_client_requests set is_mobile_validated = 1, request_otp='' where request_id = p_request_id;
			select fcm_server_api_key,fcm_server_sender_id into o_fcm_server_api_key,o_fcm_server_sender_id from PayBillApp.tbl_admin limit 1; 
			
            select request_id,
					created_date,
					client_name,
                    contact_name,
                    client_address,
                    contact_mobile
            from PayBillApp.tbl_client_requests 
            where request_id = p_request_id;
            
            select firebase_token from PayBillApp.tbl_cp_users where length(firebase_token) > 5 and user_is_active = 1;
	else 
		signal sqlstate '45000' set message_text = 'OTP not matched!';
    end if;
            
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_active_clients` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_active_clients`(p_search varchar(50),
																		p_user_id varchar(50),
																		p_user_security_key varchar(100))
leave_lable: BEGIN
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    if p_search is null then
		set p_search = '';
    end if;
    
	select clt.client_id,
			client_name,
			contact_name,
			client_address,
			contact_mobile1,
            contact_email,
			client_type_desc,
			date_format(created_date,'%d-%b-%Y') as created_date,
			created_by,
            package_name,
            package_no_users,
            ifnull(no_of_users,0) as no_of_users,
            date_format(subscription_end_date,'%d-%b-%Y') as service_end_date,
            date_format(last_access_date,'%d-%b-%Y') as last_access_date
	from PayBillApp.tbl_clients clt
    inner join PayBillApp.tbl_client_types ctp
    on clt.client_type_id = ctp.client_type_id
    inner join PayBillApp.tbl_packages pkg
    on clt.package_id = pkg.package_id
    left outer join PayBillApp.vw_client_users usr
    on clt.client_id = usr.client_id
    where clt.client_status_id = 1 and 
			(client_name like concat(p_search,'%') || 
            contact_mobile1 like concat(p_search,'%') || 
            contact_email like concat(p_search,'%'))
    order by clt.client_status_id,client_name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_datewise_sales_summary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_datewise_sales_summary`(p_client_id bigint,
																				p_from_date date,
																				p_to_date date,
																				p_created_by varchar(150),
																				p_emp_user_id varchar(150),
																				p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    select sales_date,
            concat(sls.created_by,',', emp_first_name, ' ', emp_last_name) as emp_name,
			sum((total_incl_gst+
			transport_charge+
			packing_charge+
			other_charge)) as total_value
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtls
    on sls.sales_id = dtls.sales_id
    inner join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    inner join PayBillApp.tbl_users usr
    on sls.created_by = usr.emp_user_id
    where sls.client_id = p_client_id and 
			sales_date between p_from_date and p_to_date and 
			sls.created_by = ifnull(p_created_by,sls.created_by)
	group by sales_date,sls.created_by
    order by sales_date,sls.created_by;
    
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_deleted_invoice_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_deleted_invoice_items`(p_client_id bigint,
																			p_from_date date,
																			p_to_date date,
																			p_emp_user_id varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select ROW_NUMBER() OVER (ORDER BY item_name) AS s_no,
			concat(sls.created_by,',', emp_first_name, ' ', emp_last_name) as emp_name,
			sales_date,
			sls.sales_id,
			payment_type_desc,
			item_name,
			item_quantity,
			item_total_value_incl_gst,
            dtls.updated_date as deleted_date
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.tbl_sales_details dtls
    on sls.sales_id = dtls.sales_id
    inner join PayBillApp.tbl_items itm
    on dtls.item_id = itm.item_id
    inner join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    inner join PayBillApp.tbl_users usr
    on sls.created_by = usr.emp_user_id
    where sls.client_id = p_client_id and 
			dtls.is_deleted = 1 and
			sales_date between p_from_date and p_to_date
	order by sales_date,sls.created_by;    

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_discount_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_discount_items`(p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
	select ROW_NUMBER() OVER (ORDER BY item_name) AS s_no,
			item_name,
			item_name_telugu,
            item_alias_name,
			item_barcode,
			item_mrp_price,
			item_sales_price,
			item_purchase_price,
			item_discount_in_per,
			item_discount_expiry_date,
			opening_balance,
			current_balance
		from PayBillApp.tbl_items
		where client_id = p_client_id and 
				is_active = 1 and 
                item_discount_in_per > 0 and 
                item_discount_expiry_date > date(now())
		order by item_name;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_gst_wise_sales_summary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_gst_wise_sales_summary`(p_client_id bigint,
																			p_from_date date,
																			p_to_date date,
																			p_emp_user_id varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select 	cgst_in_per,
			sgst_in_per,
            sum(item_taxable_value) as taxable_value,
            sum(cgst_in_rs) as central_tax_amount,
            sum(sgst_in_rs) as state_tax_amount
    from PayBillApp.tbl_sales_details dtls
    inner join PayBillApp.tbl_sales sls
    on dtls.sales_id = sls.sales_id and sls.is_deleted = 0
    where sls.client_id = p_client_id and 
			dtls.is_deleted = 0 and
			sales_date between p_from_date and p_to_date and 
            (cgst_in_per +	sgst_in_per) > 0
	group by cgst_in_per,sgst_in_per
    order by (cgst_in_per +	sgst_in_per);
    
    select 	igst_in_per,
            sum(item_taxable_value) as taxable_value,
            sum(igst_in_rs) as integrated_tax_amount
    from PayBillApp.tbl_sales_details dtls
    inner join PayBillApp.tbl_sales sls
    on dtls.sales_id = sls.sales_id and sls.is_deleted = 0
    where sls.client_id = p_client_id and 
			dtls.is_deleted = 0 and
			sales_date between p_from_date and p_to_date and 
            igst_in_per > 0
	group by igst_in_per order by igst_in_per;
    
     select sum(item_taxable_value) as taxable_value,
			sum(igst_in_rs) as integrated_tax_amount,
            sum(cgst_in_rs) as central_tax_amount,
            sum(sgst_in_rs) as state_tax_amount,
            sum(igst_in_rs + cgst_in_rs + sgst_in_rs) as total_tax_amount
    from PayBillApp.tbl_sales_details dtls
    inner join PayBillApp.tbl_sales sls
    on dtls.sales_id = sls.sales_id and sls.is_deleted = 0
    where sls.client_id = p_client_id and 
			dtls.is_deleted = 0 and
			sales_date between p_from_date and p_to_date and 
            (cgst_in_per +	sgst_in_per) > 0;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_inaactive_clients` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_inaactive_clients`(p_search varchar(50),
																		p_user_id varchar(50),
																		p_user_security_key varchar(100))
leave_lable: BEGIN
	if not exists(select user_id from PayBillApp.tbl_cp_users 
							where user_id = p_user_id and 
									user_security_key = p_user_security_key and 
                                    user_is_active = 1 and 
                                    is_control_panel_access = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    if p_search is null then
		set p_search = '';
    end if;
    
	select clt.client_id,
			client_name,
			contact_name,
			client_address,
			contact_mobile1,
            contact_email,
			client_type_desc,
            client_status_desc,
			date_format(created_date,'%d-%b-%Y') as created_date,
			created_by,
            package_name,
            package_no_users,
            ifnull(no_of_users,0) as no_of_users,
            date_format(subscription_end_date,'%d-%b-%Y') as service_end_date,
            date_format(last_access_date,'%d-%b-%Y') as last_access_date
	from PayBillApp.tbl_clients clt
    inner join PayBillApp.tbl_client_status sts
    on clt.client_status_id = sts.client_status_id
    inner join PayBillApp.tbl_client_types ctp
    on clt.client_type_id = ctp.client_type_id
    inner join PayBillApp.tbl_packages pkg
    on clt.package_id = pkg.package_id
    left outer join PayBillApp.vw_client_users usr
    on clt.client_id = usr.client_id
    where clt.client_status_id != 1 and 
			(client_name like concat(p_search,'%') || 
            contact_mobile1 like concat(p_search,'%') || 
            contact_email like concat(p_search,'%'))
    order by clt.client_status_id,client_name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_items`(p_client_id bigint,
																p_search varchar(50),
																p_emp_user_id varchar(150),
																p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
	select ROW_NUMBER() OVER (ORDER BY item_name) AS s_no,
			item_name,
			item_name_telugu,
            item_alias_name,
			item_barcode,
			hsn_code,
			item_mrp_price,
			item_sales_price,
			item_purchase_price,
			item_discount_in_per,
			item_discount_expiry_date,
			cgst_in_per,
            sgst_in_per,
            igst_in_per,
			opening_balance,
			current_balance
		from PayBillApp.tbl_items itm
        left outer join PayBillApp.tbl_gst gst
        on itm.gst_id = gst.gst_id
		where itm.client_id = p_client_id and 
				itm.is_active = 1 and 
                (item_name like concat('%',p_search,'%') || 
				item_barcode like concat('%',p_search,'%') || 
				hsn_code like concat('%',p_search,'%'))
		order by item_name;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_item_trans` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_item_trans`(p_from_date date,
																p_to_date date,
																p_item_id bigint)
begin
	declare v_opening_balance bigint;
	
    drop temporary table if exists temp_table;
	create temporary table temp_table
	(
		ref_id bigint,
		invoice_no varchar(30),
		invoice_date date,
		trans_type varchar(20),
		item_quantity bigint,
		item_balance bigint
	);
    
	select `opening_balance` into v_opening_balance
	from tbl_items where `item_id` = p_item_id;
	
    
	select v_opening_balance + ifnull(sum(`item_quantity`),0) into v_opening_balance
	from tbl_purchase pur
	inner join tbl_purchase_details puri
	on pur.purchase_id = puri.purchase_id
	where `item_id` = p_item_id and 
			datediff(purchase_inv_date, p_from_date) < 0;
		
	select v_opening_balance - ifnull(sum(`item_quantity`),0) into v_opening_balance
	from tbl_sales sls
	inner join tbl_sales_details slsi
	on sls.sales_id = slsi.sales_id
	where `item_id` = p_item_id and 
			`sales_date` < p_from_date;
		
	
	
	insert into temp_table(ref_id,trans_type,item_quantity,item_balance) values(0,'opening balance',v_opening_balance,0);

	insert into temp_table
	select sls.sales_id,
			cast(sls.sales_id as char),
			`sales_date`,
			'sales',
			(-1) * `item_quantity`,
			0
	from tbl_sales sls
	inner join tbl_sales_details slsi
	on sls.sales_id = slsi.sales_id
	where `item_id` = p_item_id and 
			`sales_date` between p_from_date and p_to_date;

	
	insert into temp_table
	select pur.purchase_id,
			`purchase_inv_no`,
			`purchase_inv_date`,
			'purchase',
			`item_quantity`,
			0
	from tbl_purchase pur
	inner join tbl_purchase_details puri
	on pur.purchase_id = puri.purchase_id
	where `item_id` = p_item_id and 
			`purchase_inv_date` between p_from_date and p_to_date;
		
	select ref_id,
			trans_type,
			invoice_no,
			invoice_date,
			item_quantity,
			item_balance
	from temp_table order by invoice_date; 
	
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_master_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_master_items`()
begin
	
	select	`item_id`,
			`item_name`,
			`item_alias_name`,
			`item_barcode`,
			`item_mrp_price`,
			`item_sales_price`,
			`item_purchase_price`,
			`item_discount_in_per`,
			`item_discount_expiry_date`,
			`cgst_in_per`,
			`sgst_in_per`,
			`igst_in_per`,
			`gst_is_included`,
			`is_active`,
			`opening_balance`,
			`current_balance`
	from tbl_items
	order by `item_name`;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_non_gst_items` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_non_gst_items`(p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
	select ROW_NUMBER() OVER (ORDER BY item_name) AS s_no,
			item_name,
			item_name_telugu,
            item_alias_name,
			item_barcode,
			item_mrp_price,
			item_sales_price,
			item_purchase_price,
			item_discount_in_per,
			item_discount_expiry_date,
			opening_balance,
			current_balance
		from PayBillApp.tbl_items
		where client_id = p_client_id and is_active = 1 and gst_id is null
		order by item_name;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_purchase` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_purchase`(p_client_id bigint,
																p_from_date date,
																p_to_date date,
																p_supplier_id bigint,
																p_emp_user_id varchar(150),
																p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    select pur.purchase_id,
			purchase_inv_date,
			purchase_inv_no,
			supplier_name,
			quantity,
			total_incl_gst
	from PayBillApp.tbl_purchase pur
    inner join PayBillApp.vw_purchase_details dtls
    on pur.purchase_id = dtls.purchase_id
    inner join PayBillApp.tbl_suppliers sup
    on pur.supplier_id = sup.supplier_id
    where pur.client_id = p_client_id and 
			purchase_inv_date between p_from_date and p_to_date and 
			pur.supplier_id = ifnull(p_supplier_id, pur.supplier_id)
	order by purchase_inv_date;    
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_purchase_details` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_purchase_details`(p_from_date date,
										p_to_date date)
begin

	
	select	sls.purchase_id,
			`purchase_inv_no`,
			`purchase_inv_date`,
			`item_name`,
			`item_barcode`,
			`hsn_code`,
			`item_quantity`,
			`item_price`,
			`item_amount`,
			`item_discount_in_rs`,
			(`item_amount` - `item_discount_in_rs`) as item_taxable_value,
			slsd.cgst_in_per,
			slsd.sgst_in_per,
			slsd.igst_in_per,
			`cgst_in_rs`,
			`sgst_in_rs`,
			`igst_in_rs`,
			(`item_amount` - `item_discount_in_rs` + `item_tax_in_rs`) as item_total_value_incl_gst
	from tbl_purchase sls
	inner join tbl_purchase_details slsd
	on sls.purchase_id = slsd.purchase_id 
	inner join tbl_items itm
	on slsd.item_id = itm.item_id 
	where `purchase_inv_date` between p_from_date and p_to_date
	order by `purchase_inv_date`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_purchase_gst_summary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_purchase_gst_summary`(p_client_id bigint,
																			p_from_date date,
																			p_to_date date,
																			p_emp_user_id varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select ROW_NUMBER() OVER (ORDER BY item_name) AS s_no,
			item_name as particulars,
            sum(item_quantity) as quantity,
            sum(item_amount-item_discount_in_rs) as taxable_value,
            sum(igst_in_rs) as integrated_tax_amount,
            sum(cgst_in_rs) as central_tax_amount,
            sum(sgst_in_rs) as state_tax_amount,
            sum(igst_in_rs + cgst_in_rs + sgst_in_rs) as total_tax_amount,
            sum(item_total_value) as total_invoice_amount
    from PayBillApp.tbl_purchase_details dtls
    inner join PayBillApp.tbl_purchase pur
    on dtls.purchase_id = pur.purchase_id
    inner join PayBillApp.tbl_items itm
    on dtls.item_id = itm.item_id
    where pur.client_id = p_client_id and 
			purchase_inv_date between p_from_date and p_to_date and 
            (igst_in_rs + cgst_in_rs + sgst_in_rs) > 0
	group by item_name order by item_name;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_purchase_hsn_summary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_purchase_hsn_summary`(p_client_id bigint,
																			p_from_date date,
																			p_to_date date,
																			p_emp_user_id varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select ROW_NUMBER() OVER (ORDER BY item_name) AS s_no,
			hsn_code,
			item_name as particulars,
            sum(item_quantity) as quantity,
            sum(item_amount-item_discount_in_rs) as taxable_value,
            sum(igst_in_rs) as integrated_tax_amount,
            sum(cgst_in_rs) as central_tax_amount,
            sum(sgst_in_rs) as state_tax_amount,
            sum(igst_in_rs + cgst_in_rs + sgst_in_rs) as total_tax_amount,
            sum(item_total_value) as total_invoice_amount
    from PayBillApp.tbl_purchase_details dtls
    inner join PayBillApp.tbl_purchase pur
    on dtls.purchase_id = pur.purchase_id
    inner join PayBillApp.tbl_items itm
    on dtls.item_id = itm.item_id and length(hsn_code) > 0
    where pur.client_id = p_client_id and 
			purchase_inv_date between p_from_date and p_to_date and 
            (igst_in_rs + cgst_in_rs + sgst_in_rs) > 0
	group by hsn_code,item_name order by item_name;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_sales` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_sales`(p_client_id bigint,
																p_from_date date,
																p_to_date date,
																p_created_by varchar(150),
																p_payment_type_id int,
																p_emp_user_id varchar(150),
																p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    select concat(sls.created_by,',', emp_first_name, ' ', emp_last_name) as emp_name,
			sales_date,
			sls.sales_id,
			payment_type_desc,
			trans_no,
			quantity,
			(total_incl_gst+
			transport_charge+
			packing_charge+
			other_charge) as total_value
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtls
    on sls.sales_id = dtls.sales_id
    inner join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    inner join PayBillApp.tbl_users usr
    on sls.created_by = usr.emp_user_id
    where sls.client_id = p_client_id and 
			sls.is_deleted = 0 and
			sales_date between p_from_date and p_to_date and 
			sls.created_by = ifnull(p_created_by,sls.created_by) and 
			sls.payment_type_id = ifnull(p_payment_type_id, sls.payment_type_id)
	order by sales_date,sls.created_by;    
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_sales_gst_summary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_sales_gst_summary`(p_client_id bigint,
																			p_from_date date,
																			p_to_date date,
																			p_emp_user_id varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select ROW_NUMBER() OVER (ORDER BY item_name) AS s_no,
			item_name as particulars,
            sum(item_quantity) as quantity,
            sum(item_taxable_value) as taxable_value,
            sum(igst_in_rs) as integrated_tax_amount,
            sum(cgst_in_rs) as central_tax_amount,
            sum(sgst_in_rs) as state_tax_amount,
            sum(igst_in_rs + cgst_in_rs + sgst_in_rs) as total_tax_amount,
            sum(item_total_value_incl_gst) as total_invoice_amount
    from PayBillApp.tbl_sales_details dtls
    inner join PayBillApp.tbl_sales sls
    on dtls.sales_id = sls.sales_id and sls.is_deleted = 0
    inner join PayBillApp.tbl_items itm
    on dtls.item_id = itm.item_id
    where sls.client_id = p_client_id and 
			dtls.is_deleted = 0 and
			sales_date between p_from_date and p_to_date and 
            (igst_in_rs + cgst_in_rs + sgst_in_rs) > 0
	group by item_name order by item_name;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_sales_hsn_summary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_sales_hsn_summary`(p_client_id bigint,
																			p_from_date date,
																			p_to_date date,
																			p_emp_user_id varchar(150),
																			p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select ROW_NUMBER() OVER (ORDER BY item_name) AS s_no,
			hsn_code,
			item_name as particulars,
            sum(item_quantity) as quantity,
            sum(item_taxable_value) as taxable_value,
            sum(igst_in_rs) as integrated_tax_amount,
            sum(cgst_in_rs) as central_tax_amount,
            sum(sgst_in_rs) as state_tax_amount,
            sum(igst_in_rs + cgst_in_rs + sgst_in_rs) as total_tax_amount,
            sum(item_total_value_incl_gst) as total_invoice_amount
    from PayBillApp.tbl_sales_details dtls
    inner join PayBillApp.tbl_sales sls
    on dtls.sales_id = sls.sales_id and sls.is_deleted = 0
    inner join PayBillApp.tbl_items itm
    on dtls.item_id = itm.item_id and length(hsn_code) > 0
    where sls.client_id = p_client_id and 
			dtls.is_deleted = 0 and
			sales_date between p_from_date and p_to_date and 
            (igst_in_rs + cgst_in_rs + sgst_in_rs) > 0
	group by hsn_code,item_name order by item_name;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_sales_register` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_sales_register`(p_client_id bigint,
																		p_from_date date,
																		p_to_date date,
																		p_emp_user_id varchar(150),
																		p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select distinct (cgst_in_per+sgst_in_per+igst_in_per) as gst_per
	from tbl_sales sls
	inner join tbl_sales_details dtls
	on sls.sales_id = dtls.sales_id
	where sales_date between p_from_date and p_to_date
	order by (cgst_in_per+sgst_in_per+igst_in_per);

	select sls.sales_id,
			sales_date,
			sum(item_taxable_value) as taxable_value,
			(cgst_in_per + sgst_in_per + igst_in_per) as gst_per,
			sum(cgst_in_rs + sgst_in_rs + igst_in_rs) as gst_value
    from PayBillApp.tbl_sales sls
    inner join PayBillApp.tbl_sales_details dtls
    on sls.sales_id = dtls.sales_id and dtls.is_deleted = 0
    where client_id = p_client_id and 
			sls.is_deleted = 0 and
			sales_date between p_from_date and p_to_date
	group by sls.sales_id,
			sales_date,
			(cgst_in_per + sgst_in_per + igst_in_per)
	order by sls.sales_id;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_sales_summary_for_device` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_sales_summary_for_device`(p_client_id bigint,
																				p_from_date date,
																				p_to_date date,
																				p_emp_user_id varchar(150),
																				p_emp_device_id varchar(100),
																				p_transaction_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
                                    emp_device_id = p_emp_device_id and
									transaction_key = p_transaction_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    select sls.created_by,
			concat(emp_first_name, ' ', emp_last_name) as emp_name,
			sum((total_incl_gst+
			transport_charge+
			packing_charge+
			other_charge)) as total_value
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtls
    on sls.sales_id = dtls.sales_id
    inner join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    inner join PayBillApp.tbl_users usr
    on sls.created_by = usr.emp_user_id
    where sls.client_id = p_client_id and 
			sales_date between p_from_date and p_to_date
	group by sls.created_by,concat(emp_first_name, ' ', emp_last_name)
    order by sls.created_by;
    
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_stock_summary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_stock_summary`(p_client_id bigint,
																p_emp_user_id varchar(150),
																p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
	select ROW_NUMBER() OVER (ORDER BY item_name) AS s_no,
			item_name,
			item_barcode,
			item_mrp_price,
			item_sales_price,
			item_purchase_price,
			opening_balance,
			current_balance
		from PayBillApp.tbl_items
       where client_id = p_client_id and is_active = 1
		order by item_name;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_successful_payments` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_successful_payments`(p_client_id bigint,
																					p_emp_user_id varchar(150),
																					p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
    
    select ROW_NUMBER() OVER (ORDER BY payment_id desc) AS s_no,
			order_id,
			package_name,
            package_no_users,
			date_format(payment_date,'%d-%b-%Y %H:%i') as payment_date,
			payment_trans_no,
            payment_amount,
            emp_user_id
    from PayBillApp.tbl_client_payments pmt
    inner join PayBillApp.tbl_packages pkg
    on pmt.package_id = pkg.package_id
    where client_id = p_client_id
    order by payment_id desc;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_suppliers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_suppliers`(p_client_id bigint,
																	p_emp_user_id varchar(150),
																	p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
	select ROW_NUMBER() OVER (ORDER BY supplier_name) AS s_no,
			supplier_name,
			supplier_address,
            supplier_mobile,
			supplier_phone,
			supplier_email,
			gstin
		from PayBillApp.tbl_suppliers
		where client_id = p_client_id and 
				is_active = 1
		order by supplier_name;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_users` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_users`()
begin
	
	select `emp_id`
	,`emp_user_id`
      ,`emp_first_name`
      ,`emp_last_name`
      ,`emp_address`
      ,`emp_mobile`
      ,`is_last_invoice_access`
      ,`is_enable_sales_price`
      ,`is_enable_sales_date`
      ,`user_type_desc`
      ,`is_active`
  from tbl_employee emp
  inner join tbl_user_types utp
  on emp.user_type_id = utp.user_type_id
  order by `emp_first_name`;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_view_userwise_sales_summary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_view_userwise_sales_summary`(p_client_id bigint,
																				p_from_date date,
																				p_to_date date,
																				p_created_by varchar(150),
																				p_payment_type_id int,
																				p_emp_user_id varchar(150),
																				p_user_security_key varchar(100))
leave_lable: BEGIN

	if not exists(select emp_user_id from PayBillApp.tbl_users 
							where client_id = p_client_id and 
									emp_user_id = p_emp_user_id and 
									user_security_key = p_user_security_key and 
                                    is_active = 1) then
		signal sqlstate '45000' set message_text = 'Access Denied.';
        leave leave_lable;
    end if;
	
    select sales_date,
            concat(sls.created_by,',', emp_first_name, ' ', emp_last_name) as emp_name,
			payment_type_desc,
			sum((total_incl_gst+
			transport_charge+
			packing_charge+
			other_charge)) as total_value,
            sls.created_by
	from PayBillApp.tbl_sales sls
    inner join PayBillApp.vw_sales_details dtls
    on sls.sales_id = dtls.sales_id
    inner join PayBillApp.tbl_payment_types pmt
    on sls.payment_type_id = pmt.payment_type_id
    inner join PayBillApp.tbl_users usr
    on sls.created_by = usr.emp_user_id
    where sls.client_id = p_client_id and 
			sales_date between p_from_date and p_to_date and 
			sls.created_by = ifnull(p_created_by,sls.created_by) and 
			sls.payment_type_id = ifnull(p_payment_type_id, sls.payment_type_id)
	group by sales_date,sls.created_by,sls.payment_type_id
    order by sales_date,sls.created_by;
    
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `usp_win_qrcode_authentication` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_win_qrcode_authentication`(p_win_qrcode_id int,
																			p_win_system_unique_id varchar(250),
																			p_win_qrcode_value varchar(500),
																			p_win_qrcode_security_key varchar(500))
BEGIN
	declare v_emp_user_id varchar(150);
    
	if exists(select win_qrcode_id from PayBillApp.tbl_win_qrcodes 
									where win_qrcode_id = p_win_qrcode_id and 
											win_system_unique_id = p_win_system_unique_id and 
                                            win_qrcode_value = p_win_qrcode_value and 
                                            win_qrcode_security_key = p_win_qrcode_security_key) then
           
		select usr.client_id,
			client_name,
            emp_user_id,
			concat(emp_first_name,' ',emp_last_name) as employee_name,
			add_item_on_scan_barcode,
			barcode_required_on_invoice,
			client_gst,
			sales_invoice_title,
			sales_invoice_address,
			local_language_print,
			sales_invoice_terms1,
			sales_invoice_terms2,
            logo_required_on_invoice,
            is_admin
        from PayBillApp.tbl_users usr
        inner join PayBillApp.tbl_clients clt
        on usr.client_id = clt.client_id
        where win_qrcode_id = p_win_qrcode_id;
    else 
		signal sqlstate '45000' set message_text = 'QR Code authentication parameters have been expired. Please restart the paybill application.';
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `vw_client_users`
--

/*!50001 DROP VIEW IF EXISTS `vw_client_users`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_client_users` AS select `tbl_users`.`client_id` AS `client_id`,count(0) AS `no_of_users` from `tbl_users` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vw_purchase_details`
--

/*!50001 DROP VIEW IF EXISTS `vw_purchase_details`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_purchase_details` AS select `tbl_purchase_details`.`purchase_id` AS `purchase_id`,sum(`tbl_purchase_details`.`item_quantity`) AS `quantity`,sum(`tbl_purchase_details`.`item_total_value`) AS `total_incl_gst` from `tbl_purchase_details` group by `tbl_purchase_details`.`purchase_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vw_sales_details`
--

/*!50001 DROP VIEW IF EXISTS `vw_sales_details`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_sales_details` AS select `tbl_sales_details`.`sales_id` AS `sales_id`,sum(`tbl_sales_details`.`item_quantity`) AS `quantity`,sum(`tbl_sales_details`.`item_total_value_incl_gst`) AS `total_incl_gst` from `tbl_sales_details` where (`tbl_sales_details`.`is_deleted` = 0) group by `tbl_sales_details`.`sales_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-07-02 15:12:38
