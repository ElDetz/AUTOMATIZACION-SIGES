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
            utilityPage.ClickButton(NewQuote.qoute);
        }

        public void ClickNewQouta()
        {
            Thread.Sleep(3000);
            utilityPage.ClickButton(NewQuote.newQoute);
        }

        public void ConceptQuota(string value)
        {
            utilityPage.EnterFieldModal(NewQuote.modal, NewOrders.concept, value);
        }

        public void QuantityconceptQuota(string value)
        {
            utilityPage.CleanFieldModal(NewQuote.modal, NewOrders.quantity, value);
        }

        public void UnitPriceConceptQuota(string value)
        {
            utilityPage.CleanFieldModal(NewQuote.modal, NewQuote.unitPrice, value);
        }

        public void IGVQuota(string option)
        {
            utilityPage.CheckBox(NewQuote.modal, NewQuote.igv, option);
        }

        public void CustomerTypeQuota(string option, string value)
        {
            utilityPage.CustomerType(NewQuote.modal, NewOrders.client, NewOrders.alias, option, value);
        }
        
        public void ExpirationDateQouta(string value)
        {
            utilityPage.EnterFieldModal(NewQuote.modal, NewQuote.expirationDate, value);
        }

        public void ClickPregenerateOrder()
        {
            utilityPage.ClickButton(NewQuote.pregenerateOrderPath);
            Thread.Sleep(12000);
        }

        public void ClickPregenerateSale()
        {
            utilityPage.ClickButton(NewQuote.pregenerateSalePath);
            Thread.Sleep(7000);
        }

        public void UnifiedDetailOrderModal(string option)
        {
            NewWindow();
            utilityPage.CheckBox(NewOrders.modal, NewOrders.unifDetail, option);
        }

        public void CustomerTypeOrderModal(string option, string value)
        {
            NewWindow();
            utilityPage.CustomerType(NewOrders.modal, NewOrders.client, NewOrders.alias, option, value);
            Thread.Sleep(3000);
        }

        public void SaveOrderFromQuote()
        {
            NewWindow();
            driverQuota.FindElement(NewOrders.save).Click();
            Thread.Sleep(2000);
        }

        public void SavePregenerateSale()
        {
            NewWindow();
            driverQuota.FindElement(SaveSalePath.SaveSaleButton).Click();
            Thread.Sleep(4000);
        }

        public void NewWindow()
        {
            WebDriverWait wait = new WebDriverWait(driverQuota, TimeSpan.FromSeconds(10));
            string originalWindow = driverQuota.CurrentWindowHandle;

            // Esperar hasta que haya más de una pestaña abierta
            wait.Until(d => driverQuota.WindowHandles.Count > 1);

            // Cambiar a la nueva pestaña
            foreach (string window in driverQuota.WindowHandles)
            {
                if (window != originalWindow)
                {
                    driverQuota.SwitchTo().Window(window);
                    break;
                }
            }
        }
    }
}
