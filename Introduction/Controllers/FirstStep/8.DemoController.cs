


using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Unicode;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo8Controller : ControllerBase
    {
        public int GetTask1()
        {
            return 100;
        }

        public Task<int> GetTask2()
        {
            return Task.Run(() => { return 100; });
        }


        public Task<decimal> GetTask3()
        {
            return Task.Run<decimal>(() => { return 100; });   //100.00
        }

        public Task<decimal> GetTask4()
        {
            Task<decimal> task4 = Task.Run<decimal>(() => { return 100; });   //100.00
            return task4;
        }


        [Route("GetEmployeeName")]
        public IActionResult Get()
        {
            string name = "JOHN";
            return Ok(name);
        }


        public Task<IActionResult> Get1()
        {
            string name = "JOHN";

            return Task.Run<IActionResult>(()=>
            {
                return Ok(name);
            });
        }



        public Task<IActionResult> Get2()
        {
            string name = "JOHN";

            Task<IActionResult> task = Task.Run<IActionResult>(() =>
            {
                return Ok(name);
            });

            return task;
        }
    }
}


// Why we have to convert into Non-Task Method to Task Method?