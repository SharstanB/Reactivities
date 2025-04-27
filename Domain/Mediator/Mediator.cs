
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Mediator
{
    //public class Mediator : IMediator
    //{

    //    private readonly IServiceProvider _serviceProvider;

    //    public Mediator(IServiceProvider serviceProvider)
    //    {
    //        _serviceProvider = serviceProvider;
    //    }

    //    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    //    {
    //        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
    //        var handler = _serviceProvider.GetRequiredService(handlerType);
    //        return await (Task<TResponse>)handlerType
    //            .GetMethod("Handle")
    //            .Invoke(handler, new object[] { request, default(CancellationToken) });
    //    }
    //    public async Task<TResponse> Send<TResponse>(IRequest request)
    //    {
    //        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
    //        var handler = _serviceProvider.GetRequiredService(handlerType);
    //        return await (Task<TResponse>)handlerType
    //            .GetMethod("Handle")
    //            .Invoke(handler, new object[] { request, default(CancellationToken) });
    //    }
    //}
    public class Mediator : IMediator
    {

        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetRequiredService(handlerType);
            return await (Task<TResponse>)handlerType
                .GetMethod("Handle")
                .Invoke(handler, new object[] { request, default(CancellationToken) });
        }

        //public async Task Send(IRequest request)
        //{
        //    var handlerType = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
        //    var handler = _serviceProvider.GetRequiredService(handlerType);
        //    await (Task)handlerType
        //       .GetMethod("Handle")
        //       .Invoke(handler, new object[] { request, default(CancellationToken) });
        //}
    }
}
