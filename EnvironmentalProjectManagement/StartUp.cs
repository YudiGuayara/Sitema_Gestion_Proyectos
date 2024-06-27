using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Identity;
using EnvironmentalProjectManagement.Models;
using EnvironmentalProjectManagement.Services;
using MongoDB.Driver;

namespace EnvironmentalProjectManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de MongoDB
            services.Configure<DatabaseSettings>(
                Configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                var settings = serviceProvider.GetRequiredService<IConfiguration>()
                    .GetSection(nameof(DatabaseSettings))
                    .Get<DatabaseSettings>();
                return new MongoClient(settings.ConnectionString);
            });

            // Servicios de aplicación
            services.AddScoped<ProyectoService>();
            services.AddScoped<RecursoService>();
            services.AddScoped<TareaService>();
            services.AddScoped<UsuarioService>();

            // Configuración de Identity con MongoDB
            services.AddIdentity<Usuario, IdentityRole>()
                .AddMongoDbStores<Usuario, IdentityRole, ObjectId>(serviceProvider =>
                {
                    var settings = serviceProvider.GetRequiredService<IConfiguration>()
                        .GetSection(nameof(DatabaseSettings))
                        .Get<DatabaseSettings>();
                    return new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
                })
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EnvironmentalProjectManagement API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EnvironmentalProjectManagement API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
