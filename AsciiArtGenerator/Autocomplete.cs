using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace AsciiArtGenerator
{
    class Autocomplete
    {
        public static string takePath()//function to get a file path 
        {
            string path = "";
            Console.WriteLine("Please enter path to image ");
            ConsoleKeyInfo key; //declared outside of loop so only declared once. 
            do // keep checking key until enter. 
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Spacebar://dont add the space to path 
                        break;
                    case ConsoleKey.Backspace://remove a character
                        path = path.Remove(path.Length - 1);
                        break;
                    case ConsoleKey.Enter://do nothing
                        break;
                    default:
                        path += key.KeyChar;
                        break;
                }
                Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");// clears current console buffer
                Console.Write(path);
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine(""); //newline
            return path;
        }

    }
}

