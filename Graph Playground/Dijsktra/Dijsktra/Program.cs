using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijsktra
{
    class Program
    {
        static int INFINITY = 1000;

        static void Main(string[] args)
        {
            int N = 5;

            // int[][] cost	= new int[N][N];

            int[,] cost = {
   	{ 1000,    5,    3, 1000,    2},
   	{ 1000, 1000,    2,    6, 1000},
   	{ 1000,    1, 1000,    2, 1000},
   	{ 1000, 1000, 1000, 1000, 1000},
   	{ 1000,    6,   10,    4,    8}  };

            int[] distances = new int[N];

            Distance(N, cost, distances);

            for (int i = 0; i < distances.Length; ++i)
                Console.WriteLine(distances[i]);

            Console.Read();
        }
        public static void Distance(int N, int[,] cost, int[] D)
        {

            int w, v, min;

            bool[] visited = new bool[N];

            D[0] = 0;
            for (v = 1; v < N; v++)
            {
                visited[v] = false;
                D[v] = cost[0, v];
            };

            for (int i = 1; i < N; ++i)
            {
                min = INFINITY;
                for (w = 1; w < N; w++)
                    if (!visited[w])
                        if (D[w] < min)
                        {
                            v = w;
                            min = D[w];
                        }

                visited[v] = true;

                for (w = 1; w < N; w++)
                    if (!visited[w])
                        if (min + cost[v, w] < D[w])
                            D[w] = min + cost[v, w];
            }

        }
    }




}
