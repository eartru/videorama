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
   Select p.title from rent r
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

GO



