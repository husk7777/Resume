using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess.Context;
using DatabaseAccess.Models;
using WebAPI.Models;
using Isopoh.Cryptography.Argon2;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AccessController(IConfiguration configuration)
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
                EndUser user = dbContext.EndUser.Where(eu => eu.Email == login.userName).FirstOrDefault();
                if(Argon2.Verify(user.Password, login.password))
                {
                    return user.Id;
                }
                else
                {
                    return 0;
                }
            }
        }

        private AccessToken GenerateAccessToken(int userId)
        {
            using (DatabaseContext dbcontext = new DatabaseContext())
            {
                bool unique = false;
                AccessToken accessToken = new AccessToken();
                while (!unique)
                {
                    string tokenString = "";
                    string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
                    while (tokenString.Length < 20)
                    {
                        int pos = new Random().Next(0, chars.Length - 1);
                        tokenString += chars[pos];
                    }
                    EndUser existingUserWithToken = dbcontext.EndUser.Where(eu=>eu.LoginToken == tokenString).FirstOrDefault();
                    if(existingUserWithToken == null)
                    {
                        unique = true;
                        accessToken.Token = tokenString;
                        accessToken.Duration = Common.Constants.AccessToken.AccessTokenDuration;
                    }
                }  
                EndUser user = dbcontext.EndUser.Where(eu => eu.Id == userId).FirstOrDefault();
                user.LastLogin = DateTime.UtcNow;
                user.LoginTokenExpiry = DateTime.UtcNow.AddSeconds(accessToken.Duration);
                user.LoginToken = accessToken.Token;
                dbcontext.SaveChanges();
                return accessToken;
            }
        }


    }
}
