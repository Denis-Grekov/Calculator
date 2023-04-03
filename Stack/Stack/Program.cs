using System;
using System.Collections;
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

    public class Stack1<T> : IEnumerable<T>
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


        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _top;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }



}
