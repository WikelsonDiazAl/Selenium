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
    public class Registro
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By Registrar = By.CssSelector("a#linkk");
        protected By CUsuario = By.Id("Usuario");
        protected By CCorreo = By.Id("Correo");
        protected By CClave = By.Id("Clave");
        protected By btnRegistro = By.Id("registrar");


        public Registro(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Registro");
            Directory.CreateDirectory(rutaCarpeta);
            string rutaCompleta = Path.Combine(rutaCarpeta, $"{nombreArchivo}.png");
            screenshot.SaveAsFile(rutaCompleta);
            Console.WriteLine($"Captura de pantalla guardada en: {rutaCompleta}");
        }

        public void IngresarUsuario(string usuario)
        {
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Formulario");
            Driver.FindElement(CUsuario).SendKeys(usuario);
        }

        public void IngresarCorreo(string correo)
        {
            Driver.FindElement(CCorreo).SendKeys(correo);
        }

        public void IngresarClave(string clave)
        {
            Driver.FindElement(CClave).SendKeys(clave);
        }

        public void ClickRegistrarBoton()
        {
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Formulario lleno");
            Driver.FindElement(btnRegistro).Click();
            
        }

        public void ClickRegistrarBotonfallido()
        {
            Driver.FindElement(btnRegistro).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Formulario vacio");
        }


        public void RegistrarUsuario(string usuario, string correo, string clave)
        {
            IngresarUsuario(usuario);
            IngresarCorreo(correo);
            IngresarClave(clave);
            ClickRegistrarBoton();
            CapturarPantalla("Exito");
        }

        public void RegistrarUsuariofallido(string usuario, string correo, string clave)
        {
            IngresarUsuario(usuario);
            IngresarCorreo(correo);
            IngresarClave(clave);
            ClickRegistrarBotonfallido();
            CapturarPantalla("Error");
        }

    }

}

