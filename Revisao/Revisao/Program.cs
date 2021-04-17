using System;

namespace Revisao
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;

            string opcao = ObterOpcao();

            while (opcao.ToUpper() != "X")
            {
                
                switch (opcao)
                {
                    case "1":
                        //TO DO: adicionar aluno
                        Console.WriteLine("Informa o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }
                        

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        //TO DO: listar alunos
                        foreach(var obj in alunos)
                        {
                            if(obj != null)
                            {
                                Console.WriteLine($"Aluno: {obj.Nome} - Nota: {obj.Nota}");
                            }
                            
                        }
                        break;
                    case "3":
                        //TO DO: Calcular média geral
                        decimal notaTotal = 0;
                        var numAlunos = 0;
                        for(int i = 0; i < alunos.Length; i++)
                        {
                            if(alunos[i] != null)
                            {
                                notaTotal += alunos[i].Nota;
                                numAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / numAlunos;

                        Conceito conceitoGeral = 0;

                        if (mediaGeral <2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral >=3 && mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral >=4 && mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral >= 6 && mediaGeral<8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else if (mediaGeral >= 8)
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média geral dos alunos é: {mediaGeral} - Conceito: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = ObterOpcao();
            }
        }

        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine();
            Console.WriteLine();
            return opcao;
        }
    }
}
