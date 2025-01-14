using OpenQA.Selenium;
using PruebaConcepto.Hoks.PagesPruebaConcepto;
using System;
using TechTalk.SpecFlow;

namespace PruebaConcepto.StepDefinitions
{
    [Binding]
    public sealed class NuevaVentaStepDefinitions
    {
        private IWebDriver driver;
        SearchPage searchPage;
        public NuevaVentaStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.searchPage = new SearchPage(driver); // Inicializa searchPage aquí
        }


        [Given(@"Inicio de sesion")]
        public void GivenInicioDeSesion()
        {
            driver.Url = "https://testcore.sigesonline.com/";
            Thread.Sleep(8000);

            // Realizar el inicio de sesión
            searchPage.LoginToApplication("admin@plazafer.com", "calidad");
        }

        [When(@"Datos de la venta")]
        public void WhenDatosDeLaVenta()
        {
            
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
