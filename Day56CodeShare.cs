As there is a problem i am entering in update two times the id which is not needed in this scenatios you can go for DTO (Data Trasfer objects) as per design i have to create the DTO 
and work okay 

You can let Swagger reuse the route {id} value as the model Id so you only type it once, by removing the Id from the form model and binding it only from the route.

1. Remove Id from the body model
If you do not want to type Id in the form body, do not expose it in Employee for update; make a separate DTO without Id:

Go to Models folder and add this class 

  public class EmployeeUpdateDto
{
    [Required(ErrorMessage = "Please enter your firstname")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your lastname")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Please enter email id")]
    [EmailAddress(ErrorMessage = "Please enter valid email id")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please enter your age")]
    [Range(0, 100, ErrorMessage = "Please enter your age betwen 1 to 100 only ")]
    public int Age { get; set; }

    public string? ImagePath { get; set; }
}

then use this class in EmpController remember DTO has to be used only in Controller dont use in EmployeeService and and again dont use in EmpController two two times and make the code complex so 

[HttpPut("{id}")]
public async Task<ActionResult<Employee>> Update(
        int id,        [FromForm] EmployeeUpdateDto employeeDto,IFormFile? image)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        
            // map dto to entity
            var employee = new Employee
            {
                Id = id, // take from route only
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Age = employeeDto.Age,
                ImagePath = employeeDto.ImagePath
            };
        
            var updated = await _employeeService.UpdateEmployeeAsync(employee, image);
            if (updated == null)
                return NotFound("Employee not found to update");
        
            return Ok(updated);
        }

so after doing this much run the code and see the output everthing is working okay .

  
