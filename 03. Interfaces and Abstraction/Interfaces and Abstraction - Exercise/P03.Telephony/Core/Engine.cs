using P03.Telephony.Models;
using System;

namespace P03.Telephony.Core
{
    public class Engine : IEngine
    {

        private readonly StationaryPhone stationaryPhone;
        private readonly Smartphone smartphone;

        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public void Start()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                if (!this.ValidateNumber(phoneNumber))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (phoneNumber.Length == 10)
                {
                    Console.WriteLine(this.smartphone.Call(phoneNumber));
                }
                else if (phoneNumber.Length == 7)
                {
                    Console.WriteLine(this.stationaryPhone.Call(phoneNumber));
                }
            }

            foreach (string url in urls)
            {
                if (!this.ValidateURL(url))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine(this.smartphone.BrowseURL(url));
                }
            }
        }

        private bool ValidateNumber(string number)
        {
            foreach (char digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateURL(string url)
        {
            foreach (char ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
