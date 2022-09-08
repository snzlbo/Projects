using System;
using Sainzolboo;
using Sainzolboo.Lab1;

namespace Laboratory1
{
    public class NewClass : Person
    {
        public string Occupation { get; set; }

        public void setData()
        {
            Console.WriteLine("Enter next person's name :");
            Name = Console.ReadLine();

            Console.WriteLine("Enter next person's age :");
            Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter next person's occupation :");
            Occupation = Console.ReadLine();
        }

        public void DisplayOccupation()
        {
            Console.WriteLine("{0} {1}'s age is {2}.", Occupation, Name, Age);
        }

        public NewClass()
        {
            
        }
    }
}
