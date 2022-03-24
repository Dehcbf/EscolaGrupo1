using System;
using System.Collections.Generic;
using System.IO;
using EscolaGrupo1.Repositories;
using EscolaGrupo1.Entities;

namespace EscolaGrupo1.Services
{
    public class TurmaService : GenericRepository<Turma>
    {
        public TurmaService()
        {
            Host = Directory.GetCurrentDirectory() + @"\Database\turma.json";
        }

        public void CadastrarTurma(string nomeTurma, List<Guid> IdAula, List<Guid> IdAluno)
        {
            throw new NotImplementedException();
        }

    }
}