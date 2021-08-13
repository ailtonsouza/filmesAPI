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
        private GeneroDAO _context;
        private IMapper _mapper;

        public GeneroController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _context = new GeneroDAO(session);
        }

        public IActionResult AdicionaGenero([FromBody] CreateGeneroDto generoDTO)
        {
            Genero genero = _mapper.Map<Genero>(generoDTO);
            _context.Adiciona(genero);
            ReadGeneroDto readGeneroDto = _mapper.Map<ReadGeneroDto>(genero);

            return Ok(readGeneroDto);
            
            
        }
    }
}