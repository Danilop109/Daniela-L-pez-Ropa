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
    public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
    {
        private readonly ApiJwtContext _context;

        public TipoPersonaRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
        {
            return await _context.TipoPersonas
                .ToListAsync();
        }

        public override async Task<TipoPersona> GetByIdAsync(int id)
        {
            return await _context.TipoPersonas
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<TipoPersona> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.TipoPersonas as IQueryable<TipoPersona>;

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

        // private readonly ApiJwtContext _context;

        // public PersonaRepository(ApiJwtContext context) : base(context)
        // {
        //     _context = context;
        // }

        // public override async Task<IEnumerable<Persona>> GetAllAsync()
        // {
        //     return await _context.Personas
        //     .Include(p => p.TipoPersona)
        //     .ToListAsync();
        // }

        // public override async Task<Persona> GetByIdAsync(int id)
        // {
        //     return await _context.Personas
        //     .Include(p => p.TipoPersona)
        //     .FirstOrDefaultAsync(p => p.Id == id);
        // }


    }
}