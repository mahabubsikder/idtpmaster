using System;
using System.Threading.Tasks;
using IDTPBusinessLayer;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using IDTPKeyVaultManagement;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IDTPAdminUI
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
            services.AddControllersWithViews();
            //local run
            services.AddDbContext<IDTPDBContext>(options =>
            options.UseSqlServer(Constants.Azuresqldbconnectionstring));

            //keyvault run
            //services.AddDbContext<IDTPDBContext>(options =>
            //options.UseSqlServer(KeyVaultManagement.GetKey("azuresqldbconnectionstring")));

            services.AddSession();
            
            services.AddTransient<IBusinessLayer, BusinessLayer>();
            
            //services.AddScoped(IDTPDBContext);
            //services.AddIdentity< ApplicationUser , IdentityRole>().AddEntityFrameworkStores<IDTPDBContext>();
            
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = false;
            }
                )
                    .AddDefaultUI()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IDTPDBContext>().AddDefaultTokenProviders(); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles(); // For the wwwroot folder
            app.UseFastReport();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "", "images")),
            //    RequestPath = "/Images"
            //});            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}"
                    );
                endpoints.MapRazorPages();
            });

             CreateRoles(services).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "IDTPAdmin", "GovernmentInstitute", "FinancialInstitute", "Business" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 2
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }


            ////here in this line we are adding Admin Role
            //var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            //if (!roleCheck)
            //{
            //    //here in this line we are creating admin role and seed it to the database
            //    roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            //}
            //here we are assigning the Admin role to the User that we have registered above 
            //Now, we are assinging admin role to this user("Ali@gmail.com"). When will we run this project then it will
            //be assigned to that user.

            //IdentityUser _user = await UserManager.FindByEmailAsync("info@techvisionco.com");
            //var User = new IdentityUser();
            //await UserManager.AddToRoleAsync(user, "Admin");

            //Here you could create a super user who will maintain the web app
            var poweruser = new ApplicationUser
            {
                UserName = IDTPAdminUI.Helper.Constants.POWERUSERNAME,
                Email = IDTPAdminUI.Helper.Constants.POWERUSEREMAIL,
                EntityState = IDTPDomainModel.EntityState.Added
            };

            string userPWD = IDTPAdminUI.Helper.Constants.POWERUSERSECRET;
            var _user = await UserManager.FindByEmailAsync(IDTPAdminUI.Helper.Constants.POWERUSEREMAIL);

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role : 
                    await UserManager.AddToRoleAsync(poweruser, IDTPAdminUI.Helper.Constants.POWERUSERROLE);

                }
            }

        }

    }
}
