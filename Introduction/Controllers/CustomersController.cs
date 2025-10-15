using Introduction.DTOs;
using Introduction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class CustomersController : ControllerBase
    {

        ICustomerService _custoemrSErvice;
        public CustomersController(ICustomerService customerService) {
        
            _custoemrSErvice = customerService;
        }



        //https://localhost:7115/Customers/GetCustomers
        //Entire data..
        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var data = await _custoemrSErvice.GetAllCustomersAsync();
            return data is null ? NotFound() : Ok(data);
        }



        //https://localhost:7115/Customers/GetCustomersById/1
        //Entire data..
        [HttpGet("GetCustomersById/{ID}")]
        public async Task<IActionResult> GetCustomersById(int ID)
        {
            var data =   await  _custoemrSErvice.GetCustomerByIdAsync(ID);
            return data is null ? NotFound() : Ok(data);
        }



        //Datatype - single avlue int , string , decimal

        //Complex type --- > intrface , class


        //you need to capture the obect from postman so thatn you have to prepare the class to capture taht value..




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 




         //CustomerName { get; set; }
         //CustomerAddress { get; set; }
         //CustomerCity { get; set; }


        //if you go the TCS --- 006  TCS000001
        //Lets system genrates the id for you.




        //https://localhost:7115/Customers/GetCustomersById/1
        //Entire data..
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDTO createDTO)
        {
            //return Ok("test");
            var data = await _custoemrSErvice.CreateCustomer(createDTO);
            var ouput = data;


            if(ouput is null)
            {
                return NotFound("Please check your data once");
            }
            else
            {
                return Ok(new { status = $"DAta has inserted with the {ouput.Id} value.... Record Succss" });
            };
        }



        //https://localhost:7115/Customers/GetCustomersById/1
        //Entire data..
        [HttpPost("UpdateCustomer/{ID}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerUpdateDTO updateDTO , int ID)
        {
            //return Ok("test");
            var data = await _custoemrSErvice.UpdateCustomer(updateDTO, ID);
            var ouput = data;


            if (ouput)
            {
                return Ok(new { status = $"DAta has updated.... Record Succss  {ouput}" });
                
            }
            else
            {
                return NotFound("Please check your data once");
            }
            ;
        }




        //https://localhost:7115/Customers/GetCustomersById/1
        //Entire data..
        [HttpDelete("DeleteCustomer/{ID}")]
        public async Task<IActionResult> DeleteCustomer(int ID)
        {
            //return Ok("test");
            var data = await _custoemrSErvice.DeleteAsync(ID);
            ///var ouput = data;

            if (data)
            {
                return Ok(new { status = $"DAta has Deleted" });

            }
            else
            {
                return NotFound("Please check your data once");
            }
            ;
        }


    }
}
