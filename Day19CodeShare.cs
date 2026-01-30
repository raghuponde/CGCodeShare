
SELF JOIN 
----------
self join means joining the table with itself now here only one table is there okay 
and in this table only some body is manaager for some body so as per question i had done self join 
for the same table two objects i created .


create table Employee(id int primary key ,
name varchar(50) not null,
managerid int );


insert into employee values(1,'mike',3),(2,'David',3),(3,'Roger',null),(4,'Marry',2),(5,'Joseph',2),
(7,'Ben',2);

select * from employee;

-- give me all the employees with the names and thier corresponding manager names 

select e1.name as "empname" ,e2.name as "Manager" from Employee e1 inner join Employee e2 on 
e1.managerid=e2.id;


-- give me name of the employee also who is not having any manager and if he is top manager 
-- tell or write beside him as CEO 

--version 1 
select e1.name as "empname" ,e2.name as "Manager" from Employee e1 left join Employee e2 on 
e1.managerid=e2.id;

--version 2 
select e1.name as "empname" ,e2.name as "Manager" from Employee e1 left join Employee e2 on 
e1.managerid=e2.id where e2.name is null

-- want to keep him as CEO 

select e1.name as "empname" ,isnull(e2.name,'CEO') as "Manager"  from Employee e1 left join Employee e2 on 
e1.managerid=e2.id 

SUBQUERY 
--------- 
Query inside another query we call it as subquery 
here parent query where clause value should match with child query select clause value while
 defining subqueries .
here i am talking about a select command inside an another select comand okay so here 
here in subquery the child select  clause is independent of parent clause means individually it can give me output 
it is not depending on parent query 


create table dept23 (deptid int primary key ,deptname varchar(30))

insert into dept23 values(10,'HR'),(20,'Software'),(30,'Sales');

select * from dept23;

create table emp23 (empid int primary key ,empname varchar(40),deptid
int foreign key references dept23(deptid));

insert into emp23 values(101,'ravi',30),(102,'kiran',10),(103,'sita',10)
,(104,'suresh',20)

select * from dept23;
select * from emp23;

-- subquery means query insdie another query 


create table empdemo3(empid integer  ,empname varchar(30) ,
salary integer )
insert into empdemo3 values ( 101,'ravi',1200);
insert into empdemo3 values ( 102,'mohan',1100);
insert into empdemo3 values ( 103,'kumar',1400);
insert into empdemo3 values ( 104,'senthil',1000);
insert into empdemo3 values ( 105,'manju',200);
insert into empdemo3 values ( 106,'manoj',500);

select * from empdemo3;


-- give me second largest salary from the table 

select max(salary) from empdemo3 where salary <(select max(salary) from empdemo3);

--another way 
select max(salary) from empdemo3 where salary not in (select max(salary) from empdemo3);


-- third largest 

select max(salary) from empdemo3 where salary < (select max(salary) from 
empdemo3 where salary <(select max(salary) from empdemo3));

--


select empname,salary from empdemo3
order by salary desc
offset 3 rows 
fetch next 1 row only;

some assingment 
-----------------
First create three tables like this one is students and another is classes and another is studentclass 
so there is many to many  relation ship between two tables so i have here one junction table okay so 
now to answer the question never join student with classes table okay see
in the answer i had joined the tables using juntion table which is studentclass 


--assingment 
drop table students
  create table students(studentid int ,studentname varchar(30));
insert into students values(1,'john'),(2,'Matt'),(3,'James');
create table classes(classid int ,classname varchar(30));
insert into classes values(1,'art'),(2,'history'),(3,'Maths');
create table studentclass(studentid int,classid int );
insert into studentclass values(1,1),(1,2),(3,1),(3,2),(3,3);

select * from students;
select * from classes;
select * from studentclass;






