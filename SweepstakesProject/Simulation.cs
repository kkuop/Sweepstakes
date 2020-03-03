using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesProject
{
    public class Simulation
    {
        //member vars
        SweepstakesStackManager stack = new SweepstakesStackManager();
        SweepstakesQueueManager queue = new SweepstakesQueueManager();
        MarketingFirm marketingFirm;
        Random rng;
        //constructor
        public Simulation()
        {
            rng = new Random();
        }
        //member methods
        public void RunSimulation()
        {
            string userInput;
            CreateMarketingFirmWithManager();
            do
            {
                userInput = UserInterface.DisplayMenu("What would you like to do?\n\na) Create Sweepstake\nb) Pick Winner\nc) Add contestant\nd) Quit");
                if (Comparer<string>.Default.Compare(userInput, "a") == 0)
                {
                    marketingFirm.CreateSweepstake();
                }
                if (Comparer<string>.Default.Compare(userInput, "b") == 0)
                {
                    marketingFirm.PickAWinner(rng);
                }
                if (Comparer<string>.Default.Compare(userInput, "c") == 0)
                {
                    marketingFirm.RegisterAContestant(rng);
                }
            } while (Comparer<string>.Default.Compare(userInput, "d") != 0);                        
        }
        public void CreateMarketingFirmWithManager()
        {
            string userInput = "a";
            //get user input to determine the stack or queue
            while (userInput!="s"&&userInput!="q")
            {
                userInput = UserInterface.GetUserInputFor("Would you like to use the s)tack or q)ueue data structure?");
                if (userInput == "s")
                {
                    marketingFirm = new MarketingFirm(stack);
                }
                else if (userInput == "q")
                {
                    marketingFirm = new MarketingFirm(queue);
                }
            }
        }
    }
}
