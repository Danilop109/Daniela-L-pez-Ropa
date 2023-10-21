using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaRegistro {get; set;}
        public int IdTipoPersonaFk {get; set;}
        public TipoEstadoDto TipoPersona {get; set;}
        public int IdMunicipioFk {get; set;}
        public MunicipioDto Municipio {get; set;}
    }
}