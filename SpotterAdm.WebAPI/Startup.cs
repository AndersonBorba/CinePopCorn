
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpotterAdm.Web.Api.Extensions;
using SpotterAdm.WebAPI.Extensions;

namespace SpotterAdm.WebAPI
{
    public class Startup
    {

        public static IConfiguration StaticConfig { get; private set; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Adiciona os controllers da API
            services.AddControllers();

            // Configs do DI
            services.AddDependencies();

            // Suprime os erros http do tipo 400
            // para poder customizar as exceções
            services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors();

        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCorsPolicy();

            // Não utilizar HttpsRedirection
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
