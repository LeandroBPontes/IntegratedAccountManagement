using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace IntegratedAccountManagement.ApiConfiguration.Startup;
    public static class SwaggerConfig
    {
        public static IServiceCollection AppAddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "V1 API docs",
                        Version = "v1"
                    }
                );
                
                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme()
                    {
                        Type = SecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        Description = "",
                        In = ParameterLocation.Header,
                        BearerFormat = "Bearer {access_token}",
                        Scheme = "Bearer"
                    });

            });

            return services;
        }

        public static IApplicationBuilder AppUseSwagger(this IApplicationBuilder app)
        {

            app.UseSwagger(options => { options.RouteTemplate = "docs/{documentName}/swagger.json"; });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/docs/v1/swagger.json", "V1 API docs");
                // options.SwaggerEndpoint($"/docs/v2/swagger.json", "V2 API docs");
                options.RoutePrefix = "docs";

                options.DefaultModelRendering(ModelRendering.Example);
                options.DefaultModelsExpandDepth(-1);
                options.DisplayRequestDuration();
                options.DocExpansion(DocExpansion.List);
                options.EnableDeepLinking();
                options.ShowExtensions();

                options.SupportedSubmitMethods(
                    SubmitMethod.Options,
                    SubmitMethod.Get,
                    SubmitMethod.Post,
                    SubmitMethod.Put,
                    SubmitMethod.Patch,
                    SubmitMethod.Delete);
            });

            return app;
        }
    }

