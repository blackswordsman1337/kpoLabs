using log4net;
using System;


namespace KPOLab2.Controller
{
    [Serializable]
    public class Log4jPrinter : IPrinter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Log4jPrinter));

        public void Print(string message)
        {
            log.Info(message);
        }
    }
}
