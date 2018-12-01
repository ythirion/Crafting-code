using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Training.Crafting.Code.Stacks
{
    public class Stack : IReadOnlyCollection<object>
    {
        private List<object> _stack;

        public Stack()
        {
            _stack = new List<object>();    
        }

        public int Count => _stack.Count;

        public IEnumerator<object> GetEnumerator()
        {
            return _stack.GetEnumerator();
        }

        public void Push(object elementToPush)
        {
            _stack.Add(elementToPush);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _stack.GetEnumerator();
        }

        public object Pop()
        {
            if(Count == 0)
            {
                throw new EmptyStackException();
            }
            var lastElement = _stack.Last();
            _stack.Remove(lastElement);

            return lastElement;
        }
    }
}