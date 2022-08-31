using Common.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.Log
{
    public class LocalLogger
    {
        public static void Log(string message)
        {
            try
            {
                StackTrace stackTrace = new StackTrace(true);
                MethodBase method = stackTrace.GetFrame(1).GetMethod();
                string serviceName = "";
                if (method != null)
                {
                    if (method.Name == stackTrace.GetFrame(0).GetMethod().Name)
                    {
                        method = stackTrace.GetFrame(2).GetMethod();
                    }
                    serviceName = method.Name;
                }
                string className = method.ReflectedType.FullName;


                message = String.Format("[{0}][{1}.{2}]-------------------\r\n{3}\r\n", DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒"),
                    serviceName, className, message);
                string path = String.Format("{0}log", AppDomain.CurrentDomain.BaseDirectory);
                string fname = String.Format("{0}.txt", DateTime.Now.ToString("yyyyMMddHH"));
                Writer.WriteMessage(path, fname, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
