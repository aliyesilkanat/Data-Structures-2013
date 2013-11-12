using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularList cl = new CircularList();
            cl.insertBegin("arba");
            cl.insertEnd("asdasda");
            cl.insertEnd("son");
            cl.yazdir();
            cl.Atla(3);
            Console.Read();
        }
    }
}
