using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces
{
    public interface IPrenda : IGenericRepository<Prenda>
    {
        abstract Task<IEnumerable<object>> GetInsumosByPrenda(int idPrenda);
    }
}