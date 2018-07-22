-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.31-MariaDB - Source distribution
-- Server OS:                    Linux
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for blogjs2
CREATE DATABASE IF NOT EXISTS `blogjs2` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `blogjs2`;

-- Dumping structure for table blogjs2.Articles
CREATE TABLE IF NOT EXISTS `Articles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `content` varchar(255) NOT NULL,
  `date` datetime NOT NULL,
  `authorId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `authorId` (`authorId`),
  CONSTRAINT `Articles_ibfk_1` FOREIGN KEY (`authorId`) REFERENCES `Users` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;

-- Dumping data for table blogjs2.Articles: ~29 rows (approximately)
/*!40000 ALTER TABLE `Articles` DISABLE KEYS */;
INSERT INTO `Articles` (`id`, `title`, `content`, `date`, `authorId`) VALUES
	(1, 'xx', '12', '2018-07-19 09:13:38', 1),
	(2, 'Articles', 'Namr r', '2018-07-19 09:39:08', 2),
	(3, 'qweq', 'qweq', '2018-07-19 10:05:14', 2),
	(4, 'sdd', 'dd', '2018-07-19 10:57:41', 4),
	(7, 'Vredata ot vrednata hrana', 'Lorem ipsum dolor sit amest consectetur adipisicing elit. Incidunt voluptatem accusamus ullam pariatur fuga ad suscipit, odio unde dignissimos distinctio earum in voluptate reiciendis, est officiis atque. Aut, nulla itaque?Lorem ipsum dolor sit amest cons', '2018-07-20 08:58:59', 5),
	(8, 'asdadasdasda', 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Incidunt voluptatem accusamus ullam pariatur fuga ad suscipit, odio unde dignissimos distinctio earum in voluptate reiciendis, est officiis atque. Aut, nulla itaque?', '2018-07-20 08:59:43', 5),
	(10, '44', '44', '2018-07-20 18:52:03', 5),
	(11, 'New', 'Article', '2018-07-20 21:08:26', 2),
	(12, 'test', 'test', '2018-07-21 08:30:12', 5),
	(13, 'test', 'test', '2018-07-21 08:30:14', 5),
	(14, 'test', 'test', '2018-07-21 08:30:16', 5),
	(15, 'test', 'test', '2018-07-21 08:30:18', 5),
	(16, 'test', 'test', '2018-07-21 08:30:20', 5),
	(17, 'test', 'test', '2018-07-21 08:30:22', 5),
	(18, 'test', 'test', '2018-07-21 08:30:26', 5),
	(19, 'test', 'test', '2018-07-21 08:30:28', 5),
	(20, 'test', 'test', '2018-07-21 08:30:30', 5),
	(21, 'test', 'test', '2018-07-21 08:30:32', 5),
	(22, 'test', 'test', '2018-07-21 08:30:34', 5),
	(23, 'test', 'test', '2018-07-21 08:30:36', 5),
	(24, 'test', 'test', '2018-07-21 08:30:53', 5),
	(25, 'test', 'test', '2018-07-21 08:32:05', 5),
	(26, 'test', 'test', '2018-07-21 08:32:31', 5),
	(27, 'test', 'test', '2018-07-21 08:33:39', 5),
	(28, 'test', 'test', '2018-07-21 08:33:43', 5),
	(29, 'test', 'test', '2018-07-21 08:33:47', 5),
	(30, 'test', 'test', '2018-07-21 08:33:50', 5),
	(31, 'test', 'test', '2018-07-21 08:33:52', 5),
	(32, 'test', 'test', '2018-07-21 08:35:23', 5),
	(33, 'y', 'y', '2018-07-21 08:47:51', 5),
	(34, 'y', 'y', '2018-07-21 08:47:53', 5),
	(35, 'Lorem is not ipsum', 'This true?', '2018-07-21 11:33:31', 2);
/*!40000 ALTER TABLE `Articles` ENABLE KEYS */;

-- Dumping structure for table blogjs2.Comments
CREATE TABLE IF NOT EXISTS `Comments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `content` varchar(255) NOT NULL,
  `date` datetime NOT NULL,
  `articleId` int(11) DEFAULT NULL,
  `authorId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `articleId` (`articleId`),
  KEY `authorId` (`authorId`),
  CONSTRAINT `Comments_ibfk_1` FOREIGN KEY (`articleId`) REFERENCES `Articles` (`id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `Comments_ibfk_2` FOREIGN KEY (`authorId`) REFERENCES `Users` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;

-- Dumping data for table blogjs2.Comments: ~23 rows (approximately)
/*!40000 ALTER TABLE `Comments` DISABLE KEYS */;
INSERT INTO `Comments` (`id`, `content`, `date`, `articleId`, `authorId`) VALUES
	(1, 'das', '2018-07-19 09:24:27', 1, 2),
	(2, 'ddddd', '2018-07-19 09:37:40', 1, 2),
	(3, 'd', '2018-07-19 09:47:19', 2, 2),
	(4, 'Tjis sjot sj=uucls!', '2018-07-19 09:47:36', 2, 2),
	(5, 'sssssssssss', '2018-07-19 09:48:36', 2, 3),
	(8, 'qweqwe', '2018-07-19 10:04:58', 2, 2),
	(9, 'daaaaaaaaaaas', '2018-07-19 10:49:22', 3, 2),
	(10, 'asd', '2018-07-19 10:57:57', 3, 2),
	(11, 'd', '2018-07-19 11:13:22', NULL, 2),
	(12, 'Ne e istina!\r\nLyje6!!!!!be', '2018-07-20 09:00:39', 7, 5),
	(13, 'Ne e istina!\r\nLyje6!!!!!be', '2018-07-20 09:02:48', 7, 5),
	(14, 'This is great!', '2018-07-20 14:41:56', 1, 5),
	(15, 'adasdasd', '2018-07-20 18:34:13', 7, 2),
	(16, 'a', '2018-07-20 18:37:17', 8, 5),
	(17, 'a', '2018-07-20 18:37:55', 8, 5),
	(18, 'ff', '2018-07-20 18:46:31', 8, 5),
	(19, 'art', '2018-07-20 18:52:55', 2, 5),
	(20, 'das', '2018-07-20 18:53:49', 2, 5),
	(21, 'das', '2018-07-20 18:55:08', 2, 5),
	(22, 'ff', '2018-07-20 18:55:19', 8, 5),
	(23, 'ds', '2018-07-20 18:55:53', 8, 5),
	(24, 'dada', '2018-07-20 18:56:15', 8, 5),
	(32, 'DO IT!!!!', '2018-07-20 21:04:22', 1, 5),
	(33, 'This', '2018-07-21 11:31:15', 14, 5),
	(34, 'Yes.', '2018-07-21 11:34:04', 35, 2),
	(35, 'No true, you dum', '2018-07-21 11:35:52', 35, 5);
/*!40000 ALTER TABLE `Comments` ENABLE KEYS */;

-- Dumping structure for table blogjs2.Users
CREATE TABLE IF NOT EXISTS `Users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(255) NOT NULL,
  `passwordHash` varchar(255) DEFAULT NULL,
  `fullName` varchar(255) DEFAULT NULL,
  `salt` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Dumping data for table blogjs2.Users: ~4 rows (approximately)
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` (`id`, `email`, `passwordHash`, `fullName`, `salt`) VALUES
	(1, 'mail', '51cfc03eb06b470dd223aff4c6f3c24ab0d65400cc350db70198d47df88e3829', 'name', 'F1FXvxtgOw55KieqYWVSpFDR8apJPL3Hxzbtl7qyURdwOjtzbftj8o0NZUDL+bpTnkyhaR+iIKTfpxdqO46kmsuJR01u3fQnoEp+yO4YMx4PyzA8JcM6+xAe4yFZVnCnQYb52xnNc8PYrne7c0A2PScuYzsDFoTuV/7+Z/0kHmM='),
	(2, 'das', '26148293a492da02d1874bf0d447cc60b007b0834ce6f4e12ea4c96b726bfd3e', 'sad', 'a8jOQ7rB0YLyKgWv7BPMIM1Bdbvc2UmJ0A1ducjnGUeQpQrRtFtWAY+YfYCdtyxvWw6hF4/GRSvqa5uumQi6h9VpML4Jx0kOM4IJeeuAJwnKR1kNjf4RxTup3il3AMkpbXE1oC9sMhM90FOfcRIYZWka/M1KEvzqJFAk+ABrQJw='),
	(3, 'asdasdasd', 'e7b39b34f7f375ef45506644aa76f12a4f1741ed9b0e8b5ff5c6b03e46c49c08', 'asdasdas', 'T7TASetUfTxeLWOH7oEyzqWNXtov242U87hICTRkFjhbPPzzdN6ygRtMdZdWVPRTiYHFV4lsqsPDt5auM6u12Heyb5CNjLo3NO9B2gmg/QQkN1DSlQjuLrcCZ7XGc38DSOxqjebMyNPTAZZa9iz2ODQJFg7ibXUi2cazOO6stPU='),
	(4, 'dasc', '5ebf12f0ccb5bbed898239d5c27967a80b40aa267f0ea38fb00eb81383c899ef', 'xcvxv', '0BIP/3TerrDmcBx5Uko946NmZXn54LoMmCrlwmo7fS97T1SGaGezmucjP5qUL35+AzmK3yXjxUV6NXmqcSsuiqaXIa0I5mKvq36IU0cqrR31hzWe60EpjePcdu811dSQZN/cQaequmeUziz8oScsyrLwN80QTLLcN9GgE2nESHo='),
	(5, 'babait52', '9edeb4a188825f094562ce21bbae85af842e13b13d2f509a2a19dee232f1124e', 'Sashona', 'PBNdrYqHX/wcPlsvDPn8ZayHziqMPZqWJ3EVgnhB+X5ogbrlDmNY91s9H87eTYFx539xKh3qvqqdxkMUIKs53VQaL/YPec5eJctqrgRxPkhuIV2mxCOKWfPsA+isndYdb/4qERUQ05kVhSaFg0Zdj8X+BINysNXdklt0iCP0dWU='),
	(6, 'sss', '672a50395516a433eafd24240294572ca494b7c53e0f349fff570f7f0034378b', '1', 'PGmzaC3mwcN/QjSXUQxUYp4hxDEa/GjKI8hYOzoe3Sf+QN0QY/NJlp4J2Y1VwGSDDT3fPMA/3FZCzve2s21BADZMNMuHDIoFfrQdV1z/nnIV3giPI4po1SPrPBzXf9ueugdXECnJ+iCcD1nPhwK9TX1jXbcpo8HLz4fryI2AGKI=');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
