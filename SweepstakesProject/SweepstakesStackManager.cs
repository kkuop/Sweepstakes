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
        public Sweepstakes GetSweepstakes(string userInput)
        {
            for (int i = 0; i < stack.Count; i++)
            {
                if(stack.ElementAt(i).Name == userInput)
                {
                    return stack.ElementAt(i);
                }
            }
            return null;
        }
    }
}
