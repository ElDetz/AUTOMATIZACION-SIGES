using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigesCore.Hooks.LoginPage;
using SigesCore.Hooks.VentasPage;
using System.Net;
using SigesCore.Hooks.Utility;
using OpenQA.Selenium;

namespace SigesCore.StepDefinitions.Ventas
{
    [Binding]
    public class CotizacionStepDefinitions
    {
        private IWebDriver driver;
        CotizacionPage qouta;
 
        public CotizacionStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.qouta = new CotizacionPage(driver); ;
        }

        [When("Seleccionar Cotización")]
        public void WhenSeleccionarCotizacion()
        {
            qouta.ClickQouta();
        }

        [When("Click en nueva cotización")]
        public void WhenClickEnNuevaCotizacion()
        {
            qouta.ClickNewQouta();
        }

        [When("Agregar concepto para cotización {string}")]
        public void WhenAgregarConceptoParaCotizacion(string value)
        {
            qouta.conceptQuota(value);
        }

        [When("Agregar tipo de cliente para cotización {string} {string}")]
        public void WhenAgregarTipoDeClienteParaCotizacion(string option, string value)
        {
            qouta.CustomerTypeQuota(option, value);
        }

        [When("Ingresar la fecha de vencimiento {string}")]
        public void WhenIngresarLaFechaDeVencimiento(string value)
        {
            qouta.expirationDateQouta(value);
        }

        [When("Click en pregenerar pedido")]
        public void WhenClickEnPregenerarPedido()
        {
            qouta.ClickPregenerateOrder();
        }

        [Then("Guardar pedido pregenerado")]
        public void ThenGuardarPedidoPregenerado()
        {
            qouta.SavePregenerateOrder();
        }

        [When("Click en pregenerar venta")]
        public void WhenClickEnPregenerarVenta()
        {
            qouta.ClickPregenerateSale();
        }

        [Then("Guardar venta pregenerada")]
        public void ThenGuardarVentaPregenerada()
        {
            qouta.SavePregenerateSale();
        }
    }
}
