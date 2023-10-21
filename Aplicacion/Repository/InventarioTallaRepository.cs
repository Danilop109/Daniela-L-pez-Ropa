using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class InventarioTallaRepository: GenericRepository<InventarioTalla>, IInventarioTalla
    {
        private readonly ApiJwtContext _context;

        public InventarioTallaRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<InventarioTalla>> GetAllAsync()
        {
            return await _context.InventarioTallas
            .Include(p => p.IdInventarioFk)
            .Include(p=> p.IdTallaFk)
                .ToListAsync();
        }

        public override async Task<InventarioTalla> GetByIdAsync(int id)
        {
            return await _context.InventarioTallas
            .Include(p => p.IdInventarioFk)
            .Include(p=> p.IdTallaFk)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<InventarioTalla> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.InventarioTallas as IQueryable<InventarioTalla>;

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
    //CONSULTA 7: Listar los productos y tallas del inventario. La consulta debe 
    //mostrar el id del inventario, nombre del producto, tallas y cantidad de cada talla.
    public async Task<IEnumerable<object>> GetProducSize(){
        var objeto= 
        from iTa in _context.InventarioTallas
        join i in _context.Inventarios on iTa.IdInventarioFk equals i.Id
        join t in _context.Tallas on iTa.IdTallaFk equals t.Id
        join p in _context.Prendas on i.IdPrendaFk equals p.Id
        select new{
                InventarioId = i.Id,
                NombreProducto= p.Nombre,
                Tallas= t.Descripcion,
                Cantidad= ( from iTa in _context.InventarioTallas
                select new {
                    Cantidad= iTa.Cantidad
                }).ToList()                   
        };
        return await objeto.ToListAsync();
    }
    }

}