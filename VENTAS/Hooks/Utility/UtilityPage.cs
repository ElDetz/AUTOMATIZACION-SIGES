using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SigesCore.Hooks.XPaths;


namespace SigesCore.Hooks.Utility
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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        //By restauranteField = By.XPath("//span[contains(text(),'Restaurante')]");

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

        public void enterField2(By _path, string _field)
        {
            if (driver.FindElements(_path).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_path} no se encontró.");
            }

            wait.Until(ExpectedConditions.ElementIsVisible(_path)); // Espera hasta que el elemento sea visible
            driver.FindElement(_path).Clear();
            driver.FindElement(_path).SendKeys(_field);
            driver.FindElement(_path).SendKeys(Keys.Enter);
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

        // Ingreso Modulo
       
        public void SelectOption(By _path, string _option)
        {
            try
            {
                // Espera que el elemento del menú sea visible
                WaitForElementVisible(_path);

                // Haz clic en el campo Select2 para abrir el menú desplegable
                IWebElement dropdown = driver.FindElement(_path);
                dropdown.Click();

                // Espera a que las opciones sean visibles
                WaitForElementVisible(ModuloVenta.SelectOptions);

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
