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

        [HttpPost]  
        public JsonResult Post([FromBody] LoginModel login)
        {
            int id = ValidateLoginRequest(login);
            if (id == 0) return new JsonResult("Login Failed");
            else return new JsonResult("Login successful, User Id: " + id.ToString());
        }

        private int ValidateLoginRequest(LoginModel login)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                string password = Logic.Encryption.HashPassword(login.password);
                EndUser user = dbContext.EndUser.Where(eu=>eu.Email == login.userName && eu.Password == login.password).FirstOrDefault();
                if (user != null) return user.Id;
                else return 0;
            }
        }


    }
}
