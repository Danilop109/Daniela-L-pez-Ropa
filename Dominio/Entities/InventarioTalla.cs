using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class InventarioTalla : BaseEntity
    {
        public int IdInventarioFk {get; set;}
        public Inventario Inventario {get; set;}
        public int IdTallaFk {get; set;}
        public Talla Talla {get; set;}
    }
}