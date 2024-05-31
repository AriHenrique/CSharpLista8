using System;
using System.Diagnostics;

namespace CSharpLista8
{
    public class Insercao
    {
        public static long movi;
        public static long comp;
        static void Init(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++) {
                int tmp = array[i];
                int j = i - 1;
                comp++;
                while ( (j >= 0) && (array[j] > tmp) ){
                    array[j + 1] = array[j];
                    comp++;
                    movi++;
                    j--;
                }
                movi++;
                array[j + 1] = tmp;
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
                $"Insercao - Movimentações: {movi}, Comparações: {comp}, Tempo: {tempo} ms");
        }

    }
}