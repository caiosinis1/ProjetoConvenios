using ConveniosObras.API.Extensions;
using ConveniosObras.API.Middlewares;
using ConveniosObras.Application.DependencyInjection;
using ConveniosObras.Infrastructure.DependencyInjection;

namespace ConveniosObras.API.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddApiServices();
        services.AddSwaggerConfiguration();
        services.AddJwtConfiguration(configuration);
        
        services.AddApplicationServices();
        services.AddInfrastructureServices(configuration);

        return services;
    }

    public static WebApplication UseApiMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}

