using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        IRol Roles { get; }
        IUser Users { get; }
        ICargo Cargos { get; }
        ICliente Clientes { get; }
        IColorDetalle ColorDetalles { get; }
        IDepartamento Departamentos { get; }
        IDetalleOrden DetalleOrdenes { get; }
        IDetalleVenta DetalleVentas {get;}
        IEmpleado Empleados { get; }
        IEmpresa Empresas {get;}
        IEstado Estados { get; }
        IFormaPago FormaPagos {get;}
        IGenero Generos {get;}
        IInsumo Insumos {get;}
        IInsumoPrenda InsumoPrendas {get;}
        IInsumoProveedor InsumoProveedores {get;}
        IInventario Inventarios {get;}
        IInventarioTalla InventarioTallas {get;}
        IMunicipio Municipios {get;}
        IOrden Ordenes {get;}
        IPais Paises {get;}
        IPrenda Prendas {get;}
        IProveedor Proveedores {get;}
        ITalla Tallas {get;}
        ITipoEstado TipoEstados {get;}
        ITipoPersona TipoPersonas {get;}
        ITipoProteccion TipoProtecciones {get;}
        IVenta Ventas {get;}

        Task<int> SaveAsync();
    }
}