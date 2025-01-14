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

        [When(@"Datos de la venta '([^']*)' y '([^']*)' y '([^']*)'")]  
        public void WhenDatosDeLaVenta(string codeBarra, string dni, string info)
        {
            registroVentaPage.newSale(codeBarra,dni,info);
        }

        [When(@"Tipo de pago")]
        public void WhenTipoDePago()
        {
            
        }

        [When(@"Medio de pago")]
        public void WhenMedioDePago()
        {
            
        }

        [Then(@"Registro exitoso")]
        public void ThenRegistroExitoso()
        {
            
        }
    }
}
