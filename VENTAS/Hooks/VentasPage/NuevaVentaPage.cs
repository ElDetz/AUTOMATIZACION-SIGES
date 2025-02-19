using FluentAssertions.Equivalency;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
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
        UtilityVenta utilityPage;

        public NuevaVentaPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilityPage = new UtilityVenta(driver);
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

        //SELECIONAR EL PUNTO DE VENTA (PROPIO DE VENTA POR CAJA)
        public void PointSale(string option)
        {
            utilityPage.SelectOption(CashSales.PointSalePath, option);
        }

        //SELECIONAR EL PUNTO DE VENTA(PROPIO DE VENTA POR CAJA)
        public void Seller(string option)
        {
            utilityPage.SelectOption(CashSales.SellerPath, option);
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

        //GUÍA DE REMISIÓN
        public void ClickDispatchGuide ()
        {
            utilityPage.ClickButton(DispatchGuide.DispatchGuideButton);
        }

        public void StartDateTransfer(string value)
        {
            utilityPage.WaitForModalAndVerifyField(DispatchGuide.StartDateTransferPath);
            utilityPage.EnterField(DispatchGuide.StartDateTransferPath, value);
            driver.FindElement(DispatchGuide.StartDateTransferPath).SendKeys(Keys.Enter);
            Thread.Sleep(4000);
        }

        public void TotalGrossWeight(string value)
        {
            utilityPage.EnterField(DispatchGuide.TotalGrossWeightPath, value);
        }

        public void NumberOfPackages(string value)
        {
            utilityPage.EnterField(DispatchGuide.NumberOfPackagesPath, value);
            Thread.Sleep(2000);
        }

        public void CarrierRUC(string value)
        {
            utilityPage.EnterField(DispatchGuide.CarrierRUCPath, value);
            driver.FindElement(DispatchGuide.CarrierRUCPath).SendKeys(Keys.Enter);
        }

        public void TransportMode(string option)
        {
            utilityPage.OptionsSelector(DispatchGuide.Modal, DispatchGuide.TransportModePath, option);
            Thread.Sleep(2000);
        }

        public void DriverDNI(string option)
        {
            utilityPage.EnterField(DispatchGuide.DriverDNIPath, option);
            driver.FindElement(DispatchGuide.DriverDNIPath).SendKeys(Keys.Enter);
        }

        public void DriverLicense(string option)
        {
            utilityPage.EnterField(DispatchGuide.DriverLicensePath, option);
        }

        public void VehiclePlate(string option)
        {
            utilityPage.EnterField(DispatchGuide.VehiclePlatePath, option);
        }

        public void OriginAddressUbigeo(string option)
        {
            utilityPage.OptionsSelector(DispatchGuide.Modal, DispatchGuide.OriginAddressUbigeoPath, option);
        }

        public void OriginAddressDetail(string option)
        {
            utilityPage.EnterField(DispatchGuide.OriginAddressDetailPath, option);
        }

        public void DestinationAddressUbigeo(string option)
        {
            utilityPage.OptionsSelector(DispatchGuide.Modal, DispatchGuide.DestinationAddressUbigeoPath, option);
        }

        public void DestinationAddressDetail(string option)
        {
            utilityPage.EnterField(DispatchGuide.DestinationAddressDetailPath, option);
        }

        public void AcceptDispatchGuideButton()
        {
            utilityPage.ClickButton(DispatchGuide.AcceptDispatchGuideButtonPath);
            Thread.Sleep(2000);
        }

        //INGRESAR FECHA DE EMISIÓN (PROPIO DE VENTA POR CONTINGENCIA)
        public void IssueDateContingency(string value) 
        {
            utilityPage.EnterDateClick(Dates.IssueDateFieldContingency, Dates.IssueDateNameContingency, value);
        }

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

        //SELECCIÓN DE TIPO DE ENTREGA
        public void SelectDeliveryType(string option)
        {
            option = option.ToUpper();
            if (option == "INMEDIATA")
            {
                utilityPage.ClickButton(Delivery.immediate);
            }
            else if (option == "DIFERIDA")
            {
                utilityPage.ClickButton(Delivery.deferredLabel);
            }
            else
            {
                throw new ArgumentException($"El {option} no es válido");
            }
        }

        //SELECCIONAR TIPO DE PAGO
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
        
        //INGRESAR DETALLES DEL PAGO
        public void EnterCardDetails(string bank, string card, string info, string module)
        {
            if (module == "Nueva Venta" || module == "Venta Modo Caja")
            {
                utilityPage.EnterCardDetailsNewSale(bank, card, info);
            }

            else if (module == "Venta por Contingencia")
            {
                utilityPage.EnterCardDetailsContingency(bank, card, info);
            }
            else
            {
                throw new ArgumentException($"Módulo '{module}' no reconocido.");
            }
        }

        //INGRESAR LA INICIAL(PROPIO PARA CRÉDITO CONFIGURADO)
        public void Initial(string value)
        {

            utilityPage.WaitForModalAndVerifyField(ConfiguredCreditPopup.InitialField);
            utilityPage.EnterDateClick(ConfiguredCreditPopup.InitialField, ConfiguredCreditPopup.InitialName, value);
        }

        //INGRESAR EL NRO DE COUTAS (PROPIO PARA CRÉDITO CONFIGURADO)
        public void Cuota(string value)
        {
            utilityPage.EnterField(ConfiguredCreditPopup.CoutaField, value);
        }

        //INGRESAR EL NRO DE COUTAS SIN INICIAL (PROPIO PARA CRÉDITO CONFIGURADO)
        public void CoutasWithoutInitial(string value)
        {
            utilityPage.WaitForModalAndVerifyField(ConfiguredCreditPopup.CoutaField);
            utilityPage.EnterField(ConfiguredCreditPopup.CoutaField, value);
        }

        //INGRESAR EL DÍA DE PAGO DE COUTAS (PROPIO PARA CRÉDITO CONFIGURADO)
        public void DateCuota(string value)
        {
            utilityPage.OptionsSelector(ConfiguredCreditPopup.Modal, ConfiguredCreditPopup.ExpirationDate, value);
        }

        //GENERAR COUTAS (PROPIO PARA CRÉDITO CONFIGURADO)
        public void GenerateQuota()
        {
            utilityPage.ClickButton(ConfiguredCreditPopup.GenerateQuotaButton);
            Thread.Sleep(2000);
        }

        //BOTÓN ACEPTAR (PROPIO PARA CRÉDITO CONFIGURADO) 
        public void Accept()
        {
            utilityPage.ClickButton(ConfiguredCreditPopup.Accept);
            Thread.Sleep(2000);
        }

        //GUARDAR VENTA
        public void SaveSale()
        {
            Thread.Sleep(3000);
            utilityPage.ClickButton(SaveSalePath.SaveSaleButton);
            Thread.Sleep(5000);
        }
    }
}
