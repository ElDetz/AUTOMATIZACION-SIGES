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

namespace SigesCore.Hooks.VentasPage
{
    public class PedidosPage
    {
        private readonly IWebDriver driverOrder;
        WebDriverWait wait;
        UtilityVenta utilityPage;
        Utilities utilitiesRestaurant;

        public PedidosPage(IWebDriver driverViewPayment)
        {
            this.driverOrder = driverViewPayment;
            this.utilityPage = new UtilityVenta(driverViewPayment);
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

        public void Client(string value)
        {
            utilityPage.EnterFieldModal(NewOrders.modal, NewOrders.client, value);
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
                utilitiesRestaurant.ClickButtonInModal(orderModal, NewOrders.inmediate);
            }
            else if (option == "DIFERIDA")
            {
                utilitiesRestaurant.ClickButtonInModal(orderModal, NewOrders.deferred);
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

        public void ConfirmOrder()
        {
            utilityPage.ClickButton(ConfirmOrderClass.confirmOrderPath);
            Thread.Sleep(4000);
        }

        public void InvoiceType(string option)
        {
            utilityPage.OptionsSelector(ConfirmOrderClass.modal, ConfirmOrderClass.voucher, option);
        }
        public void SaveOrder()
        {
            utilityPage.ClickButton(NewOrders.save);
            Thread.Sleep(4000);
        }
    }
}
