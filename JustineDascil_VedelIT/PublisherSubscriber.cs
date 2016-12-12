using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustineDascil_VedelIT
{
     
    public class Publisher
    {
        public Publisher()
        {
        }

        public void Send(Message newMessage, PubSubServer myServer)
        {
            myServer.buffer.Enqueue(newMessage);
        }
    };

    public class Subscriber
    {
        public Subscriber()
        {
        }
        public string[] topics = new string[2];
        public Queue<Message> myMessages = new Queue<Message>();

        public void Listen(string newTopic, int index)
        {
            topics[index] = newTopic;
        }

        public void Print()
        {
            for (int x = 0; x < topics.Length; x++)
            {
                while (myMessages.Count != 0)
                {
                    Message newMessage = myMessages.Dequeue();
                    Console.WriteLine("\n\nTopic: " + newMessage.topic + "\n" + newMessage.payload);
                }
            }

            Console.Write("Press any key to continue...");
        }
    };

    public class Message
    {
        public Message()
        {
        }

        public string payload;
        public string topic;
    }

    public class PubSubServer
    {
        public PubSubServer()
        {
        }

        public Queue<Message> buffer = new Queue<Message>();
        public Subscriber[] subscribers = new Subscriber[2];

        public void Forward()
        {
            while (buffer.Count != 0)
            {
                Message tempMessage = buffer.Dequeue();
                for (int x = 0; x < subscribers.Length; x++)
                {
                    for (int y = 0; y < subscribers[x].topics.Length; y++)
                    {
                        if (tempMessage.topic == subscribers[x].topics[y])
                        {
                            subscribers[x].myMessages.Enqueue(tempMessage);
                        }
                    }
                }
            }
        }
    };
}
