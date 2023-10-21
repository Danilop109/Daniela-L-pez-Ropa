using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public int IdEmpleado {get; set;}
        public string Nombre { get; set; }
        public DateOnly FechaIngreso {get; set; }
        public int IdCargoFk { get; set; }
        public CargoDto Cargo {get; set;}
        public int IdMunicipioFk {get; set;}
        public MunicipioDto Municipio {get; set;}
    }
}