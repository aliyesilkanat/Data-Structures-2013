using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2._2
{
    class Program
    {   
        static void Main(string[] args)
        {
            NewMethod();

            Console.ReadLine();
        }

        private static void NewMethod()
        {
            Stack<string> a;
            Stack<int> s = new Stack<int>();
            s.Push(29);
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
        }
    }
}
