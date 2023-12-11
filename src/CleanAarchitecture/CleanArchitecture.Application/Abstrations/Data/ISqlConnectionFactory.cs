
using System.Data;


namespace CleanArchitecture.Application.Abstrations.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}