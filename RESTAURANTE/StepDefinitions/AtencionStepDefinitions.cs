using OpenQA.Selenium;
using RESTAURANTE.Hoks.Pages;
using RESTAURANTE.Hoks.Pages.Atencion;
using RESTAURANTE.Hoks.Pages.Preparacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAURANTE.StepDefinitions
{
    [Binding]
    public class AtencionStepDefinitions
    {
        private IWebDriver driver;
        AtencionPage atencionPage;
        AtencionConMesaPage atencionConMesaPage;
        AtencionSinMesaPage atencionSinMesaPage;

        public AtencionStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            atencionPage = new AtencionPage(driver);
            atencionConMesaPage = new AtencionConMesaPage(driver);
            atencionSinMesaPage = new AtencionSinMesaPage(driver);
        }

        // TIPO DE ATENCION

        [Given("Se seleciona el tipo de atencion {string}")]
        public void GivenSeSelecionaElTipoDeAtencion(string _tipoAtencion)
        {
            atencionPage.tipoAtencion(_tipoAtencion);
        }






        //ATENCION SIN MESA

        [Given("Se seleciona el modo {string}")]
        public void GivenSeSelecionaElModo(string _modoAtencion)
        {
            atencionSinMesaPage.SeleccionModoAtencion(_modoAtencion);
        }

        [Given("Se ingresa el cliente {string}")]
        public void GivenSeIngresaElCliente(string _cliente)
        {
            atencionSinMesaPage.IngresarCliente(_cliente);
        }

        [Given("Se selecciona el mozo {string}")]
        public void GivenSeSeleccionaElMozo(string _mozo)
        {
            atencionSinMesaPage.SeleccionMozo(_mozo);
        }

        [When("Se ingresa las siguientes ordenes:")]
        public void WhenSeIngresaLasSiguientesOrdenes(DataTable dataTable)
        {
            Console.WriteLine($"Procesando orden {dataTable.Rows}");

            foreach (var row in dataTable.Rows)
            {
                string _orden = row["Orden"];
                string _concepto = row["Concepto"];
                string _cantidad= row["Cantidad"];
                string _anotacion = row["Anotacion"];

                Console.WriteLine($"Procesando orden {_orden}: {_concepto}");

                switch (_orden)
                {
                    case "CODIGO":
                        atencionSinMesaPage.CodigoItem(_concepto, _anotacion);
                        break;

                    case "ITEM":
                        atencionSinMesaPage.SeleccionItem(_concepto, _cantidad, _anotacion);
                        break;

                    default:
                        throw new ArgumentException($"La {_orden} no es correcta");
                }
                Thread.Sleep(4000);
            }
        }

        [When("Se realiza la accion de {string} la Orden")]
        public void WhenSeRealizaLaAccionDeLaOrden(string _accion)
        {
            // atencionSinMesaPage.AgregarAnotacion(_accion);
            atencionSinMesaPage.AnotacionItem(_accion);
            // atencionSinMesaPage.AccionOrden(_accion);
        }

        [Then("Orden Tomada")]
        public void ThenOutcome()
        {
            // 
        }
    }
}
