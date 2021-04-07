using System;

namespace CustomerInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string question1 = "What is your favorite color ?";
            string question2 = "What is your favorite season?";
            string question3 = "Who would you rather talk to(your mother, your father, a stranger, aliens)";
            string question4 = "Which would you rather be(wealthy, popular, accommodating, an alien)";
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
            double discount = 0;
            int daysUntilBirthday;
            if (DateTime.Today.CompareTo(formatBday) < 0)
            {
                //bday this year is in future
                daysUntilBirthday = (formatBday - DateTime.Today).Days;
            }
            else if (DateTime.Today.CompareTo(formatBday) > 0)
            {
                daysUntilBirthday = (formatBday.AddYears(1) - DateTime.Today).Days;
            }
            else
            {
                daysUntilBirthday = 0;
            }
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
                    break;
                }
                Console.WriteLine(question1);
                string answer1 = Console.ReadLine();
                switch (answer1.ToLower().Trim())
                {
                    case "red":
                        survey += 8;
                        break;
                    case "blue":
                        survey += 3;
                        break;
                    case "yellow":
                        survey += 6;
                        break;
                    case "purple":
                        survey += 1;
                        break;
                    case "black":
                        survey += 0;
                        break;
                    case "white":
                        survey += 0;
                        break;
                    default:
                        survey += 5;
                        break;
                }

                Console.WriteLine(question2);
                string answer2 = Console.ReadLine();
                switch (answer2.ToLower().Trim())
                {
                    case "summer":
                        survey += 4;
                        break;
                    case "spring":
                        survey += 9;
                        break;
                    case "winter":
                        survey += 2;
                        break;
                    case "fall":
                        survey += 11;
                        break;
                    default:
                        survey += 1;
                        break;
                }
                bool validAnswer = false;
                string answer3 = "";
                while (validAnswer == false)
                {
                    Console.WriteLine(question3);
                    answer3 = Console.ReadLine();
                    answer = answer3.ToLower().Trim();
                    string[] words = answer.Split();

                    switch (words[words.Length - 1])
                    {
                        case "mother":
                            survey += 1;
                            validAnswer = true;
                            break;
                        case "father":
                            survey += 3;
                            validAnswer = true;
                            break;
                        case "stranger":
                            survey += 8;
                            validAnswer = true;
                            break;
                        case "aliens":
                            survey += 22;
                            validAnswer = true;
                            break;
                        default:
                            Console.WriteLine("Not sure what you mean.");
                            break;
                    }
                }
                validAnswer = false;
                string answer4 = "";
                while (validAnswer == false)
                {
                    Console.WriteLine(question4);
                    answer4 = Console.ReadLine();
                    answer = answer4.ToLower().Trim();
                    string[] words2 = answer.Split();

                    switch (words2[words2.Length - 1])
                    {
                        case "wealthy":
                            survey += 7;
                            validAnswer = true;
                            break;
                        case "popular":
                            survey += 2;
                            validAnswer = true;
                            break;
                        case "accommodating":
                            survey += 10;
                            validAnswer = true;
                            break;
                        case "alien":
                            survey += 22;
                            validAnswer = true;
                            break;
                        default:
                            Console.WriteLine("Not sure what you mean.");
                            break;
                    }
                }

                string recommendedProduct = "";
                if (survey > 50)
                {
                    recommendedProduct = "A full-sized black and white copy of Van Gogh’s “Starry Night.”";
                }
                else if (survey > 40)
                {
                    recommendedProduct = "Pickled elephant skull";
                }
                else if (survey > 30)
                {
                    recommendedProduct = "Lightening in a jar";
                }
                else if (survey > 20)
                {
                    recommendedProduct = "Ben Franklin bowling pin";
                }
                else if (survey > 10)
                {
                    recommendedProduct = "Bottle opener shaped bottle opener";

                }
                else if (survey > 0)
                {
                    recommendedProduct = "Shoes made of Swiss Cheese";
                }
                Console.WriteLine($"Thank you very much {nickname} for stopping by and taking our survey!" +
                    $"We have a product recommendation for you based on your answers to the following questions.");
                Console.WriteLine($"{question1}: {answer1}");
                Console.WriteLine($"{question2}: {answer2}");
                Console.WriteLine($"{question3}: {answer3}");
                Console.WriteLine($"{question4}: {answer4}");

                Console.WriteLine($"Your answers have convinces us you would probably enjoy a {recommendedProduct}.");

                if (discount > 0)
                {
                    Console.WriteLine($"Don't forget you still have a {discount * 100}% discount you can use.");

                    if (daysUntilBirthday < 15)
                    {

                        Console.WriteLine($"If you don't already have one, you should consider buying one for your birthday in {daysUntilBirthday} days.");

                    }
                }
                else
                {
                    Console.WriteLine($"If you don't already have one, you should consider buying one");
                }
                Console.WriteLine("Thanks for shopping! Goodbye");
                break;
            }
        }
    }
}

