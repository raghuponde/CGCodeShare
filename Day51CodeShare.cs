
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



go to app settings and put comma and then
paste this code and modify as per your system settinggs

 "ConnectionStrings": {
   "constring": "Data Source=LAPTOP-4G8BHPK9\\SQLEXPRESS;initial catalog=EventCG;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;"
 }
 here it will look like this
 
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "constring": "Data Source=LAPTOP-4G8BHPK9\\SQLEXPRESS;initial catalog=EventCG;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;"
  }

}

context class also u need to create and in that u have to add all classes 
   and set the path in app  settings file and 
   also in program.cs file also inject the dependency 
   
   Now add one class like this EventContext which is master class which will 
   hold all tables through this only i will call other classes and tables 

   
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFInAsp.netcoreDemo.Models
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions dbContextOptions):
            base(dbContextOptions)
        {
            
        }
        public DbSet<Author> authors { set; get; }
        public DbSet<Course> courses { set; get; }

        public DbSet<Student> students { set; get; }
    }
}



now in program.cs i have to inject this dependency 

 builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));


