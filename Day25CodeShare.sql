
-Views demo 
______________
--views mainly used for security reasons see i have created a table some parts of information 
--i dont want my junior or subordinate to see so i will created a view for him and second 
--reason is i had written a complex query involving joins and i want to store it for 
--future use then also i convert it into view 

 
--A view is a virtual table whose contents are defined by a query.
--Like a real table a view consists of a set of named columns and 
--rows of the data.
--The view is not stored in data base if   i am creating a table 
--it will be stored in database but view is actually derived from
--a some other table.The rows and columns of data come from the tables referenced
--in the query defining the view,
--it acts as a filter.it is stored as an object in the database,which does not 
--have its own data.A view will derive its data from one or more table


--explain them graphically ..okay ..drop it in editor and apply with encryption also for the
--view and then try doing schema binding and try to do edit operation on main 
--tables then it gives u nice warning message okay .so if i say yes in this message 
--then schema binding will be removed ..



--In SQL Server, views can update the underlying base tables if they are “updatable” 
--(simple joins, no aggregates, etc.), and schema binding (WITH SCHEMABINDING)
--locks the view to the schema of its base tables so you cannot change those tables 
--in ways that would break the view.

--Below are Northwind‑specific examples using multiple tables, 
--plus explanations of schema binding and other view features.

--1. Simple multi‑table view (Orders + Customers)
--Assume you have:

--Customers (CustomerID, CompanyName, City)

--Orders (OrderID, CustomerID, OrderDate, Freight)

--Create a view:

select * from Customers;
select * from Orders;

create view vw_CustomerOrderView as 
select c.CustomerID,c.CompanyName,c.City ,
o.OrderID,o.OrderDate,o.Freight from Customers c 
inner join Orders o on c.CustomerID=o.CustomerID;

select * from vw_CustomerOrderView



--2. View with Orders + Order Details + Products
--Tables:

--Orders

--Order Details (note the space; in T‑SQL you must quote it: [Order Details])

--Products

CREATE VIEW vw_OrderLineItems AS
SELECT
    o.OrderID,
    o.OrderDate,
    c.CompanyName AS CustomerName,
    p.ProductName,
    od.Quantity,
    od.UnitPrice,
    od.Quantity * od.UnitPrice AS LineTotal
FROM Orders o
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID;



SELECT OrderID, ProductName, LineTotal
FROM vw_OrderLineItems
WHERE CustomerName = 'Alfreds Futterkiste';

