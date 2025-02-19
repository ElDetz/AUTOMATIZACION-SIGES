using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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


        public string Formato(string accion, string input)
        {
            switch (accion.ToLower())
            {
                case "nombre":
                    // Si el string comienza con números seguidos de '|', lo eliminamos
                    return Regex.IsMatch(input, @"^\d+\|")
                        ? Regex.Replace(input, @"^\d+\|", "").Trim()
                        : input.Trim();

                case "numero":
                    // Expresión regular para capturar solo el número al inicio antes del "|"
                    Match match = Regex.Match(input, @"^(\d+)\|");

                    // Si hay coincidencia, devuelve el número; de lo contrario, devuelve "N/A"
                    return match.Success ? match.Groups[1].Value : "N/A";

                case "decimal":
                    if (decimal.TryParse(input, out decimal numero))
                    {
                        return numero.ToString("0.00"); // Convierte a dos decimales
                    }
                    return input;
                default:
                    return "Acción inválida";
            }
        }

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

        public void CodigoItem(string _concepto)
        {
            utilities.SubmitTexto(_codeBarraItem, _concepto);
            Thread.Sleep(2000);
        }

        public void SeleccionItem(string _concepto, string _cantidad)
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
            Thread.Sleep(2000);
        }

        public void AccionItem(string _accion, string _item, string _cantidad, string _anotacion)
        {
            // Encuentra la tabla por su ID
            IWebElement tabla = driver.FindElement(By.Id("acordionAnotacion"));
            IList<IWebElement> filas = tabla.FindElements(By.TagName("tr"));

            foreach (var fila in filas)
            {
                try
                {
                    IWebElement ordenElemento = fila.FindElement(By.CssSelector("td:nth-child(1)"));
                    string orden = ordenElemento.Text;

                    IWebElement descripcionElemento = fila.FindElement(By.CssSelector("td:nth-child(2)"));
                    string descripcion = descripcionElemento.Text;

                    IWebElement cantidadElemento = fila.FindElement(By.CssSelector("td:nth-child(3)"));
                    string cantidad = cantidadElemento.Text;

                    if (descripcion.Contains(_item) && cantidad.Contains(Formato("decimal", _cantidad)))
                    {
                        int ordenNumero = int.Parse(orden); // Convertimos a entero
                        // Encuentra y hace clic en el botón de anotación
                        utilities.ScrollViewElement(fila);
                        Thread.Sleep(2000);
                        switch (_accion)
                        {
                            case "Agregar anotacion":
                                IWebElement botonAnotacion = fila.FindElement(By.CssSelector("a.btn-info"));
                                botonAnotacion.Click();

                                IWebElement inputAnotacion = driver.FindElement(By.Id($"input-anotacion{ordenNumero - 1}"));
                                inputAnotacion.SendKeys(_anotacion);
                                Thread.Sleep(2000);
                                botonAnotacion.Click();
                                break;
                            case "Eliminar":
                                IWebElement botonEliminar = fila.FindElement(By.CssSelector("button.btn-danger"));
                                botonEliminar.Click();
                                break;
                            default:
                                throw new ArgumentException($"LA ACCION {_accion} NO ES VALIDO");
                        }
                        Thread.Sleep(2000);
                        utilities.ScrollViewTop();

                        break; // Sale del bucle al encontrar el botón
                    }
                }
                catch (NoSuchElementException)
                {
                    continue; // Si la fila no tiene una descripción válida, sigue con la siguiente
                }
            }            
        }

        public void AccionOrden(string _accion)
        {
            utilities.elementExists(_guardarOrden);
            utilities.buttonClickeable(_guardarOrden);
            Thread.Sleep(4000);
        }



    }
}   
