using NLog;
namespace AlgoServer.Libs
{
    public class LogLib
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Log(string message)
        {
            _logger.Info(message);
        }
    }
}
