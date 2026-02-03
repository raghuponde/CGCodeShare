stored procedure: when i want to make permenant changes in database tables we use stored procedure 
stored procedure may or may not return a value and it may return mutiple rows also sometimes and stored procedure may return a output type of variable also which we will c in code .

stored procedure is nothing bur a precomipled object which will be there permenantly in server any time i check and use that procedure 

when i use stored procedures security will be added to my data ,extra over heads like request and response will be avoided netwairk traffc will be avoieded ,efficent reuse of code will be there in sp 

to check stred sp_helptext storedprocname;


syntax :

create proc or procedure <procedure_name>(paramters ) 
as
begin


-------------
--------------

end

exec proedure_name paramters ..




Stored Procedures :
---------------------
Batches are temperory in nature they are not stored permenantly
in the database so in order to make batches to store permenantly 
in database we go for stored procedures.They are pre compiled
objects which can used at any time .
To execute a batch more than once you need to recreate 
sql statements and submit them to server.This leads to 
increase in overhead, as the server needs to compile and 
create the execution plan for this statements again;Therefore
 to execute a batch multiple times you save it in a stored procedure..

advantages of stored procedure :
---------------------------------
1.Precompiled execution: SQL Server compiles each stored
 procedure once and then reutilizes the execution plan. This
 results in tremendous performance boosts when stored 
procedures are called repeatedly. 

2.Reduced client/server traffic: If network bandwidth is 
a concern in your environment, youll be happy to learn that 
stored procedures can reduce long SQL queries to a single line 
that is transmitted over the wire. 

3.Efficient reuse of code and programming abstraction: 
Stored procedures can be used by multiple users and client 
programs. If you utilize them in a planned manner, 
youll find the development cycle takes less time. 

4.Enhanced security controls: You can grant users 
permission to execute a stored procedure independently 
of underlying table permissions. 

There are two types of stored procedures :
1)stored procedure without parameters
2) stored procedure with parameters.

syntax for creating a stored procedure:
---------------------------------------------
create procedure <procedure_name>(paramters list)
as
begin

---------------
---------------
---------------
end
To execute a stored procedure :
-----------------------------------
exec <procedure_name> (paramters list)


 create procedure printdata 
as 
begin 
declare @x varchar(30)
set @x='india is doing well'
print @x;
end 

exec printdata

