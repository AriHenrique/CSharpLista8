using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpLista8
{
    internal abstract class Program
    {
        static void Ordenacao()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Selecao");
            Console.WriteLine("2) Bolha");
            Console.WriteLine("3) Insercao");
            Console.WriteLine("4) QuickSort");
            Console.WriteLine("5) MergeSort");
            Console.WriteLine("6) Heapsort");
            Console.WriteLine("7) CountingSort");
            Console.WriteLine("8) TODOS");
            int opcao = Convert.ToInt32(Console.ReadLine());

            int range = 500000; //Convert.ToInt32(Console.ReadLine());
            string filePath = "teste.txt";
            switch (opcao)
            {
                case 1:
                    filePath = $"../../outputDouble/{range}_SelecaoD_int_output.txt";
                    break;
                case 2:
                    filePath = $"../../outputDouble/{range}_BolhaD_int_output.txt";
                    break;
                case 3:
                    filePath = $"../../outputDouble/{range}_InsercaoD_int_output.txt";
                    break;
                case 4:
                    filePath = $"../../outputDouble/{range}_QuickSortD_int_output.txt";
                    break;
                case 5:
                    filePath = $"../../outputDouble/{range}_MergeSortD_int_output.txt";
                    break;
                case 6:
                    filePath = $"../../outputDouble/{range}_HeapsortD_int_output.txt";
                    break;
                case 7:
                    filePath = $"../../outputDouble/{range}_CountingSortD_int_output.txt";
                    break;
                case 8:
                    filePath = $"../../outputDouble/{range}_double_output.txt";
                    break;
            }

            using (StreamWriter fileWriter = new StreamWriter(filePath))
            {
                DualWriter dualWriter = new DualWriter(Console.Out, fileWriter);
                Console.SetOut(dualWriter);
                
                // int[] vetorCrescente = Enumerable.Range(1, range).ToArray();
                // int[] vetorDecrescente = Enumerable.Range(1, range).OrderByDescending(x => x).ToArray();
                // Random rng = new Random();
                // int[] vetorAleatorio = Enumerable.Range(1, range).OrderBy(x => rng.Next()).ToArray();
                //     
                // Dictionary<string, int[]> testes = new Dictionary<string, int[]>
                // {
                //     { "vetorCrescente", vetorCrescente },
                //     { "vetorDecrescente", vetorDecrescente },
                //     { "vetorAleatorio", vetorAleatorio }
                // };
                //
                //
                double[] vetorCrescenteD = Enumerable.Range(1, range).Select(x => (double)x).ToArray();
                double[] vetorDecrescenteD = Enumerable.Range(1, range).Select(x => (double)x).OrderByDescending(x => x).ToArray();
                Random rngD = new Random();
                double[] vetorAleatorioD = Enumerable.Range(1, range).Select(x => (double)x).OrderBy(x => rngD.Next()).ToArray();
                
                Dictionary<string, double[]> testes = new Dictionary<string, double[]>
                {
                    { "vetorCrescente - double", vetorCrescenteD },
                    { "vetorDecrescente - double", vetorDecrescenteD },
                    { "vetorAleatorio - double", vetorAleatorioD }
                };

                
                if (opcao == 1)
                {
                    Console.WriteLine($"\n{range}-----------------Selecao-----------------\n");
                    foreach (var test in testes)
                    {
                        Console.Write($"{test.Key} - ");
                        // Selecao.Exe(test.Value);
                        SelecaoD.Exe(test.Value);
                    }
                }
                else if (opcao == 2)
                {
                    Console.WriteLine($"\n{range}-----------------Bolha-----------------\n");
                    foreach (var test in testes)
                    {
                        Console.Write($"{test.Key} - ");
                        // Bolha.Exe(test.Value);
                        BolhaD.Exe(test.Value);
                    }
                }
                else if (opcao == 3)
                {
                    Console.WriteLine($"\n{range}-----------------Insercao-----------------\n");
                    foreach (var test in testes)
                    {
                        Console.Write($"{test.Key} - ");
                        // Insercao.Exe(test.Value);
                        InsercaoD.Exe(test.Value);
                    }
                }
                else if (opcao == 4)
                {
                    Console.WriteLine($"\n{range}-----------------QuickSort-----------------\n");
                    foreach (var test in testes)
                    {
                        Console.Write($"{test.Key} - ");
                        // QuickSort.Exe(test.Value);
                        QuickSortD.Exe(test.Value);
                    }
                }
                else if (opcao == 5)
                {
                    Console.WriteLine($"\n{range}-----------------MergeSort-----------------\n");
                    foreach (var test in testes)
                    {
                        Console.Write($"{test.Key} - ");
                        // MergeSort.Exe(test.Value);
                        MergeSortD.Exe(test.Value);
                    }
                }
                else if (opcao == 6)
                {
                    Console.WriteLine($"\n{range}-----------------Heapsort-----------------\n");
                    foreach (var test in testes)
                    {
                        Console.Write($"{test.Key} - ");
                        // Heap.Exe(test.Value);
                        HeapD.Exe(test.Value);
                    }
                }
                else if (opcao == 7)
                {
                    Console.WriteLine($"\n{range}-----------------CountingSort-----------------\n");
                    foreach (var test in testes)
                    {
                        Console.Write($"{test.Key} - ");
                        // CountingSort.Exe(test.Value);
                    }
                }

                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);
                Console.WriteLine($"A saida foi salva em {filePath}");
            }
        }
        
        public static void Main(string[] args)
        {
            // ProgramJogador.Exe();
            // Ordenacao();
            MarkDown.Exe();
        }
        
    }
}