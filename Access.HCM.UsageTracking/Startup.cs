using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Data;
using Access.Data.Dapper;
using Access.HCM.UsageTracking.Data;
using Access.HCM.UsageTracking.Logic;
using Access.HCM.UsageTracking.Model.Data;
using Access.HCM.UsageTracking.Model.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Access.HCM.UsageTracking
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
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IDatabaseProvider, DapperDatabaseProvider>();
            services.AddTransient<IHRInstanceRepository, HRInstanceRepository>();
            services.AddTransient<IHRInstanceLogic, HRInstanceLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
