using System;

namespace BlogApi.Model.Entities.Log
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime LogTime { get; set; }
        public string Location { get; set; }
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
