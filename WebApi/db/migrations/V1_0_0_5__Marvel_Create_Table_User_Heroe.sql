CREATE TABLE IF NOT EXISTS `marvel_user_heroe` (
  `user_id` INT(11) NOT NULL,
  `heroe_id` INT(11) NOT NULL,
  `star` INT(1) NOT NULL,
  `rank` INT(1) NOT NULL,
  `level` INT(2) NOT NULL,
  `health` INT(5) NULL,
  `attack` INT(5) NULL,
  `signature` VARCHAR(45) NULL,
  PRIMARY KEY (`user_id`, `heroe_id`, `star`),
  INDEX `fk_marvel_user_heroe_marvel_user1_idx` (`user_id` ASC),
  INDEX `fk_marvel_user_heroe_marvel_heroe1_idx` (`heroe_id` ASC),
  CONSTRAINT `fk_marvel_user_heroe_marvel_user1`
    FOREIGN KEY (`user_id`)
    REFERENCES `marvel_user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_marvel_user_heroe_marvel_heroe1`
    FOREIGN KEY (`heroe_id`)
    REFERENCES `marvel_heroe` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;