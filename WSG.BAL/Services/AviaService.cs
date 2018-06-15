using AutoMapper;
using System;
using System.Collections.Generic;
using WSG.BAL.DTO.Avia;
using WSG.BAL.Infrastructure;
using WSG.BAL.Interfaces;
using WSG.DAL.Interfaces;
using WSG.DAL.Entities.Avia;

namespace WSG.BAL.Services
{
    public class AviaService : IAviaService
    {
        IUnitOfWork Database { get; set; }

        public AviaService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateGroupInvoce(AviaGroupInvoiceDTO aviaGroupInvoiceDTO)
        {
            throw new NotImplementedException();
        }

        public AviaInvoiceDTO GetInvoice(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter id must have a value");
          
            var invoice = Database.AviaInvoices.Get(id);

            if (invoice == null)
            {
                throw new NullReferenceException("Ticket not found");
            }

            Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoice, AviaInvoiceDTO>());
            return Mapper.Map<AviaInvoice, AviaInvoiceDTO>(invoice);
        }

        public AviaGroupInvoiceDTO GetGroupInvoice(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Parameter id must have a value");

            var invoice = Database.AviaGroupInvoices.Get(id);

            if (invoice == null)
            {
                throw new NullReferenceException("Group invoice not found");
            }

            Mapper.Initialize(cfg => cfg.CreateMap<AviaGroupInvoice, AviaGroupInvoiceDTO>());
            return Mapper.Map<AviaGroupInvoice, AviaGroupInvoiceDTO>(invoice);
        }

        public IEnumerable<AviaInvoiceDTO> GetInvoices()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AviaInvoice, AviaInvoiceDTO>());
            return Mapper.Map<IEnumerable<AviaInvoice>, List<AviaInvoiceDTO>>(Database.AviaInvoices.GetAll());
        }

        public IEnumerable<AviaGroupInvoiceDTO> GetGoupInvoices()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AviaGroupInvoice, AviaGroupInvoiceDTO>());
            return Mapper.Map<IEnumerable<AviaGroupInvoice>, List<AviaGroupInvoiceDTO>>(Database.AviaGroupInvoices.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public AviaGroupInvoiceDTO CreateGroupInvoce(AviaInvoiceDTO invoice)
        {
            throw new NotImplementedException();
        }

        public AviaInvoiceDTO CreateInvoice(AviaInvoiceDTO invoice)
        {
            throw new NotImplementedException();
        }
    }
}
