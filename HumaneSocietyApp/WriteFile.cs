using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class WriteFile
    {
        public WriteFile(List<string> saveApp)
        {
            TextWriter saveGame = new StreamWriter(".\\savedGame.txt");

            foreach (string data in saveApp)
            {
                saveGame.WriteLine(data);
            }

            saveGame.Close();
        }
    }
}
