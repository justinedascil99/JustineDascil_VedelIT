using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustineDascil_VedelIT
{
    public interface IProcessor
    {
        void GetUserDetails();
        string GetUserSubscription();
        Message GetTriviaFromList();
        Message GetQuoteFromList();
        void ShowUserSubscriptionDetails(string subscription, Subscriber triviaSubscriber, Subscriber quoteSubscriber );

    }
}
