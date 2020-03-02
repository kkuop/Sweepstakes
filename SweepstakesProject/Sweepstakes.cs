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
        private string name;
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
        public Contestant PickWinner()
        {
            int rng = new Random().Next(1, contestants.Count);
            Contestant winner = contestants[rng];
            return winner;
        }
        public void PrintContestantInfo(Contestant contestant)
        {

        }
    }
}
