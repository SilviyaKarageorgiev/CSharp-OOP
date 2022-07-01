using System;
using System.Collections.Generic;
using System.Text;

namespace P05.StackOfStrings
{
    public class StackOfStrings : Stack<string>
    {
        Stack<string> data;
        public bool IsEmpty()
        {
            return this.Count == 0;            
        }

        public Stack<string> AddRange(IEnumerable<string> data)
        {
            foreach (var item in data)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
