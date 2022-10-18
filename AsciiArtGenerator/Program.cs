using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArtGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            
            bool gotPath = false;
            while (!gotPath)
            {
                string path = Autocomplete.takePath();
                string ready = "";
                while (ready != "Y" && ready != "n")
                {
                    Console.WriteLine("path is: " + path);
                    Console.WriteLine("Is this the correct path? Y/n ");
                    ready = Console.ReadLine();
                }
                if (ready == "Y")
                {
                    gotPath = true;
                }
            }
            
            Console.WriteLine("Press Any key to Exit ");
            Console.ReadLine();
        }
    }
}
