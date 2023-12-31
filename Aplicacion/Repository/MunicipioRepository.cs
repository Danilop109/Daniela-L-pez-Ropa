using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class MunicipioRepository: GenericRepository<Municipio>, IMunicipio
    {
        private readonly ApiJwtContext _context;

        public MunicipioRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<Municipio>> GetAllAsync()
        {
            return await _context.Municipios
                .ToListAsync();
        }

        public override async Task<Municipio> GetByIdAsync(int id)
        {
            return await _context.Municipios
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<Municipio> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Municipios as IQueryable<Municipio>;

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
    }
}