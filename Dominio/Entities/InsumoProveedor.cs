using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class InsumoProveedor : BaseEntity
    {
        public int IdProveedorFk { get; set; }
        public Proveedor Proveedor {get; set;}
        public int IdInsumoFk { get; set; }
        public Insumo Insumo {get; set;}
    }
}