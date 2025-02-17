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
        private By _agregarItem = By.XPath("//button[@title='Agregar Item']");


        private By _anotacionItem = By.XPath("//button[@title='Agregar una Anotacion']");
        private By _eliminarItem = By.XPath("//button[@title='Eliminar Item de Orden']");


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
            // CANTIDAD
            utilities.InputTexto(_itemCantidad, _cantidad);
            // CHECK
            utilities.buttonClickeable(_agregarItem);
            Thread.Sleep(5000);
        }

        /*
        public void agregarOrden(string _orden, string _concepto, string _cantidad, string _anotacion)
        {
            // TIPO ORDEN
            switch (_orden)
            {
                case "CODIGO":
                    seleccionCode(_concepto);
                    return;

                case "ITEM":

                    seleccionItem(_concepto, _cantidad);
                    break;

                default:
                    throw new ArgumentException($"La tipo de orden por {_orden} no es válido");
            }

            Thread.Sleep(2000);
        }
        */

    }
}
