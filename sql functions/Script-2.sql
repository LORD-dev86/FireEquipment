--select data function 
DROP FUNCTION eq_select();
create or replace function eq_select()
returns table 
(
	Номер integer,
	Тип varchar(255),
	Подтип varchar(255),
	Производитель varchar(255),
	"Дата производства" date,
	"Последняя проверка" date,
	"Следующая проверка" date,
	"Дата перезарядки" date,
	"Следующая перезарядка" date,
	Подразделение integer,
	Расположение text, 
	Списан boolean
)as 
$$
begin
	return query select eq_id, te_name, mt_name, eq_releaser, eq_releasedate,
	ch_checkdate, eq_begincheck, eq_reloaddate,
	eq_beginreloaddate, eq_department, pl_desc, eq_mark 
	from equipment, typeeq, mtypeeq, checking, placement
	where te_id = eq_type and mt_id = eq_mtype and ch_id = eq_currcheck and pl_id = eq_placement order by eq_id;
end
$$
language plpgsql;

--insert function
create or replace function eq_insert (_eq_id integer, _eq_type varchar(255), 
_eq_mtype varchar(255), _eq_releaser varchar(255), _eq_releasedate date,
_eq_checkdate date, _eq_begincheckdate date, _eq_reloaddate date, 
_eq_beginreloaddate date, _eq_department integer, _eq_placement varchar(255),
_eq_mark boolean)
returns int as
$$
begin
	insert into equipment (eq_id, eq_type, eq_mtype, eq_releaser, eq_releasedate,
	eq_currcheck, eq_begincheck, eq_reloaddate, eq_beginreloaddate, eq_department, 
	eq_placement, eq_mark)
	values (_eq_id, 
		   (SELECT te_id FROM Typeeq WHERE typeeq.te_name = _eq_type), 
		   (SELECT mt_id FROM MTypeeq WHERE mtypeeq.mt_name  = _eq_mtype), 
		   _eq_releaser, _eq_releasedate,
		   (SELECT ch_id FROM Checking WHERE checking.ch_checkdate = _eq_checkdate and checking.ch_department = _eq_department), 
		   _eq_begincheckdate, _eq_reloaddate, _eq_beginreloaddate, _eq_department,
		   (SELECT pl_id FROM Placement WHERE placement.pl_desc = _eq_placement),
		   _eq_mark);
	if found then 
		return 0; --succsess
	else
		return 1; --fail
	end if;
end 
$$
language plpgsql;

--update function
create or replace function eq_update (_eq_id integer, _eq_type varchar(255), 
_eq_mtype varchar(255), _eq_releaser varchar(255), _eq_releasedate date,
_eq_checkdate date, _eq_begincheckdate date, _eq_reloaddate date, 
_eq_beginreloaddate date, _eq_department integer, _eq_placement varchar(255),
_eq_mark boolean)
returns int as
$$
begin
update equipment 
	set
		eq_id = _eq_id, 
		eq_type = (SELECT te_id FROM Typeeq WHERE typeeq.te_name = _eq_type), 
		eq_mtype = (SELECT mt_id FROM MTypeeq WHERE mtypeeq.mt_name  = _eq_mtype), 
		eq_releaser = _eq_releaser, 
		eq_releasedate = _eq_releasedate,
		eq_currcheck = (SELECT ch_id FROM Checking WHERE checking.ch_checkdate = _eq_checkdate and checking.ch_department = _eq_department),
		eq_begincheck = _eq_begincheckdate, 
		eq_reloaddate = _eq_reloaddate,
		eq_beginreloaddate = _eq_beginreloaddate,
		eq_department = _eq_department,
		eq_placement = (SELECT pl_id FROM Placement WHERE placement.pl_desc = _eq_placement),
		eq_mark = _eq_mark
	where eq_id = _eq_id;
	if found then return 0;
	else return 1;
	end if;
end 
$$
language plpgsql;