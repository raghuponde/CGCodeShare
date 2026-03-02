
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


