using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SigesCore.Hoks
{
    public class UtilityPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public UtilityPage(IWebDriver driver, int timeoutInSeconds = 150)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), "El WebDriver no puede ser null.");
            }
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }


        //By restauranteField = By.XPath("//span[contains(text(),'Restaurante')]");

        By restauranteField = By.XPath("//a[@class='menu-lista-cabecera']/span[text()='Restaurante']");

        By atencionField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[1]/a[1]");
        By preparacionField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[2]/a[1]");
        
        By cajaField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[3]/a[1]");
        //By cajaField = By.XPath("//ul[@class='treeview-menu']//a[normalize-space(text())='Caja']");

        By complementosField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[3]/a[1]");
        By reportesField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[5]/a[1]");

        // MENU DESPEGABLE
        By SelecOptions = By.CssSelector(".select2-results__options");

        public void WaitForOverlayToDisappear(By overlayLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(driver =>
            {
                try
                {
                    IWebElement overlay = driver.FindElement(overlayLocator);
                    return !overlay.Displayed; // Espera hasta que el overlay no esté visible
                }
                catch (NoSuchElementException)
                {
                    return true; // Si no se encuentra, el overlay ya desapareció
                }
            });
        }

        public void enterField(By _path, string _field)
        {
            if (driver.FindElements(_path).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_path} no se encontró.");
            }

            wait.Until(ExpectedConditions.ElementIsVisible(_path)); // Espera hasta que el elemento sea visible
            driver.FindElement(_path).Clear(); 
            driver.FindElement(_path).SendKeys(_field); 
        }

        public void elementExists(By _button)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementExists(_button)); // Espera hasta que el elemento exista en el DOM
                //buttonClickeable(_button);
            }
            catch (WebDriverTimeoutException)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_button} no se encontró dentro del tiempo esperado.");
            }
        }

        public void buttonClickeable(By _button)
        {
            if (driver.FindElements(_button).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_button} no se encontró.");
            }

            wait.Until(ExpectedConditions.ElementToBeClickable(_button)); // Espera hasta que el elemento sea clickeable
            driver.FindElement(_button).Click();
        }

        // Esperar que el menú desplegable sea visible
        public void WaitForElementVisible(By locator)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new NoSuchElementException($"El elemento con el localizador {locator} no se hizo visible dentro del tiempo de espera.");
            }
        }

        /*
        public void elementVisible(By _button)
        {
            if (driver.FindElements(_button).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_button} no se encontró.");
            }

            wait.Until(ExpectedConditions.ElementToBeClickable(_button)); // Espera hasta que el elemento sea visible
            driver.FindElement(_button).Click();
        }
        */

        // Ingreso Modulo
        public void enterModulo(string _modulo)
        {
            // Clic en "Restaurante"
            buttonClickeable(restauranteField);

            switch (_modulo)
            {
                case "Atencion":

                    buttonClickeable(atencionField);
                    break;

                case "Preparacion":

                    buttonClickeable(preparacionField);
                    break;

                case "Caja":

                    buttonClickeable(cajaField);
                    break;

                case "Complementos":

                    buttonClickeable(complementosField);
                    break;

                case "Reportes":

                    buttonClickeable(reportesField);
                    break;

                default:
                    throw new ArgumentException($"El {_modulo} no es válido.");
            }

            //Thread.Sleep(4000);
        }

        public void SelecOption(By _path, string _option)
        {
            try
            {
                // Espera que el elemento del menú sea visible
                WaitForElementVisible(_path);

                // Haz clic en el campo Select2 para abrir el menú desplegable
                IWebElement dropdown = driver.FindElement(_path);
                dropdown.Click();

                // Espera a que las opciones sean visibles
                WaitForElementVisible(SelecOptions);

                // Selecciona la opción correspondiente (busca por texto visible en el <li>)
                IWebElement optionElement = driver.FindElement(By.XPath($"//li[contains(text(), '{_option}')]"));
                optionElement.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Error: No se encontró la opción '{_option}' en el menú desplegable. Detalle: {ex.Message}");
            }
        }

    }
}
