

using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Application.Abstrations.Messaging
{
    public interface ICommand : IRequest<Result>
    {

    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {

    }

    public interface IBaseCommand
    {

    }
}