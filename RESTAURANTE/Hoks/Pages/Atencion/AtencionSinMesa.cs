using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAURANTE.Hoks.Pages.Atencion
{
    public class AtencionSinMesaPage
    {
        private IWebDriver driver;
        Utilities utilities;

        public AtencionSinMesaPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilities = new Utilities(driver);
        }

        // AMBIENTES - ATENCION SIN MESA
        private By _carrito1 = By.XPath("//label[@id='ambientesinmesa-0']");
        private By _llamadas = By.XPath("//label[@id='ambientesinmesa-1']");
        private By _carritoApoyo = By.XPath("//label[@id='ambientesinmesa-2']");
        private By fieldLocator;

        // DETALLES PEDIDO
        private By _clienteField = By.XPath("//input[@placeholder='Nombre Cliente']");
        private By _selectMozo = By.Id("mozo");

        private By _codeBarraItem = By.XPath("//input[@id='codigoBarraItem']");
        private By _selectItem = By.Id("itemSeleccionado");
        private By _itemCantidad = By.Id("cantidadItem");

        // ACCIONES
        private By _agregarItem = By.XPath("//button[@title='Agregar Item']");
        private By _anotacionItem = By.XPath("//button[@title='Agregar una Anotacion']");
        private By _eliminarItem = By.XPath("//button[@title='Eliminar Item de Orden']");
        private By _guardarOrden = By.XPath("//p[@title='Guardar Orden']");

        public void SeleccionModoAtencion(string _modoAtencion)
        {
            switch (_modoAtencion)
            {
                case "AL PASO":
                    fieldLocator = _carrito1;
                    return;

                case "DELIVERY":

                    fieldLocator = _llamadas;
                    break;

                case "CARRITO APOYO":

                    fieldLocator = _carritoApoyo;
                    break;

                default:
                    throw new ArgumentException($"El {_modoAtencion} no es válido");
            }

            utilities.elementExists(fieldLocator);
            Console.WriteLine($"SE INGRESO {_modoAtencion}");
            utilities.buttonClickeable(fieldLocator);
            Thread.Sleep(4000);
        }

        public void IngresarCliente(string _cliente)
        {
            // CLIENTE
            utilities.elementExists(_clienteField);
            utilities.InputTexto(_clienteField, _cliente);
        }

        public void SeleccionMozo(string _mozo)
        {
            // SELECCION MOZO
            utilities.elementExists(_selectMozo);
            var dropdown = new SelectElement(driver.FindElement(_selectMozo));
            dropdown.SelectByText(_mozo);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(_mozo));
            Console.WriteLine($"{_mozo} SELECCIONADO");
            Thread.Sleep(5000);
        }

        public void CodigoItem(string _concepto, string _anotacion)
        {
            utilities.SubmitTexto(_codeBarraItem, _concepto);
            Thread.Sleep(5000);
        }

        public void SeleccionItem(string _concepto, string _cantidad, string _anotacion)
        {
            // ITEM POR SELECT
            var dropdown = new SelectElement(driver.FindElement(_selectItem));
            dropdown.SelectByText(_concepto);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(_concepto));
            Console.WriteLine($"{_concepto} SELECCIONADO");
            Thread.Sleep(2000);
            // CANTIDAD
            utilities.InputTexto(_itemCantidad, _cantidad);
            Thread.Sleep(2000);
            // CHECK
            utilities.buttonClickeable(_agregarItem);
        }

        public void AccionOrden(string _accion)
        {
            utilities.elementExists(_guardarOrden);
            utilities.buttonClickeable(_guardarOrden);
            Thread.Sleep(4000);
        }

        public void AgregarAnotacion(string _accion)
        {
            // Encuentra la tabla por su ID
            IWebElement tabla = driver.FindElement(By.Id("acordionAnotacion"));

            // Encuentra todas las filas dentro de la tabla
            IList<IWebElement> filas = tabla.FindElements(By.TagName("tr"));

            foreach (var fila in filas)
            {
                try
                {
                    // Encuentra la celda de la descripción dentro de la fila
                    IWebElement descripcionElemento = fila.FindElement(By.CssSelector("td:nth-child(2)"));
                    string descripcion = descripcionElemento.Text;

                    // Si la fila contiene la orden específica
                    if (descripcion.Contains("VINO FRONTERA BOTELLA 1 UN"))
                    {
                        // Encuentra y hace clic en el botón de anotación
                        IWebElement botonAnotacion = fila.FindElement(By.CssSelector("a.btn-info"));
                        botonAnotacion.Click();
                        Console.WriteLine("Botón de anotación presionado.");

                        Thread.Sleep(1000);
                        // Encuentra el campo de anotación en la fila actual
                        IWebElement inputAnotacion = driver.FindElement(By.CssSelector("input[id^='input-anotacion']"));

                        // Escribir la anotación
                        inputAnotacion.SendKeys("Sin mayonesa, por favor.");
                        Console.WriteLine("Anotación ingresada.");
                        break; // Termina el bucle al encontrar la fila
                    }
                }
                catch (NoSuchElementException)
                {
                    continue; // Si la fila no tiene una descripción válida, sigue con la siguiente
                }
            }
            Thread.Sleep(4000);

        }

        public void AnotacionItem(string _accion)
        {
            // Encuentra la tabla por su ID
            IWebElement tabla = driver.FindElement(By.Id("acordionAnotacion"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // js.ExecuteScript("arguments[0].scrollIntoView({block: 'nearest', inline: 'center'});", tabla);
            // js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(2000);

            // Encuentra todas las filas dentro de la tabla
            IList<IWebElement> filas = tabla.FindElements(By.TagName("tr"));

            foreach (var fila in filas)
            {
                try
                {
                    // IDENTIFICA EL ORDEN DE FILA
                    IWebElement ordenElemento = fila.FindElement(By.CssSelector("td:nth-child(1)"));
                    string orden = ordenElemento.Text;

                    // Encuentra la celda de la descripción dentro de la fila
                    IWebElement descripcionElemento = fila.FindElement(By.CssSelector("td:nth-child(2)"));
                    string descripcion = descripcionElemento.Text;

                    // Encuentra la celda de cantidad dentro de la fila
                    IWebElement cantidadElemento = fila.FindElement(By.CssSelector("td:nth-child(3)"));
                    string cantidad = cantidadElemento.Text;

                    // Si la fila contiene la orden específica
                    if (descripcion.Contains("VINO FRONTERA BOTELLA 1 UN") && cantidad.Contains("3.00"))
                    {
                        int ordenNumero = int.Parse(orden); // Convertimos a entero

                        Console.WriteLine($"EL ORDEN ES {ordenNumero}");

                        // Encuentra y hace clic en el botón de anotación
                        IWebElement botonAnotacion = fila.FindElement(By.CssSelector("a.btn-info"));
                        js.ExecuteScript("arguments[0].scrollIntoView(true);", botonAnotacion);
                        Thread.Sleep(2000);
                        botonAnotacion.Click();
                        Console.WriteLine("Botón de anotación presionado.");

                        Thread.Sleep(2000);
                        /*
                        js.ExecuteScript("arguments[0].scrollIntoView(true);", inputAnotacion);
                        Thread.Sleep(2000);

                        */
                        // Escribir la anotación

                        // Encuentra el campo de anotación en la fila actual
                        IWebElement inputAnotacion = driver.FindElement(By.Id($"input-anotacion{ordenNumero-1}"));
                        // js.ExecuteScript("arguments[0].scrollIntoView(true);", inputAnotacion);
                        Thread.Sleep(2000);
                        // utilities.addFieldModal(inputAnotacion, By.CssSelector("input[id^='input-anotacion']"), "Sin mayonesa, por favor.");
                        inputAnotacion.SendKeys("Sin mayonesa, por favor.");
                        Console.WriteLine("Anotación ingresada.");
                        break; // Termina el bucle al encontrar la fila


                    }
                }
                catch (NoSuchElementException)
                {
                    continue; // Si la fila no tiene una descripción válida, sigue con la siguiente
                }
            }
            Thread.Sleep(4000);
        }

        public void ElimarItem(string _accion)
        {
            // Encuentra la tabla por su ID
            IWebElement tabla = driver.FindElement(By.Id("acordionAnotacion"));

            // Encuentra todas las filas dentro de la tabla
            IList<IWebElement> filas = tabla.FindElements(By.TagName("tr"));

            foreach (var fila in filas)
            {
                try
                {
                    // Encuentra la celda de la descripción dentro de la fila
                    IWebElement descripcionElemento = fila.FindElement(By.CssSelector("td:nth-child(2)"));
                    string descripcion = descripcionElemento.Text;

                    // Si la fila contiene la orden específica
                    if (descripcion.Contains("SALCHIPAPA SALCHIPAPA ESPECIAL"))
                    {
                        // Encuentra y hace clic en el botón de anotación
                        IWebElement botonAnotacion = fila.FindElement(By.CssSelector("a.btn-info"));
                        botonAnotacion.Click();
                        Console.WriteLine("Botón de anotación presionado.");
                        break; // Termina el bucle al encontrar la fila
                    }
                }
                catch (NoSuchElementException)
                {
                    continue; // Si la fila no tiene una descripción válida, sigue con la siguiente
                }
            }
        }
    }
}   
