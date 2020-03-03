using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesProject
{
    public class Contestant
    {
        
        //member vars
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int RegistrationNumber { get; set; }
        public bool isWinner;

        //constructor
        public Contestant(string firstName, string lastName, string emailAddress, int registrationNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            RegistrationNumber = registrationNumber;
            isWinner = false;
        }

        //member methods


    }
}
