using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class Database
    {
        List<Adopter> adopters;
        UserInput userInput;
        Cage[] cages;
        Cage cage;
        Adopter adopter;
        public Cage Cage
        {
            get
            {
                return cage;
            }
        }
        public List<Adopter> Adopters
        {
            get
            {
                return adopters;
            }
        }
        public Cage[] Cages
        {
            get
            {
                return cages;
            }
        }
        public Database(int numberOfCages)
        {
            userInput = new UserInput();
            cages = new Cage[numberOfCages];
            adopters = new List<Adopter>();
        }
        public void ChooseAction(Store store)
        {
            string answer = userInput.ChooseAction();
            switch (answer)
            {
                case "add pet":
                    int index = NextOpenCage();
                    cage = new Cage(index + 1);
                    cages[index] = cage;
                    cages[index].AddAnimalToCage(userInput.CreateAnimal());
                    break;
                case "add adopter":
                    adopter = userInput.CreateAdopter();
                    adopters.Add(adopter);
                    break;
                case "list animals":
                    userInput.PrintAllOfType(cages, userInput.AskWhichAnimal());
                    break;
                case "list adopters":
                    userInput.PrintAdopters(adopters);
                    break;
                case "check food":
                    userInput.PrintFood(cages);
                    break;
                case "adopt":
                    Adopt(userInput.WhoIsAdopting(adopters), store);
                    break;
                default:
                    Console.WriteLine("Invalid entry. Try again.");
                    ChooseAction(store);
                    break;
            }
        }
        public int CountCagesInUse()
        {
            int index = 0;
            for (int i = 0; i < cages.Length; i++)
            {
                if (cages[i] != null)
                    index++;
            }
            return index;
        }
        public int CountAdopters()
        {
            return adopters.Count;
        }
        public void Adopt(Adopter adopter, Store store)
        {
            Animal animal = userInput.ChooseAnimalToAdopt(cages, CountCagesInUse());
            store.Bank.TotalMoney += animal.Price;
            for (int i = 0; i < cages.Length; i++)
            {
                if (cages[i] != null)
                {
                    if (cages[i].Animal == animal)
                        cages[i] = null;
                }
            }
            adopter.Adopt(animal);
        }
        public int NextOpenCage()
        {
            for (int i = 0; i < cages.Length; i++)
            {
                if (cages[i] == null)
                    return i;
            }
            return 0;
        }
    }
}
