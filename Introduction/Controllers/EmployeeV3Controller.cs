using Microsoft.AspNetCore.Mvc;

namespace Introduction.EmployeeV3
{



    //200 , 201 , 500 , 404 , 403 , 

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeV3WithDIController : ControllerBase    // HighLigher Level  its giving the response to the clinet
    {
        // i need the demo 5 pm from mounika , bhavyan, sravani , divya , swapna , venkatesh ,
        //
        //
        // Audiance   -- no doubts
        // 
        // audinance  -- AddScoped why ?  

        private IEmployeeV3Reposiotry _imprepo;
        //IEmployeeV2Reposiotry   .Employees();
        //IEmployeeV2Reposiotry repo  ( new InMemoryEmployeeRepository)
        public EmployeeV3WithDIController(IEmployeeV3Reposiotry v3repo)  // InMemoryEmployeev3Repository
        {
            //_imprepo = new InMemoryEmployeev3Repository();
            _imprepo = v3repo;  // Here i am trying to create the instance of the class
        }


        //[HttpGet]
        //[Route("GetAllElmployees")]
        //public async Task<IActionResult> GetAllEmp()
        //{
        //    return Ok("success");
        //}

        //action
        //https://localhost:7115/api/EmployeeV2WithDI/GetAllElmployees
        [HttpGet]
        [Route("GetAllElmployees")]
        public async Task<IActionResult> GetAllEmp()
        {
            //_imprepo =  new InMemoryEmployeev3Repository();
            await Task.Delay(1000);
            var result = _imprepo.Employees();
            return Ok(result);
        }











        //action
        //https://localhost:7115/api/EmployeeV2WithDI/GetAllElmployees
        [HttpGet]
        [Route("GetAllElmployees1")]
        public async Task<IActionResult> GetAllEmp1()
        {
            _imprepo = new InMemoryEmployeev3Repository();
            await Task.Delay(1000);
            var result = _imprepo.Employees();
            return Ok(result);
        }


        //action
        //https://localhost:7115/api/EmployeeV2WithDI/GetAllElmployees
        [HttpGet]
        [Route("GetAllElmployees2")]
        public async Task<IActionResult> GetAllEmp2()
        {
            _imprepo = new InMemoryEmployeev3Repository();
            await Task.Delay(1000);
            var result = _imprepo.Employees();
            return Ok(result);
        }
    }

    public interface IEmployeeV3Reposiotry
    {
        List<EmployeeV2> Employees();
    }

    //Reposiroy
    public class InMemoryEmployeev3Repository : IEmployeeV3Reposiotry
    {

        public InMemoryEmployeev3Repository()
        {

        }


        public List<EmployeeV2> Employees() {
            return new List<EmployeeV2>
            {
                new EmployeeV2 { Id = 1, Name = "John", Department = "IT" },
                new EmployeeV2 { Id = 2, Name = "Sara", Department = "HR" }
            };
        }
    }


        public class EmployeeV2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }









}
