
  <form asp-action="SetA" method="post">
        <button type="submit" class="btn btn-primary">Set A to 10</button>
    </form>

    <form asp-action="GetA" method="post">
        <button type="submit" class="btn btn-secondary">Get A Value</button>
    </form>

    <p>Value of A: @ViewBag.AValue</p>


In the Home conotorller 

--------------------

 private int a = 0;

 [HttpPost]
 public IActionResult SetA()
 {
     a = 10;
     ViewBag.AValue = "A has been set to 10 ";
     return View("Index");
 }
 [HttpPost]
 public IActionResult GetA()
 {
     ViewBag.AValue = $"A is currently :{a}";
     return View("Index");
 }

go to Models folder add one class LoginViewModel 

   using System.ComponentModel.DataAnnotations;

namespace WebApplication22.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
Add one controlller with the name AccountController which is empty one of mvc type 

using Microsoft.AspNetCore.Mvc;
using StateMgtDemoinAsp.netcore.Models;

namespace StateMgtDemoinAsp.netcore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(1)// set cookie
                };
                Response.Cookies.Append("UserName", model.Username, cookieOptions);
                return RedirectToAction("Welcome");
            }
            return View(model);
        }

    }
}

add view for Login get method it is create with model LoginViewModel 

@model StateMgtDemoinAsp.netcore.Models.LoginViewModel

@{
    ViewData["Title"] = "Login";
}

<h1>Login</h1>

<h4>LoginViewModel</h4>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Login">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="Username" class="control-label"></label>
                <input asp-for="Username" class="form-control" />
                <span asp-validation-for="Username" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Password" class="control-label"></label>
                <input asp-for="Password" class="form-control" />
                <span asp-validation-for="Password" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Create" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Back to List</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}

next add Welcome action methd and logout action methods 
 public IActionResult Welcome()
 {
     if(Request.Cookies.ContainsKey("UserName"))
     {
         string username = Request.Cookies["UserName"];
         ViewBag.UserName = username;
     }
     else
     {
         return RedirectToAction("Login");
     }
   return View();
 }

 [HttpPost]
 public IActionResult Logout()
 {
     Response.Cookies.Delete("UserName");
     return RedirectToAction("Login");
 }

Now add welcome view now here empty page and put my desingin

@{
    ViewData["Title"] = "Welcome";
}

<h1>Welcome</h1>

@if (ViewBag.UserName != null)
{
    <h2>Welcome, @ViewBag.UserName!</h2>
}
<button type="button" class="btn btn-primary ">click me</button>
<form asp-action="Logout" method="post">
    <button type="submit" class="btn btn-danger">Logout</button>
</form>

same codng i want to do using session here session is server side i need to set the session in the midddleware means program.cs file i need to set 
  so same programming using session 

  go to program .cs and write this code 

   // Add session service with a timeout (set to 30 minutes here).
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1); // Session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // Required for GDPR compliance
            });





