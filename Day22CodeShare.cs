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

-- if  u want to modify the above procedure 

alter procedure printdata 
as 
begin 
declare @x varchar(30)
set @x='india is doing well'
print 'hello world'
print @x;
end 

-- u can check using object explorerr in programability section 
-- default name space is dbo means database owner 
-- if u dont give namesapce in db it gets stored in dbo

-- another way to check 
sp_helptext printdata 

-- to add two numbers write a sp
create procedure addnums (@num1 int,@num2 int)
as begin 
declare @result int;
set @result=@num1 +@num2;
print 'The sum is '+Convert(varchar(20),@result);
end 

exec addnums 20,34


 -- returnign a value in stored procedure 

alter procedure addnums (@num1 int,@num2 int)
as begin 
declare @result int;
set @result=@num1 +@num2;
--print 'The sum is '+Convert(varchar(20),@result);
return @result;
end 

declare @result1 int;
exec @result1=addnums 10,45
print 'The sum is '+Convert(varchar(20),@result1);



-- i dont want to use my varibale i want to use varibale given me from outside 
-- then in stored procedure  will use out variable like we were using in c#
-- here i can use out or output also 

alter procedure addnums (@num1 int,@num2 int,@result int output)
as begin 
set @result=@num1 +@num2;
--print 'The sum is '+Convert(varchar(20),@result);
return @result;
end 

declare @result2 int;
declare @sum1 int 
exec @result2=addnums 12,45,@sum1 output ;
print 'The sum is '+Convert(varchar(20),@result2);

create procedure calculator (@num1 int ,@num2 int,@addresult int output ,@substractresult
int output)
as
begin 
set @addresult=@num1 + @num2;
set @substractresult=@num1-@num2;
select @addresult;
select @substractresult;
end 

declare @sum int ;
declare @diff int;
exec calculator 100,34,@sum output,@diff output 
print 'The sum is '+Convert(varchar(20),@sum)
print 'The diff is '+Convert(varchar(20),@diff)
-- can be written like this also 
alter procedure calculator (@num1 int ,@num2 int,@addresult int output ,@substractresult
int output)
as
begin 
set @addresult=@num1 + @num2;
set @substractresult=@num1-@num2;

end 

declare @sum int ;
declare @diff int;
exec calculator 100,34,@sum output,@diff output 
print 'The sum is '+Convert(varchar(20),@sum)
print 'The diff is '+Convert(varchar(20),@diff)



 alter procedure printdata with encryption
as 
begin 
declare @x varchar(30)
set @x='india is doing well'
print @x;
end 

sp_helptext printdata

alter procedure printdata 
as 
begin 
declare @x varchar(30)
set @x='india is doing well'
print @x;
end

-- write a sp for finding x to the power of y 
create procedure findPower(@x int, @y int )
as
begin
declare @result int;
set @result = power(@x,@y);
print @result;
end

exec findpower 12,3


 create table studentdata(studid int primary key ,studname varchar(50))
-- sp for insert 
create proc insertstud (@studid1 int ,@studname1 varchar(50))
as
begin 
insert into studentdata values(@studid1,@studname1);
end 

exec insertstud 102,'suresh'

select * from studentdata 

-- sp for udpate 
create proc updatestud (@studid1 int ,@studname1 varchar(50))
as
begin 
update  studentdata set studname=@studname1 where studid=@studid1;
end 

exec updatestud 102,'kiran'

select * from studentdata 

-- sp for delete
create proc deletestud (@studid1 int)
as
begin 
delete  studentdata  where studid=@studid1;
end 

exec deletestud 102

select * from studentdata 


-- sp for select 

create proc selectstud(@studid1 int)
as
begin 
select * from studentdata where studid=@studid1
end

exec selectstud 101


 --write a proc to display only  name of student only 

alter  proc selectstud(@studid1 int)
as
begin
declare @name1 varchar(40);
select @name1=studname from studentdata where studid=@studid1;
print @name1;
end

exec selectstud 101
