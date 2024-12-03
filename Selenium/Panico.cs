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
    public class Panico
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected By CCorreo = By.Id("Correo");
        protected By CClave = By.Id("Clave");
        protected By btnsesion = By.Id("btnsesion");
        protected By btnañadir = By.Id("añadir");
        protected By CTitulo = By.Id("Titulo");
        protected By CDescripcion = By.Id("Descripcion");
        protected By CUrl = By.Id("Imagen");
        protected By botonAñadir = By.Id("BotonAñadir");
        protected By btnpanico = By.Id("btnPanico");
        protected By barrapanico = By.Id("barraclave");
        protected By btn = By.Id("btnEliminar");


        public Panico(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        public void CapturarPantalla(string nombreArchivo)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "Boton panico");
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
            CapturarPantalla("Boton de panico");

        }

        public void SesionUsuario(string correo, string clave)
        {

            IngresarCorreo(correo);
            IngresarClave(clave);

        }

        public void IngresarTitulo(string titulo)
        {
            Driver.FindElement(CTitulo).SendKeys(titulo);
        }

        public void IngresarDescripcion(string descripcion)
        {
            Driver.FindElement(CDescripcion).SendKeys(descripcion);

        }

        public void IngresarUrl(string url)
        {
            Driver.FindElement(CUrl).SendKeys(url);
            System.Threading.Thread.Sleep(5000);

        }

        public void Añadir()
        {
            Driver.FindElement(btnañadir).Click();
            System.Threading.Thread.Sleep(5000);
        }

        public void BtnAñadir()
        {
            Driver.FindElement(botonAñadir).Click();
            System.Threading.Thread.Sleep(5000);
        }

        public void AgregarVivencia(string titulo, string descripcion, string url)
        {

            IngresarTitulo(titulo);
            IngresarDescripcion(descripcion);
            IngresarUrl(url);

        }

        public void BotonPanico()
        {
            Driver.FindElement(btnpanico).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Barra para ingresar clave");
        }

        public void BotonPanicoerror()
        {
            Driver.FindElement(btnpanico).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Barra para ingresar clave");
        }

        public void Barra(string contraseña)
        {
            Driver.FindElement(barrapanico).SendKeys(contraseña);
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Clave ingresada");
        }

        public void BotonEliminar()
        {
            Driver.FindElement(btn).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Todo eliminado");
        }

        public void BotonEliminarerror()
        {
            Driver.FindElement(btn).Click();
            System.Threading.Thread.Sleep(5000);
            CapturarPantalla("Error");
        }



    }
}
