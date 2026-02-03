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

 create table hi(
names varchar(10),
rollno int
)


insert into hi values ('Karsen',200)

insert into hi values('Karson',500)
insert into hi values('raghu',62)
insert into hi values ('Carsen',100)
insert into hi values('kiran',46)
insert into hi values ('Carson',300)

select * from hi;
select * from hi where names like '[CK]ars[eo]n'
select * from hi where names like '[^K]ars[eo]n'


-- Retriving record that contain null values

select * from [HumanResources].[EmployeeDepartmentHistory]
select BusinessEntityID,EndDate from 
HumanResources.EmployeeDepartmentHistory where EndDate is null

select BusinessEntityID,Enddate from
HumanResources.EmployeeDepartmentHistory where Enddate is not null

--when u want to retrive records in sequence...
select * from HumanResources.Department
select DepartmentID ,Name from HumanResources.Department order by Name 

--using top keyword....
select * from HumanResources.EmployeeDepartmentHistory 
select top 3 BusinessEntityID,Enddate 
from HumanResources.EmployeeDepartmentHistory where Enddate is not null

select top 50 percent * from HumanResources .EmployeeDepartmentHistory

Aggregate functions 
---------------------
1)count:it will give u no of rows in a table 
eg: select count(*) from HumanResources.EmployeePayHistory
2)sum:it give u sum of all the values in 
column having numeric values
eg:select sum(Rate) from HumanResources.EmployeePayHistory
3)max: it will give me highest value in column
eg: select max(Rate) from HumanResources.EmployeePayHistory
4)min;it will give me the lowest value in column
eg: select min(Rate) from HumanResources.EmployeePayHistory
5)avg: it will give the average of column
 means sum_of_ numbers /total_no_of_values present in a column
eg: select avg(Rate) from HumanResources.EmployeePayHistory

Built in functions 
---------------------
--1)Mathematical functions:
--_______________________

--a) abs(n) : it returns a absolute value of given number n
   eg: select abs(-12)=12
--b)square(n) : It return the square of n
eg: select square(25)=9
--c)sqrt(n) :it will give u square root of n
eg: select sqrt(4)=2
--d)power(n,m) :it will give u n to the power of m value
eg:select power(2,3) =8
--e)round(n,size):it will round a value n is the value 
--and size is how many values to round
eg:select round(156.6789,2)=156.68
     select round(156.6789,0)=157
      select round(156.6789,-1)=160
--f)ceiling(n) :it returns an least integer greater than n
  eg: select ceiling(15.6)=16
         select ceiling (-15.6)=-15
--g)floor(n) :it returns the highest integer less than given n
eg: select floor(15.6)=15
select floor(-15.6)=-16



--2)String functions :strings are nothing but set of chracters so these
--string functions can also be applied to columns having string values.
--_________________________________________________
a) Ascii(s): it returns ascii value of first character in the given string 
eg: select ascii('D')=65
select ascii('def')=100
b)char(n):This is reverse of ascii it takes ascii value 
and returns the character represented by it
eg: select char(65)=A
c)Len(s) : it returns length of given string
eg:select len('Tanzania')=8
select len(Title) from HumanResources.Employee
d)lower(s):it return given string converted into lower case
eg: select left(Title,3) from HumanResources.Employee
e)upper(s):it retuen the given string converted in upper case
eg: select upper('apple')=APPLE
f)  left(s,n) it returns the selected n no of  characters from left
   side of given string
  eg: select  left('Hello',3)=Hel
g)right(s,n) : same as above but from right 
h)substring (s,start,length) :it returns part of string from a given string
    s 
eg: select substring('Hello',1,3)=Hel

g) reverse(n): it returns the given string in reverse order.
eg:select reverse('Hello')=0lleH
h)Ltrim(s) : it eilimates empty character that are present in left side 
of given string s
select Rtrim('hello             ')
eg: select Ltrim('       hello')=hello
i)Rtrim (s) : is is ame as left but at right side we eliminate spaces 
from the given string
eg: select Rtrim('heloo     ')=heloo
j)replace (s,searchstr,replacestr): it replaces each occurence of 
searchstr with replacestr in the given string s
select replace('Hello world','o','x')=Hellx wxrld
k)stuff(s,start,length,replacestr):
it repalces specified no of characters with replace string in the 
given string s
eg: select stuff('abxxcdxx',3,2,'yy')=abyycdxx
select stuff('abxxcdxx',3,2,'yy')

3) Date functions ; 
a)getdate( ) : To get todays date we use getdate( ) function 
 eg: select getdate() as Todaysdate

b) datediff: calculates the no of  date parts between two dates.

   select datediff(mm,'01/01/1990',getdate( ) ) as Age
   select datediff(yy,'7/8/1982' ,getdate( )) as Age
   select datediff(hh,'7/8/1982',getdate() ) as Age
  select datediff(dd,'7/8/1982',getdate( )) as Age
  select datediff(mi,'7/8/1982',getdate( )) as Age
  select datediff(yy,HireDate,getdate( )) from HumanResources.Employee
 c) dateadd: It returns the datepart listed from the listed 
date as integer.

    select dateadd(mm,30,getdate( ) )

  d) datename(datepart,d) :it is used for picking any specified 
     date part value from the given date d

   Note: seconds=ss,year =yy,quarter=q,month =mm,
             day =dd,day of the year =dy,weak of the year=wk,
             milliseconds=ms,weekday=dw,hours=hh,minutes=mi

  eg:   select datename(dw,getdate( ))=monday
a)conversion functions :
_______________________________

convert(varchar,@x) --here @x is converted to varchar type 
cast(@x as varchar) -- here again @x is converted into varchar type @x can be of any type 

declare @age int ;
declare @name varchar(30)
set @name='ravi'
set @age=23;
print 'The person with the name '+Convert(varchar(30),@name)+' is having '+Convert(varchar(30),@age) +' years of age ';
print 'The person with the name '+@name+' is having '+Convert(varchar(30),@age) +' years of age '; 
print 'The person with the name '+cast(@name as varchar)+' is having '+cast(@age as varchar) +' years of age ';


--- what ever code i had wrttien is temperroy





