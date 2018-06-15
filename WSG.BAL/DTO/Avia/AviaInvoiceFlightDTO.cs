using System;

namespace WSG.BAL.DTO.Avia
{
    public class AviaInvoiceFlightDTO
    {
        public AviaInvoiceFlightDTO()
        {
            AviaInvoiceFlightId = Guid.NewGuid();
        }
        public virtual Guid AviaInvoiceFlightId { get; set; }
        public virtual int? Number { get; set; }
        public virtual string FlightNumber { get; set; }
        public virtual string Place { get; set; }
        public virtual string ArrivalPlace { get; set; }
        public virtual string DeliveryPlace { get; set; }
        public virtual string ServiceKind { get; set; }
        public virtual DateTime? ArrivalDate { get; set; }
        public virtual DateTime? DeliveryDate { get; set; }

        public virtual Guid AviaInvoiceId { get; set; }
    }
}
