﻿create table ITIH.tProjectVotes (
	ProjectVoteId int not null identity(0, 1),
	ProjectId int not null,
	UserId int not null,
	Note int not null

	constraint PK_tProjectVotes_ProjectVoteId primary key (ProjectVoteId),
	constraint FK_tProjectVotes_ProjectId foreign key (ProjectId) references ITIH.tProject (ProjectId),
	constraint FK_tProjectVotes_UserId foreign key (UserId) references CK.tUser (UserId)
);

insert into ITIH.tProjectVotes (ProjectId, UserId, Note) values (0, 0, 0);