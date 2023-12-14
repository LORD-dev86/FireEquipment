--select check function 
DROP FUNCTION ch_select();
create or replace function ch_select()
returns table 
(
	Номер integer,
	Тип varchar(255),
	Дата date,
	Подразделение integer,
	Результат text, 
	Описание text
)as 
$$
begin
	return query select ch_id, ct_name, ch_checkdate,
	ch_department, ch_checkresult, ch_desc
	from checking, checktype
	where ct_id = ch_type order by ch_id;
end
$$
language plpgsql;

--insert check function
drop function ch_insert;
create or replace function ch_insert (_ch_id integer, _ch_type varchar(255), 
_ch_checkdate date, _ch_department integer, _ch_checkresult text,
_ch_desc text)
returns int as
$$
begin
	insert into checking (ch_id, ch_type, ch_checkdate, 
	ch_department, ch_checkresult, ch_desc)
	values (_ch_id, (SELECT ct_id FROM Checktype WHERE checktype.ct_name = _ch_type), 
	_ch_checkdate, _ch_department, _ch_checkresult, _ch_desc);
	if found then 
		return 0; --succsess
	else
		return 1; --fail
	end if;
end 
$$
language plpgsql;

--update check function
create or replace function ch_update (_ch_id integer, _ch_type varchar(255), 
_ch_checkdate date, _ch_department integer, _ch_checkresult text,
_ch_desc text)
returns int as
$$
begin
update checking 
	set
		ch_id = _ch_id, 
		ch_type = (SELECT ct_id FROM Checktype WHERE checktype.ct_name = _ch_type), 
		ch_checkdate = _ch_checkdate, 
		ch_department = _ch_department, 
		ch_checkresult = _ch_checkresult,
		ch_desc = _ch_desc
	where ch_id = _ch_id;
	if found then return 0;
	else return 1;
	end if;
end 
$$
language plpgsql;

--get checking filepath
DROP FUNCTION get_chdoc(integer);
CREATE or replace FUNCTION get_chdoc(_dp_id integer)
RETURNS varchar(255) AS $$
DECLARE
    dp_chdoc_var varchar(255);
BEGIN
    SELECT dp_chdoc INTO dp_chdoc_var
    FROM department
    WHERE dp_id = _dp_id;
    
    RETURN dp_chdoc_var;
END;
$$ LANGUAGE plpgsql;

