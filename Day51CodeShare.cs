
code first approach steps :
---------------------------
1)Installing packages core package ,tools,sql server 8.0.24 version install these dependencies 
    Microsoft.EntityFrameworkCore
   Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools
    
2)creating classes in Models folder which will later will 
be converted to db tables as i am using code first apprach 

and now add followng classes in Models folder 

Add Author,Course and Student classes into the
Models folder and then define the proeprties in them which i provide here okay 

between course and author there is one to many relationship means author
is master and course is child 
and between course and student many to many becauee one student can
take many course and in each course there will be many studnets so here 
junction table will be created with two one to many relationships okay 
