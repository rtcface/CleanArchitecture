
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres
{
    public class AlquilerErrors
    {
        public static Error NotFound = new Error(
            "Alquiler.Found",
            "El alquiler con el Id especificado no fue encontrado"
        );

        public static Error Overlap = new Error(
            "Alquiler.Overlap",
            "El alquiler esta siendo tomado por 2 o mas clientes al mismo tiempo en la misma fecha");

        public static Error NotReserved = new Error(
            "Alquiler.NotReserved",
            "El alquiler nop esta reservado"
        );

        public static Error NotConfirmado = new Error(
           "Alquiler.NotConfirmed",
           "El alquiler nop esta comfirmado"
       );

        public static Error AlreadyStarted = new Error(
           "Alquiler.AlreadyStarted",
           "El alquiler ya ha comenzado"
       );
    }
}