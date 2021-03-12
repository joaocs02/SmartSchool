using System.Collections.Generic;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor() { 
        }
        public Professor(int professorID, string nomeProfessor)
        {
            this.professorID = professorID;
            this.nomeProfessor = nomeProfessor;
        }
        public int professorID { get; set; }

        public string nomeProfessor { get; set; }

        public IEnumerable<Disciplina> Disciplina { get; set; }
    }
}