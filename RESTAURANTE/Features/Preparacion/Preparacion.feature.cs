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
namespace RESTAURANTE.Features.Preparacion
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Preparacion")]
    [NUnit.Framework.FixtureLifeCycleAttribute(NUnit.Framework.LifeCycle.InstancePerTestCase)]
    public partial class PreparacionFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Preparacion", "Preparacion", "A short summary of the feature", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "Preparacion.feature"
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
        [NUnit.Framework.DescriptionAttribute("Preparacion de varias ordenes")]
        [NUnit.Framework.CategoryAttribute("Preparacion")]
        public async System.Threading.Tasks.Task PreparacionDeVariasOrdenes()
        {
            string[] tagsOfScenario = new string[] {
                    "Preparacion"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Preparacion de varias ordenes", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
 await testRunner.GivenAsync("Inicio de sesión con usuario \'admin@tintoymadero.com\' y contraseña \'calidad\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 8
 await testRunner.AndAsync("Se ingresa al módulo \'Preparacion\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
                global::Reqnroll.Table table11 = new global::Reqnroll.Table(new string[] {
                            "ORDEN",
                            "ITEM"});
                table11.AddRow(new string[] {
                            "C001 - 125340",
                            "SALCHIPAPA SALCHIPAPA ESPECIAL"});
                table11.AddRow(new string[] {
                            "C001 - 125340",
                            "CARTA MOLLEJAS A LA PARRILLA"});
                table11.AddRow(new string[] {
                            "C001 - 125340",
                            "CARTA PIQUEO DE LOMO FINO"});
                table11.AddRow(new string[] {
                            "C001 - 125339",
                            "CARTA BROCHETA DE LOMO"});
#line 9
 await testRunner.WhenAsync("Se procede a \'Preparar\' las siguientes ordenes:", ((string)(null)), table11, "When ");
#line hidden
#line 16
 await testRunner.ThenAsync("", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Preparacion de todos los items de una orden")]
        [NUnit.Framework.CategoryAttribute("Preparacion")]
        public async System.Threading.Tasks.Task PreparacionDeTodosLosItemsDeUnaOrden()
        {
            string[] tagsOfScenario = new string[] {
                    "Preparacion"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Preparacion de todos los items de una orden", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 19
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 20
 await testRunner.GivenAsync("Inicio de sesión con usuario \'admin@tintoymadero.com\' y contraseña \'calidad\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 21
 await testRunner.AndAsync("Se ingresa al módulo \'Preparacion\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 22
 await testRunner.WhenAsync("Se procede a \'Preparar\' todos los items de la orden \'C001 - 125348\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 23
 await testRunner.ThenAsync("", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
