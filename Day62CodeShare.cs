
Open asp.net core mvc application 

and go to app settings and write like this 

   "ConnectionStrings": {
    "AzureSqlConnection": ""
  }


3) install entity framework packeages of version 8.0.24 packages in total 
Microsoft.EntityFrameworkCore 
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

4) add data folder and into that dbcontext code and also the model class Person okay 

5) go to program.cs file write this below code and in this what i am doing is that 


   var connectionString = builder.Configuration.GetConnectionString("AzureSqlConnection"); // here in appsetting u have to give this value //okay from statement 2 okay 
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
