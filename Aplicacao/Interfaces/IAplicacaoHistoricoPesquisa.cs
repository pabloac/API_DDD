using Aplicacao.Interfaces.Genericos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
	public interface IAplicacaoHistoricoPesquisa : IGenericoAplicacao<HistoricoPesquisa>
	{

		Task AdicionaHistoricoPesquisa(HistoricoPesquisa objeto);

		Task AtualizaHistoricoPesquisa(HistoricoPesquisa objeto);

		Task<List<HistoricoPesquisa>> ListarHistoricoPesquisa();

		Task<List<HistoricoPesquisa>> BuscarHistoricoPesquisa(string busca);
	}
}
