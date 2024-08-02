using Dominio.Interfaces.Genericos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos
{
	public interface IServicoHistoricoPesquisa
	{

		Task AdicionaHistoricoPesquisa(HistoricoPesquisa objeto);

		Task AtualizaHistoricoPesquisa(HistoricoPesquisa objeto);

		Task<List<HistoricoPesquisa>> ListarHistoricoPesquisa();
		
		Task<List<HistoricoPesquisa>> BuscarHistoricoPesquisa(string busca);
	}
}
