
CRUD operation using a Model :
-----------------------------------------
Means for a model means for a class any class i want to define insert,update ,delete and read etc methods in Controller function means function for insert and function for update and all i want to write 
here i will use get and post methods and all i will validate the class means business rules also i will apply 

earlier manually i had gone into the view and written html code and embedded the model object s into it 
but now i will ask the visual studio to genrate the code for me in the view that thing is called as scafffolding.

so check program dog on this example ..


First add a model class Dog here 

 <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container-fluid">
                <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">DogMgtAPP</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <nav class="navbar navbar-expand-lg bg-primary navbar-dark">
                    <div class="container-fluid">
                        <a class="navbar-brand" asp-controller="Dog" asp-action="Index">DogApp</a>
                        <div class="collapse navbar-collapse">
                            <ul class="navbar-nav me-auto">
                                <li class="nav-item">
                                    <a class="nav-link" asp-controller="Dog" asp-action="Create">Create Dog</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <form class="d-flex" asp-controller="Dog" asp-action="Index" method="get">
                        <input class="form-control me-2" type="search" name="search" placeholder="Search by name" aria-label="Search" />
                        <button class="btn btn-outline-light" type="submit">Search</button>
                    </form>
                </nav>
            </div>
        </nav>

  create post code 
  -----------------
   if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var imageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var path = Path.Combine(_environment.WebRootPath, "images", imageName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    d.ImagePath = "/images/" + imageName;
                }

                dogs.Add(d);
                return RedirectToAction("Index");
            }

            return View(d);
