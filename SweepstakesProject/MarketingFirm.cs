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
        //constructor
        public MarketingFirm(ISweepstakesManager manager)
        {
            _manager = manager;
        }
        //member methods
        public void CreateSweepstake()
        {

        }
    }
}
