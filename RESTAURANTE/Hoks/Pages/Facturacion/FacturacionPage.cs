using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace RESTAURANTE.Hoks.Pages.Facturacion
{
    public class FacturacionPage
    {

        private IWebDriver driver;
        Utilities utilities;
        WebDriverWait wait;

        public FacturacionPage(IWebDriver driver, int timeoutInSeconds = 20)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), "El WebDriver no puede ser null.");
            }
            this.driver = driver;
            this.utilities = new Utilities(driver);
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        // OVERLAY
        private By overlayLocator = By.ClassName("block-ui-overlay");

        // BOTON FACTURAR
        private By facturarAtencionButton = By.XPath("//tbody/tr[1]/td[9]/a[1]/span[1]");

        // TIPO DE FACTURACION
        private By _buttonSimple = By.Id("inlineRadio1");
        private By _buttonCtaDividida = By.Id("inlineRadio2");
        private By _buttonDiferenciado = By.Id("inlineRadio3");
        private By _buttonLocator;

        // MODAL - REGISTRAR FACTURACION
        private By docIdentidadField = By.XPath("//input[@id='DocumentoIdentidad']");
        private By _modal = By.Id("modal-facturador-restaurante");

        private By SelecOptions = By.CssSelector(".select2-results__options");

        // BOTON FACTURAR
        By _buttonFacturar = By.XPath("//button[contains(text(),'FACTURAR')]");


        public void SwitchToModal(IWebDriver driver)
        {
            // Almacena el identificador de la ventana principal
            string parentWindowHandler = driver.CurrentWindowHandle;

            // Obtén todos los identificadores de ventanas abiertas
            var handles = driver.WindowHandles;

            // Cambia a la ventana que no sea la principal
            foreach (string handle in handles)
            {
                if (handle != parentWindowHandler)
                {
                    driver.SwitchTo().Window(handle);
                    break;
                }
            }

            // Aquí puedes interactuar con el contenido del modal
            // Por ejemplo, rellenar un campo de texto:
            //driver.FindElement(By.Id("tuCampoID")).SendKeys("Información del modal");

            // Si necesitas volver a la ventana principal:
            //driver.SwitchTo().Window(parentWindowHandler);
        }

        public void typeInvoice(string _typeFactura) 
        {
            // BOTON FACTURAR - ELECCION DEL PRIMERO
            utilities.elementExists(facturarAtencionButton);
            utilities.WaitForOverlayToDisappear(overlayLocator);
            utilities.buttonClickeable(facturarAtencionButton);

            // ENCUENTRA MODAL FACTURACION RESTAURANTE
            IWebElement modalRestaurante = driver.FindElement(_modal);
            Console.WriteLine("MODAL FACTURACION RESTAURANTE ENCONTRADO");

            // ESPERA Y OVERLAY
            utilities.elementExists(docIdentidadField);
            utilities.WaitForOverlayToDisappear(overlayLocator);

            switch (_typeFactura)
            {
                case "SIMPLE":
                    _buttonLocator = _buttonSimple;
                    break;
                case "CUENTA DIVIDIDA":
                    _buttonLocator = _buttonCtaDividida;
                    break;
                case "DIFERENCIADO":
                    _buttonLocator = _buttonDiferenciado;
                    break;
                default:
                    throw new ArgumentException($"Tipo de facturacion {_typeFactura} no válido");
            }

            utilities.ClickButtonInModal(modalRestaurante, _buttonLocator);
            Console.WriteLine($"TIPO DE FACTURACION {_typeFactura} SELECCIONADO");

            // ESPERA PARA RELLENAR CAMPOS
            utilities.elementExists(docIdentidadField);
            utilities.WaitForOverlayToDisappear(overlayLocator);
            /*
            List<IWebElement> iframes = driver.FindElements(By.TagName("iframe")).ToList();
            driver.SwitchTo().Frame(iframes[0]);  // Prueba con el primer iframe
            Console.WriteLine("CAMBIANDO IFRAME");
            */
        }

        /*
        // MODO DE PAGO
        public void moodPay(IWebElement _modal, By _path)
        {
            if (driver.FindElements(_path).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_path} no se encontró.");
            }

            utilities.ClickButtonInModal(_path);
        }
        */

        //MODO DE PAGO TARJETA TDEB TCRE
        public void datosBanco(IWebElement _modal, By _bankAccountDEPCU, string _cuentaBancaria, By _infoField, string _info)
        {

            // utilityPage.SelecOption(_modal, _bankAccountDEPCU, _cuentaBancaria); // SELECCION BANCO

            utilities.addFieldModal(_modal, _infoField, _info);

        }

        //MODO DE PAGO TARJETA TDEB TCRE
        public void datosCard(IWebElement _modal, By _bankField, string _bank, By _cardField, string _card, By _infoField, string _info)
        {

            // utilityPage.SelecOption(_modal, _bankField, _bank); // SELECCION BANCO
            // utilityPage.SelecOption(_modal, _cardField, _card); // SELECCION TARJETA
            utilities.addFieldModal(_modal, _infoField, _info); ; // AGREGA INFO
            
        }

        public void realizarFacturaracion()
        {
            utilities.buttonClickeable(_buttonFacturar); //  CLIC EN FACTURAR
            Thread.Sleep(4000);
        }

    }
}
