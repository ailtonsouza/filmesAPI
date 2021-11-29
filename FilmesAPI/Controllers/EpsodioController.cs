using System;
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
    public IActionResult AdicionaEpsodio([FromBody] EpsodioDTO epsodioDto)
    {

         Epsodio epsodio = _mapper.Map<Epsodio>(epsodioDto);
     
         Temporada temporada = _TemporaContext.BuscaPorId(epsodioDto.TemporadaId);
         if (temporada == null)
         {
             return NotFound("Temporada não encontrada\\informada");
         }
         epsodio.Temporada = temporada;
         _Epsodiocontext.Adiciona(epsodio);
         EpsodioDTO ep = _mapper.Map<EpsodioDTO>(epsodio);
        return Ok(ep);
    }


    [HttpGet]
    public IActionResult BuscarTodos()
    {
        var epsodio = _Epsodiocontext.BuscaTodos();
        var ep = _mapper.Map<IList<EpsodioTemporadaDTO>>(epsodio);
        return Ok(ep);
    }
    
    [HttpGet ("{id}")]
    public IActionResult BuscarEpsodioPorId(int id)
    {

        var epsodio = _Epsodiocontext.BuscaPorId(id);
        if (epsodio == null)
        {
            return NotFound("Epsodio não foi encontrado");
        }
        var epsodioDto = _mapper.Map<EpsodioTemporadaDTO>(epsodio);
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
    
    
    
    [HttpPatch("{id}")]
    public IActionResult AtualizaEpsodio(int id, [FromBody] EpsodioDTO epsodioDTO)
    {
        Epsodio epsodio = _Epsodiocontext.BuscaPorId(id);
        if (epsodio == null)
        {
            return NotFound("Epsodio não encontrado");
        }
            
        if (epsodioDTO.Titulo != null)
        {
            epsodio.Titulo = epsodioDTO.Titulo;
        }
        
        if (epsodioDTO.Duracao != null)
        {
            epsodio.Duracao = epsodioDTO.Duracao;
        }
        
        if (epsodioDTO.NumeroEpsodio != null)
        {
            epsodio.NumeroEpsodio = epsodioDTO.NumeroEpsodio;
        }
    
        _Epsodiocontext.Update(epsodio);
            
        var updateEpsodioDto = _mapper.Map<EpsodioDTO>(epsodio);
        
        return Ok(updateEpsodioDto);
        
    }


    
    
    [HttpPatch("{id}/Temporada")]
        public IActionResult AtualizaTemporada(int id, [FromBody] EpsodioDTO epsodioDTO)
        {
        
            var epsodio = _Epsodiocontext.BuscaPorId(id);
            if (epsodio == null)
            {
                return NotFound("Epsodio não foi encontrado");
            }
            

      
                Temporada temporada = _TemporaContext.BuscaPorId(epsodioDTO.TemporadaId);
                if (temporada == null)
                {
                    return NotFound("Temporada não encontrada'\'não informada");
                }

                epsodio.Temporada = temporada;
       
            
            _Epsodiocontext.Update(epsodio);
            
            var updateEpsodioDto = _mapper.Map<EpsodioDTO>(epsodio);
        
            return Ok(updateEpsodioDto);

        }
    
    
    
    


    }
    
    
}