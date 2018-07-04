-- 05 - Create Database
CREATE DATABASE `softuni`

-- 06 - Create Table Students
CREATE TABLE `students` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`Name` VARCHAR(50) NOT NULL,
	`Age` INT(11) NULL DEFAULT '0',
	PRIMARY KEY (`id`)
)
COLLATE='latin1_swedish_ci';

-- 07 - Drop Table
DROP TABLE `students`;

-- 08 - Drop Database
DROP DATABASE `softuni`;