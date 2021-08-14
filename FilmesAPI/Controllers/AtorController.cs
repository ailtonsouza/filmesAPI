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
        private AtorDAO _context;
        private IMapper _mapper;

        public AtorController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _context = new AtorDAO(session);
        }
        
        [HttpPost]
        public IActionResult AdicionaAtor ([FromBody] CreateAtorDto atorDto)
        {
        
            Ator ator = _mapper.Map<Ator>(atorDto);
            _context.Adiciona(ator);
            ReadAtorDto ReadAtorDto = _mapper.Map<ReadAtorDto>(ator);
            return Ok(ReadAtorDto);

        }

    }
}