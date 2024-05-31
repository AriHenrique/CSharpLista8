using System;
using System.Diagnostics;

namespace CSharpLista8
{
    class SelecaoD
    {
        public static long movi;
        public static long comp;

        static void Init(double[] array)
        {
            int n = array.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int menor = i;
                for (int j = (i + 1); j < n; j++)
                {
                    comp++;
                    if (array[menor] > array[j])
                    {
                        menor = j;
                    }
                }

                movi += 3;
                double temp = array[menor];
                array[menor] = array[i];
                array[i] = temp;
            }
        }

        public static void Exe(double[] vet)
        {
            comp = 0;
            movi = 0;
            var stopwatch = Stopwatch.StartNew();
            Init(vet);
            stopwatch.Stop();
            long tempo = stopwatch.ElapsedMilliseconds;

            Console.WriteLine(
                $"Selecao Double - Movimentações: {movi}, Comparações: {comp}, Tempo: {tempo} ms");
        }
    }
}