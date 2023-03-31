using Xunit;

namespace Stack.Tests
{
    public class Stack1Tests
    {
        [Fact]
        public void PushAddsElementToStack()
        {
            // Arrange
            Stack1<int> stack = new Stack1<int>();

            // Act
            stack.Push(1);
            stack.Push(2);

            // Assert
            Assert.False(stack.IsEmpty());
            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void PopRemovesAndReturnsTopElement()
        {
            // Arrange
            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);

            // Act
            int top = stack.Pop();

            // Assert
            Assert.Equal(2, top);
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void PeekReturnsTopElementWithoutRemovingIt()
        {
            // Arrange
            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);

            // Act
            int top = stack.Peek();

            // Assert
            Assert.Equal(2, top);
            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void ContainsReturnsTrueIfElementIsInStack()
        {
            // Arrange
            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);

            // Act
            bool contains = stack.Contains(1);

            // Assert
            Assert.True(contains);
        }

        [Fact]
        public void ContainsReturnsFalseIfElementIsNotInStack()
        {
            // Arrange
            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);

            // Act
            bool contains = stack.Contains(3);

            // Assert
            Assert.False(contains);
        }

        [Fact]
        public void ClearRemovesAllElementsFromStack()
        {
            // Arrange
            Stack1<int> stack = new Stack1<int>();
            stack.Push(1);
            stack.Push(2);

            // Act
            stack.Clear();

            // Assert
            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void PopThrowsExceptionIfStackIsEmpty()
        {
            // Arrange
            Stack1<int> stack = new Stack1<int>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void PeekThrowsExceptionIfStackIsEmpty()
        {
            // Arrange
            Stack1<int> stack = new Stack1<int>();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }
}
