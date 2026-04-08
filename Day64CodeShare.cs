First create an fucntion app in azure portal for that steps are there in video u can check it what to select and what to not 

Go to visual studio and create a function app locally now here name given as CalcFunc so this will become the namespace here and inside name space 
  some default classes will be there with name as function1 and in function app u can write as many functions u can okay .

  

so while creating some default code u will get means class name and functionname all will be same as function1 here i am doing sum so i had changed 
the class name and function name as same as sum here and even constructor also i changed as sum here 

while creating app select Httptrigger means your app will be called some body request though http url so i had selected that option from drop down 
if any Blob is called then blob trigger function u have to select okay 



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CalcFunc;

public class Sum
{
    private readonly ILogger<Sum> _logger;

    public Sum(ILogger<Sum> logger)
    {
        _logger = logger;
    }

    [Function("Sum")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        int x =int.Parse(req.Query["x"]);
        int y = int.Parse(req.Query["y"]);
        int result = x + y;

        return new OkObjectResult(result);
    }
}

so 
