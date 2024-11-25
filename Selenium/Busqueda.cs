using NUnit.Framework;
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
    public class Busqueda
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By barra = By.Id("store_nav_search_term");
        protected By boton = By.Id("store_search_link");

        public Busqueda(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Busqueda");
            Directory.CreateDirectory(rutaCarpeta);
            string rutaCompleta = Path.Combine(rutaCarpeta, $"{nombreArchivo}.png");
            screenshot.SaveAsFile(rutaCompleta);
            Console.WriteLine($"Captura de pantalla guardada en: {rutaCompleta}");
        }

        public void Buscar(string game)
        {
           
            CapturarPantalla("pantalla principal");
            Driver.FindElement(barra).SendKeys(game);

            Driver.FindElement(barra).SendKeys(Keys.Enter);
        }
    }
}
