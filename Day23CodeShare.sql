Functions in sql server :
----------------------------------
Function will always return a value but we have seen that a 
stored procedure may or may not return a value .
we have already used many functions in sql server 
like sqrt,sum square ,substring like that but these are system defined
functions ...so now we are going to create 

User Defined functions: The function which are created by end user
is called as user defined  functions .When you cant find a built-in 
function that  meets your needs, you can write your own.

UDFs come in three flavors: 
1)scalar functions
2)in-line table valued functions
3) multi-statement table valued functions. 

Function is always used with select clause....

syntax :
-------

create function <function_name> ( paramters_list)
returns <function_type>
as
begin

------
return ;
------
end



execution : select <function_name> from <table_name>

Scalar function:
------------------
scalar functions accept a  parameter and return a single 
data value of type specified in RETURNS clause
A scalar function can return any data type except
text,ntext,image,cursor and timestamp.

CREATE FUNCTION <function_name>
(@input_variables  type)
RETURNS data_type of result returned by function
AS
BEGIN
.....  SQL Statements
    RETURN (data_value)
END

create function multiply(@x int ,@y int)
returns int
as
begin
return @x * @y;
end 

select dbo.multiply(23,56)
-- this function i want to apply to some other table values 
-- i am going to northwind database products tables means shifting totally to northwind and from there 
    -- calling a function in CG okay 

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ProductID]
      ,[ProductName]
      ,[SupplierID]
      ,[CategoryID]
      ,[QuantityPerUnit]
      ,[UnitPrice]
      ,[UnitsInStock]
      ,[UnitsOnOrder]
      ,[ReorderLevel]
      ,[Discontinued]
  FROM [NorthWind].[dbo].[Products]

  select ProductName+' doing business of Rs:'+Convert(varchar(30),
  CG.dbo.multiply(UnitPrice,UnitsInStock)) as totalsale
  from Products 

--example 2 on scalar function 
--____________________________
create table orders(orderid int primary key ,orderdate datetime,
whichcustomer varchar(10))

insert into orders values(101,'1996-08-01','c01')
insert into orders values(102,'1997-04-02','c01')
insert into orders values(103,'2012-08-01','c01')
insert into orders values(104,'2013-08-05','c02')
insert into orders values(105,'2014-08-01','c02')

select * from orders;
--write a function to find last or latest  order ordered by the given customer ..
 create function fn_lastorder(@cust varchar(10))
returns datetime
as begin
    declare @lastdate datetime
    select @lastdate = max(orderdate)
    from orders
    where whichcustomer = @cust

    return @lastdate
end

select dbo.fn_lastorder('c01') as lastorderdate
select dbo.fn_lastorder('c02') as lastorderdate
--second type
CREATE FUNCTION findlatestorder(@custid VARCHAR(30))
RETURNS DATETIME
AS
BEGIN
    RETURN (
        select max(orderdate)
        from orders
        where @custid = whichcustomer
    )
END
GO 

--third type 
create function fn_lastorder2(@cust varchar(10))
returns datetime
as begin
    declare @lastdate datetime
    select Top 1 @lastdate = orderdate
    from orders
    where whichcustomer = @cust order by orderdate desc;

    return @lastdate
end

select dbo.fn_lastorder2('c01') as lastorderdate

create table Books(
title_id varchar(10),
pages int,
qty_sold int)
insert into Books values('b0101',200,89)
insert into Books values('b0102',300,79)
insert into Books values('b0103',700,85)
select * from Books


--Q) write a function on this table which will give me no of books sold
--based on id value u provide to the function ?

create function copies_sold(@title_id varchar(10))
returns int
as begin 
declare @quantity int;
select @quantity=0;
select @quantity=qty_sold from Books where title_id=@title_id;
return @quantity;
end 

select dbo.copies_sold('b0101')


Table valued functions:
-------------------------
A table valued function returns a table
 as an output,which can be derived as a part of 
select statement.Table valued function return 
the output as a table data  datatype.
The Table data type is special data type used to store 
set of rows,which returns the result set of the table valued function

Inline table valued function:
-------------------------------
In-line UDFs return a single row or multiple 
rows and can contain a single SELECT statement. 
Because in-line UDFs are limited to a single SELECT,
 They cant contain much logic.An inline function does not contain function body within begin and end statement

syntax:
--------
create function <function_name>(parameters_list)
returns table as
return (<any select command which will give me resultset>)

procedure of execution(to call inline table function) :
-------------------------------------------------------
select * from <function_name>(parameters_list)
    
-- Example on inline table valued function 
_______________________________________________

create table employee_info(
     ID          int,
     name        varchar (10),
     salary      int,
     start_date  datetime,
     city       varchar (10),
     region      char (1))

insert into employee_info
               values (1,  'Jason', 40420,  '02/01/94', 'New York', 'W')
 insert into employee_info 
               values (2,  'Robert',14420,  '01/02/95', 'Vancouver','N')
 insert into employee_info 
               values (3,  'Celia', 24020,  '12/03/96', 'Toronto',  'W')

select * from employee_info


--write an inline table valued function to find employees in particular
--region 
create function listemp (@region char)
returns table 
as
return select * from employee_info where region=@region

select * from listemp('N');
-- written as per syntax 

-- if i try to put begin and end here it will give error 
alter function listemp (@region char)
returns table 
as
begin
return select * from employee_info where region=@region
end 

select * from listemp('N');

