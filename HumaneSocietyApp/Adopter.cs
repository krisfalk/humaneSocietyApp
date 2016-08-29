using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class Adopter
    {
        private string name;
        private string animalPreference;
        private bool hasAdopted;
        List<Animal> animals;
        Bank bank;
        public List<Animal> Animals
        {
            get
            {
                return animals;
            }
        }
        public Bank Bank
        {
            get
            {
                return bank;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string AnimalPreference
        {
            get
            {
                return animalPreference;
            }
            set
            {
                animalPreference = value;
            }
        }
        public bool HasAdopted
        {
            get
            {
                return hasAdopted;
            }
            set
            {
                hasAdopted = value;
            }
        }
        public Adopter(string name, string animalPreference, double money, bool hasAdopted)
        {
            animals = new List<Animal>();
            bank = new Bank();
            this.name = name;
            this.animalPreference = animalPreference;
            bank.TotalMoney = money;
            HasAdopted = hasAdopted;
            
        }
        public void Adopt(Animal animal)
        {
            bank.TotalMoney -= animal.Price;
            animals.Add(animal);
            HasAdopted = true;
        }
    }
}
