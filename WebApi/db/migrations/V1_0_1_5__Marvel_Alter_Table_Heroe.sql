ALTER TABLE `marvel_heroe` 
ADD COLUMN `release_date` DATETIME NULL AFTER `class`,
ADD COLUMN `info_page` VARCHAR(200) NULL AFTER `release_date`,
ADD COLUMN `stars` VARCHAR(6) NULL AFTER `info_page`;
