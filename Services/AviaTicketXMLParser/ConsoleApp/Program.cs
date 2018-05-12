using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Entities.AviaTicket;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new AviaTicketXMLParser().ParseTicket("test.xml");

            Console.ReadLine();
        }
    }
}
