CREATE DATABASE ADMIN_1
GO

USE[ADMIN_1]
GO

CREATE TABLE Users(
Id INT IDENTITY(1,1) PRIMARY KEY,
UserName NVARCHAR(30) UNIQUE NOT NULL,
UserPass NVARCHAR(30) NOT NULL,
IsAdmin INT DEFAULT 0 NOT NULL
);

INSERT INTO Users Values('mikamikic','mika123',0),
('peraperic','pera123',1),
('lazalazic','laza123',0)


CREATE TABLE Product(
ProductId INT IDENTITY(1,1) PRIMARY KEY,
ProductName NVARCHAR(30) NOT NULL,
StartingPrice MONEY NOT NULL,
ProductInfo NVARCHAR(100) NULL,
IsSold INT DEFAULT 0 NOT NULL,
IsDeleted INT DEFAULT 0 NOT NULL,
UserId INT FOREIGN KEY REFERENCES Users("Id") null
);

INSERT INTO Product(ProductName,StartingPrice,ProductInfo) values
('Kompijuter',599.99,'Kompijuter u odlucno stanju,gtx 1080...'),
('Automobil',10000.89,'Automobil u odlucno stanju,marke bmw x6...'),
('Iphone 6',300.99,'Iphone telefon u odlucno stanju,kao nov...')


