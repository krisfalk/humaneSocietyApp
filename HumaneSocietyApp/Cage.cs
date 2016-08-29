using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class Cage
    {
        private Animal animal;
        private int cageNumber;
        public Animal Animal
        {
            get
            {
                return animal;
            }
            set
            {
                animal = value;
            }
        }
        public int CageNumber
        {
            get
            {
                return cageNumber;
            }
        }
        
        public Cage(int number)
        {
            cageNumber = number;
        }
        public void AddAnimalToCage(Animal newAnimal)
        {
            Animal = newAnimal;
        }
    }
}
