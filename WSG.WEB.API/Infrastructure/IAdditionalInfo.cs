using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSG.WEB.API.Infrastructure
{
    public interface IAdditionalInfo
    {
        double Amount { get; set; }
        double MPE { get; set; }
        string Currency { get;set; }
    }
}