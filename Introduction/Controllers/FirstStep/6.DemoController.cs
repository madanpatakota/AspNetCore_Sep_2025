

using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Unicode;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo6Controller : ControllerBase
    {
        [Route("GetEmployeeName")]
        public IActionResult Get()
        {
            string[] names = ["JOHN1","Peter"];

            if (names.Length == 2)
            {
               return Ok(names);
            }
            else
            {
               return BadRequest("No Employee");
            }
        }
    }
}


// Here Explain why I Action Result 
