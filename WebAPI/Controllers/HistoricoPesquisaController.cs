using Aplicacao.Interfaces;
using Entidades.Entidades;
using Entidades.Notificacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HistoricoPesquisaController : ControllerBase
	{
		private readonly IAplicacaoHistoricoPesquisa _IAplicacaoHistoricoPesquisa;

		public HistoricoPesquisaController(IAplicacaoHistoricoPesquisa iAplicacaoHistoricoPesquisa)
		{
			_IAplicacaoHistoricoPesquisa = iAplicacaoHistoricoPesquisa;
		}


		[AllowAnonymous]
		[Produces("application/json")]
		[HttpPost("/api/ListarHistoricoPesquisas")]
		public async Task<List<HistoricoPesquisa>> ListarHistoricoPesquisas()
		{
			return await _IAplicacaoHistoricoPesquisa.Listar();
		}

		[AllowAnonymous]
		[Produces("application/json")]
		[HttpPost("/api/AdicionarHistoricoPesquisa")]
		public async Task<RSDefault> AdicionarHistoricoPesquisa(HistoricoPesquisaModel objeto)
		{
			var novaPesquisa = new HistoricoPesquisa()
			{
				Titulo = objeto.Titulo,
				Professor = objeto.Professor,
				CargaHoraria = objeto.CargaHoraria,
				Descricao = objeto.Descricao,
				DataPesquisa = DateTime.Now
			};

			RSDefault retorno = new RSDefault() { status = "401" };

			if (await _IAplicacaoHistoricoPesquisa.Adicionar(novaPesquisa))
			{
				retorno.status = "200";
			}

			return retorno;
			

		}


		public class RSDefault
		{
			public string status { get; set; }
		}




	}
}
