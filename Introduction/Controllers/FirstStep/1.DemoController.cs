

using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo1Controller
    {
        public string Get()
        {

            string name = "JOHN";

            return "JOHN";
        }
    }
}
