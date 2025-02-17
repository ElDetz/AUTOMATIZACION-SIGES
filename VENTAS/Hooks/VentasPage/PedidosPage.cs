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
    public class PedidosPage
    {
        private readonly IWebDriver driverOrder;
        WebDriverWait wait;
        UtilityVenta utilityPage;

        public PedidosPage(IWebDriver driverOrder)
        {
            this.driverOrder = driverOrder;
            this.utilityPage = new UtilityVenta(driverOrder);
        }

        public void ClickOrder()
        {
            utilityPage.ClickButton(NewOrders.order);
        }

        public void ClickViewOrder()
        {
            utilityPage.ClickButton(NewOrders.viewOrder);
        }

        public void ClickNewOrder()
        {
            Thread.Sleep(12000);
            utilityPage.ClickButton(NewOrders.newOrder);
        }

        public void Concept(string value)
        {
            utilityPage.EnterFieldModal(NewOrders.modal, NewOrders.concept, value);
        }

        public void CustomerType(string option, string value)
        {
            option = option.ToUpper();

            if (option == "DNI" || option == "RUC")
            {
                utilityPage.EnterFieldModal(NewOrders.modal, NewOrders.client, value);
            }
            else if (option == "ALIAS")
            {
                utilityPage.EnterFieldModal(NewOrders.modal, NewOrders.alias, value);
            }
            else
            {
                throw new ArgumentException($"El {option} no es válido");
            }
        }

        public void SelectInvoiceType(string option)
        {
            utilityPage.OptionsSelector(NewOrders.modal, NewOrders.voucher, option);
        }

        public void SelectDeliveryType(string option)
        {
            IWebElement orderModal = driverOrder.FindElement(NewOrders.modal);
            option = option.ToUpper();
            if (option == "INMEDIATA")
            {
                orderModal.FindElement(NewOrders.deferredLabel).Click();
            }
            else if (option == "DIFERIDA")
            {
                orderModal.FindElement(NewOrders.inmediate).Click();
            }
            else
            {
                throw new ArgumentException($"El {option} no es válido");
            }
        }

        public void InitialDate(string value)
        {
            Thread.Sleep(12000);
            utilityPage.EnterField(ConfirmOrderClass.initialDate, value);
            driverOrder.FindElement(ConfirmOrderClass.initialDate).SendKeys(Keys.Enter);
        }

        public void FinalDate(string value)
        {
            utilityPage.EnterField(ConfirmOrderClass.finalDate, value);
            driverOrder.FindElement(ConfirmOrderClass.finalDate).SendKeys(Keys.Enter);
        }

        public void OrderQuery()
        {
            utilityPage.ClickButton(ConfirmOrderClass.orderQueryButton);
            Thread.Sleep(4000);
        }

        public void InvoiceType(string option)
        {
            utilityPage.OptionsSelector(ConfirmOrderClass.modal, ConfirmOrderClass.voucher, option);
        }

        public void ConfirmOrder()
        {
            utilityPage.ClickButton(ConfirmOrderClass.confirmOrderPath);
            Thread.Sleep(4000);
        }

        public void InvalidateOrder()
        {
            utilityPage.ClickButton(InvalidateOrderClass.invalidateOrderButton);
        }

        public void AddObservation(string value)
        {
            utilityPage.EnterField(InvalidateOrderClass.observation, value);
            Thread.Sleep(2000);
        }

        public void ClickAcceptInvalidation()
        {
            utilityPage.ClickButton(InvalidateOrderClass.accept);
            Thread.Sleep(4000);
        }

        public void SaveOrder()
        {
            utilityPage.ClickButton(NewOrders.save);
            Thread.Sleep(4000);
        }
    }
}
