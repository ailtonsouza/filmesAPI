using System.Collections.Generic;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.DTOs.Serie;
using FilmesAPI.DTOs.Temporada;
using FilmesAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieController : ControllerBase
    {
        private SerieDAO _SerieContext;
        private IMapper _mapper;
        
        public SerieController(IMapper mapper, ISession session)
        {
            _SerieContext = new SerieDAO(session);
            _mapper = mapper;
        }
    
        [HttpPost]
        public IActionResult AdicionarSerie([FromBody] CreateSerieDTO serieDto)
        {
            Serie serie = _mapper.Map<Serie>(serieDto);
            
            _SerieContext.Adiciona(serie);

            ReadSerieDTO readSerieDTO = _mapper.Map<ReadSerieDTO>(serie);

            return Ok(readSerieDTO);
        }
        
        [HttpGet]
        public IActionResult RecuperarSeries()
        {

            var series = _SerieContext.BuscaTodos();

            var seriesDTO = _mapper.Map<IEnumerable<ReadSerieDTO>>(series);
            
            return Ok(seriesDTO);
        }
        
        [HttpGet ("{id}")]
        public IActionResult BuscarSeriePorId(int id)
        {

            var serie = _SerieContext.BuscaPorId(id);
            if (serie == null)
            {
                return NotFound();
            }
            var serieDto = _mapper.Map<ReadSerieDTO>(serie);
            return Ok(serieDto);
        }
        
        [HttpDelete("{id}")]
        public IActionResult RemovePorId(int id)
        {
            var serie =  _SerieContext.BuscaPorId(id);
            
            if (serie == null)
            {
                return NotFound("A serie não foi encontrado");
            }

            _SerieContext.Remove(serie);
            
            return NoContent();
        }
    }
}