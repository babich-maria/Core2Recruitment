/*1*/
SELECT * FROM [dbo].[Products]
WHERE isAvailable = 0
AND datepart(month,deliverydate) = datepart(month,getdate())
AND datepart(year,deliverydate) = datepart(year,getdate())

/*2*/
SELECT  PC.ProductId,  P.Description, COUNT(PC.CategoryId) AS CountCategories
FROM [dbo].[ProductCategory] AS PC 
JOIN  [dbo].[Products] AS P
ON PC.ProductId = P.ProductId WHERE P.[IsAvailable] = 1
GROUP BY PC.ProductId, P.Description
HAVING COUNT(PC.CategoryId) > 1

/*3*/
SELECT TOP 3 PC.CategoryId,  C.Description, AVG(P.Price) as AvgPrice,  COUNT(PC.ProductId) AS CountProduct
FROM [dbo].[ProductCategory] AS PC 
JOIN  [dbo].[Products] AS P
ON PC.ProductId = P.ProductId  
JOIN  [dbo].[Categories] AS C
ON PC.CategoryId = C.CategoryId WHERE P.[IsAvailable] = 1
GROUP BY PC.CategoryId, C.Description
ORDER BY AVG(P.Price) DESC;
