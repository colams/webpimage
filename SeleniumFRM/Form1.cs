using Common.IO;
using Common.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeleniumFRM.c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text.Trim();
            string password = txtPwd.Text.Trim();
            string url = txtURL.Text.Trim();

            Dictionary<String, String> dict = new Dictionary<string, string>();
            dict.Add("loginname", account);
            dict.Add("nloginpwd", password);

            // string pageMessage = SeleniumUtils.OpenUrl2(url, dict);
            string pageMessage = SeleniumUtils.OpenUrl(url, dict);



        }

        private void btnOpenURL_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            string phantomJsDriverPath = String.Format("{0}Selenium\\", AppDomain.CurrentDomain.BaseDirectory);
            string pageMessage = SeleniumUtils.OpenUrl(url, phantomJsDriverPath);
            pageMessage = String.Format("[{0}]-------------------{1}\r\n", DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒"), pageMessage);
            string path = String.Format("{0}log", AppDomain.CurrentDomain.BaseDirectory);
            string fname = String.Format("{0}.txt", DateTime.Now.ToString("yyyyMMddHH"));
            Writer.WriteMessage(path, fname, pageMessage);
        }

        private void btnLogDir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
