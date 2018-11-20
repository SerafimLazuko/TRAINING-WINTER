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
            Node<string> node1 = new Node<string>("node1");
            Node<string> node2 = new Node<string>("node2");
            Node<string> node3 = new Node<string>("node3");
            

            QueueLogic.Queue<string> queue = new QueueLogic.Queue<string>();

            queue.Enqueue(node1.Data);
            queue.Enqueue(node2.Data);
            queue.Enqueue(node3.Data);

            foreach (var node in queue)
            {
                Console.WriteLine(node);
            }

            Console.ReadKey();

            Node<string> node4 = new Node<string>("added node 4");

            queue.Enqueue(node4.Data);

            Console.WriteLine();

            foreach (var node in queue)
            {
                Console.WriteLine(node);
            }

            Console.ReadKey();

            Console.WriteLine();

            Console.WriteLine("удаление элемента - " + queue.Dequeue());

            Console.WriteLine();

            foreach (var node in queue)
            {
                Console.WriteLine(node);
            }

            Console.ReadKey();

            Console.WriteLine();

            Console.WriteLine("result of Peek - " + queue.Peek());

            Console.ReadKey();
        }
    }
}
