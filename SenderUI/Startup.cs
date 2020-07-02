using IDTPBusinessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SenderUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IBusinessLayer, BusinessLayer>();
            services.AddSession();
            //services.AddDbContext<IDTPContext>(options => options.UseSqlServer(@"Server=DESKTOP-MVUN8U4\SQLEXPRESS;Database=IDTP;Trusted_Connection=True;"));

            //services.AddTransient<ISendingBankUserRepository, SendingBankUserRepository>();
            //services.AddTransient<IReceivingBankUserRepository, ReceivingBankUserRepository>();
            //services.AddTransient<IBankRepository, BankRepository>();
            //services.AddTransient<IBranchRepository, BranchRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=TransferFund}/{action=Create}/{id?}");

            });
        }
    }
}
