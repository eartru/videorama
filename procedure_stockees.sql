USE [videorama]
GO

/****** Object:  StoredProcedure [dbo].[GetTopNProducts]    Script Date: 11/11/2018 17:58:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure GetTopNProducts
( @NbProducts int )  
as  
begin  
   select TOP(@NbProducts) p.idProduct, p.title, COUNT(rd.idProduct) as quantity
   from product p
   INNER JOIN rentDetail rd on p.idProduct = rd.idProduct 
   GROUP BY p.idProduct, p.title
   ORDER BY COUNT(rd.idProduct) desc
End

CREATE Procedure GetProductsByType
( @IdType int )  
as  
begin  
	select * from product p
	inner join productType pt on p.idType = pt.idType  
	where p.idType = @IdType
End

CREATE Procedure  GetRentByCustomer
( @IdCustomer int )  
as  
begin  
   Select p.idProduct, p.title, p.picture from rent r
   INNER JOIN rentDetail rd on r.idRent = rd.idRent 
   INNER JOIN product p on rd.idProduct = p.idProduct
   where idCustomer = @IdCustomer AND inProgress = 1
End

CREATE Procedure GetNewProducts
as  
begin  
	Select top 3 idProduct, title, synopsis, picture from product
	ORDER BY idProduct DESC 
END

CREATE Procedure [GetProductByNameAndType]
( @IdType int, @Name varchar(50) )  
as  
begin  
   select * from product where idType = @IdType
   and title like '%' + @Name + '%'
End

CREATE Procedure [PutCustomer]
( @FristName varchar(50), @Name varchar(50), @Email varchar(50),  @Password varchar(255), @Adress varchar(255), @PostalCode varchar(5), @Town varchar(50), @Country varchar(50))  
as  
begin  
	DECLARE @new_parent_id INT
	INSERT INTO videoramaUser (username, passwordUser, email, isAdmin) VALUES ( @Name, @Password, @Email, 'false');	
	SELECT @new_parent_id = SCOPE_IDENTITY()
	INSERT INTO customer(idUser, firstname, lastname, addressCustomer, postalCode, town, country) VALUES ( @new_parent_id, @FristName, @Name, @Adress, @PostalCode, @Town, @Country);
End

GO


