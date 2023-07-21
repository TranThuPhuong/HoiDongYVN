using HoiDongYVN.Controllers;
using HoiDongYVN.Models;
using HoiDongYVN.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoiDongYVN
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
            var connectionString = Configuration.GetConnectionString("db_HoiDongYVN");
            services.AddDbContext<db_HoiDongYVNContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<iCreator, CreatorRepo>();
            services.AddScoped<iPost, PostRepo>();
            services.AddScoped<iTag, TagRepo>();
            // Thêm dịch vụ Session vào container dịch vụ.
            services.AddDistributedMemoryCache();  // Cho phép lưu trữ Session trong bộ nhớ. Đối với môi trường sản xuất, bạn có thể muốn sử dụng cách lưu trữ khác như Redis.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                   option.LoginPath = "/Login/Login";
                    option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                });
      
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);  // Số phút mà Session tồn tại nếu không có hoạt động nào.
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddHttpContextAccessor();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "creators",
                    pattern: "creators",
                    defaults: new { controller = "Creators", action = "Index" });
            });
        }
    }
}
