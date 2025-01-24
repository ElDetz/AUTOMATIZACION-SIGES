using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SigesCore.Hooks.LoginPage;

namespace SigesCore.StepDefinitions.Ventas
{
    [Binding]
    public class NuevaVentaStepDefinitions
    {
        private IWebDriver driver;
        LoginPage login;
        public NuevaVentaStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.login = new LoginPage(driver);
        }
        [Given(@"Inicio de sesion con usuario '([^']*)' y contrasena '([^']*)'")]
        public void GivenInicioDeSesionConUsuarioYContrasena(string email, string password)
        {
            driver.Url = "https://testcore.sigesonline.com/";
            Thread.Sleep(8000);
            login.LoginToApplication(email, password);
        }

        [Given(@"Rellenar detalles de concepto")]
        public void GivenRellenarDetallesDeConcepto()
        {
            throw new PendingStepException();
        }

        [Then(@"Concepto pasa a facturación")]
        public void ThenConceptoPasaAFacturacion()
        {
            throw new PendingStepException();
        }
    }
}
