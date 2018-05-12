using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketsParser.Infrastructure
{
    public static class ErrorReporter
    {
        public static void WriteReportToFile(string report)
        {
            using(StreamWriter writer = new StreamWriter($"./Report.log", true, Encoding.UTF8))
            {
                writer.WriteLine(report);
                writer.WriteLine(Environment.NewLine);
            }
        }
    }
}
