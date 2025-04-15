using System.Security.Cryptography.X509Certificates;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello, World!Greetings from Message Object.");
            myMessage.Print();

            List<Message> messages = new List<Message>();
            messages.Add(new Message("Hello, Zin!"));
            messages.Add(new Message("Hello, Kaung!"));
            messages.Add(new Message("Hello, Show!"));
            messages.Add(new Message("Hello, Khant Thu!Welcome back!"));
            messages.Add(new Message("Hello,Nice to meet you!"));

            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (name.ToLower()=="zin")
            {
                messages[0].Print();
            }
            else if (name.ToLower()=="kaung")
            {
                messages[1].Print();
            }
            else if (name.ToLower()=="show")
            {
                messages[2].Print();
            }
            else if (name.ToLower()=="khantthu")
            {
                messages[3].Print();
            }
            else
            {
                messages[4].Print();
            }
        }
    }
}