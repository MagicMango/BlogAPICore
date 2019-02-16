using System;

namespace BlogApi.Model.Logging
{
    public interface ILog
    {
        void LogError(Type t, string Message);
        void LogError(Type t,string Message, Exception e);
        void LogInfo(Type t, string Message);
        void LogException(Type t, string Message, Exception e);
    }
}
