using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.DTOs.Temporada;
using FilmesAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemporadaController : ControllerBase
    {
        private TemporadaDAO _TemporaContext;
        private SerieDAO _SerieContext;
        private AtorDAO _AtorContext;
        private DiretorDAO _DiretorContext;
        private IMapper _mapper;

        public TemporadaController(IMapper mapper, ISession session)
        {
            _TemporaContext = new TemporadaDAO(session);
            _SerieContext = new SerieDAO(session);
            _AtorContext = new AtorDAO(session);
            _DiretorContext = new DiretorDAO(session);
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarTemporada([FromBody] CreateTemporadaDTO temporadaDto)
        {
            Temporada temporada = _mapper.Map<Temporada>(temporadaDto);
            Serie serie = _SerieContext.BuscaPorId(temporadaDto.SerieId);
            temporada.Serie = serie;
            _TemporaContext.Adiciona(temporada);
            ReadTemporadaDTO readTemporadaDto = _mapper.Map<ReadTemporadaDTO>(temporada);
            return Ok(readTemporadaDto);
        }
        
        [HttpGet]
        public IActionResult RecuperarTemporadas()
        {

            var temporadas = _TemporaContext.BuscaTodos();

            var temporadasDTO = _mapper.Map<IEnumerable<ReadTemporadaDTO>>(temporadas);
            
            return Ok(temporadasDTO);
        }

        [HttpPatch("{id}/ator")]
        public IActionResult AdicionarAtorTemporada(int id, int ids, [FromBody] InsertAtorTemporadaDTO AtorDTO )
        {
            Temporada temporada = _TemporaContext.BuscaPorId(id);
            if (temporada == null)
            {
                return NotFound("Temporada não foi encontrada"); 
            }
            
             Ator ator = _AtorContext.BuscaPorId(AtorDTO.AtorId);
             if (ator == null)
             {
                 return NotFound("Ator não foi encontrado"); 
             }
             
             temporada.Ator.Add(ator);
             _TemporaContext.Update(temporada);
            
             ReadTemporadaDTO temporadaDto = _mapper.Map<ReadTemporadaDTO>(temporada);
            return Ok(temporadaDto);
        }
        
        
        [HttpPatch("{id}/diretor")]
        public IActionResult AdicionarDiretorTemporada(int id, InsertDiretorTemporadaDTO diretorDTO)
        {
            Temporada temporada = _TemporaContext.BuscaPorId(id);
            if (temporada == null)
            {
                return NotFound("Temporada não foi encontrada"); 
            }
            
            Diretor diretor = _DiretorContext.BuscaPorId(diretorDTO.DiretorId);
            if (diretor == null)
            {
                return NotFound("Ator não foi encontrado"); 
            }
             
            temporada.Diretor.Add(diretor);
            _TemporaContext.Update(temporada);
            
            ReadTemporadaDTO temporadaDto = _mapper.Map<ReadTemporadaDTO>(temporada);
            return Ok(temporadaDto);

        }
        
        [HttpGet ("{id}")]
        public IActionResult BuscarTemporadaPorId(int id)
        {

            var temporada = _TemporaContext.BuscaPorId(id);
            if (temporada == null)
            {
                return NotFound();
            }
            var temporadaDto = _mapper.Map<ReadTemporadaDTO>(temporada);
            return Ok(temporadaDto);
        }
        
        [HttpDelete("{id}")]
        public IActionResult RemoveTemporadaPorId(int id)
        {
            var temporada =  _TemporaContext.BuscaPorId(id);
            
            if (temporada == null)
            {
                return NotFound("A temporada não foi encontrado");
            }

            _TemporaContext.Remove(temporada);
            
            return NoContent();
        }
    }
    
    
}