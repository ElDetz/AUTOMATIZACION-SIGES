using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


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


        private By clienteField = By.XPath("//input[@id='DocumentoIdentidad']");
        private By aliasField = By.XPath("//input[@ng-model='$ctrl.facturacion.Orden.Cliente.Alias']");

        // COMPROBANTE
        //By docField = By.XPath("//select[@name='TipoComprobante']");
        By SelecOptions = By.CssSelector(".select2-results__options");
        //By docField = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]");
        //By docField = By.XPath("//span[@id='select2-TipoComprobante-fl-container']");
        
        //By docField = By.XPath("/html[1]/body[1]/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");


        By docField = By.XPath("/html[1]/body[1]/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");

        // TDEB
        By bankFieldTdeb = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[1]/span[1]/span[1]");

        // MODO DE PAGO
        By dpcuButton = By.XPath("//label[@id='labelMedioPago-0-14']");
        By tranfonButton = By.XPath("//label[@id='labelMedioPago-0-16']");
        By tdebButton = By.XPath("//label[@id='labelMedioPago-0-18']");
        By tcreButton = By.XPath("//label[@id='labelMedioPago-0-19']");
        By efButton = By.XPath("//label[@id='labelMedioPago-0-281']");

        // TDEB
        By _bankTdeb = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[7]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[1]/span[1]/span[1]");
        By _cardTdeb = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[7]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[2]/span[1]/span[1]");
        By _infoTdeb = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[7]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/textarea[1]");

        // TCRED
        By _bankTcred = By.XPath("");
        By _cardTcred = By.XPath("");
        By _infoTcred = By.XPath("");




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


        public void invoiceData(string _clientType, string _clientValue)
        {
            // ESPERA PARA RELLENAR CAMPOS
            utilityPage.elementExists(clienteField);
            utilityPage.WaitForOverlayToDisappear(overlayLocator);

            // TIPO CLIENTE
            switch (_clientType)
            {
                case "VARIOS":

                    //CAMPO CLIENTE VACIO
                    break;

                case "DNI":

                    utilityPage.enterField(clienteField, _clientValue);
                    break;

                case "RUC":

                    utilityPage.enterField(clienteField, _clientValue);
                    break;

                case "ALIAS":

                    utilityPage.enterField(aliasField, _clientValue);
                    break;

                default:
                    throw new ArgumentException($"El {_clientType} no es válido");
            }

        }

        // TIPO COMPROBANTE DE PAGO
        public void typeComprobante(string _typeComprobante)
        {
            utilityPage.buttonClickeable(docField);
            Thread.Sleep(4000);
            //facturacionPage.typeComprobante(docField, _typeComprobante);
            //Thread.Sleep(4000);
        }

        // MODO DE PAGO
        public void moodPay(string _moodPago)
        {
            switch (_moodPago)
            {
                case "DEPCU":

                    facturacionPage.moodPay(dpcuButton, _moodPago);
                    break;

                case "TRANFON":

                    facturacionPage.moodPay(tranfonButton, _moodPago);
                    break;

                case "TDEB":

                    facturacionPage.moodPay(tdebButton, _moodPago);

                    break;

                case "TCRE":

                    facturacionPage.moodPay(tcreButton, _moodPago);

                    break;

                case "EF":

                    facturacionPage.moodPay(efButton, _moodPago);

                    break;

                default:
                    throw new ArgumentException($"El {_moodPago} no es válido");
            }

            Thread.Sleep(4000);
        }

        // DATOS DE PAGO TARJETA
        public void PaymentCard(string _bank, string _card, string _info)
        {
            string modoPagoSeleccionado = VerModoPago();
            switch (modoPagoSeleccionado)
            {
                case "TDEB":
                    facturacionPage.datosCard(_bankTdeb, _bank, _cardTdeb, _card, _infoTdeb, _info);
                    Thread.Sleep(4000);
                    break;

                case "TCRE":
                    facturacionPage.datosCard(_bankTcred, _bank, _cardTcred, _card, _infoTcred, _info);
                    Thread.Sleep(4000);
                    Thread.Sleep(4000);
                    break;
                default:
                    throw new ArgumentException($"El modo de pago {modoPagoSeleccionado} no es válido.");
            }
            Thread.Sleep(4000);
        }

    }
}
