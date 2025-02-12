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

        [When("Preparar Orden")]
        public void WhenPrepararOrden()
        {
            //throw new PendingStepException();
        }

        [Then("Servir ordens")]
        public void ThenServirOrdens()
        {
            //throw new PendingStepException();
        }
    }
}
