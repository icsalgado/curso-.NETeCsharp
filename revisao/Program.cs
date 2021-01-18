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
                        Console.WriteLine("");
                        Aluno aluno = new Aluno();//instancia objeto aluno
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno");
                        Console.WriteLine("");

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
                        foreach(var al in alunos){
                            if (!string.IsNullOrEmpty(al.Nome)){//essa linha testa se o nome não está vazio
                                Console.WriteLine($"ALUNO: {al.Nome} - NOTA: {al.Nota}");
                            }
                            
                        }
                        Console.WriteLine("");
                        //TODO: listar alunos
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nralunos = 0;
                        for (int i=0; i < alunos.Length; i++){
                            if (!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal + alunos[i].Nota;
                                nralunos++;
                            }
                        }
                        
                        var mediaGeral = notaTotal / nralunos;
                        Conceito conceitoGeral;
                        
                        if (mediaGeral < 2){
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4){
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6){
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8){
                            conceitoGeral = Conceito.B;
                        }
                        else{
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO GERAL: {conceitoGeral}");//$ é uma interpolação de string
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
