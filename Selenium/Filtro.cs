using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public class Filtro
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By CCorreo = By.Id("Correo");
        protected By CClave = By.Id("Clave");
        protected By btnsesion = By.Id("btnsesion");
        protected By barrafiltro = By.Id("BarraFiltro");
        protected By btnAplicar = By.Id("btnFiltro");



        public Filtro(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Filtro");
            Directory.CreateDirectory(rutaCarpeta);
            string rutaCompleta = Path.Combine(rutaCarpeta, $"{nombreArchivo}.png");
            screenshot.SaveAsFile(rutaCompleta);
            Console.WriteLine($"Captura de pantalla guardada en: {rutaCompleta}");
        }

        public void IngresarCorreo(string correo)
        {
            System.Threading.Thread.Sleep(3000);
            Driver.FindElement(CCorreo).SendKeys(correo);
        }

        public void IngresarClave(string clave)
        {
            Driver.FindElement(CClave).SendKeys(clave);
            System.Threading.Thread.Sleep(3000);
        }

        public void ClickRegistrarBoton()
        {
            Driver.FindElement(btnsesion).Click();
            System.Threading.Thread.Sleep(10000);
            CapturarPantalla("Barra de filtro");

        }

        public void SesionUsuario(string correo, string clave)
        {

            IngresarCorreo(correo);
            IngresarClave(clave);

        }

        public void IngresarTitulo(string titulo)
        {
            Driver.FindElement(barrafiltro).SendKeys(titulo);
            System.Threading.Thread.Sleep(3000);
            CapturarPantalla("titulo correcto");
        }

        public void IngresarTituloerror(string titulo)
        {
            Driver.FindElement(barrafiltro).SendKeys(titulo);
            System.Threading.Thread.Sleep(3000);
            CapturarPantalla("titulo incorrecto");
        }

        public void BotonFiltro()
        {
            Driver.FindElement(btnAplicar).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("encontrado");
        }

        public void BotonFiltroerror()
        {
            Driver.FindElement(btnAplicar).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("no encontrado");

        }

    }
}
