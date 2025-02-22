using System;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using RESTAURANTE.Hoks.Pages;

namespace RESTAURANTE.StepDefinitions
{
    [Binding]
    public class AccesAppStepDefinitions
    {
        IWebDriver driver;
        AccessPage accessPage;

        public AccesAppStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            accessPage = new AccessPage(driver);
        }

        [Given(@"Inicio de sesi�n con usuario '([^']*)' y contrase�a '([^']*)'")]
        public void Login(string _user, string _password)
        {
            accessPage.LoginToApplication(_user, _password);
        }

        /*
        [Given(@"Inicio de sesion con usuario")]
        public void GivenInicioDeSesionConUsuario(Table table)
        {
            driver.Url = "https://tintoymadero-qa.sigesonline.com/";

            dynamic data = table.CreateInstance<dynamic>();

            // Realizar el inicio de sesi�n
            loginPage.LoginToApplication(data.Username, data.Password);
        }
        */

        [Given(@"Se ingresa al m�dulo '([^']*)'")]
        public void GivenSeIngresaAlModulo(string _modulo)
        {
            accessPage.enterModulo(_modulo);
        }
    }
}
