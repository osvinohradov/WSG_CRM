using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = $@"./test/test.xml";

            Parser parser = new Parser();
            parser.Load(path);

            parser.Parse();
            Console.ReadKey();
        }
    }
}
