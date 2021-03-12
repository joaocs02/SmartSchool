using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges<T>(T entity) where T : class;

        Aluno[] GetallAlunos(bool bolProfessor);
        Aluno[] GetAlunosByDisciplina(int idDisciplina, bool bolProfessor);
        Aluno GetAlunosByID(int idAluno, bool bolDisciplina);
        
        Professor[] GetallProfessores(bool bolAluno);

        Professor[] GetProfessoresByDisciplina(int idDisciplina, bool aluno);

        Professor GetProfessorByID(int idProfessor, bool bolAluno);

    }
}