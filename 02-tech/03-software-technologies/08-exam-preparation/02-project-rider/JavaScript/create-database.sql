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


-- Dumping database structure for projectRider_js
CREATE DATABASE IF NOT EXISTS `projectRider_js` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `projectRider_js`;

-- Dumping structure for table projectRider_js.Projects
CREATE TABLE IF NOT EXISTS `Projects` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Budget` int(11) NOT NULL,
  `Description` text NOT NULL,
  `Title` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table projectRider_js.Projects: ~1 rows (approximately)
/*!40000 ALTER TABLE `Projects` DISABLE KEYS */;
INSERT INTO `Projects` (`Id`, `Budget`, `Description`, `Title`) VALUES
	(2, 122, 'Desca', 'Some titlea');
/*!40000 ALTER TABLE `Projects` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
