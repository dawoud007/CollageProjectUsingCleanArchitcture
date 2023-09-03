using MediatR;

namespace Collage.Application.CommandInterfaces;
public interface ICommand<TResponse> : IRequest<TResponse>
{
}