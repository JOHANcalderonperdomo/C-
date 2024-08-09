using Business.Location.Implementation;
using Business.Location.Interface;
using Business.Security.Implementacion;
using Business.Security.Interface;
using Data.Location.Implementation;
using Data.Location.Interface;
using Data.Security.Implementation;
using Data.Security.Interface;
using Entity.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura DBContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// No es necesario registrar ApplicationDbContext de nuevo
// builder.Services.AddDbContext<ApplicationDbContext>();

// Security
builder.Services.AddScoped<IPersonaBusiness, PersonaBusiness>();
builder.Services.AddScoped<IPersonaData, PersonaData>();
builder.Services.AddScoped<IModuloBusiness, ModuloBusiness>();
builder.Services.AddScoped<IModuloData, ModuloData>();
builder.Services.AddScoped<IRolBusiness, RolBusiness>();
builder.Services.AddScoped<IRolData, RolData>();
builder.Services.AddScoped<IVistaBusiness, VistaBusiness>();
builder.Services.AddScoped<IVistaData, VistaData>();
builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
builder.Services.AddScoped<IUsuarioData, UsuarioData>();
builder.Services.AddScoped<IUsuarioRolBusiness, UsuarioRolBusiness>();
builder.Services.AddScoped<IUsuarioRolData, UsuarioRolData>();
builder.Services.AddScoped<IRolVistaBusiness, RolVistaBusiness>();
builder.Services.AddScoped<IRolVistaData, RolVistaData>();
// Location
builder.Services.AddScoped<IContinetBusiness, ContinetBusiness>();
builder.Services.AddScoped<IContinetData, ContinetData>();
builder.Services.AddScoped<ICountryBusiness, CountryBusiness>();
builder.Services.AddScoped<ICountryData, CountryData>();
builder.Services.AddScoped<IDepartmentBusiness, DepartmentBusiness>();
builder.Services.AddScoped<IDepartmentData, DepartmentData>();
builder.Services.AddScoped<ICityBusiness, CityBusiness>();
builder.Services.AddScoped<ICityData, CityData>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
