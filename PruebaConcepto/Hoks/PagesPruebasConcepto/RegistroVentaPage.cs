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

        public void EnterField(By _path,string _field)
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

        public void SelecOption(By _path, string option)
        {
            IWebElement dropdownPath = driver.FindElement(_path);

            // Encuentra el elemento del menú desplegable
            IWebElement dropdownOptions = driver.FindElement(SelecOptions);

            // Usa el valor del parámetro 'option' para construir dinámicamente el XPath
            IWebElement optionElement = driver.FindElement(By.XPath($"//li[contains(text(), '{option}')]"));

            // Haz clic en la opción deseada
            optionElement.Click();

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

            SelecOption(bankField,typeBank);
            SelecOption(cardField, typeCard);


            

            /*
            driver.FindElement(bankField).SendKeys("BBVA");
            driver.FindElement(bankField).SendKeys(Keys.Enter);*/


            /*
            driver.FindElement(By.Id("idEntidadFinanciera"));

            IWebElement dropdownElement = driver.FindElement(By.Id("idEntidadFinanciera"));
            Thread.Sleep(4000);
            SelectElement selector = new SelectElement(dropdownElement);
            Thread.Sleep(4000);
            selector.SelectByText("BBVA  CONTINENTAL");
            */

            //TARJETA
            /*
            IWebElement invoiceElement = driver.FindElement(typeCard);
            Thread.Sleep(4000);
            
            Thread.Sleep(4000);
            invoiceElement.SendKeys("MASTER CARD");
            Thread.Sleep(4000);
            invoiceElement.SendKeys(Keys.Enter);
            */


            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            /*
            // Paso 1: Clic en el menú desplegable
            Thread.Sleep(4000);
            IWebElement dropdownTrigger = driver.FindElement(typeCard);
            dropdownTrigger.Click();
            Thread.Sleep(4000);

            // Paso 2: Esperar hasta que las opciones sean visibles
            IWebElement dropdownOptions = driver.FindElement(By.CssSelector(".select2-results__options"));

            // Paso 3: Seleccionar la opción deseada (por ejemplo, "MASTER CARD")
            IWebElement masterCardOption = driver.FindElement(By.XPath("//li[contains(text(), 'MASTER CARD')]"));
            masterCardOption.Click();
            */

            //TARJETA
            /*
            string methodTarjeta = "VISA";

            var dropdownTarjeta = new SelectElement(driver.FindElement(By.Id("idEntidadFinanciera")));
            Thread.Sleep(4000);
            dropdownTarjeta.SelectByText(methodTarjeta);
            Assert.That(dropdownTarjeta.SelectedOption.Text, Is.EqualTo("VISA"));
            */




            /*
            driver.FindElement(bankField).SendKeys("BBVA");
            driver.FindElement(bankField).SendKeys(Keys.Enter);
            */

            /*
            IWebElement dropdownElement = driver.FindElement(By.Id("idEntidadFinanciera"));
            Thread.Sleep(4000);
            // Crear una instancia de SelectElement
            SelectElement dropdown = new SelectElement(dropdownElement);
            Thread.Sleep(4000);
            // Seleccionar la opción "BBVA CONTINENTAL"
            dropdown.SelectByText("BBVA CONTINENTAL");
            Thread.Sleep(4000);*/


            /*
            switch (invoiceType)
            {
                case "BV":
                    invoiceElement.SendKeys("Boleta de venta");
                    break;
                case "FE":
                    invoiceElement.SendKeys("Factura Electronica");
                    break;
                case "NV":
                    invoiceElement.SendKeys("Nota de venta");
                    break;
                default:
                    break;
            }*/


            Thread.Sleep(4000);
            EnterField(infoTdebField, info);
            Thread.Sleep(4000);
            ClickButton(saveSaleButton);
            Thread.Sleep(2000);

            /*
            IWebElement dropdownOptions1 = driver.FindElement(By.CssSelector(".select2-results__options"));

            IWebElement masterCardOption1 = driver.FindElement(By.XPath("//li[contains(text(), 'BBVA  CONTINENTAL')]"));
            masterCardOption1.Click();*/
        }

    }
}
