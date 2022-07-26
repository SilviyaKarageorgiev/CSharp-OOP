using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, double> accounts = new Dictionary<int, double>();

            string[] input = Console.ReadLine().Split(",");

            for (int i = 0; i < input.Length; i++)
            {
                string[] accNumBal = input[i].Split("-");

                accounts[int.Parse(accNumBal[0])] = double.Parse(accNumBal[1]);
            }

            string cmdArgs;
            while ((cmdArgs = Console.ReadLine()) != "End")
            {
                string[] arrCmdArgs = cmdArgs.Split(" ");

                string command = arrCmdArgs[0];

                int account = int.Parse(arrCmdArgs[1]);

                double amount = double.Parse(arrCmdArgs[2]);

                try
                {
                    if (!accounts.ContainsKey(account))
                    {
                        throw new InvalidOperationException("Invalid account!");
                    }

                    if (command == "Deposit")
                    {                        
                        accounts[account] += amount;
                        Console.WriteLine($"Account {account} has new balance: {accounts[account]:f2}");
                    }
                    else if (command == "Withdraw")
                    {
                        if (amount > accounts[account])
                        {
                            throw new InvalidOperationException("Insufficient balance!");
                        }
                        accounts[account] -= amount;
                        Console.WriteLine($"Account {account} has new balance: {accounts[account]:f2}:");
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid command!");
                    }

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
