using AutoMapper;
using FilmesAPI.DAO;
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
        private IMapper _mapper;

        public TemporadaController(IMapper mapper, ISession session)
        {
            _TemporaContext = new TemporadaDAO(session);
            _SerieContext = new SerieDAO(session);
            _AtorContext = new AtorDAO(session);
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarTemporada([FromBody] CreateTemporadaDTO temporadaDto)
        {
            Temporada temporada = _mapper.Map<Temporada>(temporadaDto);
            Serie serie = _SerieContext.BuscaPorId(temporadaDto.SerieId);
            temporada.Serie = serie;
            _TemporaContext.Adiciona(temporada);
            return Ok(temporada);
        }
        
        [HttpPost("{id}")]
        public IActionResult AdicionarAtorTemporada(int id, [FromBody] int atorid)
        {
            // Temporada temporada = _TemporaContext.BuscaPorId(id);
            // if (temporada == null)
            // {
            //     return NotFound(); 
            // }

             //Ator ator = _AtorContext.BuscaPorId(atorID);
             // temporada.Ator.Add(ator);
             // _TemporaContext.Update(temporada);
            return Ok(atorid);
        }
    }
}