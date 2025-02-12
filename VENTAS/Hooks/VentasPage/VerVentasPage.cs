using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SigesCore.Hooks.Utility;
using SigesCore.Hooks.XPaths;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigesCore.Hooks.VentasPage
{
    public class VerVentasPage
    {
        private readonly IWebDriver driverViewPayment;
        WebDriverWait wait;
        UtilityVenta utilityPage;
        UtilityVerVentas utilityViewPage;

        public VerVentasPage (IWebDriver driverViewPayment)
        {
            this.driverViewPayment = driverViewPayment;
            this.utilityPage = new UtilityVenta(driverViewPayment);
        }

        // Fecha inicial
        public void SetInitialDate(string value)
        {
            Thread.Sleep(4000);
            //utilityPage.WaitExistsVisible(RedeemVoucher.initialDate, AdditionalElements.OverlayElement);
            utilityPage.EnterField(RedeemVoucher.initialDate, value);
            driverViewPayment.FindElement(RedeemVoucher.initialDate).SendKeys(Keys.Enter);
        }

        // Fecha final
        public void SetFinalDate(string value)
        {
            utilityPage.EnterField(RedeemVoucher.finalDate, value);
            driverViewPayment.FindElement(RedeemVoucher.finalDate).SendKeys(Keys.Enter);
        }

        // Consulta ventas
        public void SetSalesQuery()
        {
            utilityPage.ClickButton(RedeemVoucher.salesQueryButton);
            Thread.Sleep(4000);
        }

        // Botón busca venta
        public void SearchSaleField(string value)
        {
            utilityPage.EnterField(RedeemVoucher.searchSale, value);
            Thread.Sleep(2000);
        }

        // Activa canje
        public void ActivateRedeem()
        {
            var checkboxElement = driverViewPayment.FindElement(RedeemVoucher.activateRedeemPath);
            checkboxElement.Click();
            Thread.Sleep(2000);
        }

        // Selecciona venta
        public void SelectSale()
        {
            var checkboxElement = driverViewPayment.FindElement(RedeemVoucher.selectedSalePath);
            checkboxElement.Click();
            Thread.Sleep(2000);
        }

        // Botón canjear
        public void ClickRedeemButton()
        {
            utilityPage.ClickButton(RedeemVoucher.redeemButton);
            Thread.Sleep(2000);
        }

        // Tipo comprobante
        public void SetVoucherType(string option)
        {
            utilityPage.OptionsSelector(RedeemVoucher.modal, RedeemVoucher.voucherType, option);
            Thread.Sleep(2000);
        }

        // Botón aceptar canje
        public void ClickAcceptRedeemButton()
        {
            utilityPage.ClickButton(RedeemVoucher.acceptRedeemButton);
            Thread.Sleep(4000);
        }

        // Comprobante canjeada
        public void SetRedeemedVoucher(string value)
        {
            SearchSaleField(value);
            Thread.Sleep(2000);
        }


    }
}
