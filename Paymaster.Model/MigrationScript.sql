ALTER TABLE `paymaster_dev`.`timepunches` 
ADD COLUMN `dailyRate` DECIMAL(5,2) NULL AFTER `hours`;

ALTER TABLE `paymaster_dev`.`timepunches` 
CHANGE COLUMN `dailyrate` `dailyRate` DECIMAL(5,2) NULL DEFAULT NULL ;

ALTER TABLE `paymaster_dev`.`timepunches` 
CHANGE COLUMN `dailyRate` `dailyRate` TINYINT NULL DEFAULT NULL ,
ADD COLUMN `Hourlypayrate` DECIMAL(5,2) NULL DEFAULT NULL AFTER `hours`;


ALTER TABLE `paymaster_dev`.`employeechangelog` 
RENAME TO  `paymaster_dev`.`employeechangelogs` ;


ALTER TABLE `paymaster_dev`.`useraccess` 
RENAME TO  `paymaster_dev`.`useraccesses` ;


CREATE TABLE `tokens` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `AuthToken` varchar(255) DEFAULT NULL,
  `IssuedOn` datetime DEFAULT NULL,
  `ExpiresOn` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;
