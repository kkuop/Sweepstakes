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
        public static void DisplaySweeps(List<Sweepstakes> sweepstakes)
        {
            for (int i = 0; i < sweepstakes.Count; i++)
            {
                Console.Write($"| {sweepstakes[i].Name} |");
            }
            Console.WriteLine("\n");
        }
        public static void DisplayContestantsIsEmptyError()
        {
            Console.WriteLine("The contestants dictionary is empty!\n\nAdd some contestants before you pick a winner.\n\nPress any key to continue...");
        }
        public static void DisplayWinner(Contestant contestant)
        {
            Console.WriteLine($"The winner of the sweepstakes is: {contestant.FirstName} {contestant.LastName}!\n\n{contestant.EmailAddress}");

        }
    }
}
