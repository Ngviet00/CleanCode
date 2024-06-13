using log4net;

namespace CleanCode.Common
{
    public static class Log
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Log));

        public static void Error(string fileName = "Func", string funcName = "function", string err = "err")
        {
            log.Error($"Error server, file_name: {fileName}, function_name: {funcName}, error_detail: {err}");
        }

        public static void Info(string msg)
        {
            log.Error($"{msg}");
        }
    }
}
