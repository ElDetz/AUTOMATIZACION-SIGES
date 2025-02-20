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

        // CLICK EN EL MÓDULO DE COTIZACIÓN
        public void ClickQouta()
        {
            utilityPage.ClickButton(NewQuote.qoute);
            Thread.Sleep(4000);
        }

        // CLICK EN NUEVO PEDIDO
        public void ClickNewQouta()
        {
            utilityPage.ClickButton(NewQuote.newQoute);
        }

        // AGREGAR CONCEPTO POR CÓDIGO BARRA
        public void ConceptQuota(string value)
        {
            utilityPage.EnterFieldModal(NewQuote.modal, NewOrders.concept, value);
        }

        // INGRESAR LA CANTIDAD DEL CONCEPTO
        public void QuantityconceptQuota(string value)
        {
            utilityPage.CleanFieldModal(NewQuote.modal, NewOrders.quantity, value);
        }

        // INGRESAR LA PRECIO UNITARIO
        public void UnitPriceConceptQuota(string value)
        {
            utilityPage.CleanFieldModal(NewQuote.modal, NewQuote.unitPrice, value);
        }

        // OPCIÓN DE MARCAR O NO EL IGV
        public void IGVQuota(string option)
        {
            utilityPage.CheckBox(NewQuote.modal, NewQuote.igv, option);
        }

        // SELECCIONAR EL TIPO DE CLIENTE
        public void CustomerTypeQuota(string option, string value)
        {
            utilityPage.CustomerType(NewQuote.modal, NewOrders.client, NewOrders.alias, option, value);
        }
        
        // SELECCIONAR EL TIPO DE CLIENTE
        public void ExpirationDateQouta(string value)
        {
            utilityPage.EnterFieldModal(NewQuote.modal, NewQuote.expirationDate, value);
        }

        // CLICK EN PREGENERAR PEDIDO
        public void ClickPregenerateOrder()
        {
            utilityPage.ClickButton(NewQuote.pregenerateOrderPath);
            Thread.Sleep(12000);
        }

        // CLICK EN PREGENERAR VENTA
        public void ClickPregenerateSale()
        {
            utilityPage.ClickButton(NewQuote.pregenerateSalePath);
            Thread.Sleep(5000);
        }

        // MARCAR EL CHECKBOX PARA DETALLE UNIFICADO
        public void UnifiedDetailOrderModal(string option)
        {
            NewWindow();
            utilityPage.CheckBox(NewOrders.modal, NewOrders.unifDetail, option);
        }

        // MARCAR EL CHECKBOX PARA DETALLE UNIFICADO
        public void CustomerTypeOrderModal(string option, string value)
        {
            NewWindow();
            utilityPage.CustomerType(NewOrders.modal, NewOrders.client, NewOrders.alias, option, value);
        }

        // GUARDAR EL PEDIDO PREGENERADO DESDE COTIZACIÓN
        public void SaveOrderFromQuote()
        {
            NewWindow();
            driverQuota.FindElement(NewOrders.save).Click();
            Thread.Sleep(2000);
        }

        // GUARDAR LA VENTA PREGENERADA DESDE COTIZACIÓN
        public void SavePregenerateSale()
        {
            NewWindow();
            driverQuota.FindElement(SaveSalePath.SaveSaleButton).Click();
            Thread.Sleep(4000);
        }

        // FUNCIÓN ADICIONAL PARA TENER ACCESO A LOS COMPONENTES CUANDO SE GENERA UNA NUEVA PESTAÑA,
        // UTILIZADO PARA PREGENERAR UN PEDIDO Y UNA VENTA DESDE COTIZACIÓN
        public void NewWindow()
        {
            WebDriverWait wait = new WebDriverWait(driverQuota, TimeSpan.FromSeconds(10));
            string originalWindow = driverQuota.CurrentWindowHandle;

            wait.Until(d => driverQuota.WindowHandles.Count > 1);

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
