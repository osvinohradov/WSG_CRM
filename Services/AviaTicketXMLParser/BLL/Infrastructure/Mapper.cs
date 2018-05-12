using BLL.Entities.AviaTicket;
using BLL.Entities.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Infrastructure
{
    internal class Mapper
    {
        private AviaTicket ticket;
        private AviaInvoice invoice;
        public Mapper(AviaTicket ticket)
        {
            this.ticket = ticket;
        }

        public AviaInvoice Map()
        {
            this.invoice = new AviaInvoice();
            this.invoice.LastTransactionDate = DateTime.Parse(this.ticket.LastTransactionDate.Last());
            this.invoice.PMCode = this.ticket.AgentSignBooking;
            this.invoice.BookingCode = this.ticket.RecordLocator;
            this.invoice.FullName = this.ticket.NameElement.First().LastName + " " + this.ticket.NameElement.First().FirstName;
            this.invoice.TicketNumber = this.ticket.NameElement.First().Ticket.First().No;
            this.invoice.PaymentDate = DateTime.Parse(this.ticket.LastTransactionDate.Last()).Date;
            this.invoice.ProviderAmountSum = this.ticket.NameElement.First().Ticket.First().FareEquiv;
            this.invoice.ProviderAmountMPE = 0; // 
            this.invoice.ProviderAmountCurrency = this.ticket.NameElement.First().Ticket.First().DocCurrency;
            this.invoice.OtherServiceSum = this.ticket.NameElement.First().Ticket.First().TaxTotal;
            this.invoice.OtherServiceMPE = 0; // 

            this.invoice.TotalSum = 0; // Стоимость поставщика + Дополнительна комиссия поставщика + услуги агенции + другие услуги
            
            List<AviaInvoiceFlight> flights = new List<AviaInvoiceFlight>();
            List<AviaInvoiceTicket> tickets = new List<AviaInvoiceTicket>();
            foreach (var ne in this.ticket.NameElement)
            {
                foreach (Ticket ticket in ne.Ticket)
                {
                    AviaInvoiceTicket t = new AviaInvoiceTicket();
                    t.TicketNumber = ticket.No;
                    t.FullName = $"{ne.LastName} {ne.FirstName}";

                    foreach (AirSegment segment in ticket.AirSegment)
                    {
                        AviaInvoiceFlight flight = new AviaInvoiceFlight();
                        flight.FlightNumber = segment.ServiceCarrier +" " + segment.FlightNo;
                        flight.ArrivalPlace = segment.OrigAirport.AmaName;
                        flight.DeliveryPlace = segment.DestAirport.AmaName;
                        flight.ServiceKind = segment.AirClass;
                        flight.ArrivalDate = DateTime.Parse($"{segment.ArrivalDate} {segment.ArrivalTime}");
                        flight.DeliveryDate = DateTime.Parse($"{segment.DepartureDate} {segment.DepartureTime}");
                        flights.Add(flight);
                    }
                    tickets.Add(t);
                }
            }
            this.invoice.Tickets = tickets;
            this.invoice.Flights = flights;

            return this.invoice;
        }
    }
}
