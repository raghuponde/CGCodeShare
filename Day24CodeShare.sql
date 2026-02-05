--general example 

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

create table dbo.TestUsers(ID int primary key ,
name varchar(50))

insert into dbo.TestUsers values(1,'Alice')


