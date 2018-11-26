USE [videorama]
GO

/****** Object:  StoredProcedure [dbo].[GetTopNProducts]    Script Date: 11/11/2018 17:58:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure GetAllProducts
as  
   select p.idProduct, p.title, p.stock, pt.idType, pt.typeName
   from product p
   INNER JOIN productType pt on p.idType = pt.idType 
go

CREATE Procedure AddNewProduct
( @Title varchar(255), @Synopsis varchar(2000), @Price DECIMAL(9,2), @IdType int,  
@ReleaseDate Date, @Stock int, @Picture varchar(255))
as  
	INSERT INTO product(title, synopsis, price, releaseDate, stock, picture, idType) 
	VALUES ( @Title, @Synopsis, @Price, @ReleaseDate, @Stock, @Picture, @IdType);	
go

CREATE Procedure UpdateProduct
( @IdProduct int, @Title varchar(255), @Synopsis varchar(2000), @Price DECIMAL(9,2), @IdType int,  
@ReleaseDate Date, @Stock int, @Picture varchar(255))
as  
	Update product set title= @Title, synopsis=@Synopsis, price=@Price, releaseDate=@ReleaseDate,
	stock=@Stock, picture=@Picture, idType=@IdType
	where idProduct = @IdProduct
go

CREATE PROCEDURE DeleteProduct
(@IdProduct int)
as 
begin
	delete from product 
	where idProduct = @IdProduct
end
go

CREATE Procedure GetTopNProducts
( @NbProducts int )  
as  
   select TOP(@NbProducts) p.idProduct, p.title, COUNT(rd.idProduct) as quantity
   from product p
   INNER JOIN rentDetail rd on p.idProduct = rd.idProduct 
   GROUP BY p.idProduct, p.title
   ORDER BY COUNT(rd.idProduct) desc
go

CREATE Procedure GetProductsByType
( @IdType int )  
as    
	select * from product p
	inner join productType pt on p.idType = pt.idType  
	where p.idType = @IdType
go

CREATE Procedure  GetRentByCustomer
( @IdCustomer int )  
as  
   Select r.idRent, r.returnBackDate, p.idProduct, p.title, p.picture 
   from rent r
   INNER JOIN rentDetail rd on r.idRent = rd.idRent 
   INNER JOIN product p on rd.idProduct = p.idProduct
   where idCustomer = @IdCustomer AND inProgress = 1
   order by r.idRent
go

CREATE Procedure  GetRents
as  
   Select r.idRent, r.idCustomer, c.firstname, c.lastname, r.returnBackDate, r.rentDate
   from rent r
   INNER JOIN customer c on r.idCustomer = c.idUser
   where inProgress = 1
   order by r.idRent
go

CREATE Procedure  GetRentProducts
( @IdRent int )  
as  
    select p.idProduct, p.title, p.picture
	from rent r 
	INNER JOIN rentDetail rd on r.idRent = rd.idRent 
   INNER JOIN product p on rd.idProduct = p.idProduct
    where r.idRent = @IdRent
go

CREATE Procedure  GetDistinctRentByCustomer
( @IdCustomer int )  
as  
    select distinct r.idRent, r.returnBackDate
	from rent r 
	INNER JOIN rentDetail rd on r.idRent = rd.idRent 
   INNER JOIN product p on rd.idProduct = p.idProduct
    where r.idCustomer = @IdCustomer and r.inProgress = 1
go

CREATE Procedure GetNewProducts
as  
	Select top 3 idProduct, title, synopsis, picture from product
	ORDER BY idProduct DESC 
go

CREATE Procedure [GetProductByNameAndType]
( @IdType int, @Name varchar(50) )  
as  
   select * from product where idType = @IdType
   and title like '%' + @Name + '%'
go

CREATE Procedure [PutCustomer]
( @UserName varchar(50), @FristName varchar(50), @Name varchar(50), @Email varchar(50),  @Password varchar(255), @Adress varchar(255), @PostalCode varchar(5), @Town varchar(50), @Country varchar(50))  
as  
	DECLARE @new_parent_id INT
	INSERT INTO videoramaUser (username, passwordUser, email, isAdmin) VALUES ( @UserName, HashBytes('SHA1', @Password), @Email, 'false');	
	SELECT @new_parent_id = SCOPE_IDENTITY()
	INSERT INTO customer(idUser, firstname, lastname, addressCustomer, postalCode, town, country) VALUES ( @new_parent_id, @FristName, @Name, @Adress, @PostalCode, @Town, @Country);
go

CREATE Procedure [GetUserByUserNameAndPassword]
( @UserName varchar(50), @Password varchar(255) )  
as   
   select * from videoramaUser where username = @UserName
   and passwordUser = HashBytes('SHA1', @Password)
go

CREATE Procedure GetCustomers
as    
   select c.*, u.email from customer c
   inner join videoramaUser u on c.idUser = u.idUser 
go

CREATE Procedure GetCustomerDetail
( @IdCustomer int)
as  
   select c.*, u.email from customer c
   inner join videoramaUser u on c.idUser = u.idUser 
   where c.idUser = @IdCustomer
go

CREATE Procedure GetRentDetails
( @IdRent int )  
as  
   select r.idRent, r.idCustomer, c.firstname, c.lastname, c.addressCustomer, c.postalCode, c.town,
	c.country, r.rentDate, r.returnBackDate, p.title, p.price  
	from rent r 
	inner join rentDetail rd on r.idRent = rd.idRent
	inner join product p on p.idProduct = rd.idProduct
	inner join customer c on c.idUser = r.idCustomer
	where r.idRent = @IdRent
go

CREATE Procedure GetCustomerById
( @Id int )  
as  
begin  
   select * from customer, videoramaUser 
   where customer.idUser = @Id
End
GO

CREATE PROCEDURE UpdateCustomer
(@IdCustomer int, @FirstName varchar(50), @LastName varchar(50), @Email varchar(50), @Address varchar(255),
 @PostalCode varchar(5), @Town varchar(50), @Country varchar(50))
as 
begin
	update customer 
	set firstname = @FirstName, lastname = @LastName, 
	addressCustomer = @Address, postalCode = @PostalCode, town = @Town, country = @Country
	where idUser = @IdCustomer

	update videoramaUser 
	set email = @Email 
	where idUser = @IdCustomer
end
go

CREATE PROCEDURE DeleteCustomer
(@IdCustomer int)
as 
begin
	delete from videoramaUser 
	where idUser = @IdCustomer
end
go

CREATE PROCEDURE UpdateRentReturnedBack
(@IdRent int)
as 
begin
	update rent 
	set inProgress = 0 
	where idRent = @IdRent
end
go