using OpenQA.Selenium;


namespace RESTAURANTE.Hoks.Pages
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

        By usernameField = By.XPath("//input[@id='Email']"); // campo de usuario
        By passwordField = By.XPath("//input[@id='Password']"); // campo de contraseña
        By loginButton = By.XPath("//button[contains(text(),'Iniciar')]"); // botón de inicio de sesión 
        By aceptarButton = By.XPath("//button[contains(text(),'Aceptar')]"); // botón de aceptar

        // Método para realizar el Inicio de sesión
        public void LoginToApplication(string _user, string _password)
        {
            utilityPage.enterField(usernameField, _user); // campo user
            utilityPage.enterField(passwordField, _password); // campo contraseña

            utilityPage.buttonClickeable(loginButton); // boton login
            utilityPage.buttonClickeable(aceptarButton); // boton aceptar
        }
    }
}
