
1)Open asp.net core mvc application 

2)and go to app settings and write like this 

   "ConnectionStrings": {
    "AzureSqlConnection": ""
  }
 

3) install entity framework packeages of version 8.0.24 packages in total 
Microsoft.EntityFrameworkCore 
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

4) add data folder inside the project and 

and add this class 

   using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; } = null!;
    }
}

Add a person class in Models folder only 

namespace WebApplication1.Models
{
    public class Person
    {
        public int Id { get; set; }        // PK
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string City { get; set; } = null!;
    }
}

   

5) go to program.cs file write this below code and in this what i am doing is that 


   var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection"); // here in appsetting u have to give this value //okay from statement 2 okay 
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
