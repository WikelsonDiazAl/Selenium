using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public class Logiin
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By LoginnButton = By.ClassName("global_action_link");
        protected By UserInput = By.CssSelector("input[type='text']");
        protected By PasswordInput = By.CssSelector("input[type='password']");
        protected By LoginButton = By.ClassName("DjSvCZoKKfoNSmarsEcTS");
        protected By SuccessIndicator = By.CssSelector("a.menuitem.supernav.username");
        protected By ErrorMessage = By.CssSelector("div._1W_6HXiG4JJ0By1qN_0fGZ");

        public Logiin(IWebDriver driver)
        {
            Driver = driver;

        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Login");
            Directory.CreateDirectory(rutaCarpeta);
            string rutaCompleta = Path.Combine(rutaCarpeta, $"{nombreArchivo}.png");
            screenshot.SaveAsFile(rutaCompleta);
            Console.WriteLine($"Captura de pantalla guardada en: {rutaCompleta}");
        }

        public void ClickBotonn()
        {
            CapturarPantalla("Pantalla principal");
            Driver.FindElement(LoginnButton).Click();
            CapturarPantalla("Cargando login");
        }


        public void UsarNombre(string user)
        {
            CapturarPantalla("pantalla login");
            Driver.FindElement(UserInput).SendKeys(user);
            CapturarPantalla("Usuario ingresado");
        }

        public void UsarContraseña(string password)
        {
            Driver.FindElement(PasswordInput).SendKeys(password);
            CapturarPantalla("contraseña ingresada ");
        }

        public void ClickBoton()
        {
            Driver.FindElement(LoginButton).Click();
            System.Threading.Thread.Sleep(5000);

        }

        public void ClickBotonConEspera()
        {
            Driver.FindElement(LoginButton).Click();
            CapturarPantalla("Sesion_Iniciando");
        }
        
        public PaginaItla LoginAs(string user, string password)
        {
             ClickBotonn();
             UsarNombre(user);
             UsarContraseña(password);
              ClickBoton();
            return new PaginaItla(Driver);
        }

        public bool VerificarLoginExitoso()
        {
            try
            {
                Driver.FindElement(SuccessIndicator);
                CapturarPantalla("sesion iniciada");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool VerificarLoginFallido()
        {
            try
            {
                Driver.FindElement(ErrorMessage);
                CapturarPantalla("Error sesion");
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

}

