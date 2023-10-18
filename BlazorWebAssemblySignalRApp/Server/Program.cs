using Microsoft.AspNetCore.ResponseCompression;
using BlazorWebAssemblySignalRApp.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//添加 SignalR 和响应压缩中间件服务
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(option=>{
    option.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
});

var app = builder.Build();
//使用响应压缩中间件
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
//在控制器终结点和客户端回退之间，为中心添加一个终结点
app.MapHub<ChatHub>("/chathub");
app.MapFallbackToFile("index.html");

app.Run();
