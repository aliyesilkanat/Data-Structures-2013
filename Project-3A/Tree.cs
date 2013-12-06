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
        public void displayNode() { Console.Write(" " + eleman.KisiAdi+ " "); }
    }

    // Agaç Sınıfı
    class Tree
    {
        private TreeNode root;
        public int sayi;
        public int düzey;

        public Tree() { root = null; }

        public TreeNode getRoot()
        { return root; }

        // Agacın preOrder Dolasılması
        public void preOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                localRoot.displayNode();
                preOrder(localRoot.leftChild);
                preOrder(localRoot.rightChild);
            }
        }

        // Agacın inOrder Dolasılması
        public void inOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.leftChild);
                localRoot.displayNode();
                inOrder(localRoot.rightChild);
            }
        }

        // Agacın postOrder Dolasılması
        public void postOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.leftChild);
                postOrder(localRoot.rightChild);
                localRoot.displayNode();
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
                    if (newEleman.KisiAdi.CompareTo( current.eleman.KisiAdi)<0)
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
                düzey = düzey + 1;
                düzeyListele2(etkin.leftChild);
                Console.WriteLine(" " + etkin.eleman + " " + düzey + ". düzeyde");
                düzeyListele2(etkin.rightChild);
                düzey = düzey - 1;
            }
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
