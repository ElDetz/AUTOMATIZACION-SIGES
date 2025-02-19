using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SigesCore.Hooks.XPaths;
using System.IO;

namespace SigesCore.Hooks.Utility
{
    public class UtilityVenta
    {
        private IWebDriver driver;
        WebDriverWait wait;

        public UtilityVenta(IWebDriver driver, int timeoutInSeconds = 150)
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

        public void EnterField(By path, string value)
        {
            if (driver.FindElements(path).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {path} no se encontró.");
            }

            wait.Until(ExpectedConditions.ElementIsVisible(path)); // Espera hasta que el elemento sea visible
            driver.FindElement(path).SendKeys(Keys.Control + "a");
            driver.FindElement(path).SendKeys(Keys.Delete);
            driver.FindElement(path).Clear();
            driver.FindElement(path).SendKeys(value);
        }

        public void EnterFieldModal(By pathModal, By pathComponent, string value)
        {
            Thread.Sleep(3000);
            IWebElement orderModal = driver.FindElement(pathModal);
            orderModal.FindElement(pathComponent).Clear();
            orderModal.FindElement(pathComponent).SendKeys(value);
            orderModal.FindElement(pathComponent).SendKeys(Keys.Enter);
        }

        public void CleanFieldModal(By pathModal, By pathComponent, string value)
        {
            Thread.Sleep(3000);
            IWebElement orderModal = driver.FindElement(pathModal);
            orderModal.FindElement(pathComponent).SendKeys(Keys.Control + "a");
            orderModal.FindElement(pathComponent).SendKeys(Keys.Delete);
            orderModal.FindElement(pathComponent).Clear();
            orderModal.FindElement(pathComponent).SendKeys(value);
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementToBeClickable(button)); // Espera hasta que el elemento sea clickeable
            driver.FindElement(button).Click();
        }

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

        public void Registered(By buttonRegistered, By fieldRegistered, string option)
        {
            ClickUility(buttonRegistered);
            Thread.Sleep(4000);
            ClickUility(fieldRegistered);
            DataEntryAndEnter(fieldRegistered, option);
        }

        public void Quantity(By quantity, string value)
        {
            Thread.Sleep(2000);
            EnterField(quantity, value);
            Thread.Sleep(2000);
            driver.FindElement(quantity).SendKeys(Keys.Enter);
        }

        public void CashPayment()
        {
            ClickButton(PaymentTypePath.CashPaymentOption);
        }

        public void QuickCreditPayment()
        {
            ClickButton(PaymentTypePath.QuickPaymentOption);
        }

        public void ConfiguredCreditPayment()
        {
            ClickButton(PaymentTypePath.ConfiguredPaymentOption);
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
            Thread.Sleep(5000);
        }

        public void EnterDateClick(By pathInput, By pathName, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement Input = wait.Until(ExpectedConditions.ElementToBeClickable(pathInput));
            IWebElement Name = wait.Until(ExpectedConditions.ElementToBeClickable(pathName));
            Input.Click();
            Input.SendKeys(value);
            Name.Click();
        }

        public void SelectInvoiceType(By path, string option)
        {
            option = option.ToUpper();
            ElementExists(path);

            switch (option)
            {
                case "BOLETA":

                    SelectOption(path, option);
                    Thread.Sleep(4000);
                    break;

                case "FACTURA":

                    SelectOption(path, option);
                    Thread.Sleep(4000);
                    break;

                case "NOTA":

                    SelectOption(path, option);
                    Thread.Sleep(4000);
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }
        }

