using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JustineDascil_VedelIT;

namespace UnitTest
{
    [TestClass]
    public class UnitTestProcessor
    {
        [TestMethod]
        public void GetTrivia()
        {
            Processor processor = new Processor();
            processor.GetTriviaFromList();
        }

        [TestMethod]
        public void GetQuote()
        {
            Processor processor = new Processor();
            processor.GetQuoteFromList();
        }

        [TestMethod]
        public void ShowUserSubscriptionDetails()
        {
            Processor processor = new Processor();


            Subscriber triviaSubscriber = new Subscriber();
            Subscriber quoteSubscriber = new Subscriber();

            triviaSubscriber.Listen("Trivia", 0);
            quoteSubscriber.Listen("Quote", 0);
        
            string subscription = "a";

            processor.ShowUserSubscriptionDetails(subscription, triviaSubscriber, quoteSubscriber);
        }
    }
}
