using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class Bank
    {
        private double totalMoney;

        public double TotalMoney
        {
            get
            {
                return totalMoney;
            }
            set
            {
                totalMoney += value;
            }
        }
        public Bank()
        {
            totalMoney = 0;
        }
    }
}
