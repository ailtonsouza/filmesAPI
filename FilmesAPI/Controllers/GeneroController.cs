using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
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
        private GenericDao<Genero> _GeneroContext;
        private IMapper _mapper;

        public GeneroController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _GeneroContext = new GenericDao<Genero>(session);
        }

        public IActionResult AdicionaGenero([FromBody] GeneroDTO generoDTO)
        {
            Genero genero = _mapper.Map<Genero>(generoDTO);
            _GeneroContext.Adiciona(genero);
            GeneroDTO readGeneroDto = _mapper.Map<GeneroDTO>(genero);

            return Ok(readGeneroDto);
            
            
        }
        
        [HttpGet]
        public IActionResult BuscarTodosGeneros(int id)
        {
            var genero = _GeneroContext.BuscaTodos();
   
            var ReadGenerorDto = _mapper.Map<IList<GeneroDTO>>(genero);
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
            var ReadGenerorDto = _mapper.Map<GeneroDTO>(genero);
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
            
            if (genero.FilmeGenero.Count != 0)
            {
                return BadRequest("Genero possui filmes associados");
            }
            
            if (genero.SerieGenero.Count != 0)
            {
                return BadRequest("Genero possui series associadas");
            }

            _GeneroContext.Remove(genero);
            
            return NoContent();
        }
        
        
        [HttpPatch("{id}")]
        public IActionResult AtualizaGenero(int id, [FromBody] GeneroDTO generoDTO)
        {
            Genero genero = _GeneroContext.BuscaPorId(id);
            if (genero == null)
            {
                return NotFound("Diretor não encontrado");
            }
            
            if (generoDTO.Nome != null)
            {
                genero.Nome = generoDTO.Nome;
            }
            
            _GeneroContext.Update(genero);
            
            var updateGeneroDto = _mapper.Map<GeneroDTO>(genero);
        
            return Ok(updateGeneroDto);
        
        }





    }
}