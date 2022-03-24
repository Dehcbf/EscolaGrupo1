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
        //private readonly ProfessorRepository _professorRepository;
        private List<string> _erros;

        public AulaService()
        {
            _aulaRepository = new AulaRepository();
            //_professorRepository = new ProfessorRepository();
            _erros = new List<string>();
        }

        public void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Aulas");
            var nomeMateria = "";

            do
            {
                _erros.Clear();

                Console.Write("\nNome da Matéria: ");
                nomeMateria = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(nomeMateria))
                    _erros.Add("Nome da Matéria não pode estar vazio.");

            }
            while(_erros.Any());

            _aulaRepository.Cadastrar(new Aula(nomeMateria));
        }

        public void Atualizar()
        {
            Console.Clear();
            Console.WriteLine("Atualização de Aulas");
            Aula aula;
            var nomeMateria = "";

            do
            {
                _erros.Clear();

                Console.Write("\nId da aula: ");
                var id = Guid.Parse(Console.ReadLine());

                Console.Write("\nNome da Matéria: ");
                nomeMateria = Console.ReadLine();

                aula = _aulaRepository.BuscarPorId(id);

                if(aula == null)
                    _erros.Add("Aula não encontrada.");

                if(string.IsNullOrWhiteSpace(nomeMateria))
                    _erros.Add("O Nome da Matéria não pode estar vazio.");

            }
            while(_erros.Any());
            
            aula.Atualizar(nomeMateria);
            _aulaRepository.Atualizar(aula);
        }

        public Aula BuscarPorId()
        {
            Console.Clear();
            Console.WriteLine("Buscar Aula");
            Aula aula;
            Guid id;

            do
            {
                _erros.Clear();

                Console.Write("\nId da aula: ");
                id = Guid.Parse(Console.ReadLine());

                aula = _aulaRepository.BuscarPorId(id);

                if(aula == null)
                    _erros.Add("Aula não encontrada.");

            }
            while(_erros.Any());

            return aula;
        }

        public void Deletar()
        {
            Console.Clear();
            Console.WriteLine("Buscar Aula");
            Aula aula;
            Guid id;

            do
            {
                _erros.Clear();

                Console.Write("\nId da aula: ");
                id = Guid.Parse(Console.ReadLine());

                aula = _aulaRepository.BuscarPorId(id);

                if(aula == null)
                    _erros.Add("Aula não encontrada.");
                    
            }
            while(_erros.Any());
            
            aula.Ativo = false;
            _aulaRepository.Atualizar(aula);
        }

        public void AlocarProfessor()
        {
            Console.Clear();
            Console.WriteLine("Buscar Aula");
            Aula aula;
            Guid aulaId;
            Guid professorId;

            do
            {
                _erros.Clear();

                Console.Write("\nId da aula: ");
                aulaId = Guid.Parse(Console.ReadLine());

                Console.Write("\nId do professor: ");
                professorId = Guid.Parse(Console.ReadLine());

                aula = _aulaRepository.BuscarPorId(aulaId);
                //var professor = _professorRepository.BuscarPorId(professorId);

                if(aula == null)
                    _erros.Add("Aula não encontrada.");
                
                // if(professor == null)
                //     _erros.Add("Professor não encontrado.");
                    
            }
            while(_erros.Any());
            
            aula.AlocarProfessor(professorId);
            _aulaRepository.Atualizar(aula);
        }

        // private bool VerificarErros()
        // {
        //     if(_erros.Any())
        //     {
        //         _erros.ForEach(x => Console.WriteLine(x));
        //         return true;
        //     }

        //     return false;
        // }
    }
}