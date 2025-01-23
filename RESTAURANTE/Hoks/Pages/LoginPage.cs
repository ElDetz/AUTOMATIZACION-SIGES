﻿using OpenQA.Selenium;


namespace RESTAURANTE.Hoks.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
     
        By usernameField = By.XPath("//input[@id='Email']"); // campo de usuario
        By passwordField = By.XPath("//input[@id='Password']"); // campo de contraseña
        By loginButton = By.XPath("//button[contains(text(),'Iniciar')]"); // botón de inicio de sesión 
        By aceptarButton = By.XPath("//button[contains(text(),'Aceptar')]"); // botón de aceptar

        public void EnterField(By _path, string _field)
        {
            driver.FindElement(_path).SendKeys(_field);
        }

        public void ClickButton(By _button)
        {
            driver.FindElement(_button).Click();
        }

        // Método para realizar el Inicio de sesión
        public void LoginToApplication(string _user, string _password)
        {
            EnterField(usernameField, _user);
            EnterField(passwordField, _password);
            Thread.Sleep(4000);
            ClickButton(loginButton);
            Thread.Sleep(4000);
            ClickButton(aceptarButton);
            Thread.Sleep(4000);
        }
    }
}
