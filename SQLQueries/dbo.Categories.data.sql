/*2*/
select  PC.ProductId,  P.Description, COUNT(PC.CategoryId) as CountCategories
from [dbo].[ProductCategory] AS PC 
JOIN  [dbo].[Products] AS P
ON PC.ProductId = P.ProductId WHERE P.[IsAvailable] = 1
GROUP BY PC.ProductId, P.Description
HAVING COUNT(PC.CategoryId) > 1
/*data*/
select  *
from [dbo].[Products] 
select  *
from [dbo].[ProductCategory] order by [dbo].[ProductCategory].CategoryId

/*3*/
select TOP 3 PC.CategoryId,  C.Description, AVG(P.Price) as AvgPrice,  COUNT(PC.ProductId) as CountProduct
from [dbo].[ProductCategory] AS PC 
JOIN  [dbo].[Products] AS P
ON PC.ProductId = P.ProductId  
JOIN  [dbo].[Categories] AS C
ON PC.CategoryId = C.CategoryId WHERE P.[IsAvailable] = 1
GROUP BY PC.CategoryId, C.Description
ORDER BY AVG(P.Price) DESC;

/*1*/
select * from [dbo].[Products]
where isAvailable = 0
and datepart(month,deliverydate) = datepart(month,getdate())
and datepart(year,deliverydate) = datepart(year,getdate())

