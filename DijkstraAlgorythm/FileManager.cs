using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DijkstraAlgorythm
{
    class FileManager
    {
        /// <summary>
        /// Считывание из файла 
        /// </summary>
        public static void Get(string line, StreamReader sr, int[,] smeg, int[,] cost)
        {
            string[] words; //массив строк
            int v; //вершина графа откуда дуга
            int w; //вершина графа куда входит дуга
            int c; //стоимость дуги

            while ((line = sr.ReadLine()) != null)
            {
                words = line.Split(' ');
                v = int.Parse(words[0]);
                w = int.Parse(words[1]);
                c = int.Parse(words[2]);
                smeg[v - 1, w - 1] = 1;
                cost[v - 1, w - 1] = c;
            }
        }

        /// <summary>
        /// Заполнение матриц нулями и бесконечностью
        /// </summary>
        public static void Set(int size, int[,] smeg, int[,] cost)
        {
            //заполнение матриц
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    smeg[i, j] = 0; //матрицу смежности - нулями
                    cost[i, j] = Int32.MaxValue; //стоимости - максимальным числом
                }
            }
        }

        /// <summary>
        /// Вывод массивов
        /// </summary>
        public static void PrintArray(int[,] arr)
        {
            int size = arr.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
