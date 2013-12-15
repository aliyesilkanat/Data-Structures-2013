using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing;

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
        public bool wasVisited;
        public string label; // label (e.g. ‘A’)
        public bool isInTree;
        // -------------------------------------------------------------
        public Vertex(string lab) // constructor
        {
            wasVisited = false;
            label = lab;
            isInTree = false;
        }
        // -------------------------------------------------------------
    } // end class Vertex
    ////////////////////////////////////////////////////////////////
    public class Graph
    {
        private int MAX_VERTS = 6;
        private static int INFINITY = 1000000;
        public Vertex[] vertexList; // list of vertices
        public int[,] adjMat; // adjacency matrix
        private int nVerts; // current number of vertices
        private int currentVert;
        public DistPar[] sPath; // array for shortest-path data
        private PriorityQ thePQ;
        private Queue<int> theQueue;
        private int nTree; // number of verts in tree
        private int startToCurrent; // distance to currentVert
        // -------------------------------------------------------------
        public Graph(int max) // constructor
        {
            MAX_VERTS = max;
            vertexList = new Vertex[MAX_VERTS];
            // adjacency matrix
            adjMat = new int[MAX_VERTS, MAX_VERTS];
            nVerts = 0;
            for (int j = 0; j < MAX_VERTS; j++) // set adjacency
                for (int k = 0; k < MAX_VERTS; k++) // matrix to 0
                    adjMat[j, k] = INFINITY;
            thePQ = new PriorityQ();
            theQueue = new Queue<int>();
            sPath = new DistPar[MAX_VERTS]; // shortest paths
        } // end constructor
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
            theQueue = new Queue<int>();
            sPath = new DistPar[MAX_VERTS]; // shortest paths
        } // end constructor
        // -------------------------------------------------------------
        public void addVertex(string lab)
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
        public void mstw(int[,] mstAdjMat) // minimum spanning tree
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
                mstAdjMat[sourceVert, currentVert] = this.adjMat[sourceVert, currentVert];
                mstAdjMat[currentVert, sourceVert] = this.adjMat[currentVert, sourceVert];
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
        public void bfs( List<int> visitedVertices,int first) // breadth-first search
        { // begin at vertex 0
           

            vertexList[first].wasVisited = true; // mark it
            //displayVertex(0); // display it
            visitedVertices.Add(first);
            theQueue.Enqueue(first); // insert at tail
            int v2;
            while (theQueue.Count > 0) // until queue empty,
            {
                int v1 = theQueue.Dequeue(); // remove vertex at head
                // until it has no unvisited neighbors
                while ((v2 = getAdjUnvisitedVertex(v1)) != -1)
                { // get one,
                    vertexList[v2].wasVisited = true; // mark it
                    //displayVertex(v2); // display it
                    visitedVertices.Add(v2);
                    theQueue.Enqueue(v2); // insert it
                } // end while
            } // end while(queue not empty)
            // queue is empty, so we’re done
            for (int j = 0; j < nVerts; j++) // reset flags
                vertexList[j].wasVisited = false;
        } // end bfs()
        public int getAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < nVerts; j++)
                if (adjMat[v, j] != INFINITY && vertexList[j].wasVisited == false)
                    return j;
            return -1;
        } // end getAdjUnvisitedVertex()
        // -------------------------------------------------------------
        public void path(int first) // find all shortest paths
        {
            int startTree = first; // start at vertex 0
            vertexList[startTree].isInTree = true;
            nTree = 1; // put it in tree
            // transfer row of distances from adjMat to sPath
            for (int j = 0; j < nVerts; j++)
            {
                int tempDist = adjMat[startTree, j];
                sPath[j] = new DistPar(startTree, tempDist);
            }
            // until all vertices are in the tree
            while (nTree < nVerts)
            {
                int indexMin = getMin(first); // get minimum from sPath
                int minDist = sPath[indexMin].distance;
                if (minDist == INFINITY) // if all infinite
                { // or in tree,
                    Console.WriteLine("There are unreachable vertices");
                    break; // sPath is complete
                }
                else
                { // reset currentVert
                    currentVert = indexMin; // to closest vert
                    startToCurrent = sPath[indexMin].distance;
                    // minimum distance from startTree is
                    // to currentVert, and is startToCurrent
                }
                // put current vertex in tree
                vertexList[currentVert].isInTree = true;
                nTree++;
                adjust_sPath(); // update sPath[] array
            } // end while(nTree<nVerts)
            displayPaths(); // display sPath[] contents
            nTree = 0; // clear tree
            for (int j = 0; j < nVerts; j++)
                vertexList[j].isInTree = false;
        } // end path()
        // -------------------------------------------------------------
        public int getMin(int first) // get entry from sPath
        { // with minimum distance
            int minDist = INFINITY; // assume minimum
            int indexMin = first;
            for (int j = 0; j < nVerts; j++) // for each vertex,
            { // if it’s in tree and
                if (j != first) 
                if (!vertexList[j].isInTree && // smaller than old one
            sPath[j].distance < minDist)
                {
                    minDist = sPath[j].distance;
                    indexMin = j; // update minimum
                }
            } // end for
            return indexMin; // return index of minimum
        } // end getMin()
        // -------------------------------------------------------------
        public void adjust_sPath()
        {
            // adjust values in shortest-path array sPath
            int column = 0; // skip starting vertex
            while (column < nVerts) // go across columns
            {
                // if this column’s vertex already in tree, skip it
                if (vertexList[column].isInTree)
                {
                    column++;
                    continue;
                }
                // calculate distance for one sPath entry
                // get edge from currentVert to column
                int currentToFringe = adjMat[currentVert, column];
                // add distance from start
                int startToFringe = startToCurrent + currentToFringe;
                // get distance of current sPath entry
                int sPathDist = sPath[column].distance;
                // compare distance from start with sPath entry
                if (startToFringe < sPathDist) // if shorter,
                { // update sPath
                    sPath[column].parentVert = currentVert;
                    sPath[column].distance = startToFringe;
                }
                column++;
            } // end while(column < nVerts)
        } // end adjust_sPath()
        // -------------------------------------------------------------
        public void displayPaths()
        {
            for (int j = 0; j < nVerts; j++) // display contents of sPath[]
            {
                Console.Write(vertexList[j].label + "="); // B=
                if (sPath[j].distance == INFINITY)
                    Console.Write("inf"); // inf
                else
                    Console.Write(sPath[j].distance); // 50
                string parent = vertexList[sPath[j].parentVert].label;
                Console.Write(" (" + parent + ") "); // (A)
            }
            Console.WriteLine();
        }
        // -------------------------------------------------------------

    } // end class Graph
    public class DistPar // distance and parent
    { // items stored in sPath array
        public int distance; // distance from start to this vertex
        public int parentVert; // current parent of this vertex
        // -------------------------------------------------------------
        public DistPar(int pv, int d) // constructor
        {
            distance = d;
            parentVert = pv;
        }
    } // end class DistPar
    ////////////////////////////////////////////////////////////////

}

