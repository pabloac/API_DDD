using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SitePesquisa.Classes;
using SitePesquisa.Componentes;
using static SitePesquisa.Componentes.ApiHistoricoPesquisaComponente;

namespace SitePesquisa
{
	public partial class _Default : Page
	{

		private static ApiHistoricoPesquisaComponente apiHistoricoPesquisaComponente = new ApiHistoricoPesquisaComponente();

		protected void Page_Load(object sender, EventArgs e)
		{
			lblRetorno.Visible = false;
		}

		
		protected void btnBusca_Click(object sender, EventArgs e)
		{
			List<ResultadoPesquisa> listaResultados = ObterResultadosPesquisaAlura(txtBusca.Text);

			if (listaResultados.Count > 0)
			{
				//Lidar com API pra armazenagem de pesquisa

				foreach (var item in listaResultados)
				{
					ResultadoPesquisaRQ objRequest = new ResultadoPesquisaRQ()
					{
						Titulo = item.Titulo,
						CargaHoraria = item.CargaHoraria,
						Descricao = item.Descricao,
						Professor = item.Professor
					};

					try
					{
						string status = apiHistoricoPesquisaComponente.AdicionarHistoricoPesquisa(objRequest).status;
					}
					catch (Exception)
					{
						
					}

				}
			}
		}


		#region AUXILIARES SELENIUM

		/// <summary>
		/// Utilizando o Selenium na pesquisa para capturar os resultados de https://www.alura.com.br/
		/// titulo e descrição são atributos obrigatórios, se não houver, não adiciona ao banco
		/// </summary>
		/// <param name="busca"></param>
		public List<ResultadoPesquisa> ObterResultadosPesquisaAlura(string busca)
		{
			IWebDriver driver = new ChromeDriver();
			List<ResultadoPesquisa> listaResultados = new List<ResultadoPesquisa>();

			try
			{
				string linkRaiz = "https://www.alura.com.br/";

				driver.Navigate().GoToUrl(linkRaiz);
				IWebElement searchBox = driver.FindElement(By.Name("query"));
				searchBox.SendKeys(busca);

				searchBox.Submit();

				// Esperar alguns segundos para carregar os resultados
				System.Threading.Thread.Sleep(3000);

				string pageTitle = driver.Title;
				IList<IWebElement> resultados = driver.FindElements(By.ClassName("busca-resultado"));

				foreach (var el in resultados)
				{
					if (!ElementExists(driver, By.ClassName("busca-resultado-nome")) || !ElementExists(driver, By.ClassName("busca-resultado-descricao")))
						continue;

					ResultadoPesquisa resultadoPesquisa = new ResultadoPesquisa();

					string hrefValue = "";

					if (ElementExists(driver, By.ClassName("busca-resultado-link")))
					{
						IWebElement link = el.FindElement(By.ClassName("busca-resultado-link"));
						hrefValue = link.GetAttribute("href");
					}

					IWebElement titulo = el.FindElement(By.ClassName("busca-resultado-nome"));
					resultadoPesquisa.Titulo = titulo.Text;

					IWebElement descricao = el.FindElement(By.ClassName("busca-resultado-descricao"));
					resultadoPesquisa.Descricao = descricao.Text;


					if (!string.IsNullOrEmpty(hrefValue))
					{
						resultadoPesquisa.LinkDetalhes = hrefValue;

						driver.Navigate().GoToUrl(hrefValue);

						System.Threading.Thread.Sleep(2000);

						IWebElement cargaHoraria = null;
						if (!ElementExists(driver, By.ClassName("formacao__info-destaque")))
						{
							if (ElementExists(driver, By.ClassName("courseInfo-card-wrapper-infos")))
							{
								cargaHoraria = driver.FindElement(By.ClassName("courseInfo-card-wrapper-infos"));
							}
						}
						else
							cargaHoraria = driver.FindElement(By.ClassName("formacao__info-destaque"));


						resultadoPesquisa.CargaHoraria = cargaHoraria != null ? cargaHoraria.Text : "N/I";

						if (ElementExists(driver, By.ClassName("formacao-instrutor-nome")))
						{
							IList<IWebElement> instrutores = driver.FindElements(By.ClassName("formacao-instrutor-nome"));
							if (instrutores.Count > 0)
							{
								resultadoPesquisa.Professor = String.Join(", ", instrutores.Where(x => !string.IsNullOrEmpty(x.Text)).Select(i => i.Text));
							}
						}
						else if (ElementExists(driver, By.ClassName("instructor-title--name")))//Página diferente de um só instrutor
						{
							IWebElement instrutor = driver.FindElement(By.ClassName("instructor-title--name"));
							resultadoPesquisa.Professor = instrutor.Text;	
						}
						else
							resultadoPesquisa.Professor = "N/I";

						listaResultados.Add(resultadoPesquisa);

						driver.Navigate().Back();
					}


					//para testar
					break;
				}

				driver.Quit();

			}
			catch (Exception ex)
			{
				driver.Quit();
			}

			return listaResultados;
		}

		/// <summary>
		/// Procedimento para testar a existência de um elemento na página do Driver(Selenium)
		/// evitando cair em falha
		/// </summary>
		/// <param name="driver"></param>
		/// <param name="by"></param>
		/// <returns></returns>
		public bool ElementExists(IWebDriver driver, By by)
		{
			try
			{
				driver.FindElement(by);
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
		}
		#endregion

	}
}