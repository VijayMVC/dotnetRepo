if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DbReset')
		drop procedure DbReset
go

create procedure DbReset as
begin
	delete from Dvds;

	DBCC CHECKIDENT ('Dvds',reseed,3)

	set identity_insert Dvds on;
	insert into Dvds (DvdId,Title, Director, Rating,ReleaseYear, Notes)
	values (1,'Office Space', 'Director A','R','1999','funny movie'),
			(2,'Fight Club','Director B','R','2001','good movie'),
			(3,'Star Wars', 'Director A', 'PG','1999','nerd movie')
	set identity_insert Dvds off;
end
