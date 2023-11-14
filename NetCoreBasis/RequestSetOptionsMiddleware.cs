using System.Net;

namespace NetCoreBasis
{
    public class RequestSetOptionsMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestSetOptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //从查询字符串参数中设置选项值
        public async Task Invoke(HttpContext httpContext)
        {
            var option = httpContext.Request.Query["option"];
            if (!string.IsNullOrWhiteSpace(option))
            {
                httpContext.Items["option"] = WebUtility.HtmlEncode(option);
            }
            await _next(httpContext);
        }
    }
    //在 RequestSetOptionsStartupFilter 类中配置 RequestSetOptionsMiddleware
    public class RequestSetOptionsStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder => { 
                builder.UseMiddleware<RequestSetOptionsMiddleware>(next);
                next(builder);
            };
        }
    }


}
