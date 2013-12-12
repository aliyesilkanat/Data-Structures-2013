using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_3A
{
    class TreeNode
    {
        public Eleman eleman;
        public TreeNode leftChild;
        public TreeNode rightChild;
        public void displayNode() { Console.Write(eleman.KisiAdi); }
    }

    // Agaç Sınıfı
    class Tree
    {
        private TreeNode root;
        public int duzey;
        public int toplamDugum;
        public int maxDerin;
        public Tree() { root = null; }

        public TreeNode getRoot()
        { return root; }
        public void derinlikVeDugumSayisi(TreeNode etkin)
        {
            if (etkin != null)
            {
                toplamDugum++;
                duzey++;
                if (duzey > maxDerin)
                    maxDerin = duzey;
                derinlikVeDugumSayisi(etkin.leftChild);
                derinlikVeDugumSayisi(etkin.rightChild);
                duzey--;
            }
            if (etkin == getRoot())
            {
                Console.WriteLine("Ağacın derinliği: " + maxDerin);
                Console.WriteLine("Ağaçtaki eleman sayısı: " + toplamDugum);
            }
        }
        public void notOrt90Uzeri(TreeNode etkin)
        {
            if (etkin != null)
            {
                notOrt90Uzeri(etkin.leftChild);
                foreach (EgitimDurumu egt in etkin.eleman.egitimler)
                {
                    if (egt.NotOrtalamasi > 90)
                    {
                        Console.WriteLine(etkin.eleman.KisiAdi);
                        break;
                    }
                }
                notOrt90Uzeri(etkin.rightChild);
            }
        }
        public void ingilizceBilenler(TreeNode etkin)
        {
            if (etkin != null)
            {
                ingilizceBilenler(etkin.leftChild);
                if (etkin.eleman.YabanciDil == "İngilizce")
                    Console.WriteLine(etkin.eleman.KisiAdi);
                ingilizceBilenler(etkin.rightChild);
            }
        }
        public TreeNode ara(TreeNode localRoot, string kisi)
        {     // find node with given key
            {                           // (assumes non-empty tree)
                TreeNode current = root;
                // start at root
                while (current.eleman.KisiAdi != kisi)        // while no match,
                {
                    if (kisi.CompareTo(current.eleman.KisiAdi) < 0)         // go left?
                        current = current.leftChild;
                    else                            // or go right?
                        current = current.rightChild;
                    if (current == null)             // if no child,
                        return null;                 // didn't find it
                }
                return current;                    // found it
            }  // end find() 
        }
        // Agacın preOrder Dolasılması
        public void preOrder(TreeNode localRoot, int d)
        {
            if (localRoot != null)
            {
                d = d + 1;
                localRoot.displayNode();
                Console.WriteLine(" Düzey: " + d);
                preOrder(localRoot.leftChild, d);
                preOrder(localRoot.rightChild, d);
            }
        }

        // Agacın inOrder Dolasılması
        public void inOrder(TreeNode localRoot, int d)
        {
            if (localRoot != null)
            {
                d = d + 1;
                inOrder(localRoot.leftChild, d);
                localRoot.displayNode();
                Console.WriteLine(" Düzey: " + d);
                inOrder(localRoot.rightChild, d);
            }
        }

        // Agacın postOrder Dolasılması
        public void postOrder(TreeNode localRoot, int d)
        {
            if (localRoot != null)
            {
                d++;
                postOrder(localRoot.leftChild, d);
                postOrder(localRoot.rightChild, d);
                localRoot.displayNode();
                Console.WriteLine(" Düzey: " + d);
            }
        }

        // Agaca bir dügüm eklemeyi saglayan metot
        public void insert(Eleman newEleman)
        {
            TreeNode newNode = new TreeNode();
            newNode.eleman = newEleman;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (newEleman.KisiAdi.CompareTo(current.eleman.KisiAdi) < 0)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } // end while
            } // end else not root
        } // end insert()

        public void düzeyListele(TreeNode etkin, int d)
        {
            if (etkin != null)
            {
                d = d + 1;
                düzeyListele(etkin.leftChild, d);
                Console.WriteLine(" " + etkin.eleman + " " + d + ". düzeyde");
                düzeyListele(etkin.rightChild, d);
            }
        }

        public void düzeyListele2(TreeNode etkin)
        {
            if (etkin != null)
            {
                duzey = duzey + 1;
                düzeyListele2(etkin.leftChild);
                Console.WriteLine(" " + etkin.eleman + " " + duzey + ". düzeyde");
                düzeyListele2(etkin.rightChild);
                duzey = duzey - 1;
            }
        }

        public bool delete(string key)
        {
            TreeNode current = root;
            TreeNode parent = root;
            bool isleftChild = true;

            while (current.eleman.KisiAdi != key)
            {
                parent = current;
                if (key.CompareTo(current.eleman.KisiAdi) < 0) //go left
                {
                    isleftChild = true;
                    current = current.leftChild;

                }
                else
                { // go right
                    isleftChild = false;
                    current = current.rightChild;
                }
                if (current == null)
                    return false;
            }


            //if no children
            if (current.leftChild == null && current.rightChild == null)
            {
                if (current == root)
                    root = null; //tree is empty
                else if (isleftChild)
                    parent.leftChild = null;
                else
                    parent.rightChild = null;
            }

            //if no right child, replace with left subtree
            else if (current.rightChild == null)
                if (current == root)
                    root = current.leftChild;
                else if (isleftChild) //left child of parent
                    parent.leftChild = current.leftChild;
                else //right child of parent
                    parent.rightChild = current.leftChild;

            //if no left child,replace with right subtree
            else if (current.leftChild == null)
                if (current == null)
                    root = current.rightChild;
                else if (isleftChild)
                    parent.leftChild = current.rightChild;
                else
                    parent.rightChild = current.rightChild;

            else //two children, so replace with inorder successor
            {
                //getSuccessor of node to delete(current)
                TreeNode successor = getSuccessor(current);

                //connect parent of current to successor instead
                if (current == root)
                    root = successor;
                else if (isleftChild)
                    parent.leftChild = successor;
                else
                    parent.rightChild = successor;
                //connect successor to current's left child
                successor.leftChild = current.leftChild;
            }
            //(successor cannot have a left child)
            return true;
        }

        //returns node with next highest value after delNode
        //goes to right child, then right child's left descendants
        private TreeNode getSuccessor(TreeNode delNode)
        {
            TreeNode successorParent = delNode;
            TreeNode successor = delNode;
            TreeNode current = delNode.rightChild; //go to right child

            while (current != null) //until no more
            {                       //left child
                successorParent = successor;
                successor = current;
                current = current.leftChild;
            }

            if (successor != delNode.rightChild)
            {
                successorParent.leftChild = successor.rightChild;
                successor.rightChild = delNode.rightChild;
            }
            return successor;
        }

    } // class Tree
}
