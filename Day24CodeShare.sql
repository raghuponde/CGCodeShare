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


