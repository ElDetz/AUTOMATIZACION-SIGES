using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SigesCore.Hooks.Utility;
using SigesCore.Hooks.XPaths;
using RESTAURANTE.Hoks.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Equivalency;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;
using SeleniumExtras.WaitHelpers;

namespace SigesCore.Hooks.VentasPage
{
    public class CotizacionPage
    {
        private readonly IWebDriver driverQuota;
        WebDriverWait wait;
        UtilityVenta utilityPage;

        public CotizacionPage(IWebDriver driverQouta)
        {
            this.driverQuota = driverQouta;
            this.utilityPage = new UtilityVenta(driverQouta);
        }

        public void ClickQouta()
        {
            utilityPage.ClickButton(NewQouta.qouta);
        }

        public void ClickNewQouta()
        {
            Thread.Sleep(3000);
            utilityPage.ClickButton(NewQouta.newQouta);
        }
    }
}
