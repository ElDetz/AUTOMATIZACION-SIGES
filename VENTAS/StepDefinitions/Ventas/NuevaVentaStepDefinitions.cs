using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SigesCore.Hooks.LoginPage;
using SigesCore.Hooks.VentasPage;
using System.Net;
using SigesCore.Hooks.Utility;
using SigesCore.Hooks.XPaths;
using static SigesCore.Hooks.VentasPage.NuevaVentaPage;

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

        [When(@"Agregar concepto Agregar concepto por codigo de barra '([^']*)'")]
        public void WhenAgregarConceptoAgregarConceptoPorCodigoDeBarra(string valor)
        {
            newSale.barCodeConcept(valor);
        }

        [When(@"Agregar concepto por seleccion '([^']*)'")]
        public void WhenAgregarConceptoPorSeleccion(string value)
        {
            newSale.SelectConcept(value);
        }

        [When(@"Ingresar cantidad '([^']*)'")]
        public void WhenIngresarCantidad(string cantidad)
        {
            newSale.QuantityConcept(cantidad);
        }

        /*[When(@"Agregar concepto por '([^']*)' '([^']*)'")]
        public void WhenAgregarConceptoPor(string method, string value)
        {
            newSale.AddConcept(method, value);
        }*/

        [When(@"Activar IGV '([^']*)'")]
        public void WhenActivarIGV(string option)
        {
            CheckboxHelper.ActivarIGV(option, driver);
        }

        [When(@"Activar Detalle Unificado '([^']*)'")]
        public void WhenActivarDetalleUnificado(string option)
        {
            CheckboxHelper.ActivarDetalleUnif(option, driver);
        }

        [When(@"Seleccionar tipo de cliente '([^']*)' '([^']*)'")]
        public void WhenSeleccionarTipoDeCliente(string doc, string value)
        {
            newSale.invoiceData(doc, value);
        }

        [When(@"Seleccionar tipo de comprobante '([^']*)'")]
        public void WhenSeleccionarTipoDeComprobante(string tipoComprobante)
        {
            newSale.TipoComprobante(tipoComprobante);   
        }

        [When(@"Seleccionar credito rapido")]
        public void WhenSeleccionarCreditoRapido()
        {
            newSale.Creditorapido();
        }


        [When(@"Selecionar tipo de pago '([^']*)'")]
        public void WhenSelecionarTipoDePago(string option)
        {
            newSale.PaymentMethod(option);
        }


        /*[When(@"Medio de pago '([^']*)' y '([^']*)' y '([^']*)'")]
        public void WhenMedioDePagoYY(string bank, string card, string info)
        {
            newSale.PaymentMethod1(bank, card, info);
        }*/

        [Then(@"Guardar venta")]
        public void ThenGuardarVenta()
        {
            throw new PendingStepException();
        }
    }
}
