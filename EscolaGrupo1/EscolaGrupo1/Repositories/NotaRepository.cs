using EscolaGrupo1.Entities;
using System.Collections.Generic;
using System.IO;

namespace EscolaGrupo1.Repositories
{
    public class NotaRepository : GenericRepository<Nota>
    {
        public NotaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @".\..\EscolaGrupo1\Database\notas.json";
        }

        public void Criar(Nota nota)
        {
            var database = GetDatabase();
            database.Add(nota);
            UpdateDatabase(database);
        }

        public List<Nota> VerNotaPeloNomeAluno(string nomeAluno)
        {
            var database = GetDatabase();
            var notasAluno = database.FindAll(x => x.Aluno.Equals(nomeAluno));
            return notasAluno;
        }

        public void Deletar(Nota nota)
        {
            var database = GetDatabase();
            database.Remove(nota);
            UpdateDatabase(database);
        }
    }
}
