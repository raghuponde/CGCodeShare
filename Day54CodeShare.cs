create one folder in day54 with name jquerydemos2 and add one html file into it with name dollareachdemos.html and paste the below code into it 

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js">

    </script>
    <script type="text/javascript" language="Javascript">
         var friends = ["sunitha", "mahesh", "kiran", "sanmay"];

            var objs = [{ "name": "sita", "age": "23" }, { "name": "rajesh", "age": "55" }, { "name": "kiran", "age": "22" },
            { "name": "praveen", "age": "27" }]

            $(document).ready();
        </script>
</head>
<body>
    <ul>
        <li>US</li>
        <li>India</li>
        <li>UK</li>
        <li>Canada</li>
        <li>Australia</li>
    </ul>
    
    <div id="divresult" style="background-color: yellow;">
    
     
    
    </div> 
</body>
</html>

updated code 
--------------
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js">

    </script>
    <script type="text/javascript" language="Javascript">
        var friends = ["sunitha", "mahesh", "kiran", "sanmay"];

        var objs = [{ "name": "sita", "age": "23" }, { "name": "rajesh", "age": "55" }, { "name": "kiran", "age": "22" },
        { "name": "praveen", "age": "27" }]

        $(document).ready(

            function () {

                $.each(friends, function (index, value) {
                    console.log((index + 1) + ":----->" + value);

                })

                $.each(objs, function (index, value) {
                    console.log((index + 1) + ":" + value.name + " is having age " + value.age);
                })

                console.log("I want to iterate list")
                $("li").each(function (index, element) {
                    alert((index + 1) + ": " + $(element).text())
                })

                console.log("I want to iterate using reference")

                $("li").each(function (index) {
                    alert((index + 1) + ":" + $(this).text());
                })

                console.log("iterating collection and puttin in div tage result ");

                var results = "";
                $.each(friends, function (index, value) {

                    results += "<br/><li>" + value + "</li>"
                })
                $("#divresult").html(results);



            }






        );
    </script>
</head>

<body>
    <ul>
        <li>US</li>
        <li>India</li>
        <li>UK</li>
        <li>Canada</li>
        <li>Australia</li>
    </ul>

    <div id="divresult" style="background-color: yellow;">



    </div>
</body>

</html>

go to this url https://jsonplaceholder.typicode.com/users and check the data i need to read the data present at this url and display it  in table


so paste the below code like this for in the new file ajaxdemo1.html 

<!DOCTYPE html>
<html>

<head>
    <title>jQuery Ajax Table Example</title>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js">

    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(

            function () {
                $.ajax({
                    url: "https://jsonplaceholder.typicode.com/users",
                    type: "GET",
                    success: function (data) {
                        var tablebody = ""
                        $.each(data, function (index, user) {

                            tablebody += "<tr>";
                            tablebody += "<td>" + user.id + "</td>"
                            tablebody += "<td>" + user.name + "</td>"
                            tablebody += "<td>" + user.email + "</td>"
                            tablebody += "</tr>"
                        })
                        $("#userTable tbody").html(tablebody);
                    },
                    error: function () {
                        alert("failed to retrive data ")
                    }

                })

            }
        )

    </script>
</head>

<body>

    <h2>User Data</h2>
    <table border="1" id="userTable">
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Email</th>
            </tr>
        </thead>
        <tbody>
            <!-- Data will be loaded here -->
        </tbody>
    </table>
</body>
</html>

using for loop
-----------------
same code using for loop when u are using for loop empty array is neded 

<!DOCTYPE html>
<html>

<head>
    <title>jQuery Ajax Table Example - with For Loop</title>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                url: "https://jsonplaceholder.typicode.com/users",
                type: "GET",
                success: function (data) {
                    // Create an array to hold all the rows
                    var tableRows = [];

                    // Use a traditional for loop to iterate
                    for (var i = 0; i < data.length; i++) {
                        var user = data[i];
                        var row = "<tr>";
                        row += "<td>" + user.id + "</td>";
                        row += "<td>" + user.name + "</td>";
                        row += "<td>" + user.email + "</td>";
                        row += "</tr>";

                        // Push each row into the array
                        tableRows.push(row);
                    }

                    // Join all rows into a single string and insert into table body
                    $("#userTable tbody").html(tableRows.join(""));
                },
                error: function () {
                    alert("Failed to retrieve data.");
                }
            });
        });
    </script>
</head>

<body>

    <h2>User Data</h2>
    <table border="1" id="userTable">
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Email</th>
            </tr>
        </thead>
        <tbody>
            <!-- Data will be loaded here -->
        </tbody>
    </table>

</body>

</html>

web api demo 
--------------
create a new asp.net core mvc project now 

add a new model class in Models folder 

using System.ComponentModel.DataAnnotations;

namespace WebApiInAsp.netcoreMvcDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your firstname")]
        public string? FirstName { set; get; }

        [Required(ErrorMessage = "Please enter your lastname")]
        public string? LastName { set; get; }

        [Required(ErrorMessage = "Please enter email id")]
        [EmailAddress(ErrorMessage = "Please enter valid email id")]
        public string? Email { set; get; }

        [Required(ErrorMessage = "Please enter your age")]
        [Range(0, 100, ErrorMessage = "Please enter your age betwen 1 to 100 only ")]

        public int Age { set; get; }
    }
}
Add dependencies 

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools


Next add EmpContext class also like this in Models folder only 
using Microsoft.EntityFrameworkCore;

namespace WebApiInAsp.netcoreMvcDemo.Models
{
    public class EmpContext:DbContext
    {
        public EmpContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        {

        }

        public DbSet<Employee> employees { set; get; }

    }
}

in app setting write like this 

,
  "ConnectionStrings": {
    "constring": "Data Source=LAPTOP-4G8BHPK9\\SQLEXPRESS;initial catalog=EmpCg;Integrated Security=true;Encrypt=true;TrustServerCertificate=true;"
  }

 go to program.cs 
  write like this afer frist line  

      builder.Services.AddDbContext<EmpContext>
     (options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

build the solution once 

then run migrations and see the tables there and add some dummy data into the employees table now 

add some data graphically using right edit and add values into the employees table

    Now add one Controller of web api template empty one addd it 

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiInAsp.netcoreMvcDemo.Models;

namespace WebApiInAsp.netcoreMvcDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly EmpContext _context;
        public EmpController(EmpContext context)
        {
            _context = context;
        }
    }
}

https://localhost:7230/api/Emp

type this url u can see it 

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiInAsp.netcoreMvcDemo.Models;

namespace WebApiInAsp.netcoreMvcDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly EmpContext _context;
        public EmpController(EmpContext context)
        {
            _context = context;
        }
        public List<Employee> getemployees()
        {
            return _context.employees.ToList();
        }
        public List<Employee> getemployees2()
        {
            return _context.employees.ToList();
        }
    }
}
now to test the web api  I need some testing tools like postman or swagger 

so in Program.cs i will configure swagger to test the web api 

steps to configure 
-------------------
so I will install from packge manage console this command 

Install-Package Swashbuckle.AspNetCore

and do changes in program.cs like this 


Program.cs 
------------
using CodeFirstEFDEmo.Models;
using CodeFirstEFDEmo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFDEmo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IPost, PostRepository>();


            builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddEndpointsApiExplorer(); // Required for Swagger
            builder.Services.AddSwaggerGen();           // Adds Swagger support

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // ✅ Add this line
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}




