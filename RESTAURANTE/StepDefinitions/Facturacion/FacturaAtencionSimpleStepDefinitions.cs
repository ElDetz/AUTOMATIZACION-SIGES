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
    public class FacturaAtencionSimpleStepDefinitions
    {
        private IWebDriver driver;
        LoginPage loginPage;
        UtilityPage utilityPage;
        FacturacionPage facturacionPage;
        FacturacionSimplePage facturacionSimplePage;
        public FacturaAtencionSimpleStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.loginPage = new LoginPage(driver);
            this.utilityPage = new UtilityPage(driver);
            this.facturacionPage = new FacturacionPage(driver);
            this.facturacionSimplePage = new FacturacionSimplePage(driver);
        }

        [Given(@"Inicio de sesion con usuario '([^']*)' y contrasena '([^']*)'")]
        public void Login(string _user, string _password)
        {
            driver.Url = "https://tintoymadero-qa.sigesonline.com/";
            Thread.Sleep(8000);

            // Realizar el inicio de sesión
            loginPage.LoginToApplication(_user, _password);
        }

        [Given(@"Inicio de sesion con usuario")]
        public void GivenInicioDeSesionConUsuario(Table table)
        {
            driver.Url = "https://tintoymadero-qa.sigesonline.com/";

            dynamic data = table.CreateInstance<dynamic>();

            // Realizar el inicio de sesión
            loginPage.LoginToApplication(data.Username, data.Password);
        }


        [Given(@"Se ingresa al modulo '([^']*)'")]
        public void GivenSeIngresaAlModulo(string _modulo)
        {
            utilityPage.enterModulo(_modulo);
        }

        [Given(@"Selecciona el tipo de factura '([^']*)'")]
        public void GivenSeleccionaElTipoDeFactura(string _typeFactura)
        {
            facturacionPage.typeFactura(_typeFactura);
        }

        [When(@"Ingresa el cliente '([^']*)' '([^']*)'")]
        public void WhenIngresaElCliente(string _clientType, string _clientValue)
        {
            facturacionSimplePage.AddClient(_clientType, _clientValue);
        }

        [When(@"Selecciona el tipo de comprobante '([^']*)'")]
        public void WhenSeleccionaElTipoDeFactura(string _comprobante)
        {
            // facturacionSimplePage.typeComprobante(_comprobante);
        }

        [When(@"Ingresa alguna observacion '([^']*)'")]
        public void WhenIngresaAlgunaObservacion(string _observacion)
        {
            facturacionSimplePage.AddObservacion(_observacion);
        }

        [When(@"Selecciona el modo de pago '([^']*)'")]
        public void WhenSeleccionaElModoDePago(string _moodPago)
        {
            facturacionSimplePage.moodPay(_moodPago);
        }

        [When(@"Se ingresa datos del pago '([^']*)' '([^']*)'")]
        public void WhenSeIngresaDatosDelPago(string _cuentaBancaria, string _informacion)
        {
            facturacionSimplePage.PaymentBank(_cuentaBancaria, _informacion);
        }

        [When(@"Se ingresa datos del pago '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenDatosDePago(string _banco, string _tarjeta, string _informacion)
        {
            facturacionSimplePage.PaymentCard(_banco, _tarjeta, _informacion);
        }

        [Then(@"Factura exitoso")]
        public void ThenFacturaExitoso()
        {
            facturacionSimplePage.Facturar();
        }
    }
}
