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
using FluentAssertions.Execution;
using OpenQA.Selenium.DevTools.V130.Debugger;

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

        public void ConceptOrder(string value)
        {
            utilityPage.EnterFieldModal(NewOrders.modal, NewOrders.concept, value);
        }

        public void QuantityconceptOrder(string value)
        {
            utilityPage.CleanFieldModal(NewOrders.modal, NewOrders.quantity, value);
        }

        public void UnitPriceConceptOrder(string value)
        {
            utilityPage.CleanFieldModal(NewOrders.modal, NewOrders.unitPrice, value);
        }

        public void IGVOrder(string option)
        {
            utilityPage.CheckBox(NewOrders.modal, NewOrders.igv, option);
        }

        public void UnifiedDetailOrder(string option)
        {
            utilityPage.CheckBox(NewOrders.modal, NewOrders.unifDetail, option);
        }

        public void CustomerTypeOrder(string option, string value)
        {
            utilityPage.CustomerType(NewOrders.modal, NewOrders.client, NewOrders.alias, option, value);
            Thread.Sleep(3000);
        }

        public void SelectInvoiceType(string option)
        {
            utilityPage.OptionsSelector(NewOrders.modal, NewOrders.voucher, option);
        }

        public void SelectDeliveryType(string option)
        {
            utilityPage.SelectDeliveryType(NewOrders.modal, NewOrders.inmediate, NewOrders.deferred, option);
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
            driverOrder.FindElement(NewOrders.save).Click();
            Thread.Sleep(3000);
        }
    }
}
