using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Configuracoes
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
		{

		}

		public DbSet<HistoricoPesquisa> HistoricoPesquisa { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(ObterStringConexao());
				base.OnConfiguring(optionsBuilder);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{ 
			builder.Entity<HistoricoPesquisa>().ToTable(nameof(HistoricoPesquisa)).HasKey(t => t.Id);

			base.OnModelCreating(builder);
		}


		public string ObterStringConexao()
		{
			return "Data Source=DESKTOP-GKI620K\\SQLEXPRESS01;Connection Timeout=60;Initial Catalog=DB_API_DDD;User ID=sa;Password=123456;Integrated Security=False;TrustServerCertificate=False;Encrypt=False";
		}

	}
}
