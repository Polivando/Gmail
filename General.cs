using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailTest
{
    class General
    {
        public static IWebDriver driver;

        public static readonly string path = "https://mail.google.com/mail/u/0/#inbox";
        public static string output = "..\\..\\log.txt";
        public static string credential = "..\\..\\credentials.txt";

        public static string[] keys = { "прикреплённых", "вкладених", "Attachments" };

        public static void WriteLog(string text)
        {
            string[] arr = new String[] { text };
            File.AppendAllLines(output, arr);
        }
    }
}
