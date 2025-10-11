//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Introduction.Services
{
    public class JWTAuthenticationService : IJWTAuthenticationService
    {

        // see now i am not deployed my project(AspNetIntroduction) into the azure.

//        // {4A3B812D-649A-4656-A162-C96490A7D27D}
//        IMPLEMENT_OLECREATE(<<class>>, <<external_name>>, 
//0x4a3b812d, 0x649a, 0x4656, 0xa1, 0x62, 0xc9, 0x64, 0x90, 0xa7, 0xd2, 0x7d);


        //Generate the token in diff approach

        //Bank with Customer

        private readonly string _secreat = "4A3B812D-649A-4656-A162-C96490A7D27D";
        private readonly string _issuer  = "HDFCBank";
        private readonly string _audiance = "HDFCTellers";

        public string GenerateToken(string userName, string role = "Customer")
        {

            role = "Customer";

            // Cliam is a piece of infromation about the user...contain Name , Role , email , homeaddres , phone number

            //claim is ready
            var claims = new List<Claim>()
             {
                 new Claim(ClaimTypes.Name,userName),
                 new Claim(ClaimTypes.Role, role),
                 new Claim(ClaimTypes.Email, "madan.patakota@gmail.com"),
                 new Claim(ClaimTypes.Role, "Customer"),
                 new Claim(ClaimTypes.MobilePhone, "754444444467"),
                 new Claim(ClaimTypes.PostalCode, "675544"),
             };


            // SymmetricSecuritykey
            var Secreatkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secreat));


            //Siginingcredations --->  Secreatkey along with Hmacsha256 securityalogirtham.. 


            //scratch project 

            var signInCreds = new SigningCredentials(Secreatkey, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(
                   issuer: _issuer,
                   audience: _audiance,
                   claims: claims,
                   expires: DateTime.UtcNow.AddMinutes(30),
                   signingCredentials: signInCreds
                );


            //object   ---> string , Json , xml , binary

            //string , Json , xml , binary    --> object

            // serializtion and deserilzation

            var finalToken = new JwtSecurityTokenHandler().WriteToken(token);

            ////you need to notonly generatetoken needs to validate also
            return finalToken;
            //We need to return the token
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();


            //token params

            var validatinParams = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _issuer,

                ValidateAudience = true,
                ValidAudience = _audiance,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secreat)),
                //to ensure my cliams are also need to validate
                NameClaimType = ClaimTypes.Name,
                RoleClaimType = ClaimTypes.Role,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };


            SecurityToken validateToken;

            

            try
            {
                var authorizationtoken = token.Substring("Bearer ".Length).Trim();
                ClaimsPrincipal principal = tokenHandler.ValidateToken(authorizationtoken, validatinParams, out validateToken);
                return principal;

            }
            catch (Exception ex)
            {
                return null;
            }
            

            
            //throw new NotImplementedException();
        }
    }
}
