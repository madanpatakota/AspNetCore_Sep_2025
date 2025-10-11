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


        //Entire data..
        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var data = await _custoemrSErvice.GetAllCustomersAsync();
            return data is null ? NotFound() : Ok(data);
        }





        ///
        //

        //


        //
    }
}
