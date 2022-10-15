using System.Collections.Generic;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OscarController : ControllerBase
    {
        private GenericDao<Oscar> _OscarContext;
         private GenericDao<Filme> _FilmeContext;
        private IMapper _mapper;
        
        public OscarController(IMapper mapper, ISession session)
        {
            _FilmeContext = new GenericDao<Filme>(session);
            _OscarContext = new GenericDao<Oscar>(session);
            _mapper = mapper;
        } 
        
        [HttpPost]
        public IActionResult AdicionaOscar ([FromBody] OscarDTO oscarDTO)
        {
            try
            {
                Filme filme = _FilmeContext.BuscaPorId(oscarDTO.FilmeId);
                if (filme == null)
                {
                    return NotFound("O Filme não foi encontrado");
                }
                Oscar oscar = _mapper.Map<Oscar>(oscarDTO);
                oscar.AdicionaFilme(filme);
                _OscarContext.Adiciona(oscar);
                
                var readOscar = 
                    _mapper.Map<OscarFilmeDTO>(oscar);
                
                return Ok(readOscar);
            }
            catch (System.Data.DataException e)
            {
                string str = $"{{ \"Error Message\": \"{e.Message}\" }}";
                JObject json = JObject.Parse(str);
                
                return BadRequest(json);
            }
        }
        
        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            IEnumerable<Oscar> oscar = _OscarContext.BuscaTodos();
            
            var readOscar = 
                _mapper.Map<IList<OscarFilmeDTO>>(oscar);
            
            return Ok(readOscar);
        }
        
        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id)
        {
            Oscar oscar =  _OscarContext.BuscaPorId(id);
            
            if (oscar == null)
            {
                return NotFound("O Oscar não foi encontrado");
            }

            var readOscarDTO = 
                _mapper.Map<OscarFilmeDTO>(oscar);
            
            return Ok(readOscarDTO);
        }
        
        [HttpDelete("{id}")]
        public IActionResult RemovePorId(int id)
        {
            Oscar oscar =  _OscarContext.BuscaPorId(id);
            
            if (oscar == null)
            {
                return NotFound("O Oscar não foi encontrado");
            }

            _OscarContext.Remove(oscar);
            
            return NoContent();
        }
        

        

    }
}