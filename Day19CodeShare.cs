
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
