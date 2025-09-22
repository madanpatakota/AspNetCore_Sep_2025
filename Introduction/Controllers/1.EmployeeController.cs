using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


//Postman 1 day fire   - this is very common testers , BA , DB , frontend , backend , freshers
// Testing your apis weahter your request and response is properly working on thtat


namespace Introduction.Controllers.Employees_1
{

    //syntax : https://localhost:7051/api/EmployeeV1/GetEmployeesList

    //app-root  app-compa app-compb

    //asp.netCore server | kestral things that this class able to create the endpoints 


    //controllerbase is a class which is useful for to prepare the status to responses 
    [ApiController]
    [Route("api/[Controller]")]

    //https://localhost:7051
    //http:localhost:72

    public class EmployeeV1Controller : ControllerBase
    {
        public EmployeeV1Controller() { }

        //[HttpGet]  // if the request is data fetch then desing with httpget
        //[Route("GetEmployeesList")]
        //public async Task<IActionResult> GetEmployeesList() {
        //    await Task.Delay(5000);  // given the resoponse to the guy who asked the data
        //    return Ok(new List<string> { "JOHN", "PEter" });  // 200 success code . json
        //}



        // 200 Ok


        [HttpGet]  // if the request is data fetch then desing with httpget
        [Route("GetEmployeesList")]
        public async Task<IActionResult> GetEmployeesList()
        {


            string EmpName = "Madan";


            var employeesList = await GetEmployees();  // given the resoponse to the guy who asked the data


            var count =   employeesList.Where(x => x == EmpName).Count();  


            if(count == 0)
            {
                return NotFound($"No employees found with the name of {EmpName} ");   // 404 Not found
            }
            return Ok(new List<string> { "JOHN", "PEter" });  // 200 success code . json
        }



        private async Task<List<string>> GetEmployees()
        {
            await Task.Delay(2000);
            return _store();
        }


        private  List<string> _store()
        {

            return new List<string> { "JOHN", "PEter" , "PEter" };
        }


       


    }
}
