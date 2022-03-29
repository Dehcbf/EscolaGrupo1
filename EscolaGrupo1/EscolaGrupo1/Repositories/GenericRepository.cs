using EscolaGrupo1.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EscolaGrupo1.Repositories
{
    public class GenericRepository<T> where T : BaseEntity
    {
        protected string Host { get; set; }

        protected List<T> GetDatabase()
        {
            var registros = File.ReadAllText(Host);
            if (registros == "")
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(registros);
        }

        protected void UpdateDatabase(List<T> database)
        {
            File.WriteAllTextAsync(Host, JsonSerializer.Serialize(database));
        }

        public List<T> GetAll()
        {
            return GetDatabase().FindAll(x => x.Ativo).ToList();
        }
    }
}
