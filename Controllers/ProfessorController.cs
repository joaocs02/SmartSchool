using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
using System.Linq;
using SmartSchool.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _Repor;

        public ProfessorController(IRepository repository)
        {
            _Repor = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var retornarProfessor = _Repor.GetallProfessores(false);
            return Ok(retornarProfessor);
        }

         [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            var retornarProfessor = _Repor.GetProfessorByID(id, false);
            if(retornarProfessor == null)
            {
               return BadRequest("Não foi prossivel retonar professor");     
            }

            return Ok(retornarProfessor);
        }

        [HttpPost("{id}")]
        public IActionResult Post(Professor professor)
        {
            _Repor.add(professor);

            if (_Repor.SaveChanges(professor))
            {
               return Ok(professor);
            }
          
            return BadRequest("Não foi possível incluir professor");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            var ProfessorPatch = _Repor.GetProfessorByID(id, false);

            if (ProfessorPatch == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            
             _Repor.Update(ProfessorPatch);

            if (_Repor.SaveChanges(ProfessorPatch))
            {
               return Ok(ProfessorPatch);
            }
          
            return BadRequest("Não foi possível alterar professor");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            var professorPut = _Repor.GetAlunosByID(id, false);
            if (professorPut == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            
            _Repor.Update(professorPut);

            if (_Repor.SaveChanges(professorPut))
            {
               return Ok(professorPut);
            }
          
            return BadRequest("Não foi possível alterar professor");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professorDelete = _Repor.GetAlunosByID(id, false);
            if (professorDelete == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            _Repor.Delete(professorDelete);

            if (_Repor.SaveChanges(professorDelete))
            {
               return Ok("Exclusão realizada com sucesso.");
            }
          
            return BadRequest("Não foi possível excluir professor");
        }
    }
}