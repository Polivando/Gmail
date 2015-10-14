using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions.Internal;
using System.Threading;
using System.IO;
using NUnit.Framework;

namespace GmailTest
{
    public class GmailTest
    {
        //static MailPage mail;

        static LogonPage logon;

        static string file = "";

        static void Initialize()
        {
            General.WriteLog("Opening driver");
            General.driver = new ChromeDriver();
            General.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            General.driver.Navigate().GoToUrl(General.path);
            logon = new LogonPage();
            
        }

        static void Clean()
        {
            General.driver.Close();
        }

        [Test]
        public static void TestAttachment()
        {
            /*
                 * base (& only) case:
                 * 0. open page             OK
                 * 1. login+password        OK
                 * 1.1 wait for the page    OK
                 * 2. click "write"         OK
                 * 3. To = to;              OK
                 * 4. click "attach file"
                 * 5. select file
                 * 6. click OK
                 * 7. click "send"
                 * 8. open sent
                 * 9. select first message
                 * 10. check for attach
                 * */
            General.WriteLog(DateTime.Now.ToString() + " Performing test for gmail attachments");
            General.WriteLog("Reading credentials and file path from file");
            string[] credentials = File.ReadAllLines(General.credential);
            file = credentials[2];
            Initialize();
                var text = logon.Login(credentials[0], credentials[1])
                .WriteEmail(credentials[0], file)
                .CheckSent()
                .AttathArea.Text;
            int errors = 0;
            foreach (var item in General.keys)
                if (!text.Contains(item))
                    errors++;
            if (errors == General.keys.Length)
            {
                General.WriteLog("No attachments in mail");
                General.WriteLog("Test failed");
                throw new Exception();
            }
            General.WriteLog("Test passed");
            Clean();
        }
    }
}
