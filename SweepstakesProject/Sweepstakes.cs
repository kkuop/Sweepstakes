using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace SweepstakesProject
{
    public class Sweepstakes
    {
        //member vars
        private Dictionary<int, Contestant> contestants;
        public string Name { get; set; }
        //constructor
        public Sweepstakes(string name)
        {
            Name = name;
            contestants = new Dictionary<int, Contestant>();
        }

        //member methods
        public void RegisterContestant(Contestant contestant)
        {
            //add to dictionary
            contestants.Add(contestant.RegistrationNumber, contestant);
        }
        public Contestant PickWinner(Random rng)
        {
                Contestant winner = contestants[rng.Next(0, contestants.Count)];
            //Observer design patter to notify all other contestants of their loss
            winner.isWinner = true;
                return winner;
        }
        public void PrintContestantInfo(Contestant contestant)
        {
            UserInterface.DisplayWinner(contestant);
        }
        public void SendEmailToWinner(Contestant contestant)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("devCodeCampMailKit@gmail.com"));
            message.To.Add(new MailboxAddress("kkuopus@live.com"));
            message.Subject = $"You are a winner of the {Name} sweepstakes!";
            message.Body = new TextPart("plain")
            {
                Text = $"Hello {contestant.FirstName}," +
                $"You have won the {Name} sweepstakes! Please reply to this email to claim your winnings. "
            };
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate("devCodeCampMailKit", "");

                client.Send(message);
                client.Disconnect(true);
            }
        }
        public void SendEmailToLosers()
        {
            for (int i = 0; i < contestants.Count; i++)
            {
                if (contestants.ElementAt(i).Value.isWinner == false)
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("devCodeCampMailKit@gmail.com"));
                    message.To.Add(new MailboxAddress($"{contestants.ElementAt(i).Value.EmailAddress}"));
                    message.Subject = $"You did not win the {Name} sweepstakes :( ";
                    message.Body = new TextPart("plain")
                    {
                        Text = $"Hello {contestants.ElementAt(i).Value.FirstName}," +
                        $"Unfortunately, you did not win the {Name} sweepstakes. Please try again next time. "
                    };
                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        client.Connect("smtp.gmail.com", 587, false);

                        client.Authenticate("devCodeCampMailKit", "");

                        client.Send(message);
                        client.Disconnect(true);
                    }
                }                
            }
        }
        public bool CheckIfContestantsIsEmpty()
        {
            if(contestants.Count<1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
