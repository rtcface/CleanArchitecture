
using System.Runtime.InteropServices;
using CleanArchitecture.Application.Abstrations.Data;
using CleanArchitecture.Application.Abstrations.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using Dapper;

namespace CleanArchitecture.Application.Vehiculos.SearchVehiculos
{
    internal sealed class SearchVehiculosQueryHandler : IQueryHandler<SearchVehiculosQuery, IReadOnlyList<VehiculoResponse>>
    {
        private static readonly int[] ActiveAlquilerStatuses = {
            (int) AlquilerStatus.Reservado,
            (int) AlquilerStatus.Confirmado,
            (int) AlquilerStatus.Completado
        };
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public SearchVehiculosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IReadOnlyList<VehiculoResponse>>> Handle(
            SearchVehiculosQuery request,
            CancellationToken cancellationToken
            )
        {
            if (request.fechaInicio > request.fechaFin)
            {
                return new List<VehiculoResponse>();
            }

            using var connection = _sqlConnectionFactory.CreateConnection();

            const string sql = """
            SELECT 
            vh.id AS Id,
            vh.modelo AS Modelo,
            vh.vin AS Vin,
            vh.precio_monto AS Precio,
            vh.precio_tipo_moneda AS TipoMoneda,
            vh.direccion_pais AS Pais,
            vh.direccion_departamento as Departamento,
            vh.direccion_provincia AS Provincia,
            vh.direccion_ciudad AS Ciudad,
            vh.direccion_calle AS Calle
            FROM vehiculos AS vh WHERE NOT EXISTS (
                SELECT 1 FROM alquileres as al WHERE 
                al.vehiculo_id = vh.id AND
                al.duracion_inicio <= @EndDate AND 
                al.duracion_fin >= @StartDate AND
                al.status = ANY(@ActiveAlquilerStatuses)
            )
            """;

            var vehiculos = await connection
                .QueryAsync<VehiculoResponse, DireccionRespose, VehiculoResponse>(
                    sql,
                    (vehiculo, direccion) =>
                    {
                        vehiculo.Direccion = direccion;

                        return vehiculo;
                    },
                    new
                    {
                        StartDate = request.fechaInicio,
                        EndDate = request.fechaFin,
                        ActiveAlquilerStatuses
                    },
                    splitOn: "Pais"
                );

            return vehiculos.ToList();
        }
    }
}