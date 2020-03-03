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
        int idIncrementer;
        SweepstakesStackManager stack = new SweepstakesStackManager();
        SweepstakesQueueManager queue = new SweepstakesQueueManager();
        List<Sweepstakes> listOfSweeps = new List<Sweepstakes>();
        Sweepstakes activeSweep;
        Contestant sweepWinner;
        //constructor
        public MarketingFirm()
        {
        }
        //member methods
        public void CreateSweepstake()
        {
            //What is the name of the sweepstakes?
            //Read user input
            string nameOfSweeps = UserInterface.GetUserInputFor("What is the name of the sweepstakes?");
            Sweepstakes sweepstakes = new Sweepstakes(nameOfSweeps);
            //Add the sweepstakes to the Stack, Queue, and List
            stack.InsertSweepstakes(sweepstakes);
            listOfSweeps.Add(sweepstakes);
        }
        public void PickAWinner(Random rng)
        {
            if(listOfSweeps.Count < 1)
            {
                return;
            }
            //Which sweepstakes?
            string userInput;
            UserInterface.DisplaySweeps(listOfSweeps);
            userInput = UserInterface.GetUserInputFor("Which sweepstakes would you like to pick a winner for?\n\nType 'cancel' to cancel...");
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
            activeSweep = null;            
        }
        public void RegisterAContestant()
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
                    RegisterRandomContestants();
                }
            } while (Comparer<string>.Default.Compare(userInput, "c") != 0);
            activeSweep = null;
        }
        public void RegisterRandomContestants()
        {
            //Register the contestants

            activeSweep.RegisterContestant(new Contestant("Kyle", "Kuopus", "kkuopus@live.com", idIncrementer++));
            activeSweep.RegisterContestant(new Contestant("Johnny", "Cash", "jcash@gmail.com", idIncrementer++));
            activeSweep.RegisterContestant(new Contestant("Robert", "California", "r.california@yahoo.com", idIncrementer++));
            activeSweep.RegisterContestant(new Contestant("Michael", "Scott", "bestbossever@michaelscottpapercompany.com", idIncrementer++));
            activeSweep.RegisterContestant(new Contestant("Holly", "Flax", "hollyflax@gmail.com", idIncrementer++));
        }
    }
}
