USE Northwind;
GO
-- 1.	Obtener la lista de los productos no descatalogados incluyendo el nombre de la categoría ordenado por nombre de producto.
SELECT p.ProductName, c.CategoryName
FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE Discontinued = 0
ORDER BY ProductName;
-- 2.	Mostrar el nombre de los clientes de  Nancy Davolio.

SELECT DISTINCT c.ContactName
FROM orders o join Employees e on o.EmployeeID = e.EmployeeID join Customers c on o.CustomerID = c.CustomerID 
WHERE e.FirstName = 'Nancy' and e.LastName = 'Davolio';
-- 3.	Mostrar el total facturado por año del empleado Steven Buchanan.
SELECT sum(facturado), t.Anio
from 
(
	SELECT (od.UnitPrice * od.Quantity) - od.Discount AS Facturado , YEAR(o.OrderDate) AS Anio
	FROM Employees e JOIN Orders o ON e.EmployeeID = o.EmployeeID JOIN [Order Details] od ON o.OrderID = od.OrderID
	--JOIN Products p ON od.ProductID = p.ProductID
	WHERE e.FirstName = 'Steven' and e.LastName = 'Buchanan'
	GROUP BY od.UnitPrice, od.Quantity, od.Discount, YEAR(o.OrderDate)
) t
group by t.anio
-- 4.	Mostrar el nombre de los empleados que dependan directa o indirectamente de Andrew Fuller.
select * from Employees e
WHERE e.FirstName = 'Andrew'