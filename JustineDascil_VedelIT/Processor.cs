using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JustineDascil_VedelIT
{
    public class Processor: IProcessor
    {

        #region GetUserDetails
        public void GetUserDetails()
        {
            try
            {
                Console.Write("\n================================================");
                Console.Write("\n|   PUBLISHER/SUBSCRIBER DESIGN PATTERN SAMPLE |");
                Console.Write("\n================================================");
                Console.Write("\n\nPlease enter your name: ");
                string name = Console.In.ReadLine();
                Console.WriteLine("Hello, " + name + ", please choose on what topic do you wish to subscribe");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region GetUserSubscription
        public string GetUserSubscription()
        {
            string choice = string.Empty;
            char option;

            try
            {
                bool valid = false;

                Console.WriteLine("::::::::::::::::::::::::::::::::::");
                Console.WriteLine(": [a] Trivia of the day            :\n" +
                                  ": [b] Quote of the day             :\n" +
                                  ": [c] Both [a] and [b]             :\t");

                do
                {
                    choice = Console.ReadLine();
                    option = choice.FirstOrDefault();
                    if (!Regex.IsMatch(choice, "^[a-c]+$", RegexOptions.IgnoreCase))
                        Console.WriteLine("Invalid Input. Please try again.");
                } while (!Regex.IsMatch(choice, "^[a-c]+$", RegexOptions.IgnoreCase));
            }
            catch (Exception)
            {

                throw;
            }

            return choice;
        }
        #endregion


        #region GetTriviaFromList
        public Message GetTriviaFromList()
        {
            try
            {
                List<Message> triviaList = new List<Message>();

                Message scienceTrivia = new Message();
                scienceTrivia.topic = "Trivia";
                scienceTrivia.payload = "Half your body’s red blood cells are replaced every seven days.";

                Message computerTrivia = new Message();
                computerTrivia.topic = "Trivia";
                computerTrivia.payload =
                    " The first hard disk drive was created in 1979 by Seagate. Its capacity was a whopping (not) 5 MB.";


                Message worldTrivia = new Message();
                worldTrivia.topic = "Trivia";
                worldTrivia.payload = "The world has only 3% fresh water.";

                triviaList.Add(scienceTrivia);
                triviaList.Add(computerTrivia);
                triviaList.Add(worldTrivia);

                Random rnd = new Random();

                int r = rnd.Next(triviaList.Count);

                return ((Message)triviaList[r]);


            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region GetQuoteFromList
        public Message GetQuoteFromList()
        {
            try
            {
                List<Message> quotesList = new List<Message>();

                Message loveQuote = new Message();
                loveQuote.topic = "Quote";
                loveQuote.payload = "There is only one happiness in this life, to love and be loved. - George Sand";

                Message lifeQuote = new Message();
                lifeQuote.topic = "Quote";
                lifeQuote.payload = "Do not take life too seriously. You will never get out of it alive. - Elbert Hubbard";

                Message inspirationalQuote = new Message();
                inspirationalQuote.topic = "Quote";
                inspirationalQuote.payload = " The biggest adventure you can take is to live the life of your dreams. - Oprah Winfrey";

                quotesList.Add(loveQuote);
                quotesList.Add(lifeQuote);
                quotesList.Add(inspirationalQuote);

                Random rnd = new Random();

                int r = rnd.Next(quotesList.Count);

                return ((Message)quotesList[r]);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region ShowUserSubscriptionDetails
        public void ShowUserSubscriptionDetails(string subscription, Subscriber trivia, Subscriber quote)
        {
            if (subscription == "a" || subscription == "A")
            {
                Console.WriteLine("\nYou have subscribed to the following messages:");
                trivia.Print();

            }
            else if (subscription == "b" || subscription == "B")
            {
                Console.WriteLine("\nYou have subscribed to the following messages:");
                quote.Print();
            }
            else if (subscription == "c" || subscription == "C")
            {
                Console.WriteLine("\nYou have subscribed to the following messages:");
                trivia.Print();
                quote.Print();
            }
        }
        #endregion
    }
}
