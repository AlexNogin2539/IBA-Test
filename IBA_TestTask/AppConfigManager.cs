using System.Configuration;

namespace IBA_TestTask
{
    public static class AppConfigManager
    {
        public static int StartTime = int.Parse(ConfigurationManager.AppSettings["startTime"]);

        public static int FinishTime = int.Parse(ConfigurationManager.AppSettings["finishTime"]);

        public static string FileName = ConfigurationManager.AppSettings["fileName"];
    }
}

