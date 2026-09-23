

using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Unicode;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo5Controller : ControllerBase
    {
        [Route("GetEmployeeName")]
        public OkObjectResult Get()
        {
            string name = "JOHN1";

            if(name == "JOHN")
            {
               return Ok("JOHN");
            }

            return Ok("No Employee");
            //else
            //{
            //   return BadRequest("No Employee");
            //}
        }
    }
}


// Here tell me what is OkObjectResult