using System.Collections.Generic;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.DTOs.Epsodio;
using FilmesAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EpsodioController : ControllerBase

    {
    private EpsodioDAO _Epsodiocontext;
    private TemporadaDAO _TemporaContext;
    private IMapper _mapper;

    
    
    public EpsodioController(IMapper mapper, ISession session)
    {
        _mapper = mapper;
        _Epsodiocontext = new EpsodioDAO(session);
        _TemporaContext = new TemporadaDAO(session);
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateEpsodioDTO epsodioDto)
    {

         Epsodio epsodio = _mapper.Map<Epsodio>(epsodioDto);
     
         Temporada temporada = _TemporaContext.BuscaPorId(epsodioDto.TemporadaId);
         if (temporada == null)
         {
             return NotFound("Temporada não encontrada");
         }
         epsodio.Temporada = temporada;
         _Epsodiocontext.Adiciona(epsodio);
         ReadEpsodioDTO ep = _mapper.Map<ReadEpsodioDTO>(epsodio);
        return Ok(ep);
    }


    [HttpGet]
    public IActionResult BuscarTodos()
    {
        var epsodio = _Epsodiocontext.BuscaTodos();
        var ep = _mapper.Map<IList<ReadEpsodioDTO>>(epsodio);
        return Ok(ep);
    }
    
    [HttpGet ("{id}")]
    public IActionResult BuscarEpsodioPorId(int id)
    {

        var epsodio = _Epsodiocontext.BuscaPorId(id);
        if (epsodio == null)
        {
            return NotFound();
        }
        var epsodioDto = _mapper.Map<ReadEpsodioDTO>(epsodio);
        return Ok(epsodioDto);
    }
    
    
    [HttpDelete("{id}")]
    public IActionResult RemoveEpsodioPorId(int id)
    {
        var epsodio =  _Epsodiocontext.BuscaPorId(id);
            
        if (epsodio == null)
        {
            return NotFound("O Epsodio não foi encontrado");
        }

        _Epsodiocontext.Remove(epsodio);
            
        return NoContent();
    }
    
    
    }
}