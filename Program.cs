var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços da API
builder.Services.AddControllers();

// Suporte OpenAPI + Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger(c =>
    {
        // Configura o endpoint JSON corretamente
        c.RouteTemplate = "swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "project-lee-api v1");
        c.RoutePrefix = string.Empty;  // Swagger na raiz '/'
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
