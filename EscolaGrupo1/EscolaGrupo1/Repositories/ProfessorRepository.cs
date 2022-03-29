using EscolaGrupo1.Entities;
using System.Collections.Generic;
using System.IO;

namespace EscolaGrupo1.Repositories
{
    public class ProfessorRepository : GenericRepository<Professor>
    {
        public ProfessorRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\professores.json";
        }

        public void Cadastrar(Professor professor)
        {
            var database = GetDatabase();
            database.Add(professor);
            UpdateDatabase(database);
        }

        public void Atualizar(Professor professor)
        {
            var database = GetDatabase();
            database.Add(professor);
            UpdateDatabase(database);
        }

        public void Deletar(int indexProfessor)
        {
            var database = GetDatabase();
            database.RemoveAt(indexProfessor);
            UpdateDatabase(database);
        }

        public List<Professor> ObterTodos()
        {
            var database = GetDatabase();
            var professores = GetAll();
            return professores;
        }
    }
}
