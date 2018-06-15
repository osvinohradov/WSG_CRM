using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSG.DAL.Entities.Avia
{
    [Table("GroupInvoice")]
    public class AviaGroupInvoice
    {
        [Key]
        public virtual Guid AviaGroupInvoiceId { get; set; }
        // Short Ticket Information
        public virtual DateTime CreatedDate { get; set; }
        public virtual long Number { get; set; }
        public virtual string CounterpartyName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Agent { get; set; }
        public virtual string Responsible { get; set; }
        public virtual string Comment { get; set; }
        // ----------------------------------------

        public virtual string Organization { get; set; }
        public virtual bool Paid { get; set; }
        public virtual string Client { get; set; }
        public virtual DateTime DateOfPayment { get; set; }
        public virtual DateTime DateOfService { get; set; }
        public virtual string FormOfPayment { get; set; }
        public virtual string CheckingAccount { get; set; }
        public virtual string TotalCurrency { get; set; }
        public virtual double TotalSum { get; set; }
        public virtual string DocumentContent { get; set; }
        public virtual string Curator { get; set; }
        public virtual bool IsImplementation { get; set; }
        public virtual double TotalScore { get; set; }
        public virtual string ContentOfDocument { get; set; }
        
        public virtual ICollection<AviaInvoice> AviaInvoices { get; set; }
    }
}
