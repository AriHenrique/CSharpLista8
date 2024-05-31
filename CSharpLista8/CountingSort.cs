using System;
using System.Diagnostics;

namespace CSharpLista8
{
    public class CountingSort
    {
        public static long movi;
        public static long comp;
        static int GetMaior(int[] array)
        {
            int n = array.Length;
            int maior = array[0];
            for (int i = 1; i < n; i++)
            {
                comp++;
                if (array[i] > maior)
                {
                    maior = array[i];
                }
            }
            return maior;
        }

        static void Init(int[] array)
        {
            int n = array.Length;
            int[] count = new int[GetMaior(array) + 1];
            int[] ordenado = new int[n];

            for (int i = 0; i < n; i++)
            {
                movi++;
                count[array[i]]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                movi++;
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                movi+=2;
                ordenado[count[array[i]] - 1] = array[i];
                count[array[i]]--;
            }

            for (int i = 0; i < n; i++)
            {
                movi++;
                array[i] = ordenado[i];
            }
        }

        public static void Exe(int[] vet)
        {
            comp = 0;
            movi = 0;
            var stopwatch = Stopwatch.StartNew();
            Init(vet);
            stopwatch.Stop();
            long tempo = stopwatch.ElapsedMilliseconds;

            Console.WriteLine(
                $"CountingSort - Movimentações: {movi}, Comparações: {comp}, Tempo: {tempo} ms");
        }
    }
}
