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
        public static readonly By EmailInputField = By.XPath("//input[@id='Email']");

        public static readonly By PasswordInputField = By.XPath("//input[@id='Password']");

        public static readonly By SignInButton = By.XPath("//button[contains(text(),'Iniciar')]");

        public static readonly By ConfirmButton = By.XPath("//button[contains(text(),'Aceptar')]");
    }

    public class SalesModule
    {
        public static readonly By SalesMenu = By.XPath("//span[contains(text(),'Venta')]");

        public static readonly By NewSaleLink = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[1]/a[1]");

        public static readonly By SaleCashModeLink = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[2]/a[1]");

        public static readonly By ContingencySaleLink = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[3]/a[1]");

        public static readonly By ViewSalesLink = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[4]/a[1]");

        public static readonly By SellerReportLink = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[5]/a[1]");

        public static readonly By PointsReportLink = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[6]/a[1]");

        public static readonly By ManagerReportLink = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[7]/a[1]");

        public static readonly By ReportsMenu = By.XPath("//body/div[@id='wrapper']/aside[1]/div[1]/section[1]/ul[1]/li[1]/ul[1]/li[8]/a[1]");
    }

    public class Concept
    {
        public static readonly By codeBarraField = By.XPath("//input[@id='idCodigoBarra']");

        public static readonly By pathInputFieldConcept = By.XPath("//input[@class='select2-search__field']");

        public static readonly By pathConcept = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/registrador-detalles[1]/div[1]/div[1]/selector-concepto-comercial[1]/ng-form[1]/div[1]/div[3]/div[1]/div[1]/span[1]/span[1]/span[1]");

        public static readonly By QuantityInputField = By.XPath("//input[@id='cantidad-0']");
    }
    public class CheckBox
    {
        public static readonly By CheckboxIGV = By.XPath("//input[@id='ventaigv0']");
        public static readonly By CheckboxUnifiedDetail = By.XPath("//input[@id='detalleunificado0']");
    }
    public class Extras
    {
        public static readonly By SelectOptions = By.CssSelector(".select2-results__options");
        public static readonly By overlayLocator = By.ClassName("block-ui-overlay");
        public static readonly By SelectOptionsXPath = By.CssSelector(".select2-results__options");
        public static readonly By saveSale = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/div[2]/div[1]");
    }

    public class Dates
    {
        public static readonly By ClientField = By.XPath("//input[@id='DocumentoIdentidad']");

        public static readonly By AliasField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[5]/input[1]");

        public static readonly By RegisteredCustomerButton = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[1]/a[3]");

        public static readonly By RegisteredCustomerField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/selector-actor-comercial[1]/ng-form[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]");  
    }

    public class Voucher
    {
        public static readonly By DocField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");

        public static readonly By DocInputField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[2]/span[1]/span[1]/input[1]");
    }

    public class PayMethod
    {
        public static readonly By payment = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]");
        public static readonly By contado = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        public static readonly By rapido = By.XPath("/html[1]/body[1]/div[1]/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/input[1]");
        public static readonly By configurado = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]");

        public static readonly By contado2 = By.CssSelector("#radio1");
        public static readonly By rapido2 = By.CssSelector("#radio2");
        public static readonly By configurado2 = By.CssSelector("#radio3");
    }

    public class PaymentMethodPath
    {
        public static readonly By DepositButton = By.XPath("//label[@id='labelMedioPago-0-14']");

        public static readonly By TransferButton = By.XPath("//label[@id='labelMedioPago-0-16']");

        public static readonly By DebitCardButton = By.XPath("//label[@id='labelMedioPago-0-18']");

        public static readonly By CreditCardButton = By.XPath("//label[@id='labelMedioPago-0-19']");

        public static readonly By CashButton = By.XPath("//label[@id='labelMedioPago-0-281']");

        public static readonly By PointsButton = By.XPath("//label[@id='labelMedioPago-0-13901']");
    }

    public class Debito
    {
        public static readonly By bankFieldTdeb = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[1]/span[1]/span[1]");

        public static readonly By cardFieldTdeb = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[2]/span[1]/span[1]");

        public static readonly By infoMethod1FieldTdeb = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/textarea[1]");
    }

   public class Efectivo
    {
        public static readonly By efectivo = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[2]/div[1]/input[1]");
    }

    public class Deposit
    {
        public static readonly By BankSelector = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[8]/div[1]/span[1]/span[1]/span[1]");

        public static readonly By PaymentDetails = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[8]/div[1]/textarea[1]");
    }

    public class Transfer
    {
        public static readonly By BankSelector = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[7]/div[1]/span[1]/span[1]/span[1]");

        public static readonly By PaymentDetails = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[7]/div[1]/textarea[1");
    }
    public class DebitPayment
    {
        public static readonly By BankSelector = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[1]/span[1]/span[1]");

        public static readonly By CardSelector = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/span[2]/span[1]/span[1]");

        public static readonly By PaymentDetails = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[6]/div[1]/textarea[1]");
    }

    public class CreditPayment
    {
        public static readonly By BankSelector = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[5]/div[1]/span[1]/span[1]/span[1]");

        public static readonly By CardSelector = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[5]/div[1]/span[2]/span[1]/span[1]");

        public static readonly By PaymentDetails = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[5]/div[1]/textarea[1]");
    }

    public class Cash
    {
        public static readonly By Received = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[8]/editor-pago[1]/div[1]/div[1]/div[1]/div[1]/editor-traza-pago[1]/div[1]/div[2]/div[1]/input[1]");
    }




}
