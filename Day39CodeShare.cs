
Step 1: Create Console Project
In Visual Studio 2026, create new Console App targeting .NET 8.0, name it "CodeFirstDemo".
Install NuGet packages:

Microsoft.EntityFrameworkCore (8.0.24)
Microsoft.EntityFrameworkCore.SqlServer (8.0.24)
Microsoft.EntityFrameworkCore.Tools (8.0.24)

step 2 :
------
  Define entities means classes which will convert to tables later 

  so create one folder with name Models in project and add these classes into it .

  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo.Models
{
     class Category
    {
        public int Id { set; get; } // this will create identity column in table 
        public string Name { set; get; }

        public List<Product> Products { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo.Models
{
     class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }

        public int CategoryId { set; get; }

        public Category category { set; get; }
    }
}

step 3 :
----------
  add one folder Data in proejct and in that add one class AppDbContext 

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEFDemo.Models;

namespace CodeFirstEFDemo.Data
{
    class AppDbContext:DbContext
    {
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-4G8BHPK9\\SQLEXPRESS;Database=cgefdb1;" +
                "Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

step4 :
---------
  once buuild the solution 

step 5 :
----------
  go to package manager console and add migration and update database 

  PM> add-migration 'dbcreated'
Build started...
Build succeeded.
No store type was specified for the decimal property 'Price' on entity type 'Product'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
To undo this action, use Remove-Migration.
PM> update-database 
Build started...
Build succeeded.
No store type was specified for the decimal property 'Price' on entity type 'Product'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
Applying migration '20260302043738_dbcreated'.
Done.
PM> 

Main method code 
--------------------
using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.VisualBasic;

var context = new AppDbContext();

// create category 

var electronics = new Category { Name = "Electronics" };

context.Categories.Add(electronics);
await context.SaveChangesAsync();


