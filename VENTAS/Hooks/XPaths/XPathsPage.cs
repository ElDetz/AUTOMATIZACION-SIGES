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

    }
    public class Concept
    {
        public static readonly By codeBarraField = By.XPath("//input[@id='idCodigoBarra']");
        public static readonly By pathInputFieldConcept = By.XPath("//input[@class='select2-search__field']");
        public static readonly By pathConcept = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/registrador-detalles[1]/div[1]/div[1]/selector-concepto-comercial[1]/ng-form[1]/div[1]/div[3]/div[1]/div[1]/span[1]/span[1]/span[1]");
    }
    public class CheckBox
    {
        public static readonly By checkboxIGV = By.XPath("//input[@id='ventaigv0']");
        public static readonly By checkboxDetUnif = By.XPath("//input[@id='detalleunificado0']");
    }
    public class Extras
    {
        public static readonly By SelectOptions = By.CssSelector(".select2-results__options");
        public static readonly By overlayLocator = By.ClassName("block-ui-overlay");
        public static readonly By SelectOptionsXPath = By.CssSelector(".select2-results__options");
    }

    public class Dates
    {
        public static readonly By clientField = By.XPath("//input[@id='DocumentoIdentidad']");
        public static readonly By aliasField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[5]/input[1]");
        public static readonly By RegisteredCustomer = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[1]/a[3]");
        public static readonly By RegisteredCustomerField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]");  
    }

    public class Comprobante
    {
        public static readonly By docField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");
        public static readonly By docInputField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[2]/span[1]/span[1]/input[1]");
    }

    public class PayMethod
    {
        public static readonly By payment = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]");
        public static readonly By contado = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        public static readonly By rapido = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/input[1]");
        public static readonly By configurado = By.Id("radio3");

        public static readonly By contado2 = By.CssSelector("#radio1");
        public static readonly By rapido2 = By.CssSelector("#radio2");
        public static readonly By configurado2 = By.CssSelector("#radio3");
    }





}
