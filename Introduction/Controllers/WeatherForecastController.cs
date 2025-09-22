using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{

    //attribute     - communicate to the asp.net core this
    //class is useful builing the apis
    [ApiController]

    //route  addrubte that defines the base url path for the controller
    //controller its kind of placeholder that automatically
    //use the class(EmployeesController) name 
    [Route("api/[controller]")]  //api for prefix


    //app-root
    //app-compA
    //app-compB
    // EmployeesController using this i can desined the Apis

    public class EmployeesController : ControllerBase
    {

        //_______________________________/GetEmpName

        //https://localhost:7115/api/Employees/GetEmpName
        [HttpGet]   // return the data
        [Route("GetEmpName")]
        public IActionResult GetEmpName()

            //not found or OK
        {
            //string empname = null;
            //return empname.ToUpper();

            string empname = "Madan";

            if(empname == null)
            {
                return NotFound(new { Message = "not found" });
            }

            return Ok("JOHN");


        }


        //always 200,  404 

        // i did't prepare the asyync
        // i did't add status code
        // Use this end point into the anuglarhttp App and tell me ouputu



        [HttpGet]   // return the data
        [Route("GetMgrName")]
        //https://localhost:7115/api/Employees/GetEmpName
        public string GetMgrName()
        {
            return "Robert";
        }

    }
}



//https://localhost:7115/api/Employees/GetEmpName
//https://localhost:7115/api/Employees/GetMgrName





