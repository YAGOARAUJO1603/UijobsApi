using Microsoft.EntityFrameworkCore;
using UijobsApi.DAL.Repositories;
using UijobsApi.DAL.Repositories.Beneficios;
using UijobsApi.DAL.Repositories.BeneficiosVagas;
using UijobsApi.DAL.Repositories.Candidatos;
using UijobsApi.DAL.Repositories.CarreirasProfissionais;
using UijobsApi.DAL.Repositories.Conhecimentos;
using UijobsApi.DAL.Repositories.Curriculos;
using UijobsApi.DAL.Repositories.CurriculosConhecimentos;
using UijobsApi.DAL.Repositories.CurriculosIdiomas;
using UijobsApi.DAL.Repositories.Cursos;
using UijobsApi.DAL.Repositories.Empresas;
using UijobsApi.DAL.Repositories.EnderecoCandidatos;
using UijobsApi.DAL.Repositories.EnderecoEmpresas;
using UijobsApi.DAL.Repositories.Escolaridades;
using UijobsApi.DAL.Repositories.FormacoesAcademicas;
using UijobsApi.DAL.Repositories.Idiomas;
using UijobsApi.DAL.Repositories.Niveis;
using UijobsApi.DAL.Repositories.Portes;
using UijobsApi.DAL.Repositories.SituacoesVagas;
using UijobsApi.DAL.Repositories.Vagas;
using UijobsApi.DAL.Repositories.VagasCandidatos;
using UijobsApi.DAL.Repositories.VagasConhecimentos;
using UijobsApi.DAL.Repositories.VagasIdiomas;
using UijobsApi.DAL.Unit_of_Work;
using UijobsApi.Services.Beneficios;
using UijobsApi.Services.BeneficiosVagas;
using UijobsApi.Services.CarreirasProfissionais;
using UijobsApi.Services.Conhecimentos;
using UijobsApi.Services.Curriculos;
using UijobsApi.Services.CurriculosConhecimentos;
using UijobsApi.Services.CurriculosIdiomas;
using UijobsApi.Services.Empresas;
using UijobsApi.Services.EnderecoCandidatos;
using UijobsApi.Services.EnderecoEmpresas;
using UijobsApi.Services.Escolaridades;
using UijobsApi.Services.FormacoesAcademicas;
using UijobsApi.Services.Idiomas;
using UijobsApi.Services.Niveis;
using UijobsApi.Services.Portes;
using UijobsApi.Services.SituacoesVagas;
using UijobsApi.Services.Vagas;
using UijobsApi.Services.VagasCandidatos;
using UijobsApi.Services.VagasConhecimentos;
using UijobsApi.Services.VagasIdiomas;
using UIJobsAPI.Data;
using UIJobsAPI.Services.Candidatos;
using UIJobsAPI.Services.Cursos;
using UIJobsAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"));
});

builder.Services.AddScoped<IBeneficioRepository, BeneficioRepository>();
builder.Services.AddScoped<IBeneficioVagaRepository, BeneficioVagaRepository>();
builder.Services.AddScoped<ICandidatoRepository, CandidatoRepository>();
builder.Services.AddScoped<ICarreiraProfissionalRepository, CarreiraProfissionalRepository>();
builder.Services.AddScoped<IConhecimentoRepository, ConhecimentoRepository>();
builder.Services.AddScoped<ICurriculoRepository, CurriculoRepository>();
builder.Services.AddScoped<ICurriculoConhecimentoRepository, CurriculoConhecimentoRepository>();
builder.Services.AddScoped<ICurriculoIdiomaRepository, CurriculoIdiomaRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEnderecoCandidatoRepository, EnderecoCandidatoRepository>();
builder.Services.AddScoped<IEnderecoEmpresaRepository, EnderecoEmpresaRepository>();
builder.Services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
builder.Services.AddScoped<IFormacaoAcademicaRepository, FormacaoAcademicaRepository>();
builder.Services.AddScoped<IIdiomaRepository, IdiomaRepository>();
builder.Services.AddScoped<INivelRepository, NivelRepository>();
builder.Services.AddScoped<IPorteRepository, PorteRepository>();
builder.Services.AddScoped<ISituacaoVagaRepository, SituacaoVagaRepository>();
builder.Services.AddScoped<IVagaRepository, VagaRepository>();
builder.Services.AddScoped<IVagaCandidatoRepository, VagaCandidatoRepository>();
builder.Services.AddScoped<IVagaConhecimentoRepository, VagaConhecimentoRepository>();
builder.Services.AddScoped<IVagaIdiomaRepository, VagaIdiomaRepository>();

builder.Services.AddScoped<IBeneficioService, BeneficioService>();
builder.Services.AddScoped<IBeneficioVagaService, BeneficioVagaService>();
builder.Services.AddScoped<ICandidatoService, CandidatoService>();
builder.Services.AddScoped<ICarreiraProfissionalServices, CarreiraProfissionalServices>();
builder.Services.AddScoped<IConhecimentoService, ConhecimentoService>();
builder.Services.AddScoped<ICurriculoService, CurriculoService>();
builder.Services.AddScoped<ICurriculoConhecimentoService, CurriculoConhecimentoService>();
builder.Services.AddScoped<ICurriculoIdiomaService, CurriculoIdiomaService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEnderecoCandidatoService, EnderecoCandidatoService>();
builder.Services.AddScoped<IEnderecoEmpresaService, EnderecoEmpresaService>();
builder.Services.AddScoped<IEscolaridadeService, EscolaridadeService>();
builder.Services.AddScoped<IFormacaoAcademicaService, FormacaoAcademicaService>();
builder.Services.AddScoped<IIdiomaService, IdiomaService>();
builder.Services.AddScoped<INivelService, NivelService>();
builder.Services.AddScoped<IPorteService, PorteService>();
builder.Services.AddScoped<ISituacaoVagaService, SituacaoVagaService>();
builder.Services.AddScoped<IVagaService, VagaService>();
builder.Services.AddScoped<IVagaCandidatoService, VagaCandidatoService>();
builder.Services.AddScoped<IVagaConhecimentoService, VagaConhecimentoService>();
builder.Services.AddScoped<IVagaIdiomaService, VagaIdiomaService>();



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
