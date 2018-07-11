using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSG.DAL.Entities.Reference
{
    [Table("References.Services")]
    public class ServiceType
    {
        [Key]
        public Guid ServiceTypeId { get; set; }

        // General

        public string Name { get; set; }
        public string Provider { get; set; }
        public string AdditionalProvider { get; set; }
        public double Nomenclature { get; set; }

        // Nomenclature

        public Nomenclature CatalogOfNomenclature { get; set; }
        public string ShortTicketName { get; set; }
        public string FullTicketName { get; set; }

        // Service

        public Nomenclature NomenclatureAsService { get; set; }
        public string GeneralServices { get; set; }
        public string AgencyService { get; set; }
        public string OtherService { get; set; }
        public string MPE { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
