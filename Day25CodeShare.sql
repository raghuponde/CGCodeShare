
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


-- This UPDATE goes to the Orders table
-- here i am updating a first view which i created it is possible 
-- the effect is seen vice versa 
select * from vw_CustomerOrderView

UPDATE vw_CustomerOrderView
SET Freight = 50.00
WHERE OrderID = 10248;

--Note: Views that include GROUP BY, DISTINCT, multiple tables with aggregates, or 
--UNION are not updatable; you must modify the base tables directly.


--4. Schema‑bound view (WITH SCHEMABINDING)
--Schema binding locks the view to the schema of the tables it 
--references. You cannot drop or alter those tables in a way that would break the view.

--Example:


CREATE VIEW vw_OrderSummary
WITH SCHEMABINDING
AS
SELECT
    o.OrderID,
    o.OrderDate,
    c.CompanyName,
    SUM(od.Quantity * od.UnitPrice) AS TotalAmount
FROM dbo.Orders o
INNER JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
INNER JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.OrderID, o.OrderDate, c.CompanyName;

--Key effects of WITH SCHEMABINDING:

--You cannot drop Orders, Customers, or [Order Details] while this view exists.

--You cannot rename or remove columns that the view references.

--The view definition cannot be altered without first dropping it; you must 
--DROP VIEW and recreate it if you want to change the query.

--Schema‑bound views are often used when you plan to create an index on the view 
--(indexed views), which improves performance for heavy aggregations

Create 3 tables sailors,boats and reserves
 
create table sailors
(
 sid int constraint pk_sid primary key,
 sname varchar(20),
 rating int,
 age int
)
 
create table boats
(
 bid int constraint pk_bid primary key,
 bname varchar(20),
 color varchar(20)
)
 
create table reserves
(
sid int constraint fk_sid foreign key(sid) references sailors(sid),
bid int constraint fk_bid foreign key(bid) references boats(bid),
day date
)
 
insert into sailors values(22,'dustin',7,45)
insert into sailors values(29,'brutus',1,39)
insert into sailors values(31,'lubber',9,55)
insert into sailors values(32,'andy',8,25)
insert into sailors values(58,'Rusty',10,35)
 
insert into boats values(101,'interlake','blue')
insert into boats values(102,'interlake','red')
insert into boats values(103,'clipper','green')
insert into boats values(104,'marine','red')
 
insert into reserves values(22,101,'1/1/2004')
insert into reserves values(22,102,'1/1/2004')
insert into reserves values(22,103,'1/2/2004')
insert into reserves values(31,103,'5/5/2005')
insert into reserves values(32,104,'7/4/2005')
 
QUESTIONS
1)Write a query to find the name of the sailors who reserved red boat
2) Write a query to find the names of sailors who have reserved a red and a
green boat.
3) Write a query to find the name of sailor who reserved 1 boat
4) Write a query to find the sids of all sailors who have reserved red boats
but not green boats.
5) Write a query to find the sailors with the highest rating
6) Write a query to find  the number of sailors elligible to vote
7) Write a query to count different sailors name
8) Write a query to find  the oldest sailor
9)Write a query to find name as SAILERNAME,Rating,Age,bname as BOATNAME,Color,Day.
10)Write a query to display the sailor name  starts with letter a and b. 
11)Find the names of the Sailors who have reserved at least one boat.
12)Compute increments for the ratings of persons who have sailed two different boats on the same day.
13)Find the ages of sailors whose name begins and ends with B and has at least 3 characters.

 


