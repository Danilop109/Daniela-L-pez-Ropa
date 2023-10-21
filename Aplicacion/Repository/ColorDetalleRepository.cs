using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class ColorDetalleRepository : GenericRepository<ColorDetalle>, IColorDetalle
    {
        private readonly ApiJwtContext _context;

        public ColorDetalleRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<ColorDetalle>> GetAllAsync()
        {
            return await _context.ColoreDetalles
                .ToListAsync();
        }

        public override async Task<ColorDetalle> GetByIdAsync(int id)
        {
            return await _context.ColoreDetalles
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<ColorDetalle> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.ColoreDetalles as IQueryable<ColorDetalle>;

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
    }
}