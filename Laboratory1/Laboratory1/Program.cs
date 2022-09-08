using System;
using Sainzolboo;
using Sainzolboo.Lab1;
using Laboratory1;
using Ganbayar;

namespace Sainzolboo
{
    public class Person
    {
        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value > 0)
                {
                    _age = value;
                }
            }
        }
        public string Name { get; set; }
        public Person() { }
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
    }

    namespace Lab1
    {
        class SecondNS
        {
            Person newPerson = new Person(18, "Sainaa"); //using namespace zaaj ugsun tul shuud object uusgej bolno
            public void PrintPerson()
            {
                Console.WriteLine("Hello, {0}! Current time is {1}", newPerson.Name, System.DateTime.Now.TimeOfDay);
            }
        }
    }
}

class TestMain
{
    static void Main(string[] args)
    {
        Person person1 = new Person
        {
            Age = 18, //setter ajillaj bna
            Name = "Sainzolboo"
        }; //person 1 object uusgej bna

        Console.WriteLine("{0} is {1} years old.", person1.Name, person1.Age); //getter ajillaj bna

        SecondNS person2 = new SecondNS(); //person 2 object uusgej bna
        person2.PrintPerson();

        NewClass person3 = new NewClass();
        person3.setData();
        person3.DisplayOccupation();

        //oyutan ganbayariin namespace-g ashiglan object uusgelee
        Class1 newObject = new Class1();
        newObject.Name = "Ganbayar"; //setter ajillaj bna
        Console.WriteLine("Oyutan {0}-iin property.", newObject.Name); //getter propertyg newObject dr ashiglalaa
    }
}
