using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSG.DAL.Entities.Reference
{
    [Table("References.Services")]
    public class Service
    {
        [Key]
        public Guid ServiceId { get; set; }

        public string Name { get; set; }
        public string Provider { get; set; }
        public string AdditionalProvider { get; set; }
        public double Nomenclature { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
