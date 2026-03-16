
DbFirst approach of Entity Framework in asp.net core mvc 
*********************************************************

--->First Open mvc core app with 8.0 version 

--->add three dependencies using nugget package manager 8.0.24 version 


  Microsoft.EntityFrameworkCore
   Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools


--->then in package manager console fire this command 

Scaffold-DbContext 'Data Source=LAPTOP-4G8BHPK9\SQLEXPRESS;initial catalog=NORTHWND;Integrated Security=true;' Microsoft.EntityFrameWorkCore.SqlServer -OutputDir Models

change above as per your server and as per your db okay 

so in models all classes will be generated 
