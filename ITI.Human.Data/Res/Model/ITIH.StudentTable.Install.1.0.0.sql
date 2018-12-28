﻿create table ITIH.tStudent (
	StudentId int not null identity(0, 1),
	UserId int not null,
	SemesterId int not null

	constraint PK_tStudent_StudentId primary key (StudentId),
	constraint FK_tStudent_UserId foreign key (UserId) references CK.tUser (UserId),
	constraint FK_tStudent_SemesterId foreign key (SemesterId) references ITIH.tSemester (SemesterId)
);

insert into ITIH.tStudent (UserId, SemesterId) values (0, 0);