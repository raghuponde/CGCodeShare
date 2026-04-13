
create one asp .net core mvc application with name AzureSpookyLoginApp

add one model class into the models folder with the name 

using System.ComponentModel.DataAnnotations;

namespace AzureSpookyLogicApp.Models
{
    public class SpookyRequest
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

    }
}

Go to Home Controller index view 

and remove that desing and keep this design provided below 

@model SpookyRequest
<form method="post" enctype="multipart/form-data">
    <div class="text-center">
        <h1 class="display-4">Welcome to Spooky Request Logic App</h1>
    </div>
    <div class="text-center">
        <div class="row py-1">
            <div class="col-3">
                Name:
            </div>
            <div class="col-6">
                <input asp-for="Name" class="form-control" />
            </div>
        </div>
        <div class="row py-1">
            <div class="col-3">
                Email:
            </div>
            <div class="col-6">
                <input asp-for="Email" class="form-control" />
            </div>
        </div>
        <div class="row py-1">
            <div class="col-3">
                Phone:
            </div>
            <div class="col-6">
                <input asp-for="Phone" class="form-control" />
            </div>
        </div>
      

        <div class="row py-1">
            <div class="col-3">
            </div>
            <div class="col-6">
                <button type="submit" class="btn btn-success">Apply</button>
            </div>
        </div>
    </div>
</form>

add the following package in Newtonsoft.Json of stable version in the project 

and in program.cs add this   builder.Services.AddHttpClient();

  // Add services to the container.
  builder.Services.AddControllersWithViews();
  builder.Services.AddHttpClient();

Then in the Home controller add this 

       private readonly IHttpClientFactory _httpClientFactory;

   public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
   {
       _logger = logger;
       _httpClientFactory = httpClientFactory;
   }

