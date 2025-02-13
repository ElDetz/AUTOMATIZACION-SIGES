using System;
using OpenQA.Selenium;
using Reqnroll;
using RESTAURANTE.Hoks.Pages.Facturacion;
using RESTAURANTE.Hoks.Pages.Preparacion;

namespace RESTAURANTE.StepDefinitions
{
    [Binding]
    public class PreparacionStepDefinitions
    {
        private IWebDriver driver;
        PreparacionPage preparacionPage;

        public PreparacionStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            preparacionPage = new PreparacionPage(driver);
        }


        [When("Se procede a {string} las siguientes ordenes:")]
        public void WhenSeProcedeAElSiguientePedido(string _accion, DataTable dataTable)
        {

            foreach (var row in dataTable.Rows)
            {
                string _orden = row["ORDEN"];
                string _item = row["ITEM"];

                Console.WriteLine($"Procesando orden {_orden}: {_item}");

                preparacionPage.seleccionOrden( _orden, _item);
            }

            preparacionPage.accionRealizar(_accion);

        }

        [When("Se procede a {string} todos los items de la orden {string}")]
        public void WhenSeProcedeATodosLosItemsDeLaOrden(string _accion, string _nOrden)
        {
            preparacionPage.seleccionOrdenes(_nOrden);
            preparacionPage.accionRealizar(_accion);
        }

        [Then("Servir ordens")]
        public void ThenServirOrdens()
        {
            //throw new PendingStepException();
        }
    }
}
