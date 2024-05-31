using System;
using System.Diagnostics;

namespace CSharpLista8
{
    public class MergeSort
    {
        public static long comparacoes;
        public static long movimentacoes;

        static void Mergesort(int[] array, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(array, esq, meio);
                Mergesort(array, meio + 1, dir);
                Intercalar(array, esq, meio, dir);
            }
        }

        static void Intercalar(int[] array, int esq, int meio, int dir)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;
            int[] arrayEsq = new int[nEsq];
            int[] arrayDir = new int[nDir];

            for (int i = 0; i < nEsq; i++)
            {
                movimentacoes++;
                arrayEsq[i] = array[esq + i];
            }

            for (int i = 0; i < nDir; i++)
            {
                movimentacoes++;
                arrayDir[i] = array[meio + 1 + i];
            }

            int iEsq = 0, iDir = 0, k = esq;
            while (iEsq < nEsq && iDir < nDir)
            {
                comparacoes++;
                movimentacoes++;
                if (arrayEsq[iEsq] <= arrayDir[iDir])
                {
                    array[k++] = arrayEsq[iEsq++];
                }
                else
                {
                    array[k++] = arrayDir[iDir++];
                }
            }

            while (iEsq < nEsq)
            {
                movimentacoes++;
                array[k++] = arrayEsq[iEsq++];
            }

            while (iDir < nDir)
            {
                movimentacoes++;
                array[k++] = arrayDir[iDir++];
            }
        }

        public static void Exe(int[] array)
        {
            comparacoes = 0;
            movimentacoes = 0;
            var stopwatch = Stopwatch.StartNew();

            Mergesort(array, 0, array.Length - 1);

            stopwatch.Stop();
            long tempo = stopwatch.ElapsedMilliseconds;

            Console.WriteLine(
                $"MergeSort - Movimentações: {movimentacoes}, Comparações: {comparacoes}, Tempo: {tempo} ms");
        }
    }
}