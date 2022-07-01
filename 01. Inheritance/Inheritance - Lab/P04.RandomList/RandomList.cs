using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace P04.RandomList
{
    public class RandomList : List<string>
    {

        private Random random;
        public RandomList()
        {
            this.random = new Random();
        }
        public string RandomString()
        {
            var index = this.random.Next(0, this.Count);
            var element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}
