using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesProject
{
    public class Simulation
    {
        //member vars

        //constructor
        public Simulation()
        {

        }
        //member methods
        public void CreateMarketingFirmWithManager()
        {
            MarketingFirm marketingFirm = new MarketingFirm();
            marketingFirm.CreateSweepstake();
            //What is the name of the sweepstakes?
            //Register the contestants
            //Decide stack or queue
            //Pick winner
            //Observable pattern to notify
        }
    }
}
