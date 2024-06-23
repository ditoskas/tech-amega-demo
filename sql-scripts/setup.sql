-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: amega
-- ------------------------------------------------------
-- Server version	8.0.37

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20240622104525_DatabaseCreation','8.0.6'),('20240622122824_AddInitialData','8.0.6');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instrumentpairs`
--

DROP TABLE IF EXISTS `instrumentpairs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instrumentpairs` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `BaseInstrumentId` bigint NOT NULL,
  `NonBaseInstrumentId` bigint NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_InstrumentPairs_BaseInstrumentId` (`BaseInstrumentId`),
  KEY `IX_InstrumentPairs_NonBaseInstrumentId` (`NonBaseInstrumentId`),
  CONSTRAINT `FK_InstrumentPairs_Instruments_BaseInstrumentId` FOREIGN KEY (`BaseInstrumentId`) REFERENCES `instruments` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_InstrumentPairs_Instruments_NonBaseInstrumentId` FOREIGN KEY (`NonBaseInstrumentId`) REFERENCES `instruments` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instrumentpairs`
--

LOCK TABLES `instrumentpairs` WRITE;
/*!40000 ALTER TABLE `instrumentpairs` DISABLE KEYS */;
INSERT INTO `instrumentpairs` VALUES (1,3,1,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(2,3,2,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(3,4,1,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(4,4,2,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(5,5,1,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(6,5,2,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(7,6,1,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(8,6,2,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(9,7,1,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(10,7,2,'2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000');
/*!40000 ALTER TABLE `instrumentpairs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instruments`
--

DROP TABLE IF EXISTS `instruments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instruments` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Symbol` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ImagePath` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instruments`
--

LOCK TABLES `instruments` WRITE;
/*!40000 ALTER TABLE `instruments` DISABLE KEYS */;
INSERT INTO `instruments` VALUES (1,'EUR','Euro','/img/instruments/eur.png','2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(2,'USD','United States Dollar','/img/instruments/usd.png','2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(3,'BTC','Bitcoin','/img/instruments/btc.png','2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(4,'ETH','Ethereum','/img/instruments/eth.png','2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(5,'XRP','Ripple','/img/instruments/xrp.png','2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(6,'BCH','Bitcoin Cash','/img/instruments/bch.png','2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000'),(7,'LTC','Light Coin','/img/instruments/ltc.png','2024-06-22 15:28:24.000000','2024-06-22 15:28:24.000000');
/*!40000 ALTER TABLE `instruments` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-22 21:02:07
