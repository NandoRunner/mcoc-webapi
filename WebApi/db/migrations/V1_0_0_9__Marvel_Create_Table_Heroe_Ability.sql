CREATE TABLE  IF NOT EXISTS `marvel_heroe_ability` (
  `heroe_id` int(11) NOT NULL,
  `ability_id` int(11) NOT NULL,
  `type` int(1) NOT NULL,
  PRIMARY KEY (`heroe_id`,`ability_id`, `type`),
  CONSTRAINT `fk_marvel_heroe_ability_ability_id` FOREIGN KEY (`ability_id`) REFERENCES `marvel_ability` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_marvel_heroe_ability_heroe_id` FOREIGN KEY (`heroe_id`) REFERENCES `marvel_heroe` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;