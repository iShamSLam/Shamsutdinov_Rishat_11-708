/*USE AdventureworksDW;
GO*/

/* NUMBER 1
SELECT FirstName, DepartmentName FROM DimEmployee
WHERE (YEAR(HireDate) >= 2007) AND (MONTH(HireDate) >= 9) AND (DAY(HireDate) >= 1)
AND Gender = 'm' AND (DepartmentName = 'Marketing' OR DepartmentName = 'Information Services'); */

/* Number 2
SELECT EnglishProductName FROM DimProduct
WHERE ProductKey IN(SELECT ProductKey FROM FactResellerSales
 WHERE (YEAR(OrderDate) >= 2007 AND (MONTH(OrderDate) = 6 OR MONTH(OrderDate) = 7 OR MONTH(OrderDate) = 8)) 
 AND SalesTerritoryKey IN (SELECT SalesTerritoryKey FROM DimSalesTerritory WHERE SalesTerritoryRegion = 'Canada')); */

 /* Number 4
 SELECT count(*) as Count_1, DimProductSubcategory.EnglishProductSubcategoryName as Name_1 FROM DimProduct
 INNER JOIN DimProductSubcategory ON DimProduct.ProductSubcategoryKey = DimProductSubcategory.ProductSubcategoryKey
 WHERE ProductKey IN(SELECT ProductKey FROM FactResellerSales
  WHERE (YEAR(OrderDate) >= 2007 AND (MONTH(OrderDate) = 6 OR MONTH(OrderDate) = 7 OR MONTH(OrderDate) = 8)))
  GROUP BY EnglishProductSubcategoryName;
  */