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
        private IWebDriver driver;
        UtilityPage utilityPage;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.utilityPage = new UtilityPage(driver);
        }

        public void LoginToApplication(string email, string password)
        {
            utilityPage.EnterField(Login.EmailInputField, email);
            utilityPage.EnterField(Login.PasswordInputField, password);
            utilityPage.ClickButton(Login.SignInButton);
            utilityPage.ClickButton(Login.ConfirmButton);
        }
    }
}