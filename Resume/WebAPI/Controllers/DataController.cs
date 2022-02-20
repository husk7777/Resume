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
    public class DataController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("WorkHistory")]
        [HttpGet]
        public JsonResult WorkHistory([FromHeader]string Bearer)
        {
            EndUser user = TokenValidation.ValidateUserAccessToken(Bearer);
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
                List<Position> positions = dbContext.Position.Where(p => p.Candidate.EndUserId == user.Id && p.PositionType.Type == Common.Constants.PositionType.Paid).Include(p=>p.Responsibilities).ToList();
                return new JsonResult(positions);
            }
        }

        [Route("VolunteerHistory")]
        [HttpGet]
        public JsonResult VolunteerHistory([FromHeader] string Bearer)
        {
            EndUser user = TokenValidation.ValidateUserAccessToken(Bearer);
            if (user == null)
            {
                return new JsonResult("Invalid access token provided");
            }
            return RetrieveVolunteerHistory(user);
        }

        private JsonResult RetrieveVolunteerHistory(EndUser user)
        {
            using(DatabaseContext dbContext = new DatabaseContext())
            {
                List<Position> positions = dbContext.Position.Where(p => p.Candidate.EndUserId == user.Id && p.PositionType.Type == Common.Constants.PositionType.Volunteer).Include(p => p.Responsibilities).ToList();
                return new JsonResult(positions);
            }
        }

        [Route("ProjectHistory")]
        [HttpGet]
        public JsonResult ProjectHistory([FromHeader] string Bearer)
        {
            EndUser user = TokenValidation.ValidateUserAccessToken(Bearer);
            if (user == null)
            {
                return new JsonResult("Invalid access token provided");
            }
            return RetrieveProjectHistory(user);
        }

        private JsonResult RetrieveProjectHistory(EndUser user)
        {
            using(DatabaseContext dbContext = new DatabaseContext())
            {
                List<Project> projects = dbContext.Project.Where(p => p.Candidate.EndUserId == user.Id).Include(p => p.ProjectOutcomes).ToList();
                return new JsonResult(projects);
            }
        }

        [Route("PersonalInformation")]
        [HttpGet]
        public JsonResult PersonalInfo([FromHeader] string Bearer)
        {
            EndUser user = TokenValidation.ValidateUserAccessToken(Bearer);
            if (user == null)
            {
                return new JsonResult("Invalid access token provided");
            }
            JsonResult result = RetrievePersonalInfo(user);
            return result;
        }

        private JsonResult RetrievePersonalInfo(EndUser user)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                return new JsonResult(dbContext.Candidate.Where(c => c.EndUserId == user.Id).Include(c => c.Skills).FirstOrDefault());
            }
        }
    }
}
