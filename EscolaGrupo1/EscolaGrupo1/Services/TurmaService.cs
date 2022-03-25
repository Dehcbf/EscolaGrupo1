using System;
using System.Collections.Generic;
using System.IO;
using EscolaGrupo1.Repositories;
using EscolaGrupo1.Entities;

namespace EscolaGrupo1.Services
{
    public class TurmaService : GenericRepository<Turma>
    {
        private readonly TurmaRepository _turmaRepository;
        public TurmaService()
        {
            Host = Directory.GetCurrentDirectory() + @"\..\..\..\Database\turma.json";
            _turmaRepository = new TurmaRepository();
        }

        public void CadastrarTurma(string nomeTurma, List<string> aulas, List<string> alunos)
        {
            //verificar se as aulas existem
            //verificar se os alunos existem
            if (true)
                _turmaRepository.Create(new Turma(nomeTurma, aulas, alunos));
            else
                Console.WriteLine("Informações inválidas");
        }
     
    }
}