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




            /*Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);

            Console.WriteLine("Стек: ");
            foreach (var a in s) Console.WriteLine(a);

            Console.WriteLine("Всего чисел: ");
            Console.WriteLine(s.Count.ToString());
            Console.WriteLine("Последнее число в стеке: " + s.Pop());

            Console.WriteLine("Top after pop: " + s.Peek());

            Console.WriteLine();
            Console.WriteLine("Добавили числа в стек: ");
            s.Push(6);
            s.Push(7);
            Console.WriteLine("Всего чисел: " + s.Count.ToString());
            Console.WriteLine();
           

            Console.WriteLine("Измененный стек: ");
            foreach (var a in s) Console.WriteLine(a);
            Console.WriteLine("9 в стеке? " + s.Contains(9));
            Console.WriteLine("2 в стеке? " + s.Contains(2));

            s.Clear();
            Console.WriteLine("Cleared stack: ");
            foreach (var a in s) Console.WriteLine(a);
            s.Push(5);
            s.Push(4);
            Console.WriteLine("Добавили 5 и 4: ");
            foreach (var a in s) Console.WriteLine(a);
            Console.ReadKey();*/

            Stack1<int> myStack = new Stack1<int>();

            
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            
            int topElement = myStack.Pop();
            Console.WriteLine("Верхний элемент: " + topElement);

            
            topElement = myStack.Peek();
            Console.WriteLine("Верхний элемент после pop: " + topElement);

            
            bool containsElement = myStack.Contains(2);
            Console.WriteLine("Есть ли 2? " + containsElement);

            
            myStack.Clear();

            bool isEmpty = myStack.IsEmpty();
            Console.WriteLine("Стек пустой? " + isEmpty);

            Console.ReadKey();
        }
    }

    

    /*public class Stack
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
       
        

    }*/

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class Stack1<T>
    {
        private Node<T> _top;

        public Stack1()
        {
            _top = null;
        }

        public bool IsEmpty()
        {
            return _top == null;
        }

        public void Push(T element)
        {
            Node<T> node = new Node<T>(element);
            node.Next = _top;
            _top = node;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("Stack is empty");
            T data = _top.Data;
            _top = _top.Next;
            return data;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Stack is empty");
            return _top.Data;
        }

        public bool Contains(T element)
        {
            Node<T> current = _top;
            while (current != null)
            {
                if (current.Data.Equals(element))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            _top = null;
        }
    }



}
