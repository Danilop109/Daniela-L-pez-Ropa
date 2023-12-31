using Api.Dtos;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace Api.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    { 
        CreateMap<Rol,RolDto>().ReverseMap();
        CreateMap<User,UserDto>().ReverseMap();
        CreateMap<Cargo,CargoDto>().ReverseMap();
        CreateMap<Cliente,ClienteDto>().ReverseMap();
        CreateMap<ColorDetalle,ColorDetalleDto>().ReverseMap();
        CreateMap<Departamento,DepartamentoDto>().ReverseMap();
        CreateMap<DetalleOrden,DetalleOrdenDto>().ReverseMap();
        CreateMap<DetalleVenta,DetalleVentaDto>().ReverseMap();
        CreateMap<Empleado,EmpleadoDto>().ReverseMap();
        CreateMap<Empresa,EmpresaDto>().ReverseMap();
        CreateMap<Estado,EstadoDto>().ReverseMap();
        CreateMap<FormaPago,FormaPagoDto>().ReverseMap();
        CreateMap<Genero,GeneroDto>().ReverseMap();
        CreateMap<Insumo,InsumoDto>().ReverseMap();
        CreateMap<InsumoPrenda,InsumoPrendaDto>().ReverseMap();
        CreateMap<InsumoProveedor,InsumoProveedorDto>().ReverseMap();
        CreateMap<Inventario,InventarioDto>().ReverseMap();
        CreateMap<InventarioTalla,InventarioTallaDto>().ReverseMap();
        CreateMap<Municipio,MunicipioDto>().ReverseMap();
        CreateMap<Orden,OrdenDto>().ReverseMap();
        CreateMap<Pais,PaisDto>().ReverseMap();
        CreateMap<Prenda,PrendaDto>().ReverseMap();
        CreateMap<Proveedor,ProveedorDto>().ReverseMap();
        CreateMap<Talla,TallaDto>().ReverseMap();
        CreateMap<TipoEstado,TipoEstadoDto>().ReverseMap();
        CreateMap<TipoPersona,TipoPersonaDto>().ReverseMap();
        CreateMap<TipoProteccion,TipoProteccionDto>().ReverseMap();
        CreateMap<Venta,VentaDto>().ReverseMap();
      

    }
}
