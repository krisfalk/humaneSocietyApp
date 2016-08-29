using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class Bird : Animal
    {
        public Bird(string name, double foodPoundsPerWeek, bool hasShots, double price)
        {
            this.animalType = "bird";
            this.name = name;
            this.foodPoundsPerWeek = foodPoundsPerWeek;
            this.hasShots = hasShots;
            this.price = price;
        }
    }
}
