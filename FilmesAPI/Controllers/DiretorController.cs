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
        private DiretorDAO _context;
        private IMapper _mapper;

        public DiretorController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _context = new DiretorDAO(session);
        }
        
        [HttpPost]
        public IActionResult AdicionaDiretor ([FromBody] CreateDiretorDto diretorDto)
        {
        
            Diretor diretor = _mapper.Map<Diretor>(diretorDto);
            _context.Adiciona(diretor);
            ReadDiretorDto ReaddiretorDto = _mapper.Map<ReadDiretorDto>(diretor);
            return Ok(ReaddiretorDto);

        }

    }
}