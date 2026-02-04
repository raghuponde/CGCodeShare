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

--Example 3 on scalar function 
--__________________________________

create table Books(
title_id varchar(10),
pages int,
qty_sold int)
insert into Books values('b0101',200,89)
insert into Books values('b0102',300,79)
insert into Books values('b0103',700,85)
select * from Books


Q) write a function on this table which will give me no of books sold
based on id value u provide to the function ?

