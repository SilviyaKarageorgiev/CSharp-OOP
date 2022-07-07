using System;

namespace PersonsInfo
{
    public class Person
    {
        private const string SymbolsOfFirstNameArgumentException = "First name cannot contain fewer than 3 symbols!";
        private const string SymbolsOfLastNameArgumentException = "Last name cannot contain fewer than 3 symbols!";
        private const string ZeroOrNegativeArgumentException = "Age cannot be zero or a negative integer!";
        private const string SalaryArgumentException = "Salary cannot be less than 650 leva!";

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(SymbolsOfFirstNameArgumentException);
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(SymbolsOfLastNameArgumentException);
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ZeroOrNegativeArgumentException);
                }
                this.age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {                
                this.salary = value;
            }
        }
        

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                this.Salary += this.Salary * percentage / 200;
            }
            else
            {
                this.Salary += this.Salary * percentage / 100;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
