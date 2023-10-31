using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            //ServerCallContext 不提供对所有 ASP.NET API 中 HttpContext 的完全访问权限
            var httpcontext = context.GetHttpContext();
            var clientCertificate = httpcontext.Connection.ClientCertificate;

            return Task.FromResult(new HelloReply
            {
                Message = $"Hello {request.Name} from {clientCertificate?.Issuer}"
            });
        }

    }
}