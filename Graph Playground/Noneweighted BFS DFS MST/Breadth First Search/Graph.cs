using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breadth_First_Search
{
    class Vertex
    {
        public char label; // label (e.g. ‘A’)
        public bool wasVisited;
        // -------------------------------------------------------------
        public Vertex(char lab) // constructor
        {
            label = lab;
            wasVisited = false;
        }
        // -------------------------------------------------------------
    } // end class Vertex
    ////////////////////////////////////////////////////////////////
    class Graph
    {
        private static int MAX_VERTS = 20;
        private Vertex[] vertexList; // list of vertices
        private int[,] adjMat; // adjacency matrix
        private int nVerts; // current number of vertices
        private Queue<int> theQueue;
        private Stack<int> theStack;
        // ------------------
        public Graph() // constructor
        {
            vertexList = new Vertex[MAX_VERTS];
            // adjacency matrix
            adjMat = new int[MAX_VERTS, MAX_VERTS];
            nVerts = 0;
            for (int j = 0; j < MAX_VERTS; j++) // set adjacency
                for (int k = 0; k < MAX_VERTS; k++) // matrix to 0
                    adjMat[j, k] = 0;
            theQueue = new Queue<int>();
            theStack = new Stack<int>();
        } // end constructor// -------------------------------------------------------------
        public void addVertex(char lab)
        {
            vertexList[nVerts++] = new Vertex(lab);
        }
        // -------------------------------------------------------------
        public void addEdge(int start, int end)
        {
            adjMat[start, end] = 1;
            adjMat[end, start] = 1;
        }
        // -------------------------------------------------------------
        public void displayVertex(int v)
        {
            Console.Write(vertexList[v].label);
        }
        // -------------------------------------------------------------
        public void bfs() // breadth-first search
        { // begin at vertex 0
            vertexList[0].wasVisited = true; // mark it
            displayVertex(0); // display it
            theQueue.Enqueue(0); // insert at tail
            int v2;
            while (theQueue.Count > 0) // until queue empty,
            {
                int v1 = theQueue.Dequeue(); // remove vertex at head
                // until it has no unvisited neighbors
                while ((v2 = getAdjUnvisitedVertex(v1)) != -1)
                { // get one,
                    vertexList[v2].wasVisited = true; // mark it
                    displayVertex(v2); // display it
                    theQueue.Enqueue(v2); // insert it
                } // end while
            } // end while(queue not empty)
            // queue is empty, so we’re done
            for (int j = 0; j < nVerts; j++) // reset flags
                vertexList[j].wasVisited = false;
        } // end bfs()
        public void dfs() // depth-first search
        { // begin at vertex 0
            vertexList[0].wasVisited = true; // mark it
            displayVertex(0); // display it
            theStack.Push(0); // push it
            while (theStack.Count != 0) // until stack empty,
            {
                // get an unvisited vertex adjacent to stack top
                int v = getAdjUnvisitedVertex(theStack.Peek());
                if (v == -1) // if no such vertex,
                    theStack.Pop();
                else // if it exists,
                {
                    vertexList[v].wasVisited = true; // mark it
                    displayVertex(v); // display it
                    theStack.Push(v); // push it
                }
            } // end while
            // stack is empty, so we’re done
            for (int j = 0; j < nVerts; j++) // reset flags
                vertexList[j].wasVisited = false;
        } // end dfs
        // ------------------------------------------------------------
        // returns an unvisited vertex adj to v
        // -------------------------------------------------------------// returns an unvisited vertex adj to v

        public void mst() // minimum spanning tree (depth first)
        { // start at 0
            vertexList[0].wasVisited = true; // mark it
            theStack.Push(0); // push it
            while (theStack.Count > 0) // until stack empty
            { // get stack top
                int currentVertex = theStack.Peek();
                // get next unvisited neighbor
                int v = getAdjUnvisitedVertex(currentVertex);
                if (v == -1) // if no more neighbors
                    theStack.Pop(); // pop it away
                else // got a neighbor
                {
                    vertexList[v].wasVisited = true; // mark it
                    theStack.Push(v); // push it
                    // display edge
                    displayVertex(currentVertex); // from currentV
                    displayVertex(v); // to v
                    Console.Write(" ");
                }
            } // end while(stack not empty)
            // stack is empty, so we’re done
            for (int j = 0; j < nVerts; j++) // reset flags
                vertexList[j].wasVisited = false;
        } // end tree
        // -------------------------------------------------------------
        public int getAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < nVerts; j++)
                if (adjMat[v, j] == 1 && vertexList[j].wasVisited == false)
                    return j;
            return -1;
        } // end getAdjUnvisitedVertex()
        // -------------------------------------------------------------
    } // end class Graph
    ////////////////////////////////////////////////////////////////
}

