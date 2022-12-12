using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.DTOs.Ator;
using FilmesAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtorController :ControllerBase
    {
        private GenericDao<Ator> _AtorContext;
        private IMapper _mapper;

        public AtorController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _AtorContext = new GenericDao<Ator>(session);
        }
        
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var atores = _AtorContext.BuscaTodos();
            var ep = _mapper.Map<IList<AtorDTO>>(atores);
            return Ok(ep);
        }
        
        [HttpPost]
        public IActionResult AdicionaAtor ([FromBody] AtorDTO atorDto)
        {
        
            Ator ator = _mapper.Map<Ator>(atorDto);
            _AtorContext.Adiciona(ator);
            AtorDTO ReadAtorDto = _mapper.Map<AtorDTO>(ator);
            return Ok(ReadAtorDto);

        }
        
        [HttpDelete("{id}")]
        public IActionResult DeletarAtor(int id)
        {
            Ator ator = _AtorContext.BuscaTodos().FirstOrDefault(ator => ator.Id == id);
            if (ator == null)
            {
                return NotFound("Ator não encontrado");
            }
            if (ator.FilmeAtor.Count != 0)
            {
                return BadRequest("Ator possui filmes associados");
            }
            if (ator.TemporadaAtor.Count != 0)
            {
                return BadRequest("Ator possui temporadas associados");
            }
            _AtorContext.Remove(ator);
            return NoContent();
        
        }
        
        [HttpGet("{id}")]
        public IActionResult BuscarAtorPorId(int id)
        {
            Ator ator = _AtorContext.BuscaTodos().FirstOrDefault(ator => ator.Id == id);
            if (ator == null)
            {
                return NotFound("Ator não encontrado");
            }
            AtorDTO ReadAtorDto = _mapper.Map<AtorDTO>(ator);
            return Ok(ReadAtorDto);
       
        
        }
        
        
        [HttpPatch("{id}")]
        public IActionResult AtualizarAtor(int id, [FromBody] AtorDTO atorDTO)
        {
            Ator ator = _AtorContext.BuscaPorId(id);
            if (ator == null)
            {
                return NotFound("Ator não encontrado");
            }

            if (atorDTO.NomeCompleto != null)
            {
                ator.NomeCompleto = atorDTO.NomeCompleto;
            }
            if (atorDTO.DataNascimento != null)
            {
                ator.DataNascimento = atorDTO.DataNascimento;
            }
            
            _AtorContext.Update(ator);
            
            var updateAtorDto = _mapper.Map<AtorDTO>(ator);
        
            return Ok(updateAtorDto);
        
        }

    }
}