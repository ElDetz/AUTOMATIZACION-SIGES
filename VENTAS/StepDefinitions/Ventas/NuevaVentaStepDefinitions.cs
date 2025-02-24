using OpenQA.Selenium;
using System;
using SigesCore.Hooks.LoginPage;
using SigesCore.Hooks.VentasPage;
using System.Net;
using static SigesCore.Hooks.VentasPage.NuevaVentaPage;

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

        [When(@"Agregar los siguientes conceptos:")]
        public void WhenAgregarLosSiguientesConceptos(Table table)
        {
            foreach (var row in table.Rows)
            {
                string option = row["option"];
                string value = row["value"];

                newSale.TypeSelectConcept(option, value);
                Thread.Sleep(1000);
            }
        }

        /*[When(@"Ingresa los siguientes datos del producto:")]
        public void IngresarDatosDelProducto(Table table)
        {
            string quantity = null;
            string unitPrice = null;

            foreach (var row in table.Rows)
            {
                if (row["Campo"] == "Cantidad")
                    quantity = row["Valor"];

                if (row["Campo"] == "Precio Unitario")
                    unitPrice = row["Valor"];
            }

            if (!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(unitPrice))
            {
                newSale.QuantityAndUnitPrice(quantity, unitPrice);
            }
        }*/

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

        //STEP PROPIO DE VENTA MODO CAJA
        [When(@"Seleccionar un punto de venta '([^']*)'")]
        public void WhenSeleccionarUnPuntoDeVenta(string option)
        {
            newSale.PointSale(option);
        }

        //STEP PROPIO DE VENTA MODO CAJA
        [When(@"Seleccionar un vendedor '([^']*)'")]
        public void WhenSeleccionarUnVendedor(string option)
        {
            newSale.Seller(option);
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

        [When(@"Click en el botón Guía")]
        public void WhenClickEnElBotonGuia()
        {
            newSale.ClickDispatchGuide();
        }

        [When(@"Ingresar la fecha de inicio de traslado '([^']*)'")]
        public void WhenIngresarLaFechaDeInicioDeTraslado(string value)
        {
            newSale.StartDateTransfer(value); 
        }

        [When(@"Ingresar el peso bruto total '([^']*)'")]
        public void WhenIngresarElPesoBrutoTotal(string value)
        {
            newSale.TotalGrossWeight(value);
        }

        [When(@"Ingresar el número de bultos '([^']*)'")]
        public void WhenIngresarElNumeroDeBultos(string value)
        {
            newSale.NumberOfPackages(value);
        }

        [When(@"Ingresar el RUC del transportista '([^']*)'")]
        public void WhenIngresarElRUCDelTransportista(string value)
        {
            newSale.CarrierRUC(value);
        }

        [When(@"Seleccionar la modalidad del transporte ""([^""]*)""")]
        public void WhenSeleccionarLaModalidadDelTransporte(string option)
        {
            newSale.TransportMode(option);
        }

        //STEP PROPIO DE GUÍA DE REMISIÓN POR TRANSPORTE PRIVADO
        [When(@"Ingresar el DNI del conductor '([^']*)'")]
        public void WhenIngresarElDNIDelConductor(string value)
        {
            newSale.DriverDNI(value);   
        }

        //STEP PROPIO DE GUÍA DE REMISIÓN POR TRANSPORTE PRIVADO
        [When(@"Ingresar la licencia del conductor '([^']*)'")]
        public void WhenIngresarLaLicenciaDelConductor(string value)
        {
            newSale.DriverLicense(value);
        }

        //STEP PROPIO DE GUÍA DE REMISIÓN POR TRANSPORTE PRIVADO
        [When(@"Ingresar la placa del vehículo '([^']*)'")]
        public void WhenIngresarLaPlacaDelVehiculo(string value)
        {
            newSale.VehiclePlate(value);    
        }

        [When(@"Ingresar el ubigeo de la dirección de origen ""([^""]*)""")]
        public void WhenIngresarElUbigeoDeLaDireccionDeOrigen(string option)
        {
            newSale.OriginAddressUbigeo(option);
        }

        [When(@"Ingresar el detalle de la dirección de origen ""([^""]*)""")]
        public void WhenIngresarElDetalleDeLaDireccionDeOrigen(string option)
        {
            newSale.OriginAddressDetail(option);
        }

        [When(@"Ingresar el ubigeo de la dirección de destino ""([^""]*)""")]
        public void WhenIngresarElUbigeoDeLaDireccionDeDestino(string option)
        {
            newSale.DestinationAddressUbigeo(option);
        }

        [When(@"Ingresar el detalle de la dirección de destino ""([^""]*)""")]
        public void WhenIngresarElDetalleDeLaDireccionDeDestino(string option)
        {
            newSale.DestinationAddressDetail(option);
        }

        [When(@"Click en el botón aceptar guía de remisión")]
        public void WhenClickEnElBotonAceptarGuiaDeRemision()
        {
            newSale.AcceptDispatchGuideButton();
        }

        /*[When("Seleccionar tipo de entrega {string}")]
        public void WhenSeleccionarTipoDeEntrega(string option)
        {
            newSale.SelectDeliveryType(option);
        }*/

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
            newSale.Accept();
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

        [When("Ingresa los siguientes datos del producto:")]
        public void IngresarDatosDelProducto(Table table)
        {
            string quantity = null;
            string unitPrice = null;

            foreach (var row in table.Rows)
            {
                if (row["Campo"] == "Cantidad")
                    quantity = row["Valor"];

                if (row["Campo"] == "Precio Unitario")
                    unitPrice = row["Valor"];
            }

            if (!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(unitPrice))
            {
                newSale.QuantityAndUnitPrice(quantity, unitPrice);
            }
        }

        [When("Seleccionar tipo de entrega {string}")]
        public void WhenSeleccionarTipoDeEntrega(string option)
        {
            newSale.SelectDeliveryType(option);
        }

        [When("Hola {string}")]
        public void WhenHola(string p0)
        {
            throw new PendingStepException();
        }

    }
}
