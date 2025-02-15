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
    public class PedidosStepDefinitions
    {
        private IWebDriver driver;
        LoginPage login;
        NuevaVentaPage newSale;
        VerVentasPage viewSale;
        PedidosPage orders;

        public PedidosStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            this.login = new LoginPage(driver);
            this.newSale = new NuevaVentaPage(driver);
            this.viewSale = new VerVentasPage(driver);
            this.orders = new PedidosPage(driver);
        }

        [When("Seleccionar Pedido")]
        public void WhenSeleccionarPedido()
        {
            orders.ClickOrder();
        }

        [When("Seleccionar ver pedido")]
        public void WhenSeleccionarVerPedido()
        {
            orders.ClickViewOrder();
        }

        [When("Click en nuevo pedido")]
        public void WhenClickEnNuevoPedido()
        {
            orders.ClickNewOrder();
        }

        [When("Agregar concepto {string}")]
        public void WhenAgregarConcepto(string value)
        {
            orders.Concept(value);
        }

        [When("Agregar documento {string}")]
        public void WhenAgregarDocumento(string value)
        {
            orders.Client(value);
        }

        [When("Seleccionar tipo de comprobante {string}")]
        public void WhenSeleccionarElComprobante(string option)
        {
            orders.SelectInvoiceType(option);
        }

        [When("Seleccionar el tipo de entrega {string}")]
        public void WhenSeleccionarElTipoDeEntrega(string option)
        {
            orders.SelectDeliveryType(option);
        }

        [When("Digitar fecha inicial {string}")]
        public void WhenDigitarFechaInicial(string value)
        {
            orders.InitialDate(value);
        }

        [When("Digitar fecha final {string}")]
        public void WhenDigitarFechaFinal(string value)
        {
            orders.FinalDate(value);
        }

        [When("Click en consultar pedidos")]
        public void WhenClickEnConsultarPedidos()
        {
            orders.OrderQuery();
        }

        [When("Click en confirmar pedido")]
        public void WhenClickEnConfirmarPedido()
        {
            orders.ConfirmOrder();
        }

        [When("Seleccionar comprobante {string}")]
        public void WhenSeleccionarComprobante(string value)
        {
            orders.InvoiceType(value);
        }

        [Then("Guardar pedido")]
        public void ThenGuardarPedido()
        {
            orders.SaveOrder();
        }
    }
}
