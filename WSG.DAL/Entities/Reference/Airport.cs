using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSG.DAL.Entities.Reference
{
    [Table("References.Airports")]
    public class Airport
    {
        [Key]
        public Guid AirportId { get; set; }

        public string Name { get; set; }
        public int Code { get; set; }

        public string NameRus { get; set; }
        public string NameEng { get; set; }
        public string NameUkr { get; set; }

        public string CityRus { get; set; }
        public string CityEng { get; set; }
        public string CityUkr { get; set; }

        public string CountryRus { get; set; }
        public string CountryEng { get; set; }
        public string CountryUkr { get; set; }

        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
