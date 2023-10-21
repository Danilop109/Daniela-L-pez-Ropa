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
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
    {
        private readonly ApiJwtContext _context;

        public EmpleadoRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Empleados
                .ToListAsync();
        }

        public override async Task<Empleado> GetByIdAsync(int id)
        {
            return await _context.Empleados
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<Empleado> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Empleados as IQueryable<Empleado>;

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