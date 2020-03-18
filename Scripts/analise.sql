/*
SELECT DATE_ADD("2019-01-29", INTERVAL 137 DAY);

select * from vw_marvel_heroe_hashtag where hashtag like 'Offensive';
*/

select 
(select count(*) from marvel_ability) ability,
(select count(*) from marvel_hashtag) hashtag,
(select count(*) from marvel_heroe) heroe,
(select count(*) from marvel_heroe_ability) heroe_ability,
(select count(*) from marvel_heroe_hashtag) heroe_hashtag;

/*	ability	hashtag	heroe	heroe_ability	heroe_hashtag
	307		63		148		905				1263
*/

truncate table marvel_heroe_hashtag;
truncate table marvel_heroe_ability;
delete from marvel_ability;
delete from marvel_hashtag;
delete from marvel_heroe;




