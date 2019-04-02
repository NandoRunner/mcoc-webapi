CREATE TABLE IF NOT EXISTS `mc_fil_filme` (
  `fil_filme_id` int(11) NOT NULL AUTO_INCREMENT,
  `fil_titulo` varchar(90) NOT NULL,
  `fil_titulo_original` varchar(90) DEFAULT NULL,
  `fil_ano` int(11) NOT NULL,
  `fil_rating` decimal(2,1) NOT NULL,
  `fil_dir_diretor_id` int(11) NOT NULL,
  `fil_visto` varchar(1) DEFAULT NULL,
  `fil_periodo` datetime DEFAULT NULL,
  `fil_update` datetime DEFAULT NULL,
  PRIMARY KEY (`fil_filme_id`,`fil_dir_diretor_id`),
  KEY `fk_mc_fil_filme_mc_dir_diretor_idx` (`fil_dir_diretor_id`),
  CONSTRAINT `fk_mc_fil_filme_mc_dir_diretor` FOREIGN KEY (`fil_dir_diretor_id`) REFERENCES `mc_dir_diretor` (`dir_diretor_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1433 DEFAULT CHARSET=utf8;
