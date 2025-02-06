﻿using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SigesCore.Hooks.Utility;
using SigesCore.Hooks.XPaths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;

namespace SigesCore.Hooks.VentasPage
{
    public class NuevaVentaPage
    {
        private readonly IWebDriver driver;
        WebDriverWait wait;
        UtilityVentaPage utilityPage;

        public NuevaVentaPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilityPage = new UtilityVentaPage(driver);
        }

        //SELECCIÓN DE MÓDULO Y SUBMÓDULO
        public void SelectModule(string option)
        {
            utilityPage.ClickButton(SalesModule.SalesMenu);

            switch (option)
            {
                case "Nueva Venta":

                    utilityPage.ClickButton(SalesModule.NewSaleLink);
                    break;

                case "Venta Modo Caja":

                    utilityPage.ClickButton(SalesModule.SaleCashModeLink);
                    break;

                case "Venta Por Contingencia":

                    utilityPage.ClickButton(SalesModule.ContingencySaleLink);
                    break;

                case "Ver Ventas":

                    utilityPage.ClickButton(SalesModule.ViewSalesLink);
                    break;

                case "Reportes Vendedor":

                    utilityPage.ClickButton(SalesModule.SellerReportLink);
                    break;

                case "Reportes Puntos":

                    utilityPage.ClickButton(SalesModule.PointsReportLink);
                    break;

                case "Reportes Gerente":

                    utilityPage.ClickButton(SalesModule.ManagerReportLink);
                    break;

                case "Reportes":

                    utilityPage.ClickButton(SalesModule.ReportsMenu);
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido.");
            }
        }

        //AGREGACIÓN DE CONCEPTO
        public void TypeSelectConcept(string option, string value)
        {
            option = option.ToUpper();
            utilityPage.ElementExists(Concept.BarcodeInputField);
            switch (option)
            {
                case "BARRA":
                    utilityPage.BarCodeConcept(value);
                    break;

                case "SELECCION":
                    utilityPage.SelectConcept(value);
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }
        }

        //INGRESAR CANTIDAD
        public void QuantityConcept(string value)
        {
            utilityPage.Quantity(Concept.QuantityInputField, value);
        }

        //INGRESAR PRECIO UNITARIO
        public void UnitPrice(string value)
        {
            utilityPage.Quantity(Concept.UnitPriceInputField, value);
        }

        //SELECCIONAR IGV Y DET.UNIF
        public class CheckboxHelper
        {
            public static void CheckOption(By locator, string option, IWebDriver driver)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                option = option.ToUpper();
                var checkbox = driver.FindElement(locator);

                if (option == "SI")
                {
                    if (!checkbox.Selected)
                    {
                        checkbox.Click();
                        Console.WriteLine($"El checkbox {locator} ha sido activado.");
                    }
                    else
                    {
                        Console.WriteLine($"El checkbox {locator} ya estaba activado.");
                    }
                }
                else if (option == "NO")
                {
                    Console.WriteLine($"El checkbox {locator} sigue desactivado.");
                }
                else
                {
                    throw new ArgumentException($"Opción no válida: {option}. Use 'SI' o 'NO'.");
                }
            }
            public static void EnableIGV(string option, IWebDriver driver)
            {
                CheckOption(CheckBox.CheckboxIGV, option, driver);
            }

