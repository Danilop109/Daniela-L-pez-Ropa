using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;
namespace Aplicacion.Repository
{
    public class OrdenRepository: GenericRepository<Orden>, IOrden
    {
        private readonly ApiJwtContext _context;

        public OrdenRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<Orden>> GetAllAsync()
        {
            return await _context.Ordenes
                .ToListAsync();
        }

        public override async Task<Orden> GetByIdAsync(int id)
        {
            return await _context.Ordenes
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<Orden> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Ordenes as IQueryable<Orden>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.ToString().ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    //CONSULTA 5: Listar las ordenes de producción que pertenecen a un cliente especifico. El usuario debe ingresar el IdCliente y debe obtener la siguiente información:
    //1. IdCliente, Nombre, Municipio donde se encuentra ubicado.
    //2. Nro de orden de producción, fecha y el estado de la orden de producción (Se debe mostrar la descripción del estado, código del estado, valor total de la orden de producción.
    //3. Detalle de orden: Nombre de la prenda, Código de la prenda, Cantidad, Valor total en pesos y en dólares.
        public async Task<IEnumerable<object>> GetOrderByClientId(int IdCliente)
        {
            var objeto = from o in _context.Ordenes
            join c in _context.Clientes on o.IdClienteFk equals c.Id
            join m in _context.Municipios on c.IdMunicipioFk equals m.Id
            where c.Id == IdCliente
            select new {
                    IdCliente = c.Id,
                    municipio= m.Nombre,
                    NunOrden= o.Id,
                    fecha = o.Fecha, 
                    estado = (from o in _context.Ordenes
                        join est in _context.Estados on o.IdEstadoFk equals est.Id
                        join dor in _context.DetalleOrdenes on o.Id equals dor.IdColorDetalleFk
                        join p in _context.Prendas on dor.IdPrendaFk equals p.Id
                        where dor.Id == o.Id
                    select new {
                            Descripcion= est.Descripcion,
                            Codigo= est.Id,
                            ValorTotal= (p.ValorUnitCop* dor.CantidadProducida) + (p.ValorUnitUsd* dor.CantidadProducida),
                            prenda = (from dp in _context.DetalleOrdenes
                            join p in _context.Prendas on dp.IdPrendaFk equals p.Id
                            select new{
                                NombrePrenda= p.Nombre,
                                CodigoPrenda= p.IdPrenda,
                                Cantidad= dp.CantidadProducida,
                                ValorTotalPesos= p.ValorUnitCop* dp.CantidadProducida,
                                ValoTotalDolar= p.ValorUnitUsd* dp.CantidadProducida
                            }

                            ).ToList()
                    }
                    ).ToList()
                    
            };

            return await objeto.ToListAsync();
        }

        // CONSULTA 4: Listar todas las ordenes de producción cuyo estado se en proceso.
        public async Task<IEnumerable<object>> GetOrderByState()
        {
            var objeto = from o in _context.DetalleOrdenes 
            join dord in _context.Ordenes on o.IdOrdenFk equals dord.Id
            join e in _context.Estados on o.IdEstadoFk equals e.Id
            where e.Descripcion == "En Proceso"
            select new {
                    Id= dord.Id,
                    Fecha = dord.Fecha,
                    CantidadProducida = o.CantidadProducida
            };
            return await objeto.ToListAsync();
        }

    }
}