using System;
using System.Linq;
using System.Collections.Generic;
using EscolaGrupo1.Repositories;
using EscolaGrupo1.Entities;
using EscolaGrupo1.Interfaces.Services;

namespace EscolaGrupo1.Services
{
    public class AulaService : IAulaService
    {
        private readonly AulaRepository _aulaRepository;
        private readonly ProfessorRepository _professorRepository;
        private List<string> _erros;

        public AulaService()
        {
            _aulaRepository = new AulaRepository();
            _professorRepository = new ProfessorRepository();
            _erros = new List<string>();
        }

        public Guid Cadastrar(string nomeMateria)
        {
            if(string.IsNullOrWhiteSpace(nomeMateria))
                _erros.Add("Nome da Matéria não pode estar vazio.");

            if (VerificarErros())
                return Guid.Empty;

            var aula = new Aula(nomeMateria);
            _aulaRepository.Cadastrar(aula);
            return aula.Id;
        }

        public void Atualizar(Guid aulaId, string nomeMateria)
        {
            if(aulaId == default)
            {
                Console.WriteLine("Id da aula inválido.");
                return;
            }

            var aula = _aulaRepository.BuscarPorId(aulaId);

            if(aula == null)
                _erros.Add("Aula não encontrada.");

            if(string.IsNullOrWhiteSpace(nomeMateria))
                _erros.Add("O Nome da Matéria não pode estar vazio.");

            if(VerificarErros())
                return;

            aula.Atualizar(nomeMateria);
            _aulaRepository.Atualizar(aula);
        }

        public Aula BuscarPorId(Guid aulaId)
        {
            return _aulaRepository.BuscarPorId(aulaId);
        }

        public List<Aula> BuscarTodos()
        {
            return _aulaRepository.GetAll().Where(x => x.Ativo).ToList();
        }

        public void Deletar(Guid aulaId)
        {
            if(aulaId == default)
            {
                Console.WriteLine("Id da aula inválido.");
                return;
            }

            var aula = _aulaRepository.BuscarPorId(aulaId);

            if(aula == null)
                _erros.Add("Aula não encontrada.");

            if(VerificarErros())
                return;

            aula.Ativo = false;
            _aulaRepository.Atualizar(aula);
        }

        public void AlocarProfessor(Guid aulaId, Guid professorId)
        {
            if(aulaId == default)
            {
                if(professorId == default)
                    Console.WriteLine("Id do professor inválido.");
                    
                Console.WriteLine("Id da aula inválido.");
                return;
            }

            var aula = _aulaRepository.BuscarPorId(aulaId);
            var professor = _professorRepository.ObterTodos().Find(x => x.Id == professorId);

            if(aula == null)
                _erros.Add("Aula não encontrada.");
                
            if(professor == null)
                _erros.Add("Professor não encontrado.");
                    
            if(VerificarErros())
                return;
            
            aula.ProfessorId = professorId;
            _aulaRepository.Atualizar(aula);
        }

        private bool VerificarErros()
        {
            if (_erros.Any())
            {
                _erros.ForEach(x => Console.WriteLine(x));
                return true;
            }

            return false;
        }
    }
}