using System;
using System.Collections.Generic;
using System.IO;
using EscolaGrupo1.Repositories;

namespace EscolaGrupo1.turmas
{
    public class TurmaService : GenericRepository<Turma>
    {
        public TurmaService()
        {
            Host = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\turma.json";
        }

        public void CadastrarTurma(string nomeTurma, List<Guid> IdAula, List<Guid> IdAluno)
        {
            throw new NotImplementedException();
        }

    }
}