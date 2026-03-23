
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

