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

        [Given(@"Inicio de sesión con usuario '([^']*)' y contraseña '([^']*)'")]
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

            // Realizar el inicio de sesión
            loginPage.LoginToApplication(data.Username, data.Password);
        }
        */

        [Given(@"Se ingresa al módulo '([^']*)'")]
        public void GivenSeIngresaAlModulo(string _modulo)
        {
            accessPage.enterModulo(_modulo);
        }
    }
}
