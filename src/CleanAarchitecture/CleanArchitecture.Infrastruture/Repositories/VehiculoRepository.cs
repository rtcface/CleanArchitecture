
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Infrastruture.Repositories
{
    internal sealed class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}