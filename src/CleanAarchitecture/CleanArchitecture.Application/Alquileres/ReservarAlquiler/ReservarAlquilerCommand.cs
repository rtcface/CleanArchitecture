
using CleanArchitecture.Application.Abstrations.Messaging;

namespace CleanArchitecture.Application.Alquileres.ReservarAlquiler
{
    public record ReservarAlquilerCommand(
        Guid VehiculoId,
        Guid UserId,
        DateOnly FechaInicio,
        DateOnly FechaFin
    ) : ICommand<Guid>;
}