using Descarpack.BookGerencial.Api._Config.ActionFilters;
using Descarpack.BookGerencial.Api._Config.Binders;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace IntegratedAccountManagement.ApiConfiguration.Startup;
    public static class MvcConfig
    {
        public static IServiceCollection AppAddMvc(this IServiceCollection services)
        {
            void JsonOptions(MvcNewtonsoftJsonOptions options)
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffZ";
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }

            services.AddMvc(x =>
                {
                    x.Filters.Add(new ExceptionActionFilterAttribute());
                    x.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
                })
                .AddNewtonsoftJson(JsonOptions);

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
            });

            services.AddRazorPages();

            return services;
        }
    }

