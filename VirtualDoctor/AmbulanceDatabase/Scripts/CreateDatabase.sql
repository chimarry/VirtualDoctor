-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema ambulance
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `ambulance` ;

-- -----------------------------------------------------
-- Schema ambulance
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ambulance` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_520_ci ;
USE `ambulance` ;

-- -----------------------------------------------------
-- Table `ambulance`.`place`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`place` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`place` (
  `IdPlace` INT(11) NOT NULL AUTO_INCREMENT,
  `DrinkingWaterQuality` INT(11) NOT NULL,
  `FoodQuality` INT(11) NOT NULL,
  `RecreationalWaterQuality` INT(11) NOT NULL,
  `AirQuality` INT(11) NOT NULL,
  `InlandWaterQuality` INT(11) NOT NULL,
  `TerrainQuality` INT(11) NOT NULL,
  `MedicalVasteInformation` INT(11) NOT NULL,
  `NoiseInformation` INT(11) NOT NULL,
  `Radiation` INT(11) NOT NULL,
  `Name` VARCHAR(255) NOT NULL,
  `CountryName` VARCHAR(255) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  `PostalCode` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`IdPlace`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`clinic`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`clinic` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`clinic` (
  `IdClinic` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NOT NULL,
  `IdPlace` INT(11) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdClinic`),
  INDEX `fk_CLINIC_PLACE2_idx` (`IdPlace` ASC) VISIBLE,
  CONSTRAINT `fk_CLINIC_PLACE`
    FOREIGN KEY (`IdPlace`)
    REFERENCES `ambulance`.`place` (`IdPlace`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`disease`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`disease` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`disease` (
  `IdDisease` INT(11) NOT NULL AUTO_INCREMENT,
  `SerbianName` VARCHAR(255) NOT NULL,
  `LatinName` VARCHAR(255) NOT NULL,
  `IdDiseaseTypeICD` INT(11) NOT NULL,
  `Chronic` TINYINT(4) NOT NULL,
  `Genetic` TINYINT(4) NOT NULL,
  `Definition` VARCHAR(1000) NOT NULL,
  `Aliases` VARCHAR(4000) NULL DEFAULT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdDisease`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`local_account`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`local_account` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`local_account` (
  `IdLocalAccount` INT(11) NOT NULL AUTO_INCREMENT,
  `Email` VARCHAR(255) NOT NULL,
  `FullName` VARCHAR(255) NOT NULL,
  `PasswordHash` VARCHAR(255) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdLocalAccount`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`doctor`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`doctor` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`doctor` (
  `IdDoctor` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  `WorkExperience` INT(11) NOT NULL DEFAULT '0',
  `IdLocalAccount` INT(11) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdDoctor`),
  UNIQUE INDEX `UC_Doctor` (`Name` ASC, `LastName` ASC, `IdLocalAccount` ASC) VISIBLE,
  INDEX `fk_DOCTOR_LOCAL_ACCOUNT1_idx` (`IdLocalAccount` ASC) VISIBLE,
  CONSTRAINT `fk_DOCTOR_LOCAL_ACCOUNT1`
    FOREIGN KEY (`IdLocalAccount`)
    REFERENCES `ambulance`.`local_account` (`IdLocalAccount`))
ENGINE = InnoDB
AUTO_INCREMENT = 14
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`doctor_clinic`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`doctor_clinic` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`doctor_clinic` (
  `UntilDate` DATE NULL DEFAULT NULL,
  `Since` DATE NOT NULL,
  `IdDoctor` INT(11) NOT NULL,
  `IdClinic` INT(11) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdDoctor`, `IdClinic`, `Since`),
  INDEX `fk_DOCTOR_CLINIC_CLINIC1_idx` (`IdClinic` ASC) VISIBLE,
  CONSTRAINT `fk_DOCTOR_CLINIC_CLINIC1`
    FOREIGN KEY (`IdClinic`)
    REFERENCES `ambulance`.`clinic` (`IdClinic`),
  CONSTRAINT `fk_DOCTOR_CLINIC_DOCTOR1`
    FOREIGN KEY (`IdDoctor`)
    REFERENCES `ambulance`.`doctor` (`IdDoctor`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`medical_title`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`medical_title` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`medical_title` (
  `IdMedicalTitle` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdMedicalTitle`),
  UNIQUE INDEX `name_UNIQUE` (`Name` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`doctor_medical_title`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`doctor_medical_title` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`doctor_medical_title` (
  `IdDoctor` INT(11) NOT NULL,
  `IdMedicalTitle` INT(11) NOT NULL,
  `GettingTitleDate` DATE NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdDoctor`, `IdMedicalTitle`),
  INDEX `fk_DOCTOR_has_DOCTOR_TYPE_DOCTOR_TYPE1_idx` (`IdMedicalTitle` ASC) VISIBLE,
  INDEX `fk_DOCTOR_has_DOCTOR_TYPE_DOCTOR1_idx` (`IdDoctor` ASC) VISIBLE,
  CONSTRAINT `fk_DOCTOR_has_DOCTOR_TYPE_DOCTOR1`
    FOREIGN KEY (`IdDoctor`)
    REFERENCES `ambulance`.`doctor` (`IdDoctor`),
  CONSTRAINT `fk_DOCTOR_has_DOCTOR_TYPE_DOCTOR_TYPE1`
    FOREIGN KEY (`IdMedicalTitle`)
    REFERENCES `ambulance`.`medical_title` (`IdMedicalTitle`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`medical_record`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`medical_record` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`medical_record` (
  `IdMedicalRecord` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  `JMB` CHAR(13) NOT NULL,
  `Gender` TINYINT(4) NOT NULL,
  `BirthDate` DATE NOT NULL,
  `BirthPlace` VARCHAR(255) NOT NULL,
  `MarriageStatus` TINYINT(4) NOT NULL,
  `MothersFullName` VARCHAR(100) NOT NULL,
  `FathersFullName` VARCHAR(100) NOT NULL,
  `MothersProfession` VARCHAR(255) NOT NULL,
  `FathersProfession` VARCHAR(255) NOT NULL,
  `InsuranceNumber` VARCHAR(45) NOT NULL,
  `IdResidence` INT(11) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdMedicalRecord`),
  UNIQUE INDEX `jmb_UNIQUE` (`JMB` ASC) VISIBLE,
  UNIQUE INDEX `insurance_number_UNIQUE` (`InsuranceNumber` ASC) VISIBLE,
  INDEX `fk_MEDICAL_RECORD_PLACE2_idx` (`IdResidence` ASC) VISIBLE,
  CONSTRAINT `fk_MEDICAL_RECORD_PLACE2`
    FOREIGN KEY (`IdResidence`)
    REFERENCES `ambulance`.`place` (`IdPlace`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`doctors_test_and_opinion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`doctors_test_and_opinion` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`doctors_test_and_opinion` (
  `IdDoctor` INT(11) NOT NULL,
  `IdMedicalRecord` INT(11) NOT NULL,
  `VisitingDate` DATE NOT NULL,
  `Anamnesis` VARCHAR(4000) NULL DEFAULT NULL,
  `DiagnosisDescription` VARCHAR(4000) NULL DEFAULT NULL,
  `Opinion` VARCHAR(4000) NOT NULL,
  `ControlTime` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdDoctor`, `IdMedicalRecord`, `VisitingDate`),
  INDEX `fk_DOCTORS_TEST_AND_OPINION_MEDICAL_RECORD1_idx` (`IdMedicalRecord` ASC) VISIBLE,
  CONSTRAINT `fk_DOCTORS_TEST_AND_OPINION_DOCTOR1`
    FOREIGN KEY (`IdDoctor`)
    REFERENCES `ambulance`.`doctor` (`IdDoctor`),
  CONSTRAINT `fk_DOCTORS_TEST_AND_OPINION_MEDICAL_RECORD1`
    FOREIGN KEY (`IdMedicalRecord`)
    REFERENCES `ambulance`.`medical_record` (`IdMedicalRecord`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`family_disease`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`family_disease` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`family_disease` (
  `IdDisease` INT(11) NOT NULL,
  `Chronic` TINYINT(4) NOT NULL,
  `Genetic` TINYINT(4) NOT NULL,
  `IdMedicalRecord` INT(11) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdDisease`, `IdMedicalRecord`),
  INDEX `fk_FAMILY_DISEASE_MEDICAL_RECORD1_idx` (`IdMedicalRecord` ASC) VISIBLE,
  CONSTRAINT `fk_FAMILY_DISEASE_MEDICAL_RECORD1`
    FOREIGN KEY (`IdMedicalRecord`)
    REFERENCES `ambulance`.`medical_record` (`IdMedicalRecord`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`role`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`role` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`role` (
  `IdRole` INT(11) NOT NULL AUTO_INCREMENT,
  `RoleName` VARCHAR(45) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdRole`),
  UNIQUE INDEX `RoleName_UNIQUE` (`RoleName` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 15
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`local_account_role`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`local_account_role` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`local_account_role` (
  `IdLocalAccount` INT(11) NOT NULL,
  `IdRole` INT(11) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdLocalAccount`, `IdRole`),
  INDEX `fk_LOCAL_ACCOUNT_has_ROLES_ROLES1_idx` (`IdRole` ASC) VISIBLE,
  INDEX `fk_LOCAL_ACCOUNT_has_ROLES_LOCAL_ACCOUNT1_idx` (`IdLocalAccount` ASC) VISIBLE,
  CONSTRAINT `fk_LOCAL_ACCOUNT_has_ROLES_LOCAL_ACCOUNT1`
    FOREIGN KEY (`IdLocalAccount`)
    REFERENCES `ambulance`.`local_account` (`IdLocalAccount`),
  CONSTRAINT `fk_LOCAL_ACCOUNT_has_ROLES_ROLES1`
    FOREIGN KEY (`IdRole`)
    REFERENCES `ambulance`.`role` (`IdRole`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`patient_disease`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`patient_disease` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`patient_disease` (
  `IdDoctor` INT(11) NOT NULL,
  `IdMedicalRecord` INT(11) NOT NULL,
  `VisitingDate` DATE NOT NULL,
  `IdDisease` INT(11) NOT NULL,
  `Chronic` TINYINT(4) NOT NULL,
  `Genetic` TINYINT(4) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  `AppreanceDate` DATE NOT NULL,
  PRIMARY KEY (`IdDoctor`, `IdMedicalRecord`, `VisitingDate`, `IdDisease`),
  INDEX `fk_DOCTORS_TEST_AND_OPINION_has_DISEASE_DISEASE1_idx` (`IdDisease` ASC) VISIBLE,
  INDEX `fk_DOCTORS_TEST_AND_OPINION_has_DISEASE_DOCTORS_TEST_AND_OP_idx` (`IdDoctor` ASC, `IdMedicalRecord` ASC, `VisitingDate` ASC) VISIBLE,
  CONSTRAINT `fk_DOCTORS_TEST_AND_OPINION_has_DISEASE_DISEASE1`
    FOREIGN KEY (`IdDisease`)
    REFERENCES `ambulance`.`disease` (`IdDisease`),
  CONSTRAINT `fk_DOCTORS_TEST_AND_OPINION_has_DISEASE_DOCTORS_TEST_AND_OPIN1`
    FOREIGN KEY (`IdDoctor` , `IdMedicalRecord` , `VisitingDate`)
    REFERENCES `ambulance`.`doctors_test_and_opinion` (`IdDoctor` , `IdMedicalRecord` , `VisitingDate`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`test_results`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`test_results` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`test_results` (
  `IdTestResults` INT(11) NOT NULL AUTO_INCREMENT,
  `TypeOfTest` VARCHAR(255) NOT NULL,
  `TestStructure` JSON NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdTestResults`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`patient_test_results`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`patient_test_results` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`patient_test_results` (
  `IdMedicalRecord` INT(11) NOT NULL,
  `IdTestResults` INT(11) NOT NULL,
  `DateWhenTaken` DATE NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdMedicalRecord`, `IdTestResults`),
  INDEX `fk_MEDICAL_RECORD_has_TEST_RESULTS_TEST_RESULTS1_idx` (`IdTestResults` ASC) VISIBLE,
  INDEX `fk_MEDICAL_RECORD_has_TEST_RESULTS_MEDICAL_RECORD1_idx` (`IdMedicalRecord` ASC) VISIBLE,
  CONSTRAINT `fk_MEDICAL_RECORD_has_TEST_RESULTS_MEDICAL_RECORD1`
    FOREIGN KEY (`IdMedicalRecord`)
    REFERENCES `ambulance`.`medical_record` (`IdMedicalRecord`),
  CONSTRAINT `fk_MEDICAL_RECORD_has_TEST_RESULTS_TEST_RESULTS1`
    FOREIGN KEY (`IdTestResults`)
    REFERENCES `ambulance`.`test_results` (`IdTestResults`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;


-- -----------------------------------------------------
-- Table `ambulance`.`prescription`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`prescription` ;

CREATE TABLE IF NOT EXISTS `ambulance`.`prescription` (
  `IdPrescription` INT(11) NOT NULL AUTO_INCREMENT,
  `ConsumationDetails` VARCHAR(255) NOT NULL,
  `DateOfPrescripting` DATETIME NOT NULL,
  `IdDisease` INT(11) NOT NULL,
  `DrugInn` VARCHAR(255) NOT NULL,
  `AppearanceDate` DATE NOT NULL,
  `IdDoctor` INT(11) NOT NULL,
  `Usability` VARCHAR(255) NOT NULL,
  `Deleted` TINYINT(4) NOT NULL DEFAULT '0',
  `IdDoctor1` INT(11) NOT NULL,
  `IdMedicalRecord` INT(11) NOT NULL,
  `VisitingDate` DATE NOT NULL,
  `IdDisease1` INT(11) NOT NULL,
  PRIMARY KEY (`IdPrescription`),
  INDEX `fk_PRESCRIPTION_DOCTOR1_idx` (`IdDoctor` ASC) VISIBLE,
  INDEX `fk_PRESCRIPTION_PATIENT_DISEASE1_idx` (`IdDoctor1` ASC, `IdMedicalRecord` ASC, `VisitingDate` ASC, `IdDisease1` ASC) VISIBLE,
  CONSTRAINT `fk_PRESCRIPTION_DOCTOR1`
    FOREIGN KEY (`IdDoctor`)
    REFERENCES `ambulance`.`doctor` (`IdDoctor`),
  CONSTRAINT `fk_PRESCRIPTION_PATIENT_DISEASE1`
    FOREIGN KEY (`IdDoctor1` , `IdMedicalRecord` , `VisitingDate` , `IdDisease1`)
    REFERENCES `ambulance`.`patient_disease` (`IdDoctor` , `IdMedicalRecord` , `VisitingDate` , `IdDisease`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_520_ci;

USE `ambulance` ;

-- -----------------------------------------------------
-- Placeholder table for view `ambulance`.`doctors_view`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ambulance`.`doctors_view` (`iddoctor` INT, `name` INT, `lastname` INT, `workexperience` INT, `deleted` INT, `IdLocalAccount` INT, `email` INT);

-- -----------------------------------------------------
-- Placeholder table for view `ambulance`.`medical_records_view`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ambulance`.`medical_records_view` (`idmedicalrecord` INT, `name` INT, `lastname` INT, `jmb` INT, `gender` INT, `birthdate` INT, `birthplace` INT, `marriagestatus` INT, `mothersfullname` INT, `fathersfullname` INT, `mothersprofession` INT, `fathersprofession` INT, `insurancenumber` INT, `idresidence` INT, `residencename` INT, `deleted` INT);

-- -----------------------------------------------------
-- procedure GetActiveLocalAccounts
-- -----------------------------------------------------

USE `ambulance`;
DROP procedure IF EXISTS `ambulance`.`GetActiveLocalAccounts`;

DELIMITER $$
USE `ambulance`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetActiveLocalAccounts`()
BEGIN
select l.IdLocalAccount,Email,FullName,PasswordHash,group_concat(r.RoleName) as Roles, l.Deleted from local_account l
left outer join local_account_role lr on lr.idlocalaccount = l.idlocalaccount
left outer join role r on r.idrole = lr.idrole
where l.deleted = 0 and lr.deleted = 0
group by l.IdLocalAccount;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure GetClinicsName
-- -----------------------------------------------------

USE `ambulance`;
DROP procedure IF EXISTS `ambulance`.`GetClinicsName`;

DELIMITER $$
USE `ambulance`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetClinicsName`(in IdClinicParam int)
BEGIN
select c.idclinic,p.IdPlace, concat( c.name,' : ',p.name) as ClinicsName from clinic c
inner join place p  on p.idplace = c.idplace
where idclinic = IdClinicParam;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure GetRolesWithIdLocalAccount
-- -----------------------------------------------------

USE `ambulance`;
DROP procedure IF EXISTS `ambulance`.`GetRolesWithIdLocalAccount`;

DELIMITER $$
USE `ambulance`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetRolesWithIdLocalAccount`(in IdLocalAccountParam int)
begin
select r.IdRole,r.RoleName,r.Deleted from role r
inner join local_account_role lr on r.idrole = lr.idrole
inner join local_account l on l.idlocalaccount = lr.idlocalaccount
where l.idlocalaccount = IdLocalAccountParam and lr.deleted = 0;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure GetTitlesName
-- -----------------------------------------------------

USE `ambulance`;
DROP procedure IF EXISTS `ambulance`.`GetTitlesName`;

DELIMITER $$
USE `ambulance`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetTitlesName`(in IdDoctorParam int, in IdMedicalTitleParam int)
BEGIN
select t.idmedicaltitle,d.iddoctor,t.name as TitlesName from doctor_medical_title d
inner join medical_title t on t.idmedicaltitle = d.idmedicaltitle
where d.iddoctor =IdDoctorParam and t.idmedicaltitle = IdMedicalTitleParam;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- View `ambulance`.`doctors_view`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`doctors_view`;
DROP VIEW IF EXISTS `ambulance`.`doctors_view` ;
USE `ambulance`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ambulance`.`doctors_view` AS select `d`.`IdDoctor` AS `iddoctor`,`d`.`Name` AS `name`,`d`.`LastName` AS `lastname`,`d`.`WorkExperience` AS `workexperience`,`d`.`Deleted` AS `deleted`,`l`.`IdLocalAccount` AS `IdLocalAccount`,`l`.`Email` AS `email` from (`ambulance`.`doctor` `d` join `ambulance`.`local_account` `l` on((`l`.`IdLocalAccount` = `d`.`IdLocalAccount`)));

-- -----------------------------------------------------
-- View `ambulance`.`medical_records_view`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ambulance`.`medical_records_view`;
DROP VIEW IF EXISTS `ambulance`.`medical_records_view` ;
USE `ambulance`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ambulance`.`medical_records_view` AS select `m`.`IdMedicalRecord` AS `idmedicalrecord`,`m`.`Name` AS `name`,`m`.`LastName` AS `lastname`,`m`.`JMB` AS `jmb`,`m`.`Gender` AS `gender`,`m`.`BirthDate` AS `birthdate`,`m`.`BirthPlace` AS `birthplace`,`m`.`MarriageStatus` AS `marriagestatus`,`m`.`MothersFullName` AS `mothersfullname`,`m`.`FathersFullName` AS `fathersfullname`,`m`.`MothersProfession` AS `mothersprofession`,`m`.`FathersProfession` AS `fathersprofession`,`m`.`InsuranceNumber` AS `insurancenumber`,`m`.`IdResidence` AS `idresidence`,concat(`p`.`Name`,' : ',`p`.`CountryName`) AS `residencename`,`m`.`Deleted` AS `deleted` from (`ambulance`.`medical_record` `m` join `ambulance`.`place` `p` on((`p`.`IdPlace` = `m`.`IdResidence`)));

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
