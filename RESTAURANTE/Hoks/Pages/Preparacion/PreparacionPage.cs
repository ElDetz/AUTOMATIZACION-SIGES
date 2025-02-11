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

            /*
            // Ejecutar JavaScript para hacer scroll dentro del contenedor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollLeft += 500;", scrollableElement); // Baja 300px
            */

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            IWebElement elemento = scrollableElement.FindElement(By.XPath("//h3[contains(text(),'C001 - 125335')]"));
            js.ExecuteScript("arguments[0].scrollIntoView({block: 'nearest', inline: 'center'});", elemento);
            // js.ExecuteScript("arguments[0].scrollIntoView(true);", elemento);


            // Esperar para visualizar el cambio
            Thread.Sleep(8000);

            /*
            // IWebElement ultimaCarta = modalFacturacion.FindElement(By.Id($"facturacionVenta-{i}"));

            // Encontrar la ultima orden
            IWebElement ncard = driver.FindElement(By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[10]"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", ncard); // Desplázate hasta el elemento
            */

        }
    }
}
