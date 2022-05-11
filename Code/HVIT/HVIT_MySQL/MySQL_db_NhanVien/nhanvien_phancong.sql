CREATE DATABASE  IF NOT EXISTS `nhanvien` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `nhanvien`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: nhanvien
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `phancong`
--

DROP TABLE IF EXISTS `phancong`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phancong` (
  `PhancongID` int NOT NULL AUTO_INCREMENT,
  `DuanID` int NOT NULL,
  `NhanvienID` int NOT NULL,
  `Sogiolam` int NOT NULL,
  PRIMARY KEY (`PhancongID`),
  KEY `fk_phancong_nhanvien_idx` (`NhanvienID`),
  KEY `fk_phancong_duan_idx` (`DuanID`),
  CONSTRAINT `fk_phancong_duan` FOREIGN KEY (`DuanID`) REFERENCES `duan` (`DuanID`),
  CONSTRAINT `fk_phancong_nhanvien` FOREIGN KEY (`NhanvienID`) REFERENCES `nhanvien` (`NhanvienID`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phancong`
--

LOCK TABLES `phancong` WRITE;
/*!40000 ALTER TABLE `phancong` DISABLE KEYS */;
INSERT INTO `phancong` VALUES (1,1,1,10),(2,2,1,15),(3,3,1,30),(4,4,1,12),(5,5,1,8),(6,6,1,15),(7,7,1,100),(8,8,1,80),(9,9,1,50),(10,10,1,50),(11,1,2,50),(12,2,2,100),(13,3,2,30),(14,4,2,20),(15,5,2,70),(16,6,2,40),(17,7,2,10),(18,8,2,10),(19,1,3,13),(20,2,3,25),(21,3,3,23),(22,4,3,24),(23,5,3,56),(24,6,3,2),(25,7,3,23),(26,1,4,54),(27,2,4,23),(28,3,4,23),(29,4,4,22),(30,5,4,65),(31,6,4,34),(32,1,5,23),(33,2,5,34),(34,3,5,23),(35,4,5,35),(36,5,5,36),(37,6,5,35),(38,1,6,34),(39,2,6,23),(40,3,6,54),(41,4,6,23),(42,5,6,65),(43,1,7,54),(44,2,7,34),(45,3,7,56),(46,4,7,35),(47,1,8,78),(48,2,8,88),(49,3,8,50),(50,1,9,155),(51,2,9,78),(52,1,10,155);
/*!40000 ALTER TABLE `phancong` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-08-12 20:25:06
