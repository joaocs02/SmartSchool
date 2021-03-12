using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlunoController : ControllerBase
    {
        
        private readonly SmartDbContext _Context;
        public AlunoController(SmartDbContext Context)
        {
            _Context = Context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_Context.Alunos);
        }

       [HttpGet("byName")]
        public IActionResult GetbyName(string nome, string sobreNome)
        {
           var AlunosRetorno = _Context.Alunos.AsNoTracking().FirstOrDefault(a => 
            a.NomeAluno.Contains(nome) && a.SobreNomeAluno.Contains(sobreNome));  

           if (AlunosRetorno == null) return BadRequest("Não foi possivel encontrar o Aluno");

           return Ok(AlunosRetorno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
           _Context.Add(aluno);
           _Context.SaveChanges();
           return Ok(aluno);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
           var alunoPut = _Context.Alunos.AsNoTracking().FirstOrDefault(a => a.alunoId == id);
           if(alunoPut == null)
           {
              return BadRequest("Aluno não encontrado");
           }
           _Context.Update(aluno);
           _Context.SaveChanges();
           return Ok(aluno);
        }

          [HttpPatch]
         public IActionResult Patch(int id, Aluno aluno)
        {
           var alunoPatch = _Context.Alunos.FirstOrDefault(a => a.alunoId == id);
           if(alunoPatch == null)
           {
              return BadRequest("Aluno não encontrado");
           }
           _Context.Update(aluno);
           _Context.SaveChanges();
           return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
         var alunoDelete = _Context.Alunos.FirstOrDefault(a => a.alunoId == id);
           if(alunoDelete == null)
           {
              return BadRequest("Aluno não encontrado");
           }
           _Context.Remove(alunoDelete);
           _Context.SaveChanges();
            return Ok();
        }

    }
}