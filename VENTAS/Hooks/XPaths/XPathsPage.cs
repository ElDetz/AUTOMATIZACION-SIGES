using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigesCore.Hooks.XPaths
{
    public class Login
    {
        public static readonly By usernameField = By.XPath("//input[@id='Email']");

        public static readonly By passwordField = By.XPath("//input[@id='Password']"); 

        public static readonly By loginButton = By.XPath("//button[contains(text(),'Iniciar')]");
        
        public static readonly By aceptarButton = By.XPath("//button[contains(text(),'Aceptar')]");
    }

    public class ModuloVenta
    {
        public static readonly By VentasField = By.XPath("//span[contains(text(),'Venta')]");

        public static readonly By NuevaVentaField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[1]/a[1]");

        public static readonly By VentaModoCajaField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[2]/a[1]");

        public static readonly By VentaContingenciaField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[3]/a[1]");

        public static readonly By VerVentasField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[4]/a[1]");

        public static readonly By ReportesVendedorField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[5]/a[1]");

        public static readonly By ReportesPuntosField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[6]/a[1]");

        public static readonly By ReportesGerenteField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[7]/a[1]");

        public static readonly By ReportesField = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[8]/a[1]");

        public static readonly By SelectOptions = By.CssSelector(".select2-results__options");
    }

     


    
}
