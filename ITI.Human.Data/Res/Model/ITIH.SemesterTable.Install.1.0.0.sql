﻿create table ITIH.tSemester (
	SemesterId int not null identity(0, 1),
	[Name] nvarchar(256)

	constraint PK_tSemester_SemesterId primary key (SemesterId)
);

insert into ITIH.tSemester ([Name]) values (N'');
insert into ITIH.tSemester ([Name]) values ('S1');
insert into ITIH.tSemester ([Name]) values ('S2');
insert into ITIH.tSemester ([Name]) values ('S3');
insert into ITIH.tSemester ([Name]) values ('S4');
insert into ITIH.tSemester ([Name]) values ('S5');
insert into ITIH.tSemester ([Name]) values ('S6');
insert into ITIH.tSemester ([Name]) values ('S7');
insert into ITIH.tSemester ([Name]) values ('S8');
insert into ITIH.tSemester ([Name]) values ('S9');
insert into ITIH.tSemester ([Name]) values ('S10');