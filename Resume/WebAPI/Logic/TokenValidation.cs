using DatabaseAccess.Context;
using DatabaseAccess.Models;

namespace WebAPI.Logic
{
    public static class TokenValidation
    {
        public static EndUser ValidateUserAccessToken(string token)
        {
            using(DatabaseContext dbContext = new DatabaseContext())
            {
                return (dbContext.EndUser.Where(eu=> eu.LoginToken == token && eu.LoginTokenExpiry > DateTime.UtcNow).FirstOrDefault());
            }
        }

        public static EndUser ValidateAdminAccessToken(string token)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                return (dbContext.EndUser.Where(eu => eu.LoginToken == token && eu.LoginTokenExpiry > DateTime.UtcNow && eu.UserType.Type == Common.Constants.UserType.Admin).FirstOrDefault());
            }
        }
    }
}
