using Grpc.Core;
using Grpc.Core.Interceptors;
using MadWorldNL.Common.Exceptions;
using Microsoft.Extensions.Logging;

namespace Common.Grpc;

public class GrpcGlobalErrorHandlerInterceptor : Interceptor
{
    private readonly ILogger<GrpcGlobalErrorHandlerInterceptor> _logger;

    public GrpcGlobalErrorHandlerInterceptor(ILogger<GrpcGlobalErrorHandlerInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await base.UnaryServerHandler(request, context, continuation);
        }
        catch (RpcException)
        {
            throw;
        }
        catch (ValidationException exception)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, exception.Message));
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Internal Server Error");
            throw new RpcException(new Status(StatusCode.Internal, "Internal Server Error"));
        }
    }
}