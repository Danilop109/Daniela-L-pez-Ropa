using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TallaRepository: GenericRepository<Talla>, ITalla
    {
        private readonly ApiJwtContext _context;

        public TallaRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<Talla>> GetAllAsync()
        {
            return await _context.Tallas
                .ToListAsync();
        }

        public override async Task<Talla> GetByIdAsync(int id)
        {
            return await _context.Tallas
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<Talla> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Tallas as IQueryable<Talla>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    }
}