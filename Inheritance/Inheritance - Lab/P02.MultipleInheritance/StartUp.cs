using P02.MultipleInheritance;
using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
        }
    }
}
