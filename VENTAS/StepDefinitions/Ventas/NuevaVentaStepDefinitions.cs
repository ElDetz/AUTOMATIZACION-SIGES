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
        UtilityVentaPage UtilityPage;
        public NuevaVentaStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.login = new LoginPage(driver);
            this.newSale = new NuevaVentaPage(driver);
            this.UtilityPage = new UtilityVentaPage(driver);
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
            newSale.SelectModule(modulo);
        }

        [When(@"Agregar concepto por '([^']*)' y valor '([^']*)'")]
        public void WhenAgregarConceptoPorYValor(string option, string value)
        {
            newSale.TypeSelectConcept(option, value);
        }

        [When(@"Ingresar cantidad '([^']*)'")]
        public void WhenIngresarCantidad(string quantity)
        {
            newSale.QuantityConcept(quantity);
        }

        [When(@"Ingresar precio unitario '([^']*)'")]
        public void WhenIngresarPrecioUnitario(string quantity)
        {
            newSale.UnitPrice(quantity);
        }

        [When(@"Activar IGV '([^']*)'")]
        public void WhenActivarIGV(string option)
        {
            CheckboxHelper.EnableIGV(option, driver);
        }

        [When(@"Activar Detalle Unificado '([^']*)'")]
        public void WhenActivarDetalleUnificado(string option)
        {
            CheckboxHelper.EnableUnifiedDetail(option, driver);
        }

        [When(@"Seleccionar tipo de cliente '([^']*)' '([^']*)'")]
        public void WhenSeleccionarTipoDeCliente(string option, string value)
        {
            newSale.SelectCustomerType(option, value);
        }

        //STEP DE VENTA POR CONTIGENCIA
        /* [When(@"Ingresar fecha de emisión de la venta '([^']*)'")] 
         public void WhenIngresarFechaDeEmisionDeLaVenta(string value)
         {
             newSale.IssueDate(value);
         }*/

        [When(@"Seleccionar tipo de comprobante '([^']*)'")]
        public void WhenSeleccionarTipoDeComprobante(string option)
        {
            newSale.SelectInvoiceTypeNewSale(option);   
        }

        /*[When(@"Seleccionar Credito rapido")]
        public void WhenSeleccionarCreditoRapido()
        {
            newSale.CreditoConfigurado();
        }*/

        [When(@"Seleccionar tipo de pago ""([^""]*)""")]
        public void WhenSeleccionarTipoDePago(string option)
        {
            newSale.SelectPaymentType(option);
        }

        [When(@"Ingresar monto inicial '([^']*)'")]
        public void WhenIngresarMontoInicial(string value)
        {
            newSale.Initial(value);
        }

        [When(@"Ingresar el número de coutas '([^']*)'")]
        public void WhenIngresarElNumeroDeCoutas(string value)
        {
            newSale.Cuota(value);
        }


        [When(@"Seleccionar el medio de pago '([^']*)'")]
        public void WhenSeleccionarElMedioDePago(string option)
        {
            newSale.PaymentMethod(option);
        }

        [When(@"Rellene datos de la tarjeta '([^']*)' , '([^']*)' y '([^']*)'")]
        public void WhenRelleneDatosDeLaTarjetaY(string bank, string card, string info)
        {
            newSale.EnterCardDetailsNewSale(bank, card, info);
        }

        [Then(@"Guardar venta")]
        public void ThenGuardarVenta()
        {
            newSale.SaveSale();
        }
    }
}
