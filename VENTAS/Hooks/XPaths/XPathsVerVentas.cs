using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigesCore.Hooks.XPaths
{
    public class RedeemVoucher
    {
        public static readonly By modal = By.Id("modal-canje-de-comprobante");

        public static readonly By initialDate = By.XPath("//input[@id='fechaInicio']");

        public static readonly By finalDate = By.XPath("//input[@id='fechaFin']");

        public static readonly By salesQueryButton = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[4]/button[1]");

        public static readonly By searchSale = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[2]/div[1]/label[1]/input[1]");

        public static readonly By activateRedeemPath = By.XPath("//input[@id='canjeComprobante']");

        public static readonly By selectedSalePath = By.XPath("//tbody/tr[1]/td[1]/div[1]/input[1]");

        public static readonly By redeemButton = By.XPath("//button[contains(text(),'CANJEAR')]");

        public static readonly By voucherType = By.CssSelector("select.tipoDocumento");

        public static readonly By acceptRedeemButton = By.XPath("//body/div[4]/div[1]/div[1]/div[1]/div[3]/button[1]");   
    }

    public class DebitNote
    {

    }

    public class CreditNote
    {

    }

    public class InvalidateSale
    {

    }

    public class CloneSale
    {

    }

    public class PrintSale
    {

    }

    public class DownloadSale
    {

    }

    public class SendSale
    {

    }
}
