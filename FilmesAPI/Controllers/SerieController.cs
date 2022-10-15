using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.Dtos.Genero;
using FilmesAPI.DTOs.Serie;
using FilmesAPI.DTOs.Temporada;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieController : ControllerBase
    {
        private GenericDao<Serie> _SerieContext;
        private GenericDao<Filme> _filmeDaocontext;
        private GenericDao<Genero> _generoDaocontext;
        private GenericDao<SerieGenero> _serieGeneroDaoContext;
        private IMapper _mapper;
        
        public SerieController(IMapper mapper, ISession session)
        {
            _SerieContext = new GenericDao<Serie>(session);
            _generoDaocontext = new GenericDao<Genero>(session);
            _serieGeneroDaoContext = new GenericDao<SerieGenero>(session);
            _mapper = mapper;
        }
    
        [HttpPost]
        public IActionResult AdicionarSerie([FromBody] SerieDTO serieDto)
        {
            Serie serie = _mapper.Map<Serie>(serieDto);
            
            _SerieContext.Adiciona(serie);

            SerieDTO readSerieDTO = _mapper.Map<SerieDTO>(serie);

            return Ok(readSerieDTO);
        }
        
        [HttpGet]
        public IActionResult RecuperarSeries()
        {

            var series = _SerieContext.BuscaTodos();

            var seriesDTO = _mapper.Map<IEnumerable<SerieAgregaçõesDTO>>(series);
            
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
            var serieDto = _mapper.Map<SerieDTO>(serie);
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
        
        [HttpPatch("{id}/AddGenero")]
        public IActionResult AssociarGenero(int id, [FromBody] GeneroDTO generoIdDto)
        {


            Serie serie = _SerieContext.BuscaPorId(id);
            if (serie == null)
            {
                return NotFound("Serie não encontrada");
            }

            Genero genero = _generoDaocontext.BuscaTodos().FirstOrDefault(genero => genero.Id == generoIdDto.Id);
            if (genero == null)
            {
                return NotFound("Genero não encontrado");
            }

            SerieGenero SG = new SerieGenero();
            SG.Genero = genero;
            SG.Serie = serie;
            
            serie.SerieGenero.Add(SG);
            
            _SerieContext.Update(serie);
            
            var updatedSerieDto = _mapper.Map<SerieAgregaçõesDTO>(serie);
            
            return Ok(updatedSerieDto);
        }
        
        
        [HttpDelete("RemoveGenero")]
        public IActionResult RemoveGenero([FromBody] SerieDTO generoIdDto)
        {

            SerieGenero serieGenero = _serieGeneroDaoContext.BuscaPorId(generoIdDto.Id);

            if (serieGenero == null)
            {
                return NotFound("Registro não encontrado");
            }

            
            _serieGeneroDaoContext.Remove(serieGenero);
            
            return NoContent();
        }
        
        
        [HttpPatch("{id}")]
        public IActionResult AtualizarSerie(int id, [FromBody] SerieDTO serieDTO)
        {
            Serie serie = _SerieContext.BuscaPorId(id);
            if (serie == null)
            {
                return NotFound("Serie não encontrado");
            }

            if (serieDTO.Titulo != null)
            {
                serie.Titulo = serieDTO.Titulo;
            }
  
            _SerieContext.Update(serie);
            
            var updateSerieDto = _mapper.Map<SerieDTO>(serie);
        
            return Ok(updateSerieDto);
        
        }
        
        
    }
}