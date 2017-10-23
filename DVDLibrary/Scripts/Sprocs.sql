use DvdList
go

if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DvdsSelectAll')
		drop procedure DvdsSelectAll
go

create procedure DvdsSelectAll as
begin
	select DvdId,Title,Director,ReleaseYear,Rating,Notes
	from Dvds
end
go


if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddDvd')
		drop procedure AddDvd
go

create procedure AddDvd (
	@DvdId int output,
	@Title nvarchar(220),
	@Director nvarchar(75),
	@ReleaseYear int,
	@Rating nvarchar(5),
	@Notes nvarchar(500)
) as
begin
	insert into Dvds (Title, Director, Rating,ReleaseYear, Notes)
	values (@Title, @Director, @Rating, @ReleaseYear, @Notes);

	set @DvdId = SCOPE_IDENTITY();
end
go


if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'EditDvd')
		drop procedure EditDvd
go

create procedure EditDvd (
	@DvdId int,
	@Title nvarchar(220),
	@Director nvarchar(75),
	@ReleaseYear int,
	@Rating nvarchar(5),
	@Notes nvarchar(500)
) as
begin
	update Dvds set 
	Title = @Title, 
	Director = @Director, 
	Rating = @Rating,
	ReleaseYear = @ReleaseYear, 
	Notes = @Notes
	where DvdId = @DvdId
end
go

if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DeleteDvd')
		drop procedure DeleteDvd
go

create procedure DeleteDvd (
	@DvdId int
) as
begin
	delete from Dvds where DvdId = @DvdId;
end
go

if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetDvd')
		drop procedure GetDvd
go

create procedure GetDvd (
	@DvdId int
) as
begin
	select DvdId, Title, Director, ReleaseYear, Rating, Notes
	from Dvds
	where DvdId = @DvdId
end
go


if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetDvdsByTitle')
		drop procedure GetDvdsByTitle
go

create procedure GetDvdsByTitle (
	@Title nvarchar(max)
	) as
begin
	select DvdId,Title,Director,ReleaseYear,Rating,Notes
	from Dvds
	where Title = @Title
end
go


if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetDvdsByDate')
		drop procedure GetDvdsByDate
go

create procedure GetDvdsByDate (
	@ReleaseYear int
	) as
begin
	select DvdId,Title,Director,ReleaseYear,Rating,Notes
	from Dvds
	where ReleaseYear = @ReleaseYear
end
go

if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetDvdsByDirector')
		drop procedure GetDvdsByDirector
go

create procedure GetDvdsByDirector (
	@Director nvarchar(max)
	) as
begin
	select DvdId,Title,Director,ReleaseYear,Rating,Notes
	from Dvds
	where Director = @Director
end
go

if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetDvdsByRating')
		drop procedure GetDvdsByRating
go

create procedure GetDvdsByRating (
	@Rating nvarchar(max)
	) as
begin
	select DvdId,Title,Director,ReleaseYear,Rating,Notes
	from Dvds
	where Rating = @Rating
end
go
