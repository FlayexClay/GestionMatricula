using GestionMatricula.AccesoDatos.Contexto;
using GestionMatricula.Presentacion.Components;
using GestionMatricula.Repositorios.Implementaciones;
using GestionMatricula.Repositorios.Interfaces;
using GestionMatricula.Servicio.Implementaciones;
using GestionMatricula.Servicio.Interfaces;
using GestionMatricula.Servicio.Mappers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContext<BdGestionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BdGestion"));
});

builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();

builder.Services.AddAutoMapper(map =>
{
    map.AddProfile<CursoMap>();
    map.AddProfile<AlumnoMap>();
    map.AddProfile<MatriculaMap>();
});

builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();