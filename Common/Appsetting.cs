using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Common
{
    public class Appsetting
    {
        private static string serverPath = AppDomain.CurrentDomain.BaseDirectory;

        public static string phantomJsPath = string.Format("{0}{1}", serverPath, ConfigurationManager.AppSettings["phantomJsPath"]);

        //static Appsetting()
        //{

        //}
    }
}
