using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArtGenerator
{
    /// <summary>
    /// Class to manage iterating through a list of suggestions that match a string. 
    /// </summary>
    class Suggestion
    {
        private List<string> suggestionList;
        private int index = 0;

        public Suggestion(List<string> inStrings)
        {
            suggestionList = inStrings;
        }
        /// <summary>
        /// cycles suggestionList items in a loop
        /// </summary>
        /// <returns> returns an int of the current index</returns>
        private int cycle()
        {
             int currentIndex = index++;
            if (index >= suggestionList.Count)
            {
                index = 0;
            }
            return currentIndex;
        }
        /// <summary>
        /// sets the values to sort through
        /// </summary>
        /// <param name="inStrings"> List of strings to add</param>
        /// <param name="compareTo"> string to compare to</param>
        public void setSuggestions(List<string> inStrings, string compareTo)
        {
            index = 0;
            suggestionList.Clear();
            for (int i = 0; i < inStrings.Count; i++)
            {
                if (inStrings[i].StartsWith(compareTo))
                {
                    suggestionList.Add(inStrings[i]);
                }
            }
            suggestionList.Sort();
        }
        /// <summary>
        /// get a suggestion from the list
        /// </summary>
        /// <returns>returns a string of the suggestion</returns>
        public string getSuggestion()
        {
            return suggestionList[cycle()];
        }
        /// <summary>
        /// Method to append an additoinal string to be checked 
        /// </summary>
        /// <param name="inString">string to add</param>
        public void addSuggestion(string inString)
        {
            suggestionList.Add(inString);
        }
    }
}
