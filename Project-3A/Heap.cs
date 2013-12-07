using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Project_3A
{

    class HeapNode
    {
        private double uygunluk;

        public double Uygunluk
        {
            get { return uygunluk; }
            set { uygunluk = value; }
        }
        private Eleman eleman;

        public Eleman Eleman
        {
            get { return eleman; }
            set { eleman = value; }
        }


        public HeapNode(double key, Eleman e)
        {
            uygunluk = key;

            eleman = e;
        }

        public void setKey(HeapNode nd)
        {
            uygunluk = nd.uygunluk;
            eleman = nd.eleman;


        }
        // -------------------------------------------------------------
    } // end class HeapNode
    ////////////////////////////////////////////////////////////////
    class Heap
    {
        public void kisiyiIlandanCikar(Eleman e)
        {
            HeapNode[] oldHeapArray = (HeapNode[])heapArray.Clone();
            heapArray = new HeapNode[maxSize];

            currentSize = 0;
            foreach (HeapNode item in oldHeapArray)
            {
                if (item!=null &&item.Eleman != e)
                    this.insert(item.Uygunluk, item.Eleman);

            }
        }
        public HeapNode ilaniSistemdenCikar()
        {
            HeapNode node = remove();
            node.Eleman.basvurduguIsIlanlari.Remove(this); return node;
        }
        private string isPozisyonu;

        public string IsPozisyonu
        {
            get { return isPozisyonu; }
            set { isPozisyonu = value; }
        }
        private Sirket sirket;

        public Sirket Sirket
        {
            get { return sirket; }
            set { sirket = value; }
        }
        private HeapNode[] heapArray;
        private int maxSize; // size of array

        public int MaxSize
        {
            get { return maxSize; }
        }
        private int currentSize; // number of HeapNodes in array

        public int CurrentSize
        {
            get { return currentSize; }
        }
        // -------------------------------------------------------------
        public Heap(int mx, Sirket s, string poz) // constructor
        {
            isPozisyonu = poz;
            sirket = s;
            maxSize = mx;
            currentSize = 0;
            heapArray = new HeapNode[maxSize]; // create array
        }
        // -------------------------------------------------------------
        public Boolean isEmpty()
        { return currentSize == 0; }
        // -------------------------------------------------------------
        public Boolean insert(double key, Eleman e)
        {
            if (currentSize == maxSize)
                return false;
            HeapNode newNode = new HeapNode(key, e);
            heapArray[currentSize] = newNode;
            trickleUp(currentSize++);
            return true;
        } // end insert()
        // -------------------------------------------------------------

        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapNode bottom = heapArray[index];
            while (index > 0 &&
           heapArray[parent].Uygunluk < bottom.Uygunluk)
            {
                heapArray[index] = heapArray[parent]; // move it down
                index = parent;
                parent = (parent - 1) / 2;
            } // end while
            heapArray[index] = bottom;
        } // end trickleUp()
        // -------------------------------------------------------------
        public HeapNode remove() // delete item with max key
        { // (assumes non-empty list)
            HeapNode root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            trickleDown(0);
            return root;
        } // end remove()
        // -------------------------------------------------------------
        public void trickleDown(int index)
        {
            int largerChild;
            HeapNode top = heapArray[index]; // save root
            while (index < currentSize / 2) // while HeapNode has at
            { // least one child,
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                // find larger child
                if (rightChild < currentSize && // (rightChild exists?)
                 heapArray[leftChild].Uygunluk <
                heapArray[rightChild].Uygunluk)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                // top >= largerChild?
                if (top.Uygunluk >= heapArray[largerChild].Uygunluk)
                    break;
                // shift child up
                heapArray[index] = heapArray[largerChild];
                index = largerChild; // go down
            } // end while
            heapArray[index] = top; // root to index
        } // end trickleDown()
        // -------------------------------------------------------------
        public Boolean change(int index, HeapNode newValue)
        {
            if (index < 0 || index >= currentSize)
                return false;
            double oldValue = heapArray[index].Uygunluk; // remember old
            heapArray[index].Uygunluk = newValue.Uygunluk;
            heapArray[index].Eleman = newValue.Eleman;// change to new
            if (oldValue < newValue.Uygunluk) // if raised,
                trickleUp(index); // trickle it up
            else // if lowered,
                trickleDown(index); // trickle it down
            return true;
        } // end change()
        // -------------------------------------------------------------
        public void displayHeap()
        {
            //Console.Write("heapArray: "); // array format
            Console.WriteLine(String.Format("{0,-30}{1,-8}", "Kişi Adı", "Uygunluk")); ;
            for (int m = 0; m < currentSize; m++)
                if (heapArray[m] != null)
                    Console.WriteLine(String.Format("{0,-30}{1,-8}", heapArray[m].Eleman.KisiAdi, heapArray[m].Uygunluk));

            Console.WriteLine();
            // heap format
            //int nBlanks = 32;
            //int itemsPerRow = 1;
            //int column = 0;
            //int j = 0; // current item
            //String dots = "...............................";
            //Console.WriteLine(dots + dots); // dotted top line
            //while (currentSize > 0) // for each heap item
            //{
            //    if (column == 0) // first item in row?
            //        for (int k = 0; k < nBlanks; k++) // preceding blanks
            //            Console.Write(" ");
            //    // display item
            //    Console.Write(heapArray[j].Uygunluk + heapArray[j].Eleman.KisiAdi);
            //    if (++j == currentSize) // done?
            //        break;
            //    if (++column == itemsPerRow) // end of row?
            //    {
            //        nBlanks /= 2; // half the blanks
            //        itemsPerRow *= 2; // twice the items
            //        Console.WriteLine(); // new row
            //    }
            //    else // next item on row
            //        for (int k = 0; k < nBlanks * 2 - 2; k++)
            //            Console.Write(" "); // interim blanks
            //} // end for
            //Console.WriteLine("\n" + dots + dots); // dotted bottom line
        } // end displayHeap()
        // -------------------------------------------------------------
    } // end class Heap
    ////////////////////////////////////////////////////////////////
}
