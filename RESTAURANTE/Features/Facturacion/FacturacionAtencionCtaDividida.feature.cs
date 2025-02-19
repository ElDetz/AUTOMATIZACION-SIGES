﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RESTAURANTE.Features.Facturacion
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Factura Atencion Cuenta Dividida")]
    [NUnit.Framework.FixtureLifeCycleAttribute(NUnit.Framework.LifeCycle.InstancePerTestCase)]
    public partial class FacturaAtencionCuentaDivididaFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Facturacion", "Factura Atencion Cuenta Dividida", "And Se especifica que la factura será dividida en \'3\' cuentas ", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "FacturacionAtencionCtaDividida.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Facturación con Cuenta Dividida - 001")]
        [NUnit.Framework.CategoryAttribute("FacturaAtencionCuentaDividida")]
        public async System.Threading.Tasks.Task FacturacionConCuentaDividida_001()
        {
            string[] tagsOfScenario = new string[] {
                    "FacturaAtencionCuentaDividida"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Facturación con Cuenta Dividida - 001", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 6
 await testRunner.GivenAsync("Inicio de sesión con usuario \'admin@tintoymadero.com\' y contraseña \'calidad\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 7
 await testRunner.AndAsync("Se ingresa al módulo \'Caja\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 8
 await testRunner.AndAsync("Se selecciona el tipo de factura \'CUENTA DIVIDIDA\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 9
 await testRunner.AndAsync("Se especifica que la factura será dividida en \'3\' cuentas", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
                global::Reqnroll.Table table6 = new global::Reqnroll.Table(new string[] {
                            "TipoCliente",
                            "ValorCliente",
                            "TipoComprobante",
                            "Observacion",
                            "MedioPago"});
                table6.AddRow(new string[] {
                            "ALIAS",
                            "72935878",
                            "FACTURA ELECTRONICA",
                            "OBSERVACIÓN1",
                            "DEPCU"});
                table6.AddRow(new string[] {
                            "ALIAS",
                            "CHIQUI",
                            "NOTA DE VENTA (INTERNA)",
                            "OBSERVACIÓN2",
                            "TDEB"});
#line 10
 await testRunner.WhenAsync("Se ingresan los detalles de la factura:", ((string)(null)), table6, "When ");
#line hidden
                global::Reqnroll.Table table7 = new global::Reqnroll.Table(new string[] {
                            "Banco_Cuenta",
                            "TipoTarjeta",
                            "MontoRecibido",
                            "Informacion"});
                table7.AddRow(new string[] {
                            "001103180100023457",
                            "-",
                            "-",
                            "-"});
                table7.AddRow(new string[] {
                            "INTERBANK",
                            "AMERICAN EXPRESS",
                            "-",
                            "10010"});
#line 15
 await testRunner.AndAsync("Se ingresan los datos del pago:", ((string)(null)), table7, "And ");
#line hidden
#line 20
 await testRunner.ThenAsync("Se realiza la facturación", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
