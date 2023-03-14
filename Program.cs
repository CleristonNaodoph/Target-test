using System.Text.Json;
using Newtonsoft.Json;
using Classes;

namespace Target
{
    class Program
    {
        static void Main()
        {
            int? opcao;

            do
            {

                try
                {
                    Console.WriteLine("Selecione o número que deseja no Menu abaixo: ");
                    Console.WriteLine(" 1 - Primeira Questão (Somatório)\n 2 - Segunda Questão (Fibonacci)\n 3 - Terceira Questão\n 4 - Quarta Questão (Participação)\n 5 - Quinta Questão (Inverter String)\n 0 - Sair\n\n Digite sua Opção: ");

                    opcao = int.Parse(Console.ReadLine());
                    Console.Clear();


                    switch (opcao)
                    {
                        case 1:
                            pergunta1();
                            break;
                        case 2:
                            Console.WriteLine("--- Segunda questão ---\n Digite o numero da Fibonacci a ser verificado:");
                            int fibo = int.Parse(Console.ReadLine());
                            Boolean ret = pergunta2(fibo);

                            if (ret == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"O numero {fibo} pertence a sequencia fibonacci!\n\n");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"O numero {fibo} NÂO pertence a sequencia fibonacci!\n\n");
                            }
                            break;
                        case 3:
                            Console.WriteLine("3 - Terceira Pergunta");

                            List<Filial> faturamento = new List<Filial>();
                            faturamento = adquirirdados();
                            int qtDias = faturamento.Count;

                            Filial menor = new Filial(faturamento[0]);
                            Filial maior = new Filial();
                            double soma = 0;
                            double media;
                            int qtDiasFat = 0;


                            foreach (Filial Fl in faturamento)
                            {
                                soma += Fl.valor;
                                if (Fl.valor < menor.valor)
                                {
                                    menor = Fl;
                                }
                                else if (Fl.valor > maior.valor)
                                {
                                    maior = Fl;
                                }
                            }
                            media = soma / qtDias;
                            foreach (Filial Fl in faturamento)
                            {
                                if (Fl.valor >= media)
                                {
                                    qtDiasFat += 1;
                                }
                            }
                            Console.WriteLine("----------------------\n Faturamento Diário");
                            Console.WriteLine($"O MENOR faturamento foi no dia {menor.dia}, com o valor de {Math.Round(menor.valor, 2)}");
                            Console.WriteLine($"O MAIOR faturamento foi no dia {maior.dia}, com o valor de {Math.Round(maior.valor, 2)}");
                            Console.WriteLine($"Média de faturamento: {Math.Round(media, 2)},Em {qtDiasFat} dias o faturamento foi maior que a MÈDIA!\n");

                            break;
                        case 4:
                            List<Estado_fat> dist = new List<Estado_fat>();
                            dist.Add(new Estado_fat("SP", 67836.43));
                            dist.Add(new Estado_fat("RJ", 36678.66));
                            dist.Add(new Estado_fat("MG", 29229.88));
                            dist.Add(new Estado_fat("ES", 27165.48));
                            dist.Add(new Estado_fat("Outros", 19849.53));

                            double total = 0;
                            double part = 0;
                            foreach (Estado_fat Estado_fat in dist)
                            {
                                total += Estado_fat.Faturamento;
                            }
                            foreach (Estado_fat Estado_fat in dist)
                            {
                                part = Estado_fat.participacao(Estado_fat.Faturamento, total);

                                Console.WriteLine($" Estado: {Estado_fat.Estado} \n Faturamento: R$ {Estado_fat.Faturamento}\n Participação: {part}%\n\n");
                            }
                            break;
                        case 5:
                            Console.WriteLine("--- Digite a String a ser invertida:");
                            string str = Console.ReadLine();
                            string invert = pergunta5(str);
                            Console.WriteLine(invert + "\n\n");
                            break;
                        case 0:
                            Console.WriteLine("0 - Sair");
                            break;
                        default:
                            Console.WriteLine("Opção inexistente!");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Opção inválida!");
                    opcao = 7;
                }

            } while (opcao != 0);



            static void pergunta1()
            {
                Console.Clear();
                int indice = 13, soma = 0, k = 0;
                while (k < indice)
                {
                    k = k + 1;
                    soma = soma + k;
                }
                Console.WriteLine($"--- Primeira Questão ---\n O somatório final é {soma}\n\n");
            }

            static Boolean pergunta2(int fibo)
            {
                int temp, primeiro = 0, segundo = 1, soma = 0;
                {
                    while (soma < fibo)
                    {
                        temp = segundo + soma;
                        primeiro = segundo;
                        segundo = soma;
                        soma = temp;
                    };

                    if (fibo == soma)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            static string pergunta5(string str)
            {
                string invert = new string((new Stack<char>(str)).ToArray());

                return invert;
            }

        }

        /* funções para deserializar e verificar faturamento*/
        public static List<Filial> adquirirdados()
        {
            List<Filial> arquivo = new List<Filial>();
            List<Filial> fat = new List<Filial>();

            using (StreamReader stream = new StreamReader(@"C:\Programas\TargetTest\dados.json"))
            {
                string dadosJson = stream.ReadToEnd();
                arquivo = JsonConvert.DeserializeObject<List<Filial>>(dadosJson);
            }

            foreach (Filial fl in arquivo)
            {
                if (fl.valor > 0)
                {
                    fat.Add(fl);
                }
            }

            return fat;
        }






    }


}



