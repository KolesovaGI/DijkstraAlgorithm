using System;
using System.IO;

namespace DijkstraAlgorythm
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "E:/DijkstraAlgorythm/DijkstraAlgorythm/input.txt";
            using (StreamReader sr = new StreamReader(text))
            {
                string line = sr.ReadLine();
                int size = int.Parse(line);     //количество вершин
                var smeg = new int[size, size]; //матрица смежности
                var cost = new int[size, size]; //матрица стоимости

                FileManager.Set(size, smeg, cost);    //метод заполнения матриц

                FileManager.Get(line, sr, smeg, cost);//метод считывания из файла

                //Вывод матриц
                Console.WriteLine("Матрица смежности графа");
                FileManager.PrintArray(smeg);
                Console.WriteLine("Матрица стоимости графа");
                FileManager.PrintArray(cost);
                Console.WriteLine();

                //Ввод начальной вершины
                Console.Write("Введите начальную вершину: ");
                int st = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Алгоритм Дейкстры
                Dijkstra.Deijkstra(cost, st - 1, size);
            }
        }
    }
}
