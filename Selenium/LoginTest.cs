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
        }

        [Test]
        public void RegistroExitoso()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Registrar");
            Registro logiin = new Registro(Driver);

            string usuario = "Marcos";
            string correo = "Marcos@gmail.com";
            string clave = "ContraseñaSegura1-";

            logiin.RegistrarUsuario(usuario, correo, clave);

           
        }

        [Test]
        public void RegistroFallido()
        {

            Driver.Navigate().GoToUrl("http://localhost:5206/Registrar");
            Registro logiin = new Registro(Driver);

            string usuario = "";
            string correo = "";
            string clave = "";

            logiin.RegistrarUsuariofallido(usuario, correo, clave);


        }

        [Test]
        public void SesionExitoso()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            InicioSesion logiin = new InicioSesion(Driver);

 
            string correo = "Jose@gmail.com";
            string clave = "Jose123";

            logiin.SesionUsuario(correo, clave);

        }

        [Test]
        public void SesionFallido()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            InicioSesion logiin = new InicioSesion(Driver);

            string correo = "Manuel@gmail.com";
            string clave = "holajaja3";

            logiin.SesionUsuariofallido(correo, clave);


        }

        [Test]
        public void AgregarExito()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            Agregar logiin = new Agregar(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();
            logiin.Añadir();

            
            logiin.AgregarVivencia("Minecraft", "Hoy jugué Minecraft y construí una casa en la cima de una montaña. Me tomó un tiempo conseguir los materiales, pero al final quedó perfecta. También exploré una cueva oscura y encontré diamantes, aunque casi me atrapa un Creeper. Fue divertido y me sentí como un verdadero constructor y aventurero.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSz5LBHSKh1RbicnjEqppICIGRbey-yF4ZMhg&s");
            logiin.CapturarPantalla("Formulario lleno");
            logiin.BtnAñadir();
            

        }

        [Test]
        public void AgregarFallido()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            Agregar logiin = new Agregar(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();
            logiin.Añadir();


            logiin.AgregarVivenciaerror("", "", "");

            logiin.BtnAñadirerror();

        }

        [Test]
        public void EditarExitoso()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            Editar logiin = new Editar(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();

            logiin.BtnEditar();

            logiin.AgregarVivencia("Titulo modificado");

            logiin.BtnAñadir();

        }

        [Test]
        public void EliminarExitoso()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            Eliminar logiin = new Eliminar(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();

            logiin.BotonEliminar();

            logiin.BotonConfirmar();

        }

        [Test]
        public void FiltroExitoso()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            Filtro logiin = new Filtro(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();

            logiin.IngresarTitulo("minecraft");

            logiin.BotonFiltro();

        }

        [Test]
        public void FiltroExitosoFallido()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            Filtro logiin = new Filtro(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();

            logiin.IngresarTituloerror("hola");

            logiin.BotonFiltroerror();

        }

        [Test]
        public void ConteoExitoso()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            Conteo logiin = new Conteo(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();

            logiin.Añadir();

            logiin.AgregarVivencia("Minecraft", "Hoy jugué Minecraft y construí una casa en la cima de una montaña. Me tomó un tiempo conseguir los materiales, pero al final quedó perfecta. También exploré una cueva oscura y encontré diamantes, aunque casi me atrapa un Creeper. Fue divertido y me sentí como un verdadero constructor y aventurero.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSz5LBHSKh1RbicnjEqppICIGRbey-yF4ZMhg&s");

            logiin.BtnAñadir();

            logiin.BotonEliminar();

            logiin.BotonConfirmar();



        }

        [Test]
        public void BotonPanicoExito()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            Panico logiin = new Panico(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();

            logiin.Añadir();

            logiin.AgregarVivencia("Animal Crossing: New Horizons", "En mi pequeña isla, pase un dia decorando mi casa con muebles que habia hecho yo mismo.","https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAkpdUmFbYJ_He7veJqhNuHDbOsV-Dy2SF6A&s");

            logiin.BtnAñadir();

            logiin.BotonPanico();

            logiin.Barra("Jose123");

            logiin.BotonEliminar();

        }

        [Test]
        public void BotonPanicoFallido()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            Panico logiin = new Panico(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();

            logiin.BotonPanicoerror();

            logiin.BotonEliminarerror();

        }

        [Test]
        public void MostrarConvivencia()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            MostrarConvivencia logiin = new MostrarConvivencia(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();

            logiin.Añadir();

            logiin.AgregarVivencia("Animal Crossing: New Horizons", "En mi pequeña isla, pase un dia decorando mi casa con muebles que habia hecho yo mismo.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAkpdUmFbYJ_He7veJqhNuHDbOsV-Dy2SF6A&s");

            logiin.BtnAñadir();


        }

        [Test]
        public void CerrarSesion()
        {
            Driver.Navigate().GoToUrl("http://localhost:5206/Login");
            CerrarSesion logiin = new CerrarSesion(Driver);


            logiin.SesionUsuario("Jose@gmail.com", "Jose123");
            logiin.ClickRegistrarBoton();

            logiin.Cerrar();
            


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
