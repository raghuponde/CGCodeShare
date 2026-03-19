
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



namespace CodeFirstEntityFrameworkDemo.Models
{
    public class Author
    {
        public int Id { get; set; } // it will create identity column
        public string? AuthorName { set;get; }

        public IList<Course> Courses { get; set; }
    }
}

namespace CodeFirstEntityFrameworkDemo.Models
{
    public class Course
    {

        public int Id { get; set; } 
       
       public string? Title { get; set; }  

        public string? CourseDescription { get; set; }  

        public float? fullprice { get; set; }

        public Author? Author { get; set; }

        public List<Student> Students { get; set; } 

    }
}

namespace CodeFirstEntityFrameworkDemo.Models
{
    public class Student
    {
        public int Id { get; set; }

        public    List<Course> Courses { get; set; } 
    }
}
