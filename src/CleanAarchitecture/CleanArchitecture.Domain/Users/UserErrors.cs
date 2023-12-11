
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users
{
    public class UserErrors
    {
        public static Error NotFound = new(
            "User.Found",
            "No existe el usurio buscado por este id"
            );
        public static Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "Las credenciales son incorrectas"
            );
    }
}