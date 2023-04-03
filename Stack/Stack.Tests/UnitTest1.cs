using Xunit;
using System;

namespace Stack.Tests
{
    public class Stack1Tests
    {
        [Fact]
        public void PushAddsElementToStack()
        {

            Stack1<int> stack = new Stack1<int>();


            stack.Push(1);
            stack.Push(2);


            Assert.False(stack.IsEmpty());
            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void PopRemovesAndReturnsTopElement()
        {

            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);


            int top = stack.Pop();


            Assert.Equal(2, top);
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void PeekReturnsTopElementWithoutRemovingIt()
        {

            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);


            int top = stack.Peek();


            Assert.Equal(2, top);
            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void ContainsReturnsTrueIfElementIsInStack()
        {

            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);


            bool contains = stack.Contains(1);


            Assert.True(contains);
        }

        [Fact]
        public void ContainsReturnsFalseIfElementIsNotInStack()
        {

            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);


            bool contains = stack.Contains(3);


            Assert.False(contains);
        }

        [Fact]
        public void ClearRemovesAllElementsFromStack()
        {

            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);


            stack.Clear();


            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void ForeachIsWorking()
        {
            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            int counter = 0;
            foreach(var item in stack)
            {
                if (counter == 1)
                    Assert.Equal(3, item);

                counter++;
            }

        }
    }
}

