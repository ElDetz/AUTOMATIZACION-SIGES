using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTAURANTE.Hoks.Pages.Facturacion;

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

        private By prepararButton = By.Id("boton-preparar");
        private By servirButton = By.Id("boton-servir");

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

            IWebElement cartillaOrden = scrollableElement.FindElement(By.XPath("//h3[contains(text(),'C001 - 125339')]"));

            js.ExecuteScript("arguments[0].scrollIntoView({block: 'nearest', inline: 'center'});", cartillaOrden);
            // js.ExecuteScript("arguments[0].scrollIntoView(true);", elemento);

            // Esperar para visualizar el cambio
            Thread.Sleep(4000);

            IWebElement itemOrden = scrollableElement.FindElement(By.XPath("//div[contains(text(),'CARTA 1/2 POLLO A LA BRASA')]"));

            Thread.Sleep(2000);

            // Hacer clic en el ítem
            itemOrden.Click();


            /*
            // Encuentra todas las órdenes que contienen casillas de verificación
            var ordenes = cartillaOrden.FindElements(By.XPath("//div[contains(@class, 'boton-detalle-orden')]"));

            foreach (var orden in ordenes)
            {
                try
                {
                    // Verificar si contiene un checkbox
                    var checkbox = orden.FindElement(By.XPath(".//input[@type='checkbox']"));
                    if (checkbox != null)
                    {
                        // Hacer clic en la orden que contiene la casilla
                        orden.Click();
                        Console.WriteLine("Orden clickeada: " + orden.Text);
                    }
                }
                catch (NoSuchElementException)
                {
                    // Si no tiene checkbox, continuar con la siguiente orden
                    continue;
                }
            }
            */

            /*

            // Encuentra todas las casillas de órdenes
            IReadOnlyCollection<IWebElement> casillas = driver.FindElements(By.XPath("//h3[contains(text(),'C001 - 125335')]"));

            Thread.Sleep(4000);
            // Encuentra las órdenes dentro de la casilla
            IReadOnlyCollection<IWebElement> casillas = casilla.FindElements(By.ClassName("boton-detalle-orden"));

            foreach (var casilla in casillas)
            {
                try
                {
                    // Encuentra las órdenes dentro de la casilla
                    IReadOnlyCollection<IWebElement> ordenes = scroll.FindElements(By.ClassName("boton-detalle-orden"));

                    foreach (var orden in ordenes)
                    {
                        try
                        {
                            // Hace clic en la orden
                            orden.Click();
                            Thread.Sleep(1000); // Pequeña pausa para evitar fallos
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al hacer clic en una orden: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar órdenes en la casilla: " + ex.Message);
                }
            }
            */
            // Esperar para visualizar el cambio
            Thread.Sleep(4000);

            /*
            // IWebElement ultimaCarta = modalFacturacion.FindElement(By.Id($"facturacionVenta-{i}"));

            /*
            // Ejecutar JavaScript para hacer scroll dentro del contenedor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollLeft += 500;", scrollableElement); // Baja 300px
            */

        }
    }
}
