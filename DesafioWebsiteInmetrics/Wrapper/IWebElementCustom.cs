using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioWebsiteInmetrics.ScreenShot;

namespace DesafioWebsiteInmetrics.Wrapper
{
    public static class IWebElementCustom
    {
        public static void ClearCustom(this IWebElement elemento)
        {
            elemento.Clear();
            new ScreenshotCustom().ScreenShot();
        }

        public static void ClickCustom(this IWebElement elemento)
        {
            elemento.Click();
            new ScreenshotCustom().ScreenShot();
        }

        public static void SendKeysCustom(this IWebElement elemento, string text)
        {
            elemento.SendKeys(text);
            new ScreenshotCustom().ScreenShot();
        }

        public static void SubmitCustom(this IWebElement elemento)
        {
            elemento.Submit();
            new ScreenshotCustom().ScreenShot();
        }
    }
}
