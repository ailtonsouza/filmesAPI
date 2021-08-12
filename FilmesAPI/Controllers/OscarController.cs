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
        private OscarDAO _OscarContext;
         private FilmeDAO _FilmeContext;
        private IMapper _mapper;
        
        public OscarController(IMapper mapper, ISession session)
        {
            _FilmeContext = new FilmeDAO(session);
            _OscarContext = new OscarDAO(session);
            _mapper = mapper;
        } 
        
        [HttpPost]
        public IActionResult AdicionaOscar ([FromBody] CreateOscarDto OscarDto)
        {
            try
            {
                Filme filme = _FilmeContext.BuscaPorId(OscarDto.FilmeId);
                if (filme == null)
                {
                    return NotFound("O Filme não foi encontrado");
                }
                Oscar oscar = _mapper.Map<Oscar>(OscarDto);
                oscar.AdicionaFilme(filme);
                _OscarContext.Adiciona(oscar);
                
                var readOscar = 
                    _mapper.Map<ReadOscarAndFilmeDto>(oscar);
                
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
                _mapper.Map<IList<ReadOscarAndFilmeDto>>(oscar);
            
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

            var readOscar = 
                _mapper.Map<ReadOscarAndFilmeDto>(oscar);
            
            return Ok();
        }
    }
}