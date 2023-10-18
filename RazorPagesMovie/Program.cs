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
            if (!app.Environment.IsDevelopment())//��Ӧ��δ�ڿ���ģʽ������ʱ
            {
                app.UseExceptionHandler("/Error");//���쳣�ս������Ϊ /Error
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();//���� HTTP �ϸ��䰲ȫЭ�� (HSTS)
            }

            app.UseHttpsRedirection();//�� HTTP �����ض��� HTTPS��
            app.UseStaticFiles();//ʹ�ܹ��ṩ HTML��CSS��ӳ��� JavaScript �Ⱦ�̬�ļ�

            app.UseRouting();//���м���ܵ����·��ƥ��

            app.UseAuthorization();//��Ȩ�û����ʰ�ȫ��Դ��

            app.MapRazorPages();//Ϊ Razor Pages �����ս��·�ɡ�

            app.Run();//����Ӧ�á�
        }
    }
}