using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


//Postman 1 day fire   - this is very common testers , BA , DB , frontend , backend , freshers
// Testing your apis weahter your request and response is properly working on thtat

// DI , GUID , static class , angular , headers , params , body(post) , put , pathc , delete



namespace Introduction.Controllers.Employees_2
{

    [ApiController]
    [Route("api/[Controller]")]

    public class EmployeeV2Controller : ControllerBase
    {
        public EmployeeV2Controller() { }


        //lets focus on the request url


        //Route paramters

        //syntax : https://localhost:7051/api/EmployeeV2/GetEmployeesList/1

        [HttpGet]  // if the request is data fetch then desing with httpget
        [Route("GetEmployeesList/{id:int}")]
        public async Task<IActionResult> GetEmployeesList(int Id)
        {
            var employeesList = await GetEmployees();  // given the resoponse to the guy who asked the data
            var result = employeesList.Where(x => x.EmpId == Id);
            if (!result.Any())
            {
                return NotFound($"No employees found with the empid  of {Id} ");   // 404 Not found
            }
            else
            {
               return Ok(result.First());
            }
              //  return Ok(new List<string> { "JOHN", "PEter" });  // 200 success code . json
        }





        //Route paramters

        //syntax : https://localhost:7051/api/EmployeeV2/GetEmployeesListByLocatinAndSalary/New%20York/28000

        //syntax: _---------------------/api/[controller]/[actionname]
        //: → %3A   / → %2F  ? → %3F  & → %26    = → %3D   @ → %40




        [HttpGet]  // if the request is data fetch then desing with httpget
        [Route("GetEmployeesListByLocatinAndSalary/{location}/{salary:double}")]
        public async Task<IActionResult> GetEmployeesListByLocatinAndSalary(string location , double salary)
        {
            var employeesList = await GetEmployees();  // given the resoponse to the guy who asked the data
            var result = employeesList.Where(x => x.EmpLocation == location && x.EmpSalary > salary);
            if (!result.Any())
            {
                return NotFound($"No employees found with salary and location {location} - {salary} ");   // 404 Not found
            }
            else
            {
                return Ok(result);
            }
            //  return Ok(new List<string> { "JOHN", "PEter" });  // 200 success code . json
        }





        //https://localhost:7051/api/EmployeeV2/GetEmployeesListByLocatinAndSalaryWithQuery?location=New%20York

        [HttpGet]  // if the request is data fetch then desing with httpget
        [Route("GetEmployeesListByLocatinAndSalaryWithQuery")]
        public async Task<IActionResult> GetEmployeesListByLocatinAndSalaryWithQuery([FromQuery(Name = "location")]  string locationName)
        {
            var employeesList = await GetEmployees();  // given the resoponse to the guy who asked the data
            var result = employeesList.Where(x => x.EmpLocation == locationName);
            if (!result.Any())
            {
                return NotFound($"No employees found with salary and location {locationName} - {locationName} ");   // 404 Not found
            }
            else
            {
                return Ok(result);
            }
            //  return Ok(new List<string> { "JOHN", "PEter" });  // 200 success code . json
        }






        //https://localhost:7051/api/EmployeeV2/GetEmployeesListByLocatinAndSalaryWithMultiQueryParams?location=New%20York&salary=28000

        [HttpGet]  // if the request is data fetch then desing with httpget
        [Route("GetEmployeesListByLocatinAndSalaryWithMultiQueryParams")]
        public async Task<IActionResult> GetEmployeesListByLocatinAndSalaryWithQuery(
            [FromQuery(Name = "location")] string locationName , 
            [FromQuery(Name = "salary")] double salary )
        {
            var employeesList = await GetEmployees();  // given the resoponse to the guy who asked the data
            var result = employeesList.Where(x => x.EmpLocation == locationName && x.EmpSalary > salary);
            if (!result.Any())
            {
                return NotFound($"No employees found with salary and location {locationName} - {locationName} ");   // 404 Not found
            }
            else
            {
                return Ok(result);
            }
            //  return Ok(new List<string> { "JOHN", "PEter" });  // 200 success code . json
        }


























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


    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLocation{ get; set; }
        public double EmpSalary { get; set; }
    }
}