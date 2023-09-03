using MediatR;

namespace Collage.Application.CommandInterfaces;
public interface IQuery<TResponse> : IRequest<TResponse>
{
}