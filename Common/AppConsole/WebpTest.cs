using Imagelib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsole
{
    public class WebpTest
    {
        public static void ConvertWebp()
        {
            Console.WriteLine("请输入要转换的文件路径：");
            string fileName = Console.ReadLine();
            Console.WriteLine("选择导出路径：");
            string outFilePath = Console.ReadLine();
            if (!string.IsNullOrEmpty(outFilePath))
            {
                outFilePath.TrimEnd('/').TrimEnd('\\');
            }
            new WebpConvertUtil().ConvertToWebp(fileName, outFilePath);

        }
    }
}
