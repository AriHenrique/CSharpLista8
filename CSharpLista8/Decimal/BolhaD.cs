﻿using System;
using System.Diagnostics;

namespace CSharpLista8
{
    public class BolhaD
    {
        public static long movi;
        public static long comp;
        static void Init(double[] array)
        {
            double temp;
            int n = array.Length;
            for (int i = 0; i < n - 1; i++) {
                for (int j = n - 1; j > i; j--)
                {
                    comp++;
                    if (array[j] < array[j - 1])
                    {
                        movi++;
                        temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                }
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
                $"Bolha Double - Movimentações: {movi}, Comparações: {comp}, Tempo: {tempo} ms");
        }
    }
}