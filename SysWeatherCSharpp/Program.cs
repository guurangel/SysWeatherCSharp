using Microsoft.EntityFrameworkCore;
using SysWeather.Infrastructure.Contexts;
using SysWeatherC_.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar string de conexão Oracle (via appsettings.json)
var oracleConnectionString = builder.Configuration.GetConnectionString("Oracle");

// Adicionar o DbContext SysWeatherDbContext
builder.Services.AddDbContext<SysWeatherDbContext>(options =>
    options.UseOracle(oracleConnectionString));

// Configurar controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Para evitar loop de referência circular e JSON formatado
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Registrar services do SysWeather
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<MunicipioService>();
builder.Services.AddScoped<OcorrenciaService>();
// Registre outras services que você tenha, se houver

// Adicionar Swagger/OpenAPI para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
