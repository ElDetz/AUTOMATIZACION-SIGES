using FluentAssertions.Equivalency;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SigesCore.Hooks.Utility;
using SigesCore.Hooks.XPaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SigesCore.Hooks.VentasPage
{
    public class NuevaVentaPage
    {
        private readonly IWebDriver driver;
        WebDriverWait wait;
        UtilityPage utilityPage;

        public NuevaVentaPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilityPage = new UtilityPage(driver);
        }
        //By SelecOptions = By.CssSelector("select2-results__options");

        private By aliasField = By.ClassName("//input[@ng-model='$ctrl.facturacion.Orden.Cliente.Alias']");

        private By buscarCliente = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[1]/a[3]");

        private By overlayLocator = By.ClassName("block-ui-overlay");

        private By clientField = By.ClassName("//input[@id='DocumentoIdentidad']");

        By codeBarraField = By.XPath("//input[@id='idCodigoBarra']");

        By dniField = By.XPath("//input[@id='DocumentoIdentidad']");

        By checkboxIGV = By.XPath("//input[@id='ventaigv0']");

        By checkboxDetUnif = By.XPath("//input[@id='detalleunificado0']");

        By pathFamily = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/registrador-detalles[1]/div[1]/div[1]/selector-concepto-comercial[1]/ng-form[1]/div[1]/div[5]/div[1]/span[1]/span[1]/span[1]");
        By pathInputFieldFamily = By.XPath("//input[@class='select2-search__field']");

        By pathConcept = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/registrador-detalles[1]/div[1]/div[1]/selector-concepto-comercial[1]/ng-form[1]/div[1]/div[5]/div[2]/span[1]/span[1]/span[1]");
        By Quantity = By.XPath("/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/registrador-detalles[1]/div[1]/div[2]/table[1]/tbody[1]/tr[1]/td[6]/input[1]");

        By pathDoc = By.XPath("/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]/span[1]");

        By pathInputDoc = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[2]/span[1]/span[1]/input[1]");

        By SelectOptionsXPath = By.CssSelector(".select2-results__options");

        //METODO 1

        // TDEB
        By bankFieldTdeb = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[1]/span[1]/span[1]");

        By cardFieldTdeb = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[2]/span[1]/span[1]");

        By infoMethod1FieldTdeb = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/textarea[1]");

        // TCRED
        By bankFieldTcred = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[5]/div[1]/span[1]/span[1]/span[1]");

        By cardFieldTcred = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[5]/div[1]/span[2]/span[1]/span[1]");

        By infoMethod1FieldTcred = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[5]/div[1]/textarea[1]");

        public void enterModulo(string _modulo)
        {
            // Clic en "Restaurante"
            utilityPage.buttonClickeable(ModuloVenta.VentasField);

            switch (_modulo)
            {
                case "Nueva Venta":

                    utilityPage.buttonClickeable(ModuloVenta.NuevaVentaField);
                    break;

                case "Venta Modo Caja":

                    utilityPage.buttonClickeable(ModuloVenta.VentaModoCajaField);
                    break;

                case "Venta Por Contingencia":

                    utilityPage.buttonClickeable(ModuloVenta.VentaContingenciaField);
                    break;

                case "Ver Ventas":

                    utilityPage.buttonClickeable(ModuloVenta.VerVentasField);
                    break;

                case "Reportes Vendedor":

                    utilityPage.buttonClickeable(ModuloVenta.ReportesVendedorField);
                    break;

                case "Reportes Puntos":

                    utilityPage.buttonClickeable(ModuloVenta.ReportesPuntosField);
                    break;

                case "Reportes Gerente":

                    utilityPage.buttonClickeable(ModuloVenta.ReportesGerenteField);
                    break;

                case "Reportes":

                    utilityPage.buttonClickeable(ModuloVenta.ReportesField);
                    break;

                default:
                    throw new ArgumentException($"El {_modulo} no es válido.");
            }
        }
        public void barCodeConcept(string codeBarra)
        {
            utilityPage.elementExists(codeBarraField);
            utilityPage.WaitForElementVisible(overlayLocator);
            utilityPage.enterField2(codeBarraField, codeBarra);
            Thread.Sleep(4000);
        }

        /*public void CheckIGV()
        {
            var checkbox = driver.FindElement(checkboxIGV);
            if (!checkbox.Selected)
            {
                checkbox.Click();
            }
        }*/

        public void CheckIGVandDetUnif(string option)
        {
            // Convertir la opción a mayúsculas para evitar problemas de sensibilidad de mayúsculas
            option = option.ToUpper();

            // Localizar el checkbox
            var checkbox = driver.FindElement(checkboxIGV);

            switch (option)
            {
                case "SI":
                    // Siempre activar IGV, ya que sabemos que está desactivado
                    checkbox.Click();
                    Console.WriteLine("El IGV ha sido activado.");
                    break;

                case "NO":
                    // No hacer nada, ya que el IGV siempre está desactivado
                    Console.WriteLine("El IGV ya estaba desactivado.");
                    break;

                default:
                    // Manejar opciones no válidas
                    throw new ArgumentException($"Opción no válida: {option}. Use 'SI' o 'NO'.");
            }
        }

        //Método para seleccionar una familia y un concepto
        public void SelectConcept(By pathFamilia, By pathInputField, string option)
        {
            try
            {
                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(pathFamilia));

                IWebElement dropdown = driver.FindElement(pathFamilia);
                dropdown.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(pathInputField));
                IWebElement inputField = driver.FindElement(pathInputField);

                inputField.SendKeys(option);

                inputField.SendKeys(Keys.Enter);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Error: No se encontró un elemento durante el proceso. Detalle: {ex.Message}");
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Error: El tiempo de espera se agotó. Detalle: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
        public void invoiceData(string _clientType, string _clientValue)
        {
            // ESPERA PARA RELLENAR CAMPOS
            utilityPage.elementExists(clientField);
            utilityPage.WaitForOverlayToDisappear(overlayLocator);

            // TIPO CLIENTE
            switch (_clientType)
            {
                case "VARIOS":

                    //CAMPO CLIENTE VACIO
                    break;

                case "DNI":

                    utilityPage.enterField(clientField, _clientValue);
                    break;

                case "RUC":

                    utilityPage.enterField(clientField, _clientValue);
                    break;

                case "ALIAS":

                    utilityPage.enterField(aliasField, _clientValue);
                    break;
                case "REGISTRADO":
                    //utilityPage.enterField(registradoField, _clientValue);
                    break;

                default:
                    throw new ArgumentException($"El {_clientType} no es válido");
            }

        }

        //Ver medio de pago
        public string VerMedioPago()
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

            // Si no se selecciona nada, retorna una cadena vacía o lanza una excepción si es necesario
            return string.Empty;
        }

        public void SelectOption(By _path, string option)
        {
            try
            {
                // Esperar que el menú desplegable sea visible
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(_path));

                // Abre el menú desplegable
                IWebElement dropdown = driver.FindElement(_path);
                dropdown.Click();

                // Espera explícita para que las opciones sean visibles
                wait.Until(ExpectedConditions.ElementIsVisible(SelectOptionsXPath));

                /*Selecciona la opción deseada
                IWebElement optionElement = driver.FindElement(By.XPath($"//li[contains(text(), '{option}')]"));
                optionElement.Click();*/
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Error: No se encontró la opción '{option}' en el menú desplegable. Detalle: {ex.Message}");
            }
        }

        public void PaymentMethod1(string typeBank, string typeCard, string info)
        {
            string medioPagoSeleccionado = VerMedioPago();

            switch (medioPagoSeleccionado)
            {
                case "TDEB":

                    SelectOption(bankFieldTdeb, typeBank); // SELECCION BANCO
                    SelectOption(cardFieldTdeb, typeCard); // SELECCION TARJETA

                    utilityPage.enterField(infoMethod1FieldTdeb, info); // AGREGA INFO
                    Thread.Sleep(4000);

                    break;

                case "TCRE":

                    SelectOption(bankFieldTcred, typeBank); // SELECCION BANCO
                    SelectOption(cardFieldTcred, typeCard); // SELECCION TARJETA

                    utilityPage.enterField(infoMethod1FieldTcred, info); // AGREGA INFO
                    Thread.Sleep(4000);

                    break;
                default:
                    throw new ArgumentException($"El tipo de pago {medioPagoSeleccionado} no es válido.");
            }
        }

        // Método para realizar el inicio de sesión completo

        public void Concept(string family, string concept, string quantity)
        {
            SelectConcept(pathFamily, pathInputFieldFamily, family);
  
            SelectConcept(pathConcept, pathInputFieldFamily, concept);

            //EnterField(Quantity, quantity);
            Thread.Sleep(4000);
        }

        public void IGVoption(string option)
        {
            //CheckIGV(option);
        }
    }
}
