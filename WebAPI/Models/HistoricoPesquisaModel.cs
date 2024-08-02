namespace WebAPI.Models
{
	public class HistoricoPesquisaModel
	{
		public long Id { get; set; }

		public string Titulo { get; set; }
		
		public string Professor { get; set; }

		public string CargaHoraria { get; set; }

		public string? Descricao { get; set; }

		public DateTime? DataPesquisa { get; set; }

	}
}
