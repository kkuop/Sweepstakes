using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;

namespace SweepstakesProject
{
    public class MarketingFirm
    {
        //member vars
        ISweepstakesManager _manager;
        int idIncrementer;
        List<Sweepstakes> listOfSweeps;
        Sweepstakes activeSweep;
        Contestant sweepWinner;
        int Count { get; set; }
        //constructor
        public MarketingFirm( ISweepstakesManager _manager)
        {
            this._manager = _manager;
            Count = 0;
            listOfSweeps = new List<Sweepstakes>();
        }
        //member methods
        public void CreateSweepstake()
        {
            //What is the name of the sweepstakes?
            //Read user input
            string nameOfSweeps = UserInterface.GetUserInputFor("What is the name of the sweepstakes?");
            Sweepstakes sweepstakes = new Sweepstakes(nameOfSweeps);
            //Add the sweepstakes to the Stack, Queue, or List
            _manager.InsertSweepstakes(sweepstakes);            
            listOfSweeps.Add(sweepstakes);
            Count++;
        }
        public void PickAWinner(Random rng)
        {
            if(listOfSweeps.Count < 1)
            {
                return;
            }
            //Which sweepstakes?
            UserInterface.DisplaySweeps(listOfSweeps);
            string userInput = UserInterface.GetUserInputFor("Which sweepstakes would you like to pick a winner for?\n\nType 'cancel' to cancel...");
            while (activeSweep == null && userInput != "cancel")
            {
                for (int i = 0; i < listOfSweeps.Count; i++)
                {
                    if (listOfSweeps[i].Name == userInput)
                    {
                        //activeSweep = listOfSweeps[i];
                        activeSweep = _manager.GetSweepstakes(userInput);
                    }
                }
                if (activeSweep == null)
                {
                    UserInterface.DisplaySweeps(listOfSweeps);
                    userInput = UserInterface.GetUserInputFor("Which sweepstakes would you like to pick a winner for?\n\nType 'cancel' to cancel...");
                }
            }
            if(userInput == "cancel")
            {
                return;
            }
            bool isEmpty = activeSweep.CheckIfContestantsIsEmpty();
            //Randomly generate int to pick contestant from dictionary based on their key
            if (isEmpty == false)
            {
                sweepWinner = activeSweep.PickWinner(rng);
            }
            else
            {
                UserInterface.DisplayContestantsIsEmptyError();
                Console.ReadKey();
                Console.Clear();
                return;
            }
            activeSweep.PrintContestantInfo(sweepWinner);
            //Notify all contestants of their win/loss
            //Integrate the mailAPI
            activeSweep.SendEmailToWinner(sweepWinner);
            activeSweep = null;            
        }
        public void RegisterAContestant(Random rng)
        {
            if (listOfSweeps.Count < 1)
            {
                return;
            }
            //Which sweepstakes?
            string userInput;
            UserInterface.DisplaySweeps(listOfSweeps);
            userInput = UserInterface.GetUserInputFor("Which sweepstakes would you like to register a contestant for?\n\nType 'cancel' to cancel...");
            while (activeSweep == null && userInput != "cancel")
            {
                for (int i = 0; i < listOfSweeps.Count; i++)
                {
                    if (listOfSweeps[i].Name == userInput)
                    {
                        activeSweep = listOfSweeps[i];
                    }
                }
                if (activeSweep == null)
                {
                    UserInterface.DisplaySweeps(listOfSweeps);
                    userInput = UserInterface.GetUserInputFor("Which sweepstakes would you like to register a contestant for?\n\nType 'cancel' to cancel...");
                }
            } 
            if(userInput == "cancel")
            {
                return;
            }
            //Ask if you would like to manually add one or generate random contestants
            do
            {
                userInput = UserInterface.DisplayMenu("What would you like to do?\n\na) Add one contestant\nb) Generate 50 random contestants\nc) Done registering contestants");
                if (Comparer<string>.Default.Compare(userInput, "a") == 0)
                {
                    //Manually add one contestant
                    string firstName = UserInterface.GetUserInputFor("What is the contestant's first name?");
                    string lastName = UserInterface.GetUserInputFor("What is the contestant's last name?");
                    string emailAddress = UserInterface.GetUserInputFor("What is the contestant's email address?");
                    Contestant newContestant = new Contestant(firstName, lastName, emailAddress, idIncrementer++);
                    activeSweep.RegisterContestant(newContestant);
                }
                if (Comparer<string>.Default.Compare(userInput, "b") == 0)
                {
                    RegisterRandomContestants(rng);
                }
            } while (Comparer<string>.Default.Compare(userInput, "c") != 0);
            activeSweep = null;
        }
        public void RegisterRandomContestants(Random rng)
        {
            List<string> listOfNames = new List<string> { "Beckie", "Casimira", "Myesha", "Monika", "Una", "Cesar", "Renae", "Aleisha", "Randy", "Jordon", "Geraldo", "Normand", "Marilu", "Madeline", "Francesco", "Hulda", "Carolyn", "Marline", "Anderson", "Marquitta", "Lupita", "Louella", "Lottie", "Alfonzo", "Yanira", "Rona", "Newton", "Latina", "Vicente", "Migdalia", "Winfred", "Somer", "Raphael", "Shakira", "Ghislaine", "Fiona", "Deanna", "Eldora", "Cinda", "Desmond", "Mistie", "Lashaun", "Dusty", "Tanja", "Christinia", "Rhea", "Marg", "Ashanti", "Filiberto", "Harley" };
            //Register the random contestants
            for (int i = 0; i < 50; i++)
            {
                string firstName = listOfNames[rng.Next(0, 26)];
                string lastName = listOfNames[rng.Next(26, 50)];
                activeSweep.RegisterContestant(new Contestant(firstName, lastName, ""+firstName+"."+lastName+"@gmail.com", idIncrementer++));
            }
        }
    }
}
