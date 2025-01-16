using FluentAssertions.Equivalency;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;
using NUnit.Framework;

namespace PruebaConcepto.Hoks.PagesPruebaConcepto
{
    public class RegistroVentaPage
    {
        private IWebDriver driver;

        public RegistroVentaPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By SelecOptions = By.CssSelector(".select2-results__options");
        
        // Element locators
        By salesButton = By.XPath("//span[contains(text(),'Venta')]");
        By newSaleButton = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[1]/a[1]");
        By codeBarraField = By.XPath("//input[@id='idCodigoBarra']");
        By dniField = By.XPath("//input[@id='DocumentoIdentidad']");

        By tranfonButton = By.XPath("/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/label[2]");
        By infoTranfonField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[7]/div[1]/textarea[1]");

        By tdebButton = By.XPath("/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/label[3]");

        By bankButton = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[1]/span[1]/span[1]");

        By bankField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[3]/span[1]/span[1]/input[1]");

        //TARJETA
        private readonly By cardField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[2]/span[1]/span[1]");


        By infoTdebField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/textarea[1]");

 

        By saveSaleButton = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/div[2]/div[1]");

        public void EnterField(By _path, string _field)
        {
            driver.FindElement(_path).Clear();
            driver.FindElement(_path).SendKeys(_field);
            driver.FindElement(_path).SendKeys(Keys.Enter);
        }

        public void ClickButton(By _button)
        {
            driver.FindElement(_button).Click();
        }

        // Método para realizar el inicio de sesión completo
        public void CompleteFields(string codeBarra, string dni)
        {
            ClickButton(salesButton);
            Thread.Sleep(2000);

            ClickButton(newSaleButton);
            Thread.Sleep(4000);

            EnterField(codeBarraField, codeBarra);
            Thread.Sleep(4000);

            EnterField(dniField, dni);
            Thread.Sleep(4000);
        }
        public void PaymentTypeCC()
        {
            
        }

        public void SelecOption(By _path, string option)
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
                wait.Until(ExpectedConditions.ElementIsVisible(SelecOptions));

                // Selecciona la opción deseada
                IWebElement optionElement = driver.FindElement(By.XPath($"//li[contains(text(), '{option}')]"));
                optionElement.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Error: No se encontró la opción '{option}' en el menú desplegable. Detalle: {ex.Message}");
            }
        }




        public void PaymentMethodTranfon(string info)
        {
            ClickButton(tranfonButton);
            Thread.Sleep(4000);
            EnterField(infoTranfonField, info);
            Thread.Sleep(4000);
            ClickButton(saveSaleButton);
            Thread.Sleep(2000);

        }

        public void PaymentMethodTdeb(string info, string typeBank, string typeCard)
        {
            ClickButton(tdebButton);
            Thread.Sleep(4000);
            driver.FindElement(bankButton).Click();
            Thread.Sleep(4000);

            // Banco
            Thread.Sleep(4000);
            IWebElement dropdownBank = driver.FindElement(bankField);
            //dropdownBank.Click();
            Thread.Sleep(4000);

            SelecOption(bankField, typeBank);
            SelecOption(cardField, typeCard);
    
            Thread.Sleep(4000);
            EnterField(infoTdebField, info);
            Thread.Sleep(4000);
            ClickButton(saveSaleButton);
            Thread.Sleep(2000);

        }

        /*
        public void SelecOption(By _path, string option)
        {
            // Esperar que el menú desplegable sea visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_path));
            IWebElement dropdownPath = driver.FindElement(_path);

            // Encuentra el elemento del menú desplegable
            IWebElement dropdownOptions = driver.FindElement(SelecOptions);

            Thread.Sleep(4000);
            EnterField(infoTdebField, info);
            Thread.Sleep(4000);
            ClickButton(saveSaleButton);
            Thread.Sleep(2000);

            // Haz clic en la opción deseada
            optionElement.Click();

        }
        */
    }
}
