using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigesCore.Features.Ventas;
using SigesCore.Hooks.XPaths;
using SigesCore.Hooks.Utility;

namespace SigesCore.Hooks.LoginPage
{
    public class LoginPage
    {
        private IWebDriver _driver;
        UtilityPage utilityPage;
        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            this.utilityPage = new UtilityPage(driver);
        }
     
        public void LoginToApplication(string _user, string _password)
        {
            utilityPage.enterField(Login.usernameField, _user);
            utilityPage.enterField(Login.passwordField, _password);
            utilityPage.buttonClickeable(Login.loginButton);
            utilityPage.buttonClickeable(Login.aceptarButton);
        }
    }
}