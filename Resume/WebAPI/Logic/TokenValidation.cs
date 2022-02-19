using DatabaseAccess.Context;
using DatabaseAccess.Models;

namespace WebAPI.Logic
{
    public static class TokenValidation
    {
        public static EndUser ValidateAccessToken(string token)
        {
            using(DatabaseContext dbContext = new DatabaseContext())
            {
                return (dbContext.EndUser.Where(eu=> eu.LoginToken == token && eu.LoginTokenExpiry > DateTime.UtcNow).FirstOrDefault());
            }
        }
    }
}
