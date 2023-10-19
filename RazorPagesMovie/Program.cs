using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())//Seed 方法完成时释放上下文。 using 语句将确保释放上下文。
            {
                var services = scope.ServiceProvider;//从依赖注入 (DI) 容器中获取数据库上下文实例。
                SeedData.Initialize(services);//调用 seedData.Initialize 方法，并向其传递数据库上下文实例。
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())//当应用未在开发模式中运行时
            {
                app.UseExceptionHandler("/Error");//将异常终结点设置为 /Error
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();//启用 HTTP 严格传输安全协议 (HSTS)
            }

            app.UseHttpsRedirection();//将 HTTP 请求重定向到 HTTPS。
            app.UseStaticFiles();//使能够提供 HTML、CSS、映像和 JavaScript 等静态文件

            app.UseRouting();//向中间件管道添加路由匹配

            app.UseAuthorization();//授权用户访问安全资源。

            app.MapRazorPages();//为 Razor Pages 配置终结点路由。

            app.Run();//运行应用。
        }
    }
}