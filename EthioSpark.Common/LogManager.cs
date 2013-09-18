using log4net;

namespace EthioSpark.Common
{
    public static class AppLogManager
    {
        public static ILog Logger { get; private set; }

        static AppLogManager()
        {
            Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}
