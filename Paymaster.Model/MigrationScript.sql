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
