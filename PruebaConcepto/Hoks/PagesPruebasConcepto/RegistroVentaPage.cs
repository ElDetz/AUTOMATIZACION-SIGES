using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConcepto.Hoks.PagesPruebaConcepto
{
    public class RegistroVentaPage
    {
        private IWebDriver driver;

        public RegistroVentaPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Element locators
        By salesButton = By.XPath("//span[contains(text(),'Venta')]"); 
        By newSaleButton = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[1]/a[1]"); 
        By codeBarraField = By.XPath("//input[@id='idCodigoBarra']");
        By dniField = By.XPath("//input[@id='DocumentoIdentidad']");

        By infoTranfonButton = By.XPath("/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/label[2]");
        By infoTranfonField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[7]/div[1]/textarea[1]"); 

        By saveSaleButton = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/div[2]/div[1]");

        public void ClicksalesButton()
        {
            driver.FindElement(salesButton).Click();
        }

        public void ClicknewSaleButton()
        {
            driver.FindElement(newSaleButton).Click();
        }

        public void EnterCodeBarra(string code)
        {
            driver.FindElement(codeBarraField).SendKeys(code);
            driver.FindElement(codeBarraField).SendKeys(Keys.Enter);
        }

        public void EnterDni(string dni)
        {
            driver.FindElement(dniField).Clear();
            driver.FindElement(dniField).SendKeys(dni);
            driver.FindElement(dniField).SendKeys(Keys.Enter);
        }

        public void ClickinfoTranfonButton()
        {
            driver.FindElement(infoTranfonButton).Click();
        }
        public void EnterinfoTranfon(string info)
        {
            driver.FindElement(infoTranfonField).SendKeys(info);
        }

        public void ClicksaveSaleButton()
        {
            driver.FindElement(saveSaleButton).Click();
        }

        // Método para realizar el inicio de sesión completo
        public void newSale(string codeBarra, string dni, string info)
        {
            ClicksalesButton();
            Thread.Sleep(2000);
            ClicknewSaleButton();
            Thread.Sleep(4000);
            EnterCodeBarra(codeBarra);
            Thread.Sleep(4000);
            EnterDni(dni);
            Thread.Sleep(4000);
            ClickinfoTranfonButton();
            Thread.Sleep(4000);
            EnterinfoTranfon(info);
            Thread.Sleep(4000);
            ClicksaveSaleButton();
            Thread.Sleep(4000);
        }
    }
}
