using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Infraestructure;
using Infraestructure.DTO_s.Bill;
using Infraestructure.DTO_s.Bills;
using Infraestructure.DTO_s.Clients;
using Infraestructure.DTO_s.Entries;
using Infraestructure.DTO_s.Products;
using Infraestructure.DTO_s.Providers;
using Infraestructure.DTO_s.Sells;
using Infraestructure.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DeSuperHeroesPrueba
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
            services.AddControllers();

            //DI for DbContext and repositories, i used singleton with unitOfWork because this instance will be used in every request,
            //on the other hand, the repositories will be used only in their own controllers, not necessary in every request.
            services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(Configuration["db"]));
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEntriesRepository, EntriesRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<ISellsRepository, SellsRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            //DTO's mappers
            services.AddAutoMapper(mapper =>
            {
                mapper.CreateMap<Bill, BillOTO>();
                mapper.CreateMap<BillITO, Bill>().ReverseMap();

                mapper.CreateMap<Client, ClientOTO>();
                mapper.CreateMap<ClientITO, Client>().ReverseMap();

                mapper.CreateMap<ProductProvider, EntryOTO>();
                mapper.CreateMap<EntryITO, ProductProvider>().ReverseMap();

                mapper.CreateMap<Product, ProductOTO>();
                mapper.CreateMap<ProductITO, Product>().ReverseMap();

                mapper.CreateMap<ProductClient, SellOTO>();
                mapper.CreateMap<SellITO, ProductClient>().ReverseMap();

                mapper.CreateMap<Provider, ProviderOTO>();
                mapper.CreateMap<ProviderITO, Provider>().ReverseMap();
            });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
