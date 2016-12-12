using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace JustineDascil_VedelIT
{
    public class PublisherSubscriber
    {
        static void Main(string[] args)
        {

            Publisher triviaPublisher = new Publisher();
            Publisher quotePublisher = new Publisher();

            Subscriber triviaSubscriber = new Subscriber();
            Subscriber quoteSubscriber = new Subscriber();

            PubSubServer serverPubSub = new PubSubServer();

            Processor processor = new Processor();
            processor.GetUserDetails();

            var subscription = processor.GetUserSubscription();

            triviaPublisher.Send(processor.GetTriviaFromList(), serverPubSub);
            quotePublisher.Send(processor.GetQuoteFromList(), serverPubSub);


            triviaSubscriber.Listen("Trivia", 0);

            quoteSubscriber.Listen("Quote", 0);

            serverPubSub.subscribers[0] = triviaSubscriber;
            serverPubSub.subscribers[1] = quoteSubscriber;
            serverPubSub.Forward();

            processor.ShowUserSubscriptionDetails(subscription, triviaSubscriber, quoteSubscriber);

            Console.ReadLine();
        }
    }
}
