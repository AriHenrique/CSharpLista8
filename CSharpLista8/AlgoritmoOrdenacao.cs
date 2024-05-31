using System;
using System.Diagnostics;

namespace CSharpLista8
{
    
    public class AlgoritmoOrdenacaoSimples
    {
        public long Movimentacoes { get; private set; }
        public long Comparacoes { get; private set; }
        public long Tempo { get; private set; }

        public void ExecutarOrdenacao(int[] array, Action<int[], Action<int>, Action<int>> ordenar)
        {
            Stopwatch stopwatch = new Stopwatch();
            Movimentacoes = 0;
            Comparacoes = 0;

            Action<int> incrementarComparacoes = (x) => Comparacoes += x;
            Action<int> incrementarMovimentacoes = (x) => Movimentacoes += x;

            stopwatch.Start();
            ordenar(array, incrementarComparacoes, incrementarMovimentacoes);
            stopwatch.Stop();

            Tempo = stopwatch.ElapsedMilliseconds;
        }

        public void ImprimirResultados(string nomeAlgoritmo)
        {
            Console.WriteLine($"{nomeAlgoritmo} - Movimentações: {Movimentacoes}, Comparacoes: {Comparacoes}, Tempo: {Tempo} ms");
        }
    }
    
}