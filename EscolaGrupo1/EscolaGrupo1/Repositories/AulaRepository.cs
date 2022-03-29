using System;
using System.Text.Json;
using System.IO;
using EscolaGrupo1.Entities;
using EscolaGrupo1.Interfaces.Repositories;
using System.Linq;

namespace EscolaGrupo1.Repositories
{
    public class AulaRepository : GenericRepository<Aula>, IAulaRepository
    {
        public AulaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\aula.json";
        }

         public void Cadastrar(Aula aula)
        {
            var database = GetDatabase().ToList();

            database.Add(aula);
            File.WriteAllText(Host, JsonSerializer.Serialize(database));
        }

        public void Atualizar(Aula aula)
        {
            var database = GetDatabase().ToList();
            var index = database.FindIndex(x => x.Id == aula.Id);

            database[index] = aula;

            UpdateDatabase(database);
        }

        public Aula BuscarPorId(Guid id)
        {
            var database = GetDatabase();
            return database.Where(x => x.Ativo).ToList().Find(x => x.Id == id);
        }
    }
}