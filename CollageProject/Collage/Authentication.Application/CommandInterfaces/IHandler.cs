using MediatR;

namespace Collage.Application.CommandInterfaces;
public interface IHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
where TRequest : IRequest<TResponse>
{

}
