
Add one class with the name ProdCat in Models folder 


    public class ProdCat
    {
        public string? prodname { set; get; }
        public string? catname { set; get; }
    }


 public ActionResult ProductsInCategory(string categoryname)
 {
     NorthWindContext cnt = new NorthWindContext();
     var productsinCategory = cnt.Products.
         Where(x => x.Category.CategoryName == categoryname).
         Select(x => new ProdCat
         {
         prodname=x.ProductName,
         catname=x.Category.CategoryName

         }).ToList();
     return View(productsinCategory);
 }

@model IEnumerable<DBFirstEFinAsp.netcoreDemo.Models.ProdCat>

@{
    ViewData["Title"] = "ProductsInCategory";
}

<h1>ProductsInCategory</h1>

<div class="container">
    <div class="row">
       
        <div class="col-lg-9">

<h2>Products in Category</h2>
        </div>
        <form method="get" action="/NorthWind/ProductsInCategory">
        <div class="col-lg-2">

            <input type="text" id="category" name="categoryname" 
                class="form-control" />
        </div>
        <div class="col-lg-1">
            <input type="submit" id="Searchproducts" 
                class="btn btn-primary" value="search"/>
        </div>
        </form>
    </div>
</div>
@if(Model.Count()==0)
{
    <table>
        <tr>
            <td>No products found</td>
        </tr>
    </table>
}
else
{
    
}
