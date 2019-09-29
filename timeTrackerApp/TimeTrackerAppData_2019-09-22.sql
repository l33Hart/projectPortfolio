# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 5.7.25)
# Database: TimeTrackerAppData
# Generation Time: 2019-09-22 22:09:42 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table activity_categories
# ------------------------------------------------------------

DROP TABLE IF EXISTS `activity_categories`;

CREATE TABLE `activity_categories` (
  `activity_category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category_description` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`activity_category_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `activity_categories` WRITE;
/*!40000 ALTER TABLE `activity_categories` DISABLE KEYS */;

INSERT INTO `activity_categories` (`activity_category_id`, `category_description`)
VALUES
	(1,'	Converting SQL to JSON	'),
	(2,'	Five Star Rating	'),
	(3,'	Animated Bar Graphs	'),
	(4,'	Card Game	'),
	(5,'	Repo	'),
	(6,'	Time Tracker EER & Database	'),
	(7,'	Time Tracker App	'),
	(8,'	Time Tracker Sprint 1	'),
	(9,'	Time Tracker Sprint 2	'),
	(10,'	Time Tracker Sprint 3	'),
	(11,'	Time Tracker Visual Story	'),
	(12,'	Researched App Flowchart	'),
	(13,'	Custom App Flowchart	'),
	(14,'	Custom App Code & Database	'),
	(15,'	Custom App Presentation	'),
	(16,'	Visual Story 1	'),
	(17,'	Visual Story 2	'),
	(18,'	Visual Story 3	'),
	(19,'	Review Test	'),
	(20,'	No Access	');

/*!40000 ALTER TABLE `activity_categories` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table activity_descriptions
# ------------------------------------------------------------

DROP TABLE IF EXISTS `activity_descriptions`;

CREATE TABLE `activity_descriptions` (
  `activity_description_id` int(11) NOT NULL,
  `activity_description` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`activity_description_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `activity_descriptions` WRITE;
/*!40000 ALTER TABLE `activity_descriptions` DISABLE KEYS */;

INSERT INTO `activity_descriptions` (`activity_description_id`, `activity_description`)
VALUES
	(1,'Data Entry'),
	(2,'Coding'),
	(3,'Debugging'),
	(4,'Testing'),
	(5,'Uploading to FSO'),
	(6,'Reading Assignment'),
	(7,'Studying'),
	(8,'Thinking'),
	(9,'Staring at Computer Confused'),
	(10,'Writing'),
	(11,'Looking for Images'),
	(12,'Doing Assignment'),
	(13,'Logging Activity Times'),
	(14,'Recording Video'),
	(15,'Unable to access assignments'),
	(16,'Contacting Full Sail Support');

/*!40000 ALTER TABLE `activity_descriptions` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table activity_log
# ------------------------------------------------------------

DROP TABLE IF EXISTS `activity_log`;

CREATE TABLE `activity_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `calendar_day` int(11) DEFAULT NULL,
  `day_name` int(11) DEFAULT NULL,
  `category_description` int(11) DEFAULT NULL,
  `activity_description` int(11) DEFAULT NULL,
  `time_spent_on_activity` int(11) DEFAULT NULL,
  `calendar_date` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `timeSpent_idx` (`time_spent_on_activity`),
  KEY `dayOfWeek_idx` (`day_name`),
  KEY `user_idx` (`user_id`),
  KEY `numericalDay_idx` (`calendar_day`),
  KEY `date_idx` (`calendar_date`),
  KEY `activityCategory_idx` (`category_description`),
  KEY `activityDescription_idx` (`activity_description`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `activity_log` WRITE;
/*!40000 ALTER TABLE `activity_log` DISABLE KEYS */;

INSERT INTO `activity_log` (`id`, `user_id`, `calendar_day`, `day_name`, `category_description`, `activity_description`, `time_spent_on_activity`, `calendar_date`)
VALUES
	(2,1,6,6,6,13,1,6),
	(3,1,7,7,6,13,1,7),
	(4,1,7,7,1,7,2,7),
	(5,1,7,7,1,2,11,7),
	(6,1,8,1,1,2,5,8),
	(7,1,8,1,12,7,5,8),
	(8,1,9,2,12,7,5,9),
	(10,1,1,1,1,1,1,1),
	(11,1,1,1,1,1,1,1),
	(15,1,22,7,7,2,12,22);

/*!40000 ALTER TABLE `activity_log` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table activity_times
# ------------------------------------------------------------

DROP TABLE IF EXISTS `activity_times`;

CREATE TABLE `activity_times` (
  `activity_time_id` int(11) NOT NULL AUTO_INCREMENT,
  `time_spent_on_activity` double NOT NULL,
  PRIMARY KEY (`activity_time_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `activity_times` WRITE;
/*!40000 ALTER TABLE `activity_times` DISABLE KEYS */;

INSERT INTO `activity_times` (`activity_time_id`, `time_spent_on_activity`)
VALUES
	(1,0.25),
	(2,0.5),
	(3,0.75),
	(4,1),
	(5,1.25),
	(6,1.5),
	(7,1.75),
	(8,2),
	(9,2.25),
	(10,2.5),
	(11,2.75),
	(12,3),
	(13,3.25),
	(14,3.5),
	(15,3.75),
	(16,4),
	(17,4.25),
	(18,4.5),
	(19,4.75),
	(20,5),
	(21,5.25),
	(22,5.5),
	(23,5.75),
	(24,6),
	(25,6.25),
	(26,6.5),
	(27,6.75),
	(28,7),
	(29,7.25),
	(30,7.5),
	(31,7.75),
	(32,8),
	(33,8.25),
	(34,8.5),
	(35,8.75),
	(36,9),
	(37,9.25),
	(38,9.5),
	(39,9.75),
	(40,10),
	(41,10.25),
	(42,10.5),
	(43,10.75),
	(44,11),
	(45,11.25),
	(46,11.5),
	(47,11.75),
	(48,12),
	(49,12.25),
	(50,12.5),
	(51,12.75),
	(52,13),
	(53,13.25),
	(54,13.5),
	(55,13.75),
	(56,14),
	(57,14.25),
	(58,14.5),
	(59,14.75),
	(60,15),
	(61,15.25),
	(62,15.5),
	(63,15.75),
	(64,16),
	(65,16.25),
	(66,16.5),
	(67,16.75),
	(68,17),
	(69,17.25),
	(70,17.5),
	(71,17.75),
	(72,18),
	(73,18.25),
	(74,18.5),
	(75,18.75),
	(76,19),
	(77,19.25),
	(78,19.5),
	(79,19.75),
	(80,20),
	(81,20.25),
	(82,20.5),
	(83,20.75),
	(84,21),
	(85,21.25),
	(86,21.5),
	(87,21.75),
	(88,22),
	(89,22.25),
	(90,22.5),
	(91,22.75),
	(92,23),
	(93,23.25),
	(94,23.5),
	(95,23.75),
	(96,24);

/*!40000 ALTER TABLE `activity_times` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table days_of_week
# ------------------------------------------------------------

DROP TABLE IF EXISTS `days_of_week`;

CREATE TABLE `days_of_week` (
  `day_id` int(11) NOT NULL AUTO_INCREMENT,
  `day_name` varchar(10) NOT NULL,
  PRIMARY KEY (`day_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `days_of_week` WRITE;
/*!40000 ALTER TABLE `days_of_week` DISABLE KEYS */;

INSERT INTO `days_of_week` (`day_id`, `day_name`)
VALUES
	(1,'	Monday	'),
	(2,'	Tuesday	'),
	(3,'	Wednesday'),
	(4,'	Thursday	'),
	(5,'	Friday	'),
	(6,'	Saturday	'),
	(7,'	Sunday	');

/*!40000 ALTER TABLE `days_of_week` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table time_tracker_users
# ------------------------------------------------------------

DROP TABLE IF EXISTS `time_tracker_users`;

CREATE TABLE `time_tracker_users` (
  `user_id` int(11) NOT NULL,
  `user_password` varchar(10) NOT NULL,
  `user_firstname` varchar(25) NOT NULL,
  `user_lastname` varchar(25) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `time_tracker_users` WRITE;
/*!40000 ALTER TABLE `time_tracker_users` DISABLE KEYS */;

INSERT INTO `time_tracker_users` (`user_id`, `user_password`, `user_firstname`, `user_lastname`)
VALUES
	(1,'password','Lee','Hart');

/*!40000 ALTER TABLE `time_tracker_users` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table tracked_calendar_dates
# ------------------------------------------------------------

DROP TABLE IF EXISTS `tracked_calendar_dates`;

CREATE TABLE `tracked_calendar_dates` (
  `calendar_date_id` int(11) NOT NULL AUTO_INCREMENT,
  `calendar_date` date NOT NULL,
  PRIMARY KEY (`calendar_date_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `tracked_calendar_dates` WRITE;
/*!40000 ALTER TABLE `tracked_calendar_dates` DISABLE KEYS */;

INSERT INTO `tracked_calendar_dates` (`calendar_date_id`, `calendar_date`)
VALUES
	(1,'2019-09-02'),
	(2,'2019-09-03'),
	(3,'2019-09-04'),
	(4,'2019-09-05'),
	(5,'2019-09-06'),
	(6,'2019-09-07'),
	(7,'2019-09-08'),
	(8,'2019-09-09'),
	(9,'2019-09-10'),
	(10,'2019-09-11'),
	(11,'2019-09-12'),
	(12,'2019-09-13'),
	(13,'2019-09-14'),
	(14,'2019-09-15'),
	(15,'2019-09-16'),
	(16,'2019-09-17'),
	(17,'2019-09-18'),
	(18,'2019-09-19'),
	(19,'2019-09-20'),
	(20,'2019-09-21'),
	(21,'2019-09-22'),
	(22,'2019-09-23'),
	(23,'2019-09-24'),
	(24,'2019-09-25'),
	(25,'2019-09-26'),
	(26,'2019-09-27'),
	(27,'2019-09-28'),
	(28,'2019-09-29');

/*!40000 ALTER TABLE `tracked_calendar_dates` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table tracked_calendar_days
# ------------------------------------------------------------

DROP TABLE IF EXISTS `tracked_calendar_days`;

CREATE TABLE `tracked_calendar_days` (
  `calendar_day_id` int(11) NOT NULL AUTO_INCREMENT,
  `calendar_numerical_day` int(11) NOT NULL,
  PRIMARY KEY (`calendar_day_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `tracked_calendar_days` WRITE;
/*!40000 ALTER TABLE `tracked_calendar_days` DISABLE KEYS */;

INSERT INTO `tracked_calendar_days` (`calendar_day_id`, `calendar_numerical_day`)
VALUES
	(1,1),
	(2,2),
	(3,3),
	(4,4),
	(5,5),
	(6,6),
	(7,7),
	(8,8),
	(9,9),
	(10,10),
	(11,11),
	(12,12),
	(13,13),
	(14,14),
	(15,15),
	(16,16),
	(17,17),
	(18,18),
	(19,19),
	(20,20),
	(21,21),
	(22,22),
	(23,23),
	(24,24),
	(25,25),
	(26,26),
	(27,27),
	(28,28);

/*!40000 ALTER TABLE `tracked_calendar_days` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
