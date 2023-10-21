using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ProveedorDto
    {
        public int Id { get; set; }
        public int NitProveedor { get; set; }
        public string Nombre { get; set; }
        public int IdTipoPersonaFk {get; set;}
        public TipoPersonaDto TipoPersona {get; set;}
        public int IdMunicipioFk {get; set;}
        public MunicipioDto Municipio {get; set;}
    }
}