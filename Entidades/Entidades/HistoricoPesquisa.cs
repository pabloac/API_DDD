using Entidades.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
	[Table("TB_HISTORICO_PESQUISA")]
	public class HistoricoPesquisa : Notifica
	{
		[Key]
		[Column("ID")]
		public long Id { get; set; }

		[Column("TITULO")]
		[MaxLength(255)]
		public string Titulo { get; set; }

		[Column("PROFESSOR")]
		[MaxLength(255)]
		public string Professor { get; set; }


		[Column("CARGA_HORARIA")]
		[MaxLength(100)]
		public string? CargaHoraria { get; set; }

		[Column(TypeName = "TEXT")]
		public string? Descricao { get; set; }


		[Column("DATA_PESQUISA")]
		public DateTime DataPesquisa { get; set; }


	}
}
