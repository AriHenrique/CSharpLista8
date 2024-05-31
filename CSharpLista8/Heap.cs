using System;
using System.Diagnostics;

class Heap
{
    public static long comparacoes;
    public static long movimentacoes;

    static void Heapsort(int[] array, int n)
    {
        comparacoes = 0;
        movimentacoes = 0;

        for (int ultimo = 1; ultimo < n; ultimo++)
        {
            Construir(array, ultimo);
        }

        for (int ultimo = n - 1; ultimo > 0; ultimo--)
        {
            Trocar(array, 0, ultimo);
            Reconstruir(array, ultimo);
        }
    }

    static void Construir(int[] array, int ultimo)
    {
        for (int i = ultimo; i > 0; i = (i - 1) / 2)
        {
            comparacoes++;
            if (array[i] > array[(i - 1) / 2])
            {
                Trocar(array, i, (i - 1) / 2);
            }
        }
    }

    static void Reconstruir(int[] array, int tamHeap)
    {
        int i = 0;
        while (HasFilho(i, tamHeap))
        {
            int filho = GetMaiorFilho(array, i, tamHeap);
            comparacoes++;
            if (array[i] < array[filho])
            {
                Trocar(array, i, filho);
                i = filho;
            }
            else
            {
                break;
            }
        }
    }

    static bool HasFilho(int i, int tamHeap)
    {
        return 2 * i + 1 < tamHeap;
    }

    static void Trocar(int[] array, int i, int j)
    {
        movimentacoes += 3;
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static int GetMaiorFilho(int[] array, int i, int tamHeap)
    {
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        comparacoes++;
        if (right >= tamHeap || array[left] > array[right])
        {
            return left;
        }
        else
        {
            return right;
        }
    }

    public static void Exe(int[] array)
    {
        var stopwatch = Stopwatch.StartNew();

        Heapsort(array, array.Length);

        stopwatch.Stop();
        long tempo = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"HeapSort - Movimentações: {movimentacoes}, Comparações: {comparacoes}, Tempo: {tempo} ms");
    }
}