        public void EnterCardDetailsNewSale(string typeBank, string typeCard, string info)
        {
            string option = ViewPaymentMethod();  // Obtiene el tipo de medio de pago seleccionado
            option = option.ToUpper();

            switch (option)
            {
                case "TDEB":

                    SelectOption(DebitPaymentNewSale.BankSelector, typeBank);
                    SelectOption(DebitPaymentNewSale.CardSelector, typeCard);
                    EnterField(DebitPaymentNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TCRE":

                    SelectOption(CreditPaymentNewSale.BankSelector, typeBank);
                    SelectOption(CreditPaymentNewSale.CardSelector, typeCard);
                    EnterField(CreditPaymentNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "DEPCU":

                    SelectOption(DepositNewSale.BankSelector, typeBank);
                    EnterField(DepositNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TRANFON":

                    SelectOption(TransferNewSale.BankSelector, typeBank);
                    EnterField(TransferNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "EF":

                    EnterField(CashNewSale.Received, info);
                    Thread.Sleep(4000);
                    break;

                case "PTS":
                    break;

                default:
                    throw new ArgumentException($"El tipo de pago {option} no es válido.");
            }
        }

        //INGRESAR DETALLES DEL PAGO (VENTA POR CONTINGENCIA)
        public void EnterCardDetailsContingency(string typeBank, string typeCard, string info)
        {
            string option = ViewPaymentMethod();
            option = option.ToUpper();

            switch (option)
            {
                case "TDEB":

                    SelectOption(DebitPaymentContingency.BankSelector, typeBank);
                    SelectOption(DebitPaymentContingency.CardSelector, typeCard);
                    EnterField(DebitPaymentContingency.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TCRE":

                    SelectOption(CreditPaymentNewSale.BankSelector, typeBank);
                    SelectOption(CreditPaymentNewSale.CardSelector, typeCard);
                    EnterField(CreditPaymentNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "DEPCU":

                    SelectOption(DepositNewSale.BankSelector, typeBank);
                    EnterField(DepositNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "TRANFON":

                    SelectOption(TransferNewSale.BankSelector, typeBank);
                    EnterField(TransferNewSale.PaymentDetails, info);
                    Thread.Sleep(4000);
                    break;

                case "EF":

                    EnterField(CashNewSale.Received, info);
                    Thread.Sleep(4000);
                    break;

                case "PTS":
                    break;

                default:
                    throw new ArgumentException($"El tipo de pago {option} no es válido.");
            }
        }

        public void OptionsSelector(By pathModal, By pathComponent, string value)
        {
            Thread.Sleep(4000);
            IWebElement modalFacturacion = driver.FindElement(pathModal);

            IWebElement dropdown = modalFacturacion.FindElement(pathComponent);
            Console.WriteLine("Campo seleccion encontrada");
            IReadOnlyCollection<IWebElement> dropdownOptions = dropdown.FindElements(ConfiguredCreditPopup.Option);
            Console.WriteLine("Selecciones extraidas");
            foreach (IWebElement option in dropdownOptions)
            {
                if (option.Text.Equals(value))
                    option.Click();
            }
            Console.WriteLine("seleccion terminada");
            Thread.Sleep(4000);
        }

        public void WaitForModalAndVerifyField(By path)
        {
            IWebElement modalContainer = driver.FindElement(ConfiguredCreditPopup.Modal);
            ElementExists(path);
            WaitForOverlayToDisappear(AdditionalElements.OverlayElement);
        }

        public void CustomerType(By pathModal, By pathCustomer, By pathAlias, string option, string value)
        {
            option = option.ToUpper();

            if (option == "DNI" || option == "RUC")
            {
                EnterFieldModal(pathModal, pathCustomer, value);
            }
            else if (option == "ALIAS")
            {
                EnterFieldModal(pathModal, pathAlias, value);
            }
            else if (option == "VARIOS")
            {
            }
            else
            {
                throw new ArgumentException($"El {option} no es válido");
            }
        }

        public void CheckBox(By pathModal, By pathComponent, string option)
        {
            IWebElement orderModal = driver.FindElement(pathModal);
            option = option.ToUpper();
            if (option == "SI")
            {
                orderModal.FindElement(pathComponent).Click();
            }
            else if (option == "NO")
            {

            }
            else
            {
                throw new ArgumentException($"El {option} no es válido");
            }
        }
    }
}
