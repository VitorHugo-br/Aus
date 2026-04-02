namespace ProjetoAus.Api.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection AddCorsApp(this IServiceCollection services)
    {
        return services.AddCors(options =>
            {
                options.AddPolicy("Angular", policy =>
                {
                    policy.WithOrigins("http://localhost:4200");
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });   
            }
        );
    }
}