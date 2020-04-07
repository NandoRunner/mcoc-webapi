select count(*), marvel_hashtag.name, marvel_hashtag.id
from marvel_heroe_hashtag
inner join marvel_hashtag on marvel_hashtag.id = marvel_heroe_hashtag.hashtag_id
/*
where name in ('small', 'medium', 'large', 'xlarge')
or name like '%size%'
*/ 
group by marvel_hashtag.name
order by 2;

update marvel_hashtag set name = 'S (Small)' where name  = 'small';
update marvel_hashtag set name = 'M (Medium)' where name = 'medium';
update marvel_hashtag set name = 'L (Large)' where name = 'large';
update marvel_hashtag set name = 'XL (XLarge)' where name  = 'xlarge';

delete from marvel_heroe_hashtag where hashtag_id in (151, 134, 160, 176, 177);
delete from marvel_hashtag where id in (177);

/*
21	large	152
70	medium	135
21	size: l	151
70	size: m	134
35	size: s	160
17	size: xl	176
35	small	161
16	xlarge	178
*/


