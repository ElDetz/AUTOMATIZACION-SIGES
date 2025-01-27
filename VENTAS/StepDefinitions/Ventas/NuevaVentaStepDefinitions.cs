using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SigesCore.Hooks.LoginPage;
using SigesCore.Hooks.VentasPage;
using System.Net;

namespace SigesCore.StepDefinitions.Ventas
{
    [Binding]
    public class NuevaVentaStepDefinitions
    {
        private IWebDriver driver;
        LoginPage login;
        NuevaVentaPage newSale;
        public NuevaVentaStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.login = new LoginPage(driver);
            this.newSale = new NuevaVentaPage(driver);
        }
        [Given(@"Inicio de sesion con usuario '([^']*)' y contrasena '([^']*)'")]
        public void GivenInicioDeSesionConUsuarioYContrasena(string email, string password)
        {
            driver.Url = "https://testcore.sigesonline.com/";
            Thread.Sleep(4000);
            login.LoginToApplication(email, password);
        }

        [When(@"Click en venta luego nueva venta")]
        public void WhenClickEnVentaLuegoNuevaVenta()
        {
            newSale.Buttons();
        }

        [When(@"Agregar concepto por codigo de barra '([^']*)'")]
        public void WhenAgregarConceptoPorCodigoDeBarra(string codeBarra)
        {
            newSale.BarCodeConcept(codeBarra);
        }

        [When(@"Seleccionar familia '([^']*)', concepto '([^']*)' y cantidad '([^']*)'")]
        public void WhenSeleccionarFamiliaConceptoYCantidad(string family, string concept, string quantity)
        {
            newSale.Concept(family, concept, quantity);
        }
        
        public void WhenAgregarConceptoPorCodigoDeBarraSeleccionarFamiliaConceptoYCantidad(string p0, string aBRA, string p2, string p3)
        {
            throw new PendingStepException();
        }


        [When(@"Ingresar dni '([^']*)' y activar IGV")]
        public void WhenIngresarDniEActivarIGV(string dni)
        {
            newSale.DateConcept(dni);
        }

        [When(@"Tipo documento '([^']*)'")]
        public void WhenTipoDocumento(string doc)
        {
            newSale.TypeDoc(doc);
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
