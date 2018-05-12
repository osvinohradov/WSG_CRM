using AutoMapper;
using System;
using System.Collections.Generic;
using WSG.BAL.DTO;
using WSG.BAL.Infrastructure;
using WSG.BAL.Interfaces;
using WSG.DAL.Infrastructure;
using WSG.DAL.Models.Avia;

namespace WSG.BAL.Services
{
    public class AviaInvoiceService : IAviaInvoiceService
    {
        IUnitOfWork Database { get; set; }

        public AviaInvoiceService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeInvoice(AviaInvoiceDTO invoiceDto)
        {
            AviaInvoiceTicket ticket = Database.AviaInvoiceTicket.Get(invoiceDto.InvoiceId);
            AviaInvoiceFlight flight = Database.AviaInvoiceFlight.Get(invoiceDto.InvoiceId);

            if (ticket == null)
            {
                throw new ValidationException("Ticket not found", "");
            }
            else if (flight == null)
            {
                throw new ValidationException("Flight not found", "");
            }

        }

        public AviaInvoiceDTO GetInvoice(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ValidationException("Property id is not set", "");
            }
            var invoice = Database.AviaInvoice.Get(id);

            if (invoice == null)
            {
                throw new ValidationException("Invoice not found", "");
            }

            Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoice, AviaInvoiceDTO>());
            return Mapper.Map<AviaInvoice, AviaInvoiceDTO>(invoice);
        }

        public IEnumerable<AviaInvoiceDTO> GetInvoices()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoice, AviaInvoiceDTO>());
            return Mapper.Map<IEnumerable<AviaInvoice>, List<AviaInvoiceDTO>>(Database.AviaInvoice.GetAll());
        }

        public IEnumerable<AviaInvoiceFlightDTO> GetFlights(Guid invoiceId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoiceFlight, AviaInvoiceFlightDTO>());
            return Mapper.Map<IEnumerable<AviaInvoiceFlight>, List<AviaInvoiceFlightDTO>>(Database.AviaInvoiceFlight.Find((flight) => flight.InvoiceId == invoiceId));
        }

        public IEnumerable<AviaInvoiceTicketDTO> GetTickets(Guid invoiceId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoiceTicket, AviaInvoiceTicketDTO>());
            return Mapper.Map<IEnumerable<AviaInvoiceTicket>, List<AviaInvoiceTicketDTO>>(Database.AviaInvoiceTicket.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
