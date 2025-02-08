using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SigesCore.Hooks.Utility;
using SigesCore.Hooks.XPaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigesCore.Hooks.VentasPage
{
    public class VerVentasPage
    {
        private readonly IWebDriver driverViewPayment;
        WebDriverWait wait;
        UtilityVentaPage utilityPage;
        UtilityVerVentas utilityViewPage;

        public VerVentasPage (IWebDriver driverViewPayment)
        {
            this.driverViewPayment = driverViewPayment;
            this.utilityPage = new UtilityVentaPage(driverViewPayment);
        }

    }
}
