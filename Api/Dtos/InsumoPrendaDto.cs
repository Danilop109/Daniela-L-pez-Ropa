using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class InsumoPrendaDto
    {
        public int Id { get; set; }
        public int Cantidad {get; set;}
        public int IdInsumoFk {get; set;}
        public InsumoDto Insumo {get; set;}
        public int IdPrendaFk {get; set;}
        public PrendaDto Prenda {get; set;}
    }
}