using BlazorUI.Interfaces;
using BlazorUI.Models;
using BlazorUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var serverHttp = "https://banking20220614092437.azurewebsites.net/";

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<LoginState>();
            services.AddSingleton<ClientServices>();
            services.AddHttpClient<IClientServices, ClientServices>(client =>
            {
                client.BaseAddress = new Uri(serverHttp);
            });
            services.AddSingleton<CompanyServices>();
            services.AddHttpClient<ICompanyServices, CompanyServices>(client =>
            {
                client.BaseAddress = new Uri(serverHttp);
            });
            services.AddSingleton<ContractServices>();
            services.AddHttpClient<IContractServices, ContractServices>(client =>
            {
                client.BaseAddress = new Uri(serverHttp);
            });
            services.AddSingleton<StartUpServices>();
            services.AddHttpClient<IStartUpServices, StartUpServices>(client =>
            {
                client.BaseAddress = new Uri(serverHttp);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
