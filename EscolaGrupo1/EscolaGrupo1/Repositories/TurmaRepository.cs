using EscolaGrupo1.Entities;
using System.IO;
using System.Linq;
using System;

namespace EscolaGrupo1.Repositories
{
    public class TurmaRepository : GenericRepository<Turma>
    {
        public TurmaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @".\..\EscolaGrupo1\Database\turma.json";
        }

        public void Create(Turma turma)
        {
            var database = GetDatabase();
            database.Add(turma);
            UpdateDatabase(database);
        }
        
        public Turma GetByName(string name)
        {
            var database = GetDatabase();
            return database.FirstOrDefault(turma => turma.Nome.Equals(name));
        }

        public Turma ProcurarTurma(string nomeTurma)
        {
            var database = GetDatabase();
            return database.Where(x => x.Ativo).ToList().Find(x => x.Nome.ToLower() == nomeTurma.ToLower());
        }

        public void AtualizarTurma(Turma turma)
        {
            Console.WriteLine(turma);
            var database = GetDatabase().ToList();
            var index = database.FindIndex(x => x.Nome == turma.Nome);
            database[index] = turma;
            UpdateDatabase(database);
        }

        public Turma GetByAlunoName(Aluno aluno)
        {
            var database = GetDatabase();
            return database.FirstOrDefault(turma => turma.Alunos.Contains(aluno));
        }
    }
}
