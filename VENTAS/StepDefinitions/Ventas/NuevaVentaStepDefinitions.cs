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

        //STEP PROPIO DE VENTA POR CONTIGENCIA
        [When(@"Ingresar fecha de emisión de la venta '([^']*)'")] 
         public void WhenIngresarFechaDeEmisionDeLaVenta(string value)
         {
             newSale.IssueDateContingency(value);
         }

        [When(@"Seleccionar tipo de comprobante '([^']*)' en el módulo de ""([^""]*)""")]
        public void WhenSeleccionarTipoDeComprobanteEnElModuloDe(string option, string module)
        {
            newSale.SelectInvoiceType(option, module);
        }

        //STEP PROPIO DE VENTA POR CONTIGENCIA
        [When(@"Ingresar el número de documento '([^']*)'")]
        public void WhenIngresarElNumeroDeDocumento(string value)
        {
            newSale.DocumentNumberContingency(value);
        }

        [When(@"Seleccionar tipo de pago ""([^""]*)""")]
        public void WhenSeleccionarTipoDePago(string option)
        {
            newSale.SelectPaymentType(option);
        }

        [When(@"Ingresar monto inicial de crédito rapido '([^']*)' en el módulo de ""([^""]*)""")]
        public void WhenIngresarMontoInicialDeCreditoRapidoEnElModuloDe(string value, string module)
        {
            newSale.InitialQuickPayment(value, module);
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

        [When(@"Ingresar el número de coutas sin inicial '([^']*)'")]
        public void WhenIngresarElNumeroDeCoutasSinInicial(string value)
        {
            newSale.CoutasWithoutInitial(value);
        }

        [When(@"Ingresar fecha '([^']*)'")]
        public void WhenIngresarFecha(string value)
        {
            newSale.DateCuota(value);
        }

        [When(@"Click en generar coutas")]
        public void WhenClickEnGenerarCouta()
        {
            newSale.GenerateQuota();
        }

        [When(@"Click en Aceptar")]
        public void WhenClickEnAceptar()
        {
            newSale.Aceptar();
        }

        [When(@"Seleccionar el medio de pago '([^']*)'")]
        public void WhenSeleccionarElMedioDePago(string option)
        {
            newSale.PaymentMethod(option);
        }
      
        [When(@"Rellene datos de la tarjeta '([^']*)' , '([^']*)' y '([^']*)' en el módulo de ""([^""]*)""")]
        public void WhenRelleneDatosDeLaTarjetaYEnElModuloDe(string bank, string card, string info, string module)
        {
            newSale.EnterCardDetails(bank, card, info, module);
        }

        [Then(@"Guardar venta")]
        public void ThenGuardarVenta()
        {
            newSale.SaveSale();
        }
    }
}
