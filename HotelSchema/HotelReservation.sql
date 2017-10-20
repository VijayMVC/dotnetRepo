USE master
GO
if exists (select * from sysdatabases where name='HotelSchema')
		drop database HotelSchema
go

create database HotelSchema;
go

use HotelSchema
go

create table Customer(
	CustomerID INT Identity (1,1) Primary Key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	Phone nvarchar(24) not null,
	[Address] nvarchar(60) not null,
	City nvarchar(15) not null,
	[State] varchar (20) not null,
	PostalCode nvarchar(10) not null,
	Country nvarchar(15),
	BirthDate datetime2
)

create table Reservation(
	ReservationID int Identity (1,1) Primary Key,
	CustomerID int foreign key references Customer(customerID)not null,
	StartDate date,
	EndDate date,
	Room int
)

create table PromoCodes(
	PromoCodeID int Identity (1,1) Primary Key,
	ReservationID int foreign key references Reservation(reservationID),
	StartDate date,
	EndDate date,
	DollarsOff money,
	DiscountRate int
)

create table Guest(
	GuestID int Identity (1,1) Primary Key,
	ReservationID int foreign key references Reservation(ReservationID)not null,
	FirstName nvarchar(30),
	LastName nvarchar(30),
	age int
)

create table RoomType(
	RoomTypeID int Identity (1,1) Primary Key,
	RoomTypeName varchar (30) not null,
	BaseRate money not null
)

create table Room(
	RoomID int Identity (1,1) Primary Key,
	RoomTypeID int foreign key references RoomType(roomtypeid),
	RoomNumber int not null,
	RoomFloor varchar(20),
	Occupancy int not null, 
)

create table ReservationRoom(
	RervationRoomID int Identity (1,1) Primary Key,
	RoomID int foreign key references Room(RoomID),
	ReservationID int foreign key references Reservation(ReservationID)
)

create table Amenities(
	AmenityID int Identity (1,1) Primary Key, 
	AmenityName varchar (30) not null,
)

create table RoomAmenities(
	AmenityID int foreign key references Amenities(AmenityID),
	RoomID int foreign key references Room(roomID),
)

create table Rates(
	RateID int Identity (1,1) Primary Key,
	StartDate datetime2,
	EndDate datetime2,
	Multiplier int,
	RateName varchar(30)
)

create table RoomTypeRates(
	RoomTypeID int foreign key references RoomType(RoomTypeID),
	RateID int foreign key references Rates(RateID)
)

create table AddOnRates(
	AddOnRateID int Identity (1,1) Primary Key,
	StartDate datetime2,
	EndDate datetime2,
	Multiplier int,
)

create table AddOns(
	AddOnID int Identity (1,1) Primary Key,
	AddOnName varchar(30),
	AddOnFee money,
	AddOnRateID int foreign key references AddOnRates(AddOnRateID)
)

create table Bill(
	ReservationID int Primary Key foreign key references Reservation(ReservationID),
	BillDate datetime2 not null,
	Tax int not null,
	Total money not null,
	discount int,
)

create table BillDetails(
	ReservationID int foreign key references Bill(ReservationID),
	AddOnID int foreign key references AddOns(AddOnID) null,
	Cost money,
	ItemDescription varchar(30)
)
