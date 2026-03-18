
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
    <div class="row">
        <div class="col-lg-12">
            <table id="prodlist" width="80%" cellpadding="5" cellspacing="5"
            class="table-striped table-hover">
           <thead>
               <tr>
                   <th style="padding:15px" >Prodname</th>
                   <th style="padding:15px">categaoryname</th>
               </tr>
           </thead>
           <tbody>
               @foreach(var prod in Model)
                    {
                        <tr>
                            <td style="padding:15px">@prod.prodname</td>
                            <td style="padding:15px">@prod.catname</td>
                        </tr>
                    }

           </tbody>
        
            </table>
        </div>
    </div>
}
   public ActionResult OrderRange(string range)
   {
       NorthWindContext cnt = new NorthWindContext();
       var range1 = Convert.ToInt16(range);
       var custOrderCount = cnt.Customers
           .Where(x => x.Orders.Count > range1).
           Select(x => new Customer
           {
               CustomerId = x.CustomerId,
               ContactName = x.ContactName,
               

           });
       return View(custOrderCount);
           
   }

@model IEnumerable<DBFirstEFinAsp.netcoreDemo.Models.Customer>

@{
    ViewData["Title"] = "OrderRange";
}

<h1>OrderRange</h1>
<div class="row">
    <div class="col-lg-9">
        <h3>Find customers more thann </h3>
    </div>
    <form method="get" action="/NorthWiind/OrderRange">
    <div class="col-lg-2">
        <select name="range" id="orderrange">
            <option selected value="">Select range</option>
            <option value="5">Five</option>
            <option value="10">Ten</option>
            <option value="15">Fifteen</option>
            <option value="20">Twenty</option>
        </select>
    </div>
    <div class="col-lg-1">
        <br/>
        <input type="submit" id="findcustomers" value="searchcustomers" 
            class="btn btn-info"/>
    </div>
  </form>
</div>
@if(Model.Count()==0)
{
   <table>
       <tr>
           <td>
                <h3>No customers found </h3>
           </td>
       </tr>
   </table>
}
else
{
    <div class="row">
        <div class="col-lg-12">
            <table id="orderlist" width="80%" cellpadding="7" cellspacing="7"
                   class="table-striped table-hover">
                <thead>
                    <tr>
                        <th>Customer Id </th>
                        <th>Contact Name </th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var cust in Model)
                    {
                        <tr>
                            <td style="padding:15px">@cust.CustomerId </td>
                            <td style="padding:15px">@cust.ContactName</td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>
    </div>
}
