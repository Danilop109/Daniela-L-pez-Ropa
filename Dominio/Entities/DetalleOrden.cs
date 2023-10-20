using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class DetalleOrden : BaseEntity
    {
        public int CantidadProducir {get; set;}
        public int CantidadProducida {get; set;}
        public int IdOrdenFk {get; set;}
        public Orden Orden {get; set;}
        public int IdPrendaFk {get; set;}
        public Prenda Prenda {get; set;}
        public int IdColorDetalleFk {get; set;}
        public ColorDetalle ColorDetalle {get; set;}
        public int IdEstadoFk {get; set;}
        public Estado Estado {get; set;}
    }
}