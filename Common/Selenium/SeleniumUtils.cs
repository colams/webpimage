using Common.Log;
using Common.Selenium.DTO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Common.Selenium
{
    public class SeleniumUtils
    {

        public static string OpenUrl(string url, string phantomJsDriverPath)
        {
            var pjs = PhantomJSDriverService.CreateDefaultService(phantomJsDriverPath);
            pjs.HideCommandPromptWindow = true;
            IWebDriver chrome = new PhantomJSDriver(pjs);
            chrome.Navigate().GoToUrl(url);
            string page = chrome.PageSource;
            chrome.Close();
            chrome.Dispose();
            return page;
        }


        public static string OpenUrl2(string url, Dictionary<string, string> dict)
        {
            String page = "";
            using (ChromeDriver chrome = new ChromeDriver())
            {
                chrome.Navigate().GoToUrl(url);
                page = chrome.PageSource;
                LocalLogger.Log(page);


                chrome.FindElement(By.ClassName("login-tab-r")).Click();
                chrome.FindElement(By.Id("loginname")).SendKeys(dict["loginname"]);
                chrome.FindElement(By.Id("nloginpwd")).SendKeys(dict["nloginpwd"]);

                chrome.FindElement(By.Id("loginsubmit")).Click();
            }
            return page;
        }

        public static string OpenUrl(string url, Dictionary<string, string> dict)
        {
            String page = "";
            using (var pjs = PhantomJSDriverService.CreateDefaultService(Appsetting.phantomJsPath))
            {
                pjs.HideCommandPromptWindow = true;
                using (IWebDriver chrome = new PhantomJSDriver(pjs))
                {
                    chrome.Navigate().GoToUrl(url);
                    page = chrome.PageSource;
                    LocalLogger.Log(page);
                    
                    chrome.FindElement(By.ClassName("login-tab-r")).Click();
                    chrome.FindElement(By.Id("loginname")).SendKeys(dict["loginname"]);
                    chrome.FindElement(By.Id("nloginpwd")).SendKeys(dict["nloginpwd"]);

                    chrome.FindElement(By.Id("loginsubmit")).Click();
                    // chrome.Navigate().sc

                    // chrome.
                }
            }
            return page;
        }

        public static string OpenUrl(string url, SeleniumItem Items)
        {
            //  ChromeDriver chrome = new ChromeDriver();
            IWebDriver chrome = new PhantomJSDriver(PhantomJSDriverService.CreateDefaultService());
            // chrome.Url = ;
            chrome.Navigate().GoToUrl(url);
            // chrome.FindElement(By.Id)
            chrome.FindElement(By.Id("kw")).SendKeys("test");
            chrome.FindElement(By.Id("su")).Click();
            // By.TagName
            // Console.WriteLine(chrome.PageSource);
            // Trace.WriteLine(chrome.PageSource);
            return chrome.PageSource;
        }
    }
}
