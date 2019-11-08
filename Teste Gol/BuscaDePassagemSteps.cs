using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Teste_Gol
{
    [Binding]
    public class BuscaDePassagemSteps
    {
        IWebDriver Browser;
        private string uri = "https://www.voegol.com.br/pt";

        [BeforeScenario]
        public void Init()
        {
            this.Browser = new ChromeDriver();
        }

        [AfterScenario]
        public void Close()
        {
            this.Browser.Close();
            this.Browser.Dispose();
        }
        [Given(@"que um usuário acesse a página principal")]
        public void DadoQueUmUsuarioAcesseAPaginaPrincipal()
        {
            this.Browser.Navigate().GoToUrl(uri);
        }
        
        [When(@"clicar no botão Comprar Passagem")]
        public void QuandoClicarNoBotaoComprarPassagem()
        {
            var btnComprarPassagem = this.Browser.FindElement(By.ClassName("btnCompbtn-buy-passage btn-purchase-headerrarPassagem"));
            btnComprarPassagem.Click();
        }
        
        [When(@"preencher todos os dados de busca: Aeroporto Saída, Aeroporto Chegada, Data Ida, Data Volta, Adultos, Crianças e Bebês")]
        public void QuandoPreencherTodosOsDadosDeBuscaAeroportoSaidaAeroportoChegadaDataIdaDataVoltaAdultosCriancasEBebes(Table table)
        {
            try
            {
                var txtAeroSaida = this.Browser.FindElement(By.XPath("//*[@id='purchase - box']/form[2]/div[1]/div[2]/label"));
                txtAeroSaida.SendKeys(table.Rows[0][0].ToString());
                var txtAeroChegada = this.Browser.FindElement(By.XPath("//*[@id='purchase - box']/form[2]/div[1]/div[3]/div[1]/label"));
                txtAeroSaida.SendKeys(table.Rows[0][1].ToString()); 

                var txtDtIda = this.Browser.FindElement(By.Id("datepickerGo"));
                txtDtIda.Click();
                txtDtIda.SendKeys(table.Rows[0][2].ToString());

                var txtDtVolta = this.Browser.FindElement(By.Id("datepickerBack"));
                txtDtIda.Click();
                txtDtVolta.SendKeys(table.Rows[0][3].ToString()); 

                var txtAdultos = this.Browser.FindElement(By.Id("number-adults"));
                txtAeroSaida.SendKeys(table.Rows[0][4].ToString());
                var txtCriancas = this.Browser.FindElement(By.ClassName("box-numbers kids"));
                txtAeroSaida.SendKeys(table.Rows[0][5].ToString());
                var txtBebes = this.Browser.FindElement(By.ClassName("box-numbers babys"));
                txtAeroSaida.SendKeys(table.Rows[0][6].ToString());
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }

        }

        [When(@"efetuar a busca de passagem cliando no botão Compre Aqui")]
        public void QuandoEfetuarABuscaDePassagemCliandoNoBotaoCompreAqui()
        {
            try
            {
                var btnCompraAqui = this.Browser.FindElement(By.Id("btn-box-buy"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }


        [Then(@"os dados de cadastro serão validados")]
        public void EntaoOsDadosDeCadastroSeraoValidados()
        {
//ScenarioContext.Current.Pending();
        }
        
        [Then(@"serão exibidos os resultados da busca")]
        public void EntaoSeraoExibidosOsResultadosDaBusca()
        {
            this.Browser.Navigate().GoToUrl(uri + "/Select2.aspx");
        }
    }
}
