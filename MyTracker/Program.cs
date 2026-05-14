using Infrastructura.EF;
using Infrastructura.Repositorios;
using LogicaAplicacion.CasosDeUso;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Contexto bd
builder.Services.AddDbContext<GastosContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//CUCategoria
builder.Services.AddScoped<AltaCategoria>();
builder.Services.AddScoped<ListarCategoria>();
builder.Services.AddScoped<EditarCategoria>();
builder.Services.AddScoped<EliminarCategoria>();

//CUGasto
builder.Services.AddScoped<AltaGasto>();
builder.Services.AddScoped<ListarGasto>();
builder.Services.AddScoped<EditarGasto>();
builder.Services.AddScoped<EliminarGasto>();

//Telegram bot
builder.Services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(
    builder.Configuration["Telegram:BotToken"]
));

//Repositorios
builder.Services.AddScoped<IRepositorioGasto, RepositorioGasto>();
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
