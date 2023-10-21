using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;
namespace Aplicacion.Repository
{
    public class InsumoProveedorRepository: GenericRepository<InsumoProveedor>, IInsumoProveedor
    {
        private readonly ApiJwtContext _context;

        public InsumoProveedorRepository(ApiJwtContext context) : base(context)
        {
            _context = context;
        }

         public override async Task<IEnumerable<InsumoProveedor>> GetAllAsync()
        {
            return await _context.InsumoProveedores
                .ToListAsync();
        }

        public override async Task<InsumoProveedor> GetByIdAsync(int id)
        {
            return await _context.InsumoProveedores
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRegistros, IEnumerable<InsumoProveedor> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.InsumoProveedores as IQueryable<InsumoProveedor>;

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

    //CONSULTA 2 : Listar los Insumos que son vendidos por un determinado proveedor cuyo 
    //tipo de persona sea Persona Jurídica. El usuario debe ingresar el Nit de proveedor.

        // public async Task<IEnumerable<object>> GetInsumosVendidosPorPersonaJuridica(int nit)
        // {
        //     var objeto= from ip in _context.InsumoProveedores
        //     join i in _context.Insumos on ip.IdInsumoFk equals i.Id

        // }
    }
}