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
    public class Editar
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By CCorreo = By.Id("Correo");
        protected By CClave = By.Id("Clave");
        protected By btnsesion = By.Id("btnsesion");
        protected By btnEditar = By.Id("Editar");
        protected By CTitulo = By.Id("Titulo");
        protected By botonAñadir = By.Id("BotonAñadir");



        public Editar(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Editar");
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

        public void BtnEditar()
        {
            IWebElement botonEditar = Driver.FindElement(btnEditar);

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", botonEditar);

            System.Threading.Thread.Sleep(5000);
        }


        public void IngresarTitulo(string titulo)
        {
            Driver.FindElement(CTitulo).SendKeys(titulo);
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Titulo editado");
        }

        public void BtnAñadir()
        {
            Driver.FindElement(botonAñadir).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Editado");
        }

        public void AgregarVivencia(string titulo)
        {

            IngresarTitulo(titulo);


        }


    }
}
