namespace IdentityServer4.WebServer
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        #region Constructors

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Methods

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add service of IdentityServer4
            services.AddIdentityServer() // Use Identity Server 4
                .AddDeveloperSigningCredential() // Add develop credentials
                .AddInMemoryApiResources(Config.GetApiResources()) // Add authorization resources
                .AddInMemoryClients(Config.GetClients()); // Add clients
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Declare use IdentityServer4
            app.UseIdentityServer();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // End configuration
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #endregion
    }
}