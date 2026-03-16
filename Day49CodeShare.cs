
DbFirst approach of Entity Framework in asp.net core mvc 
*********************************************************

--->First Open mvc core app with 8.0 version 

--->add three dependencies using nugget package manager 8.0.24 version 


  Microsoft.EntityFrameworkCore
   Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools


--->then in package manager console fire this command 

Scaffold-DbContext "Server=LAPTOP-4G8BHPK9\SQLEXPRESS;Database=NorthWind;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context NorthWindContext -Tables CustomProducts -Force

change above as per your server and as per your db okay 

so in models all classes will be generated 
