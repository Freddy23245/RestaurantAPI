using Microsoft.EntityFrameworkCore;
using SistemaRestauranteAPI.Data;
using SistemaRestauranteAPI.Repository;
using SistemaRestauranteAPI.Repository.IRepository;
using SistemaRestauranteAPI.RestaurantMappers;
using SistemaRestauranteAPI.Services;
using SistemaRestauranteAPI.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SistemaRestauranteContext>(
    opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Agregamos el AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<RestaurantMappers>();
});

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddScoped<ICategoriasService, CategoriasService>();
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
