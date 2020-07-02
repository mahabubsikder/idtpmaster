using IDTPBusinessLayer;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using IDTPKeyVaultManagement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace IDTPServiceController
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            #region Add CORS  
            services.AddCors(options => options.AddPolicy("Cors", builder => {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            #endregion

            #region Add Entity Framework and Identity Framework  

            //For Locally Run
            /* services.AddDbContext<IDTPDBContext>(options =>
             options.UseSqlServer(Constants.Azuresqldbconnectionstring));*/

            //For Running With KeyVault
            services.AddDbContext<IDTPDBContext>(options =>
            options.UseSqlServer(KeyVaultManagement.GetKey("azuresqldbconnectionstring")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IDTPDBContext>();

            #endregion

            #region Add Authentication  
            //Added JWT based Authentication Middleware.This will validate every API call. API will return 
            //“401 Un - Authorized” error if valid authentication token is not provided in the HTTP request header.
            string encryptionKey = KeyVaultManagement.GetKey("TokenEncryptionKey");
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(encryptionKey));

            //For local pc use this
            //var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config => {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters() {
                    IssuerSigningKey = signingKey,
                    ValidateAudience = true,
                    ValidAudience = this.Configuration["Tokens:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = this.Configuration["Tokens:Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
            #endregion

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "IDTP Service Controller API",
                    Version = "v1"
                });
            });


            services.AddMvc();
            services.AddTransient<IBusinessLayer, BusinessLayer>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("Cors");

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IDTP Service Controller API v1");
            });

        }
    }
}
