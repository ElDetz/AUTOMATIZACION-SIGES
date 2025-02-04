using FluentAssertions.Equivalency;
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

        public void QuantityConcept(string value)
        {
            utilityPage.Quantity(Concept.QuantityInputField, value);
        }

        public void UnitPrice(string value)
        {
            utilityPage.Quantity(Concept.UnitPriceInputField, value);
        }

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

            // Métodos específicos para llamar en los Steps
            public static void EnableIGV(string option, IWebDriver driver)
            {
                CheckOption(CheckBox.CheckboxIGV, option, driver);
            }

            public static void EnableUnifiedDetail(string option, IWebDriver driver)
            {
                CheckOption(CheckBox.CheckboxUnifiedDetail, option, driver);
            }
        }

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

        //FUNCIÓN DE VENTA POR CONTINGENCIA

        public void IssueDate(string value) 
        {
            utilityPage.EnterDateClick(Dates.IssueDateField, Dates.IssueDateName, value);
        }

        public void SelectInvoiceTypeNewSale(string value)
        {
            utilityPage.SelectInvoiceType(Voucher.DocNewSaleField, value);
        }

        public void SelectInvoiceTypeContingency(string value)
        {
            utilityPage.SelectInvoiceType(Voucher.DocContingencyField, value);
        }

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

        public void PaymentTypeUtility(By path, string option)
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

        public void PaymentType(string option)
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

        public void EnterCardDetailsNewSale(string typeBank, string typeCard, string info)
        {
            string option = utilityPage.ViewPaymentMethod();  // Obtiene el tipo de medio de pago seleccionado
            option = option.ToUpper();

            switch (option)
            {
                case "TDEB":

                    utilityPage.SelectOption(DebitPaymentNewSale.BankSelector, typeBank);
                    utilityPage.SelectOption(DebitPaymentNewSale.BankSelector, typeCard);
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

        //FUNCIÓN DE VENTA POR CONTINGENCIA
        public void EnterCardDetailsContingency(string typeBank, string typeCard, string info) 
        {
            string option = utilityPage.ViewPaymentMethod();  // Obtiene el tipo de medio de pago seleccionado
            option = option.ToUpper();

            switch (option)
            {
                case "TDEB":

                    utilityPage.SelectOption(DebitPaymentContingency.BankSelector, typeBank);
                    utilityPage.SelectOption(DebitPaymentContingency.BankSelector, typeCard);
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

        public void Initial(string value)
        {
            
            IWebElement modalContainer = driver.FindElement(ConfiguredCreditPopup.Modal);
         
            utilityPage.ElementExists(ConfiguredCreditPopup.InitialField);

            utilityPage.WaitForOverlayToDisappear(ConfiguredCreditPopup.overlayLocator);

            utilityPage.EnterDateClick(ConfiguredCreditPopup.InitialField, ConfiguredCreditPopup.InitialName, value);
        }

        public void Cuota(string value)
        {
            utilityPage.EnterField(ConfiguredCreditPopup.CoutaField, value);
        }

        public void FechaCuota(string value)
        {
            utilityPage.EnterDateClick(ConfiguredCreditPopup.CoutaField, ConfiguredCreditPopup.CoutaName, value);
        }

        public void SaveSale()
        {
            utilityPage.ClickButton(AdditionalElements.SaveSaleButton);
            Thread.Sleep(5000);
        }
    }
}
