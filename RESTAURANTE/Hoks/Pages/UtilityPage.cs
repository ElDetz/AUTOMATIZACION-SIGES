using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace RESTAURANTE.Hoks.Pages
{
    public class UtilityPage
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public UtilityPage(IWebDriver driver, int timeoutInSeconds = 20)
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

        public void VisibilidadElement(By _path)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(_path)); 

                //buttonClickeable(_button);
            }
            catch (WebDriverTimeoutException)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_path} visibilidad no se encontró dentro del tiempo esperado.");
            }
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

        // Esperar a que la ventana modal esté visible
        public IWebElement WaitForModal(string modalId, int timeout = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.Id(modalId)));
        }
        
        // Clic en un botón dentro del modal
        public void ClickButtonInModal(By buttonLocator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(buttonLocator));
            wait.Until(ExpectedConditions.ElementToBeClickable(buttonLocator)); // Espera hasta que el elemento sea clickeable
            driver.FindElement(buttonLocator).Click();
        }

        public void addFieldModal(IWebElement _element, By _path, string _field)
        {
            if (driver.FindElements(_path).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_path} no se encontró.");
            }

            wait.Until(ExpectedConditions.ElementIsVisible(_path)); // Espera hasta que el elemento sea visible
            _element.FindElement(_path).Clear();
            _element.FindElement(_path).SendKeys(_field);
        }

        public void enterFieldModal(IWebElement _element, By _path, string _field)
        {
            if (driver.FindElements(_path).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {_path} no se encontró.");
            }

            wait.Until(ExpectedConditions.ElementIsVisible(_path)); // Espera hasta que el elemento sea visible
            _element.FindElement(_path).Clear();
            _element.FindElement(_path).SendKeys(_field);
            _element.FindElement(_path).SendKeys(Keys.Enter);
        }

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

        public void SelecOption(IWebElement _element, By _path, string option)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(_path));
                wait.Until(ExpectedConditions.ElementToBeClickable(_path));

                _element.FindElement(_path).Click();

                /*
                // Abre el menú desplegable
                IWebElement dropdown = _element.FindElement(_path);
                //dropdown.Click();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", dropdown);
                */

                // Espera explícita para que las opciones sean visibles
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-results__options")));

                // Selecciona la opción deseada
                IWebElement optionElement = _element.FindElement(By.XPath($"//li[contains(text(), '{option}')]"));
                optionElement.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Error: No se encontró la opción '{option}' en el menú desplegable. Detalle: {ex.Message}");
            }
        }

    }
}
