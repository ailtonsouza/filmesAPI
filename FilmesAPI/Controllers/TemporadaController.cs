 using System.Collections.Generic;
 using System.Linq;
 using System.Net;
 using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.DTOs.Ator;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.DTOs.Temporada;
 using FilmesAPI.Entidades;
 using Microsoft.AspNetCore.Mvc;
 using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemporadaController : ControllerBase
    {
        private TemporadaDAO _TemporaContext;
        private SerieDAO _SerieContext;
        private AtorDAO _AtorContext;
        private DiretorDAO _DiretorContext;
        private IMapper _mapper;

        public TemporadaController(IMapper mapper, ISession session)
        {
            _TemporaContext = new TemporadaDAO(session);
            _SerieContext = new SerieDAO(session);
            _AtorContext = new AtorDAO(session);
            _DiretorContext = new DiretorDAO(session);
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarTemporada([FromBody] TemporadaDTO temporadaDto)
        {
            Temporada temporada = _mapper.Map<Temporada>(temporadaDto);
            Serie serie = _SerieContext.BuscaPorId(temporadaDto.Id);
            if (serie == null)
            {
                return NotFound("Serie não foi encontrada"); 
            }


            temporada.Serie = serie;
            _TemporaContext.Adiciona(temporada);
            TemporadaDTO readTemporadaDto = _mapper.Map<TemporadaDTO>(temporada);
            return Ok(readTemporadaDto);
        }
        
        [HttpGet]
        public IActionResult RecuperarTemporadas()
        {

            var temporadas = _TemporaContext.BuscaTodos();

            var temporadasDTO = _mapper.Map<IEnumerable<TemporadaDTO>>(temporadas);
            
            return Ok(temporadasDTO);
        }

        [HttpPatch("{id}/AddActor")]
        public IActionResult AdicionarAtorTemporada(int id, [FromBody] AtorFilmeDTO AtorDTO )
        {
            Temporada temporada = _TemporaContext.BuscaPorId(id);
            if (temporada == null)
            {
                return NotFound("Temporada não foi encontrada"); 
            }
            
             Ator ator = _AtorContext.BuscaPorId(AtorDTO.Id);
             if (ator == null)
             {
                 return NotFound("Ator não foi encontrado"); 
             }

             TemporadaAtor TA = new TemporadaAtor();
             TA.Ator = ator;
             TA.NomePersonagem = AtorDTO.NomePersonagem;
             TA.Temporada = temporada;
             
             temporada.TemporadaAtor.Add(TA);
             _TemporaContext.Update(temporada);
             
             TemporadaDTO temporadaDto = _mapper.Map<TemporadaDTO>(temporada);
            return Ok(temporadaDto);
        }
        
        [HttpDelete("{id}/RemoveDiretor")]
        public IActionResult RemoveTemporadaDiretor(int id, [FromBody] TemporadaDiretorIdDTO RemoveTemporadaDiretorDTO )
        {
            Temporada temporada = _TemporaContext.BuscaPorId(id);
            if (temporada == null)
            {
                return NotFound("Temporada não foi encontrada"); 
            }

            TemporadaDiretor temporadaDiretor = temporada.TemporadaDiretor.FirstOrDefault(td => td.Id == RemoveTemporadaDiretorDTO.TemporadaDiretorId);
            if (temporadaDiretor == null)
            {
                return NotFound("Diretor não foi encontrado na temporada"); 
            }

            temporada.TemporadaDiretor.Remove(temporadaDiretor);
        
            _TemporaContext.Update(temporada);
             
       
            return NoContent();
        }
        
               
        [HttpDelete("{id}/RemoveAtor")]
        public IActionResult RemoveTemporadaAtor(int id, [FromBody] TemporadaAtorIdDTO RemoveTemporadaAtorDTO )
        {
            Temporada temporada = _TemporaContext.BuscaPorId(id);
            if (temporada == null)
            {
                return NotFound("Temporada não foi encontrada"); 
            }

            TemporadaAtor temporadaAtor = temporada.TemporadaAtor.FirstOrDefault(td => td.Id == RemoveTemporadaAtorDTO.TemporadaAtorId);
            if (temporadaAtor == null)
            {
                return NotFound("O Ator não foi encontrado na temporada"); 
            }

            temporada.TemporadaAtor.Remove(temporadaAtor);
        
            _TemporaContext.Update(temporada);
            
            return NoContent();
        }
        
        
        [HttpPatch("{id}/AddDiretor")]
        public IActionResult AdicionarDiretorTemporada(int id, DiretorDTO diretorDTO)
        {
            Temporada temporada = _TemporaContext.BuscaPorId(id);
            if (temporada == null)
            {
                return NotFound("Temporada não foi encontrada"); 
            }
            
            Diretor diretor = _DiretorContext.BuscaPorId(diretorDTO.Id);
            if (diretor == null)
            {
                return NotFound("Diretor não foi encontrado"); 
            }

            TemporadaDiretor TD = new TemporadaDiretor();
            TD.Diretor = diretor;
            TD.Temporada = temporada;
             
             temporada.TemporadaDiretor.Add(TD);
             _TemporaContext.Update(temporada);
            //
            TemporadaDTO temporadaDto = _mapper.Map<TemporadaDTO>(temporada);
            return Ok(temporadaDto);

        }
        
        [HttpGet ("{id}")]
        public IActionResult BuscarTemporadaPorId(int id)
        {

            var temporada = _TemporaContext.BuscaPorId(id);
            if (temporada == null)
            {
                return NotFound();
            }
            var temporadaDto = _mapper.Map<TemporadaDTO>(temporada);
            return Ok(temporadaDto);
        }
        
        [HttpDelete("{id}")]
        public IActionResult RemoveTemporadaPorId(int id)
        {
            var temporada =  _TemporaContext.BuscaPorId(id);
            
            if (temporada == null)
            {
                return NotFound("A temporada não foi encontrado");
            }
            
            if (temporada.Epsodio.Count != 0)
            {

                return BadRequest("Existem epsodios associados a temporada");
            }

            _TemporaContext.Remove(temporada);
            
            return NoContent();
        }
    }
    
    
}