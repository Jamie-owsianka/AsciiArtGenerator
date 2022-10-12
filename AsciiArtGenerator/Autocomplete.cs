using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace AsciiArtGenerator
{
/// <summary>
/// Class that manages the autocomplete section to select an image. 
/// </summary>
    class Autocomplete

    {/// <summary>
    /// Function that takes the input from the user
    /// </summary>
    /// <returns>
    /// string that is the path to the image. 
    /// </returns>
        public static string takePath()
        {
            string path = "";
            Console.WriteLine("Please enter path to image ");
            ConsoleKeyInfo key; //declared outside of loop so only declared once. 
            Suggestion suggestion = new Suggestion(listFiles(""));
            do // keep checking key until enter. 
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Spacebar://dont add the space to path 
                        break;
                    case ConsoleKey.Backspace://remove a character
                        if (path.Length > 0)
                            {
                            path = path.Remove(path.Length - 1);
                            }
                        break;
                    case ConsoleKey.Enter://do nothing
                        break;
                    case ConsoleKey.Tab:
                        if (path.EndsWith("\\"))//have to check path as not all slashes are typed
                        {
                            suggestion.setSuggestions(listFiles(justPath(path)), afterPath(path));//lists files for current paths
                            suggestion.addSuggestion(afterPath(path));//adds current path so user can cycle back to it
                        }
                        path = justPath(path) + suggestion.getSuggestion();
                        break;
                    default:
                        path += key.KeyChar;
                        suggestion.setSuggestions(listFiles(justPath(path)),afterPath(path));//lists files for current paths
                        suggestion.addSuggestion(afterPath(path));//adds current path so user can cycle back to it  
                        break;
                }
                Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");// clears current console buffer
                Console.Write(path);
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine(""); //newline after input

            //testing
            if (false)
            {
                List<string> files = listFiles(path);
                for (int i = 0; i < files.Count(); i++)
                {
                    Console.WriteLine(files[i]);
                }
            }
            return path;
        }
        /// <summary>
        /// lists each file in a given directory
        /// </summary>
        /// <param name="currentDirectory"> The directory to list files from</param>
        /// <returns>List of strings containing the name of each file in that directory</returns>
        private static List<string> listFiles(string currentDirectory)
        {
            List<string> files = new List<string>();
            if (currentDirectory == "") // with no path at all, we just want the top level option. 
            {
                files.Add("C:\\");
                return files;
            }
            string rootPath = Path.GetPathRoot(AppDomain.CurrentDomain.FriendlyName);
            FileInfo[] fileArray = new DirectoryInfo(rootPath + currentDirectory).GetFiles();
            if (!(fileArray.Length > 0))//if no files
            {
                //files.Add("");
                //return files;
            }
            string[] fileNames = new string[fileArray.Length];//get list of filenames from files
            for (int i = 0; i < fileArray.Length;i++)
            {
                fileNames[i] = fileArray[i].Name;
            }
            files = fileNames.Cast<string>().ToList();
            //for (int i = 0; i < files.Count(); i++)
            //{
                //Console.WriteLine(files[i]);
            //}
            return files;
        }
        /// <summary>
        /// gets the string after the last backslash
        /// </summary>
        /// <param name="path"> the path to get the string from </param>
        /// <returns>the last string from after the backslash</returns>
        private static string afterPath(string path)
        {
            if (path.EndsWith("\\"))
            {
                return "";
            }
            string[] parts = path.Split('\\');
            return parts.Last();

        }
        /// <summary>
        /// gets the path of a string, without any bits on the end
        /// </summary>
        /// <param name="path">path to get the string from</param>
        /// <returns>string before the last backslash</returns>
        private static string justPath(string path)
        {
            if (path == "")
            {
                return "";
            }
            string[] parts = path.Split('\\');
            string[] relevnantParts = parts.Take(parts.Length -1).ToArray();
            string finalString = string.Join("\\", relevnantParts) + "\\";
            return finalString;
        }
    }
}

