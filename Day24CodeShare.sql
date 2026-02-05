-- divide by zero violation error 

BEGIN TRY
    SELECT 1/0 AS Error
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_STATE() AS ErrorState,
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_LINE() AS ErrorLine,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_MESSAGE() AS ErrorMessage
END CATCH
--example 2 primary key violation error 
create table dbo.TestUsers(ID int primary key ,
name varchar(50))

insert into dbo.TestUsers values(1,'Alice')

begin try
insert into dbo.TestUsers values(1,'Bob')
end try 
begin catch 
select
Error_number() as ErrorNumber ,
ERROR_SEVERITY() as ErrorSeverity,
error_state() as ErrorState,
ERROR_MESSAGE() as ErrorMessage,
Error_Line() as Errorline,
ERROR_PROCEDURE() AS ErrorProcedure
end catch

--example 3 
--conversion error 
begin try 
declare @val int ;
set @val=convert(int,'abc')
end try 
begin catch 
select 
Error_number() as ErrorNumber ,
ERROR_SEVERITY() as ErrorSeverity,
error_state() as ErrorState,
ERROR_MESSAGE() as ErrorMessage,
Error_Line() as Errorline,
ERROR_PROCEDURE() AS ErrorProcedure
end catch 

--exaple 4 
--------------
CREATE TABLE dbo.TableA (Id INT PRIMARY KEY, Val INT);
CREATE TABLE dbo.TableB (Id INT PRIMARY KEY, Val INT);

INSERT INTO dbo.TableA VALUES (1, 100);
INSERT INTO dbo.TableB VALUES (1, 200);

BEGIN TRY
    BEGIN TRANSACTION;
    UPDATE dbo.TableA SET Val = Val + 10 WHERE Id = 1;
    WAITFOR DELAY '00:00:10';  -- hold lock on TableA
    UPDATE dbo.TableB SET Val = Val + 10 WHERE Id = 1;
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber,      -- 1205 if deadlocked
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

-- in another tab 

BEGIN TRY
    BEGIN TRANSACTION;
    UPDATE dbo.TableB SET Val = Val + 20 WHERE Id = 1;
    WAITFOR DELAY '00:00:10';  -- hold lock on TableB
    UPDATE dbo.TableA SET Val = Val + 20 WHERE Id = 1;
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber,      -- 1205 if deadlocked
        ERROR_SEVERITY() AS ErrorSeverity,
        ERROR_STATE() AS ErrorState,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

-- Create Customers table
CREATE TABLE Customers
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100)
);

-- Create Orders table with a foreign key reference to Customers
CREATE TABLE Orders1
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT,
    OrderAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);


CREATE PROCEDURE InsertCustomerOrder
    @CustomerName NVARCHAR(100),
    @OrderAmount DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRY
        -- Start transaction
        BEGIN TRANSACTION;

        -- Insert into Customers table
        INSERT INTO Customers (CustomerName)
        VALUES (@CustomerName);

        -- Simulate error by inserting an invalid CustomerID into Orders (e.g., 0, which does not exist)
        INSERT INTO Orders (CustomerID, OrderAmount)
        VALUES (1, @OrderAmount);

        -- If no error, commit transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Error handling: Output error details using functions
        PRINT 'An error occurred during the transaction';

        PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS NVARCHAR(10));
        PRINT 'Error Message: ' + ERROR_MESSAGE();
        PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS NVARCHAR(10));
        PRINT 'Error State: ' + CAST(ERROR_STATE() AS NVARCHAR(10));
        PRINT 'Error Procedure: ' + ISNULL(ERROR_PROCEDURE(), 'N/A');
        PRINT 'Error Line: ' + CAST(ERROR_LINE() AS NVARCHAR(10));

        -- Optionally, re-throw the error
        -- THROW;
    END CATCH
END

exec InsertCustomerOrder 'ravi',123.34


select * from customers ;
select * from Orders1;

--now alter the sp using putting 0 like  this below 

