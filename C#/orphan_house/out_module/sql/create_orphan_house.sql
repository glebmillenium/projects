CREATE TABLE IF NOT EXISTS 
	`childrens` (
		`id` INT(12) NOT NULL AUTO_INCREMENT,
		`full_name` CHAR(255) NOT NULL,
		`birthday` DATE,
		`id_certificate` INT(12) NOT NULL,
		`id_passport` INT(12),
		`id_history` INT(12),
		`id_first_parent` INT(12),
		`id_second_parent` INT(12),
		PRIMARY KEY(`id`)
	);

CREATE TABLE IF NOT EXISTS
	`certificate` (
		`id_certificate` INT(12) NOT NULL,
		`code` INT(12) NOT NULL,
		`place_birth` CHAR(255) NOT NULL,
		`date_reg` DATE,
		PRIMARY KEY(`id_certificate`)
	);

CREATE TABLE IF NOT EXISTS
	`passport` (
		`id_passport` INT(12) NOT NULL,
		`p_series` INT(12) NOT NULL,
		`p_number` INT(12) NOT NULL,
		`who` CHAR(255) NOT NULL,
		`date_reg` DATE NOT NULL,
		`code` CHAR(11) NOT NULL,
		PRIMARY KEY(`id_passport`)
	);

CREATE TABLE IF NOT EXISTS
	`adult` (
		`id` INT(12) NOT NULL AUTO_INCREMENT,
		`id_passport` INT(12) NOT NULL,
		`full_name` CHAR(255) NOT NULL,
		`place_work` CHAR(255),
		`position_work` CHAR(255),
		`adress` CHAR(255) NOT NULL,
		`id_status` INT(1),
		PRIMARY KEY(`id`)
	);

CREATE TABLE IF NOT EXISTS
	`status` (
		`id` INT(1) NOT NULL,
		`description` CHAR(255) NOT NULL,
		PRIMARY KEY(`id`)
	);

CREATE TABLE IF NOT EXISTS
	`history` (
		`id_history` INT(12) AUTO_INCREMENT,
		`reason` CHAR(255),
		`behavior` CHAR(255),
		PRIMARY KEY(`id_history`)
	);
	
CREATE TABLE IF NOT EXISTS
	`auth` (
	`login` CHAR(255) NOT NULL,
	`password` CHAR(255) NOT NULL,
	`id` INT(12),
	`time_input` TIMESTAMP,
	PRIMARY KEY(`login`)
	);