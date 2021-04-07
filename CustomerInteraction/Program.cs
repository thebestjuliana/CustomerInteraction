using System;

namespace CustomerInteraction
{
    class Program
    {
        static void Main(string[] args)
        {

            bool exit = false;

            // The system should greet the user and get the following critical pieces of information
            //• Customer’s full name
            //• Customer’s preferred nickname.If they don’t have a nickname, default to their first name.
            //• Customer’s birthday month and day, it’s rude to ask for the year
            //• Customer’s country of residence.
            Console.WriteLine("Welcome to the 'let's figure something you'd like' program");

            Console.WriteLine("What's your name?");
            string customerFullName = Console.ReadLine();
            string customerFirstName = customerFullName.Split()[0];
            Console.WriteLine("Do you have a preferred nickname? Y/N");
            string answer = Console.ReadLine();
            string nickname;
            switch (answer.ToLower())
            {
                case "y":
                case "yes":
                    Console.WriteLine("What is your preferred nickname?");
                    nickname = Console.ReadLine();
                    break;

                default:
                    nickname = customerFirstName;

                    break;

            }
            Console.WriteLine($"I'll call you {nickname}.");
            bool validBday = false;
            DateTime formatBday = new DateTime();
            while (validBday == false)
            {
                Console.WriteLine("What's your birthday? (Month and Day)");
                string birthday = Console.ReadLine();
                int thisYear = DateTime.Now.Year;
                birthday += $" {thisYear}";

                validBday = DateTime.TryParse(birthday, out formatBday);

                if (validBday == false)
                {
                    Console.WriteLine("I don't think that's quite right");
                }

            }
            double discount;

            if (formatBday == DateTime.Today)
            {
                Console.WriteLine("Happy Birthday!! As our gift to you, you will receive 15% off of today's order");
                discount = .15;
            }
            else if (formatBday < DateTime.Now && formatBday >= DateTime.Now.Subtract(TimeSpan.FromDays(14)))
            {
                Console.WriteLine("Happy belated Birthday! Our belated birthday present to you is 8% off of your order today!");
                discount = .08;
            }
            else if (formatBday > DateTime.Now && formatBday < DateTime.Now.AddDays(14))
            {
                Console.WriteLine("Your birthday is soon! Come back on your birthday for 15% off anything ordered on your birthday or 8% off anything you order during the following 2 weeks!");
            }
            Console.WriteLine("What country are you from?");

            string userCountry = Console.ReadLine();
            double shippingCost;
            switch (userCountry.ToLower())
            {
                case "us":
                case "usa":
                case "canada":
                case "australia":
                    shippingCost = 0;
                    break;
                //If they live in India, Germany, Brazil, or Madagascar,
                //the charge for shipping is $289.
                case "india":
                case "germany":
                case "brazil":
                case "madagascar":
                    shippingCost = 289;
                    break;
                default:
                    //Anywhere else has a shipping charge of $12.43.
                    shippingCost = 12.43;
                    break;
            }
            Console.WriteLine($"The cost for shipping is {shippingCost:c}.");
            Console.WriteLine("Would you like to take a survey to receive product suggestions? (if no-you'll be directed to exit)");

            answer = Console.ReadLine();
            while (exit == false)
            {
                int survey = 0;
                if (answer.ToLower() == "n" || answer.ToLower() == "no")
                {
                    Console.WriteLine("Goodbye!");
                    exit = true;

                }

            }
        }
    }
}
