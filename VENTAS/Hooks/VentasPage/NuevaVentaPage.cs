using FluentAssertions.Equivalency;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SigesCore.Hooks.Utility;
using SigesCore.Hooks.XPaths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

        private By buscarCliente = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[1]/a[3]");

        By dniField = By.XPath("//input[@id='DocumentoIdentidad']");

        By pathFamily = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/registrador-detalles[1]/div[1]/div[1]/selector-concepto-comercial[1]/ng-form[1]/div[1]/div[5]/div[1]/span[1]/span[1]/span[1]");

        By pathDoc = By.XPath("/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]/span[1]");

        By pathInputDoc = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[2]/span[1]/span[1]/input[1]");

        //METODO 1

        // TDEB
        

        // TCRED
        By bankFieldTcred = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[5]/div[1]/span[1]/span[1]/span[1]");

        By cardFieldTcred = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[5]/div[1]/span[2]/span[1]/span[1]");

        By infoMethod1FieldTcred = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[5]/div[1]/textarea[1]");

        By lookCliente = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[1]/a[3]");

        //DEPCU
        By bankAccountFieldDepcu = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[8]/div[1]/span[1]/span[1]/span[1]");

        By infoMethod2FieldDepcu = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[8]/div[1]/textarea[1]");

        //TRANFON
        By bankAccountFieldTranfon = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[7]/div[1]/span[1]/span[1]/span[1]");

        By infoMethod2FieldTranfon = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[7]/div[1]/textarea[1]");   

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

        public void barCodeConcept(string valor)
        {
            utilityPage.enterDate(Concept.codeBarraField, valor);
        }

        public void SelectConcept(string valor)
        {
            Thread.Sleep(4000);
            SelectOption(Concept.pathConcept, valor);
        }

        public void TypeSelectConcept(string option, string valor)
        {
            option = option.ToUpper();
            utilityPage.elementExists(Concept.codeBarraField);
            switch (option)
            {
                case "BARRA":
                    barCodeConcept(valor);
                    break;

                case "SELECCION":
                    SelectConcept(valor);
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }

        }
        public void TypeSelectConcept(string option)
        {
           
        }

        public void QuantityConcept(string valor)
        {
            utilityPage.cantidad(Concept.Quantity, valor);
        }

        public class CheckboxHelper
        {
            public static void CheckOption(By locator, string option, IWebDriver driver)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                // Convertir la opción a mayúsculas para evitar errores de sensibilidad
                option = option.ToUpper();

                // Localizar el checkbox
                var checkbox = driver.FindElement(locator);

                if (option == "SI")
                {
                    if (!checkbox.Selected)
                    {
                        checkbox.Click();
                        Console.WriteLine($"El checkbox {locator} ha sido activado.");
                    }
                    else
                    {
                        Console.WriteLine($"El checkbox {locator} ya estaba activado.");
                    }
                }
                else if (option == "NO")
                {
                    Console.WriteLine($"El checkbox {locator} sigue desactivado.");
                }
                else
                {
                    throw new ArgumentException($"Opción no válida: {option}. Use 'SI' o 'NO'.");
                }
            }

            // Métodos específicos para llamar en los Steps
            public static void ActivarIGV(string option, IWebDriver driver)
            {
                CheckOption(CheckBox.checkboxIGV, option, driver);
            }

            public static void ActivarDetalleUnif(string option, IWebDriver driver)
            {
                CheckOption(CheckBox.checkboxDetUnif, option, driver);
            }
        }

        public void invoiceData(string option, string _clientValue)
        {
            // ESPERA PARA RELLENAR CAMPOS
            option = option.ToUpper();
            utilityPage.elementExists(Dates.clientField);
            // TIPO CLIENTE
            switch (option)
            {
                case "VARIOS":

                    //CAMPO CLIENTE VACIO
                    break;

                case "DNI":

                    utilityPage.enterField(Dates.clientField, _clientValue);
                    driver.FindElement(Dates.clientField).SendKeys(Keys.Enter);
                    Thread.Sleep(4000);
                    break;

                case "RUC":

                    utilityPage.enterField(Dates.clientField, _clientValue);
                    driver.FindElement(Dates.clientField).SendKeys(Keys.Enter);
                    Thread.Sleep(4000);
                    break;

                case "ALIAS":

                    utilityPage.enterField(Dates.aliasField, _clientValue);
                    driver.FindElement(Dates.aliasField).SendKeys(Keys.Enter);
                    Thread.Sleep(4000);
                    break;
                case "REGISTRADO":


                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }

        }

        public void TipoComprobante(string option)
        {
            option = option.ToUpper();
            utilityPage.elementExists(Comprobante.docField);
            switch (option)
            {
                case "BOLETA":

                    utilityPage.SelectOption(Comprobante.docField, Comprobante.docInputField, option);
                    Thread.Sleep(4000);
                    break;

                case "FACTURA":

                    utilityPage.SelectOption(Comprobante.docField, Comprobante.docInputField, option);
                    Thread.Sleep(4000);
                    break;

                case "NOTA":

                    utilityPage.SelectOption(Comprobante.docField, Comprobante.docInputField, option);
                    Thread.Sleep(4000);
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }
        }
        /*
        public void PaymentMethod(string option)
        {
            option = option.ToUpper();

            // Espera explícita para asegurarse de que el elemento 'PayMethod.payment' esté visible
            utilityPage.elementExists(PayMethod.payment);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            switch (option)
            {
                case "Contado":
                    // Espera explícita para asegurar que el botón 'contado' esté clickeable
                    wait.Until(ExpectedConditions.ElementToBeClickable(PayMethod.contado));
                    utilityPage.buttonClickeable(PayMethod.contado);
                    break;

                case "Rapido":
                    // Espera explícita para asegurar que el botón 'rapido' esté clickeable
                    wait.Until(ExpectedConditions.ElementToBeClickable(PayMethod.rapido));
                    utilityPage.buttonClickeable(PayMethod.rapido);
                    break;

                case "Configurado":
                    // Espera explícita para asegurar que el botón 'configurado' esté clickeable
                    wait.Until(ExpectedConditions.ElementToBeClickable(PayMethod.configurado));
                    utilityPage.buttonClickeable(PayMethod.configurado);
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }
        }*/

        public void Creditorapido()
        {
            utilityPage.buttonClickeable(PayMethod.rapido);
        }

        By registrado = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[1]/a[3]");
        By fieldRegistrado = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/span[1]");
        public void ClickClienteRegistrado(string valor)
        {
            utilityPage.buttonClickeable(registrado);
            Thread.Sleep(2000);
            utilityPage.buttonClickeable(fieldRegistrado);
            Thread.Sleep(2000);
            utilityPage.enterDate(fieldRegistrado, valor);
        }

        public void BuscarClienteRegistrado(string datoCliente)
        {
            // Paso 1: Hacer clic en el botón de búsqueda de clientes
            var botonBuscarCliente = driver.FindElement(registrado);
            botonBuscarCliente.Click();

            // Esperar que el campo de búsqueda sea visible y esté habilitado
            utilityPage.WaitForElementVisible(fieldRegistrado);
            var campoBusqueda = driver.FindElement(fieldRegistrado);

            // Paso 2: Hacer clic en el campo de búsqueda
            campoBusqueda.Click();

            // Esperar a que el campo esté realmente enfocado antes de escribir
            // Puede que sea necesario esperar un poco más si el campo es dinámico
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => campoBusqueda.Equals(driver.SwitchTo().ActiveElement()));  // Verifica que el campo esté enfocado

            // Paso 3: Limpiar el campo y luego escribir el dato
            campoBusqueda.Clear();  // Limpiar cualquier valor previo en el campo de búsqueda
            campoBusqueda.SendKeys(datoCliente);  // Ingresar el dato (ejemplo: número de documento)

            // Si el campo está listo, enviar la tecla Enter
            campoBusqueda.SendKeys(Keys.Enter);
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
                wait.Until(ExpectedConditions.ElementIsVisible(Extras.SelectOptions));

                // Selecciona la opción deseada
                IWebElement optionElement = driver.FindElement(By.XPath($"//li[contains(text(), '{option}')]"));
                optionElement.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Error: No se encontró la opción '{option}' en el menú desplegable. Detalle: {ex.Message}");
            }
        }
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
        public void PaymentMethod(string _moodPago)
        {
            _moodPago = _moodPago.ToUpper();
            switch (_moodPago)
            {
                case "DEPCU":

                    utilityPage.moodPay(MedioPago.depositoButton, _moodPago);
                    break;

                case "TRANFON":

                    utilityPage.moodPay(MedioPago.tranferenciaButton, _moodPago);
                    break;

                case "TDEB":

                    utilityPage.moodPay(MedioPago.debitoButton, _moodPago);
                    break;

                case "TCRE":

                    utilityPage.moodPay(MedioPago.creditoButton, _moodPago);
                    break;

                case "EF":

                    utilityPage.moodPay(MedioPago.efectivoButton, _moodPago);
                    break;

                case "PTS":

                    utilityPage.moodPay(MedioPago.puntosButton, _moodPago);
                    break;

                default:
                    throw new ArgumentException($"El {_moodPago} no es válido");
            }

            Thread.Sleep(4000);
        }
        /*
        public void CardPayment(string typeBank, string typeCard, string info)

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
        }*/

        public void PaymentMethod(string typeBank, string typeCard, string info)
        {
            string medioPagoSeleccionado = VerMedioPago();  // Obtiene el tipo de medio de pago seleccionado

            medioPagoSeleccionado = medioPagoSeleccionado.ToUpper();
            switch (medioPagoSeleccionado)
            {
                case "TDEB": // Para tarjetas de débito
                    SelectOption(Debito.bankFieldTdeb, typeBank); // SELECCION BANCO
                    SelectOption(Debito.cardFieldTdeb, typeCard); // SELECCION TARJETA
                    utilityPage.enterField(Debito.infoMethod1FieldTdeb, info); // AGREGA INFO
                    Thread.Sleep(4000);
                    break;

                case "TCRE": // Para tarjetas de crédito
                    SelectOption(bankFieldTcred, typeBank); // SELECCION BANCO
                    SelectOption(cardFieldTcred, typeCard); // SELECCION TARJETA
                    utilityPage.enterField(infoMethod1FieldTcred, info); // AGREGA INFO
                    Thread.Sleep(4000);
                    break;

                case "DEPCU": // Para Depósito
                    SelectOption(bankAccountFieldDepcu, typeBank); // SELECCION BANCO
                    utilityPage.enterField(infoMethod2FieldDepcu, info); // AGREGA INFO
                    Thread.Sleep(4000);
                    break;

                case "TRANFON": // Para Transferencia
                    SelectOption(bankAccountFieldTranfon, typeBank); // SELECCION BANCO
                    utilityPage.enterField(infoMethod2FieldTranfon, info); // AGREGA INFO
                    Thread.Sleep(4000);
                    break;

                case "EF": // Para Transferencia
                    utilityPage.enterField(Efectivo.efectivo, info); // AGREGA INFO
                    Thread.Sleep(4000);
                    break;

                case "PTS": // Para Transferencia
                    break;

                default:
                    throw new ArgumentException($"El tipo de pago {medioPagoSeleccionado} no es válido.");
            }
        }

        public void saveSale()
        {
            utilityPage.buttonClickeable(Extras.saveSale);
            Thread.Sleep(5000);
        }

    }
}

