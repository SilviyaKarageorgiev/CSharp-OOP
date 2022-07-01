using P04.RandomList;
using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            var randomList = new RandomList();
            randomList.Add("1");
            randomList.Add("2");
            randomList.Add("3");
            randomList.Add("4");

            Console.WriteLine(randomList.RandomString());
        }
    }
}
