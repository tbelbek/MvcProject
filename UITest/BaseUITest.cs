using OpenQA.Selenium;
using System;

namespace UITest
{
    public class BaseUITest
    {
        protected IWebDriver webDriver = null;

        protected string LocalUrl
        {
            get
            {
                return "http://localhost:3588/";
            }
        }

        protected IWebDriver Driver
        {
            get
            {
                if (this.webDriver == null)
                {
                    this.webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
                }
                return webDriver;
            }
        }
    }
}
