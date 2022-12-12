using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiretorController :ControllerBase
    {
        private GenericDao<Diretor> _DiretorContext;
        private IMapper _mapper;

        public DiretorController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _DiretorContext = new GenericDao<Diretor>(session);
        }
        
        [HttpPost]
        public IActionResult AdicionaDiretor ([FromBody] DiretorDTO diretorDto)
        {
        
            Diretor diretor = _mapper.Map<Diretor>(diretorDto);
            _DiretorContext.Adiciona(diretor);
            DiretorDTO ReaddiretorDto = _mapper.Map<DiretorDTO>(diretor);
            return Ok(ReaddiretorDto);

        }
        
        [HttpGet]
        public IActionResult RecuperarDiretor()
        {

            var diretores = _DiretorContext.BuscaTodos();
  
            var ReaddiretoresDto = _mapper.Map<IEnumerable<DiretorDTO>>(diretores);
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
            var readDiretor = _mapper.Map<DiretorDTO>(diretor);
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
            if (diretor.FilmeDiretor.Count != 0)
            {
                return BadRequest("Diretor possui filmes associados");
            }
            if (diretor.TemporadaDiretor.Count != 0)
            {
                return BadRequest("Diretor possui temporadas associados");
            }

            _DiretorContext.Remove(diretor);
            
            return NoContent();
        }
        
        
        [HttpPatch("{id}")]
        public IActionResult Diretor(int id, [FromBody] DiretorDTO diretorDTO)
        {
            Diretor diretor = _DiretorContext.BuscaPorId(id);
            if (diretor == null)
            {
                return NotFound("Diretor não encontrado");
            }

            if (diretorDTO.NomeCompleto != null)
            {
                diretor.NomeCompleto = diretorDTO.NomeCompleto;
            }
            if (diretorDTO.DataNascimento != null)
            {
                diretor.DataNascimento = diretorDTO.DataNascimento;
            }
            
            _DiretorContext.Update(diretor);
            
            var updateDiretorDto = _mapper.Map<DiretorDTO>(diretor);
        
            return Ok(updateDiretorDto);
        
        }

    }
}