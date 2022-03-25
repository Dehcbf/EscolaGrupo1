using EscolaGrupo1.Entities;
using System.IO;
using System.Linq;

namespace EscolaGrupo1.Repositories
{
    public class TurmaRepository : GenericRepository<Turma>
    {
        public TurmaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\turma.json";
        }

        public void Create(Turma turma)
        {
            var database = GetDatabase();
            database.Add(turma);
            UpdateDatabase(database);
        }
        
        public Turma ProcurarTurma(string nomeTurma)
        {
            var database = GetDatabase();
            return database.Where(x => x.Ativo).ToList().Find(x => x.Nome.ToLower() == nomeTurma.ToLower());
        }
    }
}
