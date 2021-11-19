using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.Dtos.Genero;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiretorController :ControllerBase
    {
        private DiretorDAO _DiretorContext;
        private IMapper _mapper;

        public DiretorController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _DiretorContext = new DiretorDAO(session);
        }
        
        [HttpPost]
        public IActionResult AdicionaDiretor ([FromBody] CreateDiretorDto diretorDto)
        {
        
            Diretor diretor = _mapper.Map<Diretor>(diretorDto);
            _DiretorContext.Adiciona(diretor);
            ReadDiretorDto ReaddiretorDto = _mapper.Map<ReadDiretorDto>(diretor);
            return Ok(ReaddiretorDto);

        }
        
        [HttpGet]
        public IActionResult RecuperarDiretor()
        {

            var diretores = _DiretorContext.BuscaTodos();
  
            var ReaddiretoresDto = _mapper.Map<IEnumerable<CreateDiretorDto>>(diretores);
            return Ok(ReaddiretoresDto);
        }
        
        
                      
        [HttpGet("{id}")]
        public IActionResult BuscarDiretorPorId(int id)
        {
            var diretor = _DiretorContext.BuscaTodos().FirstOrDefault(genero => genero.Id == id);
            if (diretor == null)
            {
                return NotFound("O Diretor não foi encontrado");
            }
            var readDiretor = _mapper.Map<ReadDiretorDto>(diretor);
            return Ok(readDiretor);
       
        
        }
        
        [HttpDelete("{id}")]
        public IActionResult RemovePorId(int id)
        {
            var diretor =  _DiretorContext.BuscaPorId(id);
            
            if (diretor == null)
            {
                return NotFound("O Diretor não foi encontrado");
            }

            _DiretorContext.Remove(diretor);
            
            return NoContent();
        }

    }
}