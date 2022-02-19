using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess.Context;
using DatabaseAccess.Models;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult("Method call success");
        }


        [Route("Login")]
        [HttpPost]  
        public JsonResult Login([FromBody] LoginModel login)
        {
            int userId = ValidateLoginRequest(login);
            if (userId == 0) return new JsonResult("Login Failed");
            else return new JsonResult(GenerateAccessToken(userId));
        }

        private int ValidateLoginRequest(LoginModel login)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                string password = Logic.Encryption.HashPassword(login.password);
                EndUser user = dbContext.EndUser.Where(eu=>eu.Email == login.userName && eu.Password == login.password).FirstOrDefault();
                return user == null? 0:user.Id;
            }
        }

        private AccessToken GenerateAccessToken(int userId)
        {
            AccessToken accessToken = new AccessToken();
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            string tokenString = "";
            while(tokenString.Length < 20)
            {
                int pos = new Random().Next(0,chars.Length-1);
                tokenString += chars[pos]; 
            }
            accessToken.Token = tokenString;
            accessToken.Duration = Common.Constants.AccessToken.AccessTokenDuration;
            using(DatabaseContext dbcontext = new DatabaseContext())
            {
                EndUser user = dbcontext.EndUser.Where(eu => eu.Id == userId).FirstOrDefault();
                user.LoginTokenExpiry = DateTime.UtcNow.AddSeconds(accessToken.Duration);
                user.LoginToken = tokenString;
                dbcontext.SaveChanges();
            }
            return accessToken;
        }


    }
}
