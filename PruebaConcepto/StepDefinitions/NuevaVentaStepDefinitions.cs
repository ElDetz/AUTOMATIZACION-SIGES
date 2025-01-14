using OpenQA.Selenium;
using PruebaConcepto.Hoks.PagesPruebaConcepto;
using System;
using TechTalk.SpecFlow;

namespace PruebaConcepto.StepDefinitions
{
    [Binding]
    public class NuevaVentaStepDefinitions
    {
        private IWebDriver driver;
        SearchPage searchPage;
        public NuevaVentaStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.searchPage = new SearchPage(driver); // Inicializa searchPage aquí
        }

        [Given(@"Inicio de sesion con usuario '([^']*)' y contrasena '([^']*)'")]
        public void GivenInicioDeSesionConUsuarioYContrasena(string p0, string calidad)
        {
            driver.Url = "https://testcore.sigesonline.com/";
            Thread.Sleep(8000);

            // Realizar el inicio de sesión
            searchPage.LoginToApplication(p0, calidad);
        }

        [When(@"Datos de la venta")]
        public void WhenDatosDeLaVenta()
        {
            throw new PendingStepException();
        }

        [When(@"Tipo de pago")]
        public void WhenTipoDePago()
        {
            throw new PendingStepException();
        }

        [When(@"Medio de pago")]
        public void WhenMedioDePago()
        {
            throw new PendingStepException();
        }

        [Then(@"Registro exitoso")]
        public void ThenRegistroExitoso()
        {
            throw new PendingStepException();
        }
    }
}
