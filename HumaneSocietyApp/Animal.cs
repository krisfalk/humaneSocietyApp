using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class Animal
    {
        protected double foodPoundsPerWeek;
        protected string name;
        protected bool hasShots;
        protected double price;
        protected string animalType;

        public string AnimalType
        {
            get
            {
                return animalType;
            }
        }
        public double FoodPoundsPerWeek
        {
            get
            {
                return foodPoundsPerWeek;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
        }
        public bool HasShots
        {
            get
            {
                return hasShots;
            }
            set
            {
                hasShots = value;  
            }
        }
        public Animal()
        {

        }

    }
}
