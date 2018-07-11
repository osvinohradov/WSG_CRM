﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSG.DAL.Entities.Reference
{
    [Table("References.AviaCompanies")]
    public class AviaCompany
    {
        [Key]
        public Guid AviaCompanyId { get; set; }
        
        public string Name { get; set; }
        public int Code { get; set; }
        public string IATA { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
