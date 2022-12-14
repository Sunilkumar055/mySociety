using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySociety.BAL.Repository;
using MySociety.Common.Configurations;
using MySociety_DataAccessLayer;
using MySociety_DataAccessLayer.DBContext;
using MySociety_DataAccessLayer.Helper;
using MySociety_DataAccessLayer.Helper.Interface;
using MySociety_DataAccessLayer.Interface;
using Newtonsoft.Json.Serialization;

namespace MySocietyAPI
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
            //services.AddTransient<>
            //services.AddDbContext<ApplicationDBContext>(
            //    options => options.UseSqlServer(
            //        Configuration.GetConnectionString("AzureConnection")
            //        )
            //    );


            //Connection string
            services.AddSingleton<ConfigurationManager>(new ConfigurationManager(Configuration.GetSection("CustomConfig")));            
            //CORS
            services.AddCors(options =>
                options.AddPolicy("AllowOrigin",options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
            );
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());                

            //Add dependancy
            services.AddScoped<IAuthManager, AuthManager>();                        
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ISQLHelper, SQLHelper>();               
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
