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
        private readonly SmartDbContext _Context;

        public ProfessorController(SmartDbContext Context) 
        { 
            _Context = Context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
           
           _Context.Add(professor);
           _Context.SaveChanges();
           return Ok(professor);
        }

        [HttpPatch]
        public IActionResult Patch(int id, Professor professor)
        {
           var ProfessorPatch = _Context.Professores.FirstOrDefault(a => a.professorID == id);
           if(ProfessorPatch == null)
           {
              return BadRequest("Aluno não encontrado");
           }
           _Context.Update(ProfessorPatch);
           _Context.SaveChanges();

           return Ok(ProfessorPatch);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
           var professorPut = _Context.Professores.AsNoTracking().FirstOrDefault(a => a.professorID == id);
           if(professorPut == null)
           {
              return BadRequest("Aluno não encontrado");
           }
           _Context.Update(professorPut);
           _Context.SaveChanges();
           return Ok(professorPut);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
         var professorDelete = _Context.Professores.AsNoTracking().FirstOrDefault(a => a.professorID == id);
           if(professorDelete == null)
           {
              return BadRequest("Aluno não encontrado");
           }
           _Context.Remove(professorDelete);
           _Context.SaveChanges();
            return Ok();
        }
    }
}