

using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo10Controller : ControllerBase
    {

        [Route("GetEmployeeName")]
        public async Task<IActionResult> Get()
        {
            string str = "JOHN";

            await Task.Delay(2000).ContinueWith((task) =>
            {
                str = "JOHN1";
            });

            //return Ok(str);
            return Ok(str);
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