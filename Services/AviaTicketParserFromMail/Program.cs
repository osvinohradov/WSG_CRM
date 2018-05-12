using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using S22.Pop3;
using System.Net.Mail;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using AviaTicketParserFromMail.Entities;
using AviaTicketParserFromMail.DbContext;
using System.Timers;

namespace AviaTicketParserFromMail
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
           // System.Threading.Timer timer = new System.Threading.Timer(MainLogic, null, 0, 40000);
            Console.WriteLine("Start main logic!");
            MainLogic(null);
            Console.ReadKey();
        }

        public static void MainLogic(object sender)
        {
            try
            {
                // Получаем все письма с почтового ящика
                //IEnumerable<MailMessage> messages = GetMessages();
                // Сохраняем полученные файлы во временный каталог
                //SaveMail(messages);

                // Получаем все файлы с информацией об авиа билетах и багаже
                IEnumerable<FileInfo> aviaFiles = GetFiles("electronic ticket");
                IEnumerable<FileInfo> baggageFiles = GetFiles("baggage");

                Parser parser = new Parser();

                AviaTicket ticket = null;
                AviaBaggage baggage = null;

                foreach (FileInfo item in aviaFiles)
                {
                    try
                    {
                        ticket = parser.ParseAviaTicket(item.FullName);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(item.FullName);
                    }

                    using (MailDb db = new MailDb())
                    {
                        var query = from t in db.Tickets
                                    where t.TicketNumber == ticket.TicketNumber
                                    select t;

                        if (query.Count() == 0)
                        {
                            db.Tickets.Add(new Ticket() { TicketNumber = ticket.TicketNumber, Agent = ticket.Agent });
                            db.SaveChanges();
                            SaveFileToXML(ticket);
                        }
                    }
                }

                foreach (FileInfo item in baggageFiles)
                {
                    try
                    {
                        baggage = parser.ParseAviaBaggage(item.FullName);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(item.FullName);
                    }


                    using (MailDb db = new MailDb())
                    {
                        var query = from b in db.Baggages
                                    where b.BaggageNumber == baggage.No
                                    select b;

                        if (query.Count() == 0)
                        {
                            db.Baggages.Add(new Baggage() { BaggageNumber = baggage.No });
                            db.SaveChanges();
                            SaveFileToXML(baggage);
                        }
                    }
                }

                Console.WriteLine("End parsing!");
                DirectoryInfo tempFolder = new DirectoryInfo(@".\AviaTicketsFromMail");
                try
                {
                    //tempFolder.Delete(true);
                }
                catch (Exception ex) { }
            }
            catch (Exception ex)
            {
                string str = $"Date: {DateTime.Now}\nError: {ex.Message}\nStackTrace: {ex.StackTrace}";
                using (StreamWriter writer = new StreamWriter(@"error.log", true, Encoding.UTF8))
                {
                    writer.WriteLine(str);
                }
            }
        }

        public static IEnumerable<MailMessage> GetMessages()
        {
            Pop3Client pop3Client = new Pop3Client("mail.worldservice.ua");

            try
            {
                pop3Client.Login("ps@worldservice.ua", "0Z7w8K6h", AuthMethod.Login);
                Console.WriteLine("Подключенно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("В процессе подключения к серверу произошла ошибка. Проверте подключение к интернету, или обратитесь к системному администратору.");
                Console.WriteLine(ex.Message);
                throw ex;
            }

            IEnumerable<MailMessage> messages = pop3Client.GetMessages();

            return messages;
        }

        public static void SaveMail(IEnumerable<MailMessage> messageCollection)
        {
            if (messageCollection == null)
                throw new NullReferenceException();

            string path = @".\AviaTicketsFromMail";
            DirectoryInfo tempFolder = new DirectoryInfo(path);

            if (!tempFolder.Exists)
            {
                tempFolder.Create();
            }

            foreach (MailMessage msg in messageCollection)
            {
                string chooise = msg.Subject.ToLower().Replace(':', ' ');

                if (string.IsNullOrEmpty(chooise))
                {
                    chooise = "no subject";
                    continue;
                }


                foreach (Attachment attachment in msg.Attachments)
                {
                    FileStream stream = new FileStream($@"{tempFolder.FullName}\{chooise}_{Guid.NewGuid()}_{attachment.Name}", FileMode.Create);
                    attachment.ContentStream.CopyTo(stream);
                }
            }
        }

        /// <summary>
        /// Метод возвращает коллекцию файлов по заданому шаблону в имени файла.
        /// </summary>
        /// <param name="pattern">Шаблон для имени файла.</param>
        /// <param name="path">Маршрут поиска файлов.</param>
        /// <returns>Коллекция файлов.</returns>
        public static IEnumerable<FileInfo> GetFiles(string pattern, string path = @".\AviaTicketsFromMail")
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            // return files by pattern
            return dir.GetFiles().Where(f => f.Name.Contains(pattern));
        }

        public static void SaveFileToXML(AviaBaggage baggage)
        {
            DirectoryInfo dir = new DirectoryInfo(@".\XmlFiles");

            if (!dir.Exists)
            {
                dir.Create();
            }
            var date = DateTime.Now;

            string path = string.Format(@"{0}\{1}.{2}.{3} {4}.{5}.{6}_Baggage.xml", dir.FullName, date.Day, date.Month, date.Year, date.Hour, date.Minute, date.Millisecond);

            using (FileStream stream = new FileStream(path, FileMode.CreateNew))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(AviaBaggage));

                xmlSerializer.Serialize(stream, baggage);
            }

        }

        public static void SaveFileToXML(AviaTicket ticket)
        {
            DirectoryInfo dir = new DirectoryInfo(@".\XmlFiles");

            if (!dir.Exists)
            {
                dir.Create();
            }
            var date = DateTime.Now;

            string path = string.Format(@"{0}\{1}.{2}.{3} {4}.{5}.{6}.xml", dir.FullName, date.Day, date.Month, date.Year, date.Hour, date.Minute, date.Millisecond);

            using (FileStream stream = new FileStream(path, FileMode.CreateNew))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(AviaTicket));

                xmlSerializer.Serialize(stream, ticket);
            }

        }
    }
}
