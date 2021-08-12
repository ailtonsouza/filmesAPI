using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
 [ApiController]
    [Route("[controller]")]
    public class FilmeController :ControllerBase
    {
        private FilmeDAO _filmeDaocontext;
        private DiretorDAO _diretorDaocontext;
        private IMapper _mapper;

        public FilmeController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _filmeDaocontext = new FilmeDAO(session);
            _diretorDaocontext = new DiretorDAO(session);
        }

        [HttpPost]
         public IActionResult AdicionaFilme ([FromBody] CreateFilmeDto filmeDto)
        {
        
                Filme filme = _mapper.Map<Filme>(filmeDto);
             
                _filmeDaocontext.Adiciona(filme);
                
                var createFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
                
                return CreatedAtAction(nameof(RecuperarFilmesPorId), new { Id = filme.Id }, createFilmeDto);
                return Ok(filme);
        }
        
        [HttpGet]
        public IActionResult RecuperarFilmes()
        {

            var filmes = _filmeDaocontext.BuscaTodos();

            var filmesDTO = _mapper.Map<IEnumerable<ReadFilmeAndOscarDto>>(filmes);
            
            return Ok(filmesDTO);
        }
        
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorId(int id)
        {
            Filme filme =  _filmeDaocontext.BuscaPorId(id);
        
            if (filme != null)
            {
                var filmeDto = _mapper.Map<ReadFilmeAndOscarDto>(filme);
                
                return Ok(filmeDto);
            }
        
            return NotFound();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDTO)
        {
            Filme filme =  _filmeDaocontext.BuscaTodos().FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            
            filme = _mapper.Map<Filme>(filmeDTO);
            _filmeDaocontext.Update(filme);
        
            return NoContent();
        
        }
        
        
        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _filmeDaocontext.BuscaTodos().FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _filmeDaocontext.Remove(filme);
            return NoContent();
        
        }
    }
}