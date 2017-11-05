delete Specials
delete Purchases
delete PurchaseTypes
delete CarModels
delete Makes
delete ContactUs
delete Interiors
delete Employees
delete Customers
delete Colors
delete BodyTypes
delete Vehicles

DBCC CHECKIDENT('Vehicles', RESEED, 0)
DBCC CHECKIDENT('Specials', RESEED, 0)
DBCC CHECKIDENT('PurchaseTypes', RESEED, 0)
DBCC CHECKIDENT('Purchases', RESEED, 0)
DBCC CHECKIDENT('Makes', RESEED, 0)
DBCC CHECKIDENT('Interiors', RESEED, 0)
DBCC CHECKIDENT('Employees', RESEED, 0)
DBCC CHECKIDENT('Customers', RESEED, 0)
DBCC CHECKIDENT('ContactUs', RESEED, 0)
DBCC CHECKIDENT('Colors', RESEED, 0)
DBCC CHECKIDENT('CarModels', RESEED, 0)
DBCC CHECKIDENT('BodyTypes', RESEED, 0)