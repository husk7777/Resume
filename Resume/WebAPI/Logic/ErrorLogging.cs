using DatabaseAccess.Context;
using DatabaseAccess.Models;

namespace WebAPI.Logic
{
    public static class ErrorLogging
    {/*
        public static void LogError(string controller,string action, string message, string stacktrace, DatabaseContext dbContext)
        {
            dbContext.ErrorLog.Add(new ErrorLog
            {
                Controller = controller,
                Message = message,
                StackTrace = stacktrace,
                Action = action,
                Timestamp = DateTime.UtcNow
            });
            dbContext.SaveChanges();
        }

        public static void LogError(string controller, string action, string message, string stacktrace)
        {
            using(DatabaseContext dbcontext = new DatabaseContext())
            {
                LogError(controller, action, message, stacktrace, dbcontext);
            }
        }

        public static void LogError(string controller, string action, Exception error, DatabaseContext dbcontext)
        {
            LogError(controller, action, error.Message, error.StackTrace, dbcontext);
        }

        public static void LogError(string controller, string action, Exception error)
        {
            using(DatabaseContext dbcontext = new DatabaseContext())
            {
                LogError(controller,action,error,dbcontext);
            }
        }*/
    }
}
