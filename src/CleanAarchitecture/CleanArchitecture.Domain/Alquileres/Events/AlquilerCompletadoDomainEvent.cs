using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres.Events
{
    public sealed record AlquilerCompletadoDomainEvent(Guid AlquilerId) : IDomainEvent;

}