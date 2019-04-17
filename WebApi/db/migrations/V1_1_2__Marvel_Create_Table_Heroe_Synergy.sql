CREATE TABLE IF NOT EXISTS `db_a3f268_myasp`.`marvel_heroe_synergy` (
  `heroe_parent_id` INT(11) NOT NULL,
  `heroe_child_id` INT(11) NOT NULL,
  `synergy_id` INT NOT NULL,
  PRIMARY KEY (`heroe_parent_id`, `heroe_child_id`, `synergy_id`),
  INDEX `fk_marvel_heroe_has_marvel_heroe_marvel_heroe2_idx` (`heroe_child_id` ASC),
  INDEX `fk_marvel_heroe_has_marvel_heroe_marvel_heroe1_idx` (`heroe_parent_id` ASC),
  INDEX `fk_marvel_heroe_synergy_marvel_synergy1_idx` (`synergy_id` ASC),
  CONSTRAINT `fk_marvel_heroe_has_marvel_heroe_marvel_heroe1`
    FOREIGN KEY (`heroe_parent_id`)
    REFERENCES `db_a3f268_myasp`.`marvel_heroe` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_marvel_heroe_has_marvel_heroe_marvel_heroe2`
    FOREIGN KEY (`heroe_child_id`)
    REFERENCES `db_a3f268_myasp`.`marvel_heroe` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_marvel_heroe_synergy_marvel_synergy1`
    FOREIGN KEY (`synergy_id`)
    REFERENCES `db_a3f268_myasp`.`marvel_synergy` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;