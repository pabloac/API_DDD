using Dominio.Interfaces;
using Dominio.Interfaces.Servicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
	public class ServicoHistoricoPesquisa : IServicoHistoricoPesquisa
	{


		//Injeção de Dependência aqui
		private readonly IHistoricoPesquisa _IServicoHistoricoPesquisa;

		public ServicoHistoricoPesquisa(IHistoricoPesquisa iServicoHistoricoPesquisa)
		{
			_IServicoHistoricoPesquisa = iServicoHistoricoPesquisa;
		}

		public async Task AdicionaHistoricoPesquisa(HistoricoPesquisa objeto)
		{
			var validarTitulo = objeto.ValidaPropriedadeString(objeto.Titulo, "Titulo");
			var validarProfessor = objeto.ValidaPropriedadeString(objeto.Professor, "Professor");

			if (validarTitulo && validarProfessor)
			{
				objeto.DataPesquisa = DateTime.Now;
				await _IServicoHistoricoPesquisa.Adicionar(objeto);
			}


		}

		public async Task AtualizaHistoricoPesquisa(HistoricoPesquisa objeto)
		{
			var validarTitulo = objeto.ValidaPropriedadeString(objeto.Titulo, "Titulo");
			var validarProfessor = objeto.ValidaPropriedadeString(objeto.Professor, "Professor");

			if (validarTitulo && validarProfessor)
			{
				objeto.DataPesquisa = DateTime.Now;
				await _IServicoHistoricoPesquisa.Atualizar(objeto);
			}
		}

		public async Task<List<HistoricoPesquisa>> ListarHistoricoPesquisa()
		{
			return await _IServicoHistoricoPesquisa.Listar();
		}

		public async Task<List<HistoricoPesquisa>> BuscarHistoricoPesquisa(string busca)
		{
			return await _IServicoHistoricoPesquisa.BuscarHistoricoPesquisas(x => x.Titulo.Contains(busca) || x.Professor.Contains(busca) || x.Descricao.Contains(busca));
		}

	}
}
