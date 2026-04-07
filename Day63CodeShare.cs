
1)First create an asp.net core web api project withname ProductApi 

2)2)and go to app settings and write like this 

   "ConnectionStrings": {
    "AzureSqlConnection": ""
  }
 


3) from the portal where sql servver is there add connection string setting like this and And write like this

   
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "AzureSqlConnection":"Server=tcp:raghuserver.database.windows.net,1433;Initial Catalog=raghudb;Persist Security Info=False;User ID=raghuadmin;Password=SqlServer#123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }


}
Note enter password manually here 

4) install entity framework packeages of version 8.0.24 packages in total 
Microsoft.EntityFrameworkCore 
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools


5) Add Models folder and add Data Folder in project and add the following classes 
given below 

namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
 
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

        public DbSet<Product> Products { get; set; } = null!;
    }
}

6) go to program.cs file write this below code and in this what i am doing is that 


   var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection"); // here in appsetting u have to give this value //okay from statement 2 okay 
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

6)once build the solution and add-migration 
and do update-database 

7)Next add one folder in the project with the name Services and add one interface like this 

using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}

8) go to chat gpt and give him model Product and also above interface and ask him ProductService code which is your class 
   which will implement IProductService and also give me ProductController code also 

   namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}
for the above model the interface is like this 
using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IproductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
Now I will implement this interface in ProductService class and and this ProductService i will use in ProductController of webpi  so give me complete code for ProductService and ProductController for the above secenaio
