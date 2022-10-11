using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace AsciiArtGenerator
{
    class Autocomplete //class used to read inputs and autocomplete paths
    {
        //function to get a file path 
        public static string takePath()
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
                        if (path.Length > 0)
                            {path = path.Remove(path.Length - 1);}
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
            Console.WriteLine(""); //newline after input

            //testing
            List<string> files = listFiles(path);
            for (int i = 0; i <files.Count();i++)
            {
                Console.WriteLine(files[i]);
            }
            return path;
        }
        //lists files in a given directory
        private static List<string> listFiles(string currentDirectory)
        {
            List<string> files = new List<string>();
            if (currentDirectory == "") // with no path at all, we just want the top level option. 
            {
                files.Add("C:\\");
                return files;
            }
            //get a list of files, and find names
            System.IO.FileInfo[] fileArray = new System.IO.DirectoryInfo(currentDirectory).GetFiles();
            string[] fileNames = new string[fileArray.Length];
            for (int i = 0; i < fileArray.Length;i++)
            {
                fileNames[i] = fileArray[i].Name;
            }
            files = fileNames.Cast<string>().ToList();
            for (int i = 0; i < files.Count(); i++)
            {
                Console.WriteLine(files[i]);
            }
            return files;
        }
    }
}

