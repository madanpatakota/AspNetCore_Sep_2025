namespace Introduction.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private static readonly string myToken = "madan!12346711@#@@@@@#$%TGFFDERRRavafas"; //hard coded value
        public string GenerateToken(string userName, string role = "Customer")
        {
            return myToken;
        }

        public string ValidateToken(string token)
        {
            if(token.Contains("madan"))
            {
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }
    }
}

// Discussions

//solo ---> dependency injection

//Jwt  ---> hemandth venkatsh --> video watch ---> 

//JWT and Exception Handling

//solid 

//action 

// routing ---> 

// forms   --->

// 1 hour --->   1 hour(my time) ---> progress

// 10%  90% 


//final real time project --> structure 