using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSocietyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainApp mainApp = new MainApp();
            mainApp.InitializeStore(0);
            mainApp.RunApp();
        }
    }
}
