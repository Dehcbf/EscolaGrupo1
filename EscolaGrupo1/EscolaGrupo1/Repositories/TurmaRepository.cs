using EscolaGrupo1.Entities;
using System.IO;

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
    }
}
