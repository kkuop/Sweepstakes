using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesProject
{
    public class MarketingFirm
    {
        //member vars
        ISweepstakesManager _manager;
        int idIncrementer;
        SweepstakesStackManager stack = new SweepstakesStackManager();
        SweepstakesQueueManager queue = new SweepstakesQueueManager();
        //constructor
        public MarketingFirm()
        {
        }
        //member methods
        public void CreateSweepstake()
        {
            //What is the name of the sweepstakes?
            //Read user input
            string nameOfSweeps = UserInterface.GetUserInputFor("What is the name of the sweepstakes?");
            Sweepstakes sweepstakes = new Sweepstakes(nameOfSweeps);
            //Add the sweepstakes to the Stack and Queue
            stack.InsertSweepstakes(sweepstakes);

            //Register the contestants

            sweepstakes.RegisterContestant(new Contestant("Kyle", "Kuopus", "kkuopus@live.com", idIncrementer++));
            sweepstakes.RegisterContestant(new Contestant("Johnny", "Cash", "jcash@gmail.com", idIncrementer++));
            sweepstakes.RegisterContestant(new Contestant("Robert", "California", "r.california@yahoo.com", idIncrementer++));
            sweepstakes.RegisterContestant(new Contestant("Michael", "Scott", "bestbossever@michaelscottpapercompany.com", idIncrementer++));
            sweepstakes.RegisterContestant(new Contestant("Holly", "Flax", "hollyflax@gmail.com", idIncrementer++));
            



            //Pick winner
            //Observable pattern to notify
        }
        public void PickAWinner()
        {
            //Which sweepstakes?
            string userInput;
            ReturnListOfOpenSweeps();
            userInput = UserInterface.GetUserInputFor("Which sweepstakes would you like to pick a winner for?");

        }
        public void RegisterAContestant()
        {
            //Which sweepstakes?
            string userInput;
            userInput = UserInterface.GetUserInputFor("Which sweepstakes would you like to register a contestant for?");
        }
        private void ReturnListOfOpenSweeps()
        {
            stack.GetSweepstakes();
        }
    }
}
