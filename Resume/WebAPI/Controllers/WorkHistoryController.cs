using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Logic;
using DatabaseAccess.Context;
using DatabaseAccess.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkHistoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public WorkHistoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[Authorize()]
        [HttpGet]
        public JsonResult Get([FromHeader]string Bearer)
        {
            EndUser user = TokenValidation.ValidateAccessToken(Bearer);
            if(user == null)
            {
                return new JsonResult("Invalid access token provided");
            }
            return RetrieveWorkHistory(user);
        }

        private JsonResult RetrieveWorkHistory(EndUser user)
        {
            using(DatabaseContext dbContext = new DatabaseContext())
            {
                List<Position> positions = dbContext.Position.Where(p => p.EndUser == user).Include(p => p.Responsibilities).ToList();
                return new JsonResult(positions);
            }
        }
    }
}
