

using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Application.Abstrations.Messaging
{
    public interface ICommand : IRequest<Result>
    {

    }
}