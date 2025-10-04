using EPP_Backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configura DbContext
builder.Services.AddDbContext<EppContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 26))
    )
);

// Agrega servicios de controladores
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    // 🔹 Opción 1: AllowAll (para desarrollo rápido, NO recomendado en producción)
      /*  options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // permite cualquier origen
              .AllowAnyMethod()   // permite GET, POST, PUT, DELETE
              .AllowAnyHeader();  // permite cualquier cabecera
    });
    */

    // 🔹 Opción 2: Solo tu frontend (recomendado)
   options.AddPolicy("FrontendOnly", policy =>
       {
           policy.WithOrigins("http://127.0.0.1:3000", "http://localhost:5208") // solo tu frontend
                 .AllowAnyMethod()   // permite GET, POST, PUT, DELETE
                 .AllowAnyHeader();  // permite cabeceras como Content-Type
       });
    });


    var app = builder.Build();

    // 🔹 Para desarrollo rápido, puedes usar AllowAll
    //app.UseCors("AllowAll");

    // 🔹 Para seguridad, usa solo tu frontend
    app.UseCors("FrontendOnly");

    app.MapGet("/", () => "Prueba");

    app.MapControllers();

    app.Run();



    // Mapea los controladores
    app.MapControllers();

    app.Run();

