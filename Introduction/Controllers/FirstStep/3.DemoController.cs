

using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo3Controller : ControllerBase
    {
        [Route("GetEmployeeName")]
        public string Get()
        {

            string name = "JOHN";



            return "JOHN";
        }
    }
}
