using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_4A
{

    class Edge
    {
        public int srcVert; // index of a vertex starting edge
        public int destVert; // index of a vertex ending edge
        public int distance; // distance from src to dest
        // -------------------------------------------------------------
        public Edge(int sv, int dv, int d) // constructor
        {
            srcVert = sv;
            destVert = dv;
            distance = d;
        }
        // -------------------------------------------------------------
    } // end class Edge
    ////////////////////////////////////////////////////////////////
    class PriorityQ
    {
        // array in sorted order, from max at 0 to min at size-1
        private static int SIZE = 20;
        private Edge[] queArray;
        private int size;
        // -------------------------------------------------------------
        public PriorityQ() // constructor
        {
            queArray = new Edge[SIZE];
            size = 0;
        }
        // -------------------------------------------------------------
        public void insert(Edge item) // insert item in sorted order
        {
            int j;
            for (j = 0; j < size; j++) // find place to insert
                if (item.distance >= queArray[j].distance)
                    break;
            for (int k = size - 1; k >= j; k--) // move items up
                queArray[k + 1] = queArray[k];
            queArray[j] = item; // insert item
            size++;
        }
        // -------------------------------------------------------------
        public Edge removeMin() // remove minimum item
        { return queArray[--size]; }
        // -------------------------------------------------------------
        public void removeN(int n) // remove item at n
        {
            for (int j = n; j < size - 1; j++) // move items down
                queArray[j] = queArray[j + 1];
            size--;
        }
        // -------------------------------------------------------------
        public Edge peekMin() // peek at minimum item
        { return queArray[size - 1]; }
        // -------------------------------------------------------------
        public int Size() // return number of items
        { return size; }
        // -------------------------------------------------------------
        public bool isEmpty() // true if queue is empty
        { return (size == 0); }
        // -------------------------------------------------------------
        public Edge peekN(int n) // peek at item n
        { return queArray[n]; }
        // -------------------------------------------------------------
        public int find(int findDex) // find item with specified
        { // destVert value
            for (int j = 0; j < size; j++)
                if (queArray[j].destVert == findDex)
                    return j;
            return -1;
        }
        // -------------------------------------------------------------
    } // end class PriorityQ
    ////////////////////////////////////////////////////////////////
    public class Vertex
    {
        public char label; // label (e.g. ‘A’)
        public bool isInTree;
        // -------------------------------------------------------------
        public Vertex(char lab) // constructor
        {
            label = lab;
            isInTree = false;
        }
        // -------------------------------------------------------------
    } // end class Vertex
    ////////////////////////////////////////////////////////////////
    public class Graph
    {
        private static int MAX_VERTS = 6;
        private static int INFINITY = 1000000;
        public Vertex[] vertexList; // list of vertices
        public int[,] adjMat; // adjacency matrix
        private int nVerts; // current number of vertices
        private int currentVert;
        private PriorityQ thePQ;
        private int nTree; // number of verts in tree
        // -------------------------------------------------------------
        public Graph() // constructor
        {
            vertexList = new Vertex[MAX_VERTS];
            // adjacency matrix
            adjMat = new int[MAX_VERTS, MAX_VERTS];
            nVerts = 0;
            for (int j = 0; j < MAX_VERTS; j++) // set adjacency
                for (int k = 0; k < MAX_VERTS; k++) // matrix to 0
                    adjMat[j, k] = INFINITY;
            thePQ = new PriorityQ();
        } // end constructor
        // -------------------------------------------------------------
        public void addVertex(char lab)
        {
            vertexList[nVerts++] = new Vertex(lab);
        }
        // -------------------------------------------------------------
        public void addEdge(int start, int end, int weight)
        {
            adjMat[start, end] = weight;
            adjMat[end, start] = weight;
        }
        // -------------------------------------------------------------
        public void displayVertex(int v)
        {
            Console.Write(vertexList[v].label);
        }
        // -------------------------------------------------------------
        public void mstw() // minimum spanning tree
        {
            currentVert = 0; // start at 0
            while (nTree < nVerts - 1) // while not all verts in tree
            { // put currentVert in tree
                vertexList[currentVert].isInTree = true;
                nTree++;
                // insert edges adjacent to currentVert into PQ
                for (int j = 0; j < nVerts; j++) // for each vertex,
                {
                    if (j == currentVert) // skip if it’s us
                        continue;
                    if (vertexList[j].isInTree) // skip if in the tree
                        continue;
                    int distance = adjMat[currentVert, j];
                    if (distance == INFINITY) // skip if no edge
                        continue;
                    putInPQ(j, distance); // put it in PQ (maybe)
                }
                if (thePQ.Size() == 0) // no vertices in PQ?
                {
                    Console.WriteLine(" GRAPH NOT CONNECTED");
                    return;
                }
                // remove edge with minimum distance, from PQ
                Edge theEdge = thePQ.removeMin();
                int sourceVert = theEdge.srcVert;
                currentVert = theEdge.destVert;
                // display edge from source to current
                Console.Write(vertexList[sourceVert].label);
                Console.Write(vertexList[currentVert].label);
                Console.Write(" ");
            } // end while(not all verts in tree)
            // mst is complete
            for (int j = 0; j < nVerts; j++) // unmark vertices
                vertexList[j].isInTree = false;
        } // end mstw



        // -------------------------------------------------------------
        public void putInPQ(int newVert, int newDist)
        {
            // is there another edge with the same destination vertex?
            int queueIndex = thePQ.find(newVert);
            if (queueIndex != -1) // got edge’s index
            {
                Edge tempEdge = thePQ.peekN(queueIndex); // get edge
                int oldDist = tempEdge.distance;
                if (oldDist > newDist) // if new edge shorter,
                {
                    thePQ.removeN(queueIndex); // remove old edge
                    Edge theEdge =
                    new Edge(currentVert, newVert, newDist);
                    thePQ.insert(theEdge); // insert new edge
                }
                // else no action; just leave the old vertex there
            } // end if
            else // no edge with same destination vertex
            { // so insert new one
                Edge theEdge = new Edge(currentVert, newVert, newDist);
                thePQ.insert(theEdge);
            }
        } // end putInPQ()
        // -------------------------------------------------------------
    } // end class Graph
    ////////////////////////////////////////////////////////////////

}

