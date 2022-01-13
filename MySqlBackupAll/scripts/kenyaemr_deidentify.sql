drop procedure if exists randomize_names;

delimiter $$
create procedure randomize_names()
begin
	set @size = (select max(person_name_id) from person_name);
	set @start = 0;
	set @stepsize = 300; 
	while @start < @size do
		update
			person_name
		set
			given_name = (select
									name
								from
									(select
										rid
										from
										random_names
										order by
										rand()
										limit 300
									) rid,
									random_names rn
								where	
									rid.rid = rn.rid
								order by
									rand()
								limit 1
							),
						middle_name = given_name,
						family_name = middle_name
		where
			person_name_id between @start and (@start + @stepsize);
		
		set @start = @start + @stepsize +1;
	end while;
end $$
delimiter ;

drop table if exists random_names;

CREATE TABLE `random_names` (
	`rid` int(11) NOT NULL auto_increment,
	`name` varchar(255) NOT NULL,
	PRIMARY KEY  (`rid`),
	UNIQUE KEY `name` (`name`),
	UNIQUE KEY `rid` (`rid`)
) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=utf8;

insert into random_names (name, rid) 
select distinct(trim(given_name)) as name, null from person_name where given_name is not null and not exists (select * from random_names where name = trim(given_name));
insert into random_names (name, rid) 
select distinct(trim(middle_name)) as name, null from person_name where middle_name is not null and not exists (select * from random_names where name = trim(middle_name));
insert into random_names (name, rid) 
select distinct(trim(family_name)) as name, null from person_name where family_name is not null and not exists (select * from random_names where name = trim(family_name));

call randomize_names();
drop procedure if exists randomize_names;

update 
	person_address
set
	address1 = concat(person_id, ' address1'),
	address2 = concat(person_id, ' address2'),
	latitude = null,
	longitude = null;

update location set name = concat('Location-', location_id);