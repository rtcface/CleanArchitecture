
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehiculos
{
    public class VehiculoErrors
    {
        public static Error NotFound = new(
            "Vehiculo.Found",
            "Noexiste el vehiculo con este id"
        );
    }
}