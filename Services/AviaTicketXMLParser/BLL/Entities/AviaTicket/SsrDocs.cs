using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entities.AviaTicket
{
    public class SsrDocs
    {
        public SsrDocs()
        {
            SsrDocsId = Guid.NewGuid();
        }
        [Key]
        public Guid SsrDocsId { get; set; }
        public string AirlineCode { get; set; }
        public string DocType { get; set; }
        public string DocCountry { get; set; }
        public string DocNumber { get; set; }
        public string PaxCountry { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string ExpiryDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public NameElement NameElement { get; set; }
        public Guid NameElementId { get; set; }
    }
}
