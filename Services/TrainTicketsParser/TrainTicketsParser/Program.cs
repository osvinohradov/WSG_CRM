using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketsParser.Infrastructure;
using TrainTicketsParser.Model;

namespace TrainTicketsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = $@"./test/test.xml";

            Parser parser = new Parser();
            parser.Load(path);

            Invoice invoice = parser.Parse();

            TrainTicketXmlModelContainer db = new TrainTicketXmlModelContainer();
            db.Invoices.Add(invoice);
            try
            {
                db.SaveChanges();
                Console.WriteLine($"Бiлет з номером {invoice.Id} збережено.");
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine($"");
                ErrorReporter.WriteReportToFile($"");
            }
            Console.ReadKey();
        }
    }
}
