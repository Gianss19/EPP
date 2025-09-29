using EPP_Backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EppContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 26))
                    )
    );


// Agrega servicios de controladores
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Prueba");

// Mapea los controladores
app.MapControllers();

app.Run();