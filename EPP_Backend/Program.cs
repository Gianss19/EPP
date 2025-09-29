var builder = WebApplication.CreateBuilder(args);

// Agrega servicios de controladores
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Prueba");

// Mapea los controladores
app.MapControllers();

app.Run();