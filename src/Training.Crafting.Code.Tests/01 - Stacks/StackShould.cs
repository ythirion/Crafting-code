using FluentAssertions;
using System.Linq;
using Training.Crafting.Code.Stacks;
using Xunit;

namespace Training.Crafting.Code.Tests.Stacks
{
    public class StackShould
    {
        private static object Object1 = new object();
        private static object Object2 = new object();

        private Stack stack;

        public StackShould()
        {
            stack = new Stack();
        }

        //NO VALUE TO TEST THE PUSH
        [Fact]
        public void raise_an_exception_when_popped_and_empty()
        {
            Stack emptyStack = new Stack();
            Assert.Throws<EmptyStackException>(() => emptyStack.Pop());
        }

        [Fact]
        public void pop_the_last_object_pushed()
        {
            var stackElement = new object();

            stack.Push(stackElement);

            var poppedElement = stack.Pop();

            stack.Count.Should().Be(0);
            poppedElement.Should().Be(stackElement);
        }

        [Fact]
        public void pop_objects_in_the_reverse_order_they_were_pushed()
        {
            stack.Push(Object1);
            stack.Push(Object2);

            stack.Pop().Should().Be(Object2);
            stack.Pop().Should().Be(Object1);
        }
    }
}
