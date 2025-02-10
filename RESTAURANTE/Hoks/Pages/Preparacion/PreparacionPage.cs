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
        WebDriverWait wait;

        public PreparacionPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilities = new Utilities(driver);
        }


        private By prepararBoton = By.Id("boton-preparar");
        private By servirBoton = By.Id("boton-servir");


        public void typeInvoice(string _typeFactura)
        {
            // Encontrar la ultima carta
            // IWebElement ultimaCarta = modalFacturacion.FindElement(By.Id($"facturacionVenta-{i}"));

            // Encontrar la ultima orden
            IWebElement ncard = driver.FindElement(By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[10]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", ncard); // Desplázate hasta el elemento

            Thread.Sleep(4000);
            // BOTON FACTURAR - ELECCION DEL PRIMERO
            /*
            utilities.elementExists(facturarAtencionButton);
            utilities.WaitForOverlayToDisappear(overlayLocator);
            utilities.buttonClickeable(facturarAtencionButton);
            */
        }
    }
}
