# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 5.7.25)
# Database: CoolCal
# Generation Time: 2019-09-25 03:09:01 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table Calendars
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Calendars`;

CREATE TABLE `Calendars` (
  `CalendarID` int(40) NOT NULL AUTO_INCREMENT,
  `UserID` int(40) NOT NULL,
  PRIMARY KEY (`CalendarID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `UserID` FOREIGN KEY (`UserID`) REFERENCES `Profile` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Calendars` WRITE;
/*!40000 ALTER TABLE `Calendars` DISABLE KEYS */;

INSERT INTO `Calendars` (`CalendarID`, `UserID`)
VALUES
	(1,9),
	(5,10),
	(8,11),
	(2,12),
	(3,13),
	(6,14),
	(4,15),
	(7,16);

/*!40000 ALTER TABLE `Calendars` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table Events
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Events`;

CREATE TABLE `Events` (
  `EventID` int(40) NOT NULL AUTO_INCREMENT,
  `CalendarID` int(40) NOT NULL,
  `Description` varchar(256) NOT NULL DEFAULT ' ',
  `Color` varchar(40) NOT NULL DEFAULT 'gray',
  `EventDateTime` datetime NOT NULL,
  `Location` varchar(256) NOT NULL DEFAULT ' ',
  `AdditionalInfo` varchar(256) NOT NULL DEFAULT ' ',
  `NotificationID` int(40) NOT NULL DEFAULT '1',
  `Notes` varchar(256) NOT NULL DEFAULT ' ',
  `EventTypeID` int(40) NOT NULL,
  PRIMARY KEY (`EventID`),
  KEY `CalID` (`CalendarID`),
  KEY `Notify` (`NotificationID`),
  KEY `EventTypes` (`EventTypeID`),
  CONSTRAINT `CalID` FOREIGN KEY (`CalendarID`) REFERENCES `Calendars` (`CalendarID`),
  CONSTRAINT `EventTypes` FOREIGN KEY (`EventTypeID`) REFERENCES `EventTypes` (`EventTypeID`),
  CONSTRAINT `Notify` FOREIGN KEY (`NotificationID`) REFERENCES `Notifications` (`NotificationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Events` WRITE;
/*!40000 ALTER TABLE `Events` DISABLE KEYS */;

INSERT INTO `Events` (`EventID`, `CalendarID`, `Description`, `Color`, `EventDateTime`, `Location`, `AdditionalInfo`, `NotificationID`, `Notes`, `EventTypeID`)
VALUES
	(1,1,'	2coolivet	','	red 	','2019-10-02 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(2,1,'	A1cialerce	','	green	','2019-10-03 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(3,1,'	Acumeri	','	blue	','2019-10-04 08:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(4,1,'	Amporyok	','	red 	','2019-10-05 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(5,1,'	Appmaceti	','	green	','2019-10-06 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(6,1,'	AttractiveNephew	','	blue	','2019-10-07 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(7,1,'	AuthorScan	','	red 	','2019-10-08 08:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(8,1,'	Aveloted	','	green	','2019-10-09 08:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(9,2,'	2coolivet	','	blue	','2019-10-02 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(10,2,'	A1cialerce	','	red 	','2019-10-03 08:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(11,2,'	Acumeri	','	green	','2019-10-04 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(12,2,'	Amporyok	','	blue	','2019-10-05 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(13,2,'	Appmaceti	','	red 	','2019-10-06 08:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(14,2,'	AttractiveNephew	','	green	','2019-10-07 08:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(15,2,'	AuthorScan	','	blue	','2019-10-08 08:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(16,2,'	Aveloted	','	red 	','2019-10-09 08:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(17,3,'	2coolivet	','	green	','2019-10-02 08:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(18,3,'	A1cialerce	','	blue	','2019-10-03 08:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(19,3,'	Acumeri	','	red 	','2019-10-04 08:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(20,3,'	Amporyok	','	green	','2019-10-05 08:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(21,3,'	Appmaceti	','	blue	','2019-10-06 08:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(22,3,'	AttractiveNephew	','	red 	','2019-10-07 08:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(23,3,'	AuthorScan	','	green	','2019-10-08 08:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(24,3,'	Aveloted	','	blue	','2019-10-09 08:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(25,4,'	2coolivet	','	red 	','2019-10-02 08:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(26,4,'	A1cialerce	','	green	','2019-10-03 08:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(27,4,'	Acumeri	','	blue	','2019-10-04 08:00:00','	HOME	','	NONE	',2,'	NONE	',4),
	(28,4,'	Amporyok	','	red 	','2019-10-05 08:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(29,4,'	Appmaceti	','	green	','2019-10-06 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(30,4,'	AttractiveNephew	','	blue	','2019-10-07 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(31,5,'	AuthorScan	','	red 	','2019-10-08 08:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(32,5,'	Aveloted	','	green	','2019-10-09 08:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(33,5,'	2coolivet	','	blue	','2019-10-02 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(34,6,'	A1cialerce	','	red 	','2019-10-03 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(35,6,'	Acumeri	','	green	','2019-10-04 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(36,6,'	Amporyok	','	blue	','2019-10-05 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(37,6,'	Appmaceti	','	red 	','2019-10-06 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(38,1,'	2coolivet	','	red 	','2019-11-06 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(39,1,'	A1cialerce	','	green	','2019-11-07 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(40,1,'	Acumeri	','	blue	','2019-11-08 08:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(41,1,'	Amporyok	','	red 	','2019-11-09 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(42,1,'	Appmaceti	','	green	','2019-11-10 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(43,1,'	AttractiveNephew	','	blue	','2019-11-11 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(44,1,'	AuthorScan	','	red 	','2019-11-12 08:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(45,1,'	Aveloted	','	green	','2019-11-13 08:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(46,2,'	2coolivet	','	blue	','2019-11-14 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(47,2,'	A1cialerce	','	red 	','2019-11-15 08:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(48,2,'	Acumeri	','	green	','2019-11-16 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(49,2,'	Amporyok	','	blue	','2019-11-17 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(50,2,'	Appmaceti	','	red 	','2019-11-18 08:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(51,2,'	AttractiveNephew	','	green	','2019-11-19 08:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(52,2,'	AuthorScan	','	blue	','2019-11-20 08:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(53,2,'	Aveloted	','	red 	','2019-11-21 08:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(54,3,'	2coolivet	','	green	','2019-11-22 08:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(55,3,'	A1cialerce	','	blue	','2019-11-23 08:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(56,3,'	Acumeri	','	red 	','2019-11-24 08:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(57,3,'	Amporyok	','	green	','2019-11-25 08:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(58,3,'	Appmaceti	','	blue	','2019-11-26 08:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(59,3,'	AttractiveNephew	','	red 	','2019-11-27 08:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(60,3,'	AuthorScan	','	green	','2019-11-28 08:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(61,3,'	Aveloted	','	blue	','2019-11-29 08:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(62,4,'	2coolivet	','	red 	','2019-11-30 08:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(63,4,'	A1cialerce	','	green	','2019-12-01 08:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(64,4,'	Acumeri	','	blue	','2019-12-02 08:00:00','	HOME	','	NONE	',2,'	NONE	',4),
	(65,4,'	Amporyok	','	red 	','2019-12-03 08:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(66,4,'	Appmaceti	','	green	','2019-12-04 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(67,4,'	AttractiveNephew	','	blue	','2019-12-05 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(68,5,'	AuthorScan	','	red 	','2019-12-06 08:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(69,5,'	Aveloted	','	green	','2019-12-07 08:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(70,5,'	2coolivet	','	blue	','2019-12-08 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(71,6,'	A1cialerce	','	red 	','2019-12-09 08:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(72,6,'	Acumeri	','	green	','2019-12-10 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(73,6,'	Amporyok	','	blue	','2019-12-11 08:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(74,6,'	Appmaceti	','	red 	','2019-12-12 08:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(75,1,'	2coolivet	','	red 	','2019-11-14 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(76,1,'	A1cialerce	','	green	','2019-11-15 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(77,1,'	Acumeri	','	blue	','2019-11-16 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(78,1,'	Amporyok	','	red 	','2019-11-17 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(79,1,'	Appmaceti	','	green	','2019-11-18 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(80,1,'	AttractiveNephew	','	blue	','2019-11-19 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(81,1,'	AuthorScan	','	red 	','2019-11-20 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(82,1,'	Aveloted	','	green	','2019-11-21 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(83,2,'	2coolivet	','	blue	','2019-11-22 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(84,2,'	A1cialerce	','	red 	','2019-11-23 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(85,2,'	Acumeri	','	green	','2019-11-24 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(86,2,'	Amporyok	','	blue	','2019-11-25 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(87,2,'	Appmaceti	','	red 	','2019-11-26 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(88,2,'	AttractiveNephew	','	green	','2019-11-27 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(89,2,'	AuthorScan	','	blue	','2019-11-28 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(90,2,'	Aveloted	','	red 	','2019-11-29 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(91,3,'	2coolivet	','	green	','2019-11-30 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(92,3,'	A1cialerce	','	blue	','2019-12-01 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(93,3,'	Acumeri	','	red 	','2019-12-02 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(94,3,'	Amporyok	','	green	','2019-12-03 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(95,3,'	Appmaceti	','	blue	','2019-12-04 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(96,3,'	AttractiveNephew	','	red 	','2019-12-05 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(97,3,'	AuthorScan	','	green	','2019-12-06 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(98,3,'	Aveloted	','	blue	','2019-12-07 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(99,4,'	2coolivet	','	red 	','2019-12-08 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(100,4,'	A1cialerce	','	green	','2019-12-09 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(101,4,'	Acumeri	','	blue	','2019-12-10 11:00:00','	HOME	','	NONE	',2,'	NONE	',4),
	(102,4,'	Amporyok	','	red 	','2019-12-11 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(103,4,'	Appmaceti	','	green	','2019-12-12 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(104,4,'	AttractiveNephew	','	blue	','2019-12-13 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(105,5,'	AuthorScan	','	red 	','2019-12-14 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(106,5,'	Aveloted	','	green	','2019-12-15 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(107,5,'	2coolivet	','	blue	','2019-12-16 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(108,6,'	A1cialerce	','	red 	','2019-12-17 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(109,6,'	Acumeri	','	green	','2019-12-18 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(110,6,'	Amporyok	','	blue	','2019-12-19 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(111,6,'	Appmaceti	','	red 	','2019-12-20 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(112,1,'	2coolivet	','	red 	','2019-12-18 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(113,1,'	A1cialerce	','	green	','2019-12-19 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(114,1,'	Acumeri	','	blue	','2019-12-20 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(115,1,'	Amporyok	','	red 	','2019-12-21 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(116,1,'	Appmaceti	','	green	','2019-12-22 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(117,1,'	AttractiveNephew	','	blue	','2019-12-23 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(118,1,'	AuthorScan	','	red 	','2019-12-24 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(119,1,'	Aveloted	','	green	','2019-12-25 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(120,2,'	2coolivet	','	blue	','2019-12-26 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(121,2,'	A1cialerce	','	red 	','2019-12-27 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(122,2,'	Acumeri	','	green	','2019-12-28 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(123,2,'	Amporyok	','	blue	','2019-12-29 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(124,2,'	Appmaceti	','	red 	','2019-12-30 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(125,2,'	AttractiveNephew	','	green	','2019-12-31 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(126,2,'	AuthorScan	','	blue	','2020-01-01 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(127,2,'	Aveloted	','	red 	','2020-01-02 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(128,3,'	2coolivet	','	green	','2020-01-03 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(129,3,'	A1cialerce	','	blue	','2020-01-04 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(130,3,'	Acumeri	','	red 	','2020-01-05 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(131,3,'	Amporyok	','	green	','2020-01-06 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(132,3,'	Appmaceti	','	blue	','2020-01-07 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(133,3,'	AttractiveNephew	','	red 	','2020-01-08 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(134,3,'	AuthorScan	','	green	','2020-01-09 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(135,3,'	Aveloted	','	blue	','2020-01-10 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(136,4,'	2coolivet	','	red 	','2020-01-11 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(137,4,'	A1cialerce	','	green	','2020-01-12 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(138,4,'	Acumeri	','	blue	','2020-01-13 11:00:00','	HOME	','	NONE	',2,'	NONE	',4),
	(139,4,'	Amporyok	','	red 	','2020-01-14 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(140,4,'	Appmaceti	','	green	','2020-01-15 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(141,4,'	AttractiveNephew	','	blue	','2020-01-16 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(142,5,'	AuthorScan	','	red 	','2020-01-17 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(143,5,'	Aveloted	','	green	','2020-01-18 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(144,5,'	2coolivet	','	blue	','2020-01-19 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(145,6,'	A1cialerce	','	red 	','2020-01-20 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(146,6,'	Acumeri	','	green	','2020-01-21 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(147,6,'	Amporyok	','	blue	','2020-01-22 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(148,6,'	Appmaceti	','	red 	','2020-01-23 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(149,1,'	2coolivet	','	red 	','2020-01-22 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(150,1,'	A1cialerce	','	green	','2020-01-23 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(151,1,'	Acumeri	','	blue	','2020-01-24 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(152,1,'	Amporyok	','	red 	','2020-01-25 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(153,1,'	Appmaceti	','	green	','2020-01-26 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(154,1,'	AttractiveNephew	','	blue	','2020-01-27 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(155,1,'	AuthorScan	','	red 	','2020-01-28 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(156,1,'	Aveloted	','	green	','2020-01-29 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(157,2,'	2coolivet	','	blue	','2020-01-30 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(158,2,'	A1cialerce	','	red 	','2020-01-31 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(159,2,'	Acumeri	','	green	','2020-02-01 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(160,2,'	Amporyok	','	blue	','2020-02-02 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(161,2,'	Appmaceti	','	red 	','2020-02-03 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(162,2,'	AttractiveNephew	','	green	','2020-02-04 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(163,2,'	AuthorScan	','	blue	','2020-02-05 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(164,2,'	Aveloted	','	red 	','2020-02-06 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(165,3,'	2coolivet	','	green	','2020-02-07 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(166,3,'	A1cialerce	','	blue	','2020-02-08 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(167,3,'	Acumeri	','	red 	','2020-02-09 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(168,3,'	Amporyok	','	green	','2020-02-10 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(169,3,'	Appmaceti	','	blue	','2020-02-11 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(170,3,'	AttractiveNephew	','	red 	','2020-02-12 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(171,3,'	AuthorScan	','	green	','2020-02-13 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(172,3,'	Aveloted	','	blue	','2020-02-14 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(173,4,'	2coolivet	','	red 	','2020-02-15 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(174,4,'	A1cialerce	','	green	','2020-02-16 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(175,4,'	Acumeri	','	blue	','2020-02-17 11:00:00','	HOME	','	NONE	',2,'	NONE	',4),
	(176,4,'	Amporyok	','	red 	','2020-02-18 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(177,4,'	Appmaceti	','	green	','2020-02-19 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(178,4,'	AttractiveNephew	','	blue	','2020-02-20 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(179,5,'	AuthorScan	','	red 	','2020-02-21 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(180,5,'	Aveloted	','	green	','2020-02-22 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(181,5,'	2coolivet	','	blue	','2020-02-23 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(182,6,'	A1cialerce	','	red 	','2020-02-24 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(183,6,'	Acumeri	','	green	','2020-02-25 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(184,6,'	Amporyok	','	blue	','2020-02-26 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(185,6,'	Appmaceti	','	red 	','2020-02-27 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(186,1,'	2coolivet	','	red 	','2020-02-27 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(187,1,'	A1cialerce	','	green	','2020-02-28 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(188,1,'	Acumeri	','	blue	','2020-02-29 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(189,1,'	Amporyok	','	red 	','2020-03-01 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(190,1,'	Appmaceti	','	green	','2020-03-02 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(191,1,'	AttractiveNephew	','	blue	','2020-03-03 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(192,1,'	AuthorScan	','	red 	','2020-03-04 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(193,1,'	Aveloted	','	green	','2020-03-05 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(194,2,'	2coolivet	','	blue	','2020-03-06 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(195,2,'	A1cialerce	','	red 	','2020-03-07 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(196,2,'	Acumeri	','	green	','2020-03-08 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(197,2,'	Amporyok	','	blue	','2020-03-09 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(198,2,'	Appmaceti	','	red 	','2020-03-10 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(199,2,'	AttractiveNephew	','	green	','2020-03-11 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(200,2,'	AuthorScan	','	blue	','2020-03-12 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(201,2,'	Aveloted	','	red 	','2020-03-13 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(202,3,'	2coolivet	','	green	','2020-03-14 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(203,3,'	A1cialerce	','	blue	','2020-03-15 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(204,3,'	Acumeri	','	red 	','2020-03-16 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(205,3,'	Amporyok	','	green	','2020-03-17 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(206,3,'	Appmaceti	','	blue	','2020-03-18 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(207,3,'	AttractiveNephew	','	red 	','2020-03-19 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(208,3,'	AuthorScan	','	green	','2020-03-20 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(209,3,'	Aveloted	','	blue	','2020-03-21 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(210,4,'	2coolivet	','	red 	','2020-03-22 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(211,4,'	A1cialerce	','	green	','2020-03-23 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(212,4,'	Acumeri	','	blue	','2020-03-24 11:00:00','	HOME	','	NONE	',2,'	NONE	',4),
	(213,4,'	Amporyok	','	red 	','2020-03-25 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(214,4,'	Appmaceti	','	green	','2020-03-26 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(215,4,'	AttractiveNephew	','	blue	','2020-03-27 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(216,5,'	AuthorScan	','	red 	','2020-03-28 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(217,5,'	Aveloted	','	green	','2020-03-29 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(218,5,'	2coolivet	','	blue	','2020-03-30 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(219,6,'	A1cialerce	','	red 	','2020-03-31 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(220,6,'	Acumeri	','	green	','2020-04-01 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(221,6,'	Amporyok	','	blue	','2020-04-02 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(222,6,'	Appmaceti	','	red 	','2020-04-03 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(223,1,'	2coolivet	','	red 	','2020-03-21 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(224,1,'	A1cialerce	','	green	','2020-03-22 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(225,1,'	Acumeri	','	blue	','2020-03-23 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(226,1,'	Amporyok	','	red 	','2020-03-24 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(227,1,'	Appmaceti	','	green	','2020-03-25 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(228,1,'	AttractiveNephew	','	blue	','2020-03-26 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(229,1,'	AuthorScan	','	red 	','2020-03-27 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(230,1,'	Aveloted	','	green	','2020-03-28 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(231,2,'	2coolivet	','	blue	','2020-03-29 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(232,2,'	A1cialerce	','	red 	','2020-03-30 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(233,2,'	Acumeri	','	green	','2020-03-31 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(234,2,'	Amporyok	','	blue	','2020-04-01 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(235,2,'	Appmaceti	','	red 	','2020-04-02 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(236,2,'	AttractiveNephew	','	green	','2020-04-03 11:00:00','	HOME	','	NONE	',3,'	NONE	',1),
	(237,2,'	AuthorScan	','	blue	','2020-04-04 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(238,2,'	Aveloted	','	red 	','2020-04-05 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(239,3,'	2coolivet	','	green	','2020-04-06 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(240,3,'	A1cialerce	','	blue	','2020-04-07 11:00:00','	HOME	','	NONE	',1,'	NONE	',2),
	(241,3,'	Acumeri	','	red 	','2020-04-08 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(242,3,'	Amporyok	','	green	','2020-04-09 11:00:00','	HOME	','	NONE	',2,'	NONE	',3),
	(243,3,'	Appmaceti	','	blue	','2020-04-10 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(244,3,'	AttractiveNephew	','	red 	','2020-04-11 11:00:00','	HOME	','	NONE	',3,'	NONE	',3),
	(245,3,'	AuthorScan	','	green	','2020-04-12 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(246,3,'	Aveloted	','	blue	','2020-04-13 11:00:00','	HOME	','	NONE	',4,'	NONE	',3),
	(247,4,'	2coolivet	','	red 	','2020-04-14 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(248,4,'	A1cialerce	','	green	','2020-04-15 11:00:00','	HOME	','	NONE	',1,'	NONE	',4),
	(249,4,'	Acumeri	','	blue	','2020-04-16 11:00:00','	HOME	','	NONE	',2,'	NONE	',4),
	(250,4,'	Amporyok	','	red 	','2020-04-17 11:00:00','	HOME	','	NONE	',2,'	NONE	',1),
	(251,4,'	Appmaceti	','	green	','2020-04-18 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(252,4,'	AttractiveNephew	','	blue	','2020-04-19 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(253,5,'	AuthorScan	','	red 	','2020-04-20 11:00:00','	HOME	','	NONE	',4,'	NONE	',2),
	(254,5,'	Aveloted	','	green	','2020-04-21 11:00:00','	HOME	','	NONE	',4,'	NONE	',1),
	(255,5,'	2coolivet	','	blue	','2020-04-22 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(256,6,'	A1cialerce	','	red 	','2020-04-23 11:00:00','	HOME	','	NONE	',1,'	NONE	',1),
	(257,6,'	Acumeri	','	green	','2020-04-24 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(258,6,'	Amporyok	','	blue	','2020-04-25 11:00:00','	HOME	','	NONE	',2,'	NONE	',2),
	(259,6,'	Appmaceti	','	red 	','2020-04-26 11:00:00','	HOME	','	NONE	',3,'	NONE	',2),
	(260,1,'hello world','    blue    ','2019-11-09 11:00:00','home','none',4,'hold note',4),
	(261,1,'hello world','	green	','2019-11-06 11:00:00','home','',1,'no notes',4),
	(262,1,'hello world','	red 	','2019-11-08 11:00:00','home','note not made',2,'no note',4),
	(263,1,'hello world','	red 	','2019-11-09 00:00:00','home','hello',1,'no note',4),
	(264,1,'hello event','	blue	','2020-11-19 11:00:00','home','none',1,'no notes',4);

/*!40000 ALTER TABLE `Events` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table EventTypes
# ------------------------------------------------------------

DROP TABLE IF EXISTS `EventTypes`;

CREATE TABLE `EventTypes` (
  `EventTypeID` int(40) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`EventTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `EventTypes` WRITE;
/*!40000 ALTER TABLE `EventTypes` DISABLE KEYS */;

INSERT INTO `EventTypes` (`EventTypeID`)
VALUES
	(1),
	(2),
	(3),
	(4);

/*!40000 ALTER TABLE `EventTypes` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table Notifications
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Notifications`;

CREATE TABLE `Notifications` (
  `NotificationID` int(40) NOT NULL AUTO_INCREMENT,
  `Daily` int(40) NOT NULL DEFAULT '0',
  `Hourly` int(40) NOT NULL DEFAULT '0',
  `quarterHour` int(40) NOT NULL DEFAULT '0',
  PRIMARY KEY (`NotificationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Notifications` WRITE;
/*!40000 ALTER TABLE `Notifications` DISABLE KEYS */;

INSERT INTO `Notifications` (`NotificationID`, `Daily`, `Hourly`, `quarterHour`)
VALUES
	(1,1,1,1),
	(2,2,2,2),
	(3,3,2,2),
	(4,4,4,4);

/*!40000 ALTER TABLE `Notifications` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table Profile
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Profile`;

CREATE TABLE `Profile` (
  `UserID` int(40) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(100) NOT NULL DEFAULT '',
  `Password` varchar(100) DEFAULT NULL,
  `ViewTypeID` int(40) DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  KEY `ViewTypeID` (`ViewTypeID`),
  CONSTRAINT `profile_ibfk_1` FOREIGN KEY (`ViewTypeID`) REFERENCES `ViewID` (`ViewTypeID`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Profile` WRITE;
/*!40000 ALTER TABLE `Profile` DISABLE KEYS */;

INSERT INTO `Profile` (`UserID`, `UserName`, `Password`, `ViewTypeID`)
VALUES
	(9,'2coolivet','password',1),
	(10,'A1cialerce	','password',2),
	(11,'Acumeri	','password',3),
	(12,'Amporyok	','password',1),
	(13,'Appmaceti	','password',1),
	(14,'AttractiveNephew	','password',2),
	(15,'AuthorScan	','password',1),
	(16,'Aveloted	','password',2);

/*!40000 ALTER TABLE `Profile` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table ViewID
# ------------------------------------------------------------

DROP TABLE IF EXISTS `ViewID`;

CREATE TABLE `ViewID` (
  `ViewTypeID` int(40) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ViewTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `ViewID` WRITE;
/*!40000 ALTER TABLE `ViewID` DISABLE KEYS */;

INSERT INTO `ViewID` (`ViewTypeID`)
VALUES
	(1),
	(2),
	(3);

/*!40000 ALTER TABLE `ViewID` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
