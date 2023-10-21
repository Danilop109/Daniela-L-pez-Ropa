using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiJwtContext _context;
        private UserRepository _users;
        private RolRepository _roles;
        private CargoRepository _cargos;
        private ClienteRepository _clientes;
        private ColorDetalleRepository _colorDetalles;
        private DepartamentoRepository _departamentos;
        private DetalleOrdenRepository _DetalleOrdenes;
        private DetalleVentaRepository _DetalleVentas;
        private EmpleadoRepository _Empleados;
        private EmpresaRepository _Empresas;
        private EstadoRepository _Estados;
        private FormaPagoRepository _FormaPagos;
        private GeneroRepository _Generos;
        private InsumoRepository _Insumos;
        private InsumoPrendaRepository _InsumoPrendas;
        private InsumoProveedorRepository _InsumoProveedores;
        private InventarioRepository _Inventarios;
        private InventarioTallaRepository _InventarioTallas;
        private MunicipioRepository _Municipios;
        private OrdenRepository _Ordenes;
        private PaisRepository _Paises;
        private PrendaRepository _Prendas;
        private ProveedorRepository _Proveedores;
        private TallaRepository _Tallas;
        private TipoEstadoRepository _TipoEstados;
        private TipoPersonaRepository _TipoPersonas;
        private TipoProteccionRepository _TipoProtecciones;
        private VentaRepository _Ventas;
        private PaisRepository _Pais;
        public UnitOfWork(ApiJwtContext context)
        {
            _context = context;
        }

        public IRol Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public ICargo Cargos {
            get
            {
                if (_cargos== null)
                {
                    _cargos= new CargoRepository(_context);
                }
                return _cargos;
            }
        }

        public ICliente Clientes{
            get
            {
                if (_clientes== null)
                {
                    _clientes= new ClienteRepository(_context);
                }
                return _clientes;
            }
        }

        public IColorDetalle ColorDetalles {
            get
            {
                if (_colorDetalles== null)
                {
                    _colorDetalles= new ColorDetalleRepository(_context);
                }
                return _colorDetalles;
            }
        }

        public IDepartamento Departamentos {
            get
            {
                if (_departamentos== null)
                {
                    _departamentos= new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }

        public IDetalleOrden DetalleOrdenes{
            get
            {
                if (_DetalleOrdenes== null)
                {
                    _DetalleOrdenes= new DetalleOrdenRepository(_context);
                }
                return _DetalleOrdenes;
            }
        }
        public IDetalleVenta DetalleVentas {
            get
            {
                if (_DetalleVentas== null)
                {
                    _DetalleVentas= new DetalleVentaRepository(_context);
                }
                return _DetalleVentas;
            }
        }

        public IEmpleado Empleados {
            get
            {
                if (_Empleados== null)
                {
                    _Empleados= new EmpleadoRepository(_context);
                }
                return _Empleados;
            }
        }

        public IEmpresa Empresas {
            get
            {
                if (_Empresas== null)
                {
                    _Empresas= new EmpresaRepository(_context);
                }
                return _Empresas;
            }
        }

        public IEstado Estados {
            get
            {
                if (_Estados== null)
                {
                    _Estados= new EstadoRepository(_context);
                }
                return _Estados;
            }
        }
        public IFormaPago FormaPagos{
            get
            {
                if (_FormaPagos== null)
                {
                    _FormaPagos= new FormaPagoRepository(_context);
                }
                return _FormaPagos;
            }
        }

        public IGenero Generos{
            get
            {
                if (_Generos== null)
                {
                    _Generos= new GeneroRepository(_context);
                }
                return _Generos;
            }
        }

        public IInsumo Insumos{
            get
            {
                if (_Insumos== null)
                {
                    _Insumos= new InsumoRepository(_context);
                }
                return _Insumos;
            }
        }

        public IInsumoPrenda InsumoPrendas {
            get
            {
                if (_InsumoPrendas== null)
                {
                    _InsumoPrendas= new InsumoPrendaRepository(_context);
                }
                return _InsumoPrendas;
            }
        }
        public IInsumoProveedor InsumoProveedores {
            get
            {
                if (_InsumoProveedores== null)
                {
                    _InsumoProveedores= new InsumoProveedorRepository(_context);
                }
                return _InsumoProveedores;
            }
        }
        public IInventario Inventarios {
            get
            {
                if (_Inventarios== null)
                {
                    _Inventarios= new InventarioRepository(_context);
                }
                return _Inventarios;
            }
        }

        public IInventarioTalla InventarioTallas {
            get
            {
                if (_InventarioTallas== null)
                {
                    _InventarioTallas= new InventarioTallaRepository(_context);
                }
                return _InventarioTallas;
            }
        }

        public IMunicipio Municipios {
            get
            {
                if (_Municipios== null)
                {
                    _Municipios= new MunicipioRepository(_context);
                }
                return _Municipios;
            }
        }

        public IOrden Ordenes {
            get
            {
                if (_Ordenes== null)
                {
                    _Ordenes= new OrdenRepository(_context);
                }
                return _Ordenes;
            }
        }

        public IPais Paises {
            get
            {
                if (_Paises== null)
                {
                    _Paises= new PaisRepository(_context);
                }
                return _Paises;
            }
        }

        public IPrenda Prendas{
            get
            {
                if (_Prendas== null)
                {
                    _Prendas= new PrendaRepository(_context);
                }
                return _Prendas;
            }
        }

        public IProveedor Proveedores {
            get
            {
                if (_Proveedores== null)
                {
                    _Proveedores= new ProveedorRepository(_context);
                }
                return _Proveedores;
            }
        }

        public ITalla Tallas{
            get
            {
                if (_Tallas== null)
                {
                    _Tallas= new TallaRepository(_context);
                }
                return _Tallas;
            }
        }

        public ITipoEstado TipoEstados {
            get
            {
                if (_TipoEstados== null)
                {
                    _TipoEstados= new TipoEstadoRepository(_context);
                }
                return _TipoEstados;
            }
        }

        public ITipoProteccion TipoProtecciones {
            get
            {
                if (_TipoProtecciones== null)
                {
                    _TipoProtecciones= new TipoProteccionRepository(_context);
                }
                return _TipoProtecciones;
            }
        }

        public IVenta Ventas{
            get
            {
                if (_Ventas== null)
                {
                    _Ventas= new VentaRepository(_context);
                }
                return _Ventas;
            }
        }

        public ITipoPersona TipoPersonas {
            get
            {
                if (_TipoPersonas== null)
                {
                    _TipoPersonas= new TipoPersonaRepository(_context);
                }
                return _TipoPersonas;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}