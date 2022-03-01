using System.Configuration;

namespace IBA_TestTask
{
    public class AppConfigManager
    {
        public AppConfigManager()
        {
            StartTime = int.Parse(ConfigurationManager.AppSettings["startTime"]);
            FinishTime = int.Parse(ConfigurationManager.AppSettings["finishTime"]);
        }

        public int StartTime { get; }

        public int FinishTime { get; }
    }
}
