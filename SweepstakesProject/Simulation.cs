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
                    marketingFirm.RegisterAContestant();
                }
            } while (Comparer<string>.Default.Compare(userInput, "d") != 0);                        
        }
        public void CreateMarketingFirmWithManager()
        {
            marketingFirm = new MarketingFirm();            
        }

    }
}
