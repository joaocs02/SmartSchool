using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlunoController : ControllerBase
    {
        
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                alunoId = 1,
                NomeAluno = "Joao",
                SobreNomeAluno = "Souza",
                Telefone = "0319887766"
            },

               new Aluno(){
                alunoId = 2,
                NomeAluno = "Kissila",
                SobreNomeAluno = "Pires",
                Telefone = "0319865566"
            },

                new Aluno(){
                alunoId = 3,
                NomeAluno = "Pedro",
                SobreNomeAluno = "Villas",
                Telefone = "0319866444"
            },
        };
        public AlunoController(){}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
           var AlunosReturno = Alunos.FirstOrDefault(a => a.alunoId == id);  

           if (AlunosReturno == null) return BadRequest("Não foi possivel encontrar o Aluno");

           return Ok(AlunosReturno);
        }

       [HttpGet("byName")]
        public IActionResult GetbyName(string nome, string sobreNome)
        {
           var AlunosRetorno = Alunos.FirstOrDefault(a => 
            a.NomeAluno.Contains(nome) && a.SobreNomeAluno.Contains(sobreNome));  

           if (AlunosRetorno == null) return BadRequest("Não foi possivel encontrar o Aluno");

           return Ok(AlunosRetorno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
           return Ok(aluno);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
           return Ok(aluno);
        }

          [HttpPatch]
         public IActionResult Patch(int id, Aluno aluno)
        {
           return Ok(aluno);
        }

    }
}