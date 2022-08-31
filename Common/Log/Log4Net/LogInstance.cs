using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Log.Log4Net
{
    public class LogInstance
    {
        private static LogInstance instance;

        private static readonly Object obj = new Object();

        public static LogInstance Instance()
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new LogInstance();
                    }
                }
            }

            return instance;
        }


        private LogInstance()
        {
            // log4net.Config.XmlConfigurator.Configure();
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "/log4net.config");
            //加载配置
            XmlConfigurator.ConfigureAndWatch(logCfg);
        }

        public void Info(string message, LoggerName loggerName)
        {
            ILog Ilog = LogManager.GetLogger(loggerName.ToString());
            Ilog.Info(message);
        }

        public void Info(string message)
        {
            Info(message, LoggerName.LoggerInfo);
        }
    }
}
