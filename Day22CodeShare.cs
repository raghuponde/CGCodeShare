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

 
right click on database and say restore database 

click device and three dots 

then say add 

copy the path from the above highlighted text box into the notepad only the path u copy 

C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup  

after copying the path close all widows 

and in that path u put these two .bak files 

then again follow the same steps and select the database say  ok and then in window select the file path and say ok and again ok 

-- i want to practise some commands like some select commands i want to practise 
use AdventureWorks2017
--This is the command to accept all values from a table.
select * from HumanResources.Employee
--when u want to accept particular columns just list out...like this.
select JobTitle ,Gender,LoginID from HumanResources.Employee
--using the Department table...

select * from HumanResources.Department

--These are the 3 ways to change the column names....

select 'Department Number'=DepartmentID,'DepartmentName'=Name from HumanResources.Department

select DepartmentID as 'Department Number',Name as 'Department Name' from HumanResources.Department



--suppose we want to make results more explanatory...in such a case u can add more text to the value..
--displayed by columns using literals...

select BusinessEntityID ,'Desgination: ',JobTitle from HumanResources.Employee

--suppose u want to view results in different manner...u may want to display the 
--values of multiple columns in a single column
--also to improve readability...u use concatenation operator...
--second thing is they are used only for strings...not for numbers


select Name + '   department comes under  '+ GroupName +'  group   ' as Department from HumanResources.Department
--sometimes u need to find out the columns operation also...

select * from HumanResources.EmployeePayHistory

select BusinessEntityID,Rate,per_day_rate=8*Rate from HumanResources.EmployeePayHistory

--there may be situation where u want to retrive the selected rows...

select * from HumanResources.Department where groupname='research and development'

--inside where clause u can use comaprison operators to specify condtions...

--again let us see table do some operation...

select * from HumanResources.Employee
--here relational operators are used...to check condition
select BusinessEntityID ,NationalIDNumber,JobTitle,VacationHours from 
HumanResources.Employee where VacationHours >
20
--to use logiccal operators...

--because to check for more conditions...

select * from humanresources.Department where Groupname='Manufacturing' or Groupname='Inventory management'

select * from Humanresources.Employee where JobTitle='production Technician - wc60' and Gender='M'

select * from HumanResources.Department where Groupname='Manufacturing' or NOT GroupName='quality Assurance'

--just now we have seen logial operators....
--now between and not between oprator is used for the range purpose...

select BusinessEntityID,VacationHours  from Humanresources.Employee
where vacationhours between 20 and 50

select BusinessEntityID,VacationHours from Humanresources.Employee where
vacationhours not between 20 and 80
--when we want to find the value in the given set of values...

select BusinessEntityID,JobTitle,LoginID from HumanResources.Employee where
JobTitle  in('Recruiter','Stocker') 

select BusinessEntityID,JobTitle,LoginID from Humanresources.Employee where
JobTitle not in('recruiter','stocked','janitor')

--retriving records that contain matched pattern
select * from HumanResources.Department where Name Like 'Production [c]%'
select * from HumanResources.Department
select * from HumanResources.Department where Name like 'Pro%'

select * from HumanResources.Department where Name like 'Sale_'


