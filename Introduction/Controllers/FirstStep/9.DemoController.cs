

using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers.FirstStep
{

    [ApiController]
    [Route("[Controller]")]
    public class Demo9Controller : ControllerBase
    {

        //public Task<IActionResult> Get2()
        //{
        //    string name = "JOHN";

        //    Task<IActionResult> task = Task.Run<IActionResult>(() =>
        //    {
        //        return Ok(name);
        //    });

        //    return task;
        //}

        public Task<long> getID()
        {
            Task<long> task1 = Task.Run<long>(() =>
            {
                return 1;

            });
            return task1;
        }


        public Task<IActionResult> Get1()
        {
            string name = "JOHN";

            Task<IActionResult> task1 = Task.Run<IActionResult>(() =>
            {
                return Ok(name);
            });

            return task1;
        }



        //Problem here about to the add the value while delyaing
        public Task<IActionResult> Get2()
        {
            string name = "JOHN";

            Task task1 = Task.Delay(2000).ContinueWith((task) => { name = "Peter"; });

            Task<IActionResult> task2 = Task.Run<IActionResult>(() =>
            {
                return Ok(name);
            });

            return task2;
        }


        //resolved by adding wait() method
        //But here its still its not a async call  wait() is blocking the code..
        public Task<IActionResult> Get3()
        {
            string name = "JOHN";

            Task task1 = Task.Delay(2000).ContinueWith((task) => { name = "Peter"; });
            task1.Wait();  // Here i am blocking synchronouly

            //return Ok(name);
            Task<IActionResult> task2 = Task.Run<IActionResult>(() =>
            {
                return Ok(name);
            });

            return task2;
        }



        public async Task<int> getNo()
        {
            await Task.Delay(5000).ContinueWith((task)=> { Console.WriteLine("Hello world"); });
            return 1;
        }

        public async Task<string> getName()
        {
            await Task.Delay(5000).ContinueWith((task) => { Console.WriteLine("Hello world"); });

            Task<string> task1 = Task.Run(() => { return "John"; });

            return "John";
        }

        public async Task<IActionResult> Get5()
        {
            string name = "JOHN";

            Task task1 = Task.Delay(2000).ContinueWith((task) => { name = "Peter"; });
            
            await task1;


            //while its being as async calls no need to return the Task<IActionResult> instead you can return the IActionResult
            //Task<IActionResult> task2 = Task.Run<IActionResult>(() =>
            //{
            //    return Ok(name);
            //});

            return Ok(name);


        }




        public async Task<IActionResult> Get6()
        {
            string name = "JOHN";

            Task task1 = Task.Delay(2000).ContinueWith((task) => { name = "Peter"; });
            //task1.Wait();  // Here i am blocking synchronouly

            await task1;

            //Task TaskOutut = Task.Run<IActionResult>(() =>
            //{
            return Ok(name);
            //});

            //return 

        }
    }

}




//Relation b/w OkObjectresult and Iactionrestult

//Response headers

//Content - Type
//text / plain; charset = utf - 8
//Date
//Wed, 23 Sep 2026 06:00:47 GMT
//Server
//Kestrel
//Transfer-Encoding
//chunked