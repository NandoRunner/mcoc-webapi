CREATE TABLE  IF NOT EXISTS `marvel_user_alliance` (
  `user_id` int(11) NOT NULL,
  `alliance_id` int(11) NOT NULL,
  `start_date` datetime NOT NULL,
  `end_date` datetime DEFAULT NULL,
  PRIMARY KEY (`user_id`,`alliance_id`),
  KEY `fk_marvel_user_alliance_alliance_id_idx` (`alliance_id`),
  CONSTRAINT `fk_marvel_user_alliance_alliance_id` FOREIGN KEY (`alliance_id`) REFERENCES `marvel_alliance` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_marvel_user_alliance_user_id` FOREIGN KEY (`user_id`) REFERENCES `marvel_user` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;





