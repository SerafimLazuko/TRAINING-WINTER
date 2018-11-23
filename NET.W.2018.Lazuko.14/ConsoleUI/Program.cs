using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueLogic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueLogic.Queue<string> queue = new QueueLogic.Queue<string>();

            queue.Enqueue("added1");
            queue.Enqueue("added2");
            queue.Enqueue("added3");
            queue.Enqueue("added4");
            queue.Enqueue("added5");
            queue.Enqueue("added6");
            queue.Enqueue("added7");

            Console.WriteLine(queue.Count.ToString() + " elements in queue; ");
            Console.ReadKey();

            foreach(var elem in queue)
            {
                Console.WriteLine("Plugging out " + elem);
            }

            Console.ReadKey();

        }
    }
}
