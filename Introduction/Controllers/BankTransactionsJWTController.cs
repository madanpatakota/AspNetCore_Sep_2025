using Introduction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class BankTransactionsJWTController:ControllerBase
    {
        IJWTAuthenticationService _JWTAuthenticationService;
        public BankTransactionsJWTController(IJWTAuthenticationService jWTAuthenticationService)
        {
            _JWTAuthenticationService = jWTAuthenticationService;
        }

        //https://localhost:7115/api/BankTransactionsJWT/GetCustomerTransactions
        [HttpPost("GetCustomerTransactions")]  //Madan
        public IActionResult GetCustomerTransactions()
        {
            var _message = "Customes can see this transaction";
            return Ok(new { Message = _message });
        }

        //https://localhost:7115/api/BankTransactionsJWT/Getdata



        //Autherzition
        //wheater authetincated user having to access the particular resoruce or not
        [Authorize(Roles = "Customer")]
        [HttpPost("GetBankLevelTransactions")]
        public IActionResult GetBankLevelTransactions()
        {
            var _message = "You are the Manager so you can check the Bank level transactions.";
            return Ok("record succss");
        }


    }
}
