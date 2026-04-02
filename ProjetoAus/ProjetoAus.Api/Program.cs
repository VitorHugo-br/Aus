using ProjetoAus.Api.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCorsApp();

builder.AddJwtConfig();

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddContext(builder.Configuration);

builder.Services.AddRepositories();

builder.Services.AddServices();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("Angular");

await app.ApplyMigrationsAndSeedAsync();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();