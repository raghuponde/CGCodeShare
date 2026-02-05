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

