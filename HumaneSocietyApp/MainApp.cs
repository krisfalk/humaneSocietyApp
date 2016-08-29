using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class MainApp
    {
        Store store;
        List<string> loadApp;
        List<string> saveApp;
        public MainApp()
        {

        }
        public void InitializeStore(int load)
        {
            string currentFile = @".\\savedGame.txt";
            store = new Store();
            if (File.Exists(currentFile))
            {
                ReadFile writeFile = new ReadFile();
            }
            if(load == 0)
                store.CreatedataBase(load);
        }
        public void RunApp()
        {
            while(0 != 1)
            {
                SaveApp();
                Console.WriteLine("Press enter to Continue.");
                Console.ReadLine();
                Console.Clear();
                store.Database.ChooseAction(store);
            }
        }
        public void SaveApp()
        {
            saveApp = new List<string>();
            saveApp.Add(Convert.ToString(store.Database.CountCagesInUse()));
            saveApp.Add(Convert.ToString(store.Database.CountAdopters()));
            saveApp.Add(Convert.ToString(store.Database.Cages.Length));
            saveApp.Add(Convert.ToString(store.Bank.TotalMoney));
            for (int i = 0; i < store.Database.Cages.Length; i++)
            {
                if(store.Database.Cages[i] != null)
                {
                    saveApp.Add(Convert.ToString(i));
                    saveApp.Add(store.Database.Cages[i].Animal.AnimalType);
                    saveApp.Add(store.Database.Cages[i].Animal.Name);
                    saveApp.Add(Convert.ToString(store.Database.Cages[i].Animal.FoodPoundsPerWeek));
                    saveApp.Add(Convert.ToString(store.Database.Cages[i].Animal.Price));
                }
            }
            for (int i = 0; i < store.Database.Adopters.Count; i++)
            {
                if(store.Database.Adopters[i] != null)
                {
                    saveApp.Add(store.Database.Adopters[i].Name);
                    saveApp.Add(store.Database.Adopters[i].AnimalPreference);
                    saveApp.Add(Convert.ToString(store.Database.Adopters[i].Bank.TotalMoney));
                    saveApp.Add(Convert.ToString(store.Database.Adopters[i].HasAdopted));
                    if (store.Database.Adopters[i].HasAdopted)
                    {
                        for (int p = 0; p < store.Database.Adopters[i].Animals.Count; p++)
                        {
                            saveApp.Add(Convert.ToString(store.Database.Adopters[p].Animals.Count));
                            saveApp.Add(store.Database.Adopters[i].Animals[p].AnimalType);
                            saveApp.Add(store.Database.Adopters[i].Animals[p].Name);
                            saveApp.Add(Convert.ToString(store.Database.Adopters[i].Animals[p].FoodPoundsPerWeek));
                            saveApp.Add(Convert.ToString(store.Database.Adopters[i].Animals[p].Price));
                        }

                    }

                }

            }

            WriteFile writeFile = new WriteFile(saveApp);
        }
        public void LoadApp(List<string> loadApp)
        {
            //0 = number of animals
            //1 = number of adopters
            int index2 = 0;
            int index = Convert.ToInt32(loadApp[0]);
            store.CreatedataBase(Convert.ToInt32(loadApp[2]));
            store.Bank.TotalMoney = Convert.ToDouble(loadApp[3]);
            for(int i = 0; i < index; i++)
            {
                Cage cage = new Cage(Convert.ToInt32(loadApp[4 + (5 * i)]) + 1);
                store.Database.Cages[Convert.ToInt32(loadApp[4 + (5 * i)])] = cage;
                Animal newAnimal = store.UserInput.LoadAnimal(loadApp[5 + (5 * i)], loadApp[6 + (5 * i)], Convert.ToDouble(loadApp[7 + (5 * i)]), true, Convert.ToDouble(loadApp[8 + (5 * i)]));
                store.Database.Cages[Convert.ToInt32(loadApp[4 + (5 * i)])].AddAnimalToCage(newAnimal);
            }
            for(int i = 0; i < Convert.ToInt32(loadApp[1]); i++)
            {
                bool hasAdopted = false;
                Boolean.TryParse(loadApp[6 + (5 * index) + (index2 * 5)], out hasAdopted);
                Adopter newAdopter = new Adopter(loadApp[4 + (5 * index) + (index2 * 5)], loadApp[5 + (5 * index) + (index2 * 5)], Convert.ToDouble(loadApp[6 + (5 * index) + (index2 * 5)]), hasAdopted);
                store.Database.Adopters.Add(newAdopter);
                if (hasAdopted)
                {
                    for (int p = 0; p < Convert.ToInt32(loadApp[4 + (5 * i)]); p++)
                    {
                        index2++;
                        Animal newAnimal = store.UserInput.LoadAnimal(loadApp[5 + (5 * i) + (index2 * 5)], loadApp[6 + (5 * i) + (index2 * 5)], Convert.ToDouble(loadApp[7 + (5 * i) + (index2 * 5)]), true, Convert.ToDouble(loadApp[8 + (5 * i) + (index2 * 5)]));
                        store.Database.Adopters[i].Animals.Add(newAnimal);
                    }
                }
            }
            RunApp();
        }
    }
}
