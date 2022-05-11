CREATE DATABASE  IF NOT EXISTS `hocsinh` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `hocsinh`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: hocsinh
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
-- Table structure for table `hocsinh`
--

DROP TABLE IF EXISTS `hocsinh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hocsinh` (
  `HocsinhID` int NOT NULL AUTO_INCREMENT,
  `LopID` int NOT NULL,
  `Hoten` varchar(50) NOT NULL,
  `Gioitinh` varchar(5) NOT NULL,
  `Ngaysinh` date NOT NULL,
  `Diachi` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`HocsinhID`),
  KEY `fk_hocsinh_lop_idx` (`LopID`),
  CONSTRAINT `fk_hocsinh_lop` FOREIGN KEY (`LopID`) REFERENCES `lop` (`lopID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hocsinh`
--

LOCK TABLES `hocsinh` WRITE;
/*!40000 ALTER TABLE `hocsinh` DISABLE KEYS */;
INSERT INTO `hocsinh` VALUES (1,1,'Trương Thị Châu','nữ','2005-03-03','Hà Nội',NULL),(2,1,'Hoàng Văn Chiến','nam','2004-03-06','Hà Nội','hvc@gmail.com'),(3,1,'Nguyễn Thị Mai','nữ','2005-06-07','Thái Bình',NULL),(4,2,'Đoàn Hoàng Thái','nam','2005-02-02','Cao Bằng','thaidh@gmail.com'),(5,2,'Mai Thị Châu','nữ','2005-04-05','Thanh Hóa',NULL),(6,3,'Khổng Minh Mạnh','nam','2004-06-06','Lào Cai',NULL),(7,3,'Nguyễn Quyết Chiến','nam','2004-06-07','Hà Nội',NULL),(8,3,'Nguyễn Hữu Nghĩa','nam','2005-07-07','Thái Bình',NULL),(9,4,'Ngô Văn Vở','nam','2005-03-02','Hưng Yên','vanvo@gmail.com'),(10,4,'Anna Bella','nữ','2005-02-02','Vĩnh Phúc',NULL),(11,4,'Ma Văn Kháng','nam','2004-03-05','Hòa Bình',NULL),(12,4,'Đặng Thai Mai','nữ','2005-06-03','Nam Định',NULL),(13,5,'Nguyễn Ngọc Vũ','nam','2005-02-01','Hà Giang',NULL),(14,6,'Ngô Ngọc Mỹ Linh','nữ','2005-01-02','Yên Bái','mylinh@gmail.com'),(15,7,'Trịnh Thị Thùy Linh','nữ','2005-03-05','Quảng Ninh',NULL),(16,8,'Mai Quốc Khánh','nam','2005-06-03','Hải Phòng',NULL),(17,9,'Tôn Thất Tùng','nam','2004-05-05','Nghệ An',NULL),(18,10,'Nguyễn Thị Dung','nữ','2005-04-02','Thái Bình',NULL);
/*!40000 ALTER TABLE `hocsinh` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-08-12 20:24:48
