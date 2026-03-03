
inside the project all one interface like this 

  public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    Task<List<Product>> GetByCategoryAsync(int categoryId);
}

Now add one class in the project with the name ProductRepository and implement above interface here 
using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo
{
    class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<Product> AddAsync(Product product)
        {
           await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if(product!=null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();

        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
          //  _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}


program.cs code 
-----------------
using CodeFirstEFDemo;
using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;


// create category 

//var electronics = new Category { Name = "Electronics" };

//context.Categories.Add(electronics);
//await context.SaveChangesAsync();

//context.Products.AddRange(
//    new Product { Name = "laptop", Price = 999.78M, category =electronics },
//     new Product { Name = "Mouse", Price = 678.78M, category = electronics }
//);

//await context.SaveChangesAsync();

// update command 
//var laptop = await context.Products.FirstAsync(p => p.Name == "laptop");
//laptop.Price = 7899.67M;
//await context.SaveChangesAsync();

//// delete command 
//context.Products.Remove(laptop);
//context.SaveChangesAsync();

//Querrng author with courses 

//var authors = await context.Authors.Include(x => x.Courses).ToListAsync();
//// one to many 
//foreach(var author in authors)
//{
//    Console.WriteLine($"Author: {author.Name}");
//    foreach(var course in author.Courses)
//    {
//        Console.WriteLine($"--{course.Title}--{course.Description}--{course.level}");
//    }
//}
var  context = new AppDbContext();

//var newProduct = new Product
//{ Name = "smartphone", Price = 6888.56M, CategoryId = 3 };
IProductRepository obj = new ProductRepository(context);
//await obj.AddAsync(newProduct);

//var toupdate = await obj.GetByIdAsync(newProduct.Id);
//if(toupdate!=null)
//{
//    toupdate.Price = 777.67M;
//    toupdate.Name = "normalphone";
//   await  obj.UpdateAsync(toupdate);
//    Console.WriteLine($"Updated : {toupdate.Name}--{toupdate.Price}");
//}

//var producttofetch = await obj.GetByIdAsync(7);

//if (producttofetch != null)
//{
//    producttofetch.Price = 555.67M;
//    producttofetch.Name = "normalphone2";
//    await obj.UpdateAsync(producttofetch);
//    Console.WriteLine($"Updated : {producttofetch.Name}--{producttofetch.Price}");
//}

await obj.DeleteAsync(7);


Now i want to do the same above tasks using stored procedures interface will not change only thing is that
in ProductRepository2  i will call stored procedures and remember u have to create stored procedures in 
cgefdb1 db only 

so write the below stored procedures and execute them one by one 

-- GetAllProducts
CREATE OR ALTER PROCEDURE GetAllProducts
AS
BEGIN
    SELECT Id, Name, Price, CategoryId FROM Products;
END

-- GetProductById
CREATE OR ALTER PROCEDURE GetProductById @Id int
AS
BEGIN
    SELECT Id, Name, Price, CategoryId FROM Products WHERE Id = @Id;
END

-- InsertProduct
CREATE OR ALTER PROCEDURE InsertProduct @Name nvarchar(100), @Price decimal(18,2), @CategoryId int
AS
BEGIN
    INSERT INTO Products (Name, Price, CategoryId) OUTPUT INSERTED.Id, INSERTED.Name, INSERTED.Price, INSERTED.CategoryId
    VALUES (@Name, @Price, @CategoryId);
END

-- UpdateProduct
CREATE OR ALTER PROCEDURE UpdateProduct @Id int, @Name nvarchar(100), @Price decimal(18,2), @CategoryId int
AS
BEGIN
    UPDATE Products SET Name = @Name, Price = @Price, CategoryId = @CategoryId
    WHERE Id = @Id;
END

-- DeleteProduct
CREATE OR ALTER PROCEDURE DeleteProduct @Id int
AS
BEGIN
    DELETE FROM Products WHERE Id = @Id;
END
Next go to project and add one class ProductRepository2 and implement same interface again 


using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo
{
    class ProductRepository2 : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository2(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddAsync(Product product)
        {
            var result = await _context.Products.FromSqlRaw($"EXEC InsertProduct" +
                $" {product.Name},{product.Price},{product.CategoryId}").ToListAsync();
            return result.First();
        }

       

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.
                FromSqlRaw("EXEC GetAllProducts").ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            var products = await _context.Products.FromSqlRaw($"EXEC GetProductById {id}").
                 ToListAsync();
            return products.FirstOrDefault();
        }
      
        public async Task UpdateAsync(Product product)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC UpdateProduct {product.Id}," +
                $"{product.Name},{product.Price},{product.CategoryId} ");
        }
        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC DeleteProduct {id}");
        }
        public Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}

main program code 
-------------------
using CodeFirstEFDemo;
using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;


// create category 

//var electronics = new Category { Name = "Electronics" };

//context.Categories.Add(electronics);
//await context.SaveChangesAsync();

//context.Products.AddRange(
//    new Product { Name = "laptop", Price = 999.78M, category =electronics },
//     new Product { Name = "Mouse", Price = 678.78M, category = electronics }
//);

//await context.SaveChangesAsync();

// update command 
//var laptop = await context.Products.FirstAsync(p => p.Name == "laptop");
//laptop.Price = 7899.67M;
//await context.SaveChangesAsync();

//// delete command 
//context.Products.Remove(laptop);
//context.SaveChangesAsync();

//Querrng author with courses 

//var authors = await context.Authors.Include(x => x.Courses).ToListAsync();
//// one to many 
//foreach(var author in authors)
//{
//    Console.WriteLine($"Author: {author.Name}");
//    foreach(var course in author.Courses)
//    {
//        Console.WriteLine($"--{course.Title}--{course.Description}--{course.level}");
//    }
//}
var  context = new AppDbContext();

//var newProduct = new Product
//{ Name = "smartphone", Price = 6888.56M, CategoryId = 3 };
IProductRepository obj = new ProductRepository(context);
//await obj.AddAsync(newProduct);

//var toupdate = await obj.GetByIdAsync(newProduct.Id);
//if(toupdate!=null)
//{
//    toupdate.Price = 777.67M;
//    toupdate.Name = "normalphone";
//   await  obj.UpdateAsync(toupdate);
//    Console.WriteLine($"Updated : {toupdate.Name}--{toupdate.Price}");
//}

//var producttofetch = await obj.GetByIdAsync(7);

//if (producttofetch != null)
//{
//    producttofetch.Price = 555.67M;
//    producttofetch.Name = "normalphone2";
//    await obj.UpdateAsync(producttofetch);
//    Console.WriteLine($"Updated : {producttofetch.Name}--{producttofetch.Price}");
//}

//await obj.DeleteAsync(7);
IProductRepository obj2 = new ProductRepository2(context);
//var newProd = new Product { Name = "Tablet", Price = 233.45M,
//    CategoryId = 3 };
//await obj2.AddAsync(newProd);

var toupdate = await obj2.GetByIdAsync(8);
if (toupdate != null)
{
    toupdate.Price = 888.7M;
    toupdate.Name = "IPhone";
}
await obj2.UpdateAsync(toupdate);


//await obj2.DeleteAsync(9);


