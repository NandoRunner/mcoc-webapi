ALTER TABLE `marvel_heroe_ability` 
DROP COLUMN `type`,
DROP PRIMARY KEY,
ADD PRIMARY KEY (`heroe_id`, `ability_id`);
