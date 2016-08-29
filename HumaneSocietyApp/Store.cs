using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class Store
    {
        Bank bank;
        Database database;
        UserInput userInput;
        public Bank Bank
        {
            get
            {
                return bank;
            }
        }
        public UserInput UserInput
        {
            get
            {
                return userInput;
            }
        }
        public Database Database
        {
            get
            {
                return database;
            }
        }
        public Store()
        {
            bank = new Bank();
            userInput = new UserInput();
        }
        public void CreatedataBase(int load)
        {
            if (load == 0)
                database = new Database(userInput.GetSizeOfShelter());
            else
                database = new Database(load);
        }
        
    }
}
