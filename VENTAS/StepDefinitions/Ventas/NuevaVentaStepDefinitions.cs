using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SigesCore.Hooks.LoginPage;
using SigesCore.Hooks.VentasPage;
using System.Net;
using SigesCore.Hooks.Utility;
using SigesCore.Hooks.XPaths;

namespace SigesCore.StepDefinitions.Ventas
{
    [Binding]
    public class NuevaVentaStepDefinitions
    {
        private IWebDriver driver;
        LoginPage login;
        NuevaVentaPage newSale;
        UtilityPage UtilityPage;
        public NuevaVentaStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.login = new LoginPage(driver);
            this.newSale = new NuevaVentaPage(driver);
            this.UtilityPage = new UtilityPage(driver);
        }
        [Given(@"Inicio de sesion con usuario '([^']*)' y contrasena '([^']*)'")]
        public void GivenInicioDeSesionConUsuarioYContrasena(string email, string password)
        {
            driver.Url = "https://testcore.sigesonline.com/";
            Thread.Sleep(4000);
            login.LoginToApplication(email, password);
        }

        [When(@"Seleccionar Venta y luego ""([^""]*)""")]
        public void WhenSeleccionarVentaYLuego(string modulo)
        {
            newSale.enterModulo(modulo);
        }

        [When(@"Agregar concepto por codigo de barra '([^']*)'")]
        public void WhenAgregarConceptoPorCodigoDeBarra(string codeBarra)
        {
            newSale.barCodeConcept(codeBarra);
        }

        [When(@"Seleccionar familia '([^']*)', concepto '([^']*)' y cantidad '([^']*)'")]
        public void WhenSeleccionarFamiliaConceptoYCantidad(string family, string concept, string quantity)
        {
            newSale.Concept(family, concept, quantity);
        }

        [When(@"Activar IGV '([^']*)'")]
        public void WhenActivarIGV(string option)
        {
            newSale.IGVoption(option);
        }

        [When(@"Tipo documento '([^']*)'")]
        public void WhenTipoDocumento(string doc, string value)
        {
            newSale.invoiceData(doc, value);
        }

        [When(@"Medio de pago '([^']*)' y '([^']*)' y '([^']*)'")]
        public void WhenMedioDePagoYY(string bank, string card, string info)
        {
            newSale.PaymentMethod1(bank, card, info);
        }

        [Then(@"Guardar venta")]
        public void ThenGuardarVenta()
        {
            throw new PendingStepException();
        }
    }
}