/*
        public void AddConcept(string metodo, string valor)
        {
            utilityPage.elementExists(codeBarraField);
            utilityPage.WaitForElementVisible(overlayLocator);
            // Convertir el método a mayúsculas para evitar errores de sensibilidad
            //metodo = metodo.ToUpper();
            switch (metodo)
            {
                case "Barra":
                    // Lógica para agregar concepto por código de barra
                   // utilityPage.elementExists(codeBarraField);
                    // utilityPage.WaitForElementVisible(overlayLocator);
                    utilityPage.enterField2(codeBarraField, valor);
                    Thread.Sleep(4000);
                    Console.WriteLine($"Concepto agregado por código de barra: {valor}");
                    break;

                case "Seleccion":
                    // Lógica para agregar concepto por selección manual
                    utilityPage.elementExists(pathConcept);
                    utilityPage.WaitForElementVisible(overlayLocator);
                    SelectConcept(pathConcept, pathInputFieldConcept, valor);
                    Thread.Sleep(4000);
                    Console.WriteLine($"Concepto agregado manualmente: {valor}");
                    break;

                default:
                    // Manejar opciones no válidas
                    throw new ArgumentException($"Método '{metodo}' no reconocido. Use 'Barra' o 'Concepto'.");
            }

public void PaymentMethod(string typeBank, string typeCard, string info)
{
string medioPagoSeleccionado = VerMedioPago();  // Obtiene el tipo de medio de pago seleccionado

switch (medioPagoSeleccionado)
{
case "TDEB": // Para tarjetas de débito
    SelectOption(bankFieldTdeb, typeBank); // SELECCION BANCO
    SelectOption(cardFieldTdeb, typeCard); // SELECCION TARJETA
    utilityPage.enterField(infoMethod1FieldTdeb, info); // AGREGA INFO
    Thread.Sleep(4000);
    break;

case "TCRE": // Para tarjetas de crédito
    SelectOption(bankFieldTcred, typeBank); // SELECCION BANCO
    SelectOption(cardFieldTcred, typeCard); // SELECCION TARJETA
    utilityPage.enterField(infoMethod1FieldTcred, info); // AGREGA INFO
    Thread.Sleep(4000);
    break;

case "DEPO": // Para Depósito
    SelectOption(bankFieldTdeb, typeBank); // SELECCION BANCO
    utilityPage.enterField(infoMethod1FieldTdeb, info); // AGREGA INFO
    Thread.Sleep(4000);
    break;

case "TRANS": // Para Transferencia
    SelectOption(bankFieldTdeb, typeBank); // SELECCION BANCO
    utilityPage.enterField(infoMethod1FieldTdeb, info); // AGREGA INFO
    Thread.Sleep(4000);
    break;

default:
    throw new ArgumentException($"El tipo de pago {medioPagoSeleccionado} no es válido.");
}
}

        }*/
