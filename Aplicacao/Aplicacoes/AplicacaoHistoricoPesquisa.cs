using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.Servicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
	public class AplicacaoHistoricoPesquisa : IAplicacaoHistoricoPesquisa
	{

		IHistoricoPesquisa _IHistoricoPesquisa;
		IServicoHistoricoPesquisa _IServicoHistoricoPesquisa;


		public AplicacaoHistoricoPesquisa(IHistoricoPesquisa iHistoricoPesquisa, IServicoHistoricoPesquisa iServicoHistoricoPesquisa)
		{
			_IHistoricoPesquisa = iHistoricoPesquisa;
			_IServicoHistoricoPesquisa = iServicoHistoricoPesquisa;
		}

		public async Task AdicionaHistoricoPesquisa(HistoricoPesquisa objeto)
		{
			await _IServicoHistoricoPesquisa.AdicionaHistoricoPesquisa(objeto);
		}


		public async Task AtualizaHistoricoPesquisa(HistoricoPesquisa objeto)
		{
			await _IServicoHistoricoPesquisa.AtualizaHistoricoPesquisa(objeto);
		}

		public async Task<List<HistoricoPesquisa>> BuscarHistoricoPesquisa(string busca)
		{
			return await _IServicoHistoricoPesquisa.BuscarHistoricoPesquisa(busca);
		}

		public async Task<List<HistoricoPesquisa>> ListarHistoricoPesquisa()
		{
			return await _IServicoHistoricoPesquisa.ListarHistoricoPesquisa();
		}


		public async Task<bool> Adicionar(HistoricoPesquisa Objeto)
		{
			try
			{
				await _IHistoricoPesquisa.Adicionar(Objeto);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
			
		}

		

		public async Task Atualizar(HistoricoPesquisa Objeto)
		{
			await _IHistoricoPesquisa.Atualizar(Objeto);
		}

		

		public async Task<HistoricoPesquisa> BuscarPorId(long Id)
		{
			return await _IHistoricoPesquisa.BuscarPorId(Id);
		}

		public async Task Excluir(HistoricoPesquisa Objeto)
		{
			await _IHistoricoPesquisa.Excluir(Objeto);
		}

		public async Task<List<HistoricoPesquisa>> Listar()
		{
			return await _IHistoricoPesquisa.Listar();
		}

		
	}
}
