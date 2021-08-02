using API.GRAPH.Business;
using API.GRAPH.Data;
using API.GRAPH.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API.GRAPH
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));
            services.AddScoped<ProdutoService>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQL", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
             ProdutoService produtoService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL v1"));
            }

            produtoService.Incluir(
                new Produto { CodigoBarras = "11111111111", Nome = "Produto01", Preco = 579 }
                );

            produtoService.Incluir(
              new Produto { CodigoBarras = "2222222222", Nome = "Produto02", Preco = 579 }
              );

            produtoService.Incluir(
              new Produto { CodigoBarras = "333333333333", Nome = "Produto03", Preco = 579 }
              );

            produtoService.Incluir(
              new Produto { CodigoBarras = "4444444444", Nome = "Produto04", Preco = 579 }
              );

            produtoService.Incluir(
              new Produto { CodigoBarras = "5555555555", Nome = "Produto05", Preco = 579 }
              );

            produtoService.Incluir(
              new Produto { CodigoBarras = "66666666666", Nome = "Produto06", Preco = 579 }
              );

            produtoService.Incluir(
              new Produto { CodigoBarras = "77777777777", Nome = "Produto07", Preco = 579 }
              );

            produtoService.Incluir(
              new Produto { CodigoBarras = "888888888888", Nome = "Produto08", Preco = 579 }
              );

            produtoService.Incluir(
              new Produto { CodigoBarras = "99999999999", Nome = "Produto09", Preco = 579 }
              );

            produtoService.Incluir(
              new Produto { CodigoBarras = "10101010101010101010", Nome = "Produto10", Preco = 579 }
              );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }   
    }
}
