using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Vehiculos.SearchVehiculos
{
    public sealed class DireccionRespose
    {
        public string? Pais { get; init; }

        public string? Departamento { get; init; }

        public string? Provincia { get; init; }

        public string? Calle { get; init; }

    }
}