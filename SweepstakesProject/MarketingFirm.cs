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
        //constructor
        public MarketingFirm()
        {
        }
        //member methods
        public void CreateSweepstake()
        {
            //What is the name of the sweepstakes?
            //Read user input
            string userInput = UserInterface.GetUserInputFor("What is the name of the sweepstakes?");

            //Register the contestants
            Sweepstakes sweepstakes = new Sweepstakes(userInput);
            sweepstakes.RegisterContestant(new Contestant("Kyle", "Kuopus", "kkuopus@live.com", idIncrementer++));
            sweepstakes.RegisterContestant(new Contestant("Johnny", "Cash", "jcash@gmail.com", idIncrementer++));
            sweepstakes.RegisterContestant(new Contestant("Robert", "California", "r.california@yahoo.com", idIncrementer++));
            sweepstakes.RegisterContestant(new Contestant("Michael", "Scott", "bestbossever@michaelscottpapercompany.com", idIncrementer++));
            sweepstakes.RegisterContestant(new Contestant("Holly", "Flax", "hollyflax@gmail.com", idIncrementer++));
            


            //Decide stack or queue
            //Pick winner
            //Observable pattern to notify
        }
    }
}
