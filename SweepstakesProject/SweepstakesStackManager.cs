using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesProject
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        //member vars
        private Stack<Sweepstakes> stack;
        
        //constructor
        public SweepstakesStackManager()
        {

        }

        //member methods
        public void InsertSweepstakes()
        {

        }
        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakes = new Sweepstakes("Red Bull Sweeps");
            return sweepstakes;
        }

    }
}
