CREATE VIEW `vw_heroe_per_ability` AS
    SELECT 
        `a`.`id` AS `ability_id`,
		`a`.`name` AS `ability_name`,
        COUNT(DISTINCT `ha`.`heroe_id`) AS `qty`,
        `a`.`type` AS `ability_type`
    FROM
        (`marvel_ability` `a`
        JOIN `marvel_heroe_ability` `ha` ON ((`a`.`id` = `ha`.`ability_id`)))
    GROUP BY  `a`.`id`, `a`.`name`, `a`.`type`
    ORDER BY `a`.`name`;