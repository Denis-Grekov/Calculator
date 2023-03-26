using System;

namespace Stack
{
    public class Stack<int>
    {
        private readonly int _Size;
        private readonly int[] _Array;
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
        public int Count
        {
            get
            {
                return this._Top;
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

        
    }
    
    
    
    

}
