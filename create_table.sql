SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

drop database if exists videorama;
create database videorama;

USE videorama;

drop table if exists rentDetail;
drop table if exists productCategory;
drop table if exists casting; 
drop table if exists product;
drop table if exists rent;
drop table if exists customer;
drop table if exists videoramaUser;
drop table if exists productType;
drop table if exists category;
drop table if exists person;
drop table if exists profession;

create table videoramaUser
(	idUser INT IDENTITY(1,1) NOT NULL,
	username VARCHAR(50) NOT NULL,
	passwordUser VARCHAR(50) NOT NULL,
	email VARCHAR(255) NOT NULL, 
	isAdmin BIT NOT NULL,
	CONSTRAINT PK_videoramaUserId PRIMARY KEY CLUSTERED (idUser ASC)
);

create table customer
(	idUser INT NOT NULL,
	firstname VARCHAR(50) NOT NULL,
	lastname VARCHAR(50) NOT NULL,
	addressCustomer VARCHAR(255) NOT NULL,
	postalCode VARCHAR(5) NOT NULL,
	town VARCHAR(50) NOT NULL,
	country VARCHAR(50) NOT NULL,
	CONSTRAINT PK_customerId PRIMARY KEY CLUSTERED (idUser ASC),
	CONSTRAINT FK_CustomerId FOREIGN KEY (idUser) REFERENCES videoramaUser(idUser) ON DELETE CASCADE);

create table rent 
(	idRent INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	rentDate DATE NOT NULL,
	getRentDate DATE NOT NULL,
	returnBackDate DATE NOT NULL,
	inProgress BIT NOT NULL,
	idCustomer INT,
	CONSTRAINT FK_RentCustomerId FOREIGN KEY (idCustomer) REFERENCES customer(idUser));
-- Pas de "on delete cascade", le magasin veut garder un historique de ses ventes

create table productType
(	idType INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	typeName VARCHAR(50) NOT NULL );

create table category
(	idCategory INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	categoryName VARCHAR(50) NOT NULL );

create table profession
(	idProfession INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	title VARCHAR(50) NOT NULL );

create table person
(	idPerson INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	firstname VARCHAR(50) NOT NULL,
	lastname VARCHAR(50) NOT NULL,
	birthDate DATE,
	idProfession INT NOT NULL,
	CONSTRAINT FK_PersonProfessionId FOREIGN KEY (idProfession) REFERENCES profession(idProfession) );

create table product
(	idProduct INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	title VARCHAR(255) NOT NULL,
	synopsis VARCHAR(2000),
	releaseDate DATE NOT NULL,
	price DECIMAL(9,2) NOT NULL,
	stock INT NOT NULL,
	picture VARCHAR(255),
	idType INT NOT NULL,
	CONSTRAINT FK_productTypeId FOREIGN KEY (idType) REFERENCES productType(idType) );

create table rentDetail
(	idRent INT NOT NULL,
	idProduct INT NOT NULL,
	CONSTRAINT PK_RentDetailId PRIMARY KEY (idRent,idProduct),
	CONSTRAINT FK_RentDetailIdProduct FOREIGN KEY (idProduct) REFERENCES product(idProduct),
	CONSTRAINT FK_RentDetailIdRent FOREIGN KEY (idRent) REFERENCES rent(idRent) ON DELETE CASCADE);

create table productCategory
(	idProduct INT NOT NULL,
	idCategory INT NOT NULL,
	CONSTRAINT PK_productCategoryId PRIMARY KEY (idProduct,idCategory),
	CONSTRAINT FK_productCategoryIdProduct FOREIGN KEY (idProduct) REFERENCES product(idProduct),
	CONSTRAINT FK_productCategoryIdCategory FOREIGN KEY (idCategory) REFERENCES category(idCategory));

create table casting
(	idProduct INT NOT NULL,
	idPerson INT NOT NULL,
	CONSTRAINT PK_castingId PRIMARY KEY (idProduct,idPerson),
	CONSTRAINT FK_castingIdProduct FOREIGN KEY (idProduct) REFERENCES product(idProduct) ON DELETE CASCADE,
	CONSTRAINT FK_castingIdPerson FOREIGN KEY (idPerson) REFERENCES person(idPerson));
