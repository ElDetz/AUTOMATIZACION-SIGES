using System;
using OpenQA.Selenium;
using RESTAURANTE.Features.Facturacion;
using RESTAURANTE.Hoks.Pages;
using RESTAURANTE.Hoks.Pages.Facturacion;

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

        [When(@"Se ingresa los datos de la factura '([^']*)' '([^']*)'")]
        public void WhenSeIngresaLosDatosDeLaFactura(string _clientType, string _clientValue)
        {
            facturacionSimplePage.invoiceData(_clientType, _clientValue);
        }

        [When(@"Datos de la factura")]
        public void WhenDatosDeLaFactura()
        {
            facturacionSimplePage.moodPay(_moodPago);
        }

        [When(@"Datos de pago '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenDatosDePago(string _bank, string _card, string _info)
        {
            facturacionSimplePage.PaymentCard(_bank,_card, _info);
        }


        [Then(@"Factura exitoso")]
        public void ThenFacturaExitoso()
        {
           
        }
    }
}
