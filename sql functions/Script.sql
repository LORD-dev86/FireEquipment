--основная таблица со сведениями об огнетушителях
DROP TABLE Equipment;
CREATE TABLE Equipment
(
	eq_id SERIAL PRIMARY KEY,
	eq_type integer,
	eq_mtype integer, --FK
	eq_releaser varchar(255),
	eq_releasedate date,
	eq_currcheck integer,--FK
	eq_begincheck date,
	eq_reloaddate date,
	eq_beginreloaddate date,
	eq_department integer,--FK
	eq_placement integer,
	eq_mark boolean,
	
	foreign key (eq_type) references Typeeq (te_id),
	foreign key (eq_mtype) references MTypeeq (mt_id),
	foreign key (eq_currcheck) references checking (ch_id),
	foreign key (eq_department) references department (dp_id),
	foreign key (eq_placement) references placement(pl_id)
);

--таблмица проверок СПЗ
DROP TABLE Checking cascade;
CREATE TABLE Checking
(
	ch_id SERIAL PRIMARY KEY,
	ch_type integer, --FK
	ch_checkdate date,
	ch_department integer, --FK
	ch_checkresult text,
	ch_desc text,
	
	foreign key (ch_type) references Checktype (ct_id),
	foreign key (ch_department) references department (dp_id)
);


--таблица типов объектов
drop table Typeeq cascade;
create table Typeeq
(
	te_id serial primary key,
	te_name varchar(255),
	te_size integer, --объем в м3
	te_weight integer,
	te_rweight integer,
	te_licence varchar(255),
	te_desc text
);

--таблица подтипов объектов
drop table MTypeeq cascade;
create table MTypeeq
(
	mt_id serial primary key,
	mt_name varchar(255),
	mt_desc text
);


--таблица типов проверок
drop table Checktype cascade;
create table Checktype
(
	ct_id serial primary key,
	ct_name varchar (255),
	ct_desc text
);

--таблица отделов
drop table department cascade;
create table department
(
	dp_id integer primary key,
	dp_desc text,
	dp_eqdoc varchar(255),
	dp_chdoc varchar(255)
);

select * from get_chdoc(23)

--таблица мест расположения
drop table placement cascade;
create table placement 
(
	pl_id serial primary key,
	pl_iddep integer,
	pl_desc text,
	
	foreign key (pl_iddep)
	references department (dp_id)
);
