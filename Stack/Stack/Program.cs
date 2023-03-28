using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            


            
            Stack<int> s = new Stack<int>();
            
            s.Push(1);
            s.Push(2);
            s.Push(3);

            Console.WriteLine("Стек: ");
            foreach (var a in s) Console.WriteLine(a);

            Console.WriteLine("Всего элементов в стеке: ");
            Console.WriteLine(s.Count.ToString());
            Console.WriteLine("Крайнее число стека: " + s.Pop());
            
            Console.WriteLine("Крайнее число после pop: " + s.Peek());
            
            Console.WriteLine();
            Console.WriteLine("Добавили числа: ");
            s.Push(4);
            s.Push(5);
            Console.WriteLine("Всего чисел после push: " + s.Count.ToString());
            Console.WriteLine();
            Console.WriteLine("Всего элементов в стеке: ");
            Console.WriteLine(s.Count);

            Console.WriteLine("Отредактированный стек: ");
            foreach (var a in s) Console.WriteLine(a);
            Console.WriteLine("Есть ли в стеке 9? " + s.Contains(9));
            Console.WriteLine("Есть ли в стеке 2? " + s.Contains(2));
            

            s.Clear();
            Console.WriteLine("Очистили стек: ");
            foreach (var a in s) Console.WriteLine(a);
            s.Push(5);
            s.Push(4);
            Console.WriteLine("Добавили 5 и 4 в стек: ");
            foreach (var a in s) Console.WriteLine(a);
            Console.ReadKey();
        }
    }

    

    public class Stack
    {
        private int _Size;
        private int[] _Array;
        private int _Top;


        public Stack(int Size)
        {
            this._Size = Size;
            this._Top = 0;
            this._Array = new int[this._Size];
        }

        public int Top
        {
            get
            {
                return this._Top;
            }
        }

        public int Size
        {
            get
            {
                return this._Size;
            }
        }
        
        public bool IsFull()
        {
            return this._Top == this._Size;
        }

        public bool IsEmpty()
        {
            return this._Top == 0;
        }
        public void Push(int Element)
        {
            if (this.IsFull())
                throw new Exception();
            this._Array[this._Top++] = Element;


        }

        public int Peek()
        {
            return this._Array[this._Top - 1];
        }

        public int Pop()
        {
            return this._Array[--this._Top];
        }

        public bool Contains(int arg)
        {
            for (int i = _Top - 1; i >= 0; i--)
            {
                if (_Array[i] == arg)
                {
                    return true;
                }
            }

            return false;


        }

        public void Clear()   
        {
            for (int i = 0; i < _Size; i++)
            {
                _Array[i] = 0;
            }

            _Top = 0;

        }
       
        

    }

    
   


}
