using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Aluno
    {
        public Aluno() { }
        
        public Aluno(int alunoId, string nomeAluno, string sobreNomeAluno, string telefone)
        {
            this.alunoId = alunoId;
            this.NomeAluno = nomeAluno;
            this.SobreNomeAluno = sobreNomeAluno;
            this.Telefone = telefone;

        }
        public int alunoId { get; set; }

        public string NomeAluno { get; set; }

        public string SobreNomeAluno { get; set; }

        public string Telefone { get; set; }

        public IEnumerable<AlunoDisciplina> AlunoDisciplinas{get; set;}
    }
}