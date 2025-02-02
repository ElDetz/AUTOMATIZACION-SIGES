using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SigesCore.Hooks.XPaths;
using System.IO;


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

        public void WaitForOverlayToDisappear(By overlayLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(driver =>
            {
                try
                {
                    IWebElement overlay = driver.FindElement(overlayLocator);
                    return !overlay.Displayed; 
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        public void EnterField(By path, string field)
        {
            if (driver.FindElements(path).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {path} no se encontró.");
            }

            wait.Until(ExpectedConditions.ElementIsVisible(path)); // Espera hasta que el elemento sea visible
            driver.FindElement(path).SendKeys(Keys.Control + "a");
            driver.FindElement(path).SendKeys(Keys.Delete);
            driver.FindElement(path).Clear();
            driver.FindElement(path).SendKeys(field);
        }

        public void ElementExists(By button)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementExists(button)); // Espera hasta que el elemento exista en el DOM
            }
            catch (WebDriverTimeoutException)
            {
                throw new NoSuchElementException($"El elemento con el localizador {button} no se encontró dentro del tiempo esperado.");
            }
        }

        public void ClickButton(By button)
        {
            if (driver.FindElements(button).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {button} no se encontró.");
            }

            wait.Until(ExpectedConditions.ElementToBeClickable(button)); // Espera hasta que el elemento sea clickeable
            driver.FindElement(button).Click();
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
       
        public void WaitExistsVisible(By pathExists, By pathOverlay)
        {
            ElementExists(pathExists);
            WaitForElementVisible(pathOverlay);
        }

        public void EnterDate(By path, string option)
        {
            WaitExistsVisible(path, AdditionalElements.OverlayElement);
            EnterField(path, option);
            driver.FindElement(path).SendKeys(Keys.Enter);
            Thread.Sleep(4000);
        }

        public void ClickUility(By component)
        {
            IWebElement dropdown = driver.FindElement(component);
            dropdown.Click();
        }

        public void DataEntryAndEnter(By component, string option)
        {
            EnterField(component, option);
            driver.FindElement(component).SendKeys(Keys.Enter);
        }

        public void Registered(By buttonRegistered, By FieldRegistered, string option)
        {
            ClickUility(buttonRegistered);
            Thread.Sleep(4000);
            ClickUility(FieldRegistered);
            DataEntryAndEnter(FieldRegistered, option);
        }

        public void Quantity(By quantity, string value)
        {
            Thread.Sleep(2000);
            EnterField(quantity, value);
            Thread.Sleep(2000);
            driver.FindElement(quantity).SendKeys(Keys.Enter);
        }

        public void PaymentMethodUtility(By path, string option)
        {
            switch (option)
            {
                case "DEPCU":

                    ClickButton(path);
                    break;

                case "TRANFON":

                    ClickButton(path);
                    break;

                case "TDEB":

                    ClickButton(path);
                    break;

                case "TCRE":

                    ClickButton(path);
                    break;

                case "EF":

                    ClickButton(path);
                    break;
                case "PTS":

                    ClickButton(path);
                    break;

                default:
                    throw new ArgumentException($"El {path} no es válido");
            }
        }

        public string ViewPaymentMethod()
        {
            var medioPagoContainer = driver.FindElement(By.Id("medioPago0"));
            var radioButtons = medioPagoContainer.FindElements(By.CssSelector("input[type='radio']"));

            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Selected) 
                {
                    var label = driver.FindElement(By.CssSelector($"label[for='{radioButton.GetAttribute("id")}']"));

                    return label.Text;
                }
            }
            // Si no se selecciona nada, retorna una cadena vacía o lanza una excepción si es necesario
            return string.Empty;
        }

        public void SelectOption(By path, string option)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(path));

                IWebElement dropdown = driver.FindElement(path);
                dropdown.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(AdditionalElements.SelectODropdownOptions));

                IWebElement optionElement = driver.FindElement(By.XPath($"//li[contains(text(), '{option}')]"));
                optionElement.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Error: No se encontró la opción '{option}' en el menú desplegable. Detalle: {ex.Message}");
            }
        }

        public void BarCodeConcept(string value)
        {
            EnterDate(Concept.BarcodeInputField, value);
        }

        public void SelectConcept(string value)
        {
            Thread.Sleep(4000);
            SelectOption(Concept.ConceptSelection, value);
        }
    }
}
