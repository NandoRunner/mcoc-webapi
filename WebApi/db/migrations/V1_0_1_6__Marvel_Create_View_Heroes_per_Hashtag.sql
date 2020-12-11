CREATE VIEW `vw_heroe_per_hashtag` AS
    SELECT 
        `h`.`id` AS `hashtag_id`,
		`h`.`name` AS `hashtag_name`,
        COUNT(DISTINCT `hh`.`heroe_id`) AS `qty`
    FROM
        (`marvel_hashtag` `h`
        JOIN `marvel_heroe_hashtag` `hh` ON ((`h`.`id` = `hh`.`hashtag_id`)))
    GROUP BY  `h`.`id`, `h`.`name`
    ORDER BY `h`.`name`;