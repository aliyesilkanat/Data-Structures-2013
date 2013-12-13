using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breadth_First_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph theGraph = new Graph();
            theGraph.addVertex('A'); // 0
            theGraph.addVertex('B'); // 1
            theGraph.addVertex('C'); // 2
            theGraph.addVertex('D'); // 3
            theGraph.addVertex('E'); // 4
            theGraph.addEdge(0, 1); // AB
            theGraph.addEdge(1, 2); // BC
            theGraph.addEdge(0, 3); // AD
            theGraph.addEdge(3, 4); // DE
            Console.WriteLine("Breadth-First Search Visits: ");
            theGraph.bfs(); // breadth-first search
            Console.WriteLine();

            Console.WriteLine("Depth First Search Visits: ");
            theGraph.dfs(); // depth-first search
            Console.Read();
        }
    }
}
