using System;
using OpenQA.Selenium;
using Reqnroll;
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

        [Given("Se realiza la busqueda de la ultima orden registrada {int}")]
        public void GivenSeRealizaLaBusquedaDeLaUltimaOrdenRegistrada(int _nOrden)
        {
            preparacionPage.scrollElement(_nOrden);
        }

        [When("Se procede a {string} la orden")]
        public void WhenSeProcedeALaOrden(string _accion)
        {
            preparacionPage.accionPreparacion(_accion);
        }

        [Then("Servir ordens")]
        public void ThenServirOrdens()
        {
            //throw new PendingStepException();
        }
    }
}
