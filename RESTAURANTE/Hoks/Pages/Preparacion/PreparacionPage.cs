using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTAURANTE.Hoks.Pages.Facturacion;
using static OpenQA.Selenium.BiDi.Modules.Input.Wheel;

namespace RESTAURANTE.Hoks.Pages.Preparacion
{
    public class PreparacionPage
    {
        private IWebDriver driver;
        Utilities utilities;

        public PreparacionPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilities = new Utilities(driver);
        }

        // ACCIONES
        private By prepararButton = By.Id("boton-preparar");
        private By servirButton = By.Id("boton-servir");
        private By refrescarButton = By.XPath("//button[@title='Refrescar']");
        private By fieldLocator;

        public void scrollElement(int _nOrden)
        {
            /*
            // BOTON FACTURAR - ELECCION DEL PRIMERO
            utilities.elementExists(servirButton);
            utilities.WaitForOverlayToDisappear(); // OVERLAY
            utilities.buttonClickeable(servirButton);
            */

            Thread.Sleep(8000);

            IWebElement scrollableElement = driver.FindElement(By.ClassName("contenedor-cartillas"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // IWebElement cartillaOrden = scrollableElement.FindElement(By.XPath("//div[h3[contains(text(),'C001 - 125339')]]"));
            IWebElement cartillaEspecifica = scrollableElement.FindElement(By.XPath("//div[contains(@class, 'box-primary') and .//h3[contains(text(),'C001 - 125339')]]"));
            // IWebElement cartillaEspecifica = scrollableElement.FindElements(By.ClassName("box-primary")).FirstOrDefault(cartilla => cartilla.Text.Contains("C001 - 125339"));

            js.ExecuteScript("arguments[0].scrollIntoView({block: 'nearest', inline: 'center'});", cartillaEspecifica);
            
            // Esperar para visualizar el cambio
            Thread.Sleep(4000);

            // BUSCAR TODAS LAS CARTILLAS
            // IList<IWebElement> cartillas = scrollableElement.FindElements(By.ClassName("box-primary"));

            // BUSCAR ORDENES EN LA CARTILLA
            IList<IWebElement> ordenes = cartillaEspecifica.FindElements(By.ClassName("boton-detalle-orden"));

            ordenes[0].Click();

            Thread.Sleep(2000);
            IWebElement ordenPolloMani = ordenes.FirstOrDefault(o => o.GetAttribute("textContent").Trim().Contains("MENU POLLO CON MANI"));
            // IWebElement ordenPolloMani = ordenes.FirstOrDefault(o => o.Text.Trim().Contains("MENU POLLO CON MANI"));
            ordenPolloMani.Click();



           

            /*
            foreach (var item in itemsOrden)
            {
                Console.WriteLine("Texto encontrado: " + item.Text);
            }
            */


            Thread.Sleep(2000);

   


           

            /*

            // Encuentra todas las casillas de órdenes
            IReadOnlyCollection<IWebElement> casillas = driver.FindElements(By.XPath("//h3[contains(text(),'C001 - 125335')]"));

            
            */
            // Esperar para visualizar el cambio
            Thread.Sleep(10000);

            /*
            // IWebElement ultimaCarta = modalFacturacion.FindElement(By.Id($"facturacionVenta-{i}"));

            /*
            // Ejecutar JavaScript para hacer scroll dentro del contenedor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollLeft += 500;", scrollableElement); // Baja 300px
            */
            // js.ExecuteScript("arguments[0].scrollIntoView(true);", elemento);

            
        }

        public void accionPreparacion (string _accion)
        {

            switch (_accion)
            {
                case "Preparar":
                    fieldLocator = prepararButton;
                    break;
                case "Servir":
                    fieldLocator = servirButton;
                    break;
                default:
                    throw new ArgumentException($"Accion {_accion} no válido");
            }

            utilities.buttonClickeable(fieldLocator);
            Console.WriteLine($"Accion {_accion} realizada");

            //CLICK EN REFRESCAR
            utilities.buttonClickeable(refrescarButton);

        }
    }
}
