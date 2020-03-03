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
            stack = new Stack<Sweepstakes>();
        }

        //member methods
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            stack.Push(sweepstakes);
        }
        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakes = new Sweepstakes("Red Bull Sweeps");
            return sweepstakes;
        }
    }
}
