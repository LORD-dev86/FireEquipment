--DROP FUNCTION te_select();
create or replace function te_select()
returns table 
(
	Номер integer,
	Название varchar(255),
	Объём integer,
	Масса integer,
	Полезная_масса integer,
	Лицензия varchar(255),
    Описание text
)as 
$$
begin
	return query select te_id, te_name, te_size, te_weight,
	te_rweight, te_licence, te_desc from typeeq order by te_id;
end
$$
language plpgsql;


--DROP FUNCTION mt_select();
create or replace function mt_select()
returns table 
(
	Номер integer,
	Название varchar(255),
    Описание text
)as 
$$
begin
	return query select mt_id, mt_name,
	mt_desc from mtypeeq order by mt_id;
end
$$
language plpgsql;

--DROP FUNCTION ct_select();
create or replace function ct_select()
returns table 
(
	Номер integer,
	Название varchar(255),
    Описание text
)as 
$$
begin
	return query select ct_id, ct_name, ct_desc 
	from checktype order by ct_id;
end
$$
language plpgsql;

select * from ct_select()

--DROP FUNCTION dp_select();
create or replace function dp_select()
returns table 
(
	Номер integer,
	Название text
)as 
$$
begin
	return query select dp_id, dp_desc 
		   from department order by dp_id;
end
$$
language plpgsql;

--DROP FUNCTION pl_select();
create or replace function pl_select()
returns table 
(
	Номер integer,
	Отдел integer,
	Описание text
	
)as 
$$
begin
	return query select pl_id, pl_iddep, pl_desc 
        from placement order by pl_id;
end
$$
language plpgsql;

select * from pl_select()

--drop function te_insert;
create or replace function te_insert (_te_id integer, _te_name varchar (255), 
_te_size integer, _te_weight integer, _te_rweight integer, _te_licence varchar(255),
_te_desc text)
returns int as
$$
begin
	insert into typeeq (te_id, te_name, te_size, te_weight, te_rweight, 
	te_licence, te_desc)
	values (_te_id, _te_name, _te_size, _te_weight, _te_rweight, _te_licence,_te_desc);
	if found then 
		return 0; --succsess
	else
		return 1; --fail
	end if;
end 
$$
language plpgsql;

select * from te_insert(3, 'тест'::varchar(255), 10, 15, 13, 
						'ГОСТ159'::varchar(255), 'тест записи'::text);
select * from te_select(); 

--drop function mt_insert;
create or replace function mt_insert (_mt_id integer, _mt_name varchar (255),
_mt_desc text)
returns int as
$$
begin
	insert into mtypeeq (mt_id, mt_name, mt_desc)
	values (_mt_id, _mt_name, _mt_desc);
	if found then 
		return 0; --succsess
	else
		return 1; --fail
	end if;
end 
$$
language plpgsql;

select * from mt_insert(3, 'тест', 'тестовая запись');
select * from mt_select();

--drop function ct_insert;
create or replace function ct_insert (_ct_id integer, _ct_name varchar (255),
_ct_desc text)
returns int as
$$
begin
	insert into checktype (ct_id, ct_name, ct_desc)
	values (_ct_id, _ct_name, _ct_desc);
	if found then 
		return 0; --succsess
	else
		return 1; --fail
	end if;
end 
$$
language plpgsql;

select * from ct_insert(3, 'тест', '2023-02-16','тестовая запись');
select * from ct_select();


create or replace function dp_insert (_dp_id integer, _dp_desc text)
returns int as
$$
begin
	insert into department (dp_id, dp_desc)
	values (_dp_id, _dp_desc);
	if found then 
		return 0; --succsess
	else
		return 1; --fail
	end if;
end 
$$
language plpgsql;

create or replace function pl_insert (_pl_id integer, _pl_iddep integer, _pl_desc text)
returns int as
$$
begin
	insert into placement (pl_id, pl_iddep, pl_desc)
	values (_pl_id, _pl_iddep, _pl_desc);
	if found then 
		return 0; --succsess
	else
		return 1; --fail
	end if;
end 
$$
language plpgsql;

create or replace function te_update (_te_id integer, _te_name varchar (255), 
_te_size integer, _te_weight integer, _te_rweight integer, 
_te_licence varchar(255), _te_desc text)
returns int as
$$
begin
update typeeq
	set
		te_id = _te_id,
		te_name = _te_name,
		te_size = _te_size,
		te_weight = _te_weight,
		te_rweight = _te_rweight,
		te_licence = _te_licence,
		te_desc = _te_desc 
	where te_id = _te_id;
	if found then return 0;
	else return 1;
	end if;
end 
$$
language plpgsql;

drop function mt_update;
create or replace function mt_update (_mt_id integer, _mt_name varchar (255),
_mt_desc text)
returns int as
$$
begin
update mtypeeq 
	set
		mt_id = _mt_id,
		mt_name = _mt_name,
		mt_desc = _mt_desc 
	where mt_id = _mt_id;
	if found then return 0;
	else return 1;
	end if;
end 
$$
language plpgsql;

drop function ct_update;
create or replace function ct_update (_ct_id integer, 
_ct_name varchar (255), _ct_desc text)
returns int as
$$
begin
update checktype
set
		ct_id = _ct_id,
		ct_name = _ct_name,
		ct_desc = _ct_desc
where
	ct_id = _ct_id;

if found then return 0;
else return 1;
end if;
end 
$$
language plpgsql;

select * from checktype c ;
DELETE FROM Checktype WHERE ct_id = :_index

create or replace function dp_update (_dp_id integer, _dp_desc text)
returns int as
$$
begin
update department
set
		dp_id = _dp_id,
		dp_desc = _dp_desc
where
	dp_id = _dp_id;

if found then return 0;
else return 1;
end if;
end 
$$
language plpgsql;

create or replace function pl_update (_pl_id integer, 
_pl_iddep integer, _pl_desc text)
returns int as
$$
begin
update placement 
set
		pl_id = _pl_id,
		pl_iddep = _pl_iddep,
		pl_desc = _pl_desc
where
	pl_id = _pl_id;

if found then return 0;
else return 1;
end if;
end 
$$
language plpgsql;

