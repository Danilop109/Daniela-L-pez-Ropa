using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;
namespace Aplicacion.Repository
{
    public class PrendaRepository: GenericRepository<Prenda>, IPrenda
    {
        private readonly ApiJwtContext _context;

        public PrendaRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<Prenda>> GetAllAsync()
        {
            return await _context.Prendas
                .ToListAsync();
        }

        public override async Task<Prenda> GetByIdAsync(int id)
        {
            return await _context.Prendas
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<Prenda> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Prendas as IQueryable<Prenda>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    //CONSULTA 1:Listar los insumos que pertenecen a una prenda especifica. El usuario debe ingresar el código de la prenda.
    public async Task<IEnumerable<object>> GetInsumosByPrenda(int idPrenda)
    {
        var objeto = from ip in _context.InsumoPrendas
                      join p in _context.Prendas on ip.IdPrendaFk equals p.Id
                      where p.Id == idPrenda
                      select new
                      {
                          idPrenda = p.Id,
                          insumo = (from ip in _context.InsumoPrendas
                            join i in _context.Insumos on ip.IdInsumoFk equals i.Id
                            select new
                          {
                              Nombre = i.Nombre,
                              ValorUnidad = i.ValorUnit,
                              stockMin = i.StockMin,
                              stockMax = i.StockMax

                          }).ToList()
                      };
                      return await objeto.ToListAsync();
    }
}
}