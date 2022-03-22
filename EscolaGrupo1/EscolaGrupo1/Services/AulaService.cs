using System;
using System.Linq;
using System.Collections.Generic;
using EscolaGrupo1.Repositories;
using EscolaGrupo1.Entities;
using EscolaGrupo1.Interfaces.Repositories;
using EscolaGrupo1.Interfaces.Services;

namespace EscolaGrupo1.Services
{
    public class AulaService : IAulaService
    {
        private readonly AulaRepository _aulaRepository;
        private List<string> _erros;

        public AulaService()
        {
            _aulaRepository = new AulaRepository();
            _erros = new List<string>();
        }

        public void Cadastrar(string nomeMateria)
        {
            if(string.IsNullOrWhiteSpace(nomeMateria))
                _erros.Add("Nome da Matéria não pode estar vazio.");

            if(VerificarErros())
                return;

            _aulaRepository.Cadastrar(new Aula(nomeMateria));
        }

        public void Atualizar(Guid id, string nomeMateria)
        {
            var aula = _aulaRepository.BuscarPorId(id);

            if(aula == null)
                _erros.Add("Aula não encontrada.");

            if(string.IsNullOrWhiteSpace(nomeMateria))
                _erros.Add("O Nome da Matéria não pode estar vazio.");

            if(VerificarErros())
                return;
            
            aula.Atualizar(nomeMateria);
            _aulaRepository.Atualizar(aula);
        }

        public Aula BuscarPorId(Guid id)
        {
            return _aulaRepository.BuscarPorId(id);
        }

        public void Deletar(Guid id)
        {
            var aula = _aulaRepository.BuscarPorId(id);

            if(aula == null)
                _erros.Add("Aula não encontrada.");

            if(VerificarErros())
                return;
            
            aula.Ativo = false;
            _aulaRepository.Atualizar(aula);
        }

        public void AlocarProfessor(Guid aulaId, Guid professorId)
        {
            throw new NotImplementedException();
        }

        private bool VerificarErros()
        {
            if(_erros.Any())
            {
                _erros.ForEach(x => Console.WriteLine(x));
                return true;
            }

            return false;
        }
    }
}