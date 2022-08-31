using Common.Log.Log4Net;
using Common.Net;
using Common.Serializer;
using SpiderCrawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace AppConsole
{
    public class SpilderCrawlerTest
    {
        // DownLoader downLoader = new DownLoader();
        public static void DownLoaderTest()
        {
            var result = DownLoader.DownLoad("https://www.jd.com/2017?t=2");
            String xml = XmlUtils.ObjectToXml<HttpResult>(result);
            LogInstance.Instance().Info(xml);
        }

        public static void LoveBridgeTest()
        {
            var result = DownLoader.DownLoad("https://bbs.sjtu.edu.cn/bbswapdoc?board=LoveBridge");
            //HtmlDocument doc = new HtmlDocument();
            //doc.LoadHtml(result.Html);

            string input = result.Html.ToLower().Replace("\n", "");
            // Regex regex = new Regex("(<a[^>]+>[^<]+</a)");
            string regex = "<a\\shref=([^>]+)>([^<]+)</a>";
            string host = "https://bbs.sjtu.edu.cn/";
            MatchCollection matches = Regex.Matches(input, regex, RegexOptions.Compiled);
            LogInstance.Instance().Info(input);
            string message = "";
            foreach (Match item in matches)
            {
                string uri = item.Groups[1].Value.Trim('\"');
                string title = item.Groups[2].Value;
                message += string.Format("{0}{1}     {2}\r\n", host, uri, title);
            }


            // String xml = XmlUtils.ObjectToXml<HttpResult>(html);
            LogInstance.Instance().Info(message);
        }
    }
}
