using System;
using Calculator;


namespace Laboratory2
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorBase calcBase = new CalculatorBase();
            int x, y;
            calcBase.displayResult();
            while (true)//purpose for cyclic work
            {
                Console.WriteLine(" ");
                Console.WriteLine("1. Add numbers, 2. Subtract numbers, 3. Display Memory, 4. Clear Memory, 5. Display result"); //some sort of working menu
                Console.WriteLine("6. Clear Result, 7. Remove 1 number, 8. Increase Memory By index, 9. Decrease Memory By index");
                Console.WriteLine("10. Delete Memory By index, 11. Add Number To Memory 12. Exit");
                Console.WriteLine(" ");
                int command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        Console.Write("Enter an adding number: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        calcBase.add(x);
                        Console.WriteLine("Added!");
                        calcBase.displayResult();
                        break;
                    case 2:
                        Console.Write("Enter a subtracting number: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        calcBase.subtract(x);
                        Console.WriteLine("Deducted!");
                        calcBase.displayResult();
                        break;
                    case 3:
                        calcBase.DisplayMemory();
                        break;
                    case 4:
                        calcBase.ClearMemory();
                        Console.WriteLine("Memory cleared!");
                        break;
                    case 5:
                        calcBase.displayResult();
                        break;
                    case 6:
                        calcBase.clearResult();
                        Console.WriteLine("Result cleared!");
                        break;
                    case 7:
                        calcBase.removeByOne();
                        calcBase.displayResult();
                        break;
                    case 8:
                        Console.Write("Enter an index number: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter a subtracting number: ");
                        y = Convert.ToInt32(Console.ReadLine());

                        calcBase.memoryList[x].DecreaseMemoryItem(y);
                        calcBase.DisplayCurrentMemoryItem(x);
                        break;
                    case 9:
                        Console.Write("Enter an index number: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter a adding number: ");
                        y = Convert.ToInt32(Console.ReadLine());

                        calcBase.memoryList[x].IncreaseMemoryItem(y);
                        calcBase.DisplayCurrentMemoryItem(x);
                        break;
                    case 10:
                        Console.Write("Enter an index number: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        calcBase.DeleteCurrentMemoryItem(x);
                        Console.WriteLine("Deleted!");
                        break;
                    case 11:
                        calcBase.addToMemory();
                        break;
                    case 12:
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong command.");
                        break;
                }
            }
            
        }
    }
}
