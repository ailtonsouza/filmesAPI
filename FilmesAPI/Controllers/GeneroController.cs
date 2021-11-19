using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.Dtos.Ator;
using FilmesAPI.Dtos.Genero;
using FilmesAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController : ControllerBase
    {
        private GeneroDAO _GeneroContext;
        private IMapper _mapper;

        public GeneroController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _GeneroContext = new GeneroDAO(session);
        }

        public IActionResult AdicionaGenero([FromBody] CreateGeneroDto generoDTO)
        {
            Genero genero = _mapper.Map<Genero>(generoDTO);
            _GeneroContext.Adiciona(genero);
            ReadGeneroDto readGeneroDto = _mapper.Map<ReadGeneroDto>(genero);

            return Ok(readGeneroDto);
            
            
        }
        
        [HttpGet]
        public IActionResult BuscarTodosGeneros(int id)
        {
            var genero = _GeneroContext.BuscaTodos();
   
            var ReadGenerorDto = _mapper.Map<IList<ReadGeneroDto>>(genero);
            return Ok(ReadGenerorDto);
        }
        
        
                
        [HttpGet("{id}")]
        public IActionResult BuscarGeneroPorId(int id)
        {
            var genero = _GeneroContext.BuscaTodos().FirstOrDefault(genero => genero.Id == id);
            if (genero == null)
            {
                return NotFound();
            }
            var ReadGenerorDto = _mapper.Map<ReadGeneroDto>(genero);
            return Ok(ReadGenerorDto);
       }
        
        [HttpDelete("{id}")]
        public IActionResult RemovePorId(int id)
        {
            var genero =  _GeneroContext.BuscaPorId(id);
            
            if (genero == null)
            {
                return NotFound("O Genero não foi encontrado");
            }

            _GeneroContext.Remove(genero);
            
            return NoContent();
        }
    }
}