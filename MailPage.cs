using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;

namespace GmailTest
{
    class MailPage
    {
        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'T-I') and contains(@class, 'J-J5-Ji') and contains(@class, 'T-I-KE') and contains(@class, 'L3')]")]
        public IWebElement Write { get; set; }

        [FindsBy(How = How.Name, Using = "to")]
        public IWebElement To { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'a1') and contains(@class, 'aaA') and contains(@class, aMZ)]")]
        public IWebElement AttachBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'T-I') and contains(@class, 'J-J5-Ji') and contains(@class, 'aoO') and contains(@class,'T-I-atl') and contains(@class, 'L3')]")]
        public IWebElement SendBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@href,'https://mail.google.com/mail/u/0/#sent')]")]
        public IWebElement Sent { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'ae4') and contains(@class,'UI') and @gh='tl']//*[contains(@class,'zA') and contains(@class,'yO')][1]")]
        public IWebElement First { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'hq') and contains(@class, 'gt')]")]
        public IWebElement AttathArea { get; set; }

        public MailPage()
        {
            PageFactory.InitElements(General.driver, this);
        }

        public void WriteAndSendEmail(string to, string attachment)
        {
            General.WriteLog("Writing message");
            Write.Click();
            var temp = new MailPage();
            temp.To.SendKeys(to+"@gmail.com");
            General.WriteLog("Attaching file and sending message");
            temp.AttachBtn.Click();
            Thread.Sleep(1000);
            SendKeys.SendWait(attachment);
            SendKeys.SendWait(@"{Enter}");
            //var wait = new WebDriverWait(General.driver, TimeSpan.FromSeconds(10)).Until<bool>((d) => { return SendBtn == null});
            temp.SendBtn.Click();
            //SendKeys.SendWait(@"{Ctrl+Enter}");
            //return new MailPage();
        }

        public MailPage CheckSent()
        {
            General.WriteLog("Opening first sent message");
            Sent.Click();
            var temp = new MailPage();
            temp.First.Click();
            return new MailPage();
        }
    }
}
