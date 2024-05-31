using System;
using System.IO;

namespace CSharpLista8
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public string Universidade { get; set; }
        public int AnoNasc { get; set; }
        public string CidadeNasc { get; set; }
        public string EstadoNasc { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Altura: {Altura}, Peso: {Peso}, Universidade: {Universidade}, AnoNasc: {AnoNasc}, CidadeNasc: {CidadeNasc}, EstadoNasc: {EstadoNasc}";
        }
    }

    class ProgramJogador
    {
        public static void Exe()
        {
            string filePath = "../../players.csv";
            Jogador[] jogadores = LerJogadores(filePath);

            MergeSort(jogadores, 0, jogadores.Length - 1);

            foreach (Jogador jogador in jogadores)
            {
                Console.WriteLine(jogador);
            }
        }

        static Jogador[] LerJogadores(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            Jogador[] jogadores = new Jogador[lines.Length - 1];

            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                jogadores[i - 1] = new Jogador
                {
                    Id = int.Parse(values[0]),
                    Nome = values[1],
                    Altura = int.Parse(values[2]),
                    Peso = int.Parse(values[3]),
                    Universidade = values[4],
                    AnoNasc = int.Parse(values[5]),
                    CidadeNasc = values.Length > 6 ? values[6] : "",
                    EstadoNasc = values.Length > 7 ? values[7] : ""
                };
            }
            return jogadores;
        }

        static void MergeSort(Jogador[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        static void Merge(Jogador[] array, int left, int middle, int right)
        {
            int leftSize = middle - left + 1;
            int rightSize = right - middle;

            Jogador[] leftArray = new Jogador[leftSize];
            Jogador[] rightArray = new Jogador[rightSize];

            Array.Copy(array, left, leftArray, 0, leftSize);
            Array.Copy(array, middle + 1, rightArray, 0, rightSize);

            int i = 0, j = 0, k = left;

            while (i < leftSize && j < rightSize)
            {
                if (leftArray[i].AnoNasc < rightArray[j].AnoNasc || (leftArray[i].AnoNasc == rightArray[j].AnoNasc && leftArray[i].Nome.CompareTo(rightArray[j].Nome) <= 0))
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < leftSize)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < rightSize)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}