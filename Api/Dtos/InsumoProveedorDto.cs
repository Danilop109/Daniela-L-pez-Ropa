using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class InsumoProveedorDto
    {
        public int Id { get; set; }
        public int IdProveedorFk { get; set; }
        public ProveedorDto Proveedor {get; set;}
        public int IdInsumoFk { get; set; }
        public InsumoDto Insumo {get; set;}
    }
}