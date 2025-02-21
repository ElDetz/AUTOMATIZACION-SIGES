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

        /// <summary>
        /// Función que espera hasta que el overlay desaparezca de la pantalla.
        /// </summary>
        /// <param name="overlayLocator">Localizador del overlay a esperar.</param>
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

        /// <summary>
        /// Función que ingresa un valor en un campo de texto asegurando que el campo esté visible y limpio antes de escribir.
        /// </summary>
        /// <param name="pathComponent">Localizador del campo de texto.</param>
        /// <param name="value">Valor a ingresar en el campo.</param>
        public void EnterField(By pathComponent, string value)
        {
            if (driver.FindElements(pathComponent).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {pathComponent} no se encontró.");
            }
            wait.Until(ExpectedConditions.ElementIsVisible(pathComponent));
            driver.FindElement(pathComponent).SendKeys(Keys.Control + "a");
            driver.FindElement(pathComponent).SendKeys(Keys.Delete);
            driver.FindElement(pathComponent).Clear();
            driver.FindElement(pathComponent).SendKeys(value);
        }

        public void InputAndEnter(By pathComponent, string value)
        {
            EnterField(pathComponent, value);
            driver.FindElement(pathComponent).SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Función que ingresa un valor en un campo de texto dentro de un modal, asegurando que el campo esté limpio antes de escribir.
        /// </summary>
        /// <param name="pathModal">Localizador del modal donde se encuentra el campo.</param>
        /// <param name="pathComponent">Localizador del campo de texto dentro del modal.</param>
        /// <param name="value">Valor a ingresar en el campo.</param>
        public void EnterFieldModal(By pathModal, By pathComponent, string value)
        {
            Thread.Sleep(3000);
            IWebElement orderModal = driver.FindElement(pathModal);
            orderModal.FindElement(pathComponent).Clear();
            orderModal.FindElement(pathComponent).SendKeys(value);
            orderModal.FindElement(pathComponent).SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Función que limpia un campo de texto dentro de un modal y luego ingresa un nuevo valor.
        /// Utiliza la función EnterField para realizar la acción de limpieza y escritura.
        /// </summary>
        /// <param name="pathModal">Localizador del modal donde se encuentra el campo.</param>
        /// <param name="pathComponent">Localizador del campo de texto dentro del modal.</param>
        /// <param name="value">Valor a ingresar en el campo después de limpiarlo.</param>
        public void CleanFieldModal(By pathModal, By pathComponent, string value)
        {
            Thread.Sleep(3000);
            IWebElement orderModal = driver.FindElement(pathModal);
            EnterField(pathComponent, value);
        }

        /// <summary>
        /// Función que verifica si un elemento existe en la página dentro del tiempo de espera definido.
        /// Lanza una excepción si el elemento no se encuentra dentro del tiempo límite.
        /// </summary>
        /// <param name="pathComponent">Localizador del elemento a verificar.</param>
        public void ElementExists(By pathComponent)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementExists(pathComponent)); 
            }
            catch (WebDriverTimeoutException)
            {
                throw new NoSuchElementException($"El elemento con el localizador {pathComponent} no se encontró dentro del tiempo esperado.");
            }
        }

        /// <summary>
        /// Función que hace clic en un botón si este es visible y está disponible para interactuar.
        /// Lanza una excepción si el botón no se encuentra en la página.
        /// </summary>
        /// <param name="pathButton">Localizador del botón a hacer clic.</param>
        public void ClickButton(By pathButton)
        {
            if (driver.FindElements(pathButton).Count == 0)
            {
                throw new NoSuchElementException($"El elemento con el localizador {pathButton} no se encontró.");
            }
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementToBeClickable(pathButton)); 
            driver.FindElement(pathButton).Click();
        }

        /// <summary>
        /// Función que espera hasta que un elemento sea visible en la página.
        /// Lanza una excepción si el elemento no se hace visible dentro del tiempo de espera.
        /// </summary>
        /// <param name="locator">Localizador del elemento a esperar.</param>
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

        /// <summary>
        /// Función que espera a que un elemento exista y luego a que un overlay sea visible.
        /// Invoca las funciones ElementExists y WaitForElementVisible para verificar la existencia y visibilidad del elemento.
        /// </summary>
        /// <param name="pathExists">Localizador del elemento cuya existencia se debe verificar.</param>
        /// <param name="pathOverlay">Localizador del overlay que debe hacerse visible.</param>
        public void WaitExistsVisible(By pathComponent, By pathOverlay)
        {
            ElementExists(pathComponent);
            WaitForElementVisible(pathOverlay);
        }

        /// <summary>
        /// Función que ingresa una fecha en un campo de entrada.
        /// Primero espera que el elemento exista y sea visible, luego ingresa el valor y confirma con Enter.
        /// Invoca las funciones WaitExistsVisible y EnterField.
        /// </summary>
        /// <param name="path">Localizador del campo de fecha.</param>
        /// <param name="option">Valor de la fecha a ingresar.</param>
        public void EnterDate(By pathComponent, string option)
        {
            WaitExistsVisible(pathComponent, AdditionalElements.OverlayElement);
            InputAndEnter(pathComponent, option);
            Thread.Sleep(4000);
        }

        /// <summary>
        /// Función que selecciona un método de pago en función de la opción proporcionada.
        /// </summary>
        /// <param name="path">Localizador del botón del método de pago.</param>
        /// <param name="option">Código del método de pago (DEPCU, TRANFON, TDEB, TCRE, EF, PTS).</param>
        /// <exception cref="ArgumentException">Se lanza si la opción no es válida.</exception>
        public void PaymentMethodUtility(By pathComponent, string option)
        {
            switch (option)
            {
                case "DEPCU":

                    ClickButton(pathComponent);
                    break;

                case "TRANFON":

                    ClickButton(pathComponent);
                    break;

                case "TDEB":

                    ClickButton(pathComponent);
                    break;

                case "TCRE":

                    ClickButton(pathComponent);
                    break;

                case "EF":

                    ClickButton(pathComponent);
                    break;
                case "PTS":

                    ClickButton(pathComponent);
                    break;

                default:
                    throw new ArgumentException($"El {pathComponent} no es válido");
            }
        }

        /// <summary>
        /// Función que obtiene el método de pago seleccionado en la interfaz.
        /// </summary>
        /// <returns>El texto del método de pago seleccionado o una cadena vacía si no hay ninguno seleccionado.</returns>
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

        /// <summary>
        /// Función que selecciona una opción dentro de un menú desplegable.
        /// </summary>
        /// <param name="pathComponent">Localizador del elemento desplegable.</param>
        /// <param name="option">Texto de la opción que se desea seleccionar.</param>
        public void SelectOption(By pathComponent, string option)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(pathComponent));

                IWebElement dropdown = driver.FindElement(pathComponent);
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

        /// <summary>
        /// Función que ingresa un valor en un campo de entrada y luego hace clic en otro componente 
        /// para asegurar que el dato ingresado se guarde correctamente.
        /// </summary>
        /// <param name="pathInput">Localizador del campo de entrada donde se ingresará el valor.</param>
        /// <param name="pathName">Localizador del componente en el que se hará clic después de ingresar el dato.</param>
        /// <param name="value">Valor que se ingresará en el campo de entrada.</param>
        public void EnterDateClick(By pathInput, By pathName, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement Input = wait.Until(ExpectedConditions.ElementToBeClickable(pathInput));
            IWebElement Name = wait.Until(ExpectedConditions.ElementToBeClickable(pathName));
            Input.Click();
            Input.SendKeys(value);
            Name.Click();
        }

        /// <summary>
        /// Función que selecciona un tipo de comprobante de pago en un menú desplegable.
        /// </summary>
        /// <param name="path">Localizador del elemento del menú desplegable.</param>
        /// <param name="option">Tipo de comprobante a seleccionar (BOLETA, FACTURA o NOTA).</param>
        /// <exception cref="ArgumentException">Se lanza si la opción ingresada no es válida.</exception>
        public void SelectInvoiceType(By pathComponent, string option)
        {
            option = option.ToUpper();
            ElementExists(pathComponent);

            switch (option)
            {
                case "BOLETA":

                    SelectOption(pathComponent, option);
                    Thread.Sleep(4000);
                    break;

                case "FACTURA":

                    SelectOption(pathComponent, option);
                    Thread.Sleep(4000);
                    break;

                case "NOTA":

                    SelectOption(pathComponent, option);
                    Thread.Sleep(4000);
                    break;

                default:
                    throw new ArgumentException($"El {option} no es válido");
            }
        }

        /// <summary>
        /// Función que ingresa los detalles de pago según el método de pago seleccionado.
        /// </summary>
        /// <param name="typeBank">Nombre del banco a seleccionar (para pagos con tarjeta, depósito o transferencia).</param>
        /// <param name="typeCard">Tipo de tarjeta a seleccionar (para pagos con tarjeta).</param>
        /// <param name="info">Información adicional del pago (número de referencia, monto, etc.).</param>
        /// <exception cref="ArgumentException">Se lanza si el método de pago no es válido.</exception>
        public void EnterCardDetailsNewSale(string typeBank, string typeCard, string info)
        {
            string option = ViewPaymentMethod();
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

        /// <summary>
        /// Selecciona una opción dentro de un componente desplegable dentro de un modal específico.
        /// </summary>
        /// <param name="pathModal">Localizador del modal contenedor del componente.</param>
        /// <param name="pathComponent">Localizador del componente desplegable dentro del modal.</param>
        /// <param name="value">Texto de la opción que se desea seleccionar.</param>
        public void OptionsSelector(By pathModal, By pathComponent, string value)
        {
            Thread.Sleep(4000);
            IWebElement modalFacturacion = driver.FindElement(pathModal);
            IWebElement dropdown = modalFacturacion.FindElement(pathComponent);
            IReadOnlyCollection<IWebElement> dropdownOptions = dropdown.FindElements(ConfiguredCreditPopup.Option);
            foreach (IWebElement option in dropdownOptions)
            {
                if (option.Text.Equals(value))
                    option.Click();
            }
        }

        /// <summary>
        /// Espera a que un modal esté presente y verifica que un campo específico dentro de él exista.
        /// </summary>
        /// <param name="pathModal">Localizador del modal contenedor.</param>
        /// <param name="pathComponent">Localizador del componente dentro del modal que debe verificarse.</param>
        public void WaitForModalAndVerifyField(By pathModal,By pathComponent)
        {
            IWebElement modalContainer = driver.FindElement(pathModal);
            ElementExists(pathComponent);
            WaitForOverlayToDisappear(AdditionalElements.OverlayElement);
        }


        /// <summary>
        /// Espera a que un modal esté presente, verifica que un campo específico exista y luego ingresa un valor en dicho campo.
        /// </summary>
        /// <param name="pathModal">Localizador del modal contenedor.</param>
        /// <param name="pathComponent">Localizador del campo dentro del modal donde se ingresará el valor.</param>
        /// <param name="value">Valor a ingresar en el campo.</param>
        public void WaitModalAndEnterField(By pathModal, By pathComponent, string value)
        {
            WaitForModalAndVerifyField(pathModal, pathComponent);
            EnterField(pathComponent, value);
        }

        /// <summary>
        /// Maneja el ingreso de datos según el tipo de cliente seleccionado en un modal.
        /// </summary>
        /// <param name="pathModal">Localizador del modal contenedor.</param>
        /// <param name="pathCustomer">Localizador del campo de identificación del cliente (DNI/RUC).</param>
        /// <param name="pathAlias">Localizador del campo de alias del cliente.</param>
        /// <param name="option">Tipo de cliente (DNI, RUC, ALIAS, VARIOS).</param>
        /// <param name="value">Valor a ingresar en el campo correspondiente.</param>
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

        /// <summary>
        /// Maneja la selección de un checkbox dentro de un modal según la opción proporcionada.
        /// </summary>
        /// <param name="pathModal">Localizador del modal contenedor.</param>
        /// <param name="pathComponent">Localizador del checkbox a seleccionar.</param>
        /// <param name="option">Opción que indica si se debe marcar el checkbox ("SI") o dejarlo sin cambios ("NO").</param>
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

        /// <summary>
        /// Selecciona el tipo de entrega dentro de un modal según la opción proporcionada.
        /// </summary>
        /// <param name="pathModal">Localizador del modal contenedor.</param>
        /// <param name="pathImmediate">Localizador del botón de entrega inmediata.</param>
        /// <param name="pathDeferred">Localizador del botón de entrega diferida.</param>
        /// <param name="option">Opción de entrega a seleccionar: "INMEDIATA" o "DIFERIDA".</param>
        public void SelectDeliveryType(By pathModal, By pathImmediate, By pathDeferred, string option)
        {
            IWebElement orderModal = driver.FindElement(pathModal);
            option = option.ToUpper();
            if (option == "INMEDIATA")
            {
                orderModal.FindElement(pathImmediate).Click();
            }
            else if (option == "DIFERIDA")
            {
                orderModal.FindElement(pathDeferred).Click();
            }
            else
            {
                throw new ArgumentException($"El {option} no es válido");
            }
        }
    }
}
