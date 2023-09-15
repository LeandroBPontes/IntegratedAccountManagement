using IntegratedAccountManagement.ApiConfiguration.IocConfig;
using IntegratedAccountManagement.ApiConfiguration.Startup;


namespace Management.Api;
 public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }
        
        private const string CorsPolicy = "CorsPolicy";
        
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors(options =>
                {
                    options.AddPolicy(CorsPolicy,
                        builder =>
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .WithOrigins(Configuration.GetSection("AppConfig:AppUrl").Value ?? string.Empty)
                                .AllowCredentials()
                            );
                })
                .AppAddDatabase(Configuration)
                .AppAddMvc()
                .AppAddAuthorization(Configuration, Environment)
                .AppAddCompression()
                .AppAddMediator()
                .AppAddSwagger()
                .AppAddIoCServices(Configuration)
                .AddRazorPages(cfg => {
                    cfg.RootDirectory = "/";
                });
        }
        
        public void Configure(IApplicationBuilder app, IHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            if (env.IsProduction())
                app.UseHsts();

            app.UseResponseCompression();
            app.UseStaticFiles();
            app.AppUseMigrations();
            app.UseCors(CorsPolicy);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
              
            });
        }
    }