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
        }
        //member methods
        public void RegisterContestant(Contestant contestant)
        {

        }
        public Contestant PickWinner()
        {
            return new Contestant("test", "contestant", "test@gmail.com", 1);
        }
        public void PrintContestantInfo(Contestant contestant)
        {

        }
    }
}
