using Introduction.Controllers.Employees_2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace Introduction.Controllers.Employees_3
{


    //https://localhost:7051/api/EmployeeV3/CreateEmployee
    [ApiController]
    [Route("api/[Controller]")]

    public class EmployeeV3Controller : ControllerBase
    {
        public EmployeeV3Controller() { }



 //https://localhost:7051/api/EmployeeV2/GetEmployeesListByLocatinAndSalaryWithMultiQueryParams?empname=John&location=New%20York&salary=28000
        [HttpGet]  // if the request is data fetch then desing with httpget
        [Route("GetEmployeesListByLocatinAndSalaryWithMultiQueryParamsWithDTO")]
        public async Task<IActionResult> GetEmployeesListByLocatinAndSalaryWithQueryWithDTO(
           [FromQuery] EmployeeDTO employee)
        {
            var employeesList = await GetEmployees();  // given the resoponse to the guy who asked the data
            var result = employeesList.Where(x => x.EmpLocation == employee.Location && x.EmpSalary > employee.Salary && x.EmpName == employee.EmpName);
            if (!result.Any())
            {
                return NotFound($"No employees found with salary and location {employee.Location} - {employee.Salary} ");   // 404 Not found
            }
            else
            {
                return Ok(result);
            }
            //  return Ok(new List<string> { "JOHN", "PEter" });  // 200 success code . json
        }


        //request params / queryparams / body(huge parameters)



        //Post
        //1. Supports Request Body so that we can reduce the length of the url
        //2. Used for Create / Modify



        //https://localhost:7051/api/EmployeeV2/GetEmployeesList_filter
        [HttpPost]
        [Route("GetEmployeesList_filter")]
        public async Task<IActionResult> GetEmployeesList_filter(
           [FromBody] EmployeeDTO employee)
        {
            var employeesList = await GetEmployees();  // given the resoponse to the guy who asked the data
            var result = employeesList.Where(x => x.EmpLocation == employee.Location && x.EmpSalary > employee.Salary && x.EmpName == employee.EmpName);
            if (!result.Any())
            {
                return NotFound($"No employees found with salary and location {employee.Location} - {employee.Salary} ");   // 404 Not found
            }
            else
            {
                return Ok(result);
            }
        }



        //https://localhost:7051/api/EmployeeV3/CreateEmployee

        //public string Name { get; set; }
        //public string Location { get; set; }
        //public decimal Salary { get; set; }
        //public int Age { get; set; }
        //public DateTime JoiningDate { get; set; }
        //public DateTime? DOB { get; set; }
        //public string StreetAdress { get; set; }


        ////{
        //   namespace 
        
        ////}

        //Create the new user story
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(
           [FromBody] NewEmployeeDTO newemployee)
        {

           var result =    await NewEmployee(newemployee);
           if(result  == "Failed")
            {
                return BadRequest("Employee deatils are not good narmada . please give proepr details");
            }

            return Created("Api/Employeev3/CreateEmployee", newemployee);
        }



        //Create the new user story
        [HttpPost]
        [Route("CreateEmployee1")]
        public async Task<IActionResult> CreateEmployee1()
        {
            await Task.Delay (1000);
            return Ok("succes");
           
        }


        private async Task<string> NewEmployee(NewEmployeeDTO newemployee)
        {

            await Task.Delay(2000);

            if (string.IsNullOrWhiteSpace(newemployee.Name))
            {
                return "failed";
            }
            return "Success";

        }




























        //resource | action | endpoint 
        //create new empoloyy

            //1. Think that okay we will get the new record from the request

            // Side by side you and frontend developer needs to discuss what kind of data we need to communicate



            //User ---> Instagram app uses ----->  3 hours

            //PBI ---> User story

            //Enviornment : Dev , QA , UAT , CERT , Production

            //BA  : Venkatesh  

            //Prdocut owners :  Usha & Divya

            //Mgr : Mounika

            //S.Mgr :   b and hemanth

            //Enduser : Sravani & Bhavya (money)

            //Grooming Calls  



            //narmada ----> frontend developer   dev

            //DB     : pavitra 
            //Tester : Swapna 


            //  Madan    -----> .net developer














        private async Task<List<Employee>> GetEmployees()
        {
            await Task.Delay(2000);
            return _store();
        }


        private List<Employee> _store()
        {
            return new List<Employee>()
                {
                    new Employee() { EmpId = 1, EmpName = "Michel", EmpLocation = "New York", EmpSalary = 20000.89 },
                    new Employee() { EmpId = 2, EmpName = "Sarah",  EmpLocation = "London",   EmpSalary = 25000.50 },
                    new Employee() { EmpId = 3, EmpName = "Ravi",   EmpLocation = "Bangalore",EmpSalary = 18000.00 },
                    new Employee() { EmpId = 4, EmpName = "Emily",  EmpLocation = "New York", EmpSalary = 30000.75 },
                    new Employee() { EmpId = 5, EmpName = "John",   EmpLocation = "New York", EmpSalary = 22000.40 }
                };
        }
    }

}

public class EmployeeDTO
{
    public string EmpName { get; set; }
    public string Location { get; set; }
    public double Salary { get; set; }

}

public class NewEmployeeDTO
{
    public string? Name { get; set; }
    public string Location { get; set; }
    public decimal Salary { get; set; }
    public int Age { get; set; }
    public DateTime JoiningDate { get; set; }
    public DateTime? DOB { get; set; }
    public string? StreetAdress { get; set; }


}