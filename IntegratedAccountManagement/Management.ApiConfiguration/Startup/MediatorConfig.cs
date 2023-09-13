using System;
using Descarpack.BookGerencial.Api._Config.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IntegratedAccountManagement.ApiConfiguration.Startup;
    public static class MediatorConfig
    {
        public static IServiceCollection AppAddMediator(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            var assembly = AppDomain.CurrentDomain.Load("Descarpack.BookGerencial.Domain");
            services.AddMediatR(assembly);
            return services;
        }
    }

