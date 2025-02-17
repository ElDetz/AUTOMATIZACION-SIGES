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

        [When("Ingresar la fecha de vencimiento {string}")]
        public void WhenIngresarLaFechaDeVencimiento(string value)
        {
            
        }

        [Then("Guardar cotización")]
        public void ThenGuardarCotizacion()
        {
            
        }
    }
}
