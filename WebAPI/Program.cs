using Aplicacao.Aplicacoes;
using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.Genericos;
using Dominio.Interfaces.Servicos;
using Dominio.Servicos;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
	var forecast = Enumerable.Range(1, 5).Select(index =>
		new WeatherForecast
		(
			DateTime.Now.AddDays(index),
			Random.Shared.Next(-20, 55),
			summaries[Random.Shared.Next(summaries.Length)]
		))
		.ToArray();
	return forecast;
})
.WithName("GetWeatherForecast");

app.MapControllers();

app.Run();



void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	services.AddDbContext<Contexto>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


	//Interface e Repositório
	services.AddSingleton(typeof(IGenericos<>), typeof(RepositorioGenerico<>));
	services.AddSingleton<IHistoricoPesquisa, RepositorioHistoricoPesquisa>();


	//Serviço Dominio
	services.AddSingleton<IServicoHistoricoPesquisa, ServicoHistoricoPesquisa>();

	//interface aplicação
	services.AddSingleton<IAplicacaoHistoricoPesquisa, AplicacaoHistoricoPesquisa>();
}


internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}