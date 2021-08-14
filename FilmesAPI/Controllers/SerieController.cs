using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.DTOs.Serie;
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
    }
}