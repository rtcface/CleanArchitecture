
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Alquileres
{
    public class PrecioService
    {
        public PrecioDetalle CalcularPrecio(Vehiculo vehiculo, DateRange periodo)
        {

            var tipoMondeda = vehiculo.Precio!.tipoMoneda;

            var precioPorPeriodo = new Moneda(periodo.CantidadDias * vehiculo.Precio.Monto, tipoMondeda);

            decimal porcentageChange = 0;

            foreach (var accesorio in vehiculo.Accesorios)
            {
                porcentageChange += accesorio switch
                {
                    Accesorios.AppleCar or Accesorios.AndroidCar => 0.05m,
                    Accesorios.AireAcondicionado => 0.01m,
                    Accesorios.Mapas => 0.01m,
                    _ => 0
                };
            }

            var accesorioCharges = Moneda.Zero(tipoMondeda);

            if (porcentageChange > 0)
            {
                accesorioCharges = new Moneda(precioPorPeriodo.Monto * porcentageChange, tipoMondeda);
            }

            var precioTotal = Moneda.Zero();
            precioTotal += precioPorPeriodo;

            if (!vehiculo!.Mantenimiento!.IsZero())
            {
                precioTotal += vehiculo.Mantenimiento;
            }

            precioTotal += accesorioCharges;

            return new PrecioDetalle(
                precioPorPeriodo,
                vehiculo.Mantenimiento,
                accesorioCharges,
                precioTotal);


        }

    }
}