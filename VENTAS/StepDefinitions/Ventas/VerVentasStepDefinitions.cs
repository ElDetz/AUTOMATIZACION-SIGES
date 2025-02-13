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
        VerVentasPage viewSale;

        public VerVentasStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.login = new LoginPage(driver);
            this.newSale = new NuevaVentaPage(driver);
            this.viewSale = new VerVentasPage(driver);
        }

        [When(@"Ingresar fecha inicial ""([^""]*)""")]
        public void WhenIngresarFechaInicial(string value)
        {
            viewSale.SetInitialDate(value);
        }

        [When(@"Ingresar fecha final ""([^""]*)""")]
        public void WhenIngresarFechaFinal(string value)
        {
            viewSale.SetFinalDate(value);   
        }

        [When(@"Click en consultar ventas")]
        public void WhenClickEnConsultarVentas()
        {
            viewSale.SetSalesQuery();
        }

        [When(@"Buscar venta '([^']*)'")]
        public void WhenBuscarVenta(string value)
        {
            viewSale.SearchSaleField(value);    
        }

        [When(@"Activar canje")]
        public void WhenActivarCanje()
        {
            viewSale.ActivateRedeem();
        }

        [When(@"Seleccionar venta")]
        public void WhenSeleccionarVenta()
        {
            viewSale.SelectSale();
        }

        [When(@"Click en el botón canjear")]
        public void WhenClickEnElBotonCanjear()
        {
            viewSale.ClickRedeemButton();
        }

        [When(@"Seleccionar el tipo de comprobante ""([^""]*)""")]
        public void WhenSeleccionarElTipoDeComprobante(string option)
        {
            viewSale.SetVoucherType(option);
        }

        [When(@"Click en el botón aceptar")]
        public void WhenClickEnElBotonAceptar()
        {
            viewSale.ClickAcceptRedeemButton();
        }

        [Then(@"Ver comprobante canjeada '([^']*)'")]
        public void ThenVerVentaCanjeada(string value)
        {
            viewSale.SetRedeemedVoucher(value);
        }

        [When("Ver venta buscada")]
        public void WhenVerVentaBuscada()
        {
            viewSale.SeeSale();
        }

        [When("Elegir tipo de nota {string}")]
        public void WhenElegirTipoDeNota(string option)
        {
            viewSale.ClickTypeNote(option);
        }

        [When("Seleccionar el tipo de nota {string}")]
        public void WhenSeleccionarElTipoDeNotaDeDebito(string option)
        {
            viewSale.TypeDebitNote(option);
        }

        [When("Seleccionar el documento {string}")]
        public void WhenSeleccionarElDocumento(string option)
        {
            viewSale.DocumentType(option);
        }

        [When("Escribir el motivo de la nota {string}")]
        public void WhenEscribirElMotivoDeLaNota(string value)
        {
            viewSale.ReasonDebitNote(value);
        }

        [When(@"Ingresar el interés total '([^']*)'")]
        public void WhenIngresarElInteresTotal(string value)
        {
            viewSale.noteAmount(value);
        }

        [When(@"Ingresar el aumento de valor de la nota '([^']*)'")]
        public void WhenIngresarElAumentoDeValorDeLaNota(string value)
        {
            viewSale.TotalAmount(value);
        }

        [When(@"Guardar nota")]
        public void WhenGuardarNotaDeDebito()
        {
            viewSale.SaveNote();
        }

        [Then("Ver la nota emitida {string}")]
        public void ThenVerLaNotaDeDebitoEmitida(string value)
        {
            viewSale.SearchSaleField(value);
        }

        [When(@"Ingresar el descuento global '([^']*)'")]
        public void WhenIngresarElDescuentoGlobal(string value)
        {
            viewSale.noteAmount(value);
        }

        [When(@"Ingresar el total de descuento '([^']*)'")]
        public void WhenIngresarElTotalDeDescuento(string value)
        {
            viewSale.TotalAmount(value);
        }

        [When("Ingresar la cantidad {string}")]
        public void WhenIngresarLaCantidad(string value)
        {
            viewSale.quantityCreditNote(value);
        }

        [Then("Ver la nota emitida")]
        public void ThenVerLaNotaEmitida()
        {
            viewSale.SeeSale();
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
