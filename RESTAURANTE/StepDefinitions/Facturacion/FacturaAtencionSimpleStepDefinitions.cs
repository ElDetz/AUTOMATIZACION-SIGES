using System;
using OpenQA.Selenium;
using RESTAURANTE.Features.Facturacion;
using RESTAURANTE.Hoks.Pages;

namespace RESTAURANTE.StepDefinitions.Facturacion
{
    [Binding]
    public class FacturaAtencionSimpleStepDefinitions
    {
        private IWebDriver driver;
        LoginPage loginPage;
        UtilityPage utilityPage;
        public FacturaAtencionSimpleStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.loginPage = new LoginPage(driver);
            this.utilityPage = new UtilityPage(driver);
        }

        [Given(@"Inicio de sesion con usuario '([^']*)' y contrasena '([^']*)'")]
        public void Login(string _user, string _password)
        {
            driver.Url = "https://tintoymadero-qa.sigesonline.com/";
            Thread.Sleep(8000);

            // Realizar el inicio de sesión
            loginPage.LoginToApplication(_user, _password);
        }

        [Given(@"Ingreso Modulo '([^']*)'")]
        public void GivenIngresoModulo(string _modulo)
        {
            utilityPage.enterModulo(_modulo);
        }


        [When(@"Datos de la factura")]
        public void WhenDatosDeLaFactura()
        {
           
        }

        [Then(@"Factura exitoso")]
        public void ThenFacturaExitoso()
        {
           
        }


    }
}
