using BlogApi.Model.Entities.Log;
using System;

namespace BlogApi.Model.Logging
{
    public class Logger : ILog
    {
        private LogContext context;

        public Logger(LogContext context)
        {
            this.context = context;
        }

        public void LogError(Type t, string Message)
        {
            throw new NotImplementedException();
        }

        public void LogError(Type t, string Message, Exception e)
        {
            using (context)
            {

                context.Add(new LogEntry() {
                    LogTime = DateTime.Now,
                    ErrorType = "Error",
                    ErrorMessage = Message,
                    Location = t.FullName,
                    StackTrace = e.StackTrace });
                context.SaveChanges();
            }
        }

        public void LogException(Type t, string Message, Exception e)
        {
            using (context)
            {

                context.Add(new LogEntry()
                {
                    LogTime = DateTime.Now,
                    ErrorType = "Exception",
                    ErrorMessage = Message,
                    Location = t.FullName,
                    StackTrace = e.StackTrace
                });
                context.SaveChanges();
            }
        }

        public void LogInfo(Type t, string Message)
        {
            using (context)
            {
                context.Add(new LogEntry()
                {
                    LogTime = DateTime.Now,
                    ErrorType = "Info",
                    ErrorMessage = Message,
                    Location = t.FullName
                });
                context.SaveChanges();
            }
        }
    }
}
