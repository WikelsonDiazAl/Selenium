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
    public class Comprar
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By seleccion = By.CssSelector("a[data-ds-appid='2961880']");
        protected By botoncompra = By.Id("btn_add_to_cart_1054464");
        protected By botoncarrito = By.CssSelector("button.DialogButton._DialogLayout.Primary.Focusable");
        protected By botonrcompras = By.ClassName("_3YCgcpoCojlbS6DvkNsG2J");

        public Comprar(IWebDriver driver)
        {
            Driver = driver;
        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Carrito");
            Directory.CreateDirectory(rutaCarpeta);
            string rutaCompleta = Path.Combine(rutaCarpeta, $"{nombreArchivo}.png");
            screenshot.SaveAsFile(rutaCompleta);
            Console.WriteLine($"Captura de pantalla guardada en: {rutaCompleta}");
        }

        public void Seleccion()
        {
            
            Driver.FindElement(seleccion).Click();
            CapturarPantalla("Seleccion juego");
        }

        public void Botoncompra()
        {
            CapturarPantalla("Juego");
            Driver.FindElement(botoncompra).Click();
            CapturarPantalla("Añadir carrito");
        }

        public void Botoncarrito()
        {
            Driver.FindElement(botoncarrito).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Ir a carrito");
        }

        public void Botonrcompras()
        {
            Driver.FindElement(botonrcompras).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Sin lista");
        }
    }
}
