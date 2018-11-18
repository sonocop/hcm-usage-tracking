using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Access.Data;
using Access.Data.Dapper;
using Access.HCM.UsageTracking.Data;
using Access.HCM.UsageTracking.Logic;
using Access.HCM.UsageTracking.Model.Data;
using Access.HCM.UsageTracking.Model.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    // the IsTrusted() extension method doesn't exist and
                    // you should implement your own as you may want to interpret it differently
                    // i.e. based on the current principal

                    var problemDetails = new ProblemDetails
                    {
                        Instance = $"urn:myorganization:error:{Guid.NewGuid()}"
                    };

                    if (exception is BadHttpRequestException badHttpRequestException)
                    {
                        problemDetails.Title = "Invalid request";
                        problemDetails.Status = (int)typeof(BadHttpRequestException).GetProperty("StatusCode",
                            BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttpRequestException);
                        problemDetails.Detail = badHttpRequestException.Message;
                    }
                    else
                    {
                        problemDetails.Title = "An unexpected error occurred!";
                        problemDetails.Status = 500;
                        problemDetails.Detail = exception.Message.ToString();
                    }

                    //TOOD: log the exception etc..

                    context.Response.StatusCode = problemDetails.Status.Value;
                    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(problemDetails.Detail));
                });
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
