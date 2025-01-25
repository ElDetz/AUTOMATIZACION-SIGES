using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace RESTAURANTE.Hoks.Pages.Facturacion
{
    public class FacturacionPage
    {
        private IWebDriver driver;
        UtilityPage utilityPage;

        public FacturacionPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilityPage = new UtilityPage(driver);
        }

        private By overlayLocator = By.ClassName("block-ui-overlay");

        private By facturarAtencionButton = By.XPath("//tbody/tr[1]/td[9]/a[1]/span[1]");
        //private By facturarAtencionButton = By.CssSelector("a.btn.btn-success.btn-sm[ng-click='iniciarFacturacion(item)']");



        public void typeFactura(string _typeFactura)
        {
            // Boton Facturar
            utilityPage.elementExists(facturarAtencionButton);
            utilityPage.WaitForOverlayToDisappear(overlayLocator);
            utilityPage.buttonClickeable(facturarAtencionButton);
        }

        // TIPO COMPROBANTE DE PAGO
        public void typeComprobante(By _path, string _option)
        {
            utilityPage.SelecOption(_path, _option);
        }

        // MODO DE PAGO
        public void moodPay(By _path, string _option)
        {
            switch (_option)
            {
                case "DEPCU":

                    utilityPage.buttonClickeable(_path);
                    break;

                case "TRANFON":

                    utilityPage.buttonClickeable(_path);
                    break;

                case "TDEB":

                    utilityPage.buttonClickeable(_path);
                    break;

                case "TCRE":

                    utilityPage.buttonClickeable(_path);
                    break;

                case "EF":

                    utilityPage.buttonClickeable(_path);
                    break;

                default:
                    throw new ArgumentException($"El {_path} no es válido");
            }

        }

        //MODO DE PAGO TARJETA TDEB TCRE
        public void datosCard(By _bankField, string _bank, By _cardField, string _card, By _infoField, string _info)
        {
            utilityPage.SelecOption(_bankField, _bank); // SELECCION BANCO
            utilityPage.SelecOption(_cardField, _card); // SELECCION TARJETA
            utilityPage.SelecOption(_infoField, _info); // AGREGA INFO
        }

        public void Facturar()
        {
            //ClickButton(saveSaleButton); // GUARDAR VENTA
            Thread.Sleep(2000);
        }
    }
}
