using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Vehiculos
{
    public sealed class Vehiculo : Entity
    {
        public Vehiculo(
            Guid id,
            Modelo modelo,
            Vin vin,
            Moneda precio,
            Moneda mantenimiento,
            DateTime? fechaUltimoAlquiler,
            List<Accesorios> accesorios,
            Direccion? direccion

        ) : base(id)
        {
            Modelo = modelo;
            Vin = vin;
            Precio = precio;
            Mantenimiento = mantenimiento;
            FechaUltimoAlquiler = fechaUltimoAlquiler;
            Accesorios = accesorios;
            Direccion = direccion;
        }

        public Modelo? Modelo { get; private set; }

        public Vin? Vin { get; private set; }

        public Direccion? Direccion { get; private set; }

        public Moneda Precio { get; private set; }

        public Moneda Mantenimiento { get; set; }

        public DateTime? FechaUltimoAlquiler { get; internal set; }

        public List<Accesorios> Accesorios { get; private set; } = new();


    }
}