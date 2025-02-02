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
            driver.FindElement(_path).SendKeys(Keys.Control + "a");
            driver.FindElement(_path).SendKeys(Keys.Delete);
            driver.FindElement(_path).Clear();
            driver.FindElement(_path).SendKeys(_field);
        }

        public void elementExists(By _button)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementExists(_button)); // Espera hasta que el elemento exista en el DOM
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
       
        public void WaitExistsVisible(By pathExists, By pathOverlay)
        {
            elementExists(pathExists);
            WaitForElementVisible(pathOverlay);
        }

        public void enterDate(By path, string option)
        {
            WaitExistsVisible(path, AdditionalElements.OverlayElement);
            enterField(path, option);
            driver.FindElement(path).SendKeys(Keys.Enter);
            Thread.Sleep(4000);
        }

        public void click(By component)
        {
            IWebElement dropdown = driver.FindElement(component);
            dropdown.Click();
        }

        public void dataEntryAndEnter(By component, string option)
        {
            enterField(component, option);
            driver.FindElement(component).SendKeys(Keys.Enter);
        }

        public void SelectOption2(By _pathConcept, By _pathFieldConcept, string option)
        {
            click(_pathConcept);
            dataEntryAndEnter(_pathFieldConcept, option);    
        }
        public void Registered(By buttonRegistered, By FieldRegistered, string option)
        {
            click(buttonRegistered);
            Thread.Sleep(4000);
            click(FieldRegistered);
            dataEntryAndEnter(FieldRegistered, option);
        }
        public void cantidad(By cantidad, string valor)
        {
            Thread.Sleep(2000);
            enterField(cantidad, valor);
            Thread.Sleep(2000);
            driver.FindElement(cantidad).SendKeys(Keys.Enter);
        }

        public void PaymentMethodUtility(By _path, string _option)
        {
            switch (_option)
            {
                case "DEPCU":

                    buttonClickeable(_path);
                    break;

                case "TRANFON":

                    buttonClickeable(_path);
                    break;

                case "TDEB":

                    buttonClickeable(_path);
                    break;

                case "TCRE":

                    buttonClickeable(_path);
                    break;

                case "EF":

                    buttonClickeable(_path);
                    break;
                case "PTS":

                    buttonClickeable(_path);
                    break;

                default:
                    throw new ArgumentException($"El {_path} no es válido");
            }
        }

        public string ViewPaymentMethod()
        {
            // Encuentra el contenedor con los botones de radio
            var medioPagoContainer = driver.FindElement(By.Id("medioPago0"));

            // Encuentra todos los botones de radio dentro del contenedor
            var radioButtons = medioPagoContainer.FindElements(By.CssSelector("input[type='radio']"));

            // Itera por cada botón de radio para verificar cuál está seleccionado
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Selected) // Verifica si el botón está seleccionado
                {
                    // Encuentra el label asociado al botón de radio seleccionado
                    var label = driver.FindElement(By.CssSelector($"label[for='{radioButton.GetAttribute("id")}']"));

                    // Retorna el texto del label (DEPCU, TRANFON, etc.)
                    return label.Text;
                }
            }
            // Si no se selecciona nada, retorna una cadena vacía o lanza una excepción si es necesario
            return string.Empty;
        }

        public void SelectOption(By _path, string option)
        {
            try
            {
                // Esperar que el menú desplegable sea visible
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(_path));

                // Abre el menú desplegable
                IWebElement dropdown = driver.FindElement(_path);
                dropdown.Click();

                // Espera explícita para que las opciones sean visibles
                wait.Until(ExpectedConditions.ElementIsVisible(AdditionalElements.SelectODropdownOptions));

                // Selecciona la opción deseada
                IWebElement optionElement = driver.FindElement(By.XPath($"//li[contains(text(), '{option}')]"));
                optionElement.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Error: No se encontró la opción '{option}' en el menú desplegable. Detalle: {ex.Message}");
            }
        }

        public void barCodeConcept(string value)
        {
            enterDate(Concept.BarcodeInputField, value);
        }

        public void SelectConcept(string value)
        {
            Thread.Sleep(4000);
            SelectOption(Concept.ConceptSelection, value);
        }
    }
}
