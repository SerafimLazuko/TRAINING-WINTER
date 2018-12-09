using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No4.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            FileGenerator fg1 = new RandomBytesFileGenerator();

            fg1.GenerateFiles(1, 10);

            System.Console.WriteLine(fg1.ReadBytesFromFile(fg1.FileName));

            System.Console.ReadKey();


            FileGenerator fg2 = new RandomCharsFileGenerator();

            fg2.GenerateFiles(1, 10);

            System.Console.WriteLine(fg2.ReadBytesFromFile(fg2.FileName));
            
            System.Console.ReadKey();
        }
    }
}
