using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Selenium
{
    public class ListaDeseo
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By LoginnButton = By.ClassName("global_action_link");
        protected By UserInput = By.CssSelector("input[type='text']");
        protected By PasswordInput = By.CssSelector("input[type='password']");
        protected By LoginButton = By.ClassName("DjSvCZoKKfoNSmarsEcTS");
        protected By Seleccion = By.CssSelector("a[data-ds-appid='2195410']");
        protected By Añadir = By.CssSelector("a.btnv6_blue_hoverfade.btn_medium.add_to_wishlist");
        protected By Irlista = By.Id("wishlist_link");
        protected By quitar = By.CssSelector("button.nK8lTB5HZ5o-.Focusable");

        public ListaDeseo(IWebDriver driver)
        {
            Driver = driver;

        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "ListaDeseos");
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

        public void Seleccionar()
        {
            Driver.FindElement(Seleccion).Click();
        }

        public void AñadirLLista()
        {
            CapturarPantalla("Juegoa");
            Driver.FindElement(Añadir).Click();
            CapturarPantalla("Juego añadido");
        }

        public void Lista()
        {
            CapturarPantalla("Lista");
            Driver.FindElement(Irlista).Click();
            CapturarPantalla("Lista de deseo");
        }

        public void Quitar()
        {
            Driver.FindElement(quitar).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Sin juegos añadidos");
        }
        
    }
}
