using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Proveedor : BaseEntity
    {
        public int NitProveedor { get; set; }
        public string Nombre { get; set; }
        public int IdTipoPersona {get; set;}
        public TipoPersona TipoPersona {get; set;}
        public int IdMunicipioFk {get; set;}
        public Municipio Muncipio {get; set;}
        public ICollection<InsumoProveedor> InsumoProveedores {get; set;}
    }
}