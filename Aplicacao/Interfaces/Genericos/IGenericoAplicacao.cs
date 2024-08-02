using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Genericos
{
	public interface IGenericoAplicacao <T> where T : class
	{
		Task<bool> Adicionar(T Objeto);

		Task Atualizar(T Objeto);

		Task Excluir(T Objeto);

		Task<T> BuscarPorId(long Id);

		Task<List<T>> Listar();
	}
}
