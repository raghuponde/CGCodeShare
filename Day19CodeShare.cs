
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
