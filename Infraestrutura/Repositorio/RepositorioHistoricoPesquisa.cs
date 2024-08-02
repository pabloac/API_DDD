using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
	public class RepositorioHistoricoPesquisa : RepositorioGenerico<HistoricoPesquisa>, IHistoricoPesquisa
	{
		private readonly DbContextOptions<Contexto> _optionsBuilder;

		public RepositorioHistoricoPesquisa()
		{
			_optionsBuilder = new DbContextOptions<Contexto>();
		}

		public async Task<List<HistoricoPesquisa>> BuscarHistoricoPesquisas(Expression<Func<HistoricoPesquisa, bool>> expHistoricoNoticias)
		{
			using (var banco = new Contexto(_optionsBuilder))
			{
				return await banco.HistoricoPesquisa.Where(expHistoricoNoticias).AsNoTracking().ToListAsync();
			}
		}
	}
}
