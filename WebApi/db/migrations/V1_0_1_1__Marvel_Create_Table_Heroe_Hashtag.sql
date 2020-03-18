CREATE TABLE  IF NOT EXISTS `marvel_heroe_hashtag` (
  `heroe_id` int(11) NOT NULL,
  `hashtag_id` int(11) NOT NULL,
  PRIMARY KEY (`heroe_id`,`hashtag_id`),
  CONSTRAINT `fk_marvel_heroe_hashtag_hashtag_id` FOREIGN KEY (`hashtag_id`) REFERENCES `marvel_hashtag` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_marvel_heroe_hashtag_heroe_id` FOREIGN KEY (`heroe_id`) REFERENCES `marvel_heroe` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;





