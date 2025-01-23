using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace RESTAURANTE.Hoks.Pages
{
    public class UtilityPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public UtilityPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Inicializamos WebDriverWait aquí
        }

        //By restauranteField = By.XPath("//span[contains(text(),'Restaurante')]");

        By restauranteField = By.XPath("//a[@class='menu-lista-cabecera']/span[text()='Restaurante']");

        By atencionField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[1]/a[1]");
        By preparacionField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[2]/a[1]");
        
        By cajaField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[3]/a[1]");
        //By cajaField = By.XPath("//ul[@class='treeview-menu']//a[normalize-space(text())='Caja']");

        By complementosField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[3]/a[1]");
        By reportesField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[2]/ul[1]/li[5]/a[1]");

        public void ClickButton(By _button)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(_button));

            driver.FindElement(_button).Click();
        }

        // Método para realizar el inicio de sesión completo
        public void enterModulo(string _modulo)
        {
            // Clic en "Restaurante"
            ClickButton(restauranteField);

            // Clic en "Caja"
            ClickButton(cajaField);

            Thread.Sleep(4000);
        }
    }
}
