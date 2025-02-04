using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.ComponentModel;


namespace RESTAURANTE.Hoks.Pages.Facturacion
{
    public class FacturacionSimplePage
    {
        private IWebDriver driver;
        UtilityPage utilityPage;
        FacturacionPage facturacionPage;

        public FacturacionSimplePage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilityPage = new UtilityPage(driver);
            this.facturacionPage = new FacturacionPage(driver);

        }

        private By overlayLocator = By.ClassName("block-ui-overlay");

        private By fieldLocator;
        private By _modalFacturacion = By.Id("facturacionVenta-0");

        private By clienteField = By.XPath("//input[@id='DocumentoIdentidad']");
        private By aliasField = By.XPath("//input[@ng-model='$ctrl.facturacion.Orden.Cliente.Alias']");

        //OBSERVACION
        private By observacionField = By.Id("observacion");

        // COMPROBANTE
        //By docField = By.XPath("//select[@name='TipoComprobante']");
        By SelecOptions = By.CssSelector(".select2-results__options");
        //By docField = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]");
        //By docField = By.XPath("//span[@id='select2-TipoComprobante-fl-container']");

        //By docField = By.XPath("/html[1]/body[1]/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");


        //By docField = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");

        By docField = By.Id("select2-TipoComprobante-az-container");

        //By docField = By.XPath("//select[@name='TipoComprobante']");

        //By docField = By.ClassName("select2-selection--single");


        // COMPROBANTE
        By comprobanteField = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");

        // MODO DE PAGO
        By dpcuButton = By.XPath("//label[@id='labelMedioPago-0-14']");
        By tranfonButton = By.XPath("//label[@id='labelMedioPago-0-16']");
        By tdebButton = By.XPath("//label[@id='labelMedioPago-0-18']");
        By tcreButton = By.XPath("//label[@id='labelMedioPago-0-19']");
        By efButton = By.XPath("//label[@id='labelMedioPago-0-281']");

        // DEPCU
        By _bankAccountDEPCU = By.XPath("");
        By _infoDEPCU = By.XPath("");

        // TRANFON
        By _bankAccountTRANFON = By.XPath("");
        By _infoTRANFON = By.XPath("");

        // TDEB
        By _bankTDEB = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[7]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[1]/span[1]/span[1]");
        By _cardTDEB = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[7]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[2]/span[1]/span[1]");
        By _infoTDEB = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[7]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/textarea[1]");

        // TCRED
        By _bankTCRED = By.XPath("");
        By _cardTCRED = By.XPath("");
        By _infoTCRED = By.XPath("");

        //  EF
        By _observation = By.XPath("");

        // BOTON FACTURAR
        By facturar = By.XPath("//button[contains(text(),'FACTURAR')]");

        public IWebElement inicioModal()
        {
            // Encontrar el modal FACTURACION
            IWebElement modalFacturacion = driver.FindElement(_modalFacturacion);
            return modalFacturacion;
        }


