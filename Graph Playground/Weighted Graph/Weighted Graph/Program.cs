using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weighted_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph theGraph = new Graph();
           
            theGraph.addVertex('A'); // 0 (start for mst)
            theGraph.addVertex('B'); // 1
            theGraph.addVertex('C'); // 2
            theGraph.addVertex('D'); // 3
            theGraph.addVertex('E'); // 4
            theGraph.addVertex('F'); // 5
            theGraph.addEdge(0, 1, 6); // AB 6
            theGraph.addEdge(0, 3, 4); // AD 4
            theGraph.addEdge(1, 2, 10); // BC 10
            theGraph.addEdge(1, 3, 7); // BD 7
            theGraph.addEdge(1, 4, 7); // BE 7
            theGraph.addEdge(2, 3, 8); // CD 8
            theGraph.addEdge(2, 4, 5); // CE 5
            theGraph.addEdge(2, 5, 6); // CF 6
            theGraph.addEdge(3, 4, 12); // DE 12
            theGraph.addEdge(4, 5, 7); // EF 7
            Console.Write("Minimum spanning tree: ");
            theGraph.mstw(); // minimum spanning tree
            Console.WriteLine();
            Console.Read();
        }
    }
}
