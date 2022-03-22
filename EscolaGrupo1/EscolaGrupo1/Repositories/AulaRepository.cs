using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using EscolaGrupo1.Entities;
using EscolaGrupo1.Interfaces.Repositories;
using EscolaGrupo1.Interfaces.Services;
using System.Linq;

namespace EscolaGrupo1.Repositories
{
    public class AulaRepository : GenericRepository<Aula>, IAulaRepository
    {
        public AulaRepository()
        {
            Host = Directory.GetCurrentDirectory() + @"\Database\aula.json";
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
            var database = GetDatabase().ToList();
            return database.Where(x => x.Ativo).Find(x => x.Id == id);
        }
    }
}