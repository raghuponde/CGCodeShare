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


