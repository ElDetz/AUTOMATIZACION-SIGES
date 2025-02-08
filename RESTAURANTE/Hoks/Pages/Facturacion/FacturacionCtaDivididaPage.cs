using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V130.Debugger;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RESTAURANTE.Hoks.Pages.Facturacion
{
    public class FacturacionCtaDivididaPage
    {
        private IWebDriver driver;
        Utilities utilities;
        FacturacionPage facturacionPage;

        public FacturacionCtaDivididaPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilities = new Utilities(driver);
            this.facturacionPage = new FacturacionPage(driver);

        }

        private By overlayLocator = By.ClassName("block-ui-overlay");
        private By _modalFacturacion = By.Id("facturacionVenta-0");
        private By fieldLocator;

        //CLIENTE
        private By docIdentidadField = By.Id("DocumentoIdentidad");
        // private By aliasField = By.XPath("//input[@ng-model='$ctrl.facturacion.Orden.Cliente.Alias']");
        private By aliasField = By.XPath("//label[contains(text(), 'ALIAS')]/following-sibling::input");


        // COMPROBANTE
        private By comprobanteSelect = By.Name("TipoComprobante");

        //OBSERVACION
        private By observacionField = By.Id("observacion");

        // MODO DE PAGO
        By dpcuButton = By.XPath("//label[@id='labelMedioPago-0-14']");
        By tranfonButton = By.XPath("//label[@id='labelMedioPago-0-16']");
        By tdebButton = By.XPath("//label[@id='labelMedioPago-0-18']");
        By tcreButton = By.XPath("//label[@id='labelMedioPago-0-19']");
        By efButton = By.XPath("//label[@id='labelMedioPago-0-281']");

        public void EnterBillingDetails(int _ncuenta, string _clientType, string _clientValue, string _comprobante, string _observacion, string _moodPago)
        {
            // Encontrar el modal FACTURACION
            IWebElement modalFacturacion = driver.FindElement(By.Id($"facturacionVenta-{_ncuenta}"));

            // TIPO CLIENTE
            switch (_clientType)
            {
                case "VARIOS":
                    return;

                case "DNI":
                case "RUC":

                    fieldLocator = docIdentidadField; // CAMPO DOC INDENTIDAD
                    break;

                case "ALIAS":

                    fieldLocator = aliasField; // CAMPO ALIAS
                    break;

                default:
                    throw new ArgumentException($"El {_clientType} no es válido");
            }

            utilities.enterFieldModal(modalFacturacion, fieldLocator, _clientValue);
            Console.WriteLine($"CLIENTE CUENTA {_ncuenta} INGRESADO");
            Thread.Sleep(4000);

            // COMPROBANTE
            var dropdown = new SelectElement(modalFacturacion.FindElement(comprobanteSelect));
            dropdown.SelectByText(_comprobante);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(_comprobante));

            Console.WriteLine($"COMPROBANTE CUENTA {_ncuenta} INGRESADO");
            Thread.Sleep(4000);

            // OBSERVACION
            utilities.elementExists(observacionField);
            utilities.WaitForOverlayToDisappear(overlayLocator);

            utilities.addFieldModal(modalFacturacion, observacionField, _observacion);
            Console.WriteLine($"OBSERVACION CUENTA {_ncuenta} INGRESADO");
            Thread.Sleep(4000);

            Dictionary<string, By> moodPagoButtons;

            if (_ncuenta == 0)
            {
                moodPagoButtons = new Dictionary<string, By>
                {
                    { "DEPCU", By.XPath($"//label[@id='labelMedioPago-{_ncuenta}-14']") },
                    { "TRANFON", By.XPath($"//label[@id='labelMedioPago-{_ncuenta}-16']") },
                    { "TDEB", By.XPath($"//label[@id='labelMedioPago-{_ncuenta}-18']") },
                    { "TCRE", By.XPath($"//label[@id='labelMedioPago-{_ncuenta}-19']") },
                    { "EF", By.XPath($"//label[@id='labelMedioPago-{_ncuenta}-281']") }
                };
            }
            else
            {
                // Diccionario que mapea el modo de pago al botón correspondiente
                moodPagoButtons = new Dictionary<string, By>
                {
                    { "DEPCU", By.XPath($"//label[@id='labelMedioPago--{_ncuenta}-14']") },
                    { "TRANFON", By.XPath($"//label[@id='labelMedioPago--{_ncuenta}-16']") },
                    { "TDEB", By.XPath($"//label[@id='labelMedioPago--{_ncuenta}-18']") },
                    { "TCRE", By.XPath($"//label[@id='labelMedioPago--{_ncuenta}-19']") },
                    { "EF", By.XPath($"//label[@id='labelMedioPago--{_ncuenta}-281']") }
                };
            }

            // Verificar si el modo de pago existe en el diccionario
            if (moodPagoButtons.ContainsKey(_moodPago))
            {
                // Llamar al método moodPay con el botón correspondiente
                utilities.ClickButtonInModal(modalFacturacion, moodPagoButtons[_moodPago]);
            }
            else
            {
                // Lanzar excepción si el modo de pago no es válido
                throw new ArgumentException($"El {_moodPago} no es válido");
            }
            Console.WriteLine($"METODO DE PAGO {_ncuenta} INGRESADO");
            Thread.Sleep(4000);

            Console.WriteLine($"***DETALLES CUENTA {_ncuenta} INGRESADO***");
            Thread.Sleep(4000);

        }

    }
}