using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesProject
{
    public class Sweepstakes
    {
        //member vars
        private Dictionary<int, Contestant> contestants;
        public string Name { get; set; }
        //constructor
        public Sweepstakes(string name)
        {
            Name = name;
            contestants = new Dictionary<int, Contestant>();
        }

        //member methods
        public void RegisterContestant(Contestant contestant)
        {
            //add to dictionary
            contestants.Add(contestant.RegistrationNumber, contestant);
        }
        public Contestant PickWinner(Random rng)
        {
                Contestant winner = contestants[rng.Next(0, contestants.Count)];
                return winner;
        }
        public void PrintContestantInfo(Contestant contestant)
        {
            UserInterface.DisplayWinner(contestant);
        }
        public bool CheckIfContestantsIsEmpty()
        {
            if(contestants.Count<1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
