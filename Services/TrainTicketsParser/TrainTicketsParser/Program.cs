using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Console.WriteLine("Changes saved");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Object: " + validationError.Entry.Entity.ToString());

                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Console.WriteLine(err.ErrorMessage + " ");
                        }
                }
            }


            Console.ReadKey();
        }
    }
}
