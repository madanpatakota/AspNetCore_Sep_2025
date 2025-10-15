using Introduction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class TestController : ControllerBase
    {

        //https://localhost:7115/Test/GetCustomers
        [HttpGet("GetAllCustomers")]
        public string[] GetCustomers()
        {
            return ["Test"];
        }


    }
}
