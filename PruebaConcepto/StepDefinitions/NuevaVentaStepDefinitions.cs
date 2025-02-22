using OpenQA.Selenium;
using PruebaConcepto.Hoks.PagesPruebaConcepto;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace PruebaConcepto.StepDefinitions
{
    [Binding]
    public class NuevaVentaStepDefinitions
    {
        private IWebDriver driver;
        LoginPage loginPage;
        RegistroVentaPage registroVentaPage;
        public NuevaVentaStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.loginPage = new LoginPage(driver);
            this.registroVentaPage = new RegistroVentaPage(driver);
        }

        [Given(@"Inicio de sesion con usuario '([^']*)' y contrasena '([^']*)'")]
        public void GivenInicioDeSesionConUsuarioYContrasena(string p0, string calidad)
        {
            driver.Url = "https://testcore.sigesonline.com/";
            Thread.Sleep(8000);

            // Realizar el inicio de sesión
            loginPage.LoginToApplication(p0, calidad);
        }

        [When(@"Datos de la venta '([^']*)' y '([^']*)'")]  
        public void WhenDatosDeLaVenta(string codeBarra, string dni)
        {
            registroVentaPage.CompleteFields(codeBarra,dni);
        }

        [When(@"Tipo de comprobante '([^']*)'")]
        public void WhenTipoDeComprobante(string _comprobante)
        {
            registroVentaPage.tipoComprobante(_comprobante);
        }

        [When(@"Tipo de pago '([^']*)'")]
        public void WhenTipoDePago(string _PaymentType)
        {
            //registroVentaPage.PaymentType(_PaymentType);
        }

        [When(@"Prueba '([^']*)'")]
        public void WhenDatosDelPagoYY(string dni)
        {
            
            //registroVentaPage.nuevaguia(dni);
        }

        [When(@"Datos del pago '([^']*)' y '([^']*)'")]
        public void WhenDatosDelPagoY(string _bank, string _info)
        {
            registroVentaPage.PaymentMethod2(_bank, _info);
        }

        [When(@"Datos del pago '([^']*)'")]
        public void WhenDatosDelPago(string _observacion)
        {
            registroVentaPage.PaymentMethod3(_observacion);
        }


        [Then(@"Registro exitoso")]
        public void ThenRegistroExitoso()
        {
            registroVentaPage.SaveSale();
        }
    }
}
