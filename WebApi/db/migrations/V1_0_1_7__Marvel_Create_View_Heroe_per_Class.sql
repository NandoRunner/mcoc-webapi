CREATE VIEW `vw_heroe_per_class` AS
select class, 
(CASE class
            WHEN 0 THEN 'Cosmic'
            WHEN 1 THEN 'Tech'
            WHEN 2 THEN 'Mutant'
            WHEN 3 THEN 'Skill'
            WHEN 4 THEN 'Science'
            WHEN 5 THEN 'Mystic'
            ELSE 'n/a'
        END) AS "class_name",
count(*) "qty"
from marvel_heroe
group by class
ORDER BY 1;
