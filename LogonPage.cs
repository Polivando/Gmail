using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GmailTest
{
    class LogonPage
    {
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "Passwd")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "next")]
        public IWebElement Next { get; set; }

        [FindsBy(How = How.Id, Using = "signIn")]
        public IWebElement SignIn { get; set; }

        public LogonPage()
        {
            PageFactory.InitElements(General.driver, this);
        }

        public MailPage Login(string username, string password)
        {
            General.WriteLog("Logging in");
            this.Username.SendKeys(username);
            this.Next.Click();
            var temp = new LogonPage();
            temp.Password.SendKeys(password);
            temp.SignIn.Click();
            return new MailPage();
        }
    }
}
