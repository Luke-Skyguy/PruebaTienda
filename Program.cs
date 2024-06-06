using Microsoft.EntityFrameworkCore;
using PruebaTenda.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Agregar servicios de controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(
    options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); // Autorización

app.MapControllers(); // Mapeo de controladores

app.Run();
