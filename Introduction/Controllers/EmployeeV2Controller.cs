using Microsoft.AspNetCore.Mvc;

namespace Introduction
{



    //200 , 201 , 500 , 404 , 403 , 

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeV2WithDI : ControllerBase    // HighLigher Level  its giving the response to the clinet
    {
        // i need the demo 5 pm from mounika , bhavyan, sravani , divya , swapna , venkatesh ,
        //
        //
        // Audiance   -- no doubts
        // 
        // audinance  -- AddScoped why ?  

        private IEmployeeV2Reposiotry _imprepo;
        //IEmployeeV2Reposiotry   .Employees();
        //IEmployeeV2Reposiotry repo  ( new InMemoryEmployeeRepository)
        public EmployeeV2WithDI(IEmployeeV2Reposiotry repo)
        {
            _imprepo = repo;  // Here i am trying to create the instance of the class
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
            //_repo =  new EmployeeReposiotry();
            await Task.Delay(1000);
            var result = _repo.Employees();
            return Ok(result);
        }
    }

    public interface IEmployeeV2Reposiotry
    {
        List<EmployeeV2> Employees();
    }

    //Reposiroy
    public class InMemoryEmployeeRepository : IEmployeeV2Reposiotry
    {

        public InMemoryEmployeeRepository(int id , string justnothing)
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
