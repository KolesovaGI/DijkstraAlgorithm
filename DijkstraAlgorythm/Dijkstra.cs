using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorythm
{
    class Dijkstra
    {
        /// <summary>
        /// Алгоритм Дейкстры
        /// </summary>
        public static void Deijkstra(int[,] cost, int st, int size)
        {
            int[] distance = new int[size]; //массив стоимости
            bool[] visited = new bool[size]; //массив для посещенной вершины

            for (int i = 0; i < size; i++)
            {
                distance[i] = cost[st, i]; //заполняем макс. числом
                visited[i] = false; //пока вершина не посещена
            }

            Console.WriteLine();
            int u = 0;
            distance[st] = 0;

            for (int j = 0; j < size - 1; j++)
            {
                visited[u] = true; //вершина посещена
                u = MinimumDistance(distance, visited, size);

                //Нахождение кратчайшего пути
                for (int i = 0; i < size; i++)
                {
                    if (!visited[i] && cost[u, i] != Int32.MaxValue && distance[u] + cost[u, i] < distance[i])
                    {
                        distance[i] = distance[u] + cost[u, i];
                    }
                }
            }

            PrintDijkstra(distance, size, st + 1);
        }

        /// <summary>
        /// Нахождение минимальной стоимости
        /// </summary>
        /// <returns></returns>
        private static int MinimumDistance(int[] distance, bool[] visited, int size)
        {
            int min = Int32.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < size; i++)
            {
                if (!visited[i] && distance[i] <= min) //пока вершина не посещена и стоимость меньшье либо равна "максимальному" числу
                {
                    min = distance[i]; //присваиваем эту стоимость
                    minIndex = i; //сохраняем индекс вершины
                }
            }
            return minIndex;
        }

        /// <summary>
        /// Вывод алгоритма Дейкстры
        /// </summary>
        private static void PrintDijkstra(int[] distance, int size, int st)
        {
            Console.WriteLine("Стоимость пути из начальной вершины до остальных:\t\n");

            for (int i = 0; i < size; i++)
            {
                if (distance[i] != Int32.MaxValue)
                {
                    Console.WriteLine(st + " > " + (i + 1) + " = " + distance[i] + "\n");
                }
                else Console.WriteLine(st + " > " + (i + 1) + " = маршрут недоступен\n");
            }
        }
    }
}
