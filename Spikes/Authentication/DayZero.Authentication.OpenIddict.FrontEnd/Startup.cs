using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoHelper;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DayZero.Authentication.OpenIddict.FrontEnd.Models;
using DayZero.Authentication.OpenIddict.FrontEnd.Services;
using OpenIddict;
using OpenIddict.Models;

namespace DayZero.Authentication.OpenIddict.FrontEnd
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                //builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddOpenIddict();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            //app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseOAuthValidation();

            // Alternatively, you can also use the introspection middleware.
            // Using it is recommended if your resource server is in a
            // different application/separated from the authorization server.
            // 
            // app.UseOAuthIntrospection(options => {
            //     options.AutomaticAuthenticate = true;
            //     options.AutomaticChallenge = true;
            //     options.Authority = "http://localhost:54540/";
            //     options.Audience = "resource_server";
            //     options.ClientId = "resource_server";
            //     options.ClientSecret = "875sqd4s5d748z78z7ds1ff8zz8814ff88ed8ea4z4zzd";
            // });

            app.UseIdentity();

            app.UseOpenIddict();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvcWithDefaultRoute();

            using (var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>())
            {
                context.Database.EnsureCreated();

                // Add Mvc.Client to the known applications.
                if (!context.Applications.Any())
                {
                    // Note: when using the introspection middleware, your resource server
                    // MUST be registered as an OAuth2 client and have valid credentials.
                    // 
                    // context.Applications.Add(new Application {
                    //     Id = "resource_server",
                    //     DisplayName = "Main resource server",
                    //     Secret = "875sqd4s5d748z78z7ds1ff8zz8814ff88ed8ea4z4zzd"
                    // });

                    context.Applications.Add(new Application
                    {
                        Id = "myClient",
                        DisplayName = "My client application",
                        RedirectUri = "http://localhost:53984/signin-oidc",
                        LogoutRedirectUri = "http://localhost:53984/",
                        Secret = Crypto.HashPassword("secret_secret_secret"),
                        Type = OpenIddictConstants.ApplicationTypes.Confidential
                    });

                    context.SaveChanges();
                }
            }
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
