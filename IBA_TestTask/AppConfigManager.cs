using System.Configuration;

namespace IBA_TestTask
{
    public static class AppConfigManager
    {
        public static int StartTime = int.Parse(ConfigurationManager.AppSettings["startTime"]);

        public static int EndTime = int.Parse(ConfigurationManager.AppSettings["endTime"]);

        public static string FileName = ConfigurationManager.AppSettings["fileName"];
    }
}

