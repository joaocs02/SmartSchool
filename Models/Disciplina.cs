using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Disciplina
    {

        public Disciplina() { }

        public Disciplina(int disciplinaId, string discricaoDisciplina, int professorId, Professor professor)
        {
            this.disciplinaId = disciplinaId;
            this.discricaoDisciplina = discricaoDisciplina;
            this.professorId = professorId;
            this.Professor = professor;

        }
        public int disciplinaId { get; set; }

        public string discricaoDisciplina { get; set; }

        public int professorId { get; set; }

        public Professor Professor { get; set; }
    
        public IEnumerable<AlunoDisciplina> AlunoDisciplinas{get; set;}
    }
}