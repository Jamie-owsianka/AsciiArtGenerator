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
            string path = Autocomplete.takePath();

            Console.WriteLine("Press Any key to Exit ");
            Console.ReadLine();
        }
    }
}
