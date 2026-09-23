

using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Unicode;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo7Controller : ControllerBase
    {
        [Route("GetEmployeeName")]
        public IActionResult Get()
        {
            string name = "JOHN";


            //Veryimportant note Do't write single Line Task.Delay(5000)
            Task output = Task.Delay(5000).ContinueWith(task => { name = "JOHN1"; });
         
           

            if(name == "JOHN")
            {
               return Ok("Yes your name is JOHN");
            }
            else
            {
               return BadRequest("No Employee");
            }
        }
    }
}

//Response headers

//Content - Type
//text / plain; charset = utf - 8
//Date
//Wed, 23 Sep 2026 06:00:47 GMT
//Server
//Kestrel
//Transfer-Encoding
//chunked