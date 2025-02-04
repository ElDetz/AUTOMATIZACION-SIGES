using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SigesCore.Hooks.Utility;
using SigesCore.Hooks.XPaths;

namespace SigesCore.Hooks.VentasPage
{
    public class VentaCajaPage
    {
        private readonly IWebDriver driver;
        WebDriverWait wait;
        UtilityVentaPage utilityPage;

        public VentaCajaPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilityPage = new UtilityVentaPage(driver);
        }

        public void SelectPointSale(string option)
        {
            utilityPage.SelectOption(Concept.ConceptSelection, option);
        }
        public void SelectSeller(string option)
        {

        }
    }
}
