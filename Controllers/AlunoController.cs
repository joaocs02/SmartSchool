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
        private readonly IRepository _repor;

        public AlunoController(IRepository repor)
        {
            _repor = repor;
        }

        [HttpGet]
        public IActionResult GetAllAluno()
        {
           var AlunoRetorno = _repor.GetallAlunos(true);
            return Ok(AlunoRetorno);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var AlunoResult = _repor.GetAlunosByID(id, false);

           if (AlunoResult == null) return BadRequest("Não foi possivel retornar o Aluno"); 
        
            return Ok(AlunoResult);
        }

         [HttpPost]
         public IActionResult Post(Aluno aluno)
         {
            _repor.add(aluno);

            if (_repor.SaveChanges(aluno))
            {
               return Ok(aluno);
            }
            return  BadRequest("Não foi possível incluir aluno");
         }


         [HttpPut("{id}")]
         public IActionResult Put(int id, Aluno aluno)
         {
            var alunoPut = _repor.GetAlunosByID(id, true);
            if (alunoPut == null)
            {
                  return BadRequest("Aluno não encontrado");
            }

           _repor.Update(alunoPut);

            if (_repor.SaveChanges(alunoPut))
            {
               return Ok(alunoPut);
            }
            return  BadRequest("Não foi possível incluir aluno");
         }

         [HttpPatch]
         public IActionResult Patch(int id, Aluno aluno)
         {
            var alunoPatch = _repor.GetAlunosByID(id, false);
            if (alunoPatch == null)
            {
                  return BadRequest("Aluno não encontrado");
            }
          
           _repor.Update(alunoPatch);

            if (_repor.SaveChanges(alunoPatch))
            {
               return Ok(alunoPatch);
            }
            return  BadRequest("Não foi possível alterar aluno");
         }

         [HttpDelete("{id}")]
         public IActionResult Delete(int id)
         {
            var alunoDelete = _repor.GetAlunosByID(id, false);
            if (alunoDelete == null)
            {
                  return BadRequest("Aluno não encontrado");
            }

            _repor.Delete(alunoDelete);

            if (_repor.SaveChanges(alunoDelete))
            {
               return Ok("Exclusão realizada com sucesso");
            }
            return  BadRequest("Não foi possível excluir aluno");
         }

}
}