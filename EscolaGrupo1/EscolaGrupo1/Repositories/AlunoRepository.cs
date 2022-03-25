using EscolaGrupo1.Entities;
using System.IO;
using System.Linq;

namespace EscolaGrupo1.Repositories
{
    public class AlunoRepository : GenericRepository<Aluno>
    {
        public AlunoRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\alunos.json";
        }

        public void Create(Aluno aluno)
        {
            var database = GetDatabase();
            database.Add(aluno);
            UpdateDatabase(database);
        }

        public Aluno GetByName(string name)
        {
            var database = GetDatabase();
            return database.FirstOrDefault(Aluno => Aluno.Nome.Equals(name));
        }
    }
}