--now i want to create multi line table valued where i will chosee my table and my columns


MultiLine Table valued function:
------------------------------------
A multiLine table valued function uses multiple statements
to build the table that is returned to the calling statement.
The function body contains Begin and end block
which hold a series of Transact-SQl statements to build and
 insert rows into a temperory table.The temperory table is returned in resultset and is created based on specification mentioned  in function.The major difference in the way that you define a multi-statement, table-valued function from the previous example is that you must declare the table that you will be 
returning.
syntax:
create function <function_name> (parameters-list)
returns @table Table (list_of_column_names)
as
begin 
insert @table 
--------
-----
end 

-- multiline table valued function means here begin and end will come 
-- means it will return a table only but how many columns i will decide to 
-- project ..how many columns i have to project that i will decide and 
-- i will only not just retun table but i can return some extra code also 
-- or i can display some exta code also so begin and end is ther in 
-- multi line table valued function 


 Example on multiline table valued function 
_______________________________________________

--write a multi line table valued function which will return employees in region


-- multi line table valued functions


-- same question answer but doing using multi line table valued function 
-- try to catch the difference by checking earlier code 
alter function listemp2(@region char)
returns @table Table
(
ID int not null,
name varchar(50),
city varchar(50),
reigon char,
message varchar(100)-- adding a message to column of table
)
as begin
if exists(select ID,name,city,region from employee_info where region=@region)
begin
insert into @table(ID,name,city,reigon,message)
select ID,name,City,region,'region found' from employee_info 
where region=@region
end
else
begin
-- if no rows are found 
insert into @table(ID,name,city,reigon,message)values(0,'no data','no data','n','No values are there for this region')
end
return;
end

select * from dbo.listemp2('W')

--- making it simple 

alter function listemp2(@region char)
returns @table Table
(
ID int not null,
name varchar(50),
city varchar(50),
reigon char
)
as begin
insert into @table(ID,name,city,reigon)
select ID,name,City,region from employee_info 
where region=@region
return;
end

-- i can write the code like this also but this function is returning
-- table so i cant print message in else that is why i am using table and 
-- putting message in table and returningn it even it is faalse
alter function listemp2(@region char)
returns @table Table
(
ID int not null,
name varchar(50),
city varchar(50),
reigon char
)
as begin
if exists(select ID,name,city,region from employee_info where region=@region)
insert into @table(ID,name,city,reigon)

select ID,name,City,region from employee_info 
where region=@region
else
print 'no employees found'
return;
end

--this error i am getting 
Msg 443, Level 16, State 14, Procedure listemp2, Line 16 [Batch Start Line 172]
Invalid use of a side-effecting operator 'PRINT' within a function.

SET OPERATORS
-------------
In SQL Server, set operators like UNION, INTERSECT, and EXCEPT or Minus (the SQL Server equivalent of MINUS in other databases like Oracle) are used to combine the results of two or more queries. These set operators return distinct results from the queries involved.

1. UNION
Combines the result sets of two or more queries and removes duplicates.
Returns distinct values from both result sets.
2. INTERSECT
Returns only the rows that are common in both result sets.
3. EXCEPT (Equivalent to MINUS in other databases)
Returns the rows from the first query that are not present in the second query.

Rules for Using Set Operators:

The number of columns and their data types must be the same in both queries.
The order of the columns must be the same.
Example Scenario:
Let's work with two tables, Employees_A and Employees_B, which contain some employee records.

-- Table: Employees_A
CREATE TABLE Employees_A (
    employee_id INT,
    first_name NVARCHAR(50),
    last_name NVARCHAR(50)
);

INSERT INTO Employees_A (employee_id, first_name, last_name)
VALUES (1, 'John', 'Doe'),
       (2, 'Jane', 'Smith'),
       (3, 'Alice', 'Johnson');

-- Table: Employees_B
CREATE TABLE Employees_B (
    employee_id INT,
    first_name NVARCHAR(50),
    last_name NVARCHAR(50)
);

INSERT INTO Employees_B (employee_id, first_name, last_name)
VALUES (2, 'Jane', 'Smith'),
       (3, 'Alice', 'Johnson'),
       (4, 'Bob', 'Brown');


-- Get all distinct employees from both tables
SELECT employee_id, first_name, last_name FROM Employees_A
UNION
SELECT employee_id, first_name, last_name FROM Employees_B;


-- Get the employees that are present in both tables
SELECT employee_id, first_name, last_name FROM Employees_A
INTERSECT
SELECT employee_id, first_name, last_name FROM Employees_B;



-- Get employees that are present in Employees_A but not in Employees_B
SELECT employee_id, first_name, last_name FROM Employees_A
EXCEPT
SELECT employee_id, first_name, last_name FROM Employees_B;


-- Combine UNION, INTERSECT, and EXCEPT in one query
-- Step 1: Find all employees from both tables using UNION
-- Step 2: Find common employees using INTERSECT
-- Step 3: Find employees that are only in Employees_A but not in Employees_B using EXCEPT
SELECT employee_id, first_name, last_name FROM Employees_A
UNION
SELECT employee_id, first_name, last_name FROM Employees_B
INTERSECT
SELECT employee_id, first_name, last_name FROM Employees_A
EXCEPT
SELECT employee_id, first_name, last_name FROM Employees_B;



select * from dept1
select * from empl 

-- give me all the employees who are working as clerk job or working in dept sales 



