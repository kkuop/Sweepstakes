using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesProject
{
    static class UserInterface
    {
        public static string GetUserInputFor(string prompt)
        {
            Console.Write($"{prompt}\n\n__");
            string userInput = Console.ReadLine();
            Console.Clear();
            return userInput;
        }
        public static string DisplayMenu(string prompt)
        {
            string userInput;

            do
            {
                Console.Write($"{prompt}\n\n__");
                userInput = Console.ReadLine().ToLower();
                Console.Clear();
            } while (Comparer<string>.Default.Compare(userInput, "a") != 0 && Comparer<string>.Default.Compare(userInput, "b") != 0 && Comparer<string>.Default.Compare(userInput, "c") != 0 && Comparer<string>.Default.Compare(userInput, "d") != 0);
            return userInput;
        }
    }
}
