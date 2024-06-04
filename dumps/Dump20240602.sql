-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: studentregistrationsystem
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
-- Table structure for table `admin_details`
--

DROP TABLE IF EXISTS admin_details;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE admin_details (
  username varchar(45) CHARACTER SET latin1 COLLATE latin1_general_cs NOT NULL,
  `password` varchar(45) CHARACTER SET latin1 COLLATE latin1_general_cs DEFAULT NULL,
  PRIMARY KEY (username)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_cs;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin_details`
--

LOCK TABLES admin_details WRITE;
/*!40000 ALTER TABLE admin_details DISABLE KEYS */;
INSERT INTO admin_details VALUES ('Admin','admin123');
/*!40000 ALTER TABLE admin_details ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_details`
--

DROP TABLE IF EXISTS student_details;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE student_details (
  enroll varchar(100) CHARACTER SET latin1 COLLATE latin1_general_cs NOT NULL,
  nicnum varchar(45) CHARACTER SET latin1 COLLATE latin1_general_cs DEFAULT NULL,
  sname varchar(100) CHARACTER SET latin1 COLLATE latin1_general_cs DEFAULT NULL,
  emaill varchar(45) CHARACTER SET latin1 COLLATE latin1_general_cs DEFAULT NULL,
  phonenum varchar(15) CHARACTER SET latin1 COLLATE latin1_general_cs DEFAULT NULL,
  homeaddress varchar(100) CHARACTER SET latin1 COLLATE latin1_general_cs DEFAULT NULL,
  sgender varchar(10) CHARACTER SET latin1 COLLATE latin1_general_cs DEFAULT NULL,
  birth varchar(100) CHARACTER SET latin1 COLLATE latin1_general_cs DEFAULT NULL,
  joinday varchar(100) CHARACTER SET latin1 COLLATE latin1_general_cs DEFAULT NULL,
  PRIMARY KEY (enroll)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_cs;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_details`
--

LOCK TABLES student_details WRITE;
/*!40000 ALTER TABLE student_details DISABLE KEYS */;
INSERT INTO student_details VALUES ('ANU/IT/01','200112345678','S.K. Swarnamali Silva','swarnamalisilva@gmail.com','0711234567','Kahatagasdigiliya','Female','5/12/2000 9:00:43 AM','4/20/2022 9:00:43 AM');
/*!40000 ALTER TABLE student_details ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-02  9:45:19
