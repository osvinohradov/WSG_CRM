using System;
using System.Collections.Generic;
using WSG.BAL.DTO.Avia;

namespace WSG.BAL.Interfaces
{
    public interface IAviaService
    {
        IEnumerable<AviaGroupInvoiceDTO> GetGoupInvoices();
        AviaGroupInvoiceDTO GetGroupInvoice(Guid id);
        IEnumerable<AviaInvoiceDTO> GetInvoices();
        AviaInvoiceDTO GetInvoice(Guid id);
        AviaGroupInvoiceDTO CreateGroupInvoce(AviaInvoiceDTO invoice);
        AviaInvoiceDTO CreateInvoice(AviaInvoiceDTO invoice);
        void Dispose();
    }
}
