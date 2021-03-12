using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartDbContext _context;
        public Repository(SmartDbContext context)
        {
            _context = context;
        }
        public void add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges<T>(T entity) where T : class
        {
           return _context.SaveChanges() > 0;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Aluno[] GetallAlunos(bool bolProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(bolProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                                   .ThenInclude(ad => ad.Disciplina )
                                   .ThenInclude(p => p.Professor); 
            }  
            query = query.AsNoTracking().OrderBy(a => a.alunoId); 

            return query.ToArray();  
        }

        public Aluno[] GetAlunosByDisciplina(int idDisciplina, bool bolProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(bolProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                                   .ThenInclude(ad => ad.Disciplina )
                                   .ThenInclude(p => p.Professor); 
            }  
            query = query.AsNoTracking().Where(d => d.AlunoDisciplinas.Any(ad => ad.disciplinaId == idDisciplina)); 

            return query.ToArray();  
        }

        public Aluno GetAlunosByID(int idAluno, bool bolDisciplina = false)
        {
              IQueryable<Aluno> query = _context.Alunos;

            if(bolDisciplina)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                                   .ThenInclude(ad => ad.Disciplina )
                                   .ThenInclude(p => p.Professor); 
            }  
            query = query.AsNoTracking().Where(a => a.alunoId == idAluno); 

            return query.FirstOrDefault(); 
        }


        public Professor[] GetallProfessores(bool bolAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            if (bolAluno)
            {
                query = query.Include(d => d.Disciplina)
                            .ThenInclude(ad => ad.AlunoDisciplinas)
                            .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.professorID);

            return query.ToArray(); 
        }

        public Professor[] GetProfessoresByDisciplina(int idDisciplina, bool bolAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            if (bolAluno)
            {
                query = query.Include(d => d.Disciplina)
                        .ThenInclude(ad => ad.AlunoDisciplinas)
                        .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking()
                         .Where(p => p.Disciplina.Any(d => d.disciplinaId == idDisciplina));

            return query.ToArray();  
        }

        public Professor GetProfessorByID(int idProfessor, bool bolAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            if(bolAluno)
            {
                query = query.Include(d => d.Disciplina)
                        .ThenInclude(ad => ad.AlunoDisciplinas)
                        .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().Where(p => p.professorID == idProfessor);

            return query.FirstOrDefault();
        }
    }
}