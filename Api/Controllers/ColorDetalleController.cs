using Api.Controllers;
using Api.Dtos;
using Api.Helpers.Errors;
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers;
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Authorize]
    public class ColorDetalleController : BaseApiController
{   
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public ColorDetalleController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ColorDetalleDto>>> Get()
    {
        var entidad = await unitofwork.ColorDetalles.GetAllAsync();
        return mapper.Map<List<ColorDetalleDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ColorDetalleDto>> Get(int id)
    {
        var entidad = await unitofwork.ColorDetalles.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<ColorDetalleDto>(entidad);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ColorDetalleDto>>> GetPagination([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.ColorDetalles.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<ColorDetalleDto>>(entidad.registros);
        return new Pager<ColorDetalleDto>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ColorDetalle>> Post(ColorDetalleDto entidadDto)
    {
        var entidad = this.mapper.Map<ColorDetalle>(entidadDto);
        this.unitofwork.ColorDetalles.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ColorDetalleDto>> Put(int id, [FromBody]ColorDetalleDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<ColorDetalle>(entidadDto);
        unitofwork.ColorDetalles.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.ColorDetalles.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.ColorDetalles.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}