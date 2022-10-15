using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using FilmesAPI.DAO;
using FilmesAPI.DTOs.Ator;
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
        private GenericDao<FilmeAtor> _filmeAtorDaoContext;
        private GenericDao<Filme> _filmeDaocontext;
        private GenericDao<Diretor> _diretorDaocontext;
        private GenericDao<Ator> _atorDaocontext;
        private GenericDao<FilmeGenero> _filmeGeneroDaocontext;
        private GenericDao<FilmeDiretor> _filmeDiretorDaocontext;
        private GenericDao<Genero> _generoDaocontext;
        private IMapper _mapper;

        public FilmeController(IMapper mapper, ISession session)
        {
            _mapper = mapper;
            _filmeDaocontext = new GenericDao<Filme>(session);
            _diretorDaocontext = new GenericDao<Diretor>(session);
            _atorDaocontext = new GenericDao<Ator> (session);
            _generoDaocontext = new GenericDao<Genero>(session);
            _filmeAtorDaoContext = new GenericDao<FilmeAtor>(session);
            _filmeGeneroDaocontext = new GenericDao<FilmeGenero>(session);
            _filmeDiretorDaocontext = new GenericDao<FilmeDiretor>(session);
        }

        [HttpPost]
         public IActionResult AdicionaFilme ([FromBody] FilmeDTO filmeDto)
        {
  
               Filme filme = _mapper.Map<Filme>(filmeDto);
               
               _filmeDaocontext.Adiciona(filme);
                
                var createFilmeDto = _mapper.Map<FilmeDTO>(filme);
                
                return CreatedAtAction(nameof(RecuperarFilmesPorId), new { Id = filme.Id }, createFilmeDto);
        }
        
        [HttpGet]
        public IActionResult RecuperarFilmes()
        {

            var filmes = _filmeDaocontext.BuscaTodos();

            var filmesDTO = _mapper.Map<IEnumerable<FilmeAgreçõesDTO>>(filmes);
            
            return Ok(filmesDTO);
        }
        
        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorId(int id)
        {
            Filme filme =  _filmeDaocontext.BuscaPorId(id);
        
            if (filme != null)
            {
                var filmeDto = _mapper.Map<FilmeAgreçõesDTO>(filme);
                
                return Ok(filmeDto);
            }
        
            return NotFound();
        }
        
        [HttpPatch("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] FilmeDTO filmeDTO)
        {
            Filme filme =  _filmeDaocontext.BuscaTodos().FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound("Filme não encontrado");
            }

            if (filmeDTO.Duracao != null)
            {
                filme.Duracao = filmeDTO.Duracao;
            }
            if (filmeDTO.Titulo != null)
            {
                filme.Titulo = filmeDTO.Titulo;
            }
            
            _filmeDaocontext.Update(filme);
            
            var updatedFilmeDto = _mapper.Map<FilmeDTO>(filme);
        
            return Ok(updatedFilmeDto);
        
        }
        
        
        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _filmeDaocontext.BuscaTodos().FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            if (filme.Oscar.Count != 0)
            {
                return NotFound("Filme Possui Oscar associados");
            }
            
            _filmeDaocontext.Remove(filme);
            return NoContent();
        
        }
        
        [HttpDelete("RemoveAtor")]
        public IActionResult RemoveAtor([FromBody] AtorFilmeDTO af)
        {
            FilmeAtor filmeAtor = _filmeAtorDaoContext.BuscaPorId(af.Id);
            if (filmeAtor == null)
            {
                return NotFound("Registro não encontrado");
            }

            _filmeAtorDaoContext.Remove(filmeAtor);

            return NoContent();
        
        }
        
        [HttpDelete("RemoveDiretor")]
        public IActionResult RemoveDiretor(int id,[FromBody] FilmeGeneroDTO fg)
        {
            FilmeDiretor filmeDiretor = _filmeDiretorDaocontext.BuscaPorId(fg.Id);
            if (filmeDiretor == null)
            {
                return NotFound("Registro não encontrado");
            }
            
            _filmeDiretorDaocontext.Remove(filmeDiretor);
            
            return NoContent();
        }
        
        [HttpDelete("RemoveGenero")]
        public IActionResult RemoveGenero(int id,[FromBody] FilmeGeneroDTO fg)
        {
            FilmeGenero filmeGenero = _filmeGeneroDaocontext.BuscaPorId(fg.Id);
            if (filmeGenero == null)
            {
                return NotFound("Registro não encontrado");
            }
            
            _filmeGeneroDaocontext.Remove(filmeGenero);
            
            return NoContent();
        }
        
        
        [HttpPatch("{id}/AddActor")]
        public IActionResult AssociarAtor(int id, [FromBody] AtorFilmeDTO af)
        {
            
            Filme filme = _filmeDaocontext.BuscaPorId(id);
            if (filme == null)
            {
                return NotFound("Filme não encontrado");
            }
          
            Ator ator = _atorDaocontext.BuscaTodos().FirstOrDefault(ator => ator.Id == af.Id);
            if (ator == null)
            {
                return NotFound("Aotr não encontrado");
            }

            FilmeAtor fa = new FilmeAtor();

            fa.Ator = ator;
            fa.Filme = filme;
            fa.NomePersonagem = af.NomePersonagem;

            filme.FilmeAtor.Add(fa);
    
            _filmeDaocontext.Update(filme);
            
            var updatedFilmeDto = _mapper.Map<FilmeAgreçõesDTO>(filme);
            
            return Ok(updatedFilmeDto);
        }
        
        [HttpPatch("{id}/AddGenero")]
        public IActionResult AssociarGenero(int id, [FromBody] GeneroDTO generoDto)
        {


            Filme filme = _filmeDaocontext.BuscaPorId(id);
            if (filme == null)
            {
                return NotFound();
            }

            Genero genero = _generoDaocontext.BuscaTodos().FirstOrDefault(genero => genero.Id == generoDto.Id);
             if (genero == null)
             {
                 return NotFound();
             }

             FilmeGenero FM = new FilmeGenero();
             FM.Filme = filme;
             FM.Genero = genero;
            
            filme.FilmeGenero.Add(FM);
            
           _filmeDaocontext.Update(filme);
            
            var updatedFilmeDto = _mapper.Map<FilmeAgreçõesDTO>(filme);
            
            return Ok(updatedFilmeDto);
        }
        
        [HttpPatch("{id}/AddDiretor")]
        public IActionResult AssociarDiretor(int id, [FromBody] DiretorDTO diretorDto)
        {


            Filme filme = _filmeDaocontext.BuscaPorId(id);
            if (filme == null)
            {
                return NotFound();
            }
            
            Diretor diretor = _diretorDaocontext.BuscaTodos().FirstOrDefault(diretor => diretor.Id == diretorDto.Id);
            if (diretor == null)
            {
                return NotFound();
            }

            FilmeDiretor fd = new FilmeDiretor();
            fd.Diretor = diretor;
            fd.Filme = filme;

            filme.FilmeDiretor.Add(fd);
            
            _filmeDaocontext.Update(filme);
            
            var updatedFilmeDto = _mapper.Map<FilmeAgreçõesDTO>(filme);
            
            return Ok(updatedFilmeDto);
        }
    }
}