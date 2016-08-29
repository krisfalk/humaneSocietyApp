using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class ReadFile
    {
        public ReadFile()
        {
            List<string> loadSave = new List<String>();

            TextReader readSave = new StreamReader(".\\savedGame.txt");

            int lineCount = File.ReadAllLines(".\\savedGame.txt").Length;

            for (int i = 0; i < lineCount; i++)
            {
                loadSave.Add(readSave.ReadLine());
            }
            readSave.Close();
            File.Delete(".\\savedGame.txt");
            MainApp mainApp = new MainApp();
            mainApp.InitializeStore(1);
            mainApp.LoadApp(loadSave);
        }
    }
}
