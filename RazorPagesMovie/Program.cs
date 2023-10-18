namespace RazorPagesMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

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