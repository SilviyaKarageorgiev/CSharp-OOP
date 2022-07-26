using System;
using System.Collections.Generic;

namespace P03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] pair = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string face = pair[0];
                string suit = pair[1];

                try
                {
                    Card card = new Card(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            PrintCards(cards);
        }

        private static void PrintCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                Console.Write(card);
            }
        }

        public class Card
        {
            private string face;
            private string suit;

            List<string> faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            Dictionary<string, string> suits = new Dictionary<string, string>
            {
                {"S", "\u2660"},
                {"H", "\u2665"},
                {"D", "\u2666"},
                {"C", "\u2663"},
            };

            public Card(string face, string suit)
            {
                this.Face = face;
                this.Suit = suit;
            }

            public string Face
            {
                get
                {
                    return this.face;
                }
                set
                {
                    if (!faces.Contains(value))
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    this.face = value;
                }
            }

            public string Suit
            {
                get
                {
                    return this.suit;
                }
                set
                {
                    if (!suits.ContainsKey(value))
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    this.suit = value;
                }
            }

            public override string ToString()
            {
                return $"[{face}{suits[suit]}] ";
            }

        }
    }
}
