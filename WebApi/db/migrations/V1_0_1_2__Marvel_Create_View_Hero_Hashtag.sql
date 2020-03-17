CREATE VIEW `vw_marvel_heroe_hashtag` AS
    SELECT 
        `h`.`name` AS `heroi`,
        (CASE `h`.`class`
            WHEN 0 THEN 'Cosmic'
            WHEN 1 THEN 'Tech'
            WHEN 2 THEN 'Mutant'
            WHEN 3 THEN 'Skill'
            WHEN 4 THEN 'Science'
            WHEN 5 THEN 'Mystic'
            ELSE 'n/a'
        END) AS `class`,
        `ht`.`name` AS `hashtag`
    FROM
        ((`marvel_heroe` `h`
        JOIN `marvel_heroe_hashtag` `hh` ON ((`hh`.`heroe_id` = `h`.`id`)))
        JOIN `marvel_hashtag` `ht` ON ((`ht`.`id` = `hh`.`hashtag_id`)))
    ORDER BY 1 , 3;
