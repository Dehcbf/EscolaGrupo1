using EscolaGrupo1.Entities;
using EscolaGrupo1.Repositories;
using System;

namespace EscolaGrupo1.Services
{
    public class NotaService
    {
        // TODO: REMOVER OS COMENTARIOS DEPOIS DA IMPLEMENTAÇÃO DO REPOSITORY DE ALUNO!!!!!
        private NotaRepository _notaRepository;
        private AulaRepository _aulaRepository;
        private AlunoRepository _alunoRepository;
        private TurmaRepository _turmaRepository;

        public NotaService()
        {
            _notaRepository = new NotaRepository();
            _turmaRepository = new TurmaRepository();
            _alunoRepository = new AlunoRepository();
            _aulaRepository = new AulaRepository();
        }

        private Turma VerificaTurma()
        {
            Console.Write("Digite o nome da turma: ");
            var identificadorTurma = Console.ReadLine();
            return _turmaRepository.ProcurarTurma(identificadorTurma);
        }

        private Aula VerificaAula()
        {
            Console.Write("Digite qual a aula: ");
            var materiaAula = Guid.Parse(Console.ReadLine());
            return _aulaRepository.BuscarPorId(materiaAula);
        }

        //private Aluno VerificaAluno()
        //{
        //    Console.Write("Digite o nome do aluno: ");
        //    var nomeAluno = Console.ReadLine();
        //    return _alunoRepository.BuscarAluno(nomeAluno);
        //}

        public bool CadastrarNota()
        {
            Console.Clear();

            var resultadoTurma = VerificaTurma();
            if (resultadoTurma is null)
            {
                Console.WriteLine("Turma não encontrado.");
                return false;
            }

            var resultadoMateriaAula = VerificaAula();
            if (resultadoMateriaAula is null)
            {
                Console.WriteLine("Aula não encontrada.");
                return false;
            }

            //var resultadoAluno = VerificaAluno();
            //if (resultadoAluno is null)
            //{
            //    Console.WriteLine("Aluno(a) não encontrado.");
            //    return false;
            //}

            //Console.Write($"Digite a nota do aluno(a) {resultadoAluno.Nome}: ");
            //var notaAluno = double.Parse(Console.ReadLine());

            //Nota nota = new(resultadoTurma.Nome, resultadoMateriaAula.NomeMateria, resultadoAluno.Nome, notaAluno);
            //_notaRepository.Criar(nota);

            return true;
        }

        public bool AtualizarNota()
        {
            Console.Clear();
            var resultadoTurma = VerificaTurma();
            if (resultadoTurma is null)
            {
                Console.WriteLine("Turma não encontrado.");
                return false;
            }

            var resultadoMateriaAula = VerificaAula();
            if (resultadoMateriaAula is null)
            {
                Console.WriteLine("Aula não encontrada.");
                return false;
            }

            //var resultadoAluno = VerificaAluno();
            //if (resultadoAluno is null)
            //{
            //    Console.WriteLine("Aluno(a) não encontrado.");
            //    return false;
            //}

            //var resultadoAlunoNota = _notaRepository.VerNotaPeloNomeAluno(resultadoAluno.Nome);
            //if (resultadoAlunoNota is null)
            //{
            //    Console.WriteLine("Aluno não possui notas.");
            //    return false;
            //}

            //Console.WriteLine("Notas");
            //foreach (var aluno in resultadoAlunoNota)
            //{
            //    Console.WriteLine($"{aluno.NotaAluno}");
            //}

            Console.WriteLine("Digite a nota que será atualizada: ");
            var notaAntiga = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a nova nota: ");
            var notaAtualizada = double.Parse(Console.ReadLine());

            //Nota notaDeletada = new(resultadoTurma.Nome, resultadoMateriaAula.NomeMateria, resultadoAluno.Nome, notaAntiga);
            //_notaRepository.Deletar(notaDeletada);
            //Nota notaNova = new(resultadoTurma.Nome, resultadoMateriaAula.NomeMateria, resultadoAluno.Nome, notaAtualizada);
            //_notaRepository.Criar(notaNova);

            return true;
        }

        public bool DeletarNota()
        {
            Console.Clear();
            var resultadoTurma = VerificaTurma();
            if (resultadoTurma is null)
            {
                Console.WriteLine("Turma não encontrado.");
                return false;
            }

            var resultadoMateriaAula = VerificaAula();
            if (resultadoMateriaAula is null)
            {
                Console.WriteLine("Aula não encontrada.");
                return false;
            }

            //var resultadoAluno = VerificaAluno();
            //if (resultadoAluno is null)
            //{
            //    Console.WriteLine("Aluno(a) não encontrado.");
            //    return false;
            //}

            //var resultadoAlunoNota = _notaRepository.VerNotaPeloNomeAluno(resultadoAluno.Nome);
            //if (resultadoAlunoNota is null)
            //{
            //    Console.WriteLine("Aluno não possui notas.");
            //    return false;
            //}

            //Console.WriteLine("Notas");
            //foreach (var aluno in resultadoAlunoNota)
            //{
            //    Console.WriteLine($"{aluno.NotaAluno}");
            //}

            Console.WriteLine("Digite a nota que será deletada: ");
            var notaDeletada = double.Parse(Console.ReadLine());

            //Nota nota = new(resultadoTurma.Nome, resultadoMateriaAula.NomeMateria, resultadoAluno.Nome, notaDeletada);
            //_notaRepository.Deletar(nota);

            return true;
        }

        public bool VerTodasNotasPorAluno()
        {
            Console.Clear();
            var resultadoTurma = VerificaTurma();
            if (resultadoTurma is null)
            {
                Console.WriteLine("Turma não encontrado.");
                return false;
            }

            var resultadoMateriaAula = VerificaAula();
            if (resultadoMateriaAula is null)
            {
                Console.WriteLine("Aula não encontrada.");
                return false;
            }

            //var resultadoAluno = VerificaAluno();
            //if (resultadoAluno is null)
            //{
            //    Console.WriteLine("Aluno(a) não encontrado.");
            //    return false;
            //}

            //var resultadoAlunoNota = _notaRepository.VerNotaPeloNomeAluno(resultadoAluno.Nome);
            //if (resultadoAlunoNota is null)
            //{
            //    Console.WriteLine("Aluno não possui notas.");
            //    return false;
            //}

            //Console.WriteLine($"Notas do aluno {resultadoAluno.Nome}");
            //foreach (var aluno in resultadoAlunoNota)
            //{
            //    Console.WriteLine($"{aluno.NotaAluno}");
            //}

            return true;
        }
    }
}
