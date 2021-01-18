using System;

namespace revisao
{
    class Program
    {
        static void Main(string[] args)
        {

            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0; //serve para ter controle de qual espaço do array vai ser alocado
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno");
                        Console.WriteLine("__________________________");
                        Aluno aluno = new Aluno();//instancia objeto aluno
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno");
                        Console.WriteLine("__________________________");

                        //para converter um tipo inteiro para um decimal
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)){ //var é uma inferencia de tipo
                            aluno.Nota = nota;
                        }
                        else{
                            throw new ArgumentOutOfRangeException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        
                        //TODO: adicionar aluno
                        break;
                    case "2":
                        //TODO: listar alunos
                        break;
                    case "3":
                        //TODO: calcular media geral
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = obterOpcaoUsuario();
            }

        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");

            Console.WriteLine("__________________________");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
