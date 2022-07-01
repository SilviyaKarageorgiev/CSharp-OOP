using P05.StackOfStrings;
using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            StackOfStrings stackOfStrings = new StackOfStrings();
            stackOfStrings.Push("1");
            stackOfStrings.Push("2");
            stackOfStrings.Push("3");
            Console.WriteLine(stackOfStrings.IsEmpty());

            Stack<string> stack = new Stack<string>();
            stack.Push("11");
            stack.Push("22");
            stack.Push("33");
            stack = stackOfStrings.AddRange(stack);

        }
    }
}
