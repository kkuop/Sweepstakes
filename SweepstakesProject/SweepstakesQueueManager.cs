using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesProject
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {

        //member vars
        Queue<Sweepstakes> queue;

        //constructor
        public SweepstakesQueueManager()
        {
            queue = new Queue<Sweepstakes>();
        }
        
        //member methods
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            queue.Enqueue(sweepstakes);
        }
        public Sweepstakes GetSweepstakes(string userInput)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue.ElementAt(i).Name == userInput)
                {
                    return queue.ElementAt(i);
                }
            }
            return null;
        }
    }
}
