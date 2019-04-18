CREATE TABLE IF NOT EXISTS `db_a3f268_myasp`.`marvel_synergy` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `all_bonus` VARCHAR(200) NULL,
  `star` int(1) NULL,
  `parent_bonus` VARCHAR(200) NULL,
  `child_bonus` VARCHAR(200) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB  AUTO_INCREMENT=1 
DEFAULT CHARACTER SET = utf8;