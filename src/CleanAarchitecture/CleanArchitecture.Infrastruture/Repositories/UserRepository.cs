
using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Infrastruture.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}