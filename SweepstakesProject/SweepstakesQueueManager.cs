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

        }
        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakes = new Sweepstakes("Mountain Dew Sweepstakes");
            return sweepstakes;
        }
    }
}
