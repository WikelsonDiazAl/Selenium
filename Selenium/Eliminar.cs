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
    public class Eliminar
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By CCorreo = By.Id("Correo");
        protected By CClave = By.Id("Clave");
        protected By btnsesion = By.Id("btnsesion");
        protected By btnEliminar = By.Id("Eliminar");
        protected By btnconfirmar = By.Id("modalEliminar");



        public Eliminar(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Eliminar");
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

        }

        public void SesionUsuario(string correo, string clave)
        {

            IngresarCorreo(correo);
            IngresarClave(clave);

        }

        public void BotonEliminar()
        {
            IWebElement botonEliminar = Driver.FindElement(btnEliminar);

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", botonEliminar);

            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Confirmacion");
        }

        public void BotonConfirmar()
        {
            Driver.FindElement(btnconfirmar).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Eliminado");
        }
    }
}
