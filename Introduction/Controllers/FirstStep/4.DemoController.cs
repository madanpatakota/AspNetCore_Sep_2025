

using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Unicode;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo4Controller : ControllerBase
    {
        [Route("GetEmployeeName")]
        public string Get()
        {
            string name = "JOHN1";

            if(name == "JOHN")
            {
               return "JOHN";
            }
            else
            {
               return "No Employee";
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