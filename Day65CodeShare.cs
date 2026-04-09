
create an project with the name AzureFunctionsTangyWeb of asp.net core mvc and solution name should be AzureFunctionExample means inside the solution this is my first project 
with the name AzureFunctionsTangyWeb okay 

so set this as a start up project and check this project is running or not .

so now go to models  folder of this project and add this model like this 


  namespace AzureFunctionsTangyWeb.Models
{
    public class SalesRequest
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }
    }
}

Now go to index view of home controller and delete all content over there and add this design for the above model 

@model SalesRequest
<form method="post" enctype="multipart/form-data">
    <div class="text-center">
        <h1 class="display-4">Welcome</h1>
        <p>Enter your details to apply today!</p>
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
                Upload Resume:
            </div>
            <div class="col-6">
                <input type="file" class="form-control pt-1" name="file" />
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


Run the application and see the design of this index page once which is created based on above model 


