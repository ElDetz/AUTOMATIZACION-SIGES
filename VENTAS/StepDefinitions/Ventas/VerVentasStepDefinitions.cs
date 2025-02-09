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
    public class VerVentasStepDefinitions
    {
        private IWebDriver driver;
        LoginPage login;
        NuevaVentaPage newSale;

        public VerVentasStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.login = new LoginPage(driver);
            this.newSale = new NuevaVentaPage(driver);
        }

        [When(@"Ingresar fecha inicial '([^']*)'")]
        public void WhenIngresarFechaInicial(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Ingresar fecha final '([^']*)'")]
        public void WhenIngresarFechaFinal(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Click en consultar ventas")]
        public void WhenClickEnConsultarVentas()
        {
            throw new PendingStepException();
        }

        [When(@"Buscar venta '([^']*)'")]
        public void WhenBuscarVenta(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Activar canje")]
        public void WhenActivarCanje()
        {
            throw new PendingStepException();
        }

        [When(@"Seleccionar venta")]
        public void WhenSeleccionarVenta()
        {
            throw new PendingStepException();
        }

        [When(@"Click en el botón canjear")]
        public void WhenClickEnElBotonCanjear()
        {
            throw new PendingStepException();
        }

        [When(@"Seleccionar el tipo de comprobante '([^']*)'")]
        public void WhenSeleccionarElTipoDeComprobante(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Click en el botón aceptar")]
        public void WhenClickEnElBotonAceptar()
        {
            throw new PendingStepException();
        }

        [Then(@"Ver venta canjeada")]
        public void ThenVerVentaCanjeada()
        {
            throw new PendingStepException();
        }

        [When(@"Ver venta buscada")]
        public void WhenVerVentaBuscada()
        {
            throw new PendingStepException();
        }

        [When(@"Click en nota de débito")]
        public void WhenClickEnNotaDeDebito()
        {
            throw new PendingStepException();
        }

        [When(@"Seleccionar el tipo de nota de débito '([^']*)'")]
        public void WhenSeleccionarElTipoDeNotaDeDebito(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Seleccionar el documento '([^']*)'")]
        public void WhenSeleccionarElDocumento(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Escribir el motivo de la nota '([^']*)'")]
        public void WhenEscribirElMotivoDeLaNota(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Ingresar el aumento de valor de la nota '([^']*)'")]
        public void WhenIngresarElAumentoDeValorDeLaNota(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Guardar nota de débito")]
        public void WhenGuardarNotaDeDebito()
        {
            throw new PendingStepException();
        }

        [Then(@"Ver la nota de débito emitida")]
        public void ThenVerLaNotaDeDebitoEmitida()
        {
            throw new PendingStepException();
        }

        [When(@"Ingresar el interés total '([^']*)'")]
        public void WhenIngresarElInteresTotal(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Click en nota de crédito")]
        public void WhenClickEnNotaDeCredito()
        {
            throw new PendingStepException();
        }

        [When(@"Seleccionar el tipo de nota de crédito '([^']*)'")]
        public void WhenSeleccionarElTipoDeNotaDeCredito(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Guardar nota de crédito")]
        public void WhenGuardarNotaDeCredito()
        {
            throw new PendingStepException();
        }

        [Then(@"Ver la nota de crédito emitida")]
        public void ThenVerLaNotaDeCreditoEmitida()
        {
            throw new PendingStepException();
        }

        [When(@"Ingresar el descuento global '([^']*)'")]
        public void WhenIngresarElDescuentoGlobal(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Ingresar el total de descuento '([^']*)'")]
        public void WhenIngresarElTotalDeDescuento(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Click en el botón invalidar")]
        public void WhenClickEnElBotonInvalidar()
        {
            throw new PendingStepException();
        }

        [When(@"Ingresar la observación '([^']*)'")]
        public void WhenIngresarLaObservacion(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Click en opción sí")]
        public void WhenClickEnOpcionSi()
        {
            throw new PendingStepException();
        }

        [Then(@"Ver venta invalidada")]
        public void ThenVerVentaInvalidada()
        {
            throw new PendingStepException();
        }

        [When(@"Click en el botón clonar")]
        public void WhenClickEnElBotonClonar()
        {
            throw new PendingStepException();
        }

        [Then(@"Guardar Venta")]
        public void ThenGuardarVenta()
        {
            throw new PendingStepException();
        }

        [Then(@"Click en el botón imprimir")]
        public void ThenClickEnElBotonImprimir()
        {
            throw new PendingStepException();
        }

        [Then(@"Click en el botón descargar")]
        public void ThenClickEnElBotonDescargar()
        {
            throw new PendingStepException();
        }

        [When(@"Click en el botón enviar")]
        public void WhenClickEnElBotonEnviar()
        {
            throw new PendingStepException();
        }

        [When(@"Ingresar correo '([^']*)'")]
        public void WhenIngresarCorreo(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Click en el botón agregar correo")]
        public void WhenClickEnElBotonAgregarCorreo()
        {
            throw new PendingStepException();
        }

        [Then(@"Enviar documento de venta")]
        public void ThenEnviarDocumentoDeVenta()
        {
            throw new PendingStepException();
        }
    }
}
