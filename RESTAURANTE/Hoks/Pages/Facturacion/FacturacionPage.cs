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
        UtilityPage utilityPage;
        WebDriverWait wait;

        public FacturacionPage(IWebDriver driver, int timeoutInSeconds = 10)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), "El WebDriver no puede ser null.");
            }
            this.driver = driver;
            this.utilityPage = new UtilityPage(driver);
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        /*
        private IWebDriver driver;
        UtilityPage utilityPage;

        public FacturacionPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilityPage = new UtilityPage(driver);
        }*/

        private By overlayLocator = By.ClassName("block-ui-overlay");

        private By facturarAtencionButton = By.XPath("//tbody/tr[1]/td[9]/a[1]/span[1]");
        //private By facturarAtencionButton = By.CssSelector("a.btn.btn-success.btn-sm[ng-click='iniciarFacturacion(item)']");

        // TIPO DE FACTURACION
        private By _buttonSimple = By.Id("inlineRadio1");
        private By _buttonCtaDividida = By.Id("inlineRadio2");
        private By _buttonDiferenciado = By.Id("inlineRadio3");

        // MODAL FACTURACION
        private By _modal = By.Id("modal-facturador-restaurante");
        private By _modalFacturacion1 = By.Id("modal-facturador-restaurante");

        private By clienteField = By.XPath("//input[@id='DocumentoIdentidad']");

        // TIPO COMPROBANTE
        // private By _comprobante = By.XPath("//span[@id='select2-TipoComprobante-1b-container']");
        //private By _comprobante = By.Id("select2-TipoComprobante-8d-container"); 

        // private By _comprobante = By.Id("select2-TipoComprobante-8d-results");
        // private By _comprobante = By.XPath("//ul[contains(@class, 'select2-results')]");

         // private By _comprobante = By.CssSelector("#select2-TipoComprobante-8d-container");

        // private By _comprobante = By.XPath("/html[1]/body[1]/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]/span[1]");

        // private By _comprobante = By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");

        private By _comprobante = By.XPath("//li[contains(text(), 'FACTURA ELECTRONICA')]");

        // DATOS 



        // BOTON FACTURAR
        private By _buttonFacturar = By.XPath("//button[contains(text(),'FACTURAR')]");


        private By SelecOptions = By.CssSelector(".select2-results__options");

        private By clienteField1 = By.XPath("//input[@id='DocumentoIdentidad']");


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

        public void typeFactura(string _typeFactura) 
        {
            // BOTON FACTURAR - ELECCION DEL PRIMERO
            utilityPage.elementExists(facturarAtencionButton);
            utilityPage.WaitForOverlayToDisappear(overlayLocator);
            utilityPage.buttonClickeable(facturarAtencionButton);

            /*
            // Espera a que la ventana modal esté visible
            var modal = utilityPage.WaitForModal("modal-facturador-restaurante");
            Assert.IsTrue(modal.Displayed, "El modal no se muestra correctamente.");
            */

            //SwitchToModal(driver);

            // Encontrar el modal
            IWebElement modalContainer = driver.FindElement(_modal);
            Console.WriteLine("Modal container encontrado.");
            
            // ESPERA
            utilityPage.elementExists(clienteField1);
            utilityPage.WaitForOverlayToDisappear(overlayLocator);

            //SELECCION
            By buttonLocator;
            switch (_typeFactura)
            {
                case "SIMPLE":
                    buttonLocator = _buttonSimple;
                    break;
                case "CUENTA DIVIDIDA":
                    buttonLocator = _buttonCtaDividida;
                    break;
                case "DIFERENCIADO":
                    buttonLocator = _buttonDiferenciado;
                    break;
                default:
                    throw new ArgumentException($"Tipo de facturacion {_typeFactura} no válido: ");
            }

            /*
            // CLICK EN LA SELECCION
            modalContainer.FindElement(buttonLocator).Click();
            Console.WriteLine("Boton encontrado");
            buttonSeleccion.Click();
            */

            modalContainer.FindElement(buttonLocator).Click();
            Console.WriteLine($"LA SELECCION {_typeFactura} SE encontró.");

            /*
            List<IWebElement> iframes = driver.FindElements(By.TagName("iframe")).ToList();
            driver.SwitchTo().Frame(iframes[0]);  // Prueba con el primer iframe
            Console.WriteLine("CAMBIANDO IFRAME");
            */
            
            /*
            // Intentar cerrar cualquier modal o elemento que bloquee
            IWebElement modal = driver.FindElement(By.ClassName("modal-open"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.display='none';", modal);
            Console.WriteLine("Modal cerrado.");
            */
            /*
            // Esperar que el elemento sea clickeable
            IWebElement select2Container = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(@class,'select2-selection__rendered')]")));

            Console.WriteLine("BOTÓN ENCONTRADO");

            // Usar JavaScript para forzar el clic
            select2Container.Click();
            //((IJavaScriptExecutor)modalComprobante).ExecuteScript("arguments[0].click();", select2Container);
            Console.WriteLine("MENU DESGLOSADO");
            */
            /*
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("TipoComprobante")));
            modalComprobante.FindElement(By.Name("TipoComprobante")).Click();
            


            */
            /*
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("TipoComprobante")));
            Console.WriteLine("BOTON ENCONTRADO");

           
            modalContainer.FindElement(By.Name("TipoComprobante")).Click();

            Console.WriteLine("MENU DESGLOSADO");
            */
            //modalContainer.FindElement(By.Name("TipoComprobante")).Click();
            //modalContainer.FindElement(By.Id("select2-TipoComprobante-ug-container")).Click();

            /*
          //utilityPage.elementExists(_comprobante);
          //utilityPage.WaitForOverlayToDisappear(overlayLocator);
          wait.Until(ExpectedConditions.ElementIsVisible(_comprobante));
          utilityPage.WaitForOverlayToDisappear(overlayLocator);
          Console.WriteLine("Boton comprobante visible");

          */

        }

        /*
        // TIPO COMPROBANTE DE PAGO
        public void typeComprobante(By _path, string _option)
        {
            utilityPage.SelecOption(_path, _option);
        }
        */

        // MODO DE PAGO
        public void moodPay(By _path)
        {
            if (driver.FindElements(_path).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_path} no se encontró.");
            }

            utilityPage.buttonClickeable(_path);
        }

        //MODO DE PAGO TARJETA TDEB TCRE
        public void datosBanco(IWebElement _modal, By _bankAccountDEPCU, string _cuentaBancaria, By _infoField, string _info)
        {
            
            utilityPage.SelecOption(_modal, _bankAccountDEPCU, _cuentaBancaria); // SELECCION BANCO

            utilityPage.addFieldModal(_modal, _infoField, _info);

        }

        //MODO DE PAGO TARJETA TDEB TCRE
        public void datosCard(IWebElement _modal, By _bankField, string _bank, By _cardField, string _card, By _infoField, string _info)
        {
            
            utilityPage.SelecOption(_modal, _bankField, _bank); // SELECCION BANCO
            utilityPage.SelecOption(_modal, _cardField, _card); // SELECCION TARJETA
            utilityPage.addFieldModal(_modal, _infoField, _info); ; // AGREGA INFO
            
        }


    }
}
