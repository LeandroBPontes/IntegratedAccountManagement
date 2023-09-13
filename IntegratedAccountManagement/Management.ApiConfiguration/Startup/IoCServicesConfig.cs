// using Microsoft.AspNetCore.Http;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
//
//
// namespace IntegratedAccountManagement.ApiConfiguration.Startup;
// public static class IoCServicesConfig
//     {
//         public static IServiceCollection AppAddIoCServices(this IServiceCollection services,
//             IConfiguration config)
//         {
//             Logging4NetFactory.InitializeLogFactory(
//                 new Log4NetAdapter(config.GetSection("AppConfig:Logger").Value),
//                 config.GetConnectionString("DefaultConnection")
//             );
//
//             // options/config
//             ConfigureOptions(services, config);
//
//             //validators
//             services.AddValidatorsFromAssembly(typeof(GenerateCashFlowCommandValidator).Assembly);
//
//             // infra
//             services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//
//             services.AddScoped<IViewRenderService, ViewRenderService>();
//
//             services.AddSingleton<IAppLogger>(Logging4NetFactory.GetLogger());
//
//             services.AddScoped<ILoggedUser, LoggedUser>();
//
//             services.AddScoped<IMailService, MailService>();
//
//             services.AddScoped<IAwsS3Storage, AwsS3Storage>();
//
//             services.AddScoped<CashFlowGenerator, CashFlowGenerator>();
//             services.AddScoped<CashFlowVisualizer, CashFlowVisualizer>();
//             services.AddScoped<ICashFlowSpreadsheetService, CashFlowSpreadsheetService>();
//             services.AddScoped<DataContext, DataContext>();
//
//             services.AddSingleton<PasswordHasherService>();
//
//             services.AddSingleton(Logging4NetFactory.GetLogger());
//             services.AddSingleton<IJobProcessor, JobProcessor>();
//
//             // events
//             services.AddScoped<IDomainNotification, DomainNotification>();
//
//             // unit of work
//             services.AddScoped<IUnitOfWork, UnitOfWork>();
//
//             // repositories
//             typeof(BankRepository).Assembly.GetTypes()
//                 .Where(x => !string.IsNullOrWhiteSpace(x.FullName) &&
//                             x.FullName.Contains("Repositories") &&
//                             x.GetInterfaces().Any() &&
//                             x.IsClass &&
//                             x != typeof(Repository<>))
//                 .ToList().ForEach(x =>
//                 {
//                     var @interface = x.GetInterfaces().FirstOrDefault(s => s.Name.Contains(x.Name));
//
//                     if (@interface == null) return;
//
//                     services.AddScoped(@interface, x);
//                 });
//
//             // cron jobs
//             typeof(CronJobsIoCConfig)
//                 .Assembly.GetTypes()
//                 .Where(x => x.GetInterfaces().Any() && x.IsClass && typeof(IRecurringJob).IsAssignableFrom(x))
//                 .ToList()
//                 .ForEach(x =>
//                 {
//                     services.AddScoped(x, x);
//                 });
//
//             // treasury repositories
//             InjectTreasury(services);
//
//             InjectSolutionsPortalService(services, config);
//
//             return services;
//         }
//
//         private static void InjectSolutionsPortalService(IServiceCollection services, IConfiguration config)
//         {
//             var configData = new SolutionsPortalConfig();
//             config.GetSection(nameof(SolutionsPortalConfig)).Bind(configData);
//
//             var authConfig = new ClientConfig(configData.ClientId, configData.ClientSecret, configData.AuthorizerBaseUrl, configData.RedirectUri, configData.PostLogoutRedirectUri, configData.RequireHttps);
//
//             services.AddSingleton(authConfig);
//             services.AddSingleton<AuthClient, AuthClient>();
//             services.AddSingleton<UserClient, UserClient>();
//         }
//
//         private static void InjectTreasury(IServiceCollection services)
//         {
//             services.AddScoped<TreasuryRepository, TreasuryRepository>();
//             services.AddScoped<ITreasuryService, TreasuryService>();
//             services.AddScoped<IPayableService, PayablesService>();
//             services.AddScoped<IReceivableService, ReceivablesService>();
//         }
//
//         private static void ConfigureOptions(IServiceCollection services,
//             IConfiguration config)
//         {
//             var appConfig = new AppConfig();
//             config.GetSection(nameof(AppConfig)).Bind(appConfig);
//             services.AddSingleton(appConfig);
//
//             var emailConfig = new EmailConfig();
//             config.GetSection(nameof(EmailConfig)).Bind(emailConfig);
//             services.AddSingleton(emailConfig);
//
//             var awsS3Config = new AwsS3Config();
//             config.GetSection(nameof(AwsS3Config)).Bind(awsS3Config);
//             services.AddSingleton(awsS3Config);
//         }
//     }
// }