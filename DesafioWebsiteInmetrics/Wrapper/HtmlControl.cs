using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebsiteInmetrics.Wrapper
{
    public class HtmlControl
    {
        protected readonly IWebElement webElement;

        public HtmlControl(IWebElement webElement)
        {
            this.webElement = webElement;
        }

        
        public string Text
        {
            get { return webElement.Text; }
        }

        
        //All the Find Methods and other methods you want to expose
    }

    public class HtmlEditBox : HtmlControl
    {
        public HtmlEditBox(IWebElement webElement) : base(webElement)
        {
        }

        public new string Text
        {
            get { return webElement.Text; }
            set
            {
                ((IJavaScriptExecutor)((RemoteWebElement)webElement).WrappedDriver).
                ExecuteScript("arguments[0].setAttribute('value', '" + value + "')",
                    webElement);
            }
        }
    }

    public class HtmlCheckBox : HtmlControl
    {
        public HtmlCheckBox(IWebElement webElement) : base(webElement)
        {

        }

        public bool IsChecked { get { return webElement.Selected; } }
    }

    public class HtmlHyperlink : HtmlControl
    {
        public HtmlHyperlink(IWebElement webElement) : base(webElement)
        {

        }

        public void Go()
        {
            webElement.SendKeys(Keys.Enter);
        }
    }
}
