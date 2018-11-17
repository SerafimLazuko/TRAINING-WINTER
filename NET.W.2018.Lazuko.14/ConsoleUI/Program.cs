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

            List<Node<string>> list = new List<Node<string>>(3);

            list.Add(node1);
            list.Add(node2);
            list.Add(node3);

            QueueLogic.Queue<string> queue = new QueueLogic.Queue<string>(list);

            foreach (Node<string> node in queue.Nodes)
            {
                Console.WriteLine(node.Data);
            }

            Console.ReadKey();

            Node<string> node6 = new Node<string>("added node 4");

            queue.Enqueue("added node 4");

            Console.WriteLine();

            foreach (Node<string> node in queue.Nodes)
            {
                Console.WriteLine(node.Data);
            }

            Console.ReadKey();

            Console.WriteLine();

            Console.WriteLine("удаление элемента - " +  queue.Dequeue()) ;

            Console.WriteLine();

            foreach (Node<string> node in queue.Nodes)
            {
                Console.WriteLine(node.Data);
            }

            Console.ReadKey();

            Console.WriteLine();

            Console.WriteLine("result of Peek - " + queue.Peek());

            Console.ReadKey();
        }
    }
}
