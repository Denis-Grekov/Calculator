using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 0, 1, 2, 3, 4 };
            Stack<int> stack = new Stack<int>(numbers);
            foreach (var newNum in stack) Console.WriteLine(newNum);
            stack.Push(6);
            Console.WriteLine(stack.Count);

            bool cont = stack.Contains(7);
            Console.WriteLine(cont);

            int headNum = stack.Peek();
            Console.WriteLine(headNum);

            int popNum = stack.Pop();
            Console.WriteLine(popNum);

            Console.WriteLine(stack.Count);

            foreach (var newNum in stack) Console.WriteLine(newNum);
            Console.ReadKey(true);

            
        }
    }
}
