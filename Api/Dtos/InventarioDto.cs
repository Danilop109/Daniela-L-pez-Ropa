using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class InventarioDto
    {
        public int Id { get; set; }
        public int CodInventario {get; set;}
        public double ValorVtaCop {get; set;}
        public double ValorVtaUsd {get; set;}
        public int IdPrendaFk {get; set;}
        public PrendaDto Prenda {get; set;}
    }
}