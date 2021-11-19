using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.Dtos.Ator;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtorController :ControllerBase
    {
        private AtorDAO _AtorContext;
        private IMapper _mapper;

        public AtorController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _AtorContext = new AtorDAO(session);
        }
        
        [HttpGet]
  
        public IActionResult BuscarTodos()
        {
            var atores = _AtorContext.BuscaTodos();
            var ep = _mapper.Map<IList<ReadAtorDto>>(atores);
            return Ok(ep);
        }
        
        [HttpPost]
        public IActionResult AdicionaAtor ([FromBody] CreateAtorDto atorDto)
        {
        
            Ator ator = _mapper.Map<Ator>(atorDto);
            _AtorContext.Adiciona(ator);
            ReadAtorDto ReadAtorDto = _mapper.Map<ReadAtorDto>(ator);
            return Ok(ReadAtorDto);

        }
        
        [HttpDelete("{id}")]
        public IActionResult DeletarAtor(int id)
        {
            Ator ator = _AtorContext.BuscaTodos().FirstOrDefault(ator => ator.Id == id);
            if (ator == null)
            {
                return NotFound();
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
                return NotFound();
            }
            ReadAtorDto ReadAtorDto = _mapper.Map<ReadAtorDto>(ator);
            return Ok(ReadAtorDto);
       
        
        }

    }
}