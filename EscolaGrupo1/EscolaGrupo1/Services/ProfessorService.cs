using EscolaGrupo1.Entities;
using System;
using System.Linq;
using EscolaGrupo1.Repositories;
using System.Collections.Generic;

namespace EscolaGrupo1.Professores.Service
{
    public class ProfessorService
    {
        private readonly ProfessorRepository _professorRepository;


        public ProfessorService()
        {
            _professorRepository = new ProfessorRepository();
        }

        public bool ValidarProfessor(Professor professor)
        {
            if (string.IsNullOrEmpty(professor.Nome)){
                Console.WriteLine("Nome do professor não informado");
                return false;
            }

            if (string.IsNullOrEmpty(professor.Materia)){
                Console.WriteLine("Matéria do professor não informada");
                return false;
            }

            if (string.IsNullOrEmpty(professor.Email)){
                Console.WriteLine("E-mail do professor não informado");
                return false;
            }

            if (!(professor.Email.IndexOf('@') > 0)){
                Console.WriteLine("E-mail inválido");
                return false;
            }

            return true;
        }

        public void CadastrarProfessor(Professor professor)
        {
            var professores = _professorRepository.ObterTodos();

            if (professores.Any())
            {
                if (!ValidarProfessor(professor))
                    return;
            }

            if (professores.Any(x => x.Email == professor.Email))
            {
                Console.WriteLine("Professor já cadastrado");
            }
            else
            {
                _professorRepository.Cadastrar(new Professor{
                    Nome = professor.Nome, 
                    Email = professor.Email,
                    Materia = professor.Materia,
                    Id = Guid.NewGuid(),
                    Ativo = true,
                    Presencas = new List<Presenca>()
                });
                Console.WriteLine("Professor cadastrado com sucesso");
            }
        }

        public List<Professor> ObterTodosProfessores(){
            return _professorRepository.GetAll();
        }

        public void AtualizarProfessor()
        {
            Console.WriteLine("Digite o e-mail do professor: ");
            var emailProfessorBusca = Console.ReadLine();
            var professor = _professorRepository.ObterTodos().Find(x => x.Email == emailProfessorBusca);

            if (professor is null)
            {
                Console.WriteLine("E-mail não encontrado");
                return;
            }

            var indexProfessor = _professorRepository.ObterTodos().FindIndex(x => x.Email == emailProfessorBusca);

            Console.WriteLine("Digite o novo nome do Professor: ");
            var nomeProfessor = Console.ReadLine();

            Console.WriteLine("Digite o novo e-mail do Professor: ");
            var emailProfessor = Console.ReadLine();

            Console.WriteLine("Digite a nova matéria do Professor: ");
            var materiaProfessor = Console.ReadLine();

            _professorRepository.Deletar(indexProfessor);
            _professorRepository.Cadastrar(new Professor{
                    Nome = nomeProfessor, 
                    Email = emailProfessor,
                    Materia = materiaProfessor,
                    Id = professor.Id,
                    Ativo = true,
                    Presencas = professor.Presencas
                });

            Console.WriteLine("Professor atualizado com sucesso");
        }

        public void ExcluirProfessor(string email)
        {
            var professor = _professorRepository.GetAll().Find(x => x.Email == email);
            professor.Ativo = false;
            var professorDeletar = _professorRepository.GetAll().FindIndex(x => x.Email == email);
            _professorRepository.Deletar(professorDeletar);
            _professorRepository.Cadastrar(professor);
            
            Console.WriteLine("Professor excluído com sucesso");
        }

        public void MarcarPresencas(string emailProfessor, string turma, string dataAula, List<string> alunos){
            var professorBanco = _professorRepository.ObterTodos().Find(x => x.Email == emailProfessor);
            
            if (professorBanco is null)
            {
                Console.WriteLine("E-mail do professor não encontrado");
                return;
            }

            var indexProfessor = _professorRepository.ObterTodos().FindIndex(x => x.Email == professorBanco.Email);
            _professorRepository.Deletar(indexProfessor);

            var presencas = professorBanco.Presencas;
            var presenca = new Presenca{
                Turma = turma,
                DataAula = dataAula,
                AlunosPresentes = alunos
            };
            presencas.Add(presenca);

            _professorRepository.Cadastrar(new Professor{
                Id = professorBanco.Id,
                Ativo = true,
                Email = emailProfessor,
                Materia = professorBanco.Materia,
                Nome = professorBanco.Nome,
                Presencas = presencas
            });

            Console.WriteLine($"Presenças marcadas com sucesso para o dia {dataAula}");
        }
    }
}