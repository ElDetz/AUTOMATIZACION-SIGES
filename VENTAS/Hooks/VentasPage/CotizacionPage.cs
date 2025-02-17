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
            Thread.Sleep(10000);
            utilityPage.ClickButton(NewQouta.newQouta);
        }

        public void conceptQuota(string value)
        {
            utilityPage.EnterFieldModal(NewQouta.modal, NewOrders.concept, value);
        }

        public void CustomerTypeQuota(string option, string value)
        {
            utilityPage.CustomerType(NewQouta.modal, NewOrders.client, NewOrders.alias, option, value);
        }
        
        public void expirationDateQouta(string value)
        {
            utilityPage.EnterFieldModal(NewQouta.modal, NewQouta.expirationDate, value);
        }

        public void ClickPregenerateOrder()
        {
            utilityPage.ClickButton(NewQouta.pregenerateOrderPath);
            Thread.Sleep(15000);
        }

        public void SavePregenerateOrder()
        {
            IWebElement orderModal = driverQuota.FindElement(NewQouta.modal);
            orderModal.FindElement(PregenerateOrder.saveOrder).Click();
            Thread.Sleep(2000);
        }

        public void ClickPregenerateSale()
        {
            utilityPage.ClickButton(NewQouta.pregenerateSalePath);
            Thread.Sleep(7000);
        }

        public void SavePregenerateSale()
        {
            IWebElement orderModal = driverQuota.FindElement(NewQouta.modal);
            orderModal.FindElement(PregenerateSale.saveSale).Click();
            Thread.Sleep(3000);
        }
    }
}
