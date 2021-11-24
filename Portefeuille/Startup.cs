using BasicHealthChecks;
using Croesus.AspNetCore.MVC.ContentNegotiation;
using Croesus.AspNetCore.MVC.ModelBinding;
using Croesus.NETStandard.Web.ReturnObjects.Builders;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Portefeuille.Domain;
using Portefeuille.Infrastructure;
using Portefeuille.Modules;
using Portefeuille.Utils;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Portefeuille
{
    public class Startup
    {


        /// <summary>
        /// Application settings loaded from the <see cref="Configuration"/>.
        /// </summary>
        public GeneralSettings Settings { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSingleton<Messages>();

            services.AddHandlers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portefeuille", Version = "v1" });
            });

            RepositoryModule.ConfigureServices(services);

            // HTTP request context access, to access authentified user information.
            services.AddHttpContextAccessor();
            services.AddTransient<IHttpContextTokenService, HttpContextTokenService>();

            services.AddControllers(options =>
            {
                // Add custom Croesus Output Formatter
                JsonSerializerSettings formatterSettings = JsonSerializerSettingsProvider.CreateSerializerSettings();
                ObjectBuilderGenerator objectBuilderGenerator = new ObjectBuilderGenerator();
                options.OutputFormatters.Insert(0, new CroesusFullOutputFormatter(formatterSettings, ArrayPool<char>.Shared, options, objectBuilderGenerator));
                options.OutputFormatters.Insert(0, new CroesusRawOutputFormatter(formatterSettings, ArrayPool<char>.Shared, options, objectBuilderGenerator));

                // add custom binder to beginning of collection
                options.ModelBinderProviders.Insert(0, new DateTimeBinderProvider());
                options.ModelBinderProviders.Insert(0, new CommaDelimitedCollectionBinderProvider());

                // Permettre les BODY vides.
                options.AllowEmptyInputInBodyModelBinding = true;
            })
            .AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing.
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                // add custom model binding error type
                options.InvalidModelStateResponseFactory = actionContext =>
                    InvalidModelStateFactory.GenerateActionResultFromModelState(actionContext);
            });

            services.AddMemoryCache();

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portefeuille v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Allow all CORS requests for specific domains.
            // Wildcard subdomains are allowed
            //app.UseCors(options => options
            //    .SetIsOriginAllowedToAllowWildcardSubdomains()
            //    .WithOrigins(this.Settings.AllowedOrigins)
            //    .AllowAnyHeader()
            //    .AllowAnyMethod()
            //    .AllowCredentials());

            var supportedCultures = new[]
                       {
                new CultureInfo("en-US"),
                new CultureInfo("en-CA"),
                new CultureInfo("fr-CA"),
            };


            // Ajoute un body Json au 404 pour les routes invalides
            app.UseCustomStatusCodePagesForNotFound();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-CA"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

          
        }
    }
}
