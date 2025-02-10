using System;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using RESTAURANTE.Features.Facturacion;
using RESTAURANTE.Hoks.Pages;
using RESTAURANTE.Hoks.Pages.Facturacion;
using TechTalk.SpecFlow.Assist;

namespace RESTAURANTE.StepDefinitions.Facturacion
{
    [Binding]
    public class FacturaAtencionStepDefinitions
    {
        private IWebDriver driver;
        AccessPage accessPage;
        FacturacionPage facturacionPage;
        FacturacionSimplePage facturacionSimplePage;
        FacturacionCtaDivididaPage facturacionCtaDivididaPage;

        public FacturaAtencionStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.accessPage = new AccessPage(driver);
            this.facturacionPage = new FacturacionPage(driver);
            this.facturacionSimplePage = new FacturacionSimplePage(driver);
            this.facturacionCtaDivididaPage = new FacturacionCtaDivididaPage(driver);
        }

        [Given(@"Inicio de sesión con usuario '([^']*)' y contraseña '([^']*)'")]
        public void Login(string _user, string _password)
        {
            accessPage.LoginToApplication(_user, _password);
        }

        /*
        [Given(@"Inicio de sesion con usuario")]
        public void GivenInicioDeSesionConUsuario(Table table)
        {
            driver.Url = "https://tintoymadero-qa.sigesonline.com/";

            dynamic data = table.CreateInstance<dynamic>();

            // Realizar el inicio de sesión
            loginPage.LoginToApplication(data.Username, data.Password);
        }
        */

        [Given(@"Se ingresa al módulo '([^']*)'")]
        public void GivenSeIngresaAlModulo(string _modulo)
        {
            accessPage.enterModulo(_modulo);
        }

        [Given(@"Se selecciona el tipo de factura '([^']*)'")]
        public void GivenSeleccionaElTipoDeFactura(string _typeFactura)
        {
            facturacionPage.typeInvoice(_typeFactura);
        }

        /*
        [When(@"Ingresar detalles de la factura '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIngresarDetallesDeLaFactura(string _clientType, string _clientValue, string _comprobante, string _observacion, string _moodPago)
        {
            facturacionSimplePage.EnterBillingDetails(_clientType, _clientValue, _comprobante, _observacion, _moodPago);
        }
        */

        [When(@"Se ingresan los detalles de la factura:")]
        public void WhenIngresarDetallesDeLaFactura(Table table)
        {
            int _ncuentas = 0;
            foreach (var row in table.Rows)
            {
                string tipoCliente = row["TipoCliente"];
                string valorCliente = row["ValorCliente"];
                string tipoComprobante = row["TipoComprobante"];
                string observacion = row["Observacion"];
                string medioPago = row["MedioPago"];

                Console.WriteLine($"Procesando cuenta {_ncuentas}: {tipoCliente}, {valorCliente}, {tipoComprobante}, {observacion}, {medioPago}");

                facturacionPage.EnterBillingDetails(_ncuentas, tipoCliente, valorCliente, tipoComprobante, observacion, medioPago);

                _ncuentas++;
            }
        }


        // CUENTA DIVIDIDA

        [Given(@"Se especifica que la factura será dividida en '([^']*)' cuentas")]
        public void GivenSeEspecificaQueLaFacturaSeraDivididaEnCuentas(int _ncuentas)
        {
            facturacionCtaDivididaPage.addCard(_ncuentas);
        }



        [When(@"Se ingresan los datos del pago:")]
        public void WhenSeIngresanLosDatosDelPago(Table table)
        {
            //
        }


        [When(@"Se ingresan datos del pago '([^']*)' '([^']*)'")]
        public void WhenSeIngresaDatosDelPago(string _cuentaBancaria, string _informacion)
        {
            facturacionSimplePage.PaymentBank(_cuentaBancaria, _informacion);
        }

        [When(@"Se ingresan datos del pago '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenDatosDePago(string _banco, string _tarjeta, string _informacion)
        {
            facturacionSimplePage.PaymentCard(_banco, _tarjeta, _informacion);
        }


        [Then(@"Se realiza la facturación")]
        public void ThenFacturaExitoso()
        {
            facturacionPage.realizarFacturaracion();
        }
    }
}
