

first create  a new table in sql server in NorthWind Db and on this table using db first apprach i want to perform crud operations 

use NorthWind

create table CustomProducts(Id int identity(1,1) primary key,
name varchar(100) not null,
price Decimal (10,2) not null,
stock int not null);

insert into CustomProducts(name,Price,stock) values('widget-A',34.56,100);

insert into CustomProducts(name,Price,stock) values('Gadget-B',49.67,50);

select * from CustomProducts

now come to visual studio 

create a new project of console and add these packages as usual using nugget package manager 

Microsoft.EntityFrameworkCore (version 8.0.24)
Microsoft.EntityFrameworkCore.SqlServer (version 8.0.24)
Microsoft.EntityFrameworkCore.Tools (version 8.0.24)


Open Package Manager Console (Tools > NuGet Package Manager > Package Manager Console).
Run (replace Server with your SQL Server instance

Scaffold-DbContext "Server=YourServer;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer
-OutputDir Models -Context NorthwindContext -Tables CustomProducts -Force


so this will add NorthwindContext along with the table CustomProducts which we have created 

Now create one folder Repositories in the project and in that folder add two files one is interface and  the class implementing the interface 


     using DBFirstwithSingleCrudDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstwithSingleCrudDemo.Repositories
{
    internal interface ICustomProduct
    {
        Task<List<CustomProduct>> GetAllAsync();
        Task<CustomProduct?> GetByIdAsync(int id);

        Task<CustomProduct> AddAsync(CustomProduct product);

        Task UpdateAsync(CustomProduct product);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}


Next 

using DBFirstwithSingleCrudDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstwithSingleCrudDemo.Repositories
{
    internal class CustomProductRepository : ICustomProduct
    {
        private readonly NorthWindContext _context;

        public CustomProductRepository(NorthWindContext context)
        {
            _context = context;
        }
        public async Task<CustomProduct> AddAsync(CustomProduct product)
        {
            await  _context.CustomProducts.AddAsync(product);
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.CustomProducts.FindAsync(id);
            if(product!=null)
            {
                _context.CustomProducts.Remove(product);
            }
        }

        public async Task<List<CustomProduct>> GetAllAsync()=> 
            await _context.CustomProducts.ToListAsync();
       
        public async Task<CustomProduct?> GetByIdAsync(int id)=>
            await _context.CustomProducts.
                Where(x => x.Id == id).FirstOrDefaultAsync();
       
        public async Task SaveChangesAsync()=>await _context.SaveChangesAsync();
   

        public async Task UpdateAsync(CustomProduct product)
        {
          
            _context.SaveChangesAsync();
           
        }

      
    }
}
in main program execute the code one by one by commenting others 


using DBFirstwithSingleCrudDemo.Models;
using DBFirstwithSingleCrudDemo.Repositories;
using System.Threading.Tasks;
namespace DBFirstwithSingleCrudDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            

            //var newprduct = new CustomProduct
            //{
            //    Name="super-widget",
            //    Price=89.45M,
            //    Stock=23
            //};
            NorthWindContext cnt = new NorthWindContext();
            CustomProductRepository obj = new CustomProductRepository(cnt);
           // await obj.AddAsync(newprduct);
           //await obj.SaveChangesAsync();

            var toupdate = await obj.GetByIdAsync(3);
            if (toupdate != null)
            {
                toupdate.Price = 37.67M;
                toupdate.Stock = 65;
                await obj.SaveChangesAsync();
              //  await obj.UpdateAsync(toupdate);
                
            }

            //var all = await obj.GetAllAsync();
            //Console.WriteLine("\n All products");
            //foreach(var p in all)
            //{
            //    Console.WriteLine($"{p.Id}--{p.Name}--{p.Price}--{p.Stock}");
            //}

            //await obj.DeleteAsync(2);
            //await obj.SaveChangesAsync();

            Console.WriteLine("Crud operation perfromed ");
        }
    }
}
here in the above program in 150 line commented where i am updating as i am updating in main method only exlcitly so that method is not needed okay .

     do the operations and cross check the db once .

     


