
you have to put all your code in chat gpt and have to give this prompt but right now dont give this prompt as i had given and taken out code for the above tasks now just keep this prompt with you and use in project differentn stages In the above coding i had written multiple put and post methods so sinlge one only i will take all i will not take 

Prompt:
    ---------
    Here i had written the code in web api controller i want it to put it in interface 
    IEmployee and I want to implement EmployeeService and then i want to use it in 
    web api controller where i will call a web api controller with read and write actions
    so provide me the three codes one is IEmployee and then EmployeeService implementing interface and 
    finally give create a new EmployeeController of web api with read and write actions substituing Employee service
    
so in the project only add the interface like this and also add class like this 

  
In the project add IEmployee interface how right clik and select code template from asp.net core and give name as IEmployee

using Microsoft.AspNetCore.Mvc;
using WebApiInAsp.netcoreMvcDemo.Models;

namespace WebApiInAsp.netcoreMvcDemo
{
    public interface IEmployee
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee?> UpdateEmployeeAsync(Employee employee);
        Task<Employee?> DeleteEmployeeAsync(int id);
    }
}


Then add inside the project only EmployeeService class like this which is implemeting above interface which looks like this 

    using WebApiInAsp.netcoreMvcDemo.Models;

namespace WebApiInAsp.netcoreMvcDemo
{
    public class EmployeeService : IEmployee
    {
        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}

updated codes 
---------------
 public async Task<List<Employee>> GetAllEmployeesAsync()
 {
     return await _context.employees.ToListAsync();
 }

 public async Task<Employee?> GetEmployeeByIdAsync(int id)
 {
     return await _context.employees.FindAsync(id);
 }

 public async Task<Employee> AddEmployeeAsync(Employee employee)
 {
     await  _context.employees.AddAsync(employee);
     await _context.SaveChangesAsync();
     return employee;
 }


 public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
 {
     var exsistng = await _context.employees.FindAsync(employee.Id);
     if(exsistng==null)
     {
         return null;
     }
     exsistng.FirstName = employee.FirstName;
     exsistng.LastName = employee.LastName;
     exsistng.Email = employee.Email;
     exsistng.Age = employee.Age;
     await _context.SaveChangesAsync();
     return exsistng;
 }
   public async Task<Employee?> DeleteEmployeeAsync(int id)
   {
       var employee = await _context.employees.FindAsync(id);
       if (employee == null) return null;
       _context.employees.Remove(employee);
       await _context.SaveChangesAsync();
       return employee;
   }

complete code is here 
------------------------
using Microsoft.EntityFrameworkCore;
using WebApiInAsp.netcoreMvcDemo.Models;

namespace WebApiInAsp.netcoreMvcDemo
{
    public class EmployeeService : IEmployee
    {
        private readonly EmpContext _context;
        public EmployeeService(EmpContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await  _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null) return null;
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.employees.FindAsync(id);
        }

        public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
        {
            var exsistng = await _context.employees.FindAsync(employee.Id);
            if(exsistng==null)
            {
                return null;
            }
            exsistng.FirstName = employee.FirstName;
            exsistng.LastName = employee.LastName;
            exsistng.Email = employee.Email;
            exsistng.Age = employee.Age;
            await _context.SaveChangesAsync();
            return exsistng;
        }
    }
}
Now come to EmpController now do the coding like this 

    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiInAsp.netcoreMvcDemo.Models;

namespace WebApiInAsp.netcoreMvcDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmployee _employeeService;
        public EmpController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>>  GetAll()
        {
            return Ok(await _employeeService.GetAllEmployeesAsync());
        }

        [HttpGet("{id}")]
       public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound("Employee not found");
            return Ok(employee);
        }
         
      
    }
}

final code
-----------
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiInAsp.netcoreMvcDemo.Models;

namespace WebApiInAsp.netcoreMvcDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmployee _employeeService;
        public EmpController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>>  GetAll()
        {
            return Ok(await _employeeService.GetAllEmployeesAsync());
        }

        [HttpGet("{id}")]
       public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound("Employee not found");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            var added = await _employeeService.AddEmployeeAsync(employee);
            return Ok(added);
        }
        [HttpPut]
        public async Task<ActionResult<Employee>> Update(Employee employee)
        {
            var updated = await _employeeService.UpdateEmployeeAsync(employee);
            if (updated == null)
                return NotFound("Employee not found to update");
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(id);
            if (deleted == null)
                return NotFound("Employee not foudn to delete");
            return Ok(deleted);

        }
         
      
    }
}

