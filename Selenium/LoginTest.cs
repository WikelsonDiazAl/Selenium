using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium
{
    [TestFixture]
    public class LoginTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void BeforeTest()
        {
            
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            Driver.Navigate().GoToUrl("https://store.steampowered.com/");
        }

        [Test]
        public void LoginExitoso()
        {
            Logiin logiin = new Logiin(Driver);

            logiin.LoginAs("wikelson1", "Fulanitoelmejor1-");

            if (logiin.VerificarLoginExitoso())
            {
                Console.WriteLine("Login exitoso: el elemento esperado está presente.");
            }
            else
            {
                Console.WriteLine("Error: Login fallido, el elemento esperado no está presente.");
            }
        }

        [Test]
        public void LoginFallido()
        {
            Logiin logiin = new Logiin(Driver);

            logiin.LoginAs("wikelson2", "Fulanitoelmejor1");

            if (logiin.VerificarLoginFallido())
            {
                Console.WriteLine("Login fallido correctamente: se muestra el mensaje de error.");
            }
            else
            {
                Console.WriteLine("Error: No se muestra el mensaje de error, el login no falló como se esperaba.");
            }
        }

        [Test]
        public void BuscarConResultados()
        {
            Busqueda busqueda = new Busqueda(Driver);

            busqueda.Buscar("Hollow knight");
            
            try
            {
                IWebElement resultados = Driver.FindElement(By.Id("search_resultsRows"));
                Console.WriteLine("Se encontraron resultados.");
                busqueda.CapturarPantalla("Resultados encontrados");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No se encontraron resultados.");
            }
        }

        [Test]
        public void BuscarSinResultados()
        {
 
            Busqueda busqueda = new Busqueda(Driver);

            busqueda.Buscar("El fulanitomejor");


            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement noResultsMessage = wait.Until(d => d.FindElement(By.CssSelector(".search_results_count")));

            if (noResultsMessage.Text.Contains("0 resultados coinciden con la búsqueda"))
            {
                Console.WriteLine("No se encontraron resultados.");
                busqueda.CapturarPantalla("Resultados no encontrados");
            }
            else
            {
                Console.WriteLine("Se encontraron resultados.");
            }

            busqueda.CapturarPantalla("Juego no encontrado");
        }

        [Test]
        public void Carrito()
        {

            Comprar comprar = new Comprar(Driver);

            comprar.Seleccion();

            comprar.Botoncompra();

            comprar.Botoncarrito();

            comprar.Botonrcompras();
        }

        [Test]
        public void ListaDeseo()
        {
            ListaDeseo listadeseo = new ListaDeseo(Driver);

            listadeseo.LoginAs("wikelson1", "Fulanitoelmejor1-");

            listadeseo.Seleccionar();

            listadeseo.AñadirLLista();

            listadeseo.Lista();

            listadeseo.Quitar();
        }

        [Test]
        public void Perfil()
        {
            Perfil perfil = new Perfil(Driver);

            perfil.LoginAs("wikelson1", "Fulanitoelmejor1-");

            perfil.IrPerfil();


        }

        [TearDown]
        public void AfterTest()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

    }

}