        // EXTRAE EL MODO DE PAGO SELECCIONADO
        public string VerModoPago()
        {
            // Encuentra el contenedor con los botones de radio
            var medioPagoContainer = driver.FindElement(By.Id("medioPago0"));

            // Encuentra todos los botones de radio dentro del contenedor
            var radioButtons = medioPagoContainer.FindElements(By.CssSelector("input[type='radio']"));

            // Itera por cada botón de radio para verificar cuál está seleccionado
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Selected) // Verifica si el botón está seleccionado
                {
                    // Encuentra el label asociado al botón de radio seleccionado
                    var label = driver.FindElement(By.CssSelector($"label[for='{radioButton.GetAttribute("id")}']"));

                    // Retorna el texto del label (DEPCU, TRANFON, etc.)
                    return label.Text;
                }
            }
            return string.Empty;// Si no se selecciona nada, retorna una cadena vacía o lanza una excepción si es necesario
        }


        public void AddClient(string _clientType, string _clientValue)
        {
            // ESPERA PARA RELLENAR CAMPOS
            utilityPage.elementExists(clienteField);
            utilityPage.WaitForOverlayToDisappear(overlayLocator);

            // Encontrar el modal FACTURACION
            IWebElement modalFacturacion = driver.FindElement(By.Id("facturacionVenta-0"));

            // TIPO CLIENTE
            switch (_clientType)
            {
                case "VARIOS":
                    // No se hace nada
                    return;

                case "DNI":
                case "RUC":
                    // Si es DNI o RUC, se utiliza enterFieldModal
                    fieldLocator = clienteField;
                    utilityPage.enterFieldModal(modalFacturacion, fieldLocator, _clientValue);
                    break;

                case "ALIAS":
                    // Si es ALIAS, se utiliza addFieldModal
                    fieldLocator = aliasField;
                    utilityPage.addFieldModal(modalFacturacion, fieldLocator, _clientValue);
                    break;

                default:
                    throw new ArgumentException($"El {_clientType} no es válido");
            }

            Console.WriteLine("CLIENTE INGRESADO");
            Thread.Sleep(4000);

        }

        // TIPO COMPROBANTE DE PAGO
        public void typeComprobante(string _comprobante)
        {
            By comprobanteField1 = By.XPath("//span[contains(@class,'select2-selection__rendered')]");
            // ESPERA
            utilityPage.elementExists(comprobanteField1);
            utilityPage.WaitForOverlayToDisappear(overlayLocator);
            Console.WriteLine("Campo seleccion encontrada");

            // Encontrar el modal FACTURACION
            IWebElement modalFacturacion = driver.FindElement(By.Id("facturacionVenta-0"));

            utilityPage.SelecOption(modalFacturacion, comprobanteField1, _comprobante);
            Console.WriteLine("Seleccion realizada");
            Thread.Sleep(4000);



            /*
            By comprobante1 = By.XPath("//span[contains(@class,'select2-selection__rendered')]");
            // By comprobante1 = By.Name("TipoComprobante");

            string option = "FACTURA ELECTRONICA";

            // Encontrar el modal COMPROBANTE
            IWebElement modalComprobante = driver.FindElement(By.Id("SelectorComprobanteFacturacion"));
            Console.WriteLine("Modal COMPROBANTE");

            utilityPage.elementExists(comprobante1);
            Console.WriteLine("BOTÓN EXISTENTE");
            utilityPage.VisibilidadElement(comprobante1);
            Console.WriteLine("BOTÓN VISIBLE");

            modalComprobante.FindElement(comprobante1).Click();
            Console.WriteLine("CLICK MENU");

            // Abre el menú desplegable
            IWebElement dropdown = modalComprobante.FindElement(comprobante1);
            dropdown.Click();

            // Espera explícita para que las opciones sean visibles
            utilityPage.VisibilidadElement(SelecOptions);
            Console.WriteLine("MENU DESGLOSADO");

            // Selecciona la opción deseada
            IWebElement optionElement = modalComprobante.FindElement(By.XPath($"//li[contains(text(), '{option}')]"));
            optionElement.Click();
            Thread.Sleep(4000);
            */
        }

        public void AddObservacion(string _observacion)
        {
            // ESPERA PARA RELLENAR CAMPOS
            utilityPage.elementExists(observacionField);
            utilityPage.WaitForOverlayToDisappear(overlayLocator);

            // Encontrar el modal FACTURACION
            IWebElement modalFacturacion = driver.FindElement(By.Id("facturacionVenta-0"));

            utilityPage.addFieldModal(modalFacturacion, observacionField, _observacion);
            Console.WriteLine("OBSERVACION AGREGADA");
            Thread.Sleep(4000);

        }

        // MODO DE PAGO
        public void moodPay(string _moodPago)
        {
            // Diccionario que mapea el modo de pago al botón correspondiente
            var moodPagoButtons = new Dictionary<string, By>
            {
                { "DEPCU", dpcuButton },
                { "TRANFON", tranfonButton },
                { "TDEB", tdebButton },
                { "TCRE", tcreButton },
                { "EF", efButton }
            };

            // Verificar si el modo de pago existe en el diccionario
            if (moodPagoButtons.ContainsKey(_moodPago))
            {
                // Llamar al método moodPay con el botón correspondiente
                facturacionPage.moodPay(moodPagoButtons[_moodPago]);
            }
            else
            {
                // Lanzar excepción si el modo de pago no es válido
                throw new ArgumentException($"El {_moodPago} no es válido");
            }

            Thread.Sleep(4000);
        }

        // DATOS DE PAGO BANCO - 2 CAMPOS
        public void PaymentBank(string _cuentaBancaria, string _info)
        {
            string modoPagoSeleccionado = VerModoPago();

            IWebElement modalFacturacion = inicioModal();

            switch (modoPagoSeleccionado)
            {
                case "DEPCU":

                    // Llenar los datos bancarios del formulario de facturación
                    facturacionPage.DatosBanco(modalFacturacion, _bankAccountDEPCU, _cuentaBancaria, _infoDEPCU, _info);
                    Thread.Sleep(4000);
                    break;

                case "TRANFON":
                    facturacionPage.datosBanco(_bankAccountTRANFON, _cuentaBancaria, _infoDEPCU, _info);
                    break;
                default:
                    throw new ArgumentException($"El modo de pago {modoPagoSeleccionado} no es válido.");
            }
            Thread.Sleep(4000);
        }

        // DATOS DE PAGO TARJETA - 3 CAMPOS
        public void PaymentCard(string _bank, string _card, string _info)
        {
            string modoPagoSeleccionado = VerModoPago();
            switch (modoPagoSeleccionado)
            {
                case "TDEB":
                    facturacionPage.datosCard(_bankTDEB, _bank, _cardTDEB, _card, _infoTDEB, _info);
                    break;
                    
                case "TCRE":
                    facturacionPage.datosCard(_bankTCRED, _bank, _cardTCRED, _card, _infoTCRED, _info);
                    break;
                default:
                    throw new ArgumentException($"El modo de pago {modoPagoSeleccionado} no es válido.");
            }
            Thread.Sleep(4000);
        }

        public void Facturar()
        {
            utilityPage.buttonClickeable(facturar);
            //ClickButton(saveSaleButton); // GUARDAR VENTA
            Thread.Sleep(4000);
        }
    }
}
