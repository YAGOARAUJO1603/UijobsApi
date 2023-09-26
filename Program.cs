using Microsoft.EntityFrameworkCore;
using UijobsApi.DAL.Repositories.Candidatos;
using UijobsApi.DAL.Repositories.Cursos;
using UijobsApi.DAL.Unit_of_Work;
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

builder.Services.AddScoped<ICandidatoService, CandidatoService>();
builder.Services.AddScoped<ICandidatoRepository, CandidatoRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();
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