alter PROCEDURE InsertCustomerOrder
    @CustomerName NVARCHAR(100),
    @OrderAmount DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRY
        -- Start transaction
        BEGIN TRANSACTION;

        -- Insert into Customers table
        INSERT INTO Customers (CustomerName)
        VALUES (@CustomerName);

        -- Simulate error by inserting an invalid CustomerID into Orders (e.g., 0, which does not exist)
        INSERT INTO Orders1 (CustomerID, OrderAmount)
        VALUES (0, @OrderAmount);

        -- If no error, commit transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Error handling: Output error details using functions
        PRINT 'An error occurred during the transaction';

        PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS NVARCHAR(10));
        PRINT 'Error Message: ' + ERROR_MESSAGE();
        PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS NVARCHAR(10));
        PRINT 'Error State: ' + CAST(ERROR_STATE() AS NVARCHAR(10));
        PRINT 'Error Procedure: ' + ISNULL(ERROR_PROCEDURE(), 'N/A');
        PRINT 'Error Line: ' + CAST(ERROR_LINE() AS NVARCHAR(10));

        -- Optionally, re-throw the error
        -- THROW;
    END CATCH
END
exec InsertCustomerOrder 'mahesh',128.34


select * from customers ;
select * from Orders1;

--Suposse i want to raise my own erros with my own severity numbers in the sql server then i will use RaiseError method for it 

Begin try
declare @age int =125;
if @age < 18 
RAISERROR('User must be atleast 18',16,5);
if @age > 120
RaisError('User age is unrealistic high',16,6);
if @age  is null
RaisError('Age cannot be null',16,7);
end try 
begin catch 
select 
 ERROR_NUMBER() AS ErrorNumber,
        ERROR_STATE()  AS ErrorState,   -- will be 5, 6, or 7
        ERROR_MESSAGE() AS ErrorMessage
end catch 

CREATE TABLE Employees23 (
    EmpID INT PRIMARY KEY,
    Name VARCHAR(50),
    Department VARCHAR(50),
    Salary INT
);

-- Insert sample data
INSERT INTO Employees23 (EmpID, Name, Department, Salary)
VALUES 
(1, 'Alice', 'HR', 60000),
(2, 'Bob', 'IT', 55000),
(3, 'Charlie', 'HR', 70000),
(4, 'David', 'IT', 60000),
(5, 'Eva', 'Finance', 75000),
(6, 'Frank', 'Finance', 62000),
(7, 'Grace', 'IT', 55000),
(8, 'Hannah', 'HR', 50000);


Task:
--We want to find all employees whose salary is greater than the average salary of their 
--respective department.
--We want to find all employees whose salary is greater than the average salary of their 
--respective department.
-- using co related subquery 
select e.EmpID,e.Name,e.Department, e.Salary from Employees23 e
where e.Salary > (select AVG(Salary) from Employees23 where Department=e.Department)
--using join 

select e.empid, e.name,e.department, e.salary
from employees23 e
join
(
    select department, avg(salary) as avgsalary
    from employees23
    group by department
) d on e.department = d.department where e.salary > d.avgsalary;

Now for the same above table add these chnages 

UPDATE Employees23
SET Salary = 55000
WHERE Name IN ('Bob', 'Grace');

-- Add one more IT employee with 55000 to make it three
INSERT INTO Employees23 (EmpID, Name, Department, Salary)
VALUES (9, 'Ivy', 'IT', 55000);

-- Add one HR employee with the same salary as Alice (60000)
INSERT INTO Employees23 (EmpID, Name, Department, Salary)
VALUES (10, 'Jack', 'HR', 60000);

and after adding these changes fire the below commands


select EmpID,Name,Department,Salary ,row_number() over(partition by department order by salary desc) as Rownum 
from employees23;

select EmpID,Name,Department,Salary ,rank() over(partition by department order by salary desc) as Rownum 
from employees23;

select EmpID,Name,Department,Salary ,dense_rank() over(partition by department order by salary desc) as Rownum 
from employees23;

