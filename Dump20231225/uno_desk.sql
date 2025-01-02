CREATE DATABASE  IF NOT EXISTS `uno` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `uno`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: uno
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `desk`
--

DROP TABLE IF EXISTS `desk`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `desk` (
  `Id` int NOT NULL,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `desk`
--

LOCK TABLES `desk` WRITE;
/*!40000 ALTER TABLE `desk` DISABLE KEYS */;
INSERT INTO `desk` VALUES (0,'Red(0)'),(1,'Red(1)'),(2,'Red(2)'),(3,'Red(3)'),(4,'Red(4)'),(5,'Red(5)'),(6,'Red(6)'),(7,'Red(7)'),(8,'Red(8)'),(9,'Red(9)'),(10,'Red(ActiveSkip)'),(11,'Red(ActiveRotate)'),(12,'Red(ActiveTakeTwo)'),(13,'Black(WildColor)'),(14,'Yellow(0)'),(15,'Yellow(1)'),(16,'Yellow(2)'),(17,'Yellow(3)'),(18,'Yellow(4)'),(19,'Yellow(5)'),(20,'Yellow(6)'),(21,'Yellow(7)'),(22,'Yellow(8)'),(23,'Yellow(9)'),(24,'Yellow(ActiveSkip)'),(25,'Yellow(ActiveRotate)'),(26,'Yellow(ActiveTakeTwo)'),(27,'Black(WildColor)'),(28,'Green(0)'),(29,'Green(1)'),(30,'Green(2)'),(31,'Green(3)'),(32,'Green(4)'),(33,'Green(5)'),(34,'Green(6)'),(35,'Green(7)'),(36,'Green(8)'),(37,'Green(9)'),(38,'Green(ActiveSkip)'),(39,'Green(ActiveRotate)'),(40,'Green(ActiveTakeTwo)'),(41,'Black(WildColor)'),(42,'Blue(0)'),(43,'Blue(1)'),(44,'Blue(2)'),(45,'Blue(3)'),(46,'Blue(4)'),(47,'Blue(5)'),(48,'Blue(6)'),(49,'Blue(7)'),(50,'Blue(8)'),(51,'Blue(9)'),(52,'Blue(ActiveSkip)'),(53,'Blue(ActiveRotate)'),(54,'Blue(ActiveTakeTwo)'),(55,'Black(WildColor)'),(56,'Red(1)'),(57,'Red(2)'),(58,'Red(3)'),(59,'Red(4)'),(60,'Red(5)'),(61,'Red(6)'),(62,'Red(7)'),(63,'Red(8)'),(64,'Red(9)'),(65,'Red(ActiveSkip)'),(66,'Red(ActiveRotate)'),(67,'Red(ActiveTakeTwo)'),(68,'Black(WildColor, TakeFour)'),(69,'Yellow(1)'),(70,'Yellow(2)'),(71,'Yellow(3)'),(72,'Yellow(4)'),(73,'Yellow(5)'),(74,'Yellow(6)'),(75,'Yellow(7)'),(76,'Yellow(8)'),(77,'Yellow(9)'),(78,'Yellow(ActiveSkip)'),(79,'Yellow(ActiveRotate)'),(80,'Yellow(ActiveTakeTwo)'),(81,'Black(WildColor, TakeFour)'),(82,'Green(1)'),(83,'Green(2)'),(84,'Green(3)'),(85,'Green(4)'),(86,'Green(5)'),(87,'Green(6)'),(88,'Green(7)'),(89,'Green(8)'),(90,'Green(9)'),(91,'Green(ActiveSkip)'),(92,'Green(ActiveRotate)'),(93,'Green(ActiveTakeTwo)'),(94,'Black(WildColor, TakeFour)'),(95,'Blue(1)'),(96,'Blue(2)'),(97,'Blue(3)'),(98,'Blue(4)'),(99,'Blue(5)'),(100,'Blue(6)'),(101,'Blue(7)'),(102,'Blue(8)'),(103,'Blue(9)'),(104,'Blue(ActiveSkip)'),(105,'Blue(ActiveRotate)'),(106,'Blue(ActiveTakeTwo)'),(107,'Black(WildColor, TakeFour)');
/*!40000 ALTER TABLE `desk` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-25 16:53:09
