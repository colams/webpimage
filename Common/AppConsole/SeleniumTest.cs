using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using OpenQA.Selenium.PhantomJS;


namespace AppConsole
{
    public class SeleniumTest
    {
        public static void test()
        {
            // ChromeDriver chrom = new ChromeDriver();
            ChromeDriverService cds = ChromeDriverService.CreateDefaultService();
            cds.HideCommandPromptWindow = true;
            ChromeDriver chrome = new ChromeDriver(cds);
            // ChromeDriver chrome = new ChromeDriver();
            // IWebDriver chrome = new PhantomJSDriver(PhantomJSDriverService.CreateDefaultService());
            // chrome.Url = ;
            chrome.Navigate().GoToUrl("http://www.baidu.com/");
            // chrome.FindElement(By.Id)
            chrome.FindElement(By.Id("kw")).SendKeys("test");
            chrome.FindElement(By.Id("su")).Click();
            // Console.WriteLine(chrome.PageSource);

            Trace.WriteLine(chrome.PageSource);
            chrome.Quit();
            // chrome.Close();
            chrome.Dispose();
            // chrome

        }

        public static void test2()
        {
            ChromeDriverService cds = ChromeDriverService.CreateDefaultService();
            cds.HideCommandPromptWindow = true;
            // ChromeDriver chrome = new ChromeDriver(cds);
            // ChromeDriver chrome = new ChromeDriver();
            PhantomJSDriverService pjd = PhantomJSDriverService.CreateDefaultService();
            pjd.HideCommandPromptWindow = true;
            IWebDriver chrome = new PhantomJSDriver(pjd);
            // chrome.Url = ;
            chrome.Navigate().GoToUrl("http://www.baidu.com/");
            // chrome.FindElement(By.Id)
            chrome.FindElement(By.Id("kw")).SendKeys("test");
            chrome.FindElement(By.Id("su")).Click();
            // Console.WriteLine(chrome.PageSource);

            Trace.WriteLine(chrome.PageSource);
            chrome.Quit();
            // chrome.Close();
            chrome.Dispose();
            // chrome

        }
    }
}
