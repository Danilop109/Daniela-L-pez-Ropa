using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class DetalleOrdenDto
    {
        public int Id { get; set; }
        public int CantidadProducir {get; set;}
        public int CantidadProducida {get; set;}
        public int IdOrdenFk {get; set;}
        public OrdenDto Orden {get; set;}
        public int IdPrendaFk {get; set;}
        public PrendaDto Prenda {get; set;}
        public int IdColorDetalleFk {get; set;}
        public ColorDetalleDto ColorDetalle {get; set;}
        public int IdEstadoFk {get; set;}
        public EstadoDto Estado {get; set;}
    }
}