using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TrainTicketsParser.Model;
using TrainTicketsParser.Infrastructure;

namespace TrainTicketsParser
{
    public class Parser
    {
        private XmlDocument document = null;
        private Invoice invoice = null;

        public void Load(string path)
        {
            try
            {
                if (path == null)
                {
                    throw new NullReferenceException($"Параметер path не может быть равным null.");
                }
                using (FileStream streamReader = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    document = new XmlDocument();
                    document.Load(streamReader);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Возникла ошибка при открытии файла. Файл не найден.");
                ErrorReporter.WriteReportToFile($"Возникла ошибка при открытии файла. Файл не найден.\n{ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Ошибка открытия файла.");
                ErrorReporter.WriteReportToFile($"Ошибка открытия файла.\n[{ex.Message}]");
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"При загрузке документа произошла ошибка.");
                ErrorReporter.WriteReportToFile($"При загрузке документа произошла ошибка.\n{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка.");
                ErrorReporter.WriteReportToFile($"Произошла непредвиденная ошибка.\n{ex.Message}");
            }
        }

        public Invoice Parse()
        {
            invoice = new Invoice();
            invoice.InvoiceId = Guid.NewGuid();
            try
            {
                invoice.Id = Int64.Parse(GetSingleValue("id"));
                invoice.OuterId = Int32.Parse(GetSingleValue("outer_id"));
                invoice.SalePointName = GetSingleValue("sale_point_name");
                invoice.AspsCode = GetSingleValue("asps_code");
                invoice.AspsCode2 = GetSingleValue("asps_code_2");
                invoice.State = Int32.Parse(GetSingleValue("state"));
                
                invoice.IsElectronic = GetSingleValue("is_electronic") == "1" ? true : false;
                invoice.CreationTime = DateTime.Parse(GetSingleValue("creation_time"));
                invoice.OwnerEmail = GetSingleValue("owner_email");
                invoice.OwnerPhone = GetSingleValue("owner_phone");

                invoice.Travels = GetTravelObject();
                invoice.SoldSeat = GetSoldSeat();
                invoice.Price = GetPrice();
                invoice.CounterPart = GetCounterPart();

                invoice.OwnerId = Int32.Parse(GetSingleValue("owner_id"));
                invoice.BoardingPass = Int32.Parse(GetSingleValue("boarding_pass"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"В процессе обработки XML документа произошла ошибка.");
                ErrorReporter.WriteReportToFile($"В процессе обработки XML документа произошла ошибка.\n{ex.Message}");
            }
            return invoice;
        }

        private string GetSingleValue(string name)
        {
            return this.document.GetElementsByTagName(name).Item(0).InnerText;
        }

        private Travel GetTravelObject()
        {
            Travel travel = new Travel();
            travel.TravelId = Guid.NewGuid();
            travel.Invoice = invoice;
            try
            {
                XmlNode element = this.document.GetElementsByTagName("travel").Item(0);
                string departureDate = "";
                string arrivalDate = "";
                foreach (XmlNode item in element.ChildNodes)
                {
                    if (item.Name == "dep_date" || item.Name == "src_dep")
                    {
                        departureDate += item.InnerText + " ";
                    }
                    else if (item.Name == "arr_date" || item.Name == "dst_arr")
                    {
                        arrivalDate += item.InnerText + " ";
                    }

                    switch (item.Name)
                    {
                        case "guididx":
                            {
                                travel.GuidIdx = Guid.Parse(item.InnerText);
                                break;
                            }
                        case "src":
                            {
                                Src src = new Src();
                                foreach (XmlNode srcNodes in item.ChildNodes)
                                {
                                    if (srcNodes.Name == "idx")
                                        src.Idx = Int64.Parse(srcNodes.InnerText);
                                    else if (srcNodes.Name == "name")
                                        src.Name = srcNodes.InnerText;
                                }
                                travel.Src = src;
                                break;
                            }
                        case "dst":
                            {
                                Dst dst = new Dst();
                                foreach (XmlNode dstNodes in item.ChildNodes)
                                {
                                    if (dstNodes.Name == "idx")
                                        dst.Idx = Int64.Parse(dstNodes.InnerText);
                                    else if (dstNodes.Name == "name")
                                        dst.Name = dstNodes.InnerText;
                                }
                                travel.Dst = dst;
                                break;
                            }
                        case "transport_type":
                            {
                                travel.TransportType = Int32.Parse(item.InnerText);
                                break;
                            }
                        case "duration":
                            {
                                travel.Duration = item.InnerText;
                                break;
                            }
                        case "trip":
                            {
                                Trip trip = new Trip();
                                trip.TripId = Guid.NewGuid();
                                foreach (XmlNode tripNodes in item.ChildNodes)
                                {
                                    if (tripNodes.Name == "id")
                                    {
                                        trip.Id = tripNodes.InnerText;
                                    }
                                    else if (tripNodes.Name == "src")
                                    {
                                        Src src = new Src();
                                        foreach (XmlNode srcNodes in tripNodes.ChildNodes)
                                        {
                                            if (srcNodes.Name == "idx")
                                                src.Idx = Int64.Parse(srcNodes.InnerText);
                                            else if (srcNodes.Name == "name")
                                                src.Name = srcNodes.InnerText;
                                        }
                                        trip.Src = src;
                                    }
                                    else if (tripNodes.Name == "dst")
                                    {
                                        Dst dst = new Dst();
                                        foreach (XmlNode dstNodes in tripNodes.ChildNodes)
                                        {
                                            if (dstNodes.Name == "idx")
                                                dst.Idx = Int64.Parse(dstNodes.InnerText);
                                            else if (dstNodes.Name == "name")
                                                dst.Name = dstNodes.InnerText;
                                        }
                                        trip.Dst = dst;
                                    }
                                    else if (tripNodes.Name == "transporter")
                                    {
                                        trip.Transporter = tripNodes.InnerText;
                                    }
                                    else if (tripNodes.Name == "state")
                                    {
                                        trip.State = Int32.Parse(tripNodes.InnerText);
                                    }
                                    else if (tripNodes.Name == "el")
                                    {
                                        trip.El = Int32.Parse(tripNodes.InnerText);
                                    }
                                    else if (tripNodes.Name == "boarding_pass")
                                    {
                                        trip.BoardingPass = Int32.Parse(tripNodes.InnerText);
                                    }
                                }
                                trip.Travel = travel;
                                travel.Trips = trip;
                                break;
                            }
                    }
                }

                travel.ArrivalDateTime = DateTime.Parse(arrivalDate);
                travel.DepartureDateTime = DateTime.Parse(departureDate);
                travel.Invoice = invoice;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при парсинге элемента Travel.");
                throw ex;
            }
            return travel;
        }

        private SoldSeat GetSoldSeat()
        {
            SoldSeat soldSeat = new SoldSeat();
            soldSeat.SoldSeatId = Guid.NewGuid();
            XmlNode elements = this.document.GetElementsByTagName("sold_seats").Item(0);
            foreach (XmlNode element in elements)
            {
                switch (element.Name)
                {
                    case "passenger":
                        {
                            Passenger passenger = new Passenger();
                            foreach (XmlNode item in element.ChildNodes)
                            {
                                switch (item.Name)
                                {
                                    case "name":
                                        {
                                            passenger.Name = item.InnerText;
                                            break;
                                        }
                                    case "surname":
                                        {
                                            passenger.Surname = item.InnerText;
                                            break;
                                        }
                                }
                            }
                            soldSeat.Passenger = passenger;
                            break;
                        }
                    case "id":
                        {
                            soldSeat.Id = Int32.Parse(element.InnerText);
                            break;
                        }
                    case "car_id":
                        {
                            soldSeat.CarId = Int32.Parse(element.InnerText);
                            break;
                        }
                    case "tos_id":
                        {
                            soldSeat.TosId = Int32.Parse(element.InnerText);
                            break;
                        }
                    case "price":
                        {
                            Price price = new Price();
                            price.PriceId = Guid.NewGuid();
                            var articles = new HashSet<Article>();
                            foreach (XmlNode item in element.ChildNodes)
                            {
                                if (item.Name == "total")
                                {
                                    price.Total = Int32.Parse(item.InnerText);
                                }
                                else if (item.Name == "tax")
                                {
                                    price.Tax = Int32.Parse(item.InnerText);
                                }
                                else if (item.Name == "articles")
                                {
                                    Article article = new Article();
                                    article.ArticleId = Guid.NewGuid();
                                    foreach (XmlNode art in item.ChildNodes)
                                    {
                                        if (art.Name == "code")
                                        {
                                            article.Code = Int32.Parse(art.InnerText);
                                        }
                                        else if (art.Name == "name")
                                        {
                                            article.Name = art.InnerText;
                                        }
                                        else if (art.Name == "price")
                                        {
                                            article.PriceField = Double.Parse(art.InnerText);
                                        }                                        
                                    }
                                    article.Price = price;
                                    articles.Add(article);
                                }
                            }
                            price.Articles = articles;
                            price.SoldSeats = soldSeat;
                            soldSeat.Price = price;                            
                            break;
                        }
                }
            }
            soldSeat.Invoices = invoice;
            return soldSeat;
        }

        private Price GetPrice()
        {
            Price price = new Price();
            price.PriceId = Guid.NewGuid();
            var articles = new HashSet<Article>();
            try
            {
                XmlNode elements = this.document.GetElementsByTagName("price").Item(0);
                foreach (XmlNode element in elements)
                {
                    if (element.Name == "total")
                    {
                        price.Total = Int32.Parse(element.InnerText);
                    }
                    else if (element.Name == "tax")
                    {
                        price.Tax = Int32.Parse(element.InnerText);
                    }
                    else if (element.Name == "articles")
                    {
                        Article article = new Article();
                        article.ArticleId = Guid.NewGuid();
                        foreach (XmlNode art in element.ChildNodes)
                        {
                            if (art.Name == "code")
                            {
                                article.Code = Int32.Parse(art.InnerText);
                            }
                            else if (art.Name == "name")
                            {
                                article.Name = art.InnerText;
                            }
                            else if (art.Name == "price")
                            {
                                article.PriceField = Double.Parse(art.InnerText);
                            }                            
                        }
                        article.Price = price;
                        articles.Add(article);
                    }
                }
                price.Articles = articles;                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при парсинге элемента Price.");
                throw ex;
            }
            price.Invoices = invoice;
            return price;
        }

        private CounterPart GetCounterPart()
        {
            CounterPart counterPart = new CounterPart();
            counterPart.CounterPartId = Guid.NewGuid();
            try
            {
                XmlNode element = this.document.GetElementsByTagName("counterparts").Item(0);
                foreach (XmlNode item in element.ChildNodes)
                {
                    if (item.Name == "transporter")
                    {
                        Transporter transporter = new Transporter();
                        foreach (XmlNode trans in item.ChildNodes)
                        {
                            if (trans.Name == "name")
                                transporter.Name = trans.InnerText;
                            else if (trans.Name == "text")
                                transporter.Text = trans.InnerText;
                        }
                        counterPart.Transporter = transporter;
                    }
                    else if (item.Name == "insurer")
                    {
                        Insurer insurer = new Insurer();
                        foreach (XmlNode insere in item.ChildNodes)
                        {
                            if (insere.Name == "name")
                                insurer.Name = insere.InnerText;
                            else if (insere.Name == "text")
                                insurer.Text = insere.InnerText;
                        }
                        counterPart.Insurer = insurer;
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при парсинге элемента CounterParts.");
                throw ex;
            }
            counterPart.Invoices = invoice;
            return counterPart;
        }
    }
}