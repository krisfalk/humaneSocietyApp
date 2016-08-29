using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class Dog : Animal
    {
        public Dog(string name, double foodPoundsPerWeek, bool hasShots, double price)
        {
            this.animalType = "dog";
            this.name = name;
            this.foodPoundsPerWeek = foodPoundsPerWeek;
            this.hasShots = hasShots;
            this.price = price;
        }
    }
}
