
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

8) go to chat gpt 
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
  The code which i got 

  using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService : IproductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
---
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IproductService _productService;

        public ProductController(IproductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound(new { message = $"Product with Id {id} not found." });
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var createdProduct = await _productService.CreateProductAsync(product);

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = createdProduct.Id },
                createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, product);

            if (updatedProduct == null)
            {
                return NotFound(new { message = $"Product with Id {id} not found." });
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);

            if (!deleted)
            {
                return NotFound(new { message = $"Product with Id {id} not found." });
            }

            return NoContent();
        }
    }
}
---------------
  builder.Services.AddScoped<IproductService, ProductService>(); 


now add a web app in azure and in program .cs add this code 

  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
      app.UseSwagger();
      app.UseSwaggerUI();
  }
  else
  {
      // Enable Swagger in production too for API testing
      app.UseSwagger();
      app.UseSwaggerUI(options =>
      {
          options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1");
      });
  }

means else as u have done already publish and code has changed again so do again publish and then after the url /swagger/index u type it will work


Now creeate and MVC client application with the name ProductAPIClient  

and go to app settings 


 "ApiSettings": {
    "BaseUrl": "https://productwebapicgapp-ehafefffb3faenhd.centralus-01.azurewebsites.net/api"
  }

here put base url of azure api 

next go to Layout page and add this line after footer 

  <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
as i am using jquery ajax method


