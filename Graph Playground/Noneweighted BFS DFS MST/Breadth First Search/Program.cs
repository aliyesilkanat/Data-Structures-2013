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

            Console.WriteLine();
            Graph theGraph2 = new Graph();
            theGraph2.addVertex('A'); // 0
            theGraph2.addVertex('B'); // 1
            theGraph2.addVertex('C'); // 2
            theGraph2.addVertex('D'); // 3
            theGraph2.addVertex('E'); // 4
            theGraph2.addEdge(0, 1); // AB
            theGraph2.addEdge(0, 2); // AC
            theGraph2.addEdge(0, 3); // AD
            theGraph2.addEdge(0, 4); // AE
            theGraph2.addEdge(1, 2); // BC
            theGraph2.addEdge(1, 3); // BD
            theGraph2.addEdge(1, 4); // BE
            theGraph2.addEdge(2, 3); // CD
            theGraph2.addEdge(2, 4); // CE
            theGraph2.addEdge(3, 4); // DE
            Console.WriteLine("Minimum spanning tree: ");
            theGraph2.mst(); // minimum spanning tree
            Console.WriteLine();

            Console.Read();
        }
    }
}
