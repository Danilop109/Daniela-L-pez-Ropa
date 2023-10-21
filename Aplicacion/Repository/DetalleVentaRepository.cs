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
    public class DetalleVentaRepository: GenericRepository<DetalleVenta>, IDetalleVenta
    {
        private readonly ApiJwtContext _context;

        public DetalleVentaRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<DetalleVenta>> GetAllAsync()
        {
            return await _context.DetalleVentas
                .ToListAsync();
        }

        public override async Task<DetalleVenta> GetByIdAsync(int id)
        {
            return await _context.DetalleVentas
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<DetalleVenta> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.DetalleVentas as IQueryable<DetalleVenta>;

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