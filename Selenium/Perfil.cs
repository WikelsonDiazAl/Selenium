using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public class Perfil
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By LoginnButton = By.ClassName("global_action_link");
        protected By UserInput = By.CssSelector("input[type='text']");
        protected By PasswordInput = By.CssSelector("input[type='password']");
        protected By LoginButton = By.ClassName("DjSvCZoKKfoNSmarsEcTS");
        protected By Irperfil = By.CssSelector("a.menuitem.supernav.username");
        protected By BotonMenuDesplegable = By.Id("account_pulldown");
        protected By EnlacePerfil = By.CssSelector("a.popup_menu_item[href*='/profiles/']");



        public Perfil(IWebDriver driver)
        {
            Driver = driver;

        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Perfil");
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
        }

        public PaginaItla LoginAs(string user, string password)
        {
            ClickBotonn();
            UsarNombre(user);
            UsarContraseña(password);
            ClickBoton();
            return new PaginaItla(Driver);
        }

        public void IrPerfil()
        {
            var botonMenu = Driver.FindElement(BotonMenuDesplegable);
            botonMenu.Click();
            CapturarPantalla("Menu desplegable abierto");

            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Wait.Until(driver =>
            {
                try
                {
                    var elemento = driver.FindElement(EnlacePerfil);
                    return elemento.Displayed && elemento.Enabled;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            var enlacePerfil = Driver.FindElement(EnlacePerfil);
            enlacePerfil.Click();
            CapturarPantalla("Perfil abierto");
        }


    }
}
