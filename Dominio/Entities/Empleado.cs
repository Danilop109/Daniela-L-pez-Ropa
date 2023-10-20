using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Empleado : BaseEntity
    {
        public int IdEmpleado {get; set;}
        public string Nombre { get; set; }
        public DateOnly FechaIngreso {get; set; }
        public int IdCargoFk { get; set; }
        public Cargo Cargo {get; set;}
        public int IdMunicipioFk {get; set;}
        public Municipio Municipio {get; set;}
        public ICollection<DetalleVenta> DetalleVentas {get; set;}
        public ICollection<Orden> Ordenes {get; set;}
        public ICollection<Venta> Ventas {get; set;}


    }
}