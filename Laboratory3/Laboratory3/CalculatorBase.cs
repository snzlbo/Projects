using System;
using System.Collections.Generic;
using MemoryObject;

namespace Calculator
{
    public class CalculatorBase:Memory
    {   
        public List<Memory> memoryList = new List<Memory>();
        
        public int Result { get; set; }


        //MAIN METHODS
        public void addToMemory()
        {
            Memory MemoryObj = new Memory(Result);
            memoryList.Add(MemoryObj);
            Console.WriteLine("Added to memory!");
        }

        public void add(int adder, int a) //addition between 2 numbers
        {
            Result = adder + a;
        }

        public void subtract(int deduction, int a) //subtract between 2 numbers
        {
            Result = deduction - a; 
        }


        //WORKING WITH MEMORY ITEM
        public void DisplayMemory()
        {
            Console.WriteLine("Memory items:");
            int k = 0; //purpose for displaying memory items in sequence
            for (int i = 0; i < (memoryList.Count); i++)
            {
                Console.Write("At Position {0}: ", k);
                Console.WriteLine(memoryList[i].MemoryItem);
                k++;
            }
        }
        public void DisplayCurrentMemoryItem(int index) //displaying specific indexed memory item
        {
            Console.WriteLine("At Position {0}: {1}", index, memoryList[index].MemoryItem);
        }
        public void DeleteCurrentMemoryItem(int index) //deleting specific indexed memory item
        {
            memoryList.RemoveAt(index);
        }
        public void ClearMemory()
        {
            memoryList.Clear();
        }


        //WORKING WITH DISPLAY ITEM
        public void clearResult()
        {
            Result = 0;
        }

        public void removeByOne()
        {
            Result = Result / 10;
        }

        //CONSTRUCTORS
        public CalculatorBase() //setting result equals to zero when everytime default constructer called
        {
            Result = 0;
        }
        public CalculatorBase(int x)
        {
            Result = x;
        }
    }
}