            public static void EnableUnifiedDetail(string option, IWebDriver driver)
            {
                CheckOption(CheckBox.CheckboxUnifiedDetail, option, driver);
            }
        }

        //SELECIONAR EL TIPO DE CLIENTE
        public void SelectCustomerType(string option, string value)
        {
            option = option.ToUpper();
            utilityPage.ElementExists(Dates.ClientField);

            switch (option)
            {
                case "VARIOS":

                    break;

                case "DNI":

                    utilityPage.EnterField(Dates.ClientField, value);
                    driver.FindElement(Dates.ClientField).SendKeys(Keys.Enter);
                    Thread.Sleep(4000);
                    break;

                case "RUC":

                    utilityPage.EnterField(Dates.ClientField, value);
                    driver.FindElement(Dates.ClientField).SendKeys(Keys.Enter);
                    Thread.Sleep(4000);
                    break;

                case "ALIAS":

                    utilityPage.EnterField(Dates.AliasField, value);
                    driver.FindElement(Dates.AliasField).SendKeys(Keys.Enter);
                    Thread.Sleep(4000);
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }
        }

        //INGRESAR FECHA DE EMISIÓN (PROPIO DE VENTA POR CONTINGENCIA)

        public void IssueDateContingency(string value) 
        {
            utilityPage.EnterDateClick(Dates.IssueDateFieldContingency, Dates.IssueDateNameContingency, value);
        }

        /*
        public void SelectInvoiceTypeNewSale(string value)
        {
            utilityPage.SelectInvoiceType(Voucher.DocNewSaleField, value);
        }

        public void SelectInvoiceTypeContingency(string value)
        {
            utilityPage.SelectInvoiceType(Voucher.DocContingencyField, value);
        }*/

        //SELECCIONAR TIPO DE COMPROBANTE
        public void SelectInvoiceType(string option, string module)
        {
            if (module == "Nueva Venta" || module == "Venta Modo Caja")
            {
                utilityPage.SelectInvoiceType(Voucher.DocNewSaleField, option);
            }

            else if (module == "Venta por Contingencia")
            {
                utilityPage.SelectInvoiceType(Voucher.DocContingencyField, option);
            }
            else
            {
                throw new ArgumentException($"Módulo '{module}' no reconocido.");
            }
        }

        //INGRESAR EL NRO DEL COMPROBANTE (PROPIO DE VENTA POR CONTINGENCIA)
        public void DocumentNumberContingency (string value)
        {
            utilityPage.EnterField(Dates.DocNumberContingency, value);
        }

        //falta
        public void SelectPaymentType(string option)
        {
            switch (option.ToLower())
            {
                case "contado":
                    utilityPage.CashPayment();
                    break;

                case "credito rapido":
                    utilityPage.QuickCreditPayment();
                    break;

                case "credito configurado":
                    utilityPage.ConfiguredCreditPayment();
                    break;

                default:
                    throw new ArgumentException($"Payment type '{option}' is not recognized.");
            }
        }

        /*
        public void PaymentTypeUtility3(By path, string option)
        {
            switch (option)
            {
                case "Contado":

                    utilityPage.ClickButton(path);
                    break;

                case "Credito rapido":

                    utilityPage.ClickButton(path);
                    break;

                case "Credito configurado":

                    utilityPage.ClickButton(path);
                    break;

                default:
                    throw new ArgumentException($"El {path} no es válido");
            }
        }

      
        public void PaymentType3(string option)
        {
            option = option.ToUpper();

            switch (option)
            {
                case "Contado":

                    PaymentTypeUtility(PaymentTypePath.CashPaymentOption, option);
                    break;

                case "Credito rapido":

                    PaymentTypeUtility(PaymentTypePath.QuickPaymentOption, option);
                    break;

                case "Credito configurado":

                    PaymentTypeUtility(PaymentTypePath.ConfiguredPaymentOption, option);
             
                    break;

                default:
                    throw new ArgumentException($"La opción {option} no es válido");
            }
            //Thread.Sleep(4000);
        }

        //INGRESAR LA INICIAL (PROPIO PARA CRÉDITO CONFIGURADO)
        /* public void InitialQuickPaymentNewSale(string value)
         {
             utilityPage.EnterField(QuickCreedit.InitialMountNewSale, value);
         }

        //INGRESAR LA INICIAL(PROPIO PARA CRÉDITO CONFIGURADO)
        public void InitialQuickPaymentContingency(string value) 
        {
            utilityPage.EnterField(QuickCreedit.InitialMountContingency, value);
        }*/

        //INGRESAR LA INICIAL(PROPIO PARA CRÉDITO RÁPIDO)
        public void InitialQuickPayment(string value, string module)
        {
            if (module == "Nueva Venta" || module == "Venta Modo Caja")
            {
                utilityPage.EnterField(QuickCreedit.InitialMountNewSale, value);
            }
            else if (module == "Venta por Contingencia")
            {
                utilityPage.EnterField(QuickCreedit.InitialMountContingency, value);
            }
            else
            {
                throw new ArgumentException($"Módulo '{module}' no reconocido.");
            }
        }

        //SELECIONAR MEDIO DE PAGO
        public void PaymentMethod(string option)
        {
            option = option.ToUpper();

            switch (option)
            {
                case "DEPCU":

                    utilityPage.PaymentMethodUtility(PaymentMethodPath.DepositButton, option);
                    break;

                case "TRANFON":

                    utilityPage.PaymentMethodUtility(PaymentMethodPath.TransferButton, option);
                    break;

                case "TDEB":

                    utilityPage.PaymentMethodUtility(PaymentMethodPath.DebitCardButton, option);
                    break;

                case "TCRE":

                    utilityPage.PaymentMethodUtility(PaymentMethodPath.CreditCardButton, option);
                    break;

                case "EF":

                    utilityPage.PaymentMethodUtility(PaymentMethodPath.CashButton, option);
                    break;

                case "PTS":

                    utilityPage.PaymentMethodUtility(PaymentMethodPath.PointsButton, option);
                    break;

                default:
                    throw new ArgumentException($"La opción {option} no es válido");
            }

            Thread.Sleep(4000);
        }

        //INGRESAR DETALLES DEL PAGO (NUEVA VENTA)
        public void EnterCardDetailsNewSale(string typeBank, string typeCard, string info)
        {
            string option = utilityPage.ViewPaymentMethod();  // Obtiene el tipo de medio de pago seleccionado
            option = option.ToUpper();

            switch (option)
            {
                case "TDEB":

                    utilityPage.SelectOption(DebitPaymentNewSale.BankSelector, typeBank);
                    utilityPage.SelectOption(DebitPaymentNewSale.CardSelector, typeCard);
                    utilityPage.EnterField(DebitPaymentNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TCRE":

                    utilityPage.SelectOption(CreditPaymentNewSale.BankSelector, typeBank);
                    utilityPage.SelectOption(CreditPaymentNewSale.CardSelector, typeCard);
                    utilityPage.EnterField(CreditPaymentNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "DEPCU":

                    utilityPage.SelectOption(DepositNewSale.BankSelector, typeBank);
                    utilityPage.EnterField(DepositNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TRANFON":

                    utilityPage.SelectOption(TransferNewSale.BankSelector, typeBank);
                    utilityPage.EnterField(TransferNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "EF":

                    utilityPage.EnterField(CashNewSale.Received, info);
                    Thread.Sleep(4000);
                    break;

                case "PTS":
                    break;

                default:
                    throw new ArgumentException($"El tipo de pago {option} no es válido.");
            }
        }

        //INGRESAR DETALLES DEL PAGO (VENTA POR CONTINGENCIA)
        public void EnterCardDetailsContingency(string typeBank, string typeCard, string info) 
        {
            string option = utilityPage.ViewPaymentMethod();
            option = option.ToUpper();

            switch (option)
            {
                case "TDEB":

                    utilityPage.SelectOption(DebitPaymentContingency.BankSelector, typeBank);
                    utilityPage.SelectOption(DebitPaymentContingency.CardSelector, typeCard);
                    utilityPage.EnterField(DebitPaymentContingency.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TCRE":

                    utilityPage.SelectOption(CreditPaymentNewSale.BankSelector, typeBank);
                    utilityPage.SelectOption(CreditPaymentNewSale.CardSelector, typeCard);
                    utilityPage.EnterField(CreditPaymentNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "DEPCU":

                    utilityPage.SelectOption(DepositNewSale.BankSelector, typeBank);
                    utilityPage.EnterField(DepositNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TRANFON":

                    utilityPage.SelectOption(TransferNewSale.BankSelector, typeBank);
                    utilityPage.EnterField(TransferNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "EF":

                    utilityPage.EnterField(CashNewSale.Received, info);
                    Thread.Sleep(4000);
                    break;

                case "PTS":
                    break;

                default:
                    throw new ArgumentException($"El tipo de pago {option} no es válido.");
            }
        }

        //INGRESAR DETALLES DEL PAGO

        public void EnterCardDetails(string bank, string card, string info, string module)
        {
            if (module == "Nueva Venta" || module == "Venta Modo Caja")
            {
                EnterCardDetailsNewSale(bank, card, info);
            }

            else if (module == "Venta por Contingencia")
            {
                EnterCardDetailsContingency(bank, card, info);
            }
            else
            {
                throw new ArgumentException($"Módulo '{module}' no reconocido.");
            }
        }

        //INGRESAR LA INICIAL(PROPIO PARA CRÉDITO CONFIGURADO)
        public void Initial(string value)
        {
            
            IWebElement modalContainer = driver.FindElement(ConfiguredCreditPopup.Modal);
         
            utilityPage.ElementExists(ConfiguredCreditPopup.InitialField);

            utilityPage.WaitForOverlayToDisappear(AdditionalElements.OverlayElement);

            utilityPage.EnterDateClick(ConfiguredCreditPopup.InitialField, ConfiguredCreditPopup.InitialName, value);
        }

        //INGRESAR EL NRO DE COUTAS (PROPIO PARA CRÉDITO CONFIGURADO)
        public void Cuota(string value)
        {
            utilityPage.EnterField(ConfiguredCreditPopup.CoutaField, value);
        }

        //INGRESAR EL DÍA DE PAGO DE COUTAS (PROPIO PARA CRÉDITO CONFIGURADO)
        public void DateCuota(string value)
        {
            Thread.Sleep(4000);
            IWebElement modalFacturacion = driver.FindElement(ConfiguredCreditPopup.Modal);

            IWebElement dropdown = modalFacturacion.FindElement(By.Id("diavencimiento"));
            Console.WriteLine("Campo seleccion encontrada");
            IReadOnlyCollection<IWebElement> dropdownOptions = dropdown.FindElements(By.TagName("option"));
            Console.WriteLine("Slecciones extraidas");
            foreach (IWebElement option in dropdownOptions)
            {
                if (option.Text.Equals(value))
                    option.Click();
            }
            string selectedOption = "";
            foreach (IWebElement option in dropdownOptions)
            {
                if (option.Selected)
                    selectedOption = option.Text;
            }
            Assert.That(selectedOption, Is.EqualTo(value));
            Thread.Sleep(4000);
        }

        //GENERAR COUTAS (PROPIO PARA CRÉDITO CONFIGURADO)
        public void GenerateQuota()
        {
            var botonGenerarCuota = driver.FindElement(By.XPath("//body/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[6]/button[1]"));
            botonGenerarCuota.Click();
        }

        //GUARDAR VENTA
        public void SaveSale()
        {
            utilityPage.ClickButton(SaveSalePath.SaveSaleButton);
            Thread.Sleep(5000);
        }
    }
}
