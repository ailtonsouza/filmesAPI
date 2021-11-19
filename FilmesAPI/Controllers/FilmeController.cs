using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.Dtos.Diretor;
using FilmesAPI.Dtos.Genero;
using FilmesAPI.Entidades;
using FilmesAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NHibernate;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController :ControllerBase
    {
        private FilmeDAO _filmeDaocontext;
        private DiretorDAO _diretorDaocontext;
        private AtorDAO _atorDaocontext;
        private GeneroDAO _generoDaocontext;
        private IMapper _mapper;

        public FilmeController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _filmeDaocontext = new FilmeDAO(session);
            _diretorDaocontext = new DiretorDAO(session);
            _atorDaocontext = new AtorDAO(session);
            _generoDaocontext = new GeneroDAO(session);
        }

        [HttpPost]
         public IActionResult AdicionaFilme ([FromBody] CreateFilmeDto filmeDto)
        {
  
               Filme filme = _mapper.Map<Filme>(filmeDto);
               
               _filmeDaocontext.Adiciona(filme);
                
                var createFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
                
                return CreatedAtAction(nameof(RecuperarFilmesPorId), new { Id = filme.Id }, createFilmeDto);
               return Ok();
        }
        
        [HttpGet]
        public IActionResult RecuperarFilmes()
        {

            var filmes = _filmeDaocontext.BuscaTodos();

            var filmesDTO = _mapper.Map<IEnumerable<ReadFilmeDto>>(filmes);
            
            return Ok(filmesDTO);
        }
        
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorId(int id)
        {
            Filme filme =  _filmeDaocontext.BuscaPorId(id);
        
            if (filme != null)
            {
                var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                
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
        
        [HttpPatch("{id}/AddActor")]
        public IActionResult AssociarAtor(int id, [FromBody] ActorIdDto actor)
        {


            Filme filme = _filmeDaocontext.BuscaPorId(id);
            if (filme == null)
            {
                return NotFound();
            }
            
            Ator ator = _atorDaocontext.BuscaTodos().FirstOrDefault(ator => ator.Id == actor.ActorId);
            if (ator == null)
            {
                return NotFound();
            }
            
            filme.Ator.Add(ator);
            
            _filmeDaocontext.Update(filme);
            
            var updatedFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
            
            return Ok(updatedFilmeDto);
        }
        
        [HttpPatch("{id}/AddGenero")]
        public IActionResult AssociarGenero(int id, [FromBody] GeneroIdDto generoDto)
        {


            Filme filme = _filmeDaocontext.BuscaPorId(id);
            if (filme == null)
            {
                return NotFound();
            }
            
            Genero genero = _generoDaocontext.BuscaTodos().FirstOrDefault(diretor => diretor.Id == generoDto.GeneroId);
            if (genero == null)
            {
                return NotFound();
            }

            filme.Genero.Add(genero);
            
            _filmeDaocontext.Update(filme);
            
            var updatedFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
            
            return Ok(updatedFilmeDto);
        }
        
        [HttpPatch("{id}/AddDiretor")]
        public IActionResult AssociarDiretor(int id, [FromBody] DiretorIdDto diretorDto)
        {


            Filme filme = _filmeDaocontext.BuscaPorId(id);
            if (filme == null)
            {
                return NotFound();
            }
            
            Diretor diretor = _diretorDaocontext.BuscaTodos().FirstOrDefault(genero => genero.Id == diretorDto.DiretorId);
            if (diretor == null)
            {
                return NotFound();
            }

            filme.Diretor.Add(diretor);
            
            _filmeDaocontext.Update(filme);
            
            var updatedFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
            
            return Ok(updatedFilmeDto);
        }
    }
}