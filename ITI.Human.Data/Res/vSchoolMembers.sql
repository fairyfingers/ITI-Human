﻿create view ITIH.vSchoolMembers
as
	select
		UserId = sm.UserId,
		UserName = u.UserName,
		SchoolMemberId = sm.SchoolMemberId,
		SchoolStatusId = sm.SchoolStatusId,
		SchoolStatusName = ss.SchoolStatusName
	from ITIH.tSchoolMember sm
		join CK.tUser u on u.UserId = sm.UserId
		join ITIH.tSchoolStatus ss on ss.SchoolStatusId = sm.SchoolStatusId
	where sm.SchoolMemberId <> 0;