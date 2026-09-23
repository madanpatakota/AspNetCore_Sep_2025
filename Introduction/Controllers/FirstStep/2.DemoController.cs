

using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo2Controller
    {


        [Route("GetEmployeeName")]
        public string Get()
        {

            string name = "JOHN";

            return "JOHN";
        }
    }
}
