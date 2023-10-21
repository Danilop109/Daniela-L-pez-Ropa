using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistencia;
namespace Aplicacion.Repository
{
    public class VentaRepository: GenericRepository<Venta>, IVenta
    {
        private readonly ApiJwtContext _context;

        public VentaRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<Venta>> GetAllAsync()
        {
            return await _context.Ventas
                .ToListAsync();
        }

        public override async Task<Venta> GetByIdAsync(int id)
        {
            return await _context.Ventas
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<Venta> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Ventas as IQueryable<Venta>;

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

    //Consulta 6: Listar las ventas realizadas por un empleado especifico. El usuario debe ingresar el Id del empleado y mostrar la siguiente información.
    //1. Id Empleado
    //2. Nombre del empleado
    //3. Fecturas : Nro Factura, fecha y total de la factura.
    public async Task<IEnumerable<object>> GetByIdEmpleado (int IdEmpleado)
    {
        var objeto= from v in _context.Ventas
                    join e in _context.Empleados on v.IdEmpleadoFk equals e.Id
                    where v.IdEmpleadoFk == IdEmpleado
                    select new {
                        IdEmpleado= e.Id,
                        Nombre= e.Nombre,
                        Factura = (from dv in _context.DetalleVentas
                                    join v in _context.Ventas on dv.IdVentaFk equals v.Id
                                    select new {
                                        NumFactura= dv.IdVentaFk,
                                        Fecha= v.Fecha,
                                        Total= dv.Cantidad * dv.ValorUnit 
                                    }

                        ).ToList()

                    };
          return await objeto.ToListAsync();
    }

    }
}