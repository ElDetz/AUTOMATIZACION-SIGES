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

namespace SigesCore.Hooks.VentasPage
{
    public class NuevaVentaPage
    {
        private readonly IWebDriver driver;
        WebDriverWait wait;
        UtilityPage utilityPage;

        public NuevaVentaPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilityPage = new UtilityPage(driver);
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

                case "REGISTRADO":
                    //Falta el método
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }
        }

        public void SelectInvoiceType(string option)
        {
            option = option.ToUpper();
            utilityPage.ElementExists(Voucher.DocField);

            switch (option)
            {
                case "BOLETA":

                    // utilityPage.SelectOption2(Voucher.DocField, Voucher.DocInputField, option);
                    utilityPage.SelectOption(Voucher.DocField, option);
                    Thread.Sleep(4000);
                    break;

                case "FACTURA":

                    //utilityPage.SelectOption2(Voucher.DocField, Voucher.DocInputField, option);
                    utilityPage.SelectOption(Voucher.DocField, option);
                    Thread.Sleep(4000);
                    break;

                case "NOTA":

                    //utilityPage.SelectOption2(Voucher.DocField, Voucher.DocInputField, option);
                    utilityPage.SelectOption(Voucher.DocField, option);
                    Thread.Sleep(4000);
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }
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
                    throw new ArgumentException($"El {option} no es válido");
            }

            Thread.Sleep(4000);
        }

        public void EnterCardDetails(string typeBank, string typeCard, string info)
        {
            string option = utilityPage.ViewPaymentMethod();  // Obtiene el tipo de medio de pago seleccionado
            option = option.ToUpper();

            switch (option)
            {
                case "TDEB":

                    utilityPage.SelectOption(DebitPayment.BankSelector, typeBank);
                    utilityPage.SelectOption(DebitPayment.BankSelector, typeCard);
                    utilityPage.EnterField(DebitPayment.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TCRE":

                    utilityPage.SelectOption(CreditPayment.BankSelector, typeBank);
                    utilityPage.SelectOption(CreditPayment.CardSelector, typeCard);
                    utilityPage.EnterField(CreditPayment.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "DEPCU":

                    utilityPage.SelectOption(Deposit.BankSelector, typeBank);
                    utilityPage.EnterField(Deposit.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TRANFON":

                    utilityPage.SelectOption(Transfer.BankSelector, typeBank);
                    utilityPage.EnterField(Transfer.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "EF":

                    utilityPage.EnterField(Cash.Received, info);
                    Thread.Sleep(4000);
                    break;

                case "PTS":
                    break;

                default:
                    throw new ArgumentException($"El tipo de pago {option} no es válido.");
            }
        }

        public void SaveSale()
        {
            utilityPage.ClickButton(AdditionalElements.SaveSaleButton);
            Thread.Sleep(5000);
        }
    }
}

/*
       public void PaymentMethod(string option)
       {
           option = option.ToUpper();

           // Espera explícita para asegurarse de que el elemento 'PayMethod.payment' esté visible
           utilityPage.elementExists(PayMethod.payment);

           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

           switch (option)
           {
               case "Contado":
                   // Espera explícita para asegurar que el botón 'contado' esté clickeable
                   wait.Until(ExpectedConditions.ElementToBeClickable(PayMethod.contado));
                   utilityPage.buttonClickeable(PayMethod.contado);
                   break;

               case "Rapido":
                   // Espera explícita para asegurar que el botón 'rapido' esté clickeable
                   wait.Until(ExpectedConditions.ElementToBeClickable(PayMethod.rapido));
                   utilityPage.buttonClickeable(PayMethod.rapido);
                   break;

               case "Configurado":
                   // Espera explícita para asegurar que el botón 'configurado' esté clickeable
                   wait.Until(ExpectedConditions.ElementToBeClickable(PayMethod.configurado));
                   utilityPage.buttonClickeable(PayMethod.configurado);
                   break;

               default:
                   throw new ArgumentException($"El {option} no es válido");
           }
       }
              public void Creditorapido()
       {
           utilityPage.buttonClickeable(PayMethod.rapido);
       }

       By registrado = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[1]/a[3]");
       By fieldRegistrado = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/span[1]");
       public void ClickClienteRegistrado(string valor)
       {
           utilityPage.buttonClickeable(registrado);
           Thread.Sleep(2000);
           utilityPage.buttonClickeable(fieldRegistrado);
           Thread.Sleep(2000);
           utilityPage.enterDate(fieldRegistrado, valor);
       }

       public void BuscarClienteRegistrado(string datoCliente)
       {
           // Paso 1: Hacer clic en el botón de búsqueda de clientes
           var botonBuscarCliente = driver.FindElement(registrado);
           botonBuscarCliente.Click();

           // Esperar que el campo de búsqueda sea visible y esté habilitado
           utilityPage.WaitForElementVisible(fieldRegistrado);
           var campoBusqueda = driver.FindElement(fieldRegistrado);

           // Paso 2: Hacer clic en el campo de búsqueda
           campoBusqueda.Click();

           // Esperar a que el campo esté realmente enfocado antes de escribir
           // Puede que sea necesario esperar un poco más si el campo es dinámico
           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           wait.Until(d => campoBusqueda.Equals(driver.SwitchTo().ActiveElement()));  // Verifica que el campo esté enfocado

           // Paso 3: Limpiar el campo y luego escribir el dato
           campoBusqueda.Clear();  // Limpiar cualquier valor previo en el campo de búsqueda
           campoBusqueda.SendKeys(datoCliente);  // Ingresar el dato (ejemplo: número de documento)

           // Si el campo está listo, enviar la tecla Enter
           campoBusqueda.SendKeys(Keys.Enter);
       }*/