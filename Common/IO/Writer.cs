using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.IO
{
    public class Writer
    {

        public static bool WriteMessage(string path, string fname, string message)
        {
            // This text is added only once to the file
            String fullName = string.Format("{0}\\{1}", path, fname);
            if (!File.Exists(fullName))
            {
                // Create a file to write to.
                Directory.CreateDirectory(path);
                using (StreamWriter sw = File.CreateText(fullName))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.spider
                using (StreamWriter sw = File.AppendText(fullName))
                {
                    sw.WriteLine(message);
                }
            }
            return true;
        }
    }
}
