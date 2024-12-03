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
    public class InicioSesion
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By CCorreo = By.Id("Correo");
        protected By CClave = By.Id("Clave");
        protected By btnsesion = By.Id("btnsesion");


        public InicioSesion(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Inicio de sesion");
            Directory.CreateDirectory(rutaCarpeta);
            string rutaCompleta = Path.Combine(rutaCarpeta, $"{nombreArchivo}.png");
            screenshot.SaveAsFile(rutaCompleta);
            Console.WriteLine($"Captura de pantalla guardada en: {rutaCompleta}");
        }

        public void IngresarCorreo(string correo)
        {

            CapturarPantalla("Formulario");
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
            CapturarPantalla("Informacion correcta");
            Driver.FindElement(btnsesion).Click();
            System.Threading.Thread.Sleep(5000);
           
        }

        public void ClickRegistrarBotonfallido()
        {
            Driver.FindElement(btnsesion).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Error");
        }


        public void SesionUsuario(string correo, string clave)
        {
 
            IngresarCorreo(correo);
            IngresarClave(clave);
            ClickRegistrarBoton();

        }

        public void SesionUsuariofallido(string correo, string clave)
        {

            IngresarCorreo(correo);
            IngresarClave(clave);
            ClickRegistrarBotonfallido();
        }
    }
}
