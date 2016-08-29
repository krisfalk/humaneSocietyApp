using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class UserInput
    {
        public string ChooseAction()
        {
            Console.WriteLine("What would you like to do? \n(Type: 'add pet', 'add adopter', 'list animals', 'list adopters', 'check food', or 'adopt')");
            return Console.ReadLine();
        }
        public Adopter CreateAdopter()
        {
            Console.WriteLine("What is the name of the new adopter?");
            string name = Console.ReadLine();
            Console.WriteLine("What is {0}'s animal type preference?", name);
            string type = Console.ReadLine();
            Console.WriteLine("How much money does {0} have to spend on buying pets?", name);
            double money = Convert.ToDouble(Console.ReadLine());
            return new Adopter(name, type, money, false);
        }
        public Animal CreateAnimal()
        {
            Console.WriteLine("Would you like to add a dog, a cat, or bird?");
            string type = Console.ReadLine();
            Console.WriteLine("What is this {0}'s name?", type);
            string name = Console.ReadLine();
            Console.WriteLine("How many pounds of food per week does {0} consume?", name);
            double food = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Are {0}'s shots current? (type 'true' or 'false')", name);
            bool shots = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("How much does it cost to adopt this {0}, named {1}?", type, name);
            double price = Convert.ToDouble(Console.ReadLine());
            if(shots == false)
            {
                shots = true;
                Console.WriteLine("{0} was administered all of the shots to make this {1} up to date on shots.", name, type);
            }
            switch (type)
            {
                case "dog":
                    return new Dog(name, food, shots, price);
                case "cat":
                    return new Cat(name, food, shots, price);
                case "bird":
                    return new Bird(name, food, shots, price);
                default:
                    return null;
            }
        }
        public int GetSizeOfShelter()
        {
            Console.WriteLine("How many cages does this Humane Society have?");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void PrintAnimal(Animal animal, int index)
        {
            Console.WriteLine("Cage number:{0} Type:{1} Name:{2} Lbs. food weekly:{3} Current on Shots:{4} Price:{5}", index, animal.AnimalType, animal.Name, animal.FoodPoundsPerWeek, animal.HasShots, animal.Price);
        }
        public void PrintAdopter(Adopter adopter, int index)
        {
            Console.WriteLine("{0}. Name:{1} Prefered Animal:{2} Money to Spend:{3}", index + 1, adopter.Name, adopter.AnimalPreference, adopter.Bank.TotalMoney);
            if (adopter.HasAdopted)
            {
                for (int i = 0; i < adopter.Animals.Count; i++)
                {
                    Console.WriteLine("     {0} has adopted the following animals:", adopter.Name);
                    PrintAnimal(adopter.Animals[i], i);
                }
            }
        }
        public string AskWhichAnimal()
        {
            Console.WriteLine("Which type of animal do you want to see a list of? (dog, cat, bird)");
            return Console.ReadLine();
        }
        public void PrintAllOfType(Cage[] cages, string type)
        {
            for (int i = 0; i < cages.Length; i++)
            {
                if (cages[i] != null)
                {
                    if (cages[i].Animal.AnimalType == type)
                        PrintAnimal(cages[i].Animal, i + 1);
                }
            }
        }
        public void PrintAdopters(List<Adopter> adopters)
        {
            for (int i = 0; i < adopters.Count; i++)
            {
                PrintAdopter(adopters[i], i);
            }
        }
        public void PrintFood(Cage[] cages)
        {
            double foodTotal = 0;
            for (int i = 0; i < cages.Length; i++)
            {
                if(cages[i] != null)
                    foodTotal += cages[i].Animal.FoodPoundsPerWeek;
            }
            Console.WriteLine("Your animals require {0:0.00} lbs. of food per day and {1} lbs. of food per week.", foodTotal / 7, foodTotal);
        }
        public Animal ChooseAnimalToAdopt(Cage[] cages, int index)
        {
            Console.WriteLine("Do you want to adopt a bird, cat, or dog?");
            string type = Console.ReadLine();
            PrintAllOfType(cages, type);
            Console.WriteLine("Which {0} do you want to adopt? (type the name of the {0})", type);
            string name = Console.ReadLine();
            for (int i = 0; i < cages.Length; i++)
            {
                if (cages[i] != null)
                {
                    if (cages[i].Animal.AnimalType == type && cages[i].Animal.Name == name)
                        return cages[i].Animal;
                }
            }
            return null;
        }
        public Adopter WhoIsAdopting(List<Adopter> adopters)
        {
            PrintAdopters(adopters);
            Console.WriteLine("Which adopter is going to pick an animal? (type the name of the adopter)");
            string name = Console.ReadLine();
            for (int i = 0; i < adopters.Count; i++)
            {
                if (adopters[i].Name == name)
                    return adopters[i];
            }
            return null;
        }
        public Animal LoadAnimal(string type, string name, double food, bool shots, double price)
        {
            switch (type)
            {
                case "dog":
                    return new Dog(name, food, shots, price);
                case "cat":
                    return new Cat(name, food, shots, price);
                default:
                    return new Bird(name, food, shots, price);

            }
        }
    }
}
