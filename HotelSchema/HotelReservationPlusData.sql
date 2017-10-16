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
go

create table Reservation(
	ReservationID int Identity (1,1) Primary Key,
	CustomerID int foreign key references Customer(customerID)not null,
	StartDate date,
	EndDate date,
	Room int
)
go

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
	BaseRate int not null
)

create table Room(
	RoomID int Identity (1,1) Primary Key,
	RoomTypeID int foreign key references RoomType(roomtypeid),
	RoomNumber int not null,
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
	RoomID int foreign key references Room(RoomID) not null
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
	AddOnFee int,
	AddOnRateID int foreign key references AddOnRates(AddOnRateID)
)

create table Bill(
	ReservationID int Primary Key foreign key references Reservation(ReservationID),
	BillDate datetime2 not null,
	Tax int not null,
	Total int not null,
	discount int,
)

create table BillDetails(
	ReservationID int foreign key references Bill(ReservationID),
	AddOnID int foreign key references AddOns(AddOnID),
	Cost int,
	ItemDescription varchar(30)
)

Insert into Rates(RateName,Multiplier)
values ('Weekend',1.25),('SuperBowl',2.25)

Insert into customer(firstname,lastname,
phone,[address],city,[state],postalcode,country,birthdate)
values ('Jake','Ganser','762-242-5080','10819 Sanctuary Dr NE','Blaine','MN','55449','US','1/10/1986'),
('Bill','Brasky','111-222-3333','123 Main St','Anywhere','MN','55303','US','1/11/1980')


insert into RoomType (RoomTypeName,BaseRate)
values ('Standard',80),
('Standard Suite',100),
('Deluxe',120),
('Deluxe Suite',150)

insert into Room (RoomTypeID,RoomNumber,Occupancy)
values (1,100,4),
(2,200,6),
(3,300,8),
(4,400,10),
(3,301,8)

Insert into reservation (CustomerID,Room,StartDate,EndDate)
values (1,400,'10/01/17','10/03/17'),(2,100,'10/30/17','10/31/17')

Insert into guest (ReservationID)
values (2)

Insert into guest (ReservationID,FirstName,LastName,age)
values ('1','Ashley','Weber',31),
('1','Joe','Ganser',32)

Insert into Amenities (AmenityName,RoomID)
values ('Jacuzzi',4),('Mini Bar',4),('Pull out bed',2),('Microwave',3),('Mini Fridge',4)

Insert into Bill (ReservationID,BillDate,Tax,Total)
values(1,'10/03/17',.065,324.5)

Insert into BillDetails (ReservationID,ItemDescription,Cost)
values (1,'Movie Rental',5)

select *
from customer
inner join Reservation
on Reservation.CustomerID = Customer.CustomerID
inner join Guest
on Customer.CustomerID = Guest.ReservationID
inner join Room
on room.RoomNumber = Reservation.Room
inner join RoomType
on RoomType.RoomTypeID = room.RoomTypeID
inner join Amenities
on Amenities.RoomID = Room.RoomID
inner join bill
on bill.ReservationID = Reservation.ReservationID
inner join billdetails
on billdetails.reservationID = bill.reservationID
go